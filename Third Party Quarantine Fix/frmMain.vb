Imports System.IO
Imports System.Net
Imports System.Diagnostics
Imports System.Version
Imports System

Public Class frmMain
    Dim objNodeList, tagText, objUpdateCheck
    Dim xmlDoc = CreateObject("Msxml2.DOMDocument")
    Dim strQuarantineStatus As String

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboInstallOptions.Items.Add("Install all updates")
        cboInstallOptions.Items.Add("Install selected update")
        cboInstallOptions.SelectedIndex = 0

        GetProgramList()

        RunQuarantine("/s", True)

        cmdReload.Hide()

    End Sub

    Private Sub cmdInstall_Click(sender As Object, e As EventArgs) Handles cmdInstall.Click
        cmdInstall.Enabled = False
        Dim programs = ""

        If Me.cboInstallOptions.SelectedIndex = 0 Then
            For Each i In lstPrograms.Items()
                'For testing purposes.
                'programs = programs & GetInstaller(i) & vbNewLine
                'programs = programs & i & vbNewLine
                If i.contains("Shockwave") Then
                    RunInstaller(GetInstaller("Adobe Uninstaller"))
                ElseIf i.contains("Java") Then
                    RunProgramsandFeatures()
                End If
                RunInstaller(GetInstaller(i))
            Next
            'cmdInstall.Enabled = True
            'MsgBox("Install updates for:" & vbNewLine & programs)
        ElseIf Me.cboInstallOptions.SelectedIndex = 1 Then
            'For testing purposes.
            'MsgBox("Install update for " & programs)
            'MsgBox("Install update for " & GetInstaller(lstPrograms.SelectedItem))
            If lstPrograms.SelectedItem.contains("Shockwave") Then
                RunInstaller(GetInstaller("Adobe Uninstaller"))
            ElseIf lstPrograms.SelectedItem.contains("Java") Then
                RunProgramsandFeatures()
            End If
            RunInstaller(GetInstaller(lstPrograms.SelectedItem))
            'cmdInstall.Enabled = True
        End If

        ReevaluateQuarantine()

    End Sub

    Private Sub cmdReload_Click(sender As Object, e As EventArgs) Handles cmdReload.Click
        Dim testString = "This is a test string."
        Dim testArray = testString.Split()
        MessageBox.Show(testArray.Last)
    End Sub

    Function GetInstaller(ByVal program As String) As String
        Dim programName() = Split(program)
        Dim installerSourceDirectory = "\\ant\dept-na\OAK4\Public\IT\Software Updates\"
        Dim installerDirectory As DirectoryInfo
        Dim fileList() As FileInfo
        Dim installer As String = ""

        Try
            If programName(0) = "Adobe" Then
                If programName(1) = "Flash" Then
                    If programName(4) = "ActiveX" Then
                        installerDirectory = New DirectoryInfo(installerSourceDirectory & programName(0))
                        fileList = installerDirectory.GetFiles("*" & programName(1) & "*" & "x" & "*" & ".exe")
                        installer = fileList(0).FullName
                    Else
                        installerDirectory = New DirectoryInfo(installerSourceDirectory & programName(0))
                        fileList = installerDirectory.GetFiles("*" & programName(1) & "*" & ".exe")
                        installer = fileList(0).FullName()
                    End If
                ElseIf programName(1) = "Shockwave" Then
                    installerDirectory = New DirectoryInfo(installerSourceDirectory & programName(0))
                    fileList = installerDirectory.GetFiles("*" & programName(1) & "*" & ".exe")
                    installer = fileList(0).FullName()
                ElseIf programName(1) = "AIR" Then
                    installerDirectory = New DirectoryInfo(installerSourceDirectory & programName(0))
                    fileList = installerDirectory.GetFiles("*" & programName(1) & "*" & ".exe")
                    installer = fileList(0).FullName()
                ElseIf programName(1) = "Reader" Then
                    installerDirectory = New DirectoryInfo(installerSourceDirectory & programName(0))
                    fileList = installerDirectory.GetFiles("*" & "Rdr" & "*" & ".exe")
                    installer = fileList(0).FullName()
                End If
            ElseIf programName(0) = "Mozilla" Then
                installerDirectory = New DirectoryInfo(installerSourceDirectory & programName(1))
                fileList = installerDirectory.GetFiles("*" & programName(1) & "*" & ".exe")
                installer = fileList(0).FullName
            ElseIf programName(0) = "Java" Then
                If programName(2) = "Development" Then
                    If programName.Last = "(64-bit)" Then
                        installerDirectory = New DirectoryInfo(installerSourceDirectory & programName(0))
                        fileList = installerDirectory.GetFiles("*" & "jdk" & "*" & "x64" & ".exe")
                        installer = fileList(0).FullName()
                    Else
                        installerDirectory = New DirectoryInfo(installerSourceDirectory & programName(0))
                        fileList = installerDirectory.GetFiles("*" & "jdk" & "*" & "i586" & ".exe")
                        installer = fileList(0).FullName()
                    End If
                Else
                    If programName.Last = "(64-bit)" Then
                        installerDirectory = New DirectoryInfo(installerSourceDirectory & programName(0))
                        fileList = installerDirectory.GetFiles("*" & "jre" & "*" & "x64" & ".exe")
                        installer = fileList(0).FullName()
                    Else
                        installerDirectory = New DirectoryInfo(installerSourceDirectory & programName(0))
                        fileList = installerDirectory.GetFiles("*" & "jre" & "*" & "i586" & ".exe")
                        installer = fileList(0).FullName()
                    End If
                End If
            Else
                    installerDirectory = New DirectoryInfo(installerSourceDirectory & programName(0))
                    fileList = installerDirectory.GetFiles("*" & programName(0) & "*" & ".exe")
                    installer = fileList(0).FullName
            End If
        Catch ex As Exception
            If programName(0) = "Adobe" Then
                MessageBox.Show("Could not find installer for " & program & vbNewLine & _
                                "Please put the installer for this in " & installerSourceDirectory & programName(0), "Error")
            ElseIf programName(0) = "Mozilla" Then
                MessageBox.Show("Could not find installer for " & program & vbNewLine & _
                                "Please put the installer for this in " & installerSourceDirectory & programName(1), "Error")
            Else
                MessageBox.Show("Could not find installer for " & program & vbNewLine & _
                                "Please put the installer for this in " & installerSourceDirectory & programName(0), "Error")
            End If
        End Try

        Return installer
    End Function

    'Sub borrowed from http://www.freevbcode.com/ShowCode.asp?ID=5879
    Public Sub RunInstaller(ByVal ProcessPath As String)

        Dim objProcess As System.Diagnostics.Process
        Try
            objProcess = New System.Diagnostics.Process()
            objProcess.StartInfo.FileName = ProcessPath
            objProcess.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            objProcess.Start()

            'Wait until the process passes back an exit code 
            objProcess.WaitForExit()

            'Free resources associated with this process
            objProcess.Close()
        Catch
            MessageBox.Show("Could not start process " & ProcessPath, "Error")
        End Try
    End Sub

    Public Sub GetProgramList()
        'For testing purposes.
        'xmlDoc.load("\\ant\dept-na\oak4\Support\IT\James\State_OAK4_9HBB7Y1\Third Party.xml")
        'xmlDoc.load("C:\Users\jwhitney\Desktop\Third Party.xml")

        'Open Quarantine third party software state file.
        'Parse XML file for a tag unique to systems with third party quarantine issues.
        'Parse XML file for the tags containing the applications that need to be updated.

        'If parsing the file returned one or more of the <firstRun> tags,
        'then for each of the programs listed with the <d3p1:Key> tags,
        'extract the name of the program and add it to the list box.
        'Otherwise, add the item "None" to the list box and disable the Install button.

        xmlDoc.load("C:\Program Files (x86)\Quarantine\State\Third Party.xml")
        objUpdateCheck = xmlDoc.getElementsByTagName("firstRun")
        objNodeList = xmlDoc.getElementsByTagName("d3p1:Key")

        If objUpdateCheck.length > 0 Then
            For Each i In objNodeList
                tagText = i.Text
                lstPrograms.Items.Add(tagText)
            Next
            cmdInstall.Enabled = True
        Else
            lstPrograms.Items.Add("None")
            cmdInstall.Enabled = False
        End If
    End Sub

    Public Sub ReevaluateQuarantine()
        cmdInstall.Enabled = False
        lstPrograms.Items.Clear()

        RunQuarantine("/e")
        RunQuarantine("/s", True)

        GetProgramList()
    End Sub

    Public Sub RestartQuarantine()
        Dim objStop As System.Diagnostics.Process
        Dim objStart As System.Diagnostics.Process

        Try
            objStop = New System.Diagnostics.Process()
            objStop.StartInfo.FileName = "net"
            objStop.StartInfo.Arguments = "stop quarantine"
            objStop.Start()

            'Wait until the process passes back an exit code 
            objStop.WaitForExit()

            'Free resources associated with this process
            objStop.Close()

            objStart = New System.Diagnostics.Process()
            objStart.StartInfo.FileName = "net"
            objStart.StartInfo.Arguments = "start quarantine"
            objStart.Start()

            'Wait until the process passes back an exit code 
            objStart.WaitForExit()

            'Free resources associated with this process
            objStart.Close()
        Catch
            MessageBox.Show("Could not restart quarantine.", "Error")
        End Try
    End Sub

    Public Sub RunWindowsUpdates()
        Dim objUpdates As System.Diagnostics.Process

        Try
            objUpdates = New System.Diagnostics.Process()
            objUpdates.StartInfo.FileName = "C:\Windows\system32\wuapp.exe"
            objUpdates.StartInfo.Arguments = "startmenu"
            objUpdates.Start()

            ''Wait until the process passes back an exit code 
            'objUpdates.WaitForExit()

            ''Free resources associated with this process
            'objUpdates.Close()
        Catch
            MessageBox.Show("Could not start Windows Updates.", "Error")
        End Try
    End Sub

    Public Sub RunProgramsandFeatures()
        Dim objUpdates As System.Diagnostics.Process

        Try
            objUpdates = New System.Diagnostics.Process()
            objUpdates.StartInfo.FileName = "control"
            objUpdates.StartInfo.Arguments = "appwiz.cpl"
            objUpdates.Start()

            ''Wait until the process passes back an exit code 
            'objUpdates.WaitForExit()

            ''Free resources associated with this process
            'objUpdates.Close()
        Catch
            MessageBox.Show("Could not start Programs and Features.", "Error")
        End Try
    End Sub

    Public Sub RunQuarantine(ByVal arguments As String, Optional ByVal window As Boolean = False)
        Dim objQuarantine As System.Diagnostics.Process
        Dim readerStatus As IO.StreamReader
        Dim strStatus As String

        Try
            objQuarantine = New System.Diagnostics.Process()
            objQuarantine.StartInfo.FileName = "C:\Program Files (x86)\Quarantine\quarantine.exe"
            objQuarantine.StartInfo.Arguments = arguments
            If window = True Then
                objQuarantine.StartInfo.UseShellExecute = False
                objQuarantine.StartInfo.CreateNoWindow = True
                objQuarantine.StartInfo.RedirectStandardOutput = True
            End If

            objQuarantine.Start()

            If arguments = "/s" And window = True Then
                readerStatus = objQuarantine.StandardOutput
                strStatus = readerStatus.ReadLine()
                lblQuarantineStatus.Text = strStatus
                If lblQuarantineStatus.Text = "ComplianceStatus: Compliant" Then
                    lblQuarantineStatus.ForeColor = Color.Green
                Else
                    lblQuarantineStatus.ForeColor = Color.Red
                End If
            End If

            If arguments = "/cs /q" And window = True Then
                readerStatus = objQuarantine.StandardOutput
                strQuarantineStatus = readerStatus.ReadToEnd()
            End If

            'Wait until the process passes back an exit code 
            objQuarantine.WaitForExit()

            'Free resources associated with this process
            objQuarantine.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error")
        End Try
    End Sub

    Private Sub chkRestart_CheckedChanged(sender As Object, e As EventArgs) Handles chkRestart.CheckedChanged
        If chkRestart.Checked = True Then
            chkEvaluate.Text = "Re-evaluate Quarantine status after restarting service."
        Else
            chkEvaluate.Text = "Re-evaluate Quarantine status."
        End If
    End Sub

    Public Function GetFileVersionInfo(ByVal filename As String) As Version
        Return Version.Parse(FileVersionInfo.GetVersionInfo(filename).FileVersion)
    End Function

    Private Sub cmdQuarantine_Click(sender As Object, e As EventArgs) Handles cmdQuarantine.Click
        If chkRestart.Checked = True And chkEvaluate.Checked = True Then
            RestartQuarantine()
            ReevaluateQuarantine()
        ElseIf chkRestart.Checked = True And chkEvaluate.Checked = False Then
            RestartQuarantine()
        ElseIf chkRestart.Checked = False And chkEvaluate.Checked = True Then
            ReevaluateQuarantine()
        Else
            MessageBox.Show("You didn't select any options. Please try again.", "Error")
        End If

        chkRestart.Checked = False
        chkEvaluate.Checked = False
    End Sub

    Private Sub cmdWindowsUpdates_Click(sender As Object, e As EventArgs) Handles cmdWindowsUpdates.Click
        RunWindowsUpdates()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        RunQuarantine("/cs /q", True)

        MessageBox.Show(strQuarantineStatus)
    End Sub

    Private Sub lblQuarantineStatus_Click(sender As Object, e As EventArgs) Handles lblQuarantineStatus.Click
        RunQuarantine("/cs /q", True)

        MessageBox.Show(strQuarantineStatus, "Quarantine Status Details")
    End Sub

End Class
