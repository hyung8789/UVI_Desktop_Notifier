Imports System.IO
Imports System.Net
Imports System.Xml
Imports UVI_Desktop_Notifier.Constants
Imports UVI_Desktop_Notifier.Structures

Public Class UviManager
    ' 자외선 지수 관리자 정의
#Region "Public"
    ''' <summary>
    ''' 자신의 고유 한 인스턴스 참조 반환
    ''' </summary>
    ''' <returns>UviManager 인스턴스</returns>
    Public Shared Function GetInstance() As UviManager
        If IsNothing(_instance) Then
            _instance = New UviManager()
        End If

        Return _instance
    End Function
    ''' <summary>
    ''' 구역 정보 및 자외선 지수 API 응답 결과에 따라 결과 문자열 반환
    ''' </summary>
    ''' <param name="srcGeoLocationInfo">구역 정보</param>
    ''' <param name="srcUviAPiResponseResult">자외선 지수 API 응답 결과></param>
    ''' <returns>결과 문자열</returns>
    Public Function GetUviResultMsg(ByVal srcGeoLocationInfo As GeoLocationInfo, ByVal srcUviAPiResponseResult As UviApiResponseResult) As String
        Dim resultMsg = String.Empty '결과 문자열

        If IsNothing(srcGeoLocationInfo) Or IsNothing(srcUviAPiResponseResult) Then
            Throw New Exception("구역 정보 혹은 자외선 지수 API 응답 결과가 존재하지 않음 : 재시도하거나 수동으로 지역을 선택하세요.")
        End If

        Dim todayUviWarningLevel As UviWarningLevel = Constants.GetUviWarningLevelFromUvi(srcUviAPiResponseResult.TodayUvi)
        Dim tomorrowUviWarningLevel As UviWarningLevel = Constants.GetUviWarningLevelFromUvi(srcUviAPiResponseResult.TomorrowUvi)
        Dim dayAfterTomorrowUviWarningLevel As UviWarningLevel = Constants.GetUviWarningLevelFromUvi(srcUviAPiResponseResult.DayAfterTomorrowUvi)

        resultMsg = srcGeoLocationInfo.FullName + Environment.NewLine +
            "마지막 업데이트 시간 : " + Date.Now().ToString("yyyy-MM-dd tt hh:mm:ss") + Environment.NewLine + Environment.NewLine +
            "현재 자외선 지수 : " + Constants._strUviWarningLevel(todayUviWarningLevel) + " (" + srcUviAPiResponseResult.TodayUvi.ToString + ") " + Environment.NewLine +
            "내일 자외선 지수 : " + Constants._strUviWarningLevel(tomorrowUviWarningLevel) + " (" + srcUviAPiResponseResult.TomorrowUvi.ToString + ") " + Environment.NewLine +
            "모레 자외선 지수 : " + Constants._strUviWarningLevel(dayAfterTomorrowUviWarningLevel) + " (" + srcUviAPiResponseResult.DayAfterTomorrowUvi.ToString + ") "

        Return resultMsg
    End Function
    ''' <summary>
    ''' 구역 정보에 대한 자외선 지수 API 응답 결과 반환
    ''' </summary>
    ''' <param name="srcGeoLocationInfo">구역 정보</param>
    ''' <returns>구역 정보에 대한 자외선 지수 API 응답 결과</returns>
    Public Function GetUviApiResponseResult(ByVal srcGeoLocationInfo As GeoLocationInfo) As UviApiResponseResult
        ' https://www.data.go.kr/tcs/dss/selectApiDataDetailView.do?publicDataPk=15085288

        If IsNothing(srcGeoLocationInfo) Or String.IsNullOrEmpty(srcGeoLocationInfo.AreaNum) Then
            Throw New Exception("구역 정보 혹은 지점코드가 존재하지 않음 : 재시도하거나 수동으로 지역을 선택하세요.")
        End If

        Dim retVal As UviApiResponseResult = Nothing '지역 번호에 대한 자외선 지수 API 응답 결과
        Dim currentTime As String = Date.Now().ToString("yyyyMMddHH") '현재 시간, ex: 2021121112 (년도월일시 (24시간 기준))
        Dim url As String = "http://apis.data.go.kr/1360000/LivingWthrIdxServiceV2/getUVIdxV2" +
            "?ServiceKey=" + My.Settings.apiKey + 'API 키
            "&pageNo=1" +
            "&numOfRows=10" +
            "&dataType=XML" + '요청 타입 (XML, JSON)
            "&areaNo=" + srcGeoLocationInfo.AreaNum + '지점코드
            "&time=" + currentTime '현재 시간

        Dim request = WebRequest.Create(url) '대상 URL에 대한 요청 생성
        request.Method = "GET" '요청 방법 (GET, POST)
        Dim response As HttpWebResponse = request.GetResponse() '요청에 대한 응답
        Dim results = String.Empty
        Dim reader As StreamReader = New StreamReader(response.GetResponseStream()) '응답 본문으로부터 읽기 스트림 생성
        results = reader.ReadToEnd() '응답 본문의 모든 문자열

        ' https://docs.microsoft.com/ko-kr/dotnet/api/system.xml.xmldocument?view=netframework-4.8&f1url=%3FappId%3DDev16IDEF1%26l%3DKO-KR%26k%3Dk(System.Xml.XmlDocument);k(TargetFrameworkMoniker-.NETFramework,Version%253Dv4.8);k(DevLang-VB)%26rd%3Dtrue
        Dim xml As XmlDocument = New XmlDocument()
        xml.LoadXml(results)

        If Not xml.GetElementsByTagName("resultMsg").Item(0).InnerText.Trim() = "NORMAL_SERVICE" Then '응답 메시지가 정상(NORMAL_SERVICE, 00)이 아닐 경우
            Throw New Exception("잘못 된 API 키 혹은 서버 오류 : : 재시도하거나 API 키를 변경하세요.")
        End If

        Dim todayNode As XmlNode = xml.GetElementsByTagName("today").Item(0) 'today 태그를 갖고 있는 단일 노드
        Dim tomorrowNode As XmlNode = xml.GetElementsByTagName("tomorrow").Item(0) 'tomorrow 태그를 갖고 있는 단일 노드
        Dim dayAfterTomorrowNode As XmlNode = xml.GetElementsByTagName("dayaftertomorrow").Item(0) 'dayaftertomorrow 태그를 갖고 있는 단일 노드

        retVal = New UviApiResponseResult

        '결과가 존재하지 않을 시 0으로 할당 (야간의 경우 오늘의 자외선 지수 값이 할당되지 않음)
        retVal.TodayUvi = If(todayNode.InnerText.Trim() = String.Empty, 0, CByte(todayNode.InnerText.Trim()))
        retVal.TomorrowUvi = If(tomorrowNode.InnerText.Trim() = String.Empty, 0, CByte(tomorrowNode.InnerText.Trim()))
        retVal.DayAfterTomorrowUvi = If(dayAfterTomorrowNode.InnerText.Trim() = String.Empty, 0, CByte(dayAfterTomorrowNode.InnerText.Trim()))

        Return retVal
    End Function
    ''' <summary>
    ''' 디버그용 임의로 생성 된 가상의 자외선 지수 API 응답 결과 반환
    ''' </summary>
    ''' <returns>임의로 생성 된 가상의 자외선 지수 API 응답 결과</returns>
    Public Function DebugGenUviApiResponseResult() As UviApiResponseResult
        Dim rand As New Random()
        Dim minVal As Byte = 0 '최소 자외선 지수
        Dim maxVal As Byte = 11 '최대 자외선 지수

        Dim retVal As New UviApiResponseResult '반환 값
        retVal.TodayUvi = rand.Next(minVal, maxVal)
        retVal.TomorrowUvi = rand.Next(minVal, maxVal)
        retVal.DayAfterTomorrowUvi = rand.Next(minVal, maxVal)

        Return retVal
    End Function
    ''' <summary>
    ''' 디버그용 자외선 지수 API 응답 결과 출력
    ''' </summary>
    ''' <param name="srcUviApiResponseResult">자외선 지수 API 응답 결과</param>
    Public Sub DebugUviApiResponseResult(ByVal srcUviApiResponseResult As UviApiResponseResult)
        Debug.WriteLine("----------------------------------------------------------")
        Debug.WriteLine("오늘 : " + srcUviApiResponseResult.TodayUvi.ToString)
        Debug.WriteLine("내일 : " + srcUviApiResponseResult.TomorrowUvi.ToString)
        Debug.WriteLine("모레 : " + srcUviApiResponseResult.DayAfterTomorrowUvi.ToString)
        Debug.WriteLine("----------------------------------------------------------")
    End Sub
#End Region

#Region "Private"
    Private Shared _instance As UviManager = Nothing '자신의 고유 인스턴스
    ''' <summary>
    ''' UviManager 인스턴스 초기화
    ''' </summary>
    Private Sub New()
    End Sub
#End Region

End Class
