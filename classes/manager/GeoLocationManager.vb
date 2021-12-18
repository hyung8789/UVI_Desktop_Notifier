Imports System.Device.Location
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Threading
Imports OfficeOpenXml
Imports UVI_Desktop_Notifier.Structures

Public Class GeoLocationManager
    ' 위치 관리자 정의
    ' https://docs.microsoft.com/en-us/dotnet/api/system.device.location.geocoordinatewatcher?redirectedfrom=MSDN&view=netframework-4.8
    ' https://epplussoftware.com/en/Developers/

#Region "Public"
    ''' <summary>
    ''' 자신의 고유 한 인스턴스 참조 반환
    ''' </summary>
    ''' <returns>GeoLocationManager 인스턴스</returns>
    Public Shared Function GetInstance() As GeoLocationManager
        If IsNothing(_instance) Then
            _instance = New GeoLocationManager()
        End If

        Return _instance
    End Function
    ''' <summary>
    ''' 위도, 경도가 포함 된 위치 정보 데이터를 포함 한 엑셀 DB 파일의 마지막 수정 일자 반환
    ''' </summary>
    ''' <returns>위도, 경도를 포함 한 위치 정보 데이터를 포함 한 DB의 마지막 수정 일자</returns>
    Public Function GetGeoLocationExcelDbLastModifiedDate() As String
        Static Dim lastModifiedDate As String = String.Empty '마지막 수정 일자

        If lastModifiedDate = String.Empty Then '마지막 수정 일자가 할당되지 않았으면
            Dim excelFileFullPath As String = FileIO.FileSystem.CurrentDirectory + "/" + My.Settings.excelDbFileName
            Dim excelFileInfo As FileInfo = Nothing

            Try
                excelFileInfo = New FileInfo(excelFileFullPath)
                If Not excelFileInfo.Exists Then '해당 파일이 존재하지 않으면
                    Throw New Exception("존재하지 않는 파일 : " + excelFileFullPath)
                End If

                Using package = New ExcelPackage(excelFileInfo, My.Settings.excelDbFilePassword)
                    lastModifiedDate = package.Workbook.Properties.Modified.ToShortDateString()
                End Using

            Catch ex As Exception
                Throw ex
            End Try
        End If

        Return lastModifiedDate
    End Function
    ''' <summary>
    ''' 엑셀 DB 파일로부터 전체 구역 정보 목록 반환
    ''' </summary>
    ''' <returns>전체 구역 정보 목록</returns>
    Public Function GetTotalGeoLocationInfoList() As List(Of GeoLocationInfo)
        Dim retVal As List(Of GeoLocationInfo) = Nothing '반환 값
        Dim excelFileFullPath As String = FileIO.FileSystem.CurrentDirectory + "/" + My.Settings.excelDbFileName
        Dim excelFileInfo As FileInfo = Nothing

        Try
            excelFileInfo = New FileInfo(excelFileFullPath)
            If Not excelFileInfo.Exists Then '해당 파일이 존재하지 않으면
                Throw New Exception("존재하지 않는 파일 : " + excelFileFullPath)
            End If

            Using package = New ExcelPackage(excelFileInfo, My.Settings.excelDbFilePassword)
                Dim sheet = package.Workbook.Worksheets(My.Settings.excelDbFileWorkSheetName)
                Dim startAddr As ExcelCellAddress = sheet.Dimension.Start '셀의 행과 열에 대한 시작 주소
                Dim endAddr As ExcelCellAddress = sheet.Dimension.End '셀의 행과 열에 대한 끝 주소 
                Dim dataRangeStartRowNum As Integer = startAddr.Row + 1 '데이터가 포함 된 셀만 포함 한 시작 행 번호
                Dim dataRangeEndRowNum As Integer = endAddr.Row - 1 '데이터가 포함 된 셀만 포함 한 끝 행 번호

                '데이터가 포함 된 셀만 포함 된 범위
                Dim resultRange As ExcelRange = sheet.Cells("B" + dataRangeStartRowNum.ToString + ":E" + dataRangeEndRowNum.ToString) '행정구역코드, 1단계, 2단계, 3단계 범위
                Dim latitudeRange As ExcelRange = sheet.Cells("O" + dataRangeStartRowNum.ToString + ":O" + dataRangeEndRowNum.ToString) '위도 범위
                Dim longitudeRange As ExcelRange = sheet.Cells("N" + dataRangeStartRowNum.ToString + ":N" + dataRangeEndRowNum.ToString) '경도 범위

                retVal = New List(Of GeoLocationInfo)

                For rowOffset = 0 To (dataRangeEndRowNum - dataRangeStartRowNum) '데이터가 포함 된 셀 행들에 대해 (오프셋이므로 resultRange의 0부터 시작)
                    Dim tmpGeoLocationInfo As New GeoLocationInfo()

                    tmpGeoLocationInfo.Latitude = latitudeRange.GetCellValue(Of Double)(rowOffset, 0)
                    tmpGeoLocationInfo.Longitude = longitudeRange.GetCellValue(Of Double)(rowOffset, 0)
                    tmpGeoLocationInfo.AreaNum = resultRange.GetCellValue(Of String)(rowOffset, 0).Trim()
                    tmpGeoLocationInfo.FullName = (resultRange.GetCellValue(Of String)(rowOffset, 1) + " " +
                            resultRange.GetCellValue(Of String)(rowOffset, 2) + " " +
                            resultRange.GetCellValue(Of String)(rowOffset, 3)).Trim() '해당 구역의 전체 이름   

                    retVal.Add(tmpGeoLocationInfo)
                Next

                retVal.Sort(Function(x, y) x.FullName.CompareTo(y.FullName)) '전체 이름 기준 오름차순 정렬
            End Using

        Catch ex As Exception
            Throw ex
        End Try

        Return retVal
    End Function
    ''' <summary>
    ''' 엑셀 DB 파일로부터 위도, 경도를 포함 한 위치 정보 데이터에 대해 가장 유사한 구역 정보 반환
    ''' </summary>
    ''' <param name="srcGeoCoord">대상 위치 정보 데이터</param>
    ''' <returns>대상 위치 정보 데이터에 대한 가장 유사한 구역 정보 반환, 가장 유사한 구역이 존재하지 않을 시 Nothing 반환</returns>
    Public Function GetSimilarGeoLocationInfo(ByVal srcGeoCoord As GeoCoordinate) As GeoLocationInfo
        Static Dim lastSimilarGeoLocationInfo As GeoLocationInfo = Nothing '이전 대상 위치 정보 데이터에 대한 가장 유사한 구역 정보

        If IsNothing(srcGeoCoord) Then '대상 위치 정보 데이터가 존재하지 않으면
            Throw New Exception("위치 정보 데이터가 존재하지 않음 : 재시도하거나 수동으로 지역을 선택하세요.")
        End If

        '   o) 이전 대상 위치 정보 데이터에 대한 가장 유사한 구역 정보 존재 여부 (T : 존재, F : 미 존재)
        '   n) 이전 대상 위치 정보 데이터에 대한 가장 유사한 구역 정보와 새로운 대상 위치 정보 데이터 (srcGeoCoord)의 위도와 경도 동일 여부 (T : 동일, F : 다름)
        '   d) 이에 따른 수행 작업
        '
        '   o | n | d
        '   T   T   이전에 할당 된 대상 위치 정보 데이터에 대한 가장 유사한 구역 정보 반환
        '   T   F   새로운 대상 위치 정보 데이터 (srcGeoCoord)를 통한 가장 유사한 구역 탐색, 할당 및 반환
        '   F   -   새로운 대상 위치 정보 데이터 (srcGeoCoord)를 통한 가장 유사한 구역 탐색, 할당 및 반환

        If IsNothing(lastSimilarGeoLocationInfo) Then 'F -
            GoTo ALLOCATE_PROC

        Else 'T T or T F
            Dim lastGeoCoord As New GeoCoordinate(lastSimilarGeoLocationInfo.Latitude, lastSimilarGeoLocationInfo.Longitude)
            Dim isSame As Boolean = (lastGeoCoord.Equals(srcGeoCoord)) '이전 대상 위치 정보 데이터의 위도와 경도 동일 여부 판별

            If isSame Then 'T T
                GoTo END_PROC

            Else 'T F
                GoTo ALLOCATE_PROC
            End If
        End If

ALLOCATE_PROC: '새로운 대상 위치 정보 데이터 (srcGeoCoord)를 통한 가장 유사한 구역 탐색, 할당 처리 루틴
        Dim excelFileFullPath As String = FileIO.FileSystem.CurrentDirectory + "/" + My.Settings.excelDbFileName
        Dim excelFileInfo As FileInfo = Nothing

        Try
            excelFileInfo = New FileInfo(excelFileFullPath)
            If Not excelFileInfo.Exists Then '해당 파일이 존재하지 않으면
                Throw New Exception("존재하지 않는 파일 : " + excelFileFullPath)
            End If

            Using package = New ExcelPackage(excelFileInfo, My.Settings.excelDbFilePassword)
                Dim sheet = package.Workbook.Worksheets(My.Settings.excelDbFileWorkSheetName)
                Dim startAddr As ExcelCellAddress = sheet.Dimension.Start '셀의 행과 열에 대한 시작 주소
                Dim endAddr As ExcelCellAddress = sheet.Dimension.End '셀의 행과 열에 대한 끝 주소 
                Dim dataRangeStartRowNum As Integer = startAddr.Row + 1 '데이터가 포함 된 셀만 포함 한 시작 행 번호
                Dim dataRangeEndRowNum As Integer = endAddr.Row - 1 '데이터가 포함 된 셀만 포함 한 끝 행 번호

                '데이터가 포함 된 셀만 포함 된 범위
                Dim resultRange As ExcelRange = sheet.Cells("B" + dataRangeStartRowNum.ToString + ":E" + dataRangeEndRowNum.ToString) '행정구역코드, 1단계, 2단계, 3단계 범위
                Dim latitudeRange As ExcelRange = sheet.Cells("O" + dataRangeStartRowNum.ToString + ":O" + dataRangeEndRowNum.ToString) '위도 범위
                Dim longitudeRange As ExcelRange = sheet.Cells("N" + dataRangeStartRowNum.ToString + ":N" + dataRangeEndRowNum.ToString) '경도 범위

                ' 가장 유사한 위도와 경도 (같거나 큰 맨 처음 요소)를 찾기 위해 위도와 경도를 기준 오름차순으로 정렬되어 있어야 함
                ' 위도 및 경도와 가장 일치 한 행정구역코드 및 1단계, 2단계, 3단계를 병합하여 해당 구역의 전체 이름으로 반환
                ' ---
                ' 1) 사용자가 임의로 엑셀 파일을 수정하지 못하도록 암호로 파일을 보호 할 것
                ' 2) 위도와 경도를 기준 오름차순으로 정렬에 따른 오버헤드를 줄이기 위해 미리 엑셀 상에서 정렬 적용 

                Dim similarLocationAddressLinqQuery = (From cell In latitudeRange
                                                       Join cell2 In longitudeRange On cell.Start.Row Equals cell2.Start.Row '위도와 경도의 두 행 번호가 일치 한 것끼리 내부 조인
                                                       Where CDbl(cell.Value.ToString).CompareTo(srcGeoCoord.Latitude) >= 0 And '셀의 위도가 찾고자 하는 위도와 비교하여 같거나 더 큰 경우
                                                       CDbl(cell2.Value.ToString).CompareTo(srcGeoCoord.Longitude) >= 0 '셀의 경도가 찾고자 하는 경도와 비교하여 같거나 더 큰 경우
                                                       Select cell.Address) '가장 유사한 지역들의 셀 주소에 대한 LINQ 쿼리

                ' For Each i In similarLocationAddressLinqQuery
                ' Debug.WriteLine(Regex.Replace(i, "[^0-9]", String.Empty)) '숫자가 아닌 모든 문자에 대해 empty로 치환
                ' Next

                If similarLocationAddressLinqQuery.Count() > 0 Then '유사한 지역의 셀 주소가 존재하면
                    ' 행 번호는 1부터 시작하지만, resultRange 기준 오프셋 0은 데이터가 포함 된 셀만 포함하므로, 행 번호 2와 동일
                    ' ---
                    ' ex) 5013025000 제주특별자치도 서귀포시 대정읍/마라도포함 행 번호 4를 가정 시, resultRange 기준 오프셋은 2가 되어야 함
                    ' 이에 따라, 행정구역코드 및 해당 구역의 전체 이름을 위한 행 오프셋은 행 번호 - 2

                    Dim resultRangeRowOffset As Integer =
                        CInt(Regex.Replace(similarLocationAddressLinqQuery.First, "[^0-9]", String.Empty)) - 2 '오름차순으로 정렬 된 데이터들에 대해 맨 처음 결과에 대한 행 오프셋

                    lastSimilarGeoLocationInfo = New GeoLocationInfo()
                    lastSimilarGeoLocationInfo.AreaNum = resultRange.GetCellValue(Of String)(resultRangeRowOffset, 0) '행정구역코드
                    lastSimilarGeoLocationInfo.FullName = (resultRange.GetCellValue(Of String)(resultRangeRowOffset, 1) + " " +
                        resultRange.GetCellValue(Of String)(resultRangeRowOffset, 2) + " " +
                        resultRange.GetCellValue(Of String)(resultRangeRowOffset, 3)).Trim() '해당 구역의 전체 이름

                    lastSimilarGeoLocationInfo.Latitude = srcGeoCoord.Latitude '위도
                    lastSimilarGeoLocationInfo.Longitude = srcGeoCoord.Longitude '경도

                Else '유사한 지역의 셀 주소가 존재하지 않으면
                End If
            End Using

        Catch ex As Exception
            Throw ex
        End Try

        GoTo END_PROC

END_PROC: '종료 처리 루틴
        Return lastSimilarGeoLocationInfo
    End Function
    ''' <summary>
    ''' 현재 기기의 위도, 경도를 포함 한 위치 정보 데이터 반환
    ''' </summary>
    ''' <returns>현재 기기의 위도, 경도를 포함 한 위치 정보 데이터</returns>
    Public Function GetCurrentGeoCoordinate() As GeoCoordinate
        Dim retVal As GeoCoordinate = Nothing '반환 값
        Dim numOfTries As SByte = 0 '재시도 횟수
        Dim isSuccess As Boolean '위치 정보 가져오기 성공 여부

        If Not My.Settings.autoDetectGeoLocation Then '현재 기기 위치에 따라 자동으로 지역 탐지 (선택 된 지역 목록 무시)가 아닐 경우
            Dim latitude As Double = My.Settings.staticGeoLocationLatitude
            Dim longitude As Double = My.Settings.staticGeoLocationLongitude

            '설정에서 고정 된 위도, 경도 반환
            retVal = New GeoCoordinate(latitude, longitude)

        Else '현재 기기 위치에 따라 자동으로 지역 탐지 (선택 된 지역 목록 무시)
            If Me._watcher.DesiredAccuracy <> My.Settings.geoPositionAccuracy Then '위치 정확도가 변경되었을 경우
                Me._watcher = New GeoCoordinateWatcher(My.Settings.geoPositionAccuracy)
            End If

            If Me._watcher.Permission = GeoPositionPermission.Denied Then '위치 접근 권한이 거부되었을 경우
                Throw New Exception("권한 오류 (" + Me._watcher.Permission.ToString + ") : 제어판 - 개인 정보 - 위치 엑세스를 활성화하세요.")
            End If

SYNC_TRY_START_PROC: '동기적으로 위치 공급자로부터 데이터를 가져오는 처리 루틴
            ' 위치 공급자로부터 TryStart로 동기적으로 TimeSpan 안에 가져오기를 시도하였으나, 
            ' 정상적으로 가져오지 못하거나 알 수 없는 위치 정보를 가져오는 경우
            ' ---
            ' => 위치 서비스가 아직 Initializing 과정에 있을 경우에 발생, 1초 대기하면서 재시도 (대략 위치 서비스가 완전히 Ready 상태가 되는데 2~3초 정도 걸리는 것으로 예상)

            isSuccess = Me._watcher.TryStart(False, TimeSpan.FromMilliseconds(1))
            retVal = Me._watcher.Position.Location
        End If

        If Not isSuccess Or retVal.IsUnknown Then '위치 정보를 가져오지 못했거나, 위도, 경도 데이터가 포함되지 않았으면
            If numOfTries <= My.Settings.numOfTriesThreshold Then '최대 재시도 임계 횟수를 넘지 않은 경우
                numOfTries += 1
                Thread.Sleep(TimeSpan.FromSeconds(1)) '1초 대기
                Debug.WriteLine("재시도 횟수 : " + numOfTries.ToString)
                GoTo SYNC_TRY_START_PROC
            End If

            Throw New Exception("알 수 없는 위치 정보 : 재시도하거나 수동으로 지역을 선택하세요.")
        End If

        Return retVal '위도, 경도를 포함 한 위치 정보 데이터 반환
    End Function
    ''' <summary>
    ''' 디버그용 구역 정보 출력
    ''' </summary>
    ''' <param name="srcGeoLocationInfo">구역 정보</param>
    Public Sub DebugGeoLocationInfo(ByVal srcGeoLocationInfo As GeoLocationInfo)
        Debug.WriteLine("----------------------------------------------------------")
        Debug.WriteLine("행정구역코드 : " + srcGeoLocationInfo.AreaNum)
        Debug.WriteLine("위도 : " + srcGeoLocationInfo.Latitude.ToString)
        Debug.WriteLine("경도 : " + srcGeoLocationInfo.Longitude.ToString)
        Debug.WriteLine("해당 구역의 전체 이름 : " + srcGeoLocationInfo.FullName)
        Debug.WriteLine("----------------------------------------------------------")
    End Sub
    ''' <summary>
    ''' 디버그용 위도, 경도를 포함 한 위치 정보 데이터 출력
    ''' </summary>
    ''' <param name="srcGeoCoord">위도, 경도를 포함 한 위치 정보 데이터</param>
    Public Sub DebugGeoCoordinate(ByVal srcGeoCoord As GeoCoordinate)
        Debug.WriteLine("----------------------------------------------------------")
        Debug.WriteLine("위도 : " + srcGeoCoord.Latitude.ToString)
        Debug.WriteLine("경도 : " + srcGeoCoord.Longitude.ToString)
        Debug.WriteLine("----------------------------------------------------------")
    End Sub
#End Region

#Region "Private"
    Private Shared _instance As GeoLocationManager = Nothing '자신의 고유 인스턴스
    Private _watcher As GeoCoordinateWatcher '위치 데이터 감시자
    ''' <summary>
    ''' GeoLocationManager 인스턴스 초기화
    ''' </summary>
    Private Sub New()
        Me._watcher = New GeoCoordinateWatcher(My.Settings.geoPositionAccuracy)

        '이벤트 핸들러 추가
        'AddHandler Me._watcher.StatusChanged, AddressOf Me.watcher_StatusChanged
        'AddHandler Me._watcher.PositionChanged, AddressOf Me.watcher_PositionChanged
    End Sub
    ''' <summary>
    ''' 상태가 변경되었을 시, GeoCoordinateWatcher의 이벤트 핸들러로서 처리 될 메소드
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub watcher_StatusChanged(sender As Object, e As GeoPositionStatusChangedEventArgs)
        'Debug.WriteLine("현재 상태 : " + e.Status.ToString)
    End Sub
    ''' <summary>
    ''' 위치 데이터의 위도 혹은 경도가 변경되었을 시, GeoCoordinateWatcher의 이벤트 핸들러로서 처리 될 메소드
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub watcher_PositionChanged(sender As Object, e As GeoPositionChangedEventArgs(Of GeoCoordinate))
        'Debug.WriteLine("현재 위도 : " + e.Position.Location.Latitude.ToString)
        'Debug.WriteLine("현재 경도 : " + e.Position.Location.Longitude.ToString)
    End Sub
#End Region
End Class
