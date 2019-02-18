' This code is written by Jelle Wietsma WWW.Jellewie.Weebly.Com
' 
'ToDo (Search for "TODO" in these codes)
' Short solve 3.1.2.5
'
' Short these codes in decode serial?
'  L (LRi)       Li (LRi)        R (LRi)       Ri (LRi)
'  L (LiR)       Li (LiR)        R (LiR)       Ri (LiR)
'  (LRi) L       (LRi) Li        (LRi) R       (LRi) Ri
'  (LiR) L       (LiR) Li        (LiR) R       (LiR) Ri
'
' TurnLeftInverseRight gaat fout bij
'
'


Imports System
Imports System.Threading
Imports System.IO.Ports
Imports System.ComponentModel
Public Class Rubiks_Cube_Solver
    Dim MSGBoxName As String
    Dim MSG As String
    Dim myPort As Array
    Dim ArduinoAnswer As String
    Dim ButtonSelected As String
    Dim PrefUSB As String
    'Put under this line your own strings
    Dim Steps As Integer
    Dim ArduinoSteps As Integer
    Dim CountLoops1 As Integer
    Dim CountLoops2 As Integer
    Dim LeftState As Integer
    Dim FrontState As Integer
    Dim RightState As Integer
    Dim ClamFrontState As Integer
    Dim Skip As String
    Dim ArduinoErrors As Integer
    Dim Start As Boolean
    Dim Pauze As Boolean
    Dim starttime As DateTime
    Dim MSGBOXSeconds As Integer
    Dim MSGBOXMinute As Integer
    Dim SMSGBOXSeconds As String
    Dim SMSGBOXMinute As String
    Dim SMSGBOXRunTime As String

    Delegate Sub SetTextCallback(ByVal [text] As String) 'Added to prevent threading errors during receiveing of data
    'Action - (when) Starting up
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ReloadUSB()
        MSGBoxName = "[J] JelleWie"
        ButtonConnectDisconnect.Select()
        RunOnStartup()
    End Sub
    'Button - Reload USB
    Private Sub ComboBoxPoort_USBIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxUSB.Click
        ReloadUSB()
    End Sub
    'Code   - Reload USB
    Sub ReloadUSB()
        PrefUSB = ComboBoxUSB.SelectedItem
        ComboBoxUSB.Items.Clear()
        On Error GoTo ErrHand
        myPort = IO.Ports.SerialPort.GetPortNames()
        ComboBoxUSB.Items.AddRange(myPort)
        ComboBoxUSB.SelectionStart.ToString()
        ComboBoxUSB.SelectedItem = PrefUSB
        If ComboBoxUSB.SelectedItem = "" Then
            ComboBoxUSB.SelectedItem = "COM10"
            ComboBoxUSB.SelectedItem = "COM9"
            ComboBoxUSB.SelectedItem = "COM8"
            ComboBoxUSB.SelectedItem = "COM7"
            ComboBoxUSB.SelectedItem = "COM6"
            ComboBoxUSB.SelectedItem = "COM5"
            ComboBoxUSB.SelectedItem = "COM4"
            ComboBoxUSB.SelectedItem = "COM3"
            ComboBoxUSB.SelectedItem = "COM2"
            ComboBoxUSB.SelectedItem = "COM1"
            ComboBoxUSB.SelectedItem = "COM0"
        End If
ErrHand:
    End Sub
    'Button - Send
    Private Sub ButtonSend_Click(sender As Object, e As EventArgs) Handles ButtonSend.Click
        SerialSend()
    End Sub
    'Button - Enter Pressed (Send)
    Private Sub TextBoxInput_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBoxInput.KeyDown
        If e.KeyCode = Keys.Enter Then
            SerialSend()
        End If
    End Sub
    'Code   - Serial send
    Sub SerialSend()
        RunOnSend()
        If ButtonConnectDisconnect.Text = "Connect" Then
            ButtonConnectDisconnect.Select()
            ButtonSelected = ActiveControl.Name
            MSG = "Where te hell should I write to?!" + Chr(13) + "try connecting first!"
            Dim result As Integer = MessageBox.Show(MSG, MSGBoxName, MessageBoxButtons.OKCancel)
            If result = DialogResult.Cancel Then
            ElseIf result = DialogResult.OK Then
                MsgBox("If your the programmer, Here is your solution" + Chr(13) + Chr(13) + "Put 'Enabled' in the properties of " + ButtonSelected + " to False" + Chr(13) + Chr(13) + "ADD " + Chr(13) + ButtonSelected + ".Enabled = True" + Chr(13) + "TO 'Sub RunOnConnect()'" + Chr(13) + Chr(13) + "ADD " + Chr(13) + ButtonSelected + ".Enabled =False" + Chr(13) + "TO 'Sub RunOnDisconnect()'")
            End If
        Else
            RichTextBoxOutput.Text = ""
            On Error GoTo ErrHand
            SerialPort1.Write(TextBoxInput.Text)
        End If
        Exit Sub
ErrHand:
        MsgBox("You couldn't resist to remove the cable didn't you?", , MSGBoxName)
        Disconnect()
    End Sub
    'Button - Connect and Disconnect
    Private Sub ButtonButtonConnectDisconnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonConnectDisconnect.Click
        If ButtonConnectDisconnect.Text = "Connect" Then
            'Connect
            Connect()
        Else
            'Disconnect
            ButtonConnectDisconnect.Text = "Connect"
            ButtonConnectDisconnect.ForeColor = Color.Green
            Disconnect()
        End If
    End Sub
    'Code   - Connect
    Sub Connect()
        If ComboBoxUSB.Text <> "" Then
            On Error GoTo ErrHand
            SerialPort1.PortName = ComboBoxUSB.Text
            SerialPort1.BaudRate = 9600
            SerialPort1.Open()
            ComboBoxUSB.Enabled = False
            ButtonSend.Enabled = True
            TextBoxInput.Enabled = True
            ButtonConnectDisconnect.Text = "Disconnect"
            ButtonConnectDisconnect.ForeColor = Color.Red
            TextBoxInput.Select()
            RunOnConnect()
        Else
            MsgBox("I can not connect to nothing! what where you thinking..." + Chr(13) + "Please give me a COM poort to connect to, before letting me try to connect to it", , MSGBoxName)
            ReloadUSB()
        End If
        Exit Sub
ErrHand:
        MsgBox("The COM Port your trying to use, does not seems to work annymore" + Chr(13) + "Did you remove the cable again?", , MSGBoxName)
        ReloadUSB()
        ButtonConnectDisconnect.Select()
    End Sub
    'Code   - Disconnect
    Sub Disconnect()
        ComboBoxUSB.Enabled = True
        ButtonSend.Enabled = False
        TextBoxInput.Enabled = False
        ButtonConnectDisconnect.Text = "Connect"
        ButtonConnectDisconnect.ForeColor = Color.Green
        ButtonConnectDisconnect.Select()
        RunOnDisconnect()
        On Error GoTo ErrHand
        SerialPort1.Close()
        Exit Sub
ErrHand:
        ReloadUSB()
    End Sub
    'Action - Recieved serial data
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        System.Threading.Thread.Sleep(5)
        ReceivedText(SerialPort1.ReadExisting())
    End Sub
    'Code   - Recieved serial data
    Private Sub ReceivedText(ByVal [text] As String) 'input from ReadExisting
        On Error GoTo ErrHand
        If Me.RichTextBoxOutput.InvokeRequired Then
            Dim x As New SetTextCallback(AddressOf ReceivedText)
            Me.Invoke(x, New Object() {(text)})
        Else
            Me.RichTextBoxOutput.Text &= [text] 'append text
            ArduinoAnswer = [text]
            RunOnDataRecieved()
        End If
        Exit Sub
ErrHand:
        MsgBox("Error while recieving data", , MSGBoxName)
    End Sub
    '==================================================
    '==================================================
    '==========          Your Codes          ==========
    '==================================================
    '==================================================
    'Action - (when) sending data
    Sub RunOnSend()
        ArduinoSteps = ArduinoSteps + 1
        LabelArduinoSteps.Text = ArduinoSteps
    End Sub
    'Action - (when) starting up
    Sub RunOnStartup()
        SetDropdownboxes()
        ResetSteps()
        ResetSerialSteps()
        ResetCubeState()

        CountLoops1 = 0
        CountLoops2 = 0
        ArduinoErrors = 0
    End Sub
    'Action - (when) Connect
    Sub RunOnConnect()
        ButtonArduino.Enabled = True
        ButtonStartStop.Enabled = True
    End Sub
    'Action - (when) Disconnect
    Sub RunOnDisconnect()
        If Start = True Then
            StopSolve()
        End If
        ButtonArduino.Enabled = False
        ButtonStartStop.Enabled = False
        ButtonConnectDisconnect.Select()
    End Sub
    'Action - (when) Serial data recieved
    Sub RunOnDataRecieved()
        If ArduinoAnswer = "1" Then
            If Start = True Then
                ArduinoButton()
            End If
        ElseIf ArduinoAnswer = "E" Then
            ArduinoError()
        End If
    End Sub
    '==================================================
    '==================================================
    '==========          More Codes          ==========
    '==================================================
    '==================================================
    'Code   - Arduino Error
    Sub ArduinoError()
        SerialSend()
        ArduinoErrors = ArduinoErrors + 1
        LabelErrors.Text = ArduinoErrors
    End Sub
    'Code   - Reset the state of all engines
    Sub ResetCubeState()
        LeftState = 1
        FrontState = 1
        RightState = 1
        ClamFrontState = 1
    End Sub
    'Button - Start and Stop
    Private Sub ButtonStartSolve_Click(sender As Object, e As EventArgs) Handles ButtonStartStop.Click
        If Start = False Then
            StartSolve()
        ElseIf Start = True Then
            StopSolve()
        End If
    End Sub
    'Code   - Stop Solve
    Sub StopSolve()
        ButtonStartStop.Text = "Start"
        ButtonStartStop.ForeColor = Color.Green
        Start = False
    End Sub
    'Code   - Start Solve
    Sub StartSolve()
        ButtonStartStop.Text = "Stop"
        ButtonStartStop.ForeColor = Color.Red
        Start = True
        If LabelStep1.Text = "" And LabelToDo1.Text = "" Then
            'Reset
            starttime = Now
            ResetAll()
            TextBoxInput.Text = "1111"
            SerialSend() 'To reset Actual cube
        Else
            MsgBox("Het programma is gestopt," & Chr(13) & "Proberen door te gaan waar we gebleven waren..", , MSGBoxName)
            ArduinoButton()
        End If
    End Sub
    'Code   - Reset Everything
    Sub ResetAll()
        TextBoxInput.Text = ""
        Steps = 0
        LabelSteps.Text = Steps
        ArduinoSteps = 0
        LabelArduinoSteps.Text = ArduinoSteps
        LabelTimer.Text = 0
        ArduinoErrors = 0
        LabelErrors.Text = ArduinoErrors
        starttime = Now
        RichTextBoxOutput.Text = ""
        ResetSteps()
        ResetSerialSteps()
        ResetCubeState()
        CountLoops1 = 0
        CountLoops2 = 0
    End Sub
    'Button - Reset
    Private Sub ButtonReset_Click(sender As Object, e As EventArgs) Handles ButtonReset.Click
        ResetAll()
        ResetInputVields()
        If ButtonStartStop.Enabled = True Then
            ButtonStartStop.Select()
            StopSolve()
            SerialSend() 'To reset Actual cube
        End If
    End Sub
    'Code   - Reset all Input stuff
    Sub ResetInputVields()
        PictureBox1.BackColor = Color.FromArgb(255, 227, 227, 227)
        PictureBox2.BackColor = Color.FromArgb(255, 227, 227, 227)
        PictureBox3.BackColor = Color.FromArgb(255, 227, 227, 227)
        PictureBox4.BackColor = Color.FromArgb(255, 227, 227, 227)
        PictureBox5.BackColor = Color.FromArgb(255, 227, 227, 227)
        PictureBox6.BackColor = Color.FromArgb(255, 227, 227, 227)
        PictureBox7.BackColor = Color.FromArgb(255, 227, 227, 227)
        PictureBox8.BackColor = Color.FromArgb(255, 227, 227, 227)
        PictureBox9.BackColor = Color.FromArgb(255, 227, 227, 227)
        SetDropdownboxes()
    End Sub
    'Button - Close
    Private Sub Button8_Click_1(sender As Object, e As EventArgs) Handles ButtonClose.Click
        Close()
    End Sub
    'Button - Manual Arduino wants more
    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonArduino.Click
        ArduinoButton()
    End Sub
    'Code   - Arduino wants more
    Sub ArduinoButton()

        LabelTimer.Text = DateDiff(DateInterval.Second, starttime, Now)

        '#### Check if there isnt a next Arduino step
        If LabelStep1.Text = "" Then
            '#### Check if there isnt a next cube turn
            If LabelToDo1.Text = "" Then
                '#### Solve a peace of the cube
                step1_1()
            End If
            'Decode next serial
            DecodeSerial()
            '####Go to next step
            NextStep()
            'Remember amout of Cube turns
            Steps = Steps + 1
            LabelSteps.Text = Steps
        End If
        NextSerial()
        'Clear output
        RichTextBoxOutput.Text = ""
        'Send
        SerialSend()

    End Sub
    'Code   - Connection stuff
    Sub SerialTurnFrontInverse()
        If FrontState > 2 Then
            FrontState = FrontState - 3
        Else
            FrontState = FrontState + 1
        End If
    End Sub
    Sub SerialTurnFront()
        If FrontState < 1 Then
            FrontState = FrontState + 3
        Else
            FrontState = FrontState - 1
        End If
    End Sub
    Sub SerialTurnLeftInverse()
        If LeftState > 2 Then
            LeftState = LeftState - 3
        Else
            LeftState = LeftState + 1
        End If
    End Sub
    Sub SerialTurnLeft()
        If LeftState < 1 Then
            LeftState = LeftState + 3
        Else
            LeftState = LeftState - 1
        End If
    End Sub
    Sub SerialTurnRight()
        If RightState > 2 Then
            RightState = RightState - 3
        Else
            RightState = RightState + 1
        End If
    End Sub
    Sub SerialTurnRightInverse()
        If RightState < 1 Then
            RightState = RightState + 3
        Else
            RightState = RightState - 1
        End If
    End Sub
    'Code   - Decode serial
    Sub DecodeSerial()
        '########################################
        If LabelToDo1.Text = "TurnFront" Then
            If LabelToDo2.Text = "TurnFront" Then
                Skip = "F"
                SerialTurnFront()
                NextStep()
            End If
            SerialTurnFront()
            LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            ClamFrontState = 0
            LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            If Skip = "F" Then
                SerialTurnFrontInverse()
                Skip = ""
            End If
            SerialTurnFrontInverse()
            LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            ClamFrontState = 1
            LabelStep4.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            '########################################
        ElseIf LabelToDo1.Text = "TurnFrontInverse" Then
            If LabelToDo2.Text = "TurnFrontInverse" Then
                Skip = "Fi"
                SerialTurnFrontInverse()
                NextStep()
            End If
            SerialTurnFrontInverse()
            LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            ClamFrontState = 0
            LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            If Skip = "Fi" Then
                SerialTurnFront()
                Skip = ""
            End If
            SerialTurnFront()
            LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            ClamFrontState = 1
            LabelStep4.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            '########################################
        ElseIf LabelToDo1.Text = "TurnLeft" Then
            If LabelToDo2.Text = "TurnLeft" Then
                SerialTurnLeft()
                NextStep()
            ElseIf LabelToDo2.Text = "TurnRight" Then
                SerialTurnRight()
                NextStep()
            ElseIf LabelToDo2.Text = "TurnRightInverse" Then
                SerialTurnRightInverse()
                NextStep()
            End If
            SerialTurnLeft()
            LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            '########################################
        ElseIf LabelToDo1.Text = "TurnLeftInverse" Then
            If LabelToDo2.Text = "TurnLeftInverse" Then
                SerialTurnLeftInverse()
                NextStep()
            ElseIf LabelToDo2.Text = "TurnRight" Then
                SerialTurnRight()
                NextStep()
            ElseIf LabelToDo2.Text = "TurnRightInverse" Then
                SerialTurnRightInverse()
                NextStep()
            End If
            SerialTurnLeftInverse()
            LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            '########################################
        ElseIf LabelToDo1.Text = "TurnRight" Then
            If LabelToDo2.Text = "TurnRight" Then
                SerialTurnRight()
                NextStep()
            ElseIf LabelToDo2.Text = "TurnLeft" Then
                SerialTurnLeft()
                NextStep()
            ElseIf LabelToDo2.Text = "TurnLeftInverse" Then
                SerialTurnLeftInverse()
                NextStep()
            End If
            SerialTurnRight()
            LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            '########################################
        ElseIf LabelToDo1.Text = "TurnRightInverse" Then
            If LabelToDo2.Text = "TurnRightInverse" Then
                SerialTurnRightInverse()
                NextStep()
            ElseIf LabelToDo2.Text = "TurnLeft" Then
                SerialTurnLeft()
                NextStep()
            ElseIf LabelToDo2.Text = "TurnLeftInverse" Then
                SerialTurnLeftInverse()
                NextStep()
            End If
            SerialTurnRightInverse()
            LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            '########################################
        ElseIf LabelToDo1.Text = "TurnLeftRightInverse" Then
            If LabelToDo2.Text = "TurnLeftRightInverse" Then
                NextStep()
                If LeftState < 2 And RightState < 2 Or LeftState > 1 And RightState > 1 Then
                    ClamFrontState = 0
                    LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    SerialTurnLeft()
                    SerialTurnLeft()
                    SerialTurnRight()
                    SerialTurnRight()
                    LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    ClamFrontState = 1
                    LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                ElseIf LeftState < 2 Then
                    SerialTurnLeft()
                    SerialTurnLeft()
                    LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    ClamFrontState = 0
                    LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    SerialTurnLeft()
                    SerialTurnLeft()
                    SerialTurnRight()
                    SerialTurnRight()
                    LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    ClamFrontState = 1
                    LabelStep4.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    SerialTurnLeft()
                    SerialTurnLeft()
                    LabelStep5.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                ElseIf RightState < 2 Then
                    SerialTurnRight()
                    SerialTurnRight()
                    LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    ClamFrontState = 0
                    LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    SerialTurnLeft()
                    SerialTurnLeft()
                    SerialTurnRight()
                    SerialTurnRight()
                    LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    ClamFrontState = 1
                    LabelStep4.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    SerialTurnRight()
                    SerialTurnRight()
                    LabelStep5.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                Else
                    MsgBox("Error #001 - LR2 does not work" & Chr(13) & "RightState" & RightState & Chr(13) & "LeftState" & LeftState, , MSGBoxName)
                End If
            Else
                If LeftState > 2 And RightState > 2 Then
                    ClamFrontState = 0
                    LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    SerialTurnLeft()
                    SerialTurnRightInverse()
                    LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    ClamFrontState = 1
                    LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                ElseIf LeftState < 1 Then
                    SerialTurnLeftInverse()
                    LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    ClamFrontState = 0
                    LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    SerialTurnLeft()
                    SerialTurnRightInverse()
                    ClamFrontState = 1
                    LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    SerialTurnLeft()
                    LabelStep4.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                ElseIf RightState < 1 Then
                    SerialTurnRight()
                    LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    ClamFrontState = 0
                    LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    SerialTurnLeft()
                    SerialTurnRightInverse()
                    ClamFrontState = 1
                    LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    SerialTurnRightInverse()
                    LabelStep4.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                Else
                    ClamFrontState = 0
                    LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    SerialTurnLeftInverse()
                    SerialTurnRight()
                    LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                    ClamFrontState = 1
                    LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                End If
            End If
            '########################################
        ElseIf LabelToDo1.Text = "TurnLeftInverseRight" Then
            If LabelToDo2.Text = "TurnLeftInverseRight" Then
                MsgBox("Error #002 - RL2 doesnt work" & Chr(13) & "I programmed LiR2 somewhere in the code, this should be LRi2", , MSGBoxName)
            End If
            If LeftState < 1 And RightState < 1 Then
                ClamFrontState = 0
                LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                SerialTurnLeftInverse()
                SerialTurnRight()
                LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                ClamFrontState = 1
                LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            ElseIf LeftState < 1 Then
                SerialTurnLeft()
                LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                ClamFrontState = 0
                LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                SerialTurnLeftInverse()
                SerialTurnRight()
                ClamFrontState = 1
                LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                SerialTurnLeftInverse()
                LabelStep4.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            ElseIf RightState < 1 Then
                SerialTurnRightInverse()
                LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                ClamFrontState = 0
                LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                SerialTurnLeftInverse()
                SerialTurnRight()
                ClamFrontState = 1
                LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                SerialTurnRight()
                LabelStep4.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            Else
                ClamFrontState = 0
                LabelStep1.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                SerialTurnLeftInverse()
                SerialTurnRight()
                LabelStep2.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
                ClamFrontState = 1
                LabelStep3.Text = CStr(ClamFrontState) + CStr(LeftState) + CStr(FrontState) + CStr(RightState)
            End If
        End If
    End Sub
    'Code   - Next serial
    Sub NextSerial()
        TextBoxInput.Text = LabelStep1.Text
        LabelStep1.Text = LabelStep2.Text
        LabelStep2.Text = LabelStep3.Text
        LabelStep3.Text = LabelStep4.Text
        LabelStep4.Text = LabelStep5.Text
        LabelStep5.Text = LabelStep6.Text
        LabelStep6.Text = LabelStep7.Text
        LabelStep7.Text = LabelStep8.Text
        LabelStep8.Text = LabelStep9.Text
        LabelStep9.Text = ""
    End Sub
    'Code   - Reset all serial steps
    Sub ResetSerialSteps()
        LabelStep1.Text = ""
        LabelStep2.Text = ""
        LabelStep3.Text = ""
        LabelStep4.Text = ""
        LabelStep5.Text = ""
        LabelStep6.Text = ""
        LabelStep7.Text = ""
        LabelStep8.Text = ""
        LabelStep9.Text = ""
    End Sub
    'Code   - Reset steps
    Sub ResetSteps()
        LabelToDo1.Text = ""
        LabelToDo2.Text = ""
        LabelToDo3.Text = ""
        LabelToDo4.Text = ""
        LabelToDo5.Text = ""
        LabelToDo6.Text = ""
        LabelToDo7.Text = ""
        LabelToDo8.Text = ""
        LabelToDo9.Text = ""
        LabelToDo10.Text = ""
        LabelToDo11.Text = ""
        LabelToDo12.Text = ""
        LabelToDo13.Text = ""
        LabelToDo14.Text = ""
        LabelToDo15.Text = ""
        LabelToDo16.Text = ""
        LabelToDo17.Text = ""
        LabelToDo18.Text = ""
        LabelToDo19.Text = ""
        LabelToDo20.Text = ""
        LabelToDo21.Text = ""
        LabelToDo22.Text = ""
        LabelToDo23.Text = ""
        LabelToDo24.Text = ""
        LabelToDo25.Text = ""
        LabelToDo26.Text = ""
        LabelToDo27.Text = ""
        LabelToDo28.Text = ""
        LabelToDo29.Text = ""
        LabelToDo30.Text = ""
    End Sub
    'Code   - All dropdown options
    Sub SetDropdownboxes()
        ComboBox1.Items.Add("")
        ComboBox1.SelectedItem = ""
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Red")
        ComboBox1.Items.Add("Orange")
        ComboBox1.Items.Add("Blue")
        ComboBox1.Items.Add("Green")
        ComboBox1.Items.Add("Yellow")
        ComboBox1.Items.Add("White")
        ComboBox2.Items.Add("")
        ComboBox2.SelectedItem = ""
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("Red")
        ComboBox2.Items.Add("Orange")
        ComboBox2.Items.Add("Blue")
        ComboBox2.Items.Add("Green")
        ComboBox2.Items.Add("Yellow")
        ComboBox2.Items.Add("White")
        ComboBox3.Items.Add("")
        ComboBox3.SelectedItem = ""
        ComboBox3.Items.Clear()
        ComboBox3.Items.Add("Red")
        ComboBox3.Items.Add("Orange")
        ComboBox3.Items.Add("Blue")
        ComboBox3.Items.Add("Green")
        ComboBox3.Items.Add("Yellow")
        ComboBox3.Items.Add("White")
        ComboBox4.Items.Add("")
        ComboBox4.SelectedItem = ""
        ComboBox4.Items.Clear()
        ComboBox4.Items.Add("Red")
        ComboBox4.Items.Add("Orange")
        ComboBox4.Items.Add("Blue")
        ComboBox4.Items.Add("Green")
        ComboBox4.Items.Add("Yellow")
        ComboBox4.Items.Add("White")
        ComboBox5.Items.Add("")
        ComboBox5.SelectedItem = ""
        ComboBox5.Items.Clear()
        ComboBox5.Items.Add("Red")
        ComboBox5.Items.Add("Orange")
        ComboBox5.Items.Add("Blue")
        ComboBox5.Items.Add("Green")
        ComboBox5.Items.Add("Yellow")
        ComboBox5.Items.Add("White")
        ComboBox6.Items.Add("")
        ComboBox6.SelectedItem = ""
        ComboBox6.Items.Clear()
        ComboBox6.Items.Add("Red")
        ComboBox6.Items.Add("Orange")
        ComboBox6.Items.Add("Blue")
        ComboBox6.Items.Add("Green")
        ComboBox6.Items.Add("Yellow")
        ComboBox6.Items.Add("White")
        ComboBox7.Items.Add("")
        ComboBox7.SelectedItem = ""
        ComboBox7.Items.Clear()
        ComboBox7.Items.Add("Red")
        ComboBox7.Items.Add("Orange")
        ComboBox7.Items.Add("Blue")
        ComboBox7.Items.Add("Green")
        ComboBox7.Items.Add("Yellow")
        ComboBox7.Items.Add("White")
        ComboBox8.Items.Add("")
        ComboBox8.SelectedItem = ""
        ComboBox8.Items.Clear()
        ComboBox8.Items.Add("Red")
        ComboBox8.Items.Add("Orange")
        ComboBox8.Items.Add("Blue")
        ComboBox8.Items.Add("Green")
        ComboBox8.Items.Add("Yellow")
        ComboBox8.Items.Add("White")
        ComboBox9.Items.Add("")
        ComboBox9.SelectedItem = ""
        ComboBox9.Items.Clear()
        ComboBox9.Items.Add("Red")
        ComboBox9.Items.Add("Orange")
        ComboBox9.Items.Add("Blue")
        ComboBox9.Items.Add("Green")
        ComboBox9.Items.Add("Yellow")
        ComboBox9.Items.Add("White")
    End Sub
    'Code   - Turn sides code
    Sub TurnLeft()
        'Turn L side; corners
        PictureBoxRememberColor.BackColor = PictureBox27.BackColor
        PictureBox27.BackColor = PictureBox21.BackColor
        PictureBox21.BackColor = PictureBox19.BackColor
        PictureBox19.BackColor = PictureBox25.BackColor
        PictureBox25.BackColor = PictureBoxRememberColor.BackColor
        'Turn L side; sides
        PictureBoxRememberColor.BackColor = PictureBox26.BackColor
        PictureBox26.BackColor = PictureBox24.BackColor
        PictureBox24.BackColor = PictureBox20.BackColor
        PictureBox20.BackColor = PictureBox22.BackColor
        PictureBox22.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of L; CornerL
        PictureBoxRememberColor.BackColor = PictureBox16.BackColor
        PictureBox16.BackColor = PictureBox48.BackColor
        PictureBox48.BackColor = PictureBox30.BackColor
        PictureBox30.BackColor = PictureBox57.BackColor
        PictureBox57.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of L; CornerR
        PictureBoxRememberColor.BackColor = PictureBox63.BackColor
        PictureBox63.BackColor = PictureBox10.BackColor
        PictureBox10.BackColor = PictureBox54.BackColor
        PictureBox54.BackColor = PictureBox36.BackColor
        PictureBox36.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of L; sides
        PictureBoxRememberColor.BackColor = PictureBox60.BackColor
        PictureBox60.BackColor = PictureBox13.BackColor
        PictureBox13.BackColor = PictureBox51.BackColor
        PictureBox51.BackColor = PictureBox33.BackColor
        PictureBox33.BackColor = PictureBoxRememberColor.BackColor
    End Sub
    Sub TurnLeftInverse()
        'Turn L side; corners
        PictureBoxRememberColor.BackColor = PictureBox27.BackColor
        PictureBox27.BackColor = PictureBox25.BackColor
        PictureBox25.BackColor = PictureBox19.BackColor
        PictureBox19.BackColor = PictureBox21.BackColor
        PictureBox21.BackColor = PictureBoxRememberColor.BackColor
        'Turn L side; sides
        PictureBoxRememberColor.BackColor = PictureBox26.BackColor
        PictureBox26.BackColor = PictureBox22.BackColor
        PictureBox22.BackColor = PictureBox20.BackColor
        PictureBox20.BackColor = PictureBox24.BackColor
        PictureBox24.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of L; CornerL
        PictureBoxRememberColor.BackColor = PictureBox16.BackColor
        PictureBox16.BackColor = PictureBox57.BackColor
        PictureBox57.BackColor = PictureBox30.BackColor
        PictureBox30.BackColor = PictureBox48.BackColor
        PictureBox48.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of L; CornerR
        PictureBoxRememberColor.BackColor = PictureBox63.BackColor
        PictureBox63.BackColor = PictureBox36.BackColor
        PictureBox36.BackColor = PictureBox54.BackColor
        PictureBox54.BackColor = PictureBox10.BackColor
        PictureBox10.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of L; sides
        PictureBoxRememberColor.BackColor = PictureBox60.BackColor
        PictureBox60.BackColor = PictureBox33.BackColor
        PictureBox33.BackColor = PictureBox51.BackColor
        PictureBox51.BackColor = PictureBox13.BackColor
        PictureBox13.BackColor = PictureBoxRememberColor.BackColor
    End Sub
    Sub TurnFront()
        'Turn F side; corners
        PictureBoxRememberColor.BackColor = PictureBox36.BackColor
        PictureBox36.BackColor = PictureBox30.BackColor
        PictureBox30.BackColor = PictureBox28.BackColor
        PictureBox28.BackColor = PictureBox34.BackColor
        PictureBox34.BackColor = PictureBoxRememberColor.BackColor
        'Turn F side; sides
        PictureBoxRememberColor.BackColor = PictureBox35.BackColor
        PictureBox35.BackColor = PictureBox33.BackColor
        PictureBox33.BackColor = PictureBox29.BackColor
        PictureBox29.BackColor = PictureBox31.BackColor
        PictureBox31.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of F; CornerL
        PictureBoxRememberColor.BackColor = PictureBox25.BackColor
        PictureBox25.BackColor = PictureBox54.BackColor
        PictureBox54.BackColor = PictureBox39.BackColor
        PictureBox39.BackColor = PictureBox55.BackColor
        PictureBox55.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of F; CornerR
        PictureBoxRememberColor.BackColor = PictureBox57.BackColor
        PictureBox57.BackColor = PictureBox19.BackColor
        PictureBox19.BackColor = PictureBox52.BackColor
        PictureBox52.BackColor = PictureBox45.BackColor
        PictureBox45.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of F; sides
        PictureBoxRememberColor.BackColor = PictureBox56.BackColor
        PictureBox56.BackColor = PictureBox22.BackColor
        PictureBox22.BackColor = PictureBox53.BackColor
        PictureBox53.BackColor = PictureBox42.BackColor
        PictureBox42.BackColor = PictureBoxRememberColor.BackColor
    End Sub
    Sub TurnFrontInverse()
        'Turn F side; corners
        PictureBoxRememberColor.BackColor = PictureBox36.BackColor
        PictureBox36.BackColor = PictureBox34.BackColor
        PictureBox34.BackColor = PictureBox28.BackColor
        PictureBox28.BackColor = PictureBox30.BackColor
        PictureBox30.BackColor = PictureBoxRememberColor.BackColor
        'Turn F side; sides
        PictureBoxRememberColor.BackColor = PictureBox35.BackColor
        PictureBox35.BackColor = PictureBox31.BackColor
        PictureBox31.BackColor = PictureBox29.BackColor
        PictureBox29.BackColor = PictureBox33.BackColor
        PictureBox33.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of F; CornerL
        PictureBoxRememberColor.BackColor = PictureBox25.BackColor
        PictureBox25.BackColor = PictureBox55.BackColor
        PictureBox55.BackColor = PictureBox39.BackColor
        PictureBox39.BackColor = PictureBox54.BackColor
        PictureBox54.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of F; CornerR
        PictureBoxRememberColor.BackColor = PictureBox57.BackColor
        PictureBox57.BackColor = PictureBox45.BackColor
        PictureBox45.BackColor = PictureBox52.BackColor
        PictureBox52.BackColor = PictureBox19.BackColor
        PictureBox19.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of F; sides
        PictureBoxRememberColor.BackColor = PictureBox56.BackColor
        PictureBox56.BackColor = PictureBox42.BackColor
        PictureBox42.BackColor = PictureBox53.BackColor
        PictureBox53.BackColor = PictureBox22.BackColor
        PictureBox22.BackColor = PictureBoxRememberColor.BackColor
    End Sub
    Sub TurnRight()
        'Turn R side; corners
        PictureBoxRememberColor.BackColor = PictureBox45.BackColor
        PictureBox45.BackColor = PictureBox39.BackColor
        PictureBox39.BackColor = PictureBox37.BackColor
        PictureBox37.BackColor = PictureBox43.BackColor
        PictureBox43.BackColor = PictureBoxRememberColor.BackColor
        'Turn R side; sides
        PictureBoxRememberColor.BackColor = PictureBox44.BackColor
        PictureBox44.BackColor = PictureBox42.BackColor
        PictureBox42.BackColor = PictureBox38.BackColor
        PictureBox38.BackColor = PictureBox40.BackColor
        PictureBox40.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of R; CornerL
        PictureBoxRememberColor.BackColor = PictureBox34.BackColor
        PictureBox34.BackColor = PictureBox52.BackColor
        PictureBox52.BackColor = PictureBox12.BackColor
        PictureBox12.BackColor = PictureBox61.BackColor
        PictureBox61.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of R; CornerR
        PictureBoxRememberColor.BackColor = PictureBox55.BackColor
        PictureBox55.BackColor = PictureBox28.BackColor
        PictureBox28.BackColor = PictureBox46.BackColor
        PictureBox46.BackColor = PictureBox18.BackColor
        PictureBox18.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of R; sides
        PictureBoxRememberColor.BackColor = PictureBox58.BackColor
        PictureBox58.BackColor = PictureBox31.BackColor
        PictureBox31.BackColor = PictureBox49.BackColor
        PictureBox49.BackColor = PictureBox15.BackColor
        PictureBox15.BackColor = PictureBoxRememberColor.BackColor
    End Sub
    Sub TurnRightInverse()
        'Turn R side; corners
        PictureBoxRememberColor.BackColor = PictureBox45.BackColor
        PictureBox45.BackColor = PictureBox43.BackColor
        PictureBox43.BackColor = PictureBox37.BackColor
        PictureBox37.BackColor = PictureBox39.BackColor
        PictureBox39.BackColor = PictureBoxRememberColor.BackColor
        'Turn R side; sides
        PictureBoxRememberColor.BackColor = PictureBox44.BackColor
        PictureBox44.BackColor = PictureBox40.BackColor
        PictureBox40.BackColor = PictureBox38.BackColor
        PictureBox38.BackColor = PictureBox42.BackColor
        PictureBox42.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of R; CornerL
        PictureBoxRememberColor.BackColor = PictureBox34.BackColor
        PictureBox34.BackColor = PictureBox61.BackColor
        PictureBox61.BackColor = PictureBox12.BackColor
        PictureBox12.BackColor = PictureBox52.BackColor
        PictureBox52.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of R; CornerR
        PictureBoxRememberColor.BackColor = PictureBox55.BackColor
        PictureBox55.BackColor = PictureBox18.BackColor
        PictureBox18.BackColor = PictureBox46.BackColor
        PictureBox46.BackColor = PictureBox28.BackColor
        PictureBox28.BackColor = PictureBoxRememberColor.BackColor
        'Turn the sides of R; sides
        PictureBoxRememberColor.BackColor = PictureBox58.BackColor
        PictureBox58.BackColor = PictureBox15.BackColor
        PictureBox15.BackColor = PictureBox49.BackColor
        PictureBox49.BackColor = PictureBox31.BackColor
        PictureBox31.BackColor = PictureBoxRememberColor.BackColor
    End Sub
    Sub TurnLeftInverseRight()
        TurnLeftInverse()

        'turn the middle row
        'turn the middle row; middle
        PictureBoxRememberColor.BackColor = PictureBox32.BackColor
        PictureBox32.BackColor = PictureBox50.BackColor
        PictureBox50.BackColor = PictureBox14.BackColor
        PictureBox14.BackColor = PictureBox59.BackColor
        PictureBox59.BackColor = PictureBoxRememberColor.BackColor
        'turn the middle row; corner 1
        PictureBoxRememberColor.BackColor = PictureBox35.BackColor
        PictureBox35.BackColor = PictureBox53.BackColor
        PictureBox53.BackColor = PictureBox11.BackColor
        PictureBox11.BackColor = PictureBox62.BackColor
        PictureBox62.BackColor = PictureBoxRememberColor.BackColor
        'turn the middle row; corner 2
        PictureBoxRememberColor.BackColor = PictureBox56.BackColor
        PictureBox56.BackColor = PictureBox29.BackColor
        PictureBox29.BackColor = PictureBox47.BackColor
        PictureBox47.BackColor = PictureBox17.BackColor
        PictureBox17.BackColor = PictureBoxRememberColor.BackColor

        TurnRight()
    End Sub
    Sub TurnLeftRightInverse()
        TurnLeft()

        'turn the middle row
        'turn the middle row; middle
        PictureBoxRememberColor.BackColor = PictureBox32.BackColor
        PictureBox32.BackColor = PictureBox59.BackColor
        PictureBox59.BackColor = PictureBox14.BackColor
        PictureBox14.BackColor = PictureBox50.BackColor
        PictureBox50.BackColor = PictureBoxRememberColor.BackColor
        'turn the middle row; corner 1
        PictureBoxRememberColor.BackColor = PictureBox35.BackColor
        PictureBox35.BackColor = PictureBox62.BackColor
        PictureBox62.BackColor = PictureBox11.BackColor
        PictureBox11.BackColor = PictureBox53.BackColor
        PictureBox53.BackColor = PictureBoxRememberColor.BackColor
        'turn the middle row; corner 2
        PictureBoxRememberColor.BackColor = PictureBox56.BackColor
        PictureBox56.BackColor = PictureBox17.BackColor
        PictureBox17.BackColor = PictureBox47.BackColor
        PictureBox47.BackColor = PictureBox29.BackColor
        PictureBox29.BackColor = PictureBoxRememberColor.BackColor

        TurnRightInverse()
    End Sub
    'Buttons- Colors
    'Codes  - Çolors
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "Red" Then
            PictureBox1.BackColor = Color.Red
        ElseIf ComboBox1.Text = "Orange" Then
            PictureBox1.BackColor = Color.Orange
        ElseIf ComboBox1.Text = "Blue" Then
            PictureBox1.BackColor = Color.Blue
        ElseIf ComboBox1.Text = "Green" Then
            PictureBox1.BackColor = Color.Green
        ElseIf ComboBox1.Text = "Yellow" Then
            PictureBox1.BackColor = Color.Yellow
        ElseIf ComboBox1.Text = "White" Then
            PictureBox1.BackColor = Color.White
        End If
    End Sub
    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "Red" Then
            PictureBox2.BackColor = Color.Red
        ElseIf ComboBox2.Text = "Orange" Then
            PictureBox2.BackColor = Color.Orange
        ElseIf ComboBox2.Text = "Blue" Then
            PictureBox2.BackColor = Color.Blue
        ElseIf ComboBox2.Text = "Green" Then
            PictureBox2.BackColor = Color.Green
        ElseIf ComboBox2.Text = "Yellow" Then
            PictureBox2.BackColor = Color.Yellow
        ElseIf ComboBox2.Text = "White" Then
            PictureBox2.BackColor = Color.White
        End If
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "Red" Then
            PictureBox3.BackColor = Color.Red
        ElseIf ComboBox3.Text = "Orange" Then
            PictureBox3.BackColor = Color.Orange
        ElseIf ComboBox3.Text = "Blue" Then
            PictureBox3.BackColor = Color.Blue
        ElseIf ComboBox3.Text = "Green" Then
            PictureBox3.BackColor = Color.Green
        ElseIf ComboBox3.Text = "Yellow" Then
            PictureBox3.BackColor = Color.Yellow
        ElseIf ComboBox3.Text = "White" Then
            PictureBox3.BackColor = Color.White
        End If
    End Sub
    Private Sub ComboBox4_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        If ComboBox4.Text = "Red" Then
            PictureBox4.BackColor = Color.Red
        ElseIf ComboBox4.Text = "Orange" Then
            PictureBox4.BackColor = Color.Orange
        ElseIf ComboBox4.Text = "Blue" Then
            PictureBox4.BackColor = Color.Blue
        ElseIf ComboBox4.Text = "Green" Then
            PictureBox4.BackColor = Color.Green
        ElseIf ComboBox4.Text = "Yellow" Then
            PictureBox4.BackColor = Color.Yellow
        ElseIf ComboBox4.Text = "White" Then
            PictureBox4.BackColor = Color.White
        End If
    End Sub
    Private Sub ComboBox5_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        If ComboBox5.Text = "Red" Then
            PictureBox5.BackColor = Color.Red
        ElseIf ComboBox5.Text = "Orange" Then
            PictureBox5.BackColor = Color.Orange
        ElseIf ComboBox5.Text = "Blue" Then
            PictureBox5.BackColor = Color.Blue
        ElseIf ComboBox5.Text = "Green" Then
            PictureBox5.BackColor = Color.Green
        ElseIf ComboBox5.Text = "Yellow" Then
            PictureBox5.BackColor = Color.Yellow
        ElseIf ComboBox5.Text = "White" Then
            PictureBox5.BackColor = Color.White
        End If
    End Sub
    Private Sub ComboBox6_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged
        If ComboBox6.Text = "Red" Then
            PictureBox6.BackColor = Color.Red
        ElseIf ComboBox6.Text = "Orange" Then
            PictureBox6.BackColor = Color.Orange
        ElseIf ComboBox6.Text = "Blue" Then
            PictureBox6.BackColor = Color.Blue
        ElseIf ComboBox6.Text = "Green" Then
            PictureBox6.BackColor = Color.Green
        ElseIf ComboBox6.Text = "Yellow" Then
            PictureBox6.BackColor = Color.Yellow
        ElseIf ComboBox6.Text = "White" Then
            PictureBox6.BackColor = Color.White
        End If
    End Sub
    Private Sub ComboBox7_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged
        If ComboBox7.Text = "Red" Then
            PictureBox7.BackColor = Color.Red
        ElseIf ComboBox7.Text = "Orange" Then
            PictureBox7.BackColor = Color.Orange
        ElseIf ComboBox7.Text = "Blue" Then
            PictureBox7.BackColor = Color.Blue
        ElseIf ComboBox7.Text = "Green" Then
            PictureBox7.BackColor = Color.Green
        ElseIf ComboBox7.Text = "Yellow" Then
            PictureBox7.BackColor = Color.Yellow
        ElseIf ComboBox7.Text = "White" Then
            PictureBox7.BackColor = Color.White
        End If
    End Sub
    Private Sub ComboBox8_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        If ComboBox8.Text = "Red" Then
            PictureBox8.BackColor = Color.Red
        ElseIf ComboBox8.Text = "Orange" Then
            PictureBox8.BackColor = Color.Orange
        ElseIf ComboBox8.Text = "Blue" Then
            PictureBox8.BackColor = Color.Blue
        ElseIf ComboBox8.Text = "Green" Then
            PictureBox8.BackColor = Color.Green
        ElseIf ComboBox8.Text = "Yellow" Then
            PictureBox8.BackColor = Color.Yellow
        ElseIf ComboBox8.Text = "White" Then
            PictureBox8.BackColor = Color.White
        End If
    End Sub
    Private Sub ComboBox9_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox9.SelectedIndexChanged
        If ComboBox9.Text = "Red" Then
            PictureBox9.BackColor = Color.Red
        ElseIf ComboBox9.Text = "Orange" Then
            PictureBox9.BackColor = Color.Orange
        ElseIf ComboBox9.Text = "Blue" Then
            PictureBox9.BackColor = Color.Blue
        ElseIf ComboBox9.Text = "Green" Then
            PictureBox9.BackColor = Color.Green
        ElseIf ComboBox9.Text = "Yellow" Then
            PictureBox9.BackColor = Color.Yellow
        ElseIf ComboBox9.Text = "White" Then
            PictureBox9.BackColor = Color.White
        End If
    End Sub
    'Code   - Inport code
    Sub InportFront()
        PictureBox36.BackColor = PictureBox1.BackColor
        PictureBox35.BackColor = PictureBox2.BackColor
        PictureBox34.BackColor = PictureBox3.BackColor
        PictureBox33.BackColor = PictureBox4.BackColor
        PictureBox32.BackColor = PictureBox5.BackColor
        PictureBox31.BackColor = PictureBox6.BackColor
        PictureBox30.BackColor = PictureBox7.BackColor
        PictureBox29.BackColor = PictureBox8.BackColor
        PictureBox28.BackColor = PictureBox9.BackColor
    End Sub
    Sub InportBack()
        PictureBox10.BackColor = PictureBox1.BackColor
        PictureBox11.BackColor = PictureBox2.BackColor
        PictureBox12.BackColor = PictureBox3.BackColor
        PictureBox13.BackColor = PictureBox4.BackColor
        PictureBox14.BackColor = PictureBox5.BackColor
        PictureBox15.BackColor = PictureBox6.BackColor
        PictureBox16.BackColor = PictureBox7.BackColor
        PictureBox17.BackColor = PictureBox8.BackColor
        PictureBox18.BackColor = PictureBox9.BackColor
    End Sub
    Sub InportLeft()
        PictureBox27.BackColor = PictureBox1.BackColor
        PictureBox26.BackColor = PictureBox2.BackColor
        PictureBox25.BackColor = PictureBox3.BackColor
        PictureBox24.BackColor = PictureBox4.BackColor
        PictureBox23.BackColor = PictureBox5.BackColor
        PictureBox22.BackColor = PictureBox6.BackColor
        PictureBox21.BackColor = PictureBox7.BackColor
        PictureBox20.BackColor = PictureBox8.BackColor
        PictureBox19.BackColor = PictureBox9.BackColor
    End Sub
    Sub InportRight()
        PictureBox45.BackColor = PictureBox1.BackColor
        PictureBox44.BackColor = PictureBox2.BackColor
        PictureBox43.BackColor = PictureBox3.BackColor
        PictureBox42.BackColor = PictureBox4.BackColor
        PictureBox41.BackColor = PictureBox5.BackColor
        PictureBox40.BackColor = PictureBox6.BackColor
        PictureBox39.BackColor = PictureBox7.BackColor
        PictureBox38.BackColor = PictureBox8.BackColor
        PictureBox37.BackColor = PictureBox9.BackColor
    End Sub
    Sub InportUp()
        PictureBox63.BackColor = PictureBox1.BackColor
        PictureBox62.BackColor = PictureBox2.BackColor
        PictureBox61.BackColor = PictureBox3.BackColor
        PictureBox60.BackColor = PictureBox4.BackColor
        PictureBox59.BackColor = PictureBox5.BackColor
        PictureBox58.BackColor = PictureBox6.BackColor
        PictureBox57.BackColor = PictureBox7.BackColor
        PictureBox56.BackColor = PictureBox8.BackColor
        PictureBox55.BackColor = PictureBox9.BackColor
    End Sub
    Sub InportDown()
        PictureBox54.BackColor = PictureBox1.BackColor
        PictureBox53.BackColor = PictureBox2.BackColor
        PictureBox52.BackColor = PictureBox3.BackColor
        PictureBox51.BackColor = PictureBox4.BackColor
        PictureBox50.BackColor = PictureBox5.BackColor
        PictureBox49.BackColor = PictureBox6.BackColor
        PictureBox48.BackColor = PictureBox7.BackColor
        PictureBox47.BackColor = PictureBox8.BackColor
        PictureBox46.BackColor = PictureBox9.BackColor
    End Sub
    'Button - Input 
    Private Sub ButtonInportF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInportF.Click
        InportFront()
    End Sub
    Private Sub ButtonInportB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInportB.Click
        InportBack()
    End Sub
    Private Sub ButtonInportL_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInportL.Click
        InportLeft()
    End Sub
    Private Sub ButtonInportR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInportR.Click
        InportRight()
    End Sub
    Private Sub ButtonInportU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInportU.Click
        InportUp()
    End Sub
    Private Sub ButtonInportD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonInportD.Click
        InportDown()
    End Sub
    'Code   - Next step
    Sub NextStep()
        If LabelToDo1.Text = "TurnFront" Then
            TurnFront()
        ElseIf LabelToDo1.Text = "TurnFrontInverse" Then
            TurnFrontInverse()
        ElseIf LabelToDo1.Text = "TurnLeft" Then
            TurnLeft()
        ElseIf LabelToDo1.Text = "TurnLeftInverse" Then
            TurnLeftInverse()
        ElseIf LabelToDo1.Text = "TurnRight" Then
            TurnRight()
        ElseIf LabelToDo1.Text = "TurnRightInverse" Then
            TurnRightInverse()
        ElseIf LabelToDo1.Text = "TurnLeftRightInverse" Then
            TurnLeftRightInverse()
        ElseIf LabelToDo1.Text = "TurnLeftInverseRight" Then
            TurnLeftInverseRight()
        End If
        LabelToDo1.Text = LabelToDo2.Text
        LabelToDo2.Text = LabelToDo3.Text
        LabelToDo3.Text = LabelToDo4.Text
        LabelToDo4.Text = LabelToDo5.Text
        LabelToDo5.Text = LabelToDo6.Text
        LabelToDo6.Text = LabelToDo7.Text
        LabelToDo7.Text = LabelToDo8.Text
        LabelToDo8.Text = LabelToDo9.Text
        LabelToDo9.Text = LabelToDo10.Text
        LabelToDo10.Text = LabelToDo11.Text
        LabelToDo11.Text = LabelToDo12.Text
        LabelToDo12.Text = LabelToDo13.Text
        LabelToDo13.Text = LabelToDo14.Text
        LabelToDo14.Text = LabelToDo15.Text
        LabelToDo15.Text = LabelToDo16.Text
        LabelToDo16.Text = LabelToDo17.Text
        LabelToDo17.Text = LabelToDo18.Text
        LabelToDo18.Text = LabelToDo19.Text
        LabelToDo19.Text = LabelToDo20.Text
        LabelToDo20.Text = LabelToDo21.Text
        LabelToDo21.Text = LabelToDo22.Text
        LabelToDo22.Text = LabelToDo23.Text
        LabelToDo23.Text = LabelToDo24.Text
        LabelToDo24.Text = LabelToDo25.Text
        LabelToDo25.Text = LabelToDo26.Text
        LabelToDo26.Text = LabelToDo27.Text
        LabelToDo27.Text = LabelToDo28.Text
        LabelToDo28.Text = LabelToDo29.Text
        LabelToDo29.Text = LabelToDo30.Text
        LabelToDo30.Text = ""
    End Sub
    '==================================================
    '==================================================
    '==========          The Solve           ==========
    '==================================================
    '==================================================
    'Example; 1-1-1 (Row 1) (Type 1, corner/side) (1e piece)
    Sub step1_1()
        'First layer
        If PictureBox35.BackColor = PictureBox32.BackColor And PictureBox56.BackColor = PictureBox59.BackColor Then
        ElseIf PictureBox56.BackColor = PictureBox32.BackColor And PictureBox35.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnFront"
            LabelToDo2.Text = "TurnRight"
            LabelToDo3.Text = "TurnLeftRightInverse"
            LabelToDo4.Text = "TurnFront"
            LabelToDo5.Text = "TurnLeftInverseRight"
        ElseIf PictureBox31.BackColor = PictureBox32.BackColor And PictureBox42.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnFrontInverse"
        ElseIf PictureBox42.BackColor = PictureBox32.BackColor And PictureBox31.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnRight"
            LabelToDo2.Text = "TurnLeftRightInverse"
            LabelToDo3.Text = "TurnFront"
            LabelToDo4.Text = "TurnLeftInverseRight"
        ElseIf PictureBox29.BackColor = PictureBox32.BackColor And PictureBox53.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnFront"
            LabelToDo2.Text = "TurnFront"
        ElseIf PictureBox53.BackColor = PictureBox32.BackColor And PictureBox29.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnFrontInverse"
            LabelToDo2.Text = "TurnRight"
            LabelToDo3.Text = "TurnLeftRightInverse"
            LabelToDo4.Text = "TurnFront"
            LabelToDo5.Text = "TurnLeftInverseRight"
        ElseIf PictureBox33.BackColor = PictureBox32.BackColor And PictureBox22.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnFront"
        ElseIf PictureBox22.BackColor = PictureBox32.BackColor And PictureBox33.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeftInverse"
            LabelToDo2.Text = "TurnLeftRightInverse"
            LabelToDo3.Text = "TurnFrontInverse"
            LabelToDo4.Text = "TurnLeftInverseRight"
            'Second layer
        ElseIf PictureBox58.BackColor = PictureBox32.BackColor And PictureBox44.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnRightInverse"
            LabelToDo2.Text = "TurnFrontInverse"
        ElseIf PictureBox44.BackColor = PictureBox32.BackColor And PictureBox58.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeftRightInverse"
            LabelToDo2.Text = "TurnFront"
            LabelToDo3.Text = "TurnLeftInverseRight"
        ElseIf PictureBox38.BackColor = PictureBox32.BackColor And PictureBox49.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnRight"
            LabelToDo2.Text = "TurnRight"
            LabelToDo3.Text = "TurnLeftRightInverse"
            LabelToDo4.Text = "TurnFront"
            LabelToDo5.Text = "TurnLeftInverseRight"
        ElseIf PictureBox49.BackColor = PictureBox32.BackColor And PictureBox38.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnRight"
            LabelToDo2.Text = "TurnFrontInverse"
        ElseIf PictureBox51.BackColor = PictureBox32.BackColor And PictureBox20.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeftInverse"
            LabelToDo2.Text = "TurnFront"
        ElseIf PictureBox20.BackColor = PictureBox32.BackColor And PictureBox51.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeft"
            LabelToDo2.Text = "TurnLeft"
            LabelToDo3.Text = "TurnLeftRightInverse"
            LabelToDo4.Text = "TurnFrontInverse"
            LabelToDo5.Text = "TurnLeftInverseRight"
        ElseIf PictureBox26.BackColor = PictureBox32.BackColor And PictureBox60.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeftRightInverse"
            LabelToDo2.Text = "TurnFrontInverse"
            LabelToDo3.Text = "TurnLeftInverseRight"
        ElseIf PictureBox60.BackColor = PictureBox32.BackColor And PictureBox26.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeft"
            LabelToDo2.Text = "TurnFront"
            'third layer
        ElseIf PictureBox62.BackColor = PictureBox32.BackColor And PictureBox17.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeftRightInverse"
            LabelToDo2.Text = "TurnFrontInverse"
            LabelToDo3.Text = "TurnLeftInverseRight"
            LabelToDo4.Text = "TurnLeft"
            LabelToDo5.Text = "TurnFront"
        ElseIf PictureBox17.BackColor = PictureBox32.BackColor And PictureBox62.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeftRightInverse"
            LabelToDo2.Text = "TurnFront"
            LabelToDo3.Text = "TurnFront"
            LabelToDo4.Text = "TurnLeftInverseRight"
        ElseIf PictureBox40.BackColor = PictureBox32.BackColor And PictureBox15.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnRightInverse"
            LabelToDo2.Text = "TurnLeftRightInverse"
            LabelToDo3.Text = "TurnFront"
            LabelToDo4.Text = "TurnLeftInverseRight"
        ElseIf PictureBox15.BackColor = PictureBox32.BackColor And PictureBox40.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnRightInverse"
            LabelToDo2.Text = "TurnRightInverse"
            LabelToDo3.Text = "TurnFrontInverse"
        ElseIf PictureBox47.BackColor = PictureBox32.BackColor And PictureBox11.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeftInverseRight"
            LabelToDo2.Text = "TurnFrontInverse"
            LabelToDo3.Text = "TurnRight"
            LabelToDo4.Text = "TurnLeftRightInverse"
            LabelToDo5.Text = "TurnFrontInverse"
        ElseIf PictureBox11.BackColor = PictureBox32.BackColor And PictureBox47.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeftInverseRight"
            LabelToDo2.Text = "TurnFront"
            LabelToDo3.Text = "TurnFront"
            LabelToDo4.Text = "TurnLeftRightInverse"
            LabelToDo5.Text = "TurnFront"
            LabelToDo6.Text = "TurnFront"
        ElseIf PictureBox24.BackColor = PictureBox32.BackColor And PictureBox13.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeft"
            LabelToDo2.Text = "TurnLeftRightInverse"
            LabelToDo3.Text = "TurnFrontInverse"
            LabelToDo4.Text = "TurnLeftInverseRight"
        ElseIf PictureBox13.BackColor = PictureBox32.BackColor And PictureBox24.BackColor = PictureBox59.BackColor Then
            LabelToDo1.Text = "TurnLeft"
            LabelToDo2.Text = "TurnLeft"
            LabelToDo3.Text = "TurnFront"
        End If
        Step1_2()
    End Sub
    Sub Step1_2()
        If LabelToDo1.Text = "" Then
            'First layer
            If PictureBox31.BackColor = PictureBox32.BackColor And PictureBox42.BackColor = PictureBox41.BackColor Then
            ElseIf PictureBox42.BackColor = PictureBox32.BackColor And PictureBox31.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeftInverseRight"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnRight"
            ElseIf PictureBox29.BackColor = PictureBox32.BackColor And PictureBox53.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnFrontInverse"
                LabelToDo2.Text = "TurnRight"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnRightInverse"
            ElseIf PictureBox53.BackColor = PictureBox32.BackColor And PictureBox29.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnRight"
            ElseIf PictureBox22.BackColor = PictureBox32.BackColor And PictureBox33.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftInverseRight"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnFrontInverse"
            ElseIf PictureBox33.BackColor = PictureBox32.BackColor And PictureBox22.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftInverse"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeft"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnFront"
                'Second layer
            ElseIf PictureBox60.BackColor = PictureBox32.BackColor And PictureBox26.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
            ElseIf PictureBox26.BackColor = PictureBox32.BackColor And PictureBox60.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnFrontInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFront"
            ElseIf PictureBox58.BackColor = PictureBox32.BackColor And PictureBox44.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnRightInverse"
            ElseIf PictureBox44.BackColor = PictureBox32.BackColor And PictureBox58.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnRight"
                LabelToDo2.Text = "TurnRight"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFrontInverse"
            ElseIf PictureBox38.BackColor = PictureBox32.BackColor And PictureBox49.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeftInverseRight"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFrontInverse"
            ElseIf PictureBox49.BackColor = PictureBox32.BackColor And PictureBox38.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnRight"
            ElseIf PictureBox20.BackColor = PictureBox32.BackColor And PictureBox51.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeftInverseRight"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFrontInverse"
            ElseIf PictureBox51.BackColor = PictureBox32.BackColor And PictureBox20.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                'third layer
            ElseIf PictureBox62.BackColor = PictureBox32.BackColor And PictureBox17.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverseRight"
            ElseIf PictureBox17.BackColor = PictureBox32.BackColor And PictureBox62.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnRight"
            ElseIf PictureBox15.BackColor = PictureBox32.BackColor And PictureBox40.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnRight"
                LabelToDo2.Text = "TurnRight"
            ElseIf PictureBox40.BackColor = PictureBox32.BackColor And PictureBox15.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnRightInverse"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverseRight"
            ElseIf PictureBox47.BackColor = PictureBox32.BackColor And PictureBox11.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnRight"
            ElseIf PictureBox11.BackColor = PictureBox32.BackColor And PictureBox47.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeftInverseRight"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnFrontInverse"
            ElseIf PictureBox13.BackColor = PictureBox32.BackColor And PictureBox24.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnLeft"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnFront"
            ElseIf PictureBox24.BackColor = PictureBox32.BackColor And PictureBox13.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverseRight"
                LabelToDo6.Text = "TurnFront"
            End If
            Step1_3()
        End If
    End Sub
    Sub Step1_3()
        If LabelToDo1.Text = "" Then
            'First layer
            If PictureBox29.BackColor = PictureBox32.BackColor And PictureBox53.BackColor = PictureBox50.BackColor Then
            ElseIf PictureBox53.BackColor = PictureBox32.BackColor And PictureBox29.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFrontInverse"
            ElseIf PictureBox33.BackColor = PictureBox32.BackColor And PictureBox22.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFrontInverse"
            ElseIf PictureBox22.BackColor = PictureBox32.BackColor And PictureBox33.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnLeftInverseRight"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftRightInverse"
                'Second layer
            ElseIf PictureBox26.BackColor = PictureBox32.BackColor And PictureBox60.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnLeft"
                LabelToDo3.Text = "TurnLeftInverseRight"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftRightInverse"
            ElseIf PictureBox60.BackColor = PictureBox32.BackColor And PictureBox26.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeft"
                LabelToDo3.Text = "TurnFrontInverse"
            ElseIf PictureBox58.BackColor = PictureBox32.BackColor And PictureBox44.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnFrontInverse"
                LabelToDo2.Text = "TurnRightInverse"
                LabelToDo3.Text = "TurnFront"
            ElseIf PictureBox44.BackColor = PictureBox32.BackColor And PictureBox58.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnRight"
                LabelToDo2.Text = "TurnRight"
                LabelToDo3.Text = "TurnLeftInverseRight"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnRight"
            ElseIf PictureBox38.BackColor = PictureBox32.BackColor And PictureBox49.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
            ElseIf PictureBox49.BackColor = PictureBox32.BackColor And PictureBox38.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnFrontInverse"
                LabelToDo2.Text = "TurnRight"
                LabelToDo3.Text = "TurnFront"
            ElseIf PictureBox51.BackColor = PictureBox32.BackColor And PictureBox20.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeftInverse"
                LabelToDo3.Text = "TurnFrontInverse"
            ElseIf PictureBox20.BackColor = PictureBox32.BackColor And PictureBox51.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftRightInverse"
                'third layer
            ElseIf PictureBox62.BackColor = PictureBox32.BackColor And PictureBox17.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnFrontInverse"
            ElseIf PictureBox17.BackColor = PictureBox32.BackColor And PictureBox62.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnFront"
            ElseIf PictureBox40.BackColor = PictureBox32.BackColor And PictureBox15.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnRight"
                LabelToDo2.Text = "TurnLeftInverseRight"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnRightInverse"
            ElseIf PictureBox15.BackColor = PictureBox32.BackColor And PictureBox40.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftRightInverse"
            ElseIf PictureBox47.BackColor = PictureBox32.BackColor And PictureBox11.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnFront"
            ElseIf PictureBox11.BackColor = PictureBox32.BackColor And PictureBox47.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftRightInverse"
            ElseIf PictureBox24.BackColor = PictureBox32.BackColor And PictureBox13.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftInverse"
                LabelToDo2.Text = "TurnLeftInverseRight"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftRightInverse"
            ElseIf PictureBox13.BackColor = PictureBox32.BackColor And PictureBox24.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeft"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFrontInverse"
            End If
            Step1_4()
        End If
    End Sub
    Sub Step1_4()
        If LabelToDo1.Text = "" Then
            'First layer
            If PictureBox33.BackColor = PictureBox32.BackColor And PictureBox22.BackColor = PictureBox23.BackColor Then
            ElseIf PictureBox22.BackColor = PictureBox32.BackColor And PictureBox33.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftInverse"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverseRight"
                LabelToDo6.Text = "TurnFrontInverse"
                'Second layer
            ElseIf PictureBox26.BackColor = PictureBox32.BackColor And PictureBox60.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFrontInverse"
            ElseIf PictureBox60.BackColor = PictureBox32.BackColor And PictureBox26.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeft"
            ElseIf PictureBox58.BackColor = PictureBox32.BackColor And PictureBox44.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
            ElseIf PictureBox44.BackColor = PictureBox32.BackColor And PictureBox58.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFrontInverse"
            ElseIf PictureBox38.BackColor = PictureBox32.BackColor And PictureBox49.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnFrontInverse"
                LabelToDo2.Text = "TurnLeftInverseRight"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFront"
            ElseIf PictureBox49.BackColor = PictureBox32.BackColor And PictureBox38.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnRight"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
            ElseIf PictureBox51.BackColor = PictureBox32.BackColor And PictureBox20.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftInverse"
            ElseIf PictureBox20.BackColor = PictureBox32.BackColor And PictureBox51.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnFrontInverse"
                LabelToDo2.Text = "TurnLeftInverseRight"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFront"
                'third layer
            ElseIf PictureBox62.BackColor = PictureBox32.BackColor And PictureBox17.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeft"
            ElseIf PictureBox17.BackColor = PictureBox32.BackColor And PictureBox62.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverseRight"
                LabelToDo6.Text = "TurnFrontInverse"
            ElseIf PictureBox40.BackColor = PictureBox32.BackColor And PictureBox15.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnFrontInverse"
                LabelToDo2.Text = "TurnRight"
                LabelToDo3.Text = "TurnLeftInverseRight"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnRightInverse"
                LabelToDo7.Text = "TurnFront"
            ElseIf PictureBox15.BackColor = PictureBox32.BackColor And PictureBox40.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnFront"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnRight"
                LabelToDo4.Text = "TurnRight"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnFront"
            ElseIf PictureBox47.BackColor = PictureBox32.BackColor And PictureBox11.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftRightInverse"
            ElseIf PictureBox11.BackColor = PictureBox32.BackColor And PictureBox47.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnFrontInverse"
                LabelToDo2.Text = "TurnLeftInverseRight"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnFront"
            ElseIf PictureBox24.BackColor = PictureBox32.BackColor And PictureBox13.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverseRight"
                LabelToDo6.Text = "TurnFrontInverse"
            ElseIf PictureBox13.BackColor = PictureBox32.BackColor And PictureBox24.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnLeft"
            End If
            Step1_5()
        End If
    End Sub
    Sub Step1_5()
        If LabelToDo1.Text = "" Then
            'First layer
            If PictureBox34.BackColor = PictureBox32.BackColor And PictureBox55.BackColor = PictureBox59.BackColor Then
            ElseIf PictureBox45.BackColor = PictureBox32.BackColor And PictureBox34.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnRight"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnRightInverse"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftInverseRight"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftInverseRight"
            ElseIf PictureBox55.BackColor = PictureBox32.BackColor And PictureBox45.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnRight"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnRight"
            ElseIf PictureBox28.BackColor = PictureBox32.BackColor And PictureBox39.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftInverseRight"
            ElseIf PictureBox39.BackColor = PictureBox32.BackColor And PictureBox52.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnRightInverse"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
            ElseIf PictureBox52.BackColor = PictureBox32.BackColor And PictureBox28.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftInverseRight"
            ElseIf PictureBox30.BackColor = PictureBox32.BackColor And PictureBox54.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnRight"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnRightInverse"
                LabelToDo10.Text = "TurnLeftInverse"
            ElseIf PictureBox54.BackColor = PictureBox32.BackColor And PictureBox19.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverse"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnRightInverse"
                LabelToDo13.Text = "TurnLeft"
            ElseIf PictureBox19.BackColor = PictureBox32.BackColor And PictureBox30.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftInverseRight"
            ElseIf PictureBox36.BackColor = PictureBox32.BackColor And PictureBox25.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnLeft"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftInverseRight"
            ElseIf PictureBox25.BackColor = PictureBox32.BackColor And PictureBox57.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftInverse"
                LabelToDo2.Text = "TurnRight"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeft"
                LabelToDo9.Text = "TurnRightInverse"
            ElseIf PictureBox57.BackColor = PictureBox32.BackColor And PictureBox36.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftInverseRight"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftInverseRight"
                'Second layer
            ElseIf PictureBox27.BackColor = PictureBox32.BackColor And PictureBox16.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnRight"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnRightInverse"
            ElseIf PictureBox16.BackColor = PictureBox32.BackColor And PictureBox63.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnRight"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnRightInverse"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox63.BackColor = PictureBox32.BackColor And PictureBox27.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverseRight"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftInverseRight"
            ElseIf PictureBox61.BackColor = PictureBox32.BackColor And PictureBox18.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnRight"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnRightInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
            ElseIf PictureBox18.BackColor = PictureBox32.BackColor And PictureBox43.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRight"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnRightInverse"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftInverseRight"
            ElseIf PictureBox43.BackColor = PictureBox32.BackColor And PictureBox61.BackColor = PictureBox46.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftInverseRight"
            ElseIf PictureBox37.BackColor = PictureBox32.BackColor And PictureBox12.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
            ElseIf PictureBox12.BackColor = PictureBox32.BackColor And PictureBox46.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnRight"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnRightInverse"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftInverseRight"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftInverseRight"
            ElseIf PictureBox46.BackColor = PictureBox32.BackColor And PictureBox37.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverseRight"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftInverseRight"
            ElseIf PictureBox48.BackColor = PictureBox32.BackColor And PictureBox10.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRight"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnRightInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
            ElseIf PictureBox10.BackColor = PictureBox32.BackColor And PictureBox21.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnRightInverse"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnLeftInverseRight"
            ElseIf PictureBox21.BackColor = PictureBox32.BackColor And PictureBox48.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftInverseRight"
            End If
            Step1_6()
        End If
    End Sub
    Sub Step1_6()
        If LabelToDo1.Text = "" Then
            'First layer
            If PictureBox28.BackColor = PictureBox32.BackColor And PictureBox39.BackColor = PictureBox41.BackColor Then
            ElseIf PictureBox39.BackColor = PictureBox32.BackColor And PictureBox52.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox52.BackColor = PictureBox32.BackColor And PictureBox28.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnRight"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
            ElseIf PictureBox30.BackColor = PictureBox32.BackColor And PictureBox54.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftRightInverse"
            ElseIf PictureBox54.BackColor = PictureBox32.BackColor And PictureBox19.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox19.BackColor = PictureBox32.BackColor And PictureBox30.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeft"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnRight"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
            ElseIf PictureBox36.BackColor = PictureBox32.BackColor And PictureBox25.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnRightInverse"
                LabelToDo2.Text = "TurnLeftInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnLeft"
                LabelToDo10.Text = "TurnRight"
            ElseIf PictureBox25.BackColor = PictureBox32.BackColor And PictureBox57.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnLeftRightInverse"
            ElseIf PictureBox57.BackColor = PictureBox32.BackColor And PictureBox36.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnRightInverse"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnRight"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                'Second layer
            ElseIf PictureBox18.BackColor = PictureBox32.BackColor And PictureBox43.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox43.BackColor = PictureBox32.BackColor And PictureBox61.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRightInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnRight"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
            ElseIf PictureBox61.BackColor = PictureBox32.BackColor And PictureBox18.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnRightInverse"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
            ElseIf PictureBox16.BackColor = PictureBox32.BackColor And PictureBox63.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRightInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnRight"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnFrontInverse"
                LabelToDo15.Text = "TurnLeftRightInverse"
            ElseIf PictureBox63.BackColor = PictureBox32.BackColor And PictureBox27.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
            ElseIf PictureBox27.BackColor = PictureBox32.BackColor And PictureBox16.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftInverseRight"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
            ElseIf PictureBox10.BackColor = PictureBox32.BackColor And PictureBox21.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox21.BackColor = PictureBox32.BackColor And PictureBox48.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
            ElseIf PictureBox48.BackColor = PictureBox32.BackColor And PictureBox10.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnRightInverse"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
            ElseIf PictureBox12.BackColor = PictureBox32.BackColor And PictureBox46.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftRightInverse"
            ElseIf PictureBox46.BackColor = PictureBox32.BackColor And PictureBox37.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
            ElseIf PictureBox37.BackColor = PictureBox32.BackColor And PictureBox12.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
            End If
            Step1_7()
        End If
    End Sub
    Sub Step1_7()
        If LabelToDo1.Text = "" Then
            'First layer
            If PictureBox30.BackColor = PictureBox32.BackColor And PictureBox54.BackColor = PictureBox50.BackColor Then
            ElseIf PictureBox54.BackColor = PictureBox32.BackColor And PictureBox19.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftInverseRight"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeft"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnLeftInverse"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox19.BackColor = PictureBox32.BackColor And PictureBox30.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox36.BackColor = PictureBox32.BackColor And PictureBox25.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftRightInverse"
            ElseIf PictureBox25.BackColor = PictureBox32.BackColor And PictureBox57.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnLeft"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverse"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
            ElseIf PictureBox57.BackColor = PictureBox32.BackColor And PictureBox36.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftRightInverse"
                'Second layer
            ElseIf PictureBox16.BackColor = PictureBox32.BackColor And PictureBox63.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeft"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox63.BackColor = PictureBox32.BackColor And PictureBox27.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftInverseRight"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftRightInverse"
            ElseIf PictureBox27.BackColor = PictureBox32.BackColor And PictureBox16.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
            ElseIf PictureBox10.BackColor = PictureBox32.BackColor And PictureBox21.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftRightInverse"
            ElseIf PictureBox21.BackColor = PictureBox32.BackColor And PictureBox48.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftRightInverse"
            ElseIf PictureBox48.BackColor = PictureBox32.BackColor And PictureBox10.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeft"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
            ElseIf PictureBox12.BackColor = PictureBox32.BackColor And PictureBox46.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeft"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox46.BackColor = PictureBox32.BackColor And PictureBox37.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftRightInverse"
            ElseIf PictureBox37.BackColor = PictureBox32.BackColor And PictureBox12.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
            ElseIf PictureBox18.BackColor = PictureBox32.BackColor And PictureBox43.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnLeftRightInverse"
            ElseIf PictureBox43.BackColor = PictureBox32.BackColor And PictureBox61.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftInverseRight"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
            ElseIf PictureBox61.BackColor = PictureBox32.BackColor And PictureBox18.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
            End If
            Step1_8()
        End If
    End Sub
    Sub Step1_8()
        If LabelToDo1.Text = "" Then
            'First layer
            If PictureBox36.BackColor = PictureBox32.BackColor And PictureBox25.BackColor = PictureBox23.BackColor Then
            ElseIf PictureBox25.BackColor = PictureBox32.BackColor And PictureBox57.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnLeftInverseRight"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftInverseRight"
            ElseIf PictureBox57.BackColor = PictureBox32.BackColor And PictureBox36.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeft"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                'Second layer
            ElseIf PictureBox10.BackColor = PictureBox32.BackColor And PictureBox21.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeft"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftInverseRight"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftInverseRight"
            ElseIf PictureBox21.BackColor = PictureBox32.BackColor And PictureBox48.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeft"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
            ElseIf PictureBox48.BackColor = PictureBox32.BackColor And PictureBox10.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverseRight"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftInverseRight"
            ElseIf PictureBox12.BackColor = PictureBox32.BackColor And PictureBox46.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeft"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFrontInverse"
                LabelToDo15.Text = "TurnLeftInverseRight"
            ElseIf PictureBox46.BackColor = PictureBox32.BackColor And PictureBox37.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeft"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
            ElseIf PictureBox37.BackColor = PictureBox32.BackColor And PictureBox12.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftInverseRight"
            ElseIf PictureBox18.BackColor = PictureBox32.BackColor And PictureBox43.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeft"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftInverseRight"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftInverseRight"
            ElseIf PictureBox43.BackColor = PictureBox32.BackColor And PictureBox61.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
            ElseIf PictureBox61.BackColor = PictureBox32.BackColor And PictureBox18.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftInverseRight"
            ElseIf PictureBox16.BackColor = PictureBox32.BackColor And PictureBox63.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftInverseRight"
            ElseIf PictureBox63.BackColor = PictureBox32.BackColor And PictureBox27.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeft"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
            ElseIf PictureBox27.BackColor = PictureBox32.BackColor And PictureBox16.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftInverseRight"
            End If
            Step2_1()
        End If
    End Sub
    Sub Step2_1()
        If LabelToDo1.Text = "" Then
            'First layer
            'Second layer
            If PictureBox60.BackColor = PictureBox59.BackColor And PictureBox26.BackColor = PictureBox23.BackColor Then
            ElseIf PictureBox26.BackColor = PictureBox59.BackColor And PictureBox60.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnLeftInverse"
                LabelToDo16.Text = "TurnFront"
                LabelToDo17.Text = "TurnLeft"
                LabelToDo18.Text = "TurnFront"
                LabelToDo19.Text = "TurnLeftInverseRight"
                LabelToDo20.Text = "TurnFront"
                LabelToDo21.Text = "TurnLeftRightInverse"
                LabelToDo22.Text = "TurnFrontInverse"
                LabelToDo23.Text = "TurnLeftInverseRight"
                LabelToDo24.Text = "TurnFrontInverse"
                LabelToDo25.Text = "TurnLeftInverseRight"
            ElseIf PictureBox58.BackColor = PictureBox59.BackColor And PictureBox44.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnFront"
                LabelToDo16.Text = "TurnLeftInverseRight"
            ElseIf PictureBox44.BackColor = PictureBox59.BackColor And PictureBox58.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRight"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnRightInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnLeftInverse"
                LabelToDo16.Text = "TurnFront"
                LabelToDo17.Text = "TurnLeft"
                LabelToDo18.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo18.Text = "TurnFront"
                LabelToDo19.Text = "TurnLeftInverseRight"
                LabelToDo20.Text = "TurnFront"
                LabelToDo21.Text = "TurnLeftRightInverse"
                LabelToDo22.Text = "TurnFrontInverse"
                LabelToDo23.Text = "TurnLeftInverseRight"
                LabelToDo24.Text = "TurnFrontInverse"
                LabelToDo25.Text = "TurnLeftInverseRight"
            ElseIf PictureBox38.BackColor = PictureBox59.BackColor And PictureBox49.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFrontInverse"
                LabelToDo15.Text = "TurnLeftInverse"
                LabelToDo16.Text = "TurnFront"
                LabelToDo17.Text = "TurnLeft"
                LabelToDo18.Text = "TurnFront"
                LabelToDo19.Text = "TurnLeftInverseRight"
                LabelToDo20.Text = "TurnFront"
                LabelToDo21.Text = "TurnLeftRightInverse"
                LabelToDo22.Text = "TurnFrontInverse"
                LabelToDo23.Text = "TurnLeftInverseRight"
                LabelToDo24.Text = "TurnFrontInverse"
                LabelToDo25.Text = "TurnLeftInverseRight"
            ElseIf PictureBox49.BackColor = PictureBox59.BackColor And PictureBox38.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnFront"
                LabelToDo16.Text = "TurnLeftInverseRight"
                LabelToDo17.Text = "TurnFront"
                LabelToDo18.Text = "TurnLeftRightInverse"
                LabelToDo19.Text = "TurnFrontInverse"
                LabelToDo20.Text = "TurnLeftInverseRight"
                LabelToDo21.Text = "TurnFrontInverse"
                LabelToDo22.Text = "TurnLeftRightInverse"
                LabelToDo23.Text = "TurnFrontInverse"
                LabelToDo24.Text = "TurnLeftInverse"
                LabelToDo25.Text = "TurnFront"
                LabelToDo26.Text = "TurnLeft"
                LabelToDo27.Text = "TurnLeftRightInverse"
                LabelToDo28.Text = "TurnLeftRightInverse"
            ElseIf PictureBox51.BackColor = PictureBox59.BackColor And PictureBox20.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnLeft"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeft"
                LabelToDo8.Text = "TurnLeft"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeft"
                LabelToDo12.Text = "TurnLeft"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox20.BackColor = PictureBox59.BackColor And PictureBox51.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnLeftInverseRight"
                LabelToDo16.Text = "TurnFront"
                LabelToDo17.Text = "TurnLeftInverse"
                LabelToDo18.Text = "TurnFront"
                LabelToDo19.Text = "TurnLeft"
                LabelToDo20.Text = "TurnFront"
                LabelToDo21.Text = "TurnLeftInverseRight"
                LabelToDo22.Text = "TurnFront"
                LabelToDo23.Text = "TurnLeftRightInverse"
                LabelToDo24.Text = "TurnFrontInverse"
                LabelToDo25.Text = "TurnLeftInverseRight"
                LabelToDo26.Text = "TurnFrontInverse"
                LabelToDo27.Text = "TurnLeftInverseRight"
                'third layer
            ElseIf PictureBox62.BackColor = PictureBox59.BackColor And PictureBox17.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeft"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnLeftInverseRight"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftInverseRight"
            ElseIf PictureBox17.BackColor = PictureBox59.BackColor And PictureBox62.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverseRight"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftInverse"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnLeft"
                LabelToDo16.Text = "TurnLeftRightInverse"
                LabelToDo17.Text = "TurnLeftRightInverse"
            ElseIf PictureBox40.BackColor = PictureBox59.BackColor And PictureBox15.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftInverseRight"
            ElseIf PictureBox15.BackColor = PictureBox59.BackColor And PictureBox40.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnLeftInverse"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeft"
                LabelToDo15.Text = "TurnLeftRightInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
            ElseIf PictureBox47.BackColor = PictureBox59.BackColor And PictureBox11.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeft"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnLeftInverseRight"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftInverseRight"
            ElseIf PictureBox11.BackColor = PictureBox59.BackColor And PictureBox47.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftRightInverse"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverseRight"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeft"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnLeftRightInverse"
            ElseIf PictureBox24.BackColor = PictureBox59.BackColor And PictureBox13.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeft"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFrontInverse"
                LabelToDo15.Text = "TurnLeftInverseRight"
            ElseIf PictureBox13.BackColor = PictureBox59.BackColor And PictureBox24.BackColor = PictureBox23.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnLeftInverse"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeft"
                LabelToDo15.Text = "TurnLeftRightInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
            End If
            Step2_2()
        End If
    End Sub
    Sub Step2_2()
        If LabelToDo1.Text = "" Then
            'First layer
            'Second layer
            If PictureBox44.BackColor = PictureBox41.BackColor And PictureBox58.BackColor = PictureBox59.BackColor Then
            ElseIf PictureBox58.BackColor = PictureBox41.BackColor And PictureBox44.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRight"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnRightInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnFrontInverse"
                LabelToDo15.Text = "TurnRight"
                LabelToDo16.Text = "TurnFrontInverse"
                LabelToDo17.Text = "TurnRightInverse"
                LabelToDo18.Text = "TurnFrontInverse"
                LabelToDo19.Text = "TurnLeftInverseRight"
                LabelToDo20.Text = "TurnFrontInverse"
                LabelToDo21.Text = "TurnLeftRightInverse"
                LabelToDo22.Text = "TurnFront"
                LabelToDo23.Text = "TurnLeftInverseRight"
                LabelToDo24.Text = "TurnFront"
                LabelToDo25.Text = "TurnLeftInverseRight"
            ElseIf PictureBox49.BackColor = PictureBox41.BackColor And PictureBox38.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnRight"
                LabelToDo16.Text = "TurnFrontInverse"
                LabelToDo17.Text = "TurnRightInverse"
                LabelToDo18.Text = "TurnFrontInverse"
                LabelToDo19.Text = "TurnLeftInverseRight"
                LabelToDo20.Text = "TurnFrontInverse"
                LabelToDo21.Text = "TurnLeftRightInverse"
                LabelToDo22.Text = "TurnFront"
                LabelToDo23.Text = "TurnLeftInverseRight"
                LabelToDo24.Text = "TurnFront"
                LabelToDo25.Text = "TurnLeftInverseRight"
            ElseIf PictureBox38.BackColor = PictureBox41.BackColor And PictureBox49.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRight"
                LabelToDo4.Text = "TurnRight"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnRight"
                LabelToDo8.Text = "TurnRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnRight"
                LabelToDo12.Text = "TurnRight"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox20.BackColor = PictureBox41.BackColor And PictureBox51.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnLeftRightInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
                LabelToDo17.Text = "TurnFrontInverse"
                LabelToDo18.Text = "TurnLeftRightInverse"
                LabelToDo19.Text = "TurnFront"
                LabelToDo20.Text = "TurnLeftInverseRight"
                LabelToDo21.Text = "TurnFront"
                LabelToDo22.Text = "TurnLeftRightInverse"
                LabelToDo23.Text = "TurnFront"
                LabelToDo24.Text = "TurnRight"
                LabelToDo25.Text = "TurnFrontInverse"
                LabelToDo26.Text = "TurnRightInverse"
                LabelToDo27.Text = "TurnLeftRightInverse"
                LabelToDo28.Text = "TurnLeftRightInverse"
            ElseIf PictureBox51.BackColor = PictureBox41.BackColor And PictureBox20.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnRight"
                LabelToDo16.Text = "TurnFrontInverse"
                LabelToDo17.Text = "TurnRightInverse"
                LabelToDo18.Text = "TurnFrontInverse"
                LabelToDo19.Text = "TurnLeftInverseRight"
                LabelToDo20.Text = "TurnFrontInverse"
                LabelToDo21.Text = "TurnLeftRightInverse"
                LabelToDo22.Text = "TurnFront"
                LabelToDo23.Text = "TurnLeftInverseRight"
                LabelToDo24.Text = "TurnFront"
                LabelToDo25.Text = "TurnLeftInverseRight"
                'third layer
            ElseIf PictureBox62.BackColor = PictureBox41.BackColor And PictureBox17.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftInverseRight"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnRight"
                LabelToDo14.Text = "TurnFrontInverse"
                LabelToDo15.Text = "TurnRightInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
                LabelToDo17.Text = "TurnLeftRightInverse"
            ElseIf PictureBox17.BackColor = PictureBox41.BackColor And PictureBox62.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnRight"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnRightInverse"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftInverseRight"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftInverseRight"
            ElseIf PictureBox24.BackColor = PictureBox41.BackColor And PictureBox13.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnRight"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnRightInverse"
                LabelToDo15.Text = "TurnLeftRightInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
            ElseIf PictureBox13.BackColor = PictureBox41.BackColor And PictureBox24.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRight"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnRightInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftInverseRight"
            ElseIf PictureBox47.BackColor = PictureBox41.BackColor And PictureBox11.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeftInverseRight"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnRight"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnRightInverse"
                LabelToDo14.Text = "TurnLeftRightInverse"
                LabelToDo15.Text = "TurnLeftRightInverse"
            ElseIf PictureBox11.BackColor = PictureBox41.BackColor And PictureBox47.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnRight"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnRightInverse"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftInverseRight"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftInverseRight"
            ElseIf PictureBox40.BackColor = PictureBox41.BackColor And PictureBox15.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftInverseRight"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftRightInverse"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftInverseRight"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftRightInverse"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnRight"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnRightInverse"
                LabelToDo15.Text = "TurnLeftRightInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
            ElseIf PictureBox15.BackColor = PictureBox41.BackColor And PictureBox40.BackColor = PictureBox59.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnRightInverse"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnLeftInverseRight"
            End If
            Step2_3()
        End If
    End Sub
    Sub Step2_3()
        If LabelToDo1.Text = "" Then
            'First layer
            'Second layer
            If PictureBox49.BackColor = PictureBox50.BackColor And PictureBox38.BackColor = PictureBox41.BackColor Then
            ElseIf PictureBox38.BackColor = PictureBox50.BackColor And PictureBox49.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnRightInverse"
                LabelToDo16.Text = "TurnFront"
                LabelToDo17.Text = "TurnRight"
                LabelToDo18.Text = "TurnFront"
                LabelToDo19.Text = "TurnLeftRightInverse"
                LabelToDo20.Text = "TurnFront"
                LabelToDo21.Text = "TurnLeftInverseRight"
                LabelToDo22.Text = "TurnFrontInverse"
                LabelToDo23.Text = "TurnLeftRightInverse"
                LabelToDo24.Text = "TurnFrontInverse"
                LabelToDo25.Text = "TurnLeftRightInverse"
            ElseIf PictureBox20.BackColor = PictureBox50.BackColor And PictureBox51.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnRightInverse"
                LabelToDo16.Text = "TurnFront"
                LabelToDo17.Text = "TurnRight"
                LabelToDo18.Text = "TurnFront"
                LabelToDo19.Text = "TurnLeftRightInverse"
                LabelToDo20.Text = "TurnFront"
                LabelToDo21.Text = "TurnLeftInverseRight"
                LabelToDo22.Text = "TurnFrontInverse"
                LabelToDo23.Text = "TurnLeftRightInverse"
                LabelToDo24.Text = "TurnFrontInverse"
                LabelToDo25.Text = "TurnLeftRightInverse"
            ElseIf PictureBox51.BackColor = PictureBox50.BackColor And PictureBox20.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftInverseRight"
                LabelToDo15.Text = "TurnFrontInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
                LabelToDo17.Text = "TurnFrontInverse"
                LabelToDo18.Text = "TurnLeftInverseRight"
                LabelToDo19.Text = "TurnFrontInverse"
                LabelToDo20.Text = "TurnRightInverse"
                LabelToDo21.Text = "TurnFront"
                LabelToDo22.Text = "TurnRight"
                LabelToDo23.Text = "TurnLeftRightInverse"
                LabelToDo24.Text = "TurnLeftRightInverse"
                'third layer
            ElseIf PictureBox62.BackColor = PictureBox50.BackColor And PictureBox17.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox17.BackColor = PictureBox50.BackColor And PictureBox62.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFront"
                LabelToDo3.Text = "TurnLeftInverseRight"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnRight"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnLeftRightInverse"
            ElseIf PictureBox24.BackColor = PictureBox50.BackColor And PictureBox13.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnRightInverse"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRight"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftRightInverse"
            ElseIf PictureBox13.BackColor = PictureBox50.BackColor And PictureBox24.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnRightInverse"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnRight"
                LabelToDo15.Text = "TurnLeftRightInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
            ElseIf PictureBox47.BackColor = PictureBox50.BackColor And PictureBox11.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox11.BackColor = PictureBox50.BackColor And PictureBox47.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnRightInverse"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnRight"
                LabelToDo16.Text = "TurnLeftRightInverse"
                LabelToDo17.Text = "TurnLeftRightInverse"
            ElseIf PictureBox40.BackColor = PictureBox50.BackColor And PictureBox15.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnRightInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnRight"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFrontInverse"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnFrontInverse"
                LabelToDo15.Text = "TurnLeftRightInverse"
            ElseIf PictureBox15.BackColor = PictureBox50.BackColor And PictureBox40.BackColor = PictureBox41.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFront"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFrontInverse"
                LabelToDo12.Text = "TurnRightInverse"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnRight"
                LabelToDo15.Text = "TurnLeftRightInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
            End If
            Step2_4()
        End If
    End Sub
    Sub Step2_4()
        If LabelToDo1.Text = "" Then
            'First layer
            'Second layer
            If PictureBox20.BackColor = PictureBox23.BackColor And PictureBox51.BackColor = PictureBox50.BackColor Then
            ElseIf PictureBox51.BackColor = PictureBox23.BackColor And PictureBox20.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftInverseRight"
                LabelToDo14.Text = "TurnFrontInverse"
                LabelToDo15.Text = "TurnLeft"
                LabelToDo16.Text = "TurnFrontInverse"
                LabelToDo17.Text = "TurnLeftInverse"
                LabelToDo18.Text = "TurnFrontInverse"
                LabelToDo19.Text = "TurnLeftRightInverse"
                LabelToDo20.Text = "TurnFrontInverse"
                LabelToDo21.Text = "TurnLeftInverseRight"
                LabelToDo22.Text = "TurnFront"
                LabelToDo23.Text = "TurnLeftRightInverse"
                LabelToDo24.Text = "TurnFront"
                LabelToDo25.Text = "TurnLeftRightInverse"
                'third layer
            ElseIf PictureBox62.BackColor = PictureBox23.BackColor And PictureBox17.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftInverseRight"
                LabelToDo2.Text = "TurnFrontInverse"
                LabelToDo3.Text = "TurnLeftInverseRight"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnFront"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeft"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftInverse"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnLeftRightInverse"
            ElseIf PictureBox17.BackColor = PictureBox23.BackColor And PictureBox62.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeft"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftInverse"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox24.BackColor = PictureBox23.BackColor And PictureBox13.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFrontInverse"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeft"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftInverse"
                LabelToDo15.Text = "TurnLeftRightInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
            ElseIf PictureBox13.BackColor = PictureBox23.BackColor And PictureBox24.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeft"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftInverse"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFrontInverse"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftRightInverse"
                LabelToDo14.Text = "TurnFront"
                LabelToDo15.Text = "TurnLeftRightInverse"
            ElseIf PictureBox47.BackColor = PictureBox23.BackColor And PictureBox11.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnFront"
                LabelToDo5.Text = "TurnLeftRightInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftInverseRight"
                LabelToDo8.Text = "TurnFront"
                LabelToDo9.Text = "TurnLeftRightInverse"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftInverseRight"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeft"
                LabelToDo14.Text = "TurnFrontInverse"
                LabelToDo15.Text = "TurnLeftInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
                LabelToDo17.Text = "TurnLeftRightInverse"
            ElseIf PictureBox11.BackColor = PictureBox23.BackColor And PictureBox47.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeft"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftInverse"
                LabelToDo7.Text = "TurnFrontInverse"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFrontInverse"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeftRightInverse"
                LabelToDo13.Text = "TurnFront"
                LabelToDo14.Text = "TurnLeftRightInverse"
            ElseIf PictureBox40.BackColor = PictureBox23.BackColor And PictureBox15.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnFrontInverse"
                LabelToDo6.Text = "TurnLeftInverseRight"
                LabelToDo7.Text = "TurnFront"
                LabelToDo8.Text = "TurnLeftRightInverse"
                LabelToDo9.Text = "TurnFront"
                LabelToDo10.Text = "TurnLeftInverseRight"
                LabelToDo11.Text = "TurnFront"
                LabelToDo12.Text = "TurnLeft"
                LabelToDo13.Text = "TurnFrontInverse"
                LabelToDo14.Text = "TurnLeftInverse"
                LabelToDo15.Text = "TurnLeftRightInverse"
                LabelToDo16.Text = "TurnLeftRightInverse"
            ElseIf PictureBox15.BackColor = PictureBox23.BackColor And PictureBox40.BackColor = PictureBox50.BackColor Then
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnLeft"
                LabelToDo4.Text = "TurnFrontInverse"
                LabelToDo5.Text = "TurnLeftInverse"
                LabelToDo6.Text = "TurnFrontInverse"
                LabelToDo7.Text = "TurnLeftRightInverse"
                LabelToDo8.Text = "TurnFrontInverse"
                LabelToDo9.Text = "TurnLeftInverseRight"
                LabelToDo10.Text = "TurnFront"
                LabelToDo11.Text = "TurnLeftRightInverse"
                LabelToDo12.Text = "TurnFront"
                LabelToDo13.Text = "TurnLeftRightInverse"
            End If
            Step3_1_1()
        End If
    End Sub
    '3rd Row - The cross
    Sub Step3_1_1()
        If LabelToDo1.Text = "" Then
            If PictureBox17.BackColor = PictureBox14.BackColor And PictureBox13.BackColor = PictureBox14.BackColor And PictureBox11.BackColor = PictureBox14.BackColor And PictureBox15.BackColor = PictureBox14.BackColor Then
            Else
                If PictureBox17.BackColor = PictureBox14.BackColor And PictureBox13.BackColor = PictureBox14.BackColor And PictureBox11.BackColor <> PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnLeftRightInverse"
                    LabelToDo3.Text = "TurnFront"
                    LabelToDo4.Text = "TurnLeftInverseRight"
                    LabelToDo5.Text = "TurnFront"
                    LabelToDo6.Text = "TurnLeftRightInverse"
                    LabelToDo7.Text = "TurnFront"
                    LabelToDo8.Text = "TurnRight"
                    LabelToDo9.Text = "TurnFrontInverse"
                    LabelToDo10.Text = "TurnRightInverse"
                    LabelToDo11.Text = "TurnLeftInverseRight"
                    LabelToDo12.Text = "TurnFrontInverse"
                    LabelToDo13.Text = "TurnLeftInverseRight"
                ElseIf PictureBox13.BackColor = PictureBox14.BackColor And PictureBox11.BackColor = PictureBox14.BackColor And PictureBox15.BackColor <> PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnFront"
                    LabelToDo3.Text = "TurnLeftRightInverse"
                    LabelToDo4.Text = "TurnFront"
                    LabelToDo5.Text = "TurnRight"
                    LabelToDo6.Text = "TurnFrontInverse"
                    LabelToDo7.Text = "TurnRightInverse"
                    LabelToDo8.Text = "TurnLeftInverseRight"
                    LabelToDo9.Text = "TurnFrontInverse"
                    LabelToDo10.Text = "TurnLeftInverseRight"
                ElseIf PictureBox11.BackColor = PictureBox14.BackColor And PictureBox15.BackColor = PictureBox14.BackColor And PictureBox17.BackColor <> PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnLeftRightInverse"
                    LabelToDo3.Text = "TurnFrontInverse"
                    LabelToDo4.Text = "TurnLeftInverseRight"
                    LabelToDo5.Text = "TurnFront"
                    LabelToDo6.Text = "TurnLeftRightInverse"
                    LabelToDo7.Text = "TurnFront"
                    LabelToDo8.Text = "TurnRight"
                    LabelToDo9.Text = "TurnFrontInverse"
                    LabelToDo10.Text = "TurnRightInverse"
                    LabelToDo11.Text = "TurnLeftInverseRight"
                    LabelToDo12.Text = "TurnFrontInverse"
                    LabelToDo13.Text = "TurnLeftInverseRight"
                ElseIf PictureBox15.BackColor = PictureBox14.BackColor And PictureBox17.BackColor = PictureBox14.BackColor And PictureBox13.BackColor <> PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnLeftRightInverse"
                    LabelToDo3.Text = "TurnFront"
                    LabelToDo4.Text = "TurnFront"
                    LabelToDo5.Text = "TurnLeftInverseRight"
                    LabelToDo6.Text = "TurnFront"
                    LabelToDo7.Text = "TurnLeftRightInverse"
                    LabelToDo8.Text = "TurnFront"
                    LabelToDo9.Text = "TurnRight"
                    LabelToDo10.Text = "TurnFrontInverse"
                    LabelToDo11.Text = "TurnRightInverse"
                    LabelToDo12.Text = "TurnLeftInverseRight"
                    LabelToDo13.Text = "TurnFrontInverse"
                    LabelToDo14.Text = "TurnLeftInverseRight"
                ElseIf PictureBox17.BackColor = PictureBox14.BackColor And PictureBox11.BackColor = PictureBox14.BackColor And PictureBox15.BackColor <> PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnLeftRightInverse"
                    LabelToDo3.Text = "TurnFront"
                    LabelToDo4.Text = "TurnLeftInverseRight"
                    LabelToDo5.Text = "TurnFront"
                    LabelToDo6.Text = "TurnLeftRightInverse"
                    LabelToDo7.Text = "TurnRight"
                    LabelToDo8.Text = "TurnFront"
                    LabelToDo9.Text = "TurnRightInverse"
                    LabelToDo10.Text = "TurnFrontInverse"
                    LabelToDo11.Text = "TurnLeftInverseRight"
                    LabelToDo12.Text = "TurnFrontInverse"
                    LabelToDo13.Text = "TurnLeftInverseRight"
                ElseIf PictureBox13.BackColor = PictureBox14.BackColor And PictureBox15.BackColor = PictureBox14.BackColor And PictureBox11.BackColor <> PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnFront"
                    LabelToDo3.Text = "TurnLeftRightInverse"
                    LabelToDo4.Text = "TurnRight"
                    LabelToDo5.Text = "TurnFront"
                    LabelToDo6.Text = "TurnRightInverse"
                    LabelToDo7.Text = "TurnFrontInverse"
                    LabelToDo8.Text = "TurnLeftInverseRight"
                    LabelToDo9.Text = "TurnFrontInverse"
                    LabelToDo10.Text = "TurnLeftInverseRight"
                ElseIf PictureBox62.BackColor = PictureBox14.BackColor And PictureBox24.BackColor = PictureBox14.BackColor And PictureBox47.BackColor = PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnFront"
                    LabelToDo3.Text = "TurnLeftRightInverse"
                    LabelToDo4.Text = "TurnRight"
                    LabelToDo5.Text = "TurnFront"
                    LabelToDo6.Text = "TurnRightInverse"
                    LabelToDo7.Text = "TurnFrontInverse"
                    LabelToDo8.Text = "TurnLeftInverseRight"
                    LabelToDo9.Text = "TurnFrontInverse"
                    LabelToDo10.Text = "TurnLeftInverseRight"
                    LabelToDo11.Text = "TurnLeftRightInverse"
                    LabelToDo12.Text = "TurnLeftRightInverse"
                    LabelToDo13.Text = "TurnFront"
                    LabelToDo14.Text = "TurnFront"
                    LabelToDo15.Text = "TurnLeftInverseRight"
                    LabelToDo16.Text = "TurnFront"
                    LabelToDo17.Text = "TurnLeftRightInverse"
                    LabelToDo18.Text = "TurnFront"
                    LabelToDo19.Text = "TurnRight"
                    LabelToDo20.Text = "TurnFrontInverse"
                    LabelToDo21.Text = "TurnRightInverse"
                    LabelToDo22.Text = "TurnLeftInverseRight"
                    LabelToDo23.Text = "TurnFrontInverse"
                    LabelToDo24.Text = "TurnLeftInverseRight"
                End If
            End If
            Step3_1_2()
        End If
    End Sub
    '3rd Row - The corners Orientation
    Sub Step3_1_2()
        If LabelToDo1.Text = "" Then
            If PictureBox18.BackColor = PictureBox14.BackColor And PictureBox16.BackColor = PictureBox14.BackColor And PictureBox10.BackColor = PictureBox14.BackColor And PictureBox12.BackColor = PictureBox14.BackColor Then
                Step3_1_3()
            Else
                If PictureBox61.BackColor = PictureBox14.BackColor And PictureBox63.BackColor = PictureBox14.BackColor And PictureBox46.BackColor = PictureBox14.BackColor And PictureBox48.BackColor = PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnLeftRightInverse"
                    LabelToDo3.Text = "TurnRight"
                    LabelToDo4.Text = "TurnFront"
                    LabelToDo5.Text = "TurnFront"
                    LabelToDo6.Text = "TurnRightInverse"
                    LabelToDo7.Text = "TurnFrontInverse"
                    LabelToDo8.Text = "TurnRight"
                    LabelToDo9.Text = "TurnFront"
                    LabelToDo10.Text = "TurnRightInverse"
                    LabelToDo11.Text = "TurnFrontInverse"
                    LabelToDo12.Text = "TurnRight"
                    LabelToDo13.Text = "TurnFrontInverse"
                    LabelToDo14.Text = "TurnRightInverse"
                    LabelToDo15.Text = "TurnLeftRightInverse"
                    LabelToDo16.Text = "TurnLeftRightInverse"
                ElseIf PictureBox61.BackColor = PictureBox14.BackColor And PictureBox27.BackColor = PictureBox14.BackColor And PictureBox21.BackColor = PictureBox14.BackColor And PictureBox46.BackColor = PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnLeftRightInverse"
                    LabelToDo3.Text = "TurnRight"
                    LabelToDo4.Text = "TurnFront"
                    LabelToDo5.Text = "TurnFront"
                    LabelToDo6.Text = "TurnRight"
                    LabelToDo7.Text = "TurnRight"
                    LabelToDo8.Text = "TurnFrontInverse"
                    LabelToDo9.Text = "TurnRight"
                    LabelToDo10.Text = "TurnRight"
                    LabelToDo11.Text = "TurnFrontInverse"
                    LabelToDo12.Text = "TurnRight"
                    LabelToDo13.Text = "TurnRight"
                    LabelToDo14.Text = "TurnFront"
                    LabelToDo15.Text = "TurnFront"
                    LabelToDo16.Text = "TurnRight"
                    LabelToDo17.Text = "TurnLeftRightInverse"
                    LabelToDo18.Text = "TurnLeftRightInverse"
                ElseIf PictureBox61.BackColor = PictureBox14.BackColor And PictureBox27.BackColor = PictureBox14.BackColor And PictureBox48.BackColor = PictureBox14.BackColor And PictureBox12.BackColor = PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnLeftRightInverse"
                    LabelToDo3.Text = "TurnFrontInverse"
                    LabelToDo4.Text = "TurnLeftInverse"
                    LabelToDo5.Text = "TurnFront"
                    LabelToDo6.Text = "TurnFront"
                    LabelToDo7.Text = "TurnLeft"
                    LabelToDo8.Text = "TurnFront"
                    LabelToDo9.Text = "TurnLeftInverse"
                    LabelToDo10.Text = "TurnFront"
                    LabelToDo11.Text = "TurnLeft"
                    LabelToDo12.Text = "TurnLeftRightInverse"
                    LabelToDo13.Text = "TurnLeftRightInverse"
                ElseIf PictureBox43.BackColor = PictureBox14.BackColor And PictureBox63.BackColor = PictureBox14.BackColor And PictureBox21.BackColor = PictureBox14.BackColor And PictureBox12.BackColor = PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnLeftRightInverse"
                    LabelToDo3.Text = "TurnRight"
                    LabelToDo4.Text = "TurnFront"
                    LabelToDo5.Text = "TurnFront"
                    LabelToDo6.Text = "TurnRightInverse"
                    LabelToDo7.Text = "TurnFrontInverse"
                    LabelToDo8.Text = "TurnRight"
                    LabelToDo9.Text = "TurnFrontInverse"
                    LabelToDo10.Text = "TurnRightInverse"
                    LabelToDo11.Text = "TurnLeftRightInverse"
                    LabelToDo12.Text = "TurnLeftRightInverse"
                ElseIf PictureBox61.BackColor = PictureBox14.BackColor And PictureBox63.BackColor = PictureBox14.BackColor And PictureBox10.BackColor = PictureBox14.BackColor And PictureBox12.BackColor = PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnRight"
                    LabelToDo2.Text = "TurnRight"
                    LabelToDo3.Text = "TurnFront"
                    LabelToDo4.Text = "TurnRightInverse"
                    LabelToDo5.Text = "TurnLeftRightInverse"
                    LabelToDo6.Text = "TurnLeftRightInverse"
                    LabelToDo7.Text = "TurnFront"
                    LabelToDo8.Text = "TurnFront"
                    LabelToDo9.Text = "TurnRight"
                    LabelToDo10.Text = "TurnLeftRightInverse"
                    LabelToDo11.Text = "TurnLeftRightInverse"
                    LabelToDo12.Text = "TurnFrontInverse"
                    LabelToDo13.Text = "TurnRightInverse"
                    LabelToDo14.Text = "TurnLeftRightInverse"
                    LabelToDo15.Text = "TurnLeftRightInverse"
                    LabelToDo16.Text = "TurnFront"
                    LabelToDo17.Text = "TurnFront"
                    LabelToDo18.Text = "TurnRightInverse"
                    LabelToDo19.Text = "TurnLeftRightInverse"
                    LabelToDo20.Text = "TurnLeftRightInverse"
                ElseIf PictureBox18.BackColor = PictureBox14.BackColor And PictureBox63.BackColor = PictureBox14.BackColor And PictureBox48.BackColor = PictureBox14.BackColor And PictureBox12.BackColor = PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnLeft"
                    LabelToDo3.Text = "TurnFront"
                    LabelToDo4.Text = "TurnRightInverse"
                    LabelToDo5.Text = "TurnFrontInverse"
                    LabelToDo6.Text = "TurnLeftInverse"
                    LabelToDo7.Text = "TurnFront"
                    LabelToDo8.Text = "TurnRight"
                    LabelToDo9.Text = "TurnFrontInverse"
                    LabelToDo10.Text = "TurnLeftInverseRight"
                ElseIf PictureBox61.BackColor = PictureBox14.BackColor And PictureBox16.BackColor = PictureBox14.BackColor And PictureBox21.BackColor = PictureBox14.BackColor And PictureBox12.BackColor = PictureBox14.BackColor Then
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnFrontInverse"
                    LabelToDo3.Text = "TurnLeft"
                    LabelToDo4.Text = "TurnFront"
                    LabelToDo5.Text = "TurnRightInverse"
                    LabelToDo6.Text = "TurnFrontInverse"
                    LabelToDo7.Text = "TurnLeftInverse"
                    LabelToDo8.Text = "TurnFront"
                    LabelToDo9.Text = "TurnRight"
                    LabelToDo10.Text = "TurnLeftInverseRight"
                End If
                Step3_1_3()
            End If
        End If
    End Sub
    '3rd Row - The corners Position
    Sub Step3_1_3()
        If LabelToDo1.Text = "" Then
            If PictureBox10.BackColor = PictureBox14.BackColor And PictureBox12.BackColor = PictureBox14.BackColor And PictureBox16.BackColor = PictureBox14.BackColor And PictureBox18.BackColor = PictureBox14.BackColor Then
                If PictureBox48.BackColor = PictureBox50.BackColor And PictureBox37.BackColor = PictureBox41.BackColor And PictureBox61.BackColor = PictureBox59.BackColor And PictureBox27.BackColor = PictureBox23.BackColor Then
                Else
                    If PictureBox48.BackColor = PictureBox59.BackColor And PictureBox37.BackColor = PictureBox50.BackColor And PictureBox61.BackColor = PictureBox41.BackColor And PictureBox27.BackColor = PictureBox23.BackColor Then
                        LabelToDo1.Text = "TurnLeftInverseRight"
                        LabelToDo2.Text = "TurnRightInverse"
                        LabelToDo3.Text = "TurnRightInverse"
                        LabelToDo4.Text = "TurnFrontInverse"
                        LabelToDo5.Text = "TurnFrontInverse"
                        LabelToDo6.Text = "TurnRight"
                        LabelToDo7.Text = "TurnLeftRightInverse"
                        LabelToDo8.Text = "TurnLeftRightInverse"
                        LabelToDo9.Text = "TurnFront"
                        LabelToDo10.Text = "TurnRightInverse"
                        LabelToDo11.Text = "TurnLeftRightInverse"
                        LabelToDo12.Text = "TurnLeftRightInverse"
                        LabelToDo13.Text = "TurnFrontInverse"
                        LabelToDo14.Text = "TurnFrontInverse"
                        LabelToDo15.Text = "TurnRight"
                        LabelToDo16.Text = "TurnLeftRightInverse"
                        LabelToDo17.Text = "TurnLeftRightInverse"
                        LabelToDo18.Text = "TurnFrontInverse"
                        LabelToDo19.Text = "TurnRight"
                        LabelToDo20.Text = "TurnLeftInverseRight"
                    ElseIf PictureBox48.BackColor = PictureBox41.BackColor And PictureBox37.BackColor = PictureBox59.BackColor And PictureBox61.BackColor = PictureBox50.BackColor And PictureBox27.BackColor = PictureBox23.BackColor Then
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnRightInverse"
                        LabelToDo3.Text = "TurnFront"
                        LabelToDo4.Text = "TurnLeftRightInverse"
                        LabelToDo5.Text = "TurnLeftRightInverse"
                        LabelToDo6.Text = "TurnRightInverse"
                        LabelToDo7.Text = "TurnFront"
                        LabelToDo8.Text = "TurnFront"
                        LabelToDo9.Text = "TurnLeftRightInverse"
                        LabelToDo10.Text = "TurnLeftRightInverse"
                        LabelToDo11.Text = "TurnRight"
                        LabelToDo12.Text = "TurnFrontInverse"
                        LabelToDo13.Text = "TurnLeftRightInverse"
                        LabelToDo14.Text = "TurnLeftRightInverse"
                        LabelToDo15.Text = "TurnRightInverse"
                        LabelToDo16.Text = "TurnFront"
                        LabelToDo17.Text = "TurnFront"
                        LabelToDo18.Text = "TurnRight"
                        LabelToDo19.Text = "TurnRight"
                        LabelToDo20.Text = "TurnLeftRightInverse"
                    ElseIf PictureBox48.BackColor = PictureBox41.BackColor And PictureBox37.BackColor = PictureBox50.BackColor And PictureBox61.BackColor = PictureBox59.BackColor And PictureBox27.BackColor = PictureBox23.BackColor Then
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnLeftRightInverse"
                        LabelToDo3.Text = "TurnFront"
                        LabelToDo4.Text = "TurnFront"
                        LabelToDo5.Text = "TurnLeftInverseRight"
                        LabelToDo6.Text = "TurnRightInverse"
                        LabelToDo7.Text = "TurnFront"
                        LabelToDo8.Text = "TurnLeftRightInverse"
                        LabelToDo9.Text = "TurnLeftRightInverse"
                        LabelToDo10.Text = "TurnRightInverse"
                        LabelToDo11.Text = "TurnFront"
                        LabelToDo12.Text = "TurnFront"
                        LabelToDo13.Text = "TurnLeftRightInverse"
                        LabelToDo14.Text = "TurnLeftRightInverse"
                        LabelToDo15.Text = "TurnRight"
                        LabelToDo16.Text = "TurnFrontInverse"
                        LabelToDo17.Text = "TurnLeftRightInverse"
                        LabelToDo18.Text = "TurnLeftRightInverse"
                        LabelToDo19.Text = "TurnRightInverse"
                        LabelToDo20.Text = "TurnFront"
                        LabelToDo21.Text = "TurnFront"
                        LabelToDo22.Text = "TurnRight"
                        LabelToDo23.Text = "TurnRight"
                        LabelToDo24.Text = "TurnLeftInverseRight"
                        LabelToDo25.Text = "TurnFront"
                        LabelToDo26.Text = "TurnLeftRightInverse"
                        LabelToDo27.Text = "TurnLeftRightInverse"
                    ElseIf PictureBox48.BackColor = PictureBox50.BackColor And PictureBox37.BackColor = PictureBox59.BackColor And PictureBox61.BackColor = PictureBox41.BackColor And PictureBox27.BackColor = PictureBox23.BackColor Then
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnLeftRightInverse"
                        LabelToDo3.Text = "TurnFront"
                        LabelToDo4.Text = "TurnLeftInverseRight"
                        LabelToDo5.Text = "TurnRightInverse"
                        LabelToDo6.Text = "TurnFront"
                        LabelToDo7.Text = "TurnLeftRightInverse"
                        LabelToDo8.Text = "TurnLeftRightInverse"
                        LabelToDo9.Text = "TurnRightInverse"
                        LabelToDo10.Text = "TurnFront"
                        LabelToDo11.Text = "TurnFront"
                        LabelToDo12.Text = "TurnLeftRightInverse"
                        LabelToDo13.Text = "TurnLeftRightInverse"
                        LabelToDo14.Text = "TurnRight"
                        LabelToDo15.Text = "TurnFrontInverse"
                        LabelToDo16.Text = "TurnLeftRightInverse"
                        LabelToDo17.Text = "TurnLeftRightInverse"
                        LabelToDo18.Text = "TurnRightInverse"
                        LabelToDo19.Text = "TurnFront"
                        LabelToDo20.Text = "TurnFront"
                        LabelToDo21.Text = "TurnRight"
                        LabelToDo22.Text = "TurnRight"
                        LabelToDo23.Text = "TurnLeftInverseRight"
                        LabelToDo24.Text = "TurnFront"
                        LabelToDo25.Text = "TurnFront"
                        LabelToDo26.Text = "TurnLeftRightInverse"
                        LabelToDo27.Text = "TurnLeftRightInverse"
                    ElseIf PictureBox48.BackColor = PictureBox59.BackColor And PictureBox37.BackColor = PictureBox41.BackColor And PictureBox61.BackColor = PictureBox50.BackColor And PictureBox27.BackColor = PictureBox23.BackColor Then
                        'TEMP TODO
                        MsgBox("Error #003 - See code 3.1.2.5; This one can be speed up", , MSGBoxName)
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnRightInverse"
                        LabelToDo3.Text = "TurnFront"
                        LabelToDo4.Text = "TurnLeftRightInverse"
                        LabelToDo5.Text = "TurnLeftRightInverse"
                        LabelToDo6.Text = "TurnRightInverse"
                        LabelToDo7.Text = "TurnFront"
                        LabelToDo8.Text = "TurnFront"
                        LabelToDo9.Text = "TurnLeftRightInverse"
                        LabelToDo10.Text = "TurnLeftRightInverse"
                        LabelToDo11.Text = "TurnRight"
                        LabelToDo12.Text = "TurnFrontInverse"
                        LabelToDo13.Text = "TurnLeftRightInverse"
                        LabelToDo14.Text = "TurnLeftRightInverse"
                        LabelToDo15.Text = "TurnRightInverse"
                        LabelToDo16.Text = "TurnFront"
                        LabelToDo17.Text = "TurnFront"
                        LabelToDo18.Text = "TurnRight"
                        LabelToDo19.Text = "TurnRight"
                        LabelToDo20.Text = "TurnLeftRightInverse"
                    End If
                End If
            End If
            Step3_1_4()
        End If
    End Sub
    '3rd Row - The corners Position
    Sub Step3_1_4()
        If LabelToDo1.Text = "" Then
            'Check if down is 1 color
            If PictureBox10.BackColor = PictureBox14.BackColor And PictureBox12.BackColor = PictureBox14.BackColor And PictureBox16.BackColor = PictureBox14.BackColor And PictureBox18.BackColor = PictureBox14.BackColor Then
                'Check if corners in right position
                If PictureBox48.BackColor = PictureBox50.BackColor And PictureBox37.BackColor = PictureBox41.BackColor And PictureBox61.BackColor = PictureBox59.BackColor And PictureBox27.BackColor = PictureBox23.BackColor Then
                    '1th (criss crossing)
                    If PictureBox47.BackColor = PictureBox59.BackColor And PictureBox40.BackColor = PictureBox23.BackColor And PictureBox62.BackColor = PictureBox50.BackColor And PictureBox24.BackColor = PictureBox41.BackColor Then
                        LabelToDo1.Text = "TurnLeft"
                        LabelToDo2.Text = "TurnLeft"
                        LabelToDo3.Text = "TurnRight"
                        LabelToDo4.Text = "TurnRight"
                        LabelToDo5.Text = "TurnFront"
                        LabelToDo6.Text = "TurnFront"
                        LabelToDo7.Text = "TurnLeft"
                        LabelToDo8.Text = "TurnLeft"
                        LabelToDo9.Text = "TurnRight"
                        LabelToDo10.Text = "TurnRight"
                        LabelToDo11.Text = "TurnLeftRightInverse"
                        LabelToDo12.Text = "TurnLeftRightInverse"
                        LabelToDo13.Text = "TurnFront"
                        LabelToDo14.Text = "TurnLeftRightInverse"
                        LabelToDo15.Text = "TurnLeftRightInverse"
                        LabelToDo16.Text = "TurnLeft"
                        LabelToDo17.Text = "TurnLeft"
                        LabelToDo18.Text = "TurnRight"
                        LabelToDo19.Text = "TurnRight"
                        LabelToDo20.Text = "TurnFront"
                        LabelToDo21.Text = "TurnFront"
                        LabelToDo22.Text = "TurnLeft"
                        LabelToDo23.Text = "TurnLeft"
                        LabelToDo24.Text = "TurnRight"
                        LabelToDo25.Text = "TurnRight"
                        LabelToDo26.Text = "TurnLeftRightInverse"
                        LabelToDo27.Text = "TurnLeftRightInverse"
                        LabelToDo28.Text = "TurnFrontInverse"
                        'LabelToDo29.Text = "TurnLeftRightInverse"
                        'LabelToDo30.Text = "TurnLeftRightInverse"
                        '2nd Trade 2x2sides
                    ElseIf PictureBox47.BackColor = PictureBox41.BackColor And PictureBox40.BackColor = PictureBox50.BackColor And PictureBox62.BackColor = PictureBox23.BackColor And PictureBox24.BackColor = PictureBox59.BackColor Then
                        LabelToDo1.Text = "TurnLeft"
                        LabelToDo2.Text = "TurnLeft"
                        LabelToDo3.Text = "TurnRight"
                        LabelToDo4.Text = "TurnRight"
                        LabelToDo5.Text = "TurnFrontInverse"
                        LabelToDo6.Text = "TurnLeft"
                        LabelToDo7.Text = "TurnLeft"
                        LabelToDo8.Text = "TurnRight"
                        LabelToDo9.Text = "TurnRight"
                        LabelToDo10.Text = "TurnLeftRightInverse"
                        LabelToDo11.Text = "TurnLeftRightInverse"
                        LabelToDo12.Text = "TurnFrontInverse"
                        LabelToDo13.Text = "TurnLeft"
                        LabelToDo14.Text = "TurnRightInverse"
                        LabelToDo15.Text = "TurnLeftInverseRight"
                        LabelToDo16.Text = "TurnFront"
                        LabelToDo17.Text = "TurnFront"
                        LabelToDo18.Text = "TurnLeft"
                        LabelToDo19.Text = "TurnLeft"
                        LabelToDo20.Text = "TurnRight"
                        LabelToDo21.Text = "TurnRight"
                        LabelToDo22.Text = "TurnLeftRightInverse"
                        LabelToDo23.Text = "TurnLeftRightInverse"
                        LabelToDo24.Text = "TurnFront"
                        LabelToDo25.Text = "TurnFront"
                        LabelToDo26.Text = "TurnLeft"
                        LabelToDo27.Text = "TurnRightInverse"
                        LabelToDo28.Text = "TurnLeftInverseRight"
                        LabelToDo29.Text = "TurnFront"
                        LabelToDo30.Text = "TurnFront"
                    ElseIf PictureBox47.BackColor = PictureBox23.BackColor And PictureBox40.BackColor = PictureBox59.BackColor And PictureBox62.BackColor = PictureBox41.BackColor And PictureBox24.BackColor = PictureBox50.BackColor Then
                        LabelToDo1.Text = "TurnLeft"
                        LabelToDo2.Text = "TurnLeft"
                        LabelToDo3.Text = "TurnRight"
                        LabelToDo4.Text = "TurnRight"
                        LabelToDo5.Text = "TurnFront"
                        LabelToDo6.Text = "TurnLeft"
                        LabelToDo7.Text = "TurnLeft"
                        LabelToDo8.Text = "TurnRight"
                        LabelToDo9.Text = "TurnRight"
                        LabelToDo10.Text = "TurnLeftRightInverse"
                        LabelToDo11.Text = "TurnLeftRightInverse"
                        LabelToDo12.Text = "TurnFront"
                        LabelToDo13.Text = "TurnLeft"
                        LabelToDo14.Text = "TurnRightInverse"
                        LabelToDo15.Text = "TurnLeftInverseRight"
                        LabelToDo16.Text = "TurnFront"
                        LabelToDo17.Text = "TurnFront"
                        LabelToDo18.Text = "TurnLeft"
                        LabelToDo19.Text = "TurnLeft"
                        LabelToDo20.Text = "TurnRight"
                        LabelToDo21.Text = "TurnRight"
                        LabelToDo22.Text = "TurnLeftRightInverse"
                        LabelToDo23.Text = "TurnLeftRightInverse"
                        LabelToDo24.Text = "TurnFront"
                        LabelToDo25.Text = "TurnFront"
                        LabelToDo26.Text = "TurnLeft"
                        LabelToDo27.Text = "TurnRightInverse"
                        LabelToDo28.Text = "TurnLeftInverseRight"
                        LabelToDo29.Text = "TurnFront"
                        LabelToDo30.Text = "TurnFront"
                        '3rd Trade 3 counter clockwise
                    ElseIf PictureBox47.BackColor = PictureBox23.BackColor And PictureBox40.BackColor = PictureBox50.BackColor And PictureBox62.BackColor = PictureBox59.BackColor And PictureBox24.BackColor = PictureBox41.BackColor Then
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnLeftRightInverse"
                        LabelToDo3.Text = "TurnLeft"
                        LabelToDo4.Text = "TurnFrontInverse"
                        LabelToDo5.Text = "TurnLeft"
                        LabelToDo6.Text = "TurnFront"
                        LabelToDo7.Text = "TurnLeft"
                        LabelToDo8.Text = "TurnFront"
                        LabelToDo9.Text = "TurnLeft"
                        LabelToDo10.Text = "TurnFrontInverse"
                        LabelToDo11.Text = "TurnLeftInverse"
                        LabelToDo12.Text = "TurnFrontInverse"
                        LabelToDo13.Text = "TurnLeft"
                        LabelToDo14.Text = "TurnLeft"
                        'LabelToDo15.Text = "TurnLeftRightInverse"
                        'LabelToDo16.Text = "TurnLeftRightInverse"
                    ElseIf PictureBox47.BackColor = PictureBox59.BackColor And PictureBox40.BackColor = PictureBox50.BackColor And PictureBox62.BackColor = PictureBox41.BackColor And PictureBox24.BackColor = PictureBox23.BackColor Then
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnLeftRightInverse"
                        LabelToDo3.Text = "TurnFrontInverse"
                        LabelToDo4.Text = "TurnLeft"
                        LabelToDo5.Text = "TurnFrontInverse"
                        LabelToDo6.Text = "TurnLeft"
                        LabelToDo7.Text = "TurnFront"
                        LabelToDo8.Text = "TurnLeft"
                        LabelToDo9.Text = "TurnFront"
                        LabelToDo10.Text = "TurnLeft"
                        LabelToDo11.Text = "TurnFrontInverse"
                        LabelToDo12.Text = "TurnLeftInverse"
                        LabelToDo13.Text = "TurnFrontInverse"
                        LabelToDo14.Text = "TurnLeft"
                        LabelToDo15.Text = "TurnLeft"
                        LabelToDo16.Text = "TurnFront"
                        'LabelToDo17.Text = "TurnLeftRightInverse"
                        'LabelToDo18.Text = "TurnLeftRightInverse"
                    ElseIf PictureBox47.BackColor = PictureBox50.BackColor And PictureBox40.BackColor = PictureBox23.BackColor And PictureBox62.BackColor = PictureBox41.BackColor And PictureBox24.BackColor = PictureBox59.BackColor Then
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnLeftRightInverse"
                        LabelToDo3.Text = "TurnFront"
                        LabelToDo4.Text = "TurnFront"
                        LabelToDo5.Text = "TurnLeft"
                        LabelToDo6.Text = "TurnFrontInverse"
                        LabelToDo7.Text = "TurnLeft"
                        LabelToDo8.Text = "TurnFront"
                        LabelToDo9.Text = "TurnLeft"
                        LabelToDo10.Text = "TurnFront"
                        LabelToDo11.Text = "TurnLeft"
                        LabelToDo12.Text = "TurnFrontInverse"
                        LabelToDo13.Text = "TurnLeftInverse"
                        LabelToDo14.Text = "TurnFrontInverse"
                        LabelToDo15.Text = "TurnLeft"
                        LabelToDo16.Text = "TurnLeft"
                        LabelToDo17.Text = "TurnFront"
                        LabelToDo18.Text = "TurnFront"
                        'LabelToDo19.Text = "TurnLeftRightInverse"
                        'LabelToDo20.Text = "TurnLeftRightInverse"
                    ElseIf PictureBox47.BackColor = PictureBox23.BackColor And PictureBox40.BackColor = PictureBox41.BackColor And PictureBox62.BackColor = PictureBox50.BackColor And PictureBox24.BackColor = PictureBox59.BackColor Then
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnLeftRightInverse"
                        LabelToDo3.Text = "TurnFront"
                        LabelToDo4.Text = "TurnLeft"
                        LabelToDo5.Text = "TurnFrontInverse"
                        LabelToDo6.Text = "TurnLeft"
                        LabelToDo7.Text = "TurnFront"
                        LabelToDo8.Text = "TurnLeft"
                        LabelToDo9.Text = "TurnFront"
                        LabelToDo10.Text = "TurnLeft"
                        LabelToDo11.Text = "TurnFrontInverse"
                        LabelToDo12.Text = "TurnLeftInverse"
                        LabelToDo13.Text = "TurnFrontInverse"
                        LabelToDo14.Text = "TurnLeft"
                        LabelToDo15.Text = "TurnLeft"
                        LabelToDo16.Text = "TurnFrontInverse"
                        'LabelToDo17.Text = "TurnLeftRightInverse"
                        'LabelToDo18.Text = "TurnLeftRightInverse"
                        '4rd Trade 3 clockwise
                    ElseIf PictureBox47.BackColor = PictureBox41.BackColor And PictureBox40.BackColor = PictureBox23.BackColor And PictureBox62.BackColor = PictureBox59.BackColor And PictureBox24.BackColor = PictureBox50.BackColor Then
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnLeftRightInverse"
                        LabelToDo3.Text = "TurnLeftInverse"
                        LabelToDo4.Text = "TurnLeftInverse"
                        LabelToDo5.Text = "TurnFront"
                        LabelToDo6.Text = "TurnLeft"
                        LabelToDo7.Text = "TurnFront"
                        LabelToDo8.Text = "TurnLeftInverse"
                        LabelToDo9.Text = "TurnFrontInverse"
                        LabelToDo10.Text = "TurnLeftInverse"
                        LabelToDo11.Text = "TurnFrontInverse"
                        LabelToDo12.Text = "TurnLeftInverse"
                        LabelToDo13.Text = "TurnFront"
                        LabelToDo14.Text = "TurnLeftInverse"
                        'LabelToDo15.Text = "TurnLeftRightInverse"
                        'LabelToDo16.Text = "TurnLeftRightInverse"
                    ElseIf PictureBox47.BackColor = PictureBox41.BackColor And PictureBox40.BackColor = PictureBox59.BackColor And PictureBox62.BackColor = PictureBox50.BackColor And PictureBox24.BackColor = PictureBox23.BackColor Then
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnLeftRightInverse"
                        LabelToDo3.Text = "TurnFrontInverse"
                        LabelToDo4.Text = "TurnLeftInverse"
                        LabelToDo5.Text = "TurnLeftInverse"
                        LabelToDo6.Text = "TurnFront"
                        LabelToDo7.Text = "TurnLeft"
                        LabelToDo8.Text = "TurnFront"
                        LabelToDo9.Text = "TurnLeftInverse"
                        LabelToDo10.Text = "TurnFrontInverse"
                        LabelToDo11.Text = "TurnLeftInverse"
                        LabelToDo12.Text = "TurnFrontInverse"
                        LabelToDo13.Text = "TurnLeftInverse"
                        LabelToDo14.Text = "TurnFront"
                        LabelToDo15.Text = "TurnLeftInverse"
                        LabelToDo16.Text = "TurnFront"
                        'LabelToDo17.Text = "TurnLeftRightInverse"
                        'LabelToDo18.Text = "TurnLeftRightInverse"
                    ElseIf PictureBox47.BackColor = PictureBox50.BackColor And PictureBox40.BackColor = PictureBox59.BackColor And PictureBox62.BackColor = PictureBox23.BackColor And PictureBox24.BackColor = PictureBox41.BackColor Then
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnLeftRightInverse"
                        LabelToDo3.Text = "TurnFront"
                        LabelToDo4.Text = "TurnFront"
                        LabelToDo5.Text = "TurnLeftInverse"
                        LabelToDo6.Text = "TurnLeftInverse"
                        LabelToDo7.Text = "TurnFront"
                        LabelToDo8.Text = "TurnLeft"
                        LabelToDo9.Text = "TurnFront"
                        LabelToDo10.Text = "TurnLeftInverse"
                        LabelToDo11.Text = "TurnFrontInverse"
                        LabelToDo12.Text = "TurnLeftInverse"
                        LabelToDo13.Text = "TurnFrontInverse"
                        LabelToDo14.Text = "TurnLeftInverse"
                        LabelToDo15.Text = "TurnFront"
                        LabelToDo16.Text = "TurnLeftInverse"
                        LabelToDo17.Text = "TurnFront"
                        LabelToDo18.Text = "TurnFront"
                        'LabelToDo19.Text = "TurnLeftRightInverse"
                        'LabelToDo20.Text = "TurnLeftRightInverse"
                    ElseIf PictureBox47.BackColor = PictureBox59.BackColor And PictureBox40.BackColor = PictureBox41.BackColor And PictureBox62.BackColor = PictureBox23.BackColor And PictureBox24.BackColor = PictureBox50.BackColor Then
                        LabelToDo1.Text = "TurnLeftRightInverse"
                        LabelToDo2.Text = "TurnLeftRightInverse"
                        LabelToDo3.Text = "TurnFront"
                        LabelToDo4.Text = "TurnLeftInverse"
                        LabelToDo5.Text = "TurnLeftInverse"
                        LabelToDo6.Text = "TurnFront"
                        LabelToDo7.Text = "TurnLeft"
                        LabelToDo8.Text = "TurnFront"
                        LabelToDo9.Text = "TurnLeftInverse"
                        LabelToDo10.Text = "TurnFrontInverse"
                        LabelToDo11.Text = "TurnLeftInverse"
                        LabelToDo12.Text = "TurnFrontInverse"
                        LabelToDo13.Text = "TurnLeftInverse"
                        LabelToDo14.Text = "TurnFront"
                        LabelToDo15.Text = "TurnLeftInverse"
                        LabelToDo16.Text = "TurnFrontInverse"
                        'LabelToDo17.Text = "TurnLeftRightInverse"
                        'LabelToDo18.Text = "TurnLeftRightInverse"
                    End If
                ElseIf LabelToDo1.Text = "" And CountLoops1 < 4 Then
                    CountLoops1 = CountLoops1 + 1
                    LabelToDo1.Text = "TurnLeftRightInverse"
                    LabelToDo2.Text = "TurnLeftRightInverse"
                    LabelToDo3.Text = "TurnFront"
                    LabelToDo4.Text = "TurnLeftRightInverse"
                    LabelToDo5.Text = "TurnLeftRightInverse"
                    If PictureBox46.BackColor = PictureBox59.BackColor Then
                        LabelToDo4.Text = "TurnFront"
                        LabelToDo5.Text = "TurnLeftRightInverse"
                        LabelToDo6.Text = "TurnLeftRightInverse"
                    ElseIf PictureBox21.BackColor = PictureBox59.BackColor Then
                        LabelToDo3.Text = "TurnFrontInverse"
                    End If
                End If
            ElseIf LabelToDo1.Text = "" And CountLoops2 < 4 Then
                CountLoops2 = CountLoops2 + 1
                LabelToDo1.Text = "TurnLeftRightInverse"
                LabelToDo2.Text = "TurnLeftRightInverse"
                LabelToDo3.Text = "TurnFront"
                LabelToDo4.Text = "TurnLeftRightInverse"
                LabelToDo5.Text = "TurnLeftRightInverse"
            End If
            Solved()
        End If
    End Sub
    'SOLVED :D
    Sub Solved()
        If LabelToDo1.Text = "" Then
            MSGBOXSeconds = DateDiff(DateInterval.Second, starttime, Now)
            MSGBOXMinute = DateDiff(DateInterval.Minute, starttime, Now)
            MSGBOXSeconds = MSGBOXSeconds - (MSGBOXMinute * 60)
            'Corection of seconds (when 30+ seconds)
            If MSGBOXSeconds < 0 Then
                MSGBOXSeconds = MSGBOXSeconds + 60
                MSGBOXMinute = MSGBOXMinute - 1
            End If
            'Minutes 1 to 01
            If MSGBOXMinute < 10 Then
                SMSGBOXMinute = "0" & MSGBOXMinute
            Else
                SMSGBOXMinute = MSGBOXMinute
            End If
            'Seconds 1 to 01
            If MSGBOXSeconds < 10 Then
                SMSGBOXSeconds = "0" & MSGBOXSeconds
            Else
                SMSGBOXSeconds = MSGBOXSeconds
            End If
            'Set SMSGBOXRunTime
            SMSGBOXRunTime = "Run time " & SMSGBOXMinute & ":" & SMSGBOXSeconds & " Seconds" & Chr(13) & Steps & " Cube turns and" & Chr(13) & ArduinoSteps & " Commando's to the Arduino"
            'Give the MSGBOC
            If PictureBox24.BackColor = PictureBox23.BackColor And PictureBox62.BackColor = PictureBox59.BackColor And PictureBox40.BackColor = PictureBox41.BackColor And PictureBox14.BackColor = PictureBox17.BackColor Then
                MsgBox("The Cube is solved!!!" & Chr(13) & Chr(13) & SMSGBOXRunTime, , MSGBoxName)
            Else
                MsgBox("You programmed a unvalid rubiks cube," & Chr(13) & "I tryed to solve it," & Chr(13) & Chr(13) & SMSGBOXRunTime, , MSGBoxName)
            End If
            'Stop the solve
            If Start = True Then
                StopSolve()
            End If
        End If
    End Sub
    '==================================================
    '==================================================
    '==========          TEMP stuff          ==========
    '==================================================
    '==================================================
    Sub Reset()
        CountLoops1 = 0
        CountLoops2 = 0

        InportBack()
        InportLeft()
        InportRight()
        InportDown()
        InportUp()
        InportFront()

        'all Centers
        PictureBox32.BackColor = Color.Green
        PictureBox14.BackColor = Color.Blue

        PictureBox50.BackColor = Color.White
        PictureBox59.BackColor = Color.Yellow

        PictureBox23.BackColor = Color.Red
        PictureBox41.BackColor = Color.Orange

        '1th Edges
        PictureBox35.BackColor = PictureBox32.BackColor
        PictureBox56.BackColor = PictureBox59.BackColor

        PictureBox31.BackColor = PictureBox32.BackColor
        PictureBox42.BackColor = PictureBox41.BackColor

        PictureBox29.BackColor = PictureBox32.BackColor
        PictureBox53.BackColor = PictureBox50.BackColor

        PictureBox33.BackColor = PictureBox32.BackColor
        PictureBox22.BackColor = PictureBox23.BackColor

        '1th Corners
        PictureBox34.BackColor = PictureBox32.BackColor
        PictureBox55.BackColor = PictureBox59.BackColor
        PictureBox45.BackColor = PictureBox41.BackColor

        PictureBox28.BackColor = PictureBox32.BackColor
        PictureBox39.BackColor = PictureBox41.BackColor
        PictureBox52.BackColor = PictureBox50.BackColor

        PictureBox30.BackColor = PictureBox33.BackColor
        PictureBox54.BackColor = PictureBox50.BackColor
        PictureBox19.BackColor = PictureBox23.BackColor

        PictureBox36.BackColor = PictureBox33.BackColor
        PictureBox25.BackColor = PictureBox23.BackColor
        PictureBox57.BackColor = PictureBox59.BackColor

        '2rd Corners
        PictureBox26.BackColor = PictureBox23.BackColor
        PictureBox60.BackColor = PictureBox59.BackColor

        PictureBox58.BackColor = PictureBox59.BackColor
        PictureBox44.BackColor = PictureBox41.BackColor

        PictureBox38.BackColor = PictureBox41.BackColor
        PictureBox49.BackColor = PictureBox50.BackColor

        PictureBox51.BackColor = PictureBox50.BackColor
        PictureBox20.BackColor = PictureBox23.BackColor

        '3th Cross
        PictureBox17.BackColor = PictureBox14.BackColor
        PictureBox13.BackColor = PictureBox14.BackColor
        PictureBox11.BackColor = PictureBox14.BackColor
        PictureBox15.BackColor = PictureBox14.BackColor

        '3th Side
        PictureBox10.BackColor = PictureBox14.BackColor
        PictureBox12.BackColor = PictureBox14.BackColor
        PictureBox16.BackColor = PictureBox14.BackColor
        PictureBox18.BackColor = PictureBox14.BackColor

        '3th Corners
        PictureBox48.BackColor = PictureBox50.BackColor
        PictureBox37.BackColor = PictureBox41.BackColor
        PictureBox61.BackColor = PictureBox59.BackColor
        PictureBox27.BackColor = PictureBox23.BackColor

        PictureBox21.BackColor = PictureBox23.BackColor
        PictureBox46.BackColor = PictureBox50.BackColor
        PictureBox43.BackColor = PictureBox41.BackColor
        PictureBox63.BackColor = PictureBox59.BackColor

        'IDK but it works
        PictureBox62.BackColor = PictureBox59.BackColor
        PictureBox40.BackColor = PictureBox41.BackColor
        PictureBox47.BackColor = PictureBox50.BackColor
        PictureBox24.BackColor = PictureBox23.BackColor
    End Sub
    'TEMP test 1
    Private Sub ButtonTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonTest1.Click
        Reset()
        'TODO
        PictureBox48.BackColor = PictureBox59.BackColor
        PictureBox37.BackColor = PictureBox41.BackColor
        PictureBox61.BackColor = PictureBox50.BackColor
        PictureBox27.BackColor = PictureBox23.BackColor

        PictureBox21.BackColor = PictureBox41.BackColor

        PictureBox43.BackColor = PictureBox23.BackColor

        PictureBox40.BackColor = PictureBox50.BackColor
        PictureBox47.BackColor = PictureBox23.BackColor
        PictureBox24.BackColor = PictureBox59.BackColor
        PictureBox62.BackColor = PictureBox41.BackColor

    End Sub
    Private Sub ButtonTest3_Click(sender As Object, e As EventArgs) Handles ButtonTest3.Click
        Reset()
        'TODO
        PictureBox48.BackColor = PictureBox35.BackColor
        PictureBox37.BackColor = PictureBox41.BackColor
        PictureBox61.BackColor = PictureBox14.BackColor
        PictureBox27.BackColor = PictureBox23.BackColor

        PictureBox21.BackColor = PictureBox41.BackColor
        PictureBox46.BackColor = PictureBox50.BackColor
        PictureBox43.BackColor = PictureBox23.BackColor
        PictureBox63.BackColor = PictureBox59.BackColor

        PictureBox62.BackColor = PictureBox14.BackColor
        PictureBox40.BackColor = PictureBox32.BackColor
        PictureBox47.BackColor = PictureBox32.BackColor
        PictureBox24.BackColor = PictureBox32.BackColor
    End Sub
    'TEMP test 2
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles ButtonTest2.Click
        Reset()



        LabelToDo1.Text = "TurnLeftInverseRight"
        LabelToDo2.Text = "A"
        LabelToDo3.Text = "TurnFront"
        LabelToDo4.Text = "TurnFront"
        LabelToDo5.Text = "TurnFront"
    End Sub
    'TEMP Button Spam
    Private Sub ButtonSpam_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSpam.Click
        Do Until LabelToDo1.Text = ""
            NextStep()
            Steps = Steps + 1
            LabelSteps.Text = Steps
        Loop
        If LabelToDo1.Text = "" Then
            step1_1()
        End If
    End Sub
    'TEMP Button Superflip
    Private Sub ButtonButtonSuperFlip_Click(sender As Object, e As EventArgs) Handles ButtonSuperFlip.Click
        PictureBox1.BackColor = Color.Orange
        PictureBox2.BackColor = Color.Green
        PictureBox4.BackColor = Color.White
        PictureBox6.BackColor = Color.Yellow
        PictureBox8.BackColor = Color.Blue
        PictureBox3.BackColor = PictureBox1.BackColor
        PictureBox5.BackColor = PictureBox1.BackColor
        PictureBox7.BackColor = PictureBox1.BackColor
        PictureBox9.BackColor = PictureBox1.BackColor
        InportFront()
        PictureBox1.BackColor = Color.White
        PictureBox2.BackColor = Color.Green
        PictureBox4.BackColor = Color.Red
        PictureBox6.BackColor = Color.Orange
        PictureBox8.BackColor = Color.Blue
        PictureBox3.BackColor = PictureBox1.BackColor
        PictureBox5.BackColor = PictureBox1.BackColor
        PictureBox7.BackColor = PictureBox1.BackColor
        PictureBox9.BackColor = PictureBox1.BackColor
        InportLeft()
        PictureBox1.BackColor = Color.Yellow
        PictureBox2.BackColor = Color.Green
        PictureBox4.BackColor = Color.Orange
        PictureBox6.BackColor = Color.Red
        PictureBox8.BackColor = Color.Blue
        PictureBox3.BackColor = PictureBox1.BackColor
        PictureBox5.BackColor = PictureBox1.BackColor
        PictureBox7.BackColor = PictureBox1.BackColor
        PictureBox9.BackColor = PictureBox1.BackColor
        InportRight()
        PictureBox1.BackColor = Color.Green
        PictureBox2.BackColor = Color.Red
        PictureBox4.BackColor = Color.White
        PictureBox6.BackColor = Color.Yellow
        PictureBox8.BackColor = Color.Orange
        PictureBox3.BackColor = PictureBox1.BackColor
        PictureBox5.BackColor = PictureBox1.BackColor
        PictureBox7.BackColor = PictureBox1.BackColor
        PictureBox9.BackColor = PictureBox1.BackColor
        InportUp()
        PictureBox1.BackColor = Color.Blue
        PictureBox2.BackColor = Color.Orange
        PictureBox4.BackColor = Color.White
        PictureBox6.BackColor = Color.Yellow
        PictureBox8.BackColor = Color.Red
        PictureBox3.BackColor = PictureBox1.BackColor
        PictureBox5.BackColor = PictureBox1.BackColor
        PictureBox7.BackColor = PictureBox1.BackColor
        PictureBox9.BackColor = PictureBox1.BackColor
        InportDown()
        PictureBox1.BackColor = Color.Red
        PictureBox2.BackColor = Color.Blue
        PictureBox4.BackColor = Color.White
        PictureBox6.BackColor = Color.Yellow
        PictureBox8.BackColor = Color.Green
        PictureBox3.BackColor = PictureBox1.BackColor
        PictureBox5.BackColor = PictureBox1.BackColor
        PictureBox7.BackColor = PictureBox1.BackColor
        PictureBox9.BackColor = PictureBox1.BackColor
        InportBack()
    End Sub
End Class
