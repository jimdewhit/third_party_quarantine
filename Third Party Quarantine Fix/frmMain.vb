Imports System.IO
Imports System.Net


Public Class frmMain
    Dim objNodeList, tagText, objUpdateCheck
    Dim xmlDoc = CreateObject("Msxml2.DOMDocument")

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboInstallOptions.Items.Add("Install all updates")
        cboInstallOptions.Items.Add("Install selected update")
        cboInstallOptions.SelectedIndex = 0

        GetProgramList()

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
                RunInstaller(GetInstaller(i))
            Next
            'cmdInstall.Enabled = True
            'MsgBox("Install updates for:" & vbNewLine & programs)
        ElseIf Me.cboInstallOptions.SelectedIndex = 1 Then
            'For testing purposes.
            'MsgBox("Install update for " & programs)
            'MsgBox("Install update for " & GetInstaller(lstPrograms.SelectedItem))

            RunInstaller(GetInstaller(lstPrograms.SelectedItem))
            'cmdInstall.Enabled = True
        End If

        ReevaluateQuarantine()

    End Sub

    Private Sub cmdReload_Click(sender As Object, e As EventArgs) Handles cmdReload.Click
        ReevaluateQuarantine()
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
                        fileList = installerDirectory.GetFiles("*" & programName(1) & "*" & "ax" & ".exe")
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
        Else
            lstPrograms.Items.Add("None")
            cmdInstall.Enabled = False
        End If
    End Sub

    Public Sub ReevaluateQuarantine()
        Dim objEvaluate As System.Diagnostics.Process

        cmdInstall.Enabled = False
        lstPrograms.Items.Clear()

        Try
            objEvaluate = New System.Diagnostics.Process()
            objEvaluate.StartInfo.FileName = "C:\Program Files (x86)\Quarantine\quarantine.exe"
            objEvaluate.StartInfo.Arguments = "/e"
            objEvaluate.Start()

            'Wait until the process passes back an exit code 
            objEvaluate.WaitForExit()

            'Free resources associated with this process
            objEvaluate.Close()
        Catch
            MessageBox.Show("Could not start evaluation.", "Error")
        End Try

        GetProgramList()
    End Sub
End Class
