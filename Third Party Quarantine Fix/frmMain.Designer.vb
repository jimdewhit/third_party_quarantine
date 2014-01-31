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
        Me.SuspendLayout()
        '
        'lstPrograms
        '
        Me.lstPrograms.FormattingEnabled = True
        Me.lstPrograms.Location = New System.Drawing.Point(13, 13)
        Me.lstPrograms.Name = "lstPrograms"
        Me.lstPrograms.Size = New System.Drawing.Size(232, 199)
        Me.lstPrograms.TabIndex = 0
        '
        'cmdInstall
        '
        Me.cmdInstall.Location = New System.Drawing.Point(298, 140)
        Me.cmdInstall.Name = "cmdInstall"
        Me.cmdInstall.Size = New System.Drawing.Size(144, 43)
        Me.cmdInstall.TabIndex = 1
        Me.cmdInstall.Text = "Install"
        Me.cmdInstall.UseVisualStyleBackColor = True
        '
        'cboInstallOptions
        '
        Me.cboInstallOptions.FormattingEnabled = True
        Me.cboInstallOptions.Location = New System.Drawing.Point(273, 29)
        Me.cboInstallOptions.Name = "cboInstallOptions"
        Me.cboInstallOptions.Size = New System.Drawing.Size(193, 21)
        Me.cboInstallOptions.TabIndex = 2
        '
        'cmdReload
        '
        Me.cmdReload.Location = New System.Drawing.Point(333, 100)
        Me.cmdReload.Name = "cmdReload"
        Me.cmdReload.Size = New System.Drawing.Size(75, 23)
        Me.cmdReload.TabIndex = 3
        Me.cmdReload.Text = "Reload"
        Me.cmdReload.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(492, 233)
        Me.Controls.Add(Me.cmdReload)
        Me.Controls.Add(Me.cboInstallOptions)
        Me.Controls.Add(Me.cmdInstall)
        Me.Controls.Add(Me.lstPrograms)
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.Name = "frmMain"
        Me.Text = "Resolve Third Party Quarantine"
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents lstPrograms As System.Windows.Forms.ListBox
    Friend WithEvents cmdInstall As System.Windows.Forms.Button
    Friend WithEvents cboInstallOptions As System.Windows.Forms.ComboBox
    Friend WithEvents cmdReload As System.Windows.Forms.Button

End Class
