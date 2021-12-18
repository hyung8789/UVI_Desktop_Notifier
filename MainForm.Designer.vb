<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.tray_NotifyIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.tray_ContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.open_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.option_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.exit_ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.outerMain_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.innerTopMain_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.suncream_PictureBox = New System.Windows.Forms.PictureBox()
        Me.uviWarning_Label = New System.Windows.Forms.Label()
        Me.uviWarningInfo_GroupBox = New System.Windows.Forms.GroupBox()
        Me.uviWarningInfo_Label = New System.Windows.Forms.Label()
        Me.innerBottomMain_TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.update_Button = New System.Windows.Forms.Button()
        Me.exit_Button = New System.Windows.Forms.Button()
        Me.hide_Button = New System.Windows.Forms.Button()
        Me.version_Label = New System.Windows.Forms.Label()
        Me.tray_ContextMenuStrip.SuspendLayout()
        Me.outerMain_TableLayoutPanel.SuspendLayout()
        Me.innerTopMain_TableLayoutPanel.SuspendLayout()
        CType(Me.suncream_PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.uviWarningInfo_GroupBox.SuspendLayout()
        Me.innerBottomMain_TableLayoutPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'tray_NotifyIcon
        '
        Me.tray_NotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.tray_NotifyIcon.ContextMenuStrip = Me.tray_ContextMenuStrip
        Me.tray_NotifyIcon.Icon = CType(resources.GetObject("tray_NotifyIcon.Icon"), System.Drawing.Icon)
        Me.tray_NotifyIcon.Text = "자외선 지수 데스크톱 알리미"
        Me.tray_NotifyIcon.Visible = True
        '
        'tray_ContextMenuStrip
        '
        Me.tray_ContextMenuStrip.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.tray_ContextMenuStrip.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tray_ContextMenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.open_ToolStripMenuItem, Me.option_ToolStripMenuItem, Me.exit_ToolStripMenuItem})
        Me.tray_ContextMenuStrip.Name = "tray_ContextMenuStrip"
        Me.tray_ContextMenuStrip.Size = New System.Drawing.Size(103, 82)
        '
        'open_ToolStripMenuItem
        '
        Me.open_ToolStripMenuItem.Image = CType(resources.GetObject("open_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.open_ToolStripMenuItem.Name = "open_ToolStripMenuItem"
        Me.open_ToolStripMenuItem.Size = New System.Drawing.Size(102, 26)
        Me.open_ToolStripMenuItem.Text = "열기"
        '
        'option_ToolStripMenuItem
        '
        Me.option_ToolStripMenuItem.Image = CType(resources.GetObject("option_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.option_ToolStripMenuItem.Name = "option_ToolStripMenuItem"
        Me.option_ToolStripMenuItem.Size = New System.Drawing.Size(102, 26)
        Me.option_ToolStripMenuItem.Text = "옵션"
        '
        'exit_ToolStripMenuItem
        '
        Me.exit_ToolStripMenuItem.Image = CType(resources.GetObject("exit_ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.exit_ToolStripMenuItem.Name = "exit_ToolStripMenuItem"
        Me.exit_ToolStripMenuItem.Size = New System.Drawing.Size(102, 26)
        Me.exit_ToolStripMenuItem.Text = "종료"
        '
        'outerMain_TableLayoutPanel
        '
        Me.outerMain_TableLayoutPanel.BackColor = System.Drawing.Color.Transparent
        Me.outerMain_TableLayoutPanel.ColumnCount = 1
        Me.outerMain_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.outerMain_TableLayoutPanel.Controls.Add(Me.innerTopMain_TableLayoutPanel, 0, 0)
        Me.outerMain_TableLayoutPanel.Controls.Add(Me.uviWarningInfo_GroupBox, 0, 1)
        Me.outerMain_TableLayoutPanel.Controls.Add(Me.innerBottomMain_TableLayoutPanel, 0, 2)
        Me.outerMain_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.outerMain_TableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.outerMain_TableLayoutPanel.Name = "outerMain_TableLayoutPanel"
        Me.outerMain_TableLayoutPanel.RowCount = 3
        Me.outerMain_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.outerMain_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.outerMain_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.outerMain_TableLayoutPanel.Size = New System.Drawing.Size(554, 303)
        Me.outerMain_TableLayoutPanel.TabIndex = 1
        '
        'innerTopMain_TableLayoutPanel
        '
        Me.innerTopMain_TableLayoutPanel.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.innerTopMain_TableLayoutPanel.ColumnCount = 2
        Me.innerTopMain_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerTopMain_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.innerTopMain_TableLayoutPanel.Controls.Add(Me.suncream_PictureBox, 0, 0)
        Me.innerTopMain_TableLayoutPanel.Controls.Add(Me.uviWarning_Label, 1, 0)
        Me.innerTopMain_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerTopMain_TableLayoutPanel.Location = New System.Drawing.Point(3, 3)
        Me.innerTopMain_TableLayoutPanel.Name = "innerTopMain_TableLayoutPanel"
        Me.innerTopMain_TableLayoutPanel.RowCount = 1
        Me.innerTopMain_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.innerTopMain_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 115.0!))
        Me.innerTopMain_TableLayoutPanel.Size = New System.Drawing.Size(548, 115)
        Me.innerTopMain_TableLayoutPanel.TabIndex = 0
        '
        'suncream_PictureBox
        '
        Me.suncream_PictureBox.BackColor = System.Drawing.Color.Transparent
        Me.suncream_PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.suncream_PictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.suncream_PictureBox.ErrorImage = Nothing
        Me.suncream_PictureBox.Image = CType(resources.GetObject("suncream_PictureBox.Image"), System.Drawing.Image)
        Me.suncream_PictureBox.InitialImage = Nothing
        Me.suncream_PictureBox.Location = New System.Drawing.Point(3, 3)
        Me.suncream_PictureBox.Name = "suncream_PictureBox"
        Me.suncream_PictureBox.Size = New System.Drawing.Size(103, 109)
        Me.suncream_PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.suncream_PictureBox.TabIndex = 0
        Me.suncream_PictureBox.TabStop = False
        '
        'uviWarning_Label
        '
        Me.uviWarning_Label.AutoSize = True
        Me.uviWarning_Label.BackColor = System.Drawing.Color.Transparent
        Me.uviWarning_Label.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uviWarning_Label.Font = New System.Drawing.Font("굴림", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.uviWarning_Label.ForeColor = System.Drawing.Color.White
        Me.uviWarning_Label.Location = New System.Drawing.Point(112, 0)
        Me.uviWarning_Label.Name = "uviWarning_Label"
        Me.uviWarning_Label.Padding = New System.Windows.Forms.Padding(20, 0, 0, 0)
        Me.uviWarning_Label.Size = New System.Drawing.Size(433, 115)
        Me.uviWarning_Label.TabIndex = 1
        Me.uviWarning_Label.Text = "지역, 업데이트 시간, 오늘, 내일, 모래 자외선 지수"
        Me.uviWarning_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'uviWarningInfo_GroupBox
        '
        Me.uviWarningInfo_GroupBox.BackColor = System.Drawing.Color.Transparent
        Me.uviWarningInfo_GroupBox.Controls.Add(Me.uviWarningInfo_Label)
        Me.uviWarningInfo_GroupBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uviWarningInfo_GroupBox.Location = New System.Drawing.Point(3, 124)
        Me.uviWarningInfo_GroupBox.Name = "uviWarningInfo_GroupBox"
        Me.uviWarningInfo_GroupBox.Size = New System.Drawing.Size(548, 130)
        Me.uviWarningInfo_GroupBox.TabIndex = 1
        Me.uviWarningInfo_GroupBox.TabStop = False
        Me.uviWarningInfo_GroupBox.Text = "정보"
        '
        'uviWarningInfo_Label
        '
        Me.uviWarningInfo_Label.Dock = System.Windows.Forms.DockStyle.Fill
        Me.uviWarningInfo_Label.Font = New System.Drawing.Font("굴림", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(129, Byte))
        Me.uviWarningInfo_Label.Location = New System.Drawing.Point(3, 17)
        Me.uviWarningInfo_Label.Name = "uviWarningInfo_Label"
        Me.uviWarningInfo_Label.Padding = New System.Windows.Forms.Padding(20)
        Me.uviWarningInfo_Label.Size = New System.Drawing.Size(542, 110)
        Me.uviWarningInfo_Label.TabIndex = 0
        Me.uviWarningInfo_Label.Text = "오늘 자외선 지수에 대한 설명문이 출력되는 라벨"
        Me.uviWarningInfo_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'innerBottomMain_TableLayoutPanel
        '
        Me.innerBottomMain_TableLayoutPanel.ColumnCount = 4
        Me.innerBottomMain_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.innerBottomMain_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerBottomMain_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerBottomMain_TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.innerBottomMain_TableLayoutPanel.Controls.Add(Me.update_Button, 1, 0)
        Me.innerBottomMain_TableLayoutPanel.Controls.Add(Me.exit_Button, 2, 0)
        Me.innerBottomMain_TableLayoutPanel.Controls.Add(Me.hide_Button, 3, 0)
        Me.innerBottomMain_TableLayoutPanel.Controls.Add(Me.version_Label, 0, 0)
        Me.innerBottomMain_TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.innerBottomMain_TableLayoutPanel.Location = New System.Drawing.Point(3, 260)
        Me.innerBottomMain_TableLayoutPanel.Name = "innerBottomMain_TableLayoutPanel"
        Me.innerBottomMain_TableLayoutPanel.RowCount = 1
        Me.innerBottomMain_TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.innerBottomMain_TableLayoutPanel.Size = New System.Drawing.Size(548, 40)
        Me.innerBottomMain_TableLayoutPanel.TabIndex = 2
        '
        'update_Button
        '
        Me.update_Button.BackColor = System.Drawing.Color.White
        Me.update_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.update_Button.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.update_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.update_Button.ForeColor = System.Drawing.SystemColors.ControlText
        Me.update_Button.Location = New System.Drawing.Point(222, 3)
        Me.update_Button.Name = "update_Button"
        Me.update_Button.Size = New System.Drawing.Size(103, 34)
        Me.update_Button.TabIndex = 2
        Me.update_Button.Text = "지금 업데이트"
        Me.update_Button.UseVisualStyleBackColor = False
        '
        'exit_Button
        '
        Me.exit_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.exit_Button.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.exit_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.exit_Button.Location = New System.Drawing.Point(331, 3)
        Me.exit_Button.Name = "exit_Button"
        Me.exit_Button.Size = New System.Drawing.Size(103, 34)
        Me.exit_Button.TabIndex = 1
        Me.exit_Button.Text = "종료"
        Me.exit_Button.UseVisualStyleBackColor = True
        '
        'hide_Button
        '
        Me.hide_Button.Dock = System.Windows.Forms.DockStyle.Fill
        Me.hide_Button.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveBorder
        Me.hide_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.hide_Button.Location = New System.Drawing.Point(440, 3)
        Me.hide_Button.Name = "hide_Button"
        Me.hide_Button.Size = New System.Drawing.Size(105, 34)
        Me.hide_Button.TabIndex = 0
        Me.hide_Button.Text = "숨기기"
        Me.hide_Button.UseVisualStyleBackColor = True
        '
        'version_Label
        '
        Me.version_Label.AutoSize = True
        Me.version_Label.Dock = System.Windows.Forms.DockStyle.Fill
        Me.version_Label.Location = New System.Drawing.Point(3, 0)
        Me.version_Label.Name = "version_Label"
        Me.version_Label.Size = New System.Drawing.Size(213, 40)
        Me.version_Label.TabIndex = 0
        Me.version_Label.Text = "app version && db version will be displayed here"
        Me.version_Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(554, 303)
        Me.Controls.Add(Me.outerMain_TableLayoutPanel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.ShowInTaskbar = False
        Me.Text = "자외선 지수 데스크톱 알리미"
        Me.TopMost = True
        Me.tray_ContextMenuStrip.ResumeLayout(False)
        Me.outerMain_TableLayoutPanel.ResumeLayout(False)
        Me.innerTopMain_TableLayoutPanel.ResumeLayout(False)
        Me.innerTopMain_TableLayoutPanel.PerformLayout()
        CType(Me.suncream_PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.uviWarningInfo_GroupBox.ResumeLayout(False)
        Me.innerBottomMain_TableLayoutPanel.ResumeLayout(False)
        Me.innerBottomMain_TableLayoutPanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tray_NotifyIcon As NotifyIcon
    Friend WithEvents outerMain_TableLayoutPanel As TableLayoutPanel
    Friend WithEvents innerTopMain_TableLayoutPanel As TableLayoutPanel
    Friend WithEvents suncream_PictureBox As PictureBox
    Friend WithEvents uviWarning_Label As Label
    Friend WithEvents uviWarningInfo_GroupBox As GroupBox
    Friend WithEvents uviWarningInfo_Label As Label
    Friend WithEvents innerBottomMain_TableLayoutPanel As TableLayoutPanel
    Friend WithEvents version_Label As Label
    Friend WithEvents exit_Button As Button
    Friend WithEvents hide_Button As Button
    Friend WithEvents update_Button As Button
    Friend WithEvents tray_ContextMenuStrip As ContextMenuStrip
    Friend WithEvents open_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents option_ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents exit_ToolStripMenuItem As ToolStripMenuItem
End Class
