Imports System.Configuration
Imports System.Device.Location
Imports UVI_Desktop_Notifier.Constants
Imports UVI_Desktop_Notifier.Structures

Public Class OptionForm
    ' https://docs.microsoft.com/ko-kr/dotnet/visual-basic/developing-apps/programming/app-settings/
#Region "Public"
    ''' <summary>
    ''' 옵션 폼 인스턴스 초기화
    ''' </summary>
    Public Sub New()
        InitializeComponent()

        Me.Init()
    End Sub
#End Region
    Private _refGeoLocationInfoList As List(Of GeoLocationInfo) '전체 구역 정보 리스트 (참조)
#Region "Private"
    ''' <summary>
    ''' 초기화 작업 수행
    ''' </summary>
    Private Sub Init()
        If Me.staticGeoLocation_ComboBox.Items.Count() = 0 Then '콤보박스에 추가 된 항목이 없으면
            If IsNothing(Me._refGeoLocationInfoList) Then
                Dim geoLocationManager As GeoLocationManager = GeoLocationManager.GetInstance()
                Me._refGeoLocationInfoList = geoLocationManager.GetTotalGeoLocationInfoList()
            End If

            For Each i In Me._refGeoLocationInfoList
                Me.staticGeoLocation_ComboBox.Items.Add(i.FullName) '콤보박스에 각 구역의 전체 이름 추가
            Next
        End If

        '기존 옵션 값으로 할당
        Me.staticGeoLocation_ComboBox.SelectedIndex = My.Settings.staticGeoLocationSelectedIndex
        Me.autoDetectGeoLocation_CheckBox.Checked = My.Settings.autoDetectGeoLocation '현재 기기 위치에 따라 자동으로 지역 탐지 (선택 된 지역 목록 무시)에 따라 체크박스 체크 설정

        Select Case My.Settings.geoPositionAccuracy '이전 설정에서 위치 정확도에 따라 위치 정확도 체크박스 체크 설정
            Case GeoPositionAccuracy.Default
                Me.defaultPositionAccuracy_RadioButton.Checked = True

            Case GeoPositionAccuracy.High
                Me.highPositionAccuracy_RadioButton.Checked = True
        End Select

        Me.apiKey_TextBox.Text = My.Settings.apiKey
        Me.excelDbFileName_TextBox.Text = My.Settings.excelDbFileName
        Me.excelDbFileWorkSheetName_TextBox.Text = My.Settings.excelDbFileWorkSheetName
    End Sub
#Region "옵션 폼 기타 이벤트 처리 영역"
    ''' <summary>
    ''' 현재 기기 위치에 따라 자동으로 지역 탐지 (선택 된 지역 목록 무시) 체크박스에 대한 체크 속성 변경 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub autoDetectLocation_CheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles autoDetectGeoLocation_CheckBox.CheckedChanged
        If Me.autoDetectGeoLocation_CheckBox.Checked Then '현재 기기 위치에 따라 자동으로 지역 탐지 (선택 된 지역 목록 무시)가 체크 되었을 경우
            Me.staticGeoLocation_ComboBox.Enabled = False '지역 선택 콤보 박스 비활성화
        Else
            Me.staticGeoLocation_ComboBox.Enabled = True '지역 선택 콤보 박스 활성화
        End If
    End Sub
#End Region

#Region "옵션 폼 하단 버튼 이벤트 처리 영역"
    ''' <summary>
    ''' 링크 라벨에 대한 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub about_LinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles about_LinkLabel.LinkClicked
        System.Diagnostics.Process.Start("https://github.com/hyung8789")
    End Sub
    ''' <summary>
    ''' 링크 라벨에 대한 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>6
    Private Sub apiKey_LinkLabel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles apiKey_LinkLabel.LinkClicked
        System.Diagnostics.Process.Start("https://www.data.go.kr/tcs/dss/selectApiDataDetailView.do?publicDataPk=15085288")
    End Sub
    ''' <summary>
    ''' 초기화 버튼에 대한 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub init_Button_Click(sender As Object, e As EventArgs) Handles init_Button.Click
        My.Settings.Reset()
        Me.Init()
    End Sub
    ''' <summary>
    ''' 확인 버튼에 대한 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub ok_Button_Click(sender As Object, e As EventArgs) Handles ok_Button.Click
        My.Settings.autoDetectGeoLocation = Me.autoDetectGeoLocation_CheckBox.Checked '현재 기기 위치에 따라 자동으로 지역 탐지 (선택 된 지역 목록 무시) 체크박스의 체크 여부
        '현재 선택 된 지역의 위도, 경도 저장
        My.Settings.staticGeoLocationLatitude = Me._refGeoLocationInfoList.ElementAt(Me.staticGeoLocation_ComboBox.SelectedIndex).Latitude
        My.Settings.staticGeoLocationLongitude = Me._refGeoLocationInfoList.ElementAt(Me.staticGeoLocation_ComboBox.SelectedIndex).Longitude
        My.Settings.staticGeoLocationSelectedIndex = Me.staticGeoLocation_ComboBox.SelectedIndex '현재 선택 된 지역의 인덱스 저장

        If Me.defaultPositionAccuracy_RadioButton.Checked Then '보통 정확도가 체크 되었을 경우
            My.Settings.geoPositionAccuracy = GeoPositionAccuracy.Default
        Else '높은 정확도가 체크 되었을 경우
            My.Settings.geoPositionAccuracy = GeoPositionAccuracy.High
        End If

        My.Settings.apiKey = Me.apiKey_TextBox.Text.Trim()
        My.Settings.excelDbFileName = Me.excelDbFileName_TextBox.Text.Trim()
        My.Settings.excelDbFileWorkSheetName = Me.excelDbFileWorkSheetName_TextBox.Text.Trim()
        My.Settings.Save()

        Me.DialogResult = DialogResult.OK
    End Sub
    ''' <summary>
    ''' 취소 버튼에 대한 클릭 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub cancel_Button_Click(sender As Object, e As EventArgs) Handles cancel_Button.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub
    ''' <summary>
    ''' 콤보 박스에 대한 유효성 이벤트 처리
    ''' </summary>
    ''' <param name="sender">이벤트를 발생시킨 객체</param>
    ''' <param name="e">이벤트에 대한 인자</param>
    Private Sub staticGeoLocation_ComboBox_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles staticGeoLocation_ComboBox.Validating
        If Me.staticGeoLocation_ComboBox.SelectedIndex = -1 Then '잘못 된 데이터일 경우 선택 된 인덱스가 -1이므로
            MessageBox.Show("존재하지 않는 지역 명", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error)
            e.Cancel = True '이벤트 취소
        End If
    End Sub
#End Region
#End Region
End Class