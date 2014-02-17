<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.lstPrograms = New System.Windows.Forms.ListBox()
        Me.cmdInstall = New System.Windows.Forms.Button()
        Me.cboInstallOptions = New System.Windows.Forms.ComboBox()
        Me.cmdReload = New System.Windows.Forms.Button()
        Me.tabMain = New System.Windows.Forms.TabControl()
        Me.tabThirdParty = New System.Windows.Forms.TabPage()
        Me.tabWindowsUpdates = New System.Windows.Forms.TabPage()
        Me.cmdWindowsUpdates = New System.Windows.Forms.Button()
        Me.tabQuarantine = New System.Windows.Forms.TabPage()
        Me.cmdQuarantine = New System.Windows.Forms.Button()
        Me.chkRestart = New System.Windows.Forms.CheckBox()
        Me.chkEvaluate = New System.Windows.Forms.CheckBox()
        Me.lblQuarantineStatus = New System.Windows.Forms.Label()
        Me.tabMain.SuspendLayout()
        Me.tabThirdParty.SuspendLayout()
        Me.tabWindowsUpdates.SuspendLayout()
        Me.tabQuarantine.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstPrograms
        '
        Me.lstPrograms.FormattingEnabled = True
        Me.lstPrograms.Location = New System.Drawing.Point(16, 17)
        Me.lstPrograms.Name = "lstPrograms"
        Me.lstPrograms.Size = New System.Drawing.Size(232, 199)
        Me.lstPrograms.TabIndex = 0
        '
        'cmdInstall
        '
        Me.cmdInstall.Location = New System.Drawing.Point(302, 153)
        Me.cmdInstall.Name = "cmdInstall"
        Me.cmdInstall.Size = New System.Drawing.Size(145, 45)
        Me.cmdInstall.TabIndex = 1
        Me.cmdInstall.Text = "Install"
        Me.cmdInstall.UseVisualStyleBackColor = True
        '
        'cboInstallOptions
        '
        Me.cboInstallOptions.FormattingEnabled = True
        Me.cboInstallOptions.Location = New System.Drawing.Point(279, 35)
        Me.cboInstallOptions.Name = "cboInstallOptions"
        Me.cboInstallOptions.Size = New System.Drawing.Size(193, 21)
        Me.cboInstallOptions.TabIndex = 2
        '
        'cmdReload
        '
        Me.cmdReload.Location = New System.Drawing.Point(335, 91)
        Me.cmdReload.Name = "cmdReload"
        Me.cmdReload.Size = New System.Drawing.Size(75, 23)
        Me.cmdReload.TabIndex = 3
        Me.cmdReload.Text = "Reload"
        Me.cmdReload.UseVisualStyleBackColor = True
        '
        'tabMain
        '
        Me.tabMain.Controls.Add(Me.tabThirdParty)
        Me.tabMain.Controls.Add(Me.tabWindowsUpdates)
        Me.tabMain.Controls.Add(Me.tabQuarantine)
        Me.tabMain.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.tabMain.Location = New System.Drawing.Point(12, 43)
        Me.tabMain.Name = "tabMain"
        Me.tabMain.SelectedIndex = 0
        Me.tabMain.Size = New System.Drawing.Size(497, 254)
        Me.tabMain.TabIndex = 4
        '
        'tabThirdParty
        '
        Me.tabThirdParty.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.tabThirdParty.Controls.Add(Me.lstPrograms)
        Me.tabThirdParty.Controls.Add(Me.cboInstallOptions)
        Me.tabThirdParty.Controls.Add(Me.cmdReload)
        Me.tabThirdParty.Controls.Add(Me.cmdInstall)
        Me.tabThirdParty.Location = New System.Drawing.Point(4, 22)
        Me.tabThirdParty.Name = "tabThirdParty"
        Me.tabThirdParty.Padding = New System.Windows.Forms.Padding(3)
        Me.tabThirdParty.Size = New System.Drawing.Size(489, 228)
        Me.tabThirdParty.TabIndex = 0
        Me.tabThirdParty.Text = "Third Party Programs"
        '
        'tabWindowsUpdates
        '
        Me.tabWindowsUpdates.Controls.Add(Me.cmdWindowsUpdates)
        Me.tabWindowsUpdates.Location = New System.Drawing.Point(4, 22)
        Me.tabWindowsUpdates.Name = "tabWindowsUpdates"
        Me.tabWindowsUpdates.Padding = New System.Windows.Forms.Padding(3)
        Me.tabWindowsUpdates.Size = New System.Drawing.Size(489, 228)
        Me.tabWindowsUpdates.TabIndex = 2
        Me.tabWindowsUpdates.Text = "Windows Updates"
        Me.tabWindowsUpdates.UseVisualStyleBackColor = True
        '
        'cmdWindowsUpdates
        '
        Me.cmdWindowsUpdates.Location = New System.Drawing.Point(172, 140)
        Me.cmdWindowsUpdates.Name = "cmdWindowsUpdates"
        Me.cmdWindowsUpdates.Size = New System.Drawing.Size(145, 45)
        Me.cmdWindowsUpdates.TabIndex = 1
        Me.cmdWindowsUpdates.Text = "Run Windows Updates"
        Me.cmdWindowsUpdates.UseVisualStyleBackColor = True
        '
        'tabQuarantine
        '
        Me.tabQuarantine.Controls.Add(Me.cmdQuarantine)
        Me.tabQuarantine.Controls.Add(Me.chkRestart)
        Me.tabQuarantine.Controls.Add(Me.chkEvaluate)
        Me.tabQuarantine.Location = New System.Drawing.Point(4, 22)
        Me.tabQuarantine.Name = "tabQuarantine"
        Me.tabQuarantine.Padding = New System.Windows.Forms.Padding(3)
        Me.tabQuarantine.Size = New System.Drawing.Size(489, 228)
        Me.tabQuarantine.TabIndex = 1
        Me.tabQuarantine.Text = "Quarantine Service"
        Me.tabQuarantine.UseVisualStyleBackColor = True
        '
        'cmdQuarantine
        '
        Me.cmdQuarantine.Location = New System.Drawing.Point(172, 140)
        Me.cmdQuarantine.Name = "cmdQuarantine"
        Me.cmdQuarantine.Size = New System.Drawing.Size(145, 45)
        Me.cmdQuarantine.TabIndex = 2
        Me.cmdQuarantine.Text = "Run"
        Me.cmdQuarantine.UseVisualStyleBackColor = True
        '
        'chkRestart
        '
        Me.chkRestart.AutoSize = True
        Me.chkRestart.Location = New System.Drawing.Point(20, 32)
        Me.chkRestart.Name = "chkRestart"
        Me.chkRestart.Size = New System.Drawing.Size(155, 17)
        Me.chkRestart.TabIndex = 1
        Me.chkRestart.Text = "Restart Quarantine service."
        Me.chkRestart.UseVisualStyleBackColor = True
        '
        'chkEvaluate
        '
        Me.chkEvaluate.AutoSize = True
        Me.chkEvaluate.Location = New System.Drawing.Point(20, 55)
        Me.chkEvaluate.Name = "chkEvaluate"
        Me.chkEvaluate.Size = New System.Drawing.Size(173, 17)
        Me.chkEvaluate.TabIndex = 0
        Me.chkEvaluate.Text = "Re-evaluate Quarantine status."
        Me.chkEvaluate.UseVisualStyleBackColor = True
        '
        'lblQuarantineStatus
        '
        Me.lblQuarantineStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblQuarantineStatus.Location = New System.Drawing.Point(13, 9)
        Me.lblQuarantineStatus.Name = "lblQuarantineStatus"
        Me.lblQuarantineStatus.Size = New System.Drawing.Size(497, 23)
        Me.lblQuarantineStatus.TabIndex = 5
        Me.lblQuarantineStatus.Text = "Quarantine Status: Unknown"
        Me.lblQuarantineStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(521, 309)
        Me.Controls.Add(Me.lblQuarantineStatus)
        Me.Controls.Add(Me.tabMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.Text = "Quarantine Resolver"
        Me.tabMain.ResumeLayout(False)
        Me.tabThirdParty.ResumeLayout(False)
        Me.tabWindowsUpdates.ResumeLayout(False)
        Me.tabQuarantine.ResumeLayout(False)
        Me.tabQuarantine.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstPrograms As System.Windows.Forms.ListBox
    Friend WithEvents cmdInstall As System.Windows.Forms.Button
    Friend WithEvents cboInstallOptions As System.Windows.Forms.ComboBox
    Friend WithEvents cmdReload As System.Windows.Forms.Button
    Friend WithEvents tabMain As System.Windows.Forms.TabControl
    Friend WithEvents tabThirdParty As System.Windows.Forms.TabPage
    Friend WithEvents tabQuarantine As System.Windows.Forms.TabPage
    Friend WithEvents chkEvaluate As System.Windows.Forms.CheckBox
    Friend WithEvents tabWindowsUpdates As System.Windows.Forms.TabPage
    Friend WithEvents chkRestart As System.Windows.Forms.CheckBox
    Friend WithEvents cmdQuarantine As System.Windows.Forms.Button
    Friend WithEvents cmdWindowsUpdates As System.Windows.Forms.Button
    Friend WithEvents lblQuarantineStatus As System.Windows.Forms.Label

End Class
