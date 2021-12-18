Imports System.Device.Location
Imports System.Threading
Imports UVI_Desktop_Notifier.Structures

Public Class MainForm
#Region "Public"
    ''' <summary>
    ''' 메인 폼 인스턴스 초기화
    ''' </summary>
    Public Sub New()
        InitializeComponent()

        Me.Init()
    End Sub
#End Region

#Region "Private"
    Private _mutex As Mutex '뮤텍스
    ''' <summary>
    ''' 초기화 작업 수행
    ''' </summary>
    Private Sub Init()
        Me.UpdateUviInfo()
    End Sub
    ''' <summary>
    ''' 임계 영역 진입 시도와 진입 성공 여부 반환
    ''' </summary>
    Private Function EnterCriticalSection() As Boolean
        Dim createdNew As Boolean
        Me._mutex = New Mutex(True, Application.ProductName, createdNew)

        Return createdNew
    End Function
    ''' <summary>
    ''' 임계 영역 탈출
    ''' </summary>
    Private Sub LeaveCriticalSection()
        If Not IsNothing(Me._mutex) Then
            Me._mutex.ReleaseMutex()
        End If

        Me._mutex.Dispose()
    End Sub
    ''' <summary>
    ''' 자외선 지수 정보 갱신 및 출력
    ''' </summary>
    Private Sub UpdateUviInfo()
        Dim geoLocationManager As GeoLocationManager = GeoLocationManager.GetInstance()
        Dim uviManager As UviManager = UviManager.GetInstance()
        Dim resultMsg As String = String.Empty '출력 메시지

        Try
            Dim currentGeoCoord As GeoCoordinate = geoLocationManager.GetCurrentGeoCoordinate() '현재 기기의 위치 정보 데이터
            Dim similarGeoLocationInfo As GeoLocationInfo = geoLocationManager.GetSimilarGeoLocationInfo(currentGeoCoord) '현재 기기의 위치 정보 기반 가장 유사한 구역 정보

            If Not IsNothing(similarGeoLocationInfo) Then '현재 기기의 위치 정보 기반 가장 유사한 구역 정보가 존재하면
                Dim result As UviApiResponseResult = uviManager.GetUviApiResponseResult(similarGeoLocationInfo)
                '디버그용 : Dim result As UviApiResponseResult = uviManager.DebugGenUviApiResponseResult()
                resultMsg = uviManager.GetUviResultMsg(similarGeoLocationInfo, result)

                Dim todayUvi As Byte = result.TodayUvi
                Dim tomorrowUvi As Byte = result.TomorrowUvi
                Dim dayAfterTomorrowUvi As Byte = result.DayAfterTomorrowUvi

                Me.innerTopMain_TableLayoutPanel.BackColor = ColorTranslator.FromHtml(
                    Constants._strUviWarningLevelHexBackColor(Constants.GetUviWarningLevelFromUvi(todayUvi))) '자외선 지수 출력 라벨 배경색 설정
                Me.innerTopMain_TableLayoutPanel.Update()
                Me.uviWarningInfo_Label.Text = Constants._strUviWarningLevelInfoMsg(Constants.GetUviWarningLevelFromUvi(todayUvi)) '자외선 지수 정보 출력 라벨 문자열 설정
                Me.uviWarningInfo_Label.Update()
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Me.uviWarning_Label.Text = resultMsg
        Me.uviWarning_Label.Update()
    End Sub
#Region "메인 폼 자체 이벤트 처리 영역"
    ''' <summary>
    ''' 메인 폼 로드 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        '우측 하단 트레이 아이콘 위에 메인 폼 출력
        Dim x As Integer = Screen.PrimaryScreen.WorkingArea.Width - Me.Width
        Dim y As Integer = Screen.PrimaryScreen.WorkingArea.Height - Me.Height
        Me.Location = New Point(x, y)

        Dim geoLocationManager As GeoLocationManager = GeoLocationManager.GetInstance()
        Me.version_Label.Text = "App : v" + Application.ProductVersion + Environment.NewLine +
            "Excel DB : v" + geoLocationManager.GetGeoLocationExcelDbLastModifiedDate() '버전 할당
    End Sub
    ''' <summary>
    ''' 메인 폼 열기
    ''' </summary>
    Private Sub OpenMainForm()
        Me.Visible = True
    End Sub
    ''' <summary>
    ''' 옵션 다이얼로그 폼 열기
    ''' </summary>
    Private Sub OpenOptionDialogForm()
        If Me.EnterCriticalSection() Then '임계 영역 접근 성공 시
            Dim optionForm = New OptionForm()
            optionForm.ShowDialog()
            optionForm.Dispose()

            Me.LeaveCriticalSection() '임계 영역 탈출
            System.GC.Collect() '전체 세대에 대한 강제 가비지 컬렉션 실시
        Else '중복으로 옵션 폼 실행 방지
            Debug.WriteLine("denied")
            'do nothing
        End If
    End Sub
    ''' <summary>
    ''' 트레이 아이콘으로 숨기기
    ''' </summary>
    Private Sub HideProgram()
        Me.Visible = False

        System.GC.Collect() '전체 세대에 대한 강제 가비지 컬렉션 실시
    End Sub
    ''' <summary>
    ''' 프로그램 종료
    ''' </summary>
    Private Sub CloseProgram()
        Me.Close()
    End Sub
    ''' <summary>
    ''' 메인 폼에 대한 비활성화 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub MainForm_Deactivate(sender As Object, e As EventArgs) Handles MyBase.Deactivate
        Me.HideProgram()
    End Sub
#End Region

#Region "메인 폼 하단 버튼 이벤트 처리 영역"
    ''' <summary>
    ''' 지금 업데이트 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub update_Button_Click(sender As Object, e As EventArgs) Handles update_Button.Click
        Me.UpdateUviInfo()
    End Sub
    ''' <summary>
    ''' 종료 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub exit_Button_Click(sender As Object, e As EventArgs) Handles exit_Button.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' 숨기기 버튼 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub hide_Button_Click(sender As Object, e As EventArgs) Handles hide_Button.Click
        Me.HideProgram()
    End Sub
#End Region

#Region "트레이 아이콘에 대한 이벤트 처리 영역"
    ''' <summary>
    ''' 트레이 아이콘에 대한 마우스 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub tray_NotifyIcon_MouseClick(sender As Object, e As MouseEventArgs) Handles tray_NotifyIcon.MouseClick
        Select Case e.Button
            Case MouseButtons.Left '좌 클릭
                Me.OpenMainForm()
            Case MouseButtons.Right '우 클릭
                'do nothing
        End Select
    End Sub
    ''' <summary>
    ''' 트레이 아이콘의 열기 컨텍스트 메뉴에 대한 마우스 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub open_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles open_ToolStripMenuItem.Click
        Me.OpenMainForm()
    End Sub
    ''' <summary>
    ''' 트레이 아이콘의 옵션 컨텍스트 메뉴에 대한 마우스 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub option_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles option_ToolStripMenuItem.Click
        Me.OpenOptionDialogForm()
    End Sub
    ''' <summary>
    ''' 트레이 아이콘의 종료 컨텍스트 메뉴에 대한 마우스 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub exit_ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles exit_ToolStripMenuItem.Click
        Me.CloseProgram()
    End Sub
#End Region
#End Region
End Class
