<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OptionForm
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OptionForm))
        Me.innerOption_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.devOption_GroupBox = New System.Windows.Forms.GroupBox()
        Me.excelDbFileWorkSheetName_TextBox = New System.Windows.Forms.TextBox()
        Me.excelDbFileName_TextBox = New System.Windows.Forms.TextBox()
        Me.apiKey_TextBox = New System.Windows.Forms.TextBox()
        Me.excelDbFileWorkSheetName_Label = New System.Windows.Forms.Label()
        Me.excelDbFileName_Label = New System.Windows.Forms.Label()
        Me.apiKey_LinkLabel = New System.Windows.Forms.LinkLabel()
        Me.apiKey_Label = New System.Windows.Forms.Label()
        Me.detectGeoLocationOption_GroupBox = New System.Windows.Forms.GroupBox()
        Me.positionAccuracy_GroupBox = New System.Windows.Forms.GroupBox()
        Me.defaultPositionAccuracy_RadioButton = New System.Windows.Forms.RadioButton()
        Me.highPositionAccuracy_RadioButton = New System.Windows.Forms.RadioButton()
        Me.autoDetectGeoLocation_CheckBox = New System.Windows.Forms.CheckBox()
        Me.staticGeoLocation_ComboBox = New System.Windows.Forms.ComboBox()
        Me.outerOption_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.innerButtonOption_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.init_Button = New System.Windows.Forms.Button()
        Me.about_LinkLabel = New System.Windows.Forms.LinkLabel()
        Me.ok_Button = New System.Windows.Forms.Button()
        Me.cancel_Button = New System.Windows.Forms.Button()
        Me.innerOption_TableLayoutPanel.SuspendLayout()
        Me.devOption_GroupBox.SuspendLayout()
        Me.detectGeoLocationOption_GroupBox.SuspendLayout()
        Me.positionAccuracy_GroupBox.SuspendLayout()
        Me.outerOption_TableLayoutPanel.SuspendLayout()
        Me.innerButtonOption_TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'innerOption_TableLayoutPanel
        '
        Me.innerOption_TableLayoutPanel.ColumnCount = 3
        Me.innerOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.innerOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerOption_TableLayoutPanel.Controls.Add(Me.devOption_GroupBox, 1, 2)
        Me.innerOption_TableLayoutPanel.Controls.Add(Me.detectGeoLocationOption_GroupBox, 1, 1)
        Me.innerOption_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerOption_TableLayoutPanel.Location = New System.Drawing.Point(3, 3)
        Me.innerOption_TableLayoutPanel.Name = "innerOption_TableLayoutPanel"
        Me.innerOption_TableLayoutPanel.RowCount = 4
        Me.innerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.innerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.innerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.0!))
        Me.innerOption_TableLayoutPanel.Size = New System.Drawing.Size(686, 335)
        Me.innerOption_TableLayoutPanel.TabIndex = 0
        '
        'devOption_GroupBox
        '
        Me.devOption_GroupBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.devOption_GroupBox.Controls.Add(Me.excelDbFileWorkSheetName_TextBox)
        Me.devOption_GroupBox.Controls.Add(Me.excelDbFileName_TextBox)
        Me.devOption_GroupBox.Controls.Add(Me.apiKey_TextBox)
        Me.devOption_GroupBox.Controls.Add(Me.excelDbFileWorkSheetName_Label)
        Me.devOption_GroupBox.Controls.Add(Me.excelDbFileName_Label)
        Me.devOption_GroupBox.Controls.Add(Me.apiKey_LinkLabel)
        Me.devOption_GroupBox.Controls.Add(Me.apiKey_Label)
        Me.devOption_GroupBox.Location = New System.Drawing.Point(37, 119)
        Me.devOption_GroupBox.Name = "devOption_GroupBox"
        Me.devOption_GroupBox.Size = New System.Drawing.Size(611, 195)
        Me.devOption_GroupBox.TabIndex = 1
        Me.devOption_GroupBox.TabStop = False
        Me.devOption_GroupBox.Text = "개발자 옵션"
        '
        'excelDbFileWorkSheetName_TextBox
        '
        Me.excelDbFileWorkSheetName_TextBox.Location = New System.Drawing.Point(16, 171)
        Me.excelDbFileWorkSheetName_TextBox.Name = "excelDbFileWorkSheetName_TextBox"
        Me.excelDbFileWorkSheetName_TextBox.Size = New System.Drawing.Size(582, 21)
        Me.excelDbFileWorkSheetName_TextBox.TabIndex = 6
        '
        'excelDbFileName_TextBox
        '
        Me.excelDbFileName_TextBox.Location = New System.Drawing.Point(16, 114)
        Me.excelDbFileName_TextBox.Name = "excelDbFileName_TextBox"
        Me.excelDbFileName_TextBox.Size = New System.Drawing.Size(582, 21)
        Me.excelDbFileName_TextBox.TabIndex = 5
        '
        'apiKey_TextBox
        '
        Me.apiKey_TextBox.Location = New System.Drawing.Point(16, 55)
        Me.apiKey_TextBox.Name = "apiKey_TextBox"
        Me.apiKey_TextBox.Size = New System.Drawing.Size(582, 21)
        Me.apiKey_TextBox.TabIndex = 4
        '
        'excelDbFileWorkSheetName_Label
        '
        Me.excelDbFileWorkSheetName_Label.AutoSize = True
        Me.excelDbFileWorkSheetName_Label.Location = New System.Drawing.Point(14, 151)
        Me.excelDbFileWorkSheetName_Label.Name = "excelDbFileWorkSheetName_Label"
        Me.excelDbFileWorkSheetName_Label.Size = New System.Drawing.Size(337, 12)
        Me.excelDbFileWorkSheetName_Label.TabIndex = 3
        Me.excelDbFileWorkSheetName_Label.Text = "위도, 경도에 따른 지역명 및 지역별 지점코드 엑셀 DB 시트명"
        '
        'excelDbFileName_Label
        '
        Me.excelDbFileName_Label.AutoSize = True
        Me.excelDbFileName_Label.Location = New System.Drawing.Point(14, 94)
        Me.excelDbFileName_Label.Name = "excelDbFileName_Label"
        Me.excelDbFileName_Label.Size = New System.Drawing.Size(403, 12)
        Me.excelDbFileName_Label.TabIndex = 2
        Me.excelDbFileName_Label.Text = "위도, 경도에 따른 지역명 및 지역별 지점코드 엑셀 DB 파일명 (동일 경로)"
        '
        'apiKey_LinkLabel
        '
        Me.apiKey_LinkLabel.AutoSize = True
        Me.apiKey_LinkLabel.Location = New System.Drawing.Point(112, 35)
        Me.apiKey_LinkLabel.Name = "apiKey_LinkLabel"
        Me.apiKey_LinkLabel.Size = New System.Drawing.Size(481, 12)
        Me.apiKey_LinkLabel.TabIndex = 1
        Me.apiKey_LinkLabel.TabStop = True
        Me.apiKey_LinkLabel.Text = "https://www.data.go.kr/tcs/dss/selectApiDataDetailView.do?publicDataPk=15085288"
        '
        'apiKey_Label
        '
        Me.apiKey_Label.AutoSize = True
        Me.apiKey_Label.Location = New System.Drawing.Point(14, 35)
        Me.apiKey_Label.Name = "apiKey_Label"
        Me.apiKey_Label.Size = New System.Drawing.Size(92, 12)
        Me.apiKey_Label.TabIndex = 0
        Me.apiKey_Label.Text = "발급받은 API 키"
        '
        'detectGeoLocationOption_GroupBox
        '
        Me.detectGeoLocationOption_GroupBox.Controls.Add(Me.positionAccuracy_GroupBox)
        Me.detectGeoLocationOption_GroupBox.Controls.Add(Me.autoDetectGeoLocation_CheckBox)
        Me.detectGeoLocationOption_GroupBox.Controls.Add(Me.staticGeoLocation_ComboBox)
        Me.detectGeoLocationOption_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.detectGeoLocationOption_GroupBox.Location = New System.Drawing.Point(37, 19)
        Me.detectGeoLocationOption_GroupBox.Name = "detectGeoLocationOption_GroupBox"
        Me.detectGeoLocationOption_GroupBox.Size = New System.Drawing.Size(611, 94)
        Me.detectGeoLocationOption_GroupBox.TabIndex = 0
        Me.detectGeoLocationOption_GroupBox.TabStop = False
        Me.detectGeoLocationOption_GroupBox.Text = "지역 탐지 설정"
        '
        'positionAccuracy_GroupBox
        '
        Me.positionAccuracy_GroupBox.Controls.Add(Me.defaultPositionAccuracy_RadioButton)
        Me.positionAccuracy_GroupBox.Controls.Add(Me.highPositionAccuracy_RadioButton)
        Me.positionAccuracy_GroupBox.Location = New System.Drawing.Point(430, 20)
        Me.positionAccuracy_GroupBox.Name = "positionAccuracy_GroupBox"
        Me.positionAccuracy_GroupBox.Size = New System.Drawing.Size(168, 64)
        Me.positionAccuracy_GroupBox.TabIndex = 3
        Me.positionAccuracy_GroupBox.TabStop = False
        Me.positionAccuracy_GroupBox.Text = "자동 지역 탐지 위치 정확도"
        '
        'defaultPositionAccuracy_RadioButton
        '
        Me.defaultPositionAccuracy_RadioButton.AutoSize = True
        Me.defaultPositionAccuracy_RadioButton.Location = New System.Drawing.Point(6, 20)
        Me.defaultPositionAccuracy_RadioButton.Name = "defaultPositionAccuracy_RadioButton"
        Me.defaultPositionAccuracy_RadioButton.Size = New System.Drawing.Size(87, 16)
        Me.defaultPositionAccuracy_RadioButton.TabIndex = 1
        Me.defaultPositionAccuracy_RadioButton.TabStop = True
        Me.defaultPositionAccuracy_RadioButton.Text = "보통 정확도"
        Me.defaultPositionAccuracy_RadioButton.UseVisualStyleBackColor = True
        '
        'highPositionAccuracy_RadioButton
        '
        Me.highPositionAccuracy_RadioButton.AutoSize = True
        Me.highPositionAccuracy_RadioButton.Location = New System.Drawing.Point(6, 42)
        Me.highPositionAccuracy_RadioButton.Name = "highPositionAccuracy_RadioButton"
        Me.highPositionAccuracy_RadioButton.Size = New System.Drawing.Size(87, 16)
        Me.highPositionAccuracy_RadioButton.TabIndex = 2
        Me.highPositionAccuracy_RadioButton.TabStop = True
        Me.highPositionAccuracy_RadioButton.Text = "높은 정확도"
        Me.highPositionAccuracy_RadioButton.UseVisualStyleBackColor = True
        '
        'autoDetectGeoLocation_CheckBox
        '
        Me.autoDetectGeoLocation_CheckBox.AutoSize = True
        Me.autoDetectGeoLocation_CheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.autoDetectGeoLocation_CheckBox.Location = New System.Drawing.Point(16, 30)
        Me.autoDetectGeoLocation_CheckBox.Name = "autoDetectGeoLocation_CheckBox"
        Me.autoDetectGeoLocation_CheckBox.Size = New System.Drawing.Size(387, 16)
        Me.autoDetectGeoLocation_CheckBox.TabIndex = 0
        Me.autoDetectGeoLocation_CheckBox.Text = "현재 기기 위치에 따라 자동으로 지역 탐지 (선택 된 지역 목록 무시)"
        Me.autoDetectGeoLocation_CheckBox.UseVisualStyleBackColor = True
        '
        'staticGeoLocation_ComboBox
        '
        Me.staticGeoLocation_ComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.staticGeoLocation_ComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.staticGeoLocation_ComboBox.FormattingEnabled = True
        Me.staticGeoLocation_ComboBox.Location = New System.Drawing.Point(16, 57)
        Me.staticGeoLocation_ComboBox.Name = "staticGeoLocation_ComboBox"
        Me.staticGeoLocation_ComboBox.Size = New System.Drawing.Size(387, 20)
        Me.staticGeoLocation_ComboBox.TabIndex = 0
        '
        'outerOption_TableLayoutPanel
        '
        Me.outerOption_TableLayoutPanel.ColumnCount = 1
        Me.outerOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.outerOption_TableLayoutPanel.Controls.Add(Me.innerButtonOption_TableLayoutPanel, 0, 1)
        Me.outerOption_TableLayoutPanel.Controls.Add(Me.innerOption_TableLayoutPanel, 0, 0)
        Me.outerOption_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.outerOption_TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.outerOption_TableLayoutPanel.Name = "outerOption_TableLayoutPanel"
        Me.outerOption_TableLayoutPanel.RowCount = 2
        Me.outerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.outerOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.outerOption_TableLayoutPanel.Size = New System.Drawing.Size(692, 379)
        Me.outerOption_TableLayoutPanel.TabIndex = 2
        '
        'innerButtonOption_TableLayoutPanel
        '
        Me.innerButtonOption_TableLayoutPanel.ColumnCount = 4
        Me.innerButtonOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.innerButtonOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerButtonOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerButtonOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerButtonOption_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.innerButtonOption_TableLayoutPanel.Controls.Add(Me.init_Button, 0, 0)
        Me.innerButtonOption_TableLayoutPanel.Controls.Add(Me.about_LinkLabel, 0, 0)
        Me.innerButtonOption_TableLayoutPanel.Controls.Add(Me.ok_Button, 2, 0)
        Me.innerButtonOption_TableLayoutPanel.Controls.Add(Me.cancel_Button, 3, 0)
        Me.innerButtonOption_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerButtonOption_TableLayoutPanel.Location = New System.Drawing.Point(3, 344)
        Me.innerButtonOption_TableLayoutPanel.Name = "innerButtonOption_TableLayoutPanel"
        Me.innerButtonOption_TableLayoutPanel.RowCount = 1
        Me.innerButtonOption_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.innerButtonOption_TableLayoutPanel.Size = New System.Drawing.Size(686, 32)
        Me.innerButtonOption_TableLayoutPanel.TabIndex = 1
        '
        'init_Button
        '
        Me.init_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.init_Button.Location = New System.Drawing.Point(277, 3)
        Me.init_Button.Name = "init_Button"
        Me.init_Button.Size = New System.Drawing.Size(131, 26)
        Me.init_Button.TabIndex = 10
        Me.init_Button.Text = "초기화"
        Me.init_Button.UseVisualStyleBackColor = True
        '
        'about_LinkLabel
        '
        Me.about_LinkLabel.AutoSize = True
        Me.about_LinkLabel.BackColor = System.Drawing.Color.Transparent
        Me.about_LinkLabel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.about_LinkLabel.LinkColor = System.Drawing.Color.Black
        Me.about_LinkLabel.Location = New System.Drawing.Point(3, 0)
        Me.about_LinkLabel.Name = "about_LinkLabel"
        Me.about_LinkLabel.Size = New System.Drawing.Size(268, 32)
        Me.about_LinkLabel.TabIndex = 9
        Me.about_LinkLabel.TabStop = True
        Me.about_LinkLabel.Text = "https://github.com/hyung8789"
        Me.about_LinkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ok_Button
        '
        Me.ok_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ok_Button.Location = New System.Drawing.Point(414, 3)
        Me.ok_Button.Name = "ok_Button"
        Me.ok_Button.Size = New System.Drawing.Size(131, 26)
        Me.ok_Button.TabIndex = 7
        Me.ok_Button.Text = "확인"
        Me.ok_Button.UseVisualStyleBackColor = True
        '
        'cancel_Button
        '
        Me.cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cancel_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cancel_Button.Location = New System.Drawing.Point(551, 3)
        Me.cancel_Button.Name = "cancel_Button"
        Me.cancel_Button.Size = New System.Drawing.Size(132, 26)
        Me.cancel_Button.TabIndex = 8
        Me.cancel_Button.Text = "취소"
        Me.cancel_Button.UseVisualStyleBackColor = True
        '
        'OptionForm
        '
        Me.AcceptButton = Me.ok_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cancel_Button
        Me.ClientSize = New System.Drawing.Size(692, 379)
        Me.Controls.Add(Me.outerOption_TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "OptionForm"
        Me.Text = "Option"
        Me.innerOption_TableLayoutPanel.ResumeLayout(False)
        Me.devOption_GroupBox.ResumeLayout(False)
        Me.devOption_GroupBox.PerformLayout()
        Me.detectGeoLocationOption_GroupBox.ResumeLayout(False)
        Me.detectGeoLocationOption_GroupBox.PerformLayout()
        Me.positionAccuracy_GroupBox.ResumeLayout(False)
        Me.positionAccuracy_GroupBox.PerformLayout()
        Me.outerOption_TableLayoutPanel.ResumeLayout(False)
        Me.innerButtonOption_TableLayoutPanel.ResumeLayout(False)
        Me.innerButtonOption_TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Private WithEvents innerOption_TableLayoutPanel As TableLayoutPanel
    Private WithEvents devOption_GroupBox As GroupBox
    Friend WithEvents autoDetectGeoLocation_CheckBox As CheckBox
    Private WithEvents detectGeoLocationOption_GroupBox As GroupBox
    Friend WithEvents staticGeoLocation_ComboBox As ComboBox
    Private WithEvents outerOption_TableLayoutPanel As TableLayoutPanel
    Private WithEvents innerButtonOption_TableLayoutPanel As TableLayoutPanel
    Private WithEvents ok_Button As Button
    Private WithEvents cancel_Button As Button
    Friend WithEvents about_LinkLabel As LinkLabel
    Friend WithEvents apiKey_Label As Label
    Friend WithEvents apiKey_LinkLabel As LinkLabel
    Friend WithEvents excelDbFileWorkSheetName_Label As Label
    Friend WithEvents excelDbFileName_Label As Label
    Friend WithEvents excelDbFileWorkSheetName_TextBox As TextBox
    Friend WithEvents excelDbFileName_TextBox As TextBox
    Friend WithEvents apiKey_TextBox As TextBox
    Friend WithEvents defaultPositionAccuracy_RadioButton As RadioButton
    Friend WithEvents highPositionAccuracy_RadioButton As RadioButton
    Friend WithEvents positionAccuracy_GroupBox As GroupBox
    Private WithEvents init_Button As Button
End Class
