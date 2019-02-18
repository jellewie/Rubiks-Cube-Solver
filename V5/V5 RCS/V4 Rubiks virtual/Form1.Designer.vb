<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Rubiks_Cube_Solver
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Rubiks_Cube_Solver))
        Me.LabelUitleg7 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.LabelErrors = New System.Windows.Forms.Label()
        Me.ButtonSend = New System.Windows.Forms.Button()
        Me.ButtonTest3 = New System.Windows.Forms.Button()
        Me.ButtonTest2 = New System.Windows.Forms.Button()
        Me.LabelUitleg5 = New System.Windows.Forms.Label()
        Me.LabelUitleg4 = New System.Windows.Forms.Label()
        Me.LabelUitleg2 = New System.Windows.Forms.Label()
        Me.LabelUitleg3 = New System.Windows.Forms.Label()
        Me.LabelUitleg1 = New System.Windows.Forms.Label()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.ComboBox8 = New System.Windows.Forms.ComboBox()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.ButtonSuperFlip = New System.Windows.Forms.Button()
        Me.LabelTimer = New System.Windows.Forms.Label()
        Me.ButtonReset = New System.Windows.Forms.Button()
        Me.LabelArduinoSteps = New System.Windows.Forms.Label()
        Me.ButtonClose = New System.Windows.Forms.Button()
        Me.ButtonStartStop = New System.Windows.Forms.Button()
        Me.LabelStep9 = New System.Windows.Forms.Label()
        Me.LabelStep8 = New System.Windows.Forms.Label()
        Me.LabelStep7 = New System.Windows.Forms.Label()
        Me.ButtonArduino = New System.Windows.Forms.Button()
        Me.LabelStep6 = New System.Windows.Forms.Label()
        Me.LabelStep5 = New System.Windows.Forms.Label()
        Me.LabelStep4 = New System.Windows.Forms.Label()
        Me.LabelStep3 = New System.Windows.Forms.Label()
        Me.LabelStep2 = New System.Windows.Forms.Label()
        Me.LabelStep1 = New System.Windows.Forms.Label()
        Me.RichTextBoxOutput = New System.Windows.Forms.RichTextBox()
        Me.TextBoxInput = New System.Windows.Forms.TextBox()
        Me.LabelSteps = New System.Windows.Forms.Label()
        Me.ButtonSpam = New System.Windows.Forms.Button()
        Me.LabelToDo30 = New System.Windows.Forms.Label()
        Me.LabelToDo29 = New System.Windows.Forms.Label()
        Me.LabelToDo28 = New System.Windows.Forms.Label()
        Me.LabelToDo27 = New System.Windows.Forms.Label()
        Me.LabelToDo26 = New System.Windows.Forms.Label()
        Me.LabelToDo25 = New System.Windows.Forms.Label()
        Me.LabelToDo24 = New System.Windows.Forms.Label()
        Me.LabelToDo23 = New System.Windows.Forms.Label()
        Me.LabelToDo22 = New System.Windows.Forms.Label()
        Me.LabelToDo21 = New System.Windows.Forms.Label()
        Me.LabelToDo20 = New System.Windows.Forms.Label()
        Me.LabelToDo19 = New System.Windows.Forms.Label()
        Me.LabelToDo18 = New System.Windows.Forms.Label()
        Me.LabelToDo16 = New System.Windows.Forms.Label()
        Me.LabelToDo17 = New System.Windows.Forms.Label()
        Me.LabelToDo15 = New System.Windows.Forms.Label()
        Me.LabelToDo14 = New System.Windows.Forms.Label()
        Me.LabelToDo13 = New System.Windows.Forms.Label()
        Me.LabelToDo12 = New System.Windows.Forms.Label()
        Me.LabelToDo11 = New System.Windows.Forms.Label()
        Me.LabelToDo10 = New System.Windows.Forms.Label()
        Me.LabelToDo9 = New System.Windows.Forms.Label()
        Me.LabelToDo8 = New System.Windows.Forms.Label()
        Me.LabelToDo7 = New System.Windows.Forms.Label()
        Me.LabelToDo6 = New System.Windows.Forms.Label()
        Me.LabelToDo5 = New System.Windows.Forms.Label()
        Me.LabelToDo4 = New System.Windows.Forms.Label()
        Me.LabelToDo3 = New System.Windows.Forms.Label()
        Me.LabelToDo2 = New System.Windows.Forms.Label()
        Me.LabelToDo1 = New System.Windows.Forms.Label()
        Me.ButtonTest1 = New System.Windows.Forms.Button()
        Me.PictureBoxRememberColor = New System.Windows.Forms.PictureBox()
        Me.ButtonInportD = New System.Windows.Forms.Button()
        Me.ButtonInportU = New System.Windows.Forms.Button()
        Me.ButtonInportR = New System.Windows.Forms.Button()
        Me.ButtonInportL = New System.Windows.Forms.Button()
        Me.ButtonInportB = New System.Windows.Forms.Button()
        Me.PictureBox55 = New System.Windows.Forms.PictureBox()
        Me.PictureBox56 = New System.Windows.Forms.PictureBox()
        Me.PictureBox57 = New System.Windows.Forms.PictureBox()
        Me.PictureBox58 = New System.Windows.Forms.PictureBox()
        Me.PictureBox59 = New System.Windows.Forms.PictureBox()
        Me.PictureBox60 = New System.Windows.Forms.PictureBox()
        Me.PictureBox61 = New System.Windows.Forms.PictureBox()
        Me.PictureBox62 = New System.Windows.Forms.PictureBox()
        Me.PictureBox63 = New System.Windows.Forms.PictureBox()
        Me.PictureBox46 = New System.Windows.Forms.PictureBox()
        Me.PictureBox47 = New System.Windows.Forms.PictureBox()
        Me.PictureBox48 = New System.Windows.Forms.PictureBox()
        Me.PictureBox49 = New System.Windows.Forms.PictureBox()
        Me.PictureBox50 = New System.Windows.Forms.PictureBox()
        Me.PictureBox51 = New System.Windows.Forms.PictureBox()
        Me.PictureBox52 = New System.Windows.Forms.PictureBox()
        Me.PictureBox53 = New System.Windows.Forms.PictureBox()
        Me.PictureBox54 = New System.Windows.Forms.PictureBox()
        Me.PictureBox37 = New System.Windows.Forms.PictureBox()
        Me.PictureBox38 = New System.Windows.Forms.PictureBox()
        Me.PictureBox39 = New System.Windows.Forms.PictureBox()
        Me.PictureBox40 = New System.Windows.Forms.PictureBox()
        Me.PictureBox41 = New System.Windows.Forms.PictureBox()
        Me.PictureBox42 = New System.Windows.Forms.PictureBox()
        Me.PictureBox43 = New System.Windows.Forms.PictureBox()
        Me.PictureBox44 = New System.Windows.Forms.PictureBox()
        Me.PictureBox45 = New System.Windows.Forms.PictureBox()
        Me.PictureBox28 = New System.Windows.Forms.PictureBox()
        Me.PictureBox29 = New System.Windows.Forms.PictureBox()
        Me.PictureBox30 = New System.Windows.Forms.PictureBox()
        Me.PictureBox31 = New System.Windows.Forms.PictureBox()
        Me.PictureBox32 = New System.Windows.Forms.PictureBox()
        Me.PictureBox33 = New System.Windows.Forms.PictureBox()
        Me.PictureBox34 = New System.Windows.Forms.PictureBox()
        Me.PictureBox35 = New System.Windows.Forms.PictureBox()
        Me.PictureBox36 = New System.Windows.Forms.PictureBox()
        Me.PictureBox19 = New System.Windows.Forms.PictureBox()
        Me.PictureBox20 = New System.Windows.Forms.PictureBox()
        Me.PictureBox21 = New System.Windows.Forms.PictureBox()
        Me.PictureBox22 = New System.Windows.Forms.PictureBox()
        Me.PictureBox23 = New System.Windows.Forms.PictureBox()
        Me.PictureBox24 = New System.Windows.Forms.PictureBox()
        Me.PictureBox25 = New System.Windows.Forms.PictureBox()
        Me.PictureBox26 = New System.Windows.Forms.PictureBox()
        Me.PictureBox27 = New System.Windows.Forms.PictureBox()
        Me.PictureBox10 = New System.Windows.Forms.PictureBox()
        Me.PictureBox11 = New System.Windows.Forms.PictureBox()
        Me.PictureBox12 = New System.Windows.Forms.PictureBox()
        Me.PictureBox13 = New System.Windows.Forms.PictureBox()
        Me.PictureBox14 = New System.Windows.Forms.PictureBox()
        Me.PictureBox15 = New System.Windows.Forms.PictureBox()
        Me.PictureBox16 = New System.Windows.Forms.PictureBox()
        Me.PictureBox17 = New System.Windows.Forms.PictureBox()
        Me.PictureBox18 = New System.Windows.Forms.PictureBox()
        Me.PictureBox9 = New System.Windows.Forms.PictureBox()
        Me.PictureBox8 = New System.Windows.Forms.PictureBox()
        Me.PictureBox7 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ButtonInportF = New System.Windows.Forms.Button()
        Me.ComboBoxUSB = New System.Windows.Forms.ComboBox()
        Me.ButtonConnectDisconnect = New System.Windows.Forms.Button()
        CType(Me.PictureBoxRememberColor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox55, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox56, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox57, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox58, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox59, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox60, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox61, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox62, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox63, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox54, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox45, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelUitleg7
        '
        Me.LabelUitleg7.AutoSize = True
        Me.LabelUitleg7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelUitleg7.Location = New System.Drawing.Point(181, 122)
        Me.LabelUitleg7.Name = "LabelUitleg7"
        Me.LabelUitleg7.Size = New System.Drawing.Size(47, 17)
        Me.LabelUitleg7.TabIndex = 343
        Me.LabelUitleg7.Text = "Errors"
        '
        'SerialPort1
        '
        Me.SerialPort1.PortName = "COM6"
        '
        'LabelErrors
        '
        Me.LabelErrors.AutoSize = True
        Me.LabelErrors.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelErrors.Location = New System.Drawing.Point(181, 139)
        Me.LabelErrors.Name = "LabelErrors"
        Me.LabelErrors.Size = New System.Drawing.Size(16, 17)
        Me.LabelErrors.TabIndex = 342
        Me.LabelErrors.Text = "0"
        '
        'ButtonSend
        '
        Me.ButtonSend.Enabled = False
        Me.ButtonSend.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Me.ButtonSend.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonSend.Location = New System.Drawing.Point(179, 424)
        Me.ButtonSend.Name = "ButtonSend"
        Me.ButtonSend.Size = New System.Drawing.Size(50, 27)
        Me.ButtonSend.TabIndex = 11
        Me.ButtonSend.Text = "► "
        Me.ButtonSend.UseVisualStyleBackColor = True
        '
        'ButtonTest3
        '
        Me.ButtonTest3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.ButtonTest3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonTest3.Location = New System.Drawing.Point(1165, 644)
        Me.ButtonTest3.Name = "ButtonTest3"
        Me.ButtonTest3.Size = New System.Drawing.Size(89, 32)
        Me.ButtonTest3.TabIndex = 105
        Me.ButtonTest3.Text = "Test 3"
        Me.ButtonTest3.UseVisualStyleBackColor = True
        '
        'ButtonTest2
        '
        Me.ButtonTest2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.ButtonTest2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonTest2.Location = New System.Drawing.Point(1164, 606)
        Me.ButtonTest2.Name = "ButtonTest2"
        Me.ButtonTest2.Size = New System.Drawing.Size(90, 32)
        Me.ButtonTest2.TabIndex = 104
        Me.ButtonTest2.Text = "Test 2"
        Me.ButtonTest2.UseVisualStyleBackColor = True
        '
        'LabelUitleg5
        '
        Me.LabelUitleg5.AutoSize = True
        Me.LabelUitleg5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelUitleg5.Location = New System.Drawing.Point(1116, 9)
        Me.LabelUitleg5.Name = "LabelUitleg5"
        Me.LabelUitleg5.Size = New System.Drawing.Size(80, 17)
        Me.LabelUitleg5.TabIndex = 338
        Me.LabelUitleg5.Text = "Steps to do"
        '
        'LabelUitleg4
        '
        Me.LabelUitleg4.AutoSize = True
        Me.LabelUitleg4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelUitleg4.Location = New System.Drawing.Point(1078, 10)
        Me.LabelUitleg4.Name = "LabelUitleg4"
        Me.LabelUitleg4.Size = New System.Drawing.Size(32, 17)
        Me.LabelUitleg4.TabIndex = 337
        Me.LabelUitleg4.Text = "Pos"
        '
        'LabelUitleg2
        '
        Me.LabelUitleg2.AutoSize = True
        Me.LabelUitleg2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelUitleg2.Location = New System.Drawing.Point(12, 178)
        Me.LabelUitleg2.Name = "LabelUitleg2"
        Me.LabelUitleg2.Size = New System.Drawing.Size(77, 17)
        Me.LabelUitleg2.TabIndex = 336
        Me.LabelUitleg2.Text = "Cube turns"
        '
        'LabelUitleg3
        '
        Me.LabelUitleg3.AutoSize = True
        Me.LabelUitleg3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelUitleg3.Location = New System.Drawing.Point(12, 234)
        Me.LabelUitleg3.Name = "LabelUitleg3"
        Me.LabelUitleg3.Size = New System.Drawing.Size(105, 17)
        Me.LabelUitleg3.TabIndex = 335
        Me.LabelUitleg3.Text = "Time from Start"
        '
        'LabelUitleg1
        '
        Me.LabelUitleg1.AutoSize = True
        Me.LabelUitleg1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelUitleg1.Location = New System.Drawing.Point(12, 122)
        Me.LabelUitleg1.Name = "LabelUitleg1"
        Me.LabelUitleg1.Size = New System.Drawing.Size(95, 17)
        Me.LabelUitleg1.TabIndex = 334
        Me.LabelUitleg1.Text = "Arduino steps"
        '
        'ComboBox9
        '
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Location = New System.Drawing.Point(406, 134)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(50, 24)
        Me.ComboBox9.TabIndex = 23
        '
        'ComboBox8
        '
        Me.ComboBox8.FormattingEnabled = True
        Me.ComboBox8.Location = New System.Drawing.Point(350, 134)
        Me.ComboBox8.Name = "ComboBox8"
        Me.ComboBox8.Size = New System.Drawing.Size(50, 24)
        Me.ComboBox8.TabIndex = 22
        '
        'ComboBox7
        '
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Location = New System.Drawing.Point(294, 134)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(50, 24)
        Me.ComboBox7.TabIndex = 21
        '
        'ComboBox6
        '
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Location = New System.Drawing.Point(406, 80)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(50, 24)
        Me.ComboBox6.TabIndex = 20
        '
        'ComboBox5
        '
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(350, 80)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(50, 24)
        Me.ComboBox5.TabIndex = 19
        '
        'ComboBox4
        '
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Location = New System.Drawing.Point(294, 80)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(50, 24)
        Me.ComboBox4.TabIndex = 18
        '
        'ComboBox3
        '
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(406, 25)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(50, 24)
        Me.ComboBox3.TabIndex = 17
        Me.ComboBox3.Tag = ""
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(350, 25)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(50, 24)
        Me.ComboBox2.TabIndex = 16
        '
        'ComboBox1
        '
        Me.ComboBox1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(294, 25)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(50, 24)
        Me.ComboBox1.TabIndex = 15
        '
        'ButtonSuperFlip
        '
        Me.ButtonSuperFlip.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonSuperFlip.Location = New System.Drawing.Point(1081, 570)
        Me.ButtonSuperFlip.Name = "ButtonSuperFlip"
        Me.ButtonSuperFlip.Size = New System.Drawing.Size(77, 50)
        Me.ButtonSuperFlip.TabIndex = 101
        Me.ButtonSuperFlip.Text = "Super Flip"
        Me.ButtonSuperFlip.UseVisualStyleBackColor = True
        '
        'LabelTimer
        '
        Me.LabelTimer.AutoSize = True
        Me.LabelTimer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelTimer.Location = New System.Drawing.Point(12, 251)
        Me.LabelTimer.Name = "LabelTimer"
        Me.LabelTimer.Size = New System.Drawing.Size(16, 17)
        Me.LabelTimer.TabIndex = 332
        Me.LabelTimer.Text = "0"
        '
        'ButtonReset
        '
        Me.ButtonReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ButtonReset.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonReset.Location = New System.Drawing.Point(11, 66)
        Me.ButtonReset.Name = "ButtonReset"
        Me.ButtonReset.Size = New System.Drawing.Size(106, 50)
        Me.ButtonReset.TabIndex = 3
        Me.ButtonReset.Text = "Reset"
        Me.ButtonReset.UseVisualStyleBackColor = True
        '
        'LabelArduinoSteps
        '
        Me.LabelArduinoSteps.AutoSize = True
        Me.LabelArduinoSteps.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelArduinoSteps.Location = New System.Drawing.Point(12, 139)
        Me.LabelArduinoSteps.Name = "LabelArduinoSteps"
        Me.LabelArduinoSteps.Size = New System.Drawing.Size(16, 17)
        Me.LabelArduinoSteps.TabIndex = 330
        Me.LabelArduinoSteps.Text = "0"
        '
        'ButtonClose
        '
        Me.ButtonClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ButtonClose.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonClose.Location = New System.Drawing.Point(910, 10)
        Me.ButtonClose.Name = "ButtonClose"
        Me.ButtonClose.Size = New System.Drawing.Size(106, 50)
        Me.ButtonClose.TabIndex = 30
        Me.ButtonClose.Text = "Close"
        Me.ButtonClose.UseVisualStyleBackColor = True
        '
        'ButtonStartStop
        '
        Me.ButtonStartStop.Enabled = False
        Me.ButtonStartStop.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ButtonStartStop.ForeColor = System.Drawing.Color.Green
        Me.ButtonStartStop.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonStartStop.Location = New System.Drawing.Point(123, 66)
        Me.ButtonStartStop.Name = "ButtonStartStop"
        Me.ButtonStartStop.Size = New System.Drawing.Size(106, 50)
        Me.ButtonStartStop.TabIndex = 4
        Me.ButtonStartStop.Text = "Start"
        Me.ButtonStartStop.UseVisualStyleBackColor = True
        '
        'LabelStep9
        '
        Me.LabelStep9.AutoSize = True
        Me.LabelStep9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelStep9.Location = New System.Drawing.Point(1078, 161)
        Me.LabelStep9.Name = "LabelStep9"
        Me.LabelStep9.Size = New System.Drawing.Size(16, 17)
        Me.LabelStep9.TabIndex = 327
        Me.LabelStep9.Text = "9"
        '
        'LabelStep8
        '
        Me.LabelStep8.AutoSize = True
        Me.LabelStep8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelStep8.Location = New System.Drawing.Point(1078, 145)
        Me.LabelStep8.Name = "LabelStep8"
        Me.LabelStep8.Size = New System.Drawing.Size(16, 17)
        Me.LabelStep8.TabIndex = 326
        Me.LabelStep8.Text = "8"
        '
        'LabelStep7
        '
        Me.LabelStep7.AutoSize = True
        Me.LabelStep7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelStep7.Location = New System.Drawing.Point(1078, 128)
        Me.LabelStep7.Name = "LabelStep7"
        Me.LabelStep7.Size = New System.Drawing.Size(16, 17)
        Me.LabelStep7.TabIndex = 325
        Me.LabelStep7.Text = "7"
        '
        'ButtonArduino
        '
        Me.ButtonArduino.Enabled = False
        Me.ButtonArduino.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ButtonArduino.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonArduino.Location = New System.Drawing.Point(11, 458)
        Me.ButtonArduino.Name = "ButtonArduino"
        Me.ButtonArduino.Size = New System.Drawing.Size(218, 50)
        Me.ButtonArduino.TabIndex = 12
        Me.ButtonArduino.Text = "Arduino Button"
        Me.ButtonArduino.UseVisualStyleBackColor = True
        '
        'LabelStep6
        '
        Me.LabelStep6.AutoSize = True
        Me.LabelStep6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelStep6.Location = New System.Drawing.Point(1078, 111)
        Me.LabelStep6.Name = "LabelStep6"
        Me.LabelStep6.Size = New System.Drawing.Size(16, 17)
        Me.LabelStep6.TabIndex = 323
        Me.LabelStep6.Text = "6"
        '
        'LabelStep5
        '
        Me.LabelStep5.AutoSize = True
        Me.LabelStep5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelStep5.Location = New System.Drawing.Point(1078, 94)
        Me.LabelStep5.Name = "LabelStep5"
        Me.LabelStep5.Size = New System.Drawing.Size(16, 17)
        Me.LabelStep5.TabIndex = 322
        Me.LabelStep5.Text = "5"
        '
        'LabelStep4
        '
        Me.LabelStep4.AutoSize = True
        Me.LabelStep4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelStep4.Location = New System.Drawing.Point(1078, 77)
        Me.LabelStep4.Name = "LabelStep4"
        Me.LabelStep4.Size = New System.Drawing.Size(16, 17)
        Me.LabelStep4.TabIndex = 321
        Me.LabelStep4.Text = "4"
        '
        'LabelStep3
        '
        Me.LabelStep3.AutoSize = True
        Me.LabelStep3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelStep3.Location = New System.Drawing.Point(1078, 61)
        Me.LabelStep3.Name = "LabelStep3"
        Me.LabelStep3.Size = New System.Drawing.Size(16, 17)
        Me.LabelStep3.TabIndex = 320
        Me.LabelStep3.Text = "3"
        '
        'LabelStep2
        '
        Me.LabelStep2.AutoSize = True
        Me.LabelStep2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelStep2.Location = New System.Drawing.Point(1078, 44)
        Me.LabelStep2.Name = "LabelStep2"
        Me.LabelStep2.Size = New System.Drawing.Size(16, 17)
        Me.LabelStep2.TabIndex = 319
        Me.LabelStep2.Text = "2"
        '
        'LabelStep1
        '
        Me.LabelStep1.AutoSize = True
        Me.LabelStep1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelStep1.Location = New System.Drawing.Point(1078, 27)
        Me.LabelStep1.Name = "LabelStep1"
        Me.LabelStep1.Size = New System.Drawing.Size(16, 17)
        Me.LabelStep1.TabIndex = 318
        Me.LabelStep1.Text = "1"
        '
        'RichTextBoxOutput
        '
        Me.RichTextBoxOutput.Location = New System.Drawing.Point(11, 514)
        Me.RichTextBoxOutput.Name = "RichTextBoxOutput"
        Me.RichTextBoxOutput.Size = New System.Drawing.Size(218, 162)
        Me.RichTextBoxOutput.TabIndex = 14
        Me.RichTextBoxOutput.Text = ""
        '
        'TextBoxInput
        '
        Me.TextBoxInput.Enabled = False
        Me.TextBoxInput.Location = New System.Drawing.Point(11, 425)
        Me.TextBoxInput.Name = "TextBoxInput"
        Me.TextBoxInput.Size = New System.Drawing.Size(162, 22)
        Me.TextBoxInput.TabIndex = 10
        '
        'LabelSteps
        '
        Me.LabelSteps.AutoSize = True
        Me.LabelSteps.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelSteps.Location = New System.Drawing.Point(12, 195)
        Me.LabelSteps.Name = "LabelSteps"
        Me.LabelSteps.Size = New System.Drawing.Size(16, 17)
        Me.LabelSteps.TabIndex = 314
        Me.LabelSteps.Text = "0"
        '
        'ButtonSpam
        '
        Me.ButtonSpam.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonSpam.Location = New System.Drawing.Point(1081, 626)
        Me.ButtonSpam.Name = "ButtonSpam"
        Me.ButtonSpam.Size = New System.Drawing.Size(78, 50)
        Me.ButtonSpam.TabIndex = 102
        Me.ButtonSpam.Text = "Spam"
        Me.ButtonSpam.UseVisualStyleBackColor = True
        '
        'LabelToDo30
        '
        Me.LabelToDo30.AutoSize = True
        Me.LabelToDo30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo30.Location = New System.Drawing.Point(1116, 518)
        Me.LabelToDo30.Name = "LabelToDo30"
        Me.LabelToDo30.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo30.TabIndex = 312
        Me.LabelToDo30.Text = "30"
        '
        'LabelToDo29
        '
        Me.LabelToDo29.AutoSize = True
        Me.LabelToDo29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo29.Location = New System.Drawing.Point(1116, 501)
        Me.LabelToDo29.Name = "LabelToDo29"
        Me.LabelToDo29.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo29.TabIndex = 311
        Me.LabelToDo29.Text = "29"
        '
        'LabelToDo28
        '
        Me.LabelToDo28.AutoSize = True
        Me.LabelToDo28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo28.Location = New System.Drawing.Point(1116, 484)
        Me.LabelToDo28.Name = "LabelToDo28"
        Me.LabelToDo28.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo28.TabIndex = 310
        Me.LabelToDo28.Text = "28"
        '
        'LabelToDo27
        '
        Me.LabelToDo27.AutoSize = True
        Me.LabelToDo27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo27.Location = New System.Drawing.Point(1116, 467)
        Me.LabelToDo27.Name = "LabelToDo27"
        Me.LabelToDo27.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo27.TabIndex = 309
        Me.LabelToDo27.Text = "27"
        '
        'LabelToDo26
        '
        Me.LabelToDo26.AutoSize = True
        Me.LabelToDo26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo26.Location = New System.Drawing.Point(1116, 450)
        Me.LabelToDo26.Name = "LabelToDo26"
        Me.LabelToDo26.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo26.TabIndex = 308
        Me.LabelToDo26.Text = "26"
        '
        'LabelToDo25
        '
        Me.LabelToDo25.AutoSize = True
        Me.LabelToDo25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo25.Location = New System.Drawing.Point(1116, 433)
        Me.LabelToDo25.Name = "LabelToDo25"
        Me.LabelToDo25.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo25.TabIndex = 307
        Me.LabelToDo25.Text = "25"
        '
        'LabelToDo24
        '
        Me.LabelToDo24.AutoSize = True
        Me.LabelToDo24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo24.Location = New System.Drawing.Point(1116, 416)
        Me.LabelToDo24.Name = "LabelToDo24"
        Me.LabelToDo24.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo24.TabIndex = 306
        Me.LabelToDo24.Text = "24"
        '
        'LabelToDo23
        '
        Me.LabelToDo23.AutoSize = True
        Me.LabelToDo23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo23.Location = New System.Drawing.Point(1116, 399)
        Me.LabelToDo23.Name = "LabelToDo23"
        Me.LabelToDo23.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo23.TabIndex = 305
        Me.LabelToDo23.Text = "23"
        '
        'LabelToDo22
        '
        Me.LabelToDo22.AutoSize = True
        Me.LabelToDo22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo22.Location = New System.Drawing.Point(1116, 382)
        Me.LabelToDo22.Name = "LabelToDo22"
        Me.LabelToDo22.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo22.TabIndex = 304
        Me.LabelToDo22.Text = "22"
        '
        'LabelToDo21
        '
        Me.LabelToDo21.AutoSize = True
        Me.LabelToDo21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo21.Location = New System.Drawing.Point(1116, 365)
        Me.LabelToDo21.Name = "LabelToDo21"
        Me.LabelToDo21.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo21.TabIndex = 303
        Me.LabelToDo21.Text = "21"
        '
        'LabelToDo20
        '
        Me.LabelToDo20.AutoSize = True
        Me.LabelToDo20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo20.Location = New System.Drawing.Point(1116, 348)
        Me.LabelToDo20.Name = "LabelToDo20"
        Me.LabelToDo20.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo20.TabIndex = 302
        Me.LabelToDo20.Text = "20"
        '
        'LabelToDo19
        '
        Me.LabelToDo19.AutoSize = True
        Me.LabelToDo19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo19.Location = New System.Drawing.Point(1116, 331)
        Me.LabelToDo19.Name = "LabelToDo19"
        Me.LabelToDo19.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo19.TabIndex = 301
        Me.LabelToDo19.Text = "19"
        '
        'LabelToDo18
        '
        Me.LabelToDo18.AutoSize = True
        Me.LabelToDo18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo18.Location = New System.Drawing.Point(1116, 314)
        Me.LabelToDo18.Name = "LabelToDo18"
        Me.LabelToDo18.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo18.TabIndex = 300
        Me.LabelToDo18.Text = "18"
        '
        'LabelToDo16
        '
        Me.LabelToDo16.AutoSize = True
        Me.LabelToDo16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo16.Location = New System.Drawing.Point(1116, 280)
        Me.LabelToDo16.Name = "LabelToDo16"
        Me.LabelToDo16.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo16.TabIndex = 299
        Me.LabelToDo16.Text = "16"
        '
        'LabelToDo17
        '
        Me.LabelToDo17.AutoSize = True
        Me.LabelToDo17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo17.Location = New System.Drawing.Point(1116, 297)
        Me.LabelToDo17.Name = "LabelToDo17"
        Me.LabelToDo17.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo17.TabIndex = 298
        Me.LabelToDo17.Text = "17"
        '
        'LabelToDo15
        '
        Me.LabelToDo15.AutoSize = True
        Me.LabelToDo15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo15.Location = New System.Drawing.Point(1116, 263)
        Me.LabelToDo15.Name = "LabelToDo15"
        Me.LabelToDo15.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo15.TabIndex = 297
        Me.LabelToDo15.Text = "15"
        '
        'LabelToDo14
        '
        Me.LabelToDo14.AutoSize = True
        Me.LabelToDo14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo14.Location = New System.Drawing.Point(1116, 246)
        Me.LabelToDo14.Name = "LabelToDo14"
        Me.LabelToDo14.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo14.TabIndex = 296
        Me.LabelToDo14.Text = "14"
        '
        'LabelToDo13
        '
        Me.LabelToDo13.AutoSize = True
        Me.LabelToDo13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo13.Location = New System.Drawing.Point(1116, 229)
        Me.LabelToDo13.Name = "LabelToDo13"
        Me.LabelToDo13.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo13.TabIndex = 295
        Me.LabelToDo13.Text = "13"
        '
        'LabelToDo12
        '
        Me.LabelToDo12.AutoSize = True
        Me.LabelToDo12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo12.Location = New System.Drawing.Point(1116, 213)
        Me.LabelToDo12.Name = "LabelToDo12"
        Me.LabelToDo12.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo12.TabIndex = 294
        Me.LabelToDo12.Text = "12"
        '
        'LabelToDo11
        '
        Me.LabelToDo11.AutoSize = True
        Me.LabelToDo11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo11.Location = New System.Drawing.Point(1116, 196)
        Me.LabelToDo11.Name = "LabelToDo11"
        Me.LabelToDo11.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo11.TabIndex = 293
        Me.LabelToDo11.Text = "11"
        '
        'LabelToDo10
        '
        Me.LabelToDo10.AutoSize = True
        Me.LabelToDo10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo10.Location = New System.Drawing.Point(1116, 180)
        Me.LabelToDo10.Name = "LabelToDo10"
        Me.LabelToDo10.Size = New System.Drawing.Size(24, 17)
        Me.LabelToDo10.TabIndex = 292
        Me.LabelToDo10.Text = "10"
        '
        'LabelToDo9
        '
        Me.LabelToDo9.AutoSize = True
        Me.LabelToDo9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo9.Location = New System.Drawing.Point(1116, 163)
        Me.LabelToDo9.Name = "LabelToDo9"
        Me.LabelToDo9.Size = New System.Drawing.Size(16, 17)
        Me.LabelToDo9.TabIndex = 291
        Me.LabelToDo9.Text = "9"
        '
        'LabelToDo8
        '
        Me.LabelToDo8.AutoSize = True
        Me.LabelToDo8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo8.Location = New System.Drawing.Point(1116, 146)
        Me.LabelToDo8.Name = "LabelToDo8"
        Me.LabelToDo8.Size = New System.Drawing.Size(16, 17)
        Me.LabelToDo8.TabIndex = 290
        Me.LabelToDo8.Text = "8"
        '
        'LabelToDo7
        '
        Me.LabelToDo7.AutoSize = True
        Me.LabelToDo7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo7.Location = New System.Drawing.Point(1116, 129)
        Me.LabelToDo7.Name = "LabelToDo7"
        Me.LabelToDo7.Size = New System.Drawing.Size(16, 17)
        Me.LabelToDo7.TabIndex = 289
        Me.LabelToDo7.Text = "7"
        '
        'LabelToDo6
        '
        Me.LabelToDo6.AutoSize = True
        Me.LabelToDo6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo6.Location = New System.Drawing.Point(1116, 112)
        Me.LabelToDo6.Name = "LabelToDo6"
        Me.LabelToDo6.Size = New System.Drawing.Size(16, 17)
        Me.LabelToDo6.TabIndex = 288
        Me.LabelToDo6.Text = "6"
        '
        'LabelToDo5
        '
        Me.LabelToDo5.AutoSize = True
        Me.LabelToDo5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo5.Location = New System.Drawing.Point(1116, 95)
        Me.LabelToDo5.Name = "LabelToDo5"
        Me.LabelToDo5.Size = New System.Drawing.Size(16, 17)
        Me.LabelToDo5.TabIndex = 287
        Me.LabelToDo5.Text = "5"
        '
        'LabelToDo4
        '
        Me.LabelToDo4.AutoSize = True
        Me.LabelToDo4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo4.Location = New System.Drawing.Point(1116, 78)
        Me.LabelToDo4.Name = "LabelToDo4"
        Me.LabelToDo4.Size = New System.Drawing.Size(16, 17)
        Me.LabelToDo4.TabIndex = 286
        Me.LabelToDo4.Text = "4"
        '
        'LabelToDo3
        '
        Me.LabelToDo3.AutoSize = True
        Me.LabelToDo3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo3.Location = New System.Drawing.Point(1116, 61)
        Me.LabelToDo3.Name = "LabelToDo3"
        Me.LabelToDo3.Size = New System.Drawing.Size(16, 17)
        Me.LabelToDo3.TabIndex = 285
        Me.LabelToDo3.Text = "3"
        '
        'LabelToDo2
        '
        Me.LabelToDo2.AutoSize = True
        Me.LabelToDo2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo2.Location = New System.Drawing.Point(1116, 44)
        Me.LabelToDo2.Name = "LabelToDo2"
        Me.LabelToDo2.Size = New System.Drawing.Size(16, 17)
        Me.LabelToDo2.TabIndex = 284
        Me.LabelToDo2.Text = "2"
        '
        'LabelToDo1
        '
        Me.LabelToDo1.AutoSize = True
        Me.LabelToDo1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LabelToDo1.Location = New System.Drawing.Point(1116, 27)
        Me.LabelToDo1.Name = "LabelToDo1"
        Me.LabelToDo1.Size = New System.Drawing.Size(16, 17)
        Me.LabelToDo1.TabIndex = 283
        Me.LabelToDo1.Text = "1"
        '
        'ButtonTest1
        '
        Me.ButtonTest1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!)
        Me.ButtonTest1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonTest1.Location = New System.Drawing.Point(1164, 570)
        Me.ButtonTest1.Name = "ButtonTest1"
        Me.ButtonTest1.Size = New System.Drawing.Size(90, 32)
        Me.ButtonTest1.TabIndex = 103
        Me.ButtonTest1.Text = "Test 1"
        Me.ButtonTest1.UseVisualStyleBackColor = True
        '
        'PictureBoxRememberColor
        '
        Me.PictureBoxRememberColor.ErrorImage = Nothing
        Me.PictureBoxRememberColor.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBoxRememberColor.InitialImage = Nothing
        Me.PictureBoxRememberColor.Location = New System.Drawing.Point(1081, 185)
        Me.PictureBoxRememberColor.Name = "PictureBoxRememberColor"
        Me.PictureBoxRememberColor.Size = New System.Drawing.Size(25, 25)
        Me.PictureBoxRememberColor.TabIndex = 281
        Me.PictureBoxRememberColor.TabStop = False
        '
        'ButtonInportD
        '
        Me.ButtonInportD.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonInportD.Location = New System.Drawing.Point(350, 458)
        Me.ButtonInportD.Name = "ButtonInportD"
        Me.ButtonInportD.Size = New System.Drawing.Size(50, 50)
        Me.ButtonInportD.TabIndex = 28
        Me.ButtonInportD.Text = "To D"
        Me.ButtonInportD.UseVisualStyleBackColor = True
        '
        'ButtonInportU
        '
        Me.ButtonInportU.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonInportU.Location = New System.Drawing.Point(350, 346)
        Me.ButtonInportU.Name = "ButtonInportU"
        Me.ButtonInportU.Size = New System.Drawing.Size(50, 50)
        Me.ButtonInportU.TabIndex = 24
        Me.ButtonInportU.Text = "To U"
        Me.ButtonInportU.UseVisualStyleBackColor = True
        '
        'ButtonInportR
        '
        Me.ButtonInportR.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonInportR.Location = New System.Drawing.Point(406, 402)
        Me.ButtonInportR.Name = "ButtonInportR"
        Me.ButtonInportR.Size = New System.Drawing.Size(50, 50)
        Me.ButtonInportR.TabIndex = 27
        Me.ButtonInportR.Text = "To R"
        Me.ButtonInportR.UseVisualStyleBackColor = True
        '
        'ButtonInportL
        '
        Me.ButtonInportL.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonInportL.Location = New System.Drawing.Point(294, 402)
        Me.ButtonInportL.Name = "ButtonInportL"
        Me.ButtonInportL.Size = New System.Drawing.Size(50, 50)
        Me.ButtonInportL.TabIndex = 25
        Me.ButtonInportL.Text = "To L"
        Me.ButtonInportL.UseVisualStyleBackColor = True
        '
        'ButtonInportB
        '
        Me.ButtonInportB.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonInportB.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonInportB.Location = New System.Drawing.Point(350, 514)
        Me.ButtonInportB.Name = "ButtonInportB"
        Me.ButtonInportB.Size = New System.Drawing.Size(50, 50)
        Me.ButtonInportB.TabIndex = 29
        Me.ButtonInportB.Text = "To B"
        Me.ButtonInportB.UseVisualStyleBackColor = True
        '
        'PictureBox55
        '
        Me.PictureBox55.BackColor = System.Drawing.Color.Orange
        Me.PictureBox55.ErrorImage = Nothing
        Me.PictureBox55.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox55.InitialImage = Nothing
        Me.PictureBox55.Location = New System.Drawing.Point(798, 122)
        Me.PictureBox55.Name = "PictureBox55"
        Me.PictureBox55.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox55.TabIndex = 275
        Me.PictureBox55.TabStop = False
        '
        'PictureBox56
        '
        Me.PictureBox56.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox56.ErrorImage = Nothing
        Me.PictureBox56.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox56.InitialImage = Nothing
        Me.PictureBox56.Location = New System.Drawing.Point(742, 122)
        Me.PictureBox56.Name = "PictureBox56"
        Me.PictureBox56.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox56.TabIndex = 274
        Me.PictureBox56.TabStop = False
        '
        'PictureBox57
        '
        Me.PictureBox57.BackColor = System.Drawing.Color.Red
        Me.PictureBox57.ErrorImage = Nothing
        Me.PictureBox57.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox57.InitialImage = Nothing
        Me.PictureBox57.Location = New System.Drawing.Point(686, 122)
        Me.PictureBox57.Name = "PictureBox57"
        Me.PictureBox57.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox57.TabIndex = 273
        Me.PictureBox57.TabStop = False
        '
        'PictureBox58
        '
        Me.PictureBox58.BackColor = System.Drawing.Color.Red
        Me.PictureBox58.ErrorImage = Nothing
        Me.PictureBox58.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox58.InitialImage = Nothing
        Me.PictureBox58.Location = New System.Drawing.Point(798, 66)
        Me.PictureBox58.Name = "PictureBox58"
        Me.PictureBox58.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox58.TabIndex = 272
        Me.PictureBox58.TabStop = False
        '
        'PictureBox59
        '
        Me.PictureBox59.BackColor = System.Drawing.Color.Green
        Me.PictureBox59.ErrorImage = Nothing
        Me.PictureBox59.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox59.InitialImage = Nothing
        Me.PictureBox59.Location = New System.Drawing.Point(742, 66)
        Me.PictureBox59.Name = "PictureBox59"
        Me.PictureBox59.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox59.TabIndex = 271
        Me.PictureBox59.TabStop = False
        '
        'PictureBox60
        '
        Me.PictureBox60.BackColor = System.Drawing.Color.Green
        Me.PictureBox60.ErrorImage = Nothing
        Me.PictureBox60.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox60.InitialImage = Nothing
        Me.PictureBox60.Location = New System.Drawing.Point(686, 66)
        Me.PictureBox60.Name = "PictureBox60"
        Me.PictureBox60.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox60.TabIndex = 270
        Me.PictureBox60.TabStop = False
        '
        'PictureBox61
        '
        Me.PictureBox61.BackColor = System.Drawing.Color.Red
        Me.PictureBox61.ErrorImage = Nothing
        Me.PictureBox61.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox61.InitialImage = Nothing
        Me.PictureBox61.Location = New System.Drawing.Point(798, 10)
        Me.PictureBox61.Name = "PictureBox61"
        Me.PictureBox61.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox61.TabIndex = 269
        Me.PictureBox61.TabStop = False
        '
        'PictureBox62
        '
        Me.PictureBox62.BackColor = System.Drawing.Color.Green
        Me.PictureBox62.ErrorImage = Nothing
        Me.PictureBox62.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox62.InitialImage = Nothing
        Me.PictureBox62.Location = New System.Drawing.Point(742, 10)
        Me.PictureBox62.Name = "PictureBox62"
        Me.PictureBox62.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox62.TabIndex = 268
        Me.PictureBox62.TabStop = False
        '
        'PictureBox63
        '
        Me.PictureBox63.BackColor = System.Drawing.Color.Green
        Me.PictureBox63.ErrorImage = Nothing
        Me.PictureBox63.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox63.InitialImage = Nothing
        Me.PictureBox63.Location = New System.Drawing.Point(686, 10)
        Me.PictureBox63.Name = "PictureBox63"
        Me.PictureBox63.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox63.TabIndex = 267
        Me.PictureBox63.TabStop = False
        '
        'PictureBox46
        '
        Me.PictureBox46.BackColor = System.Drawing.Color.Red
        Me.PictureBox46.ErrorImage = Nothing
        Me.PictureBox46.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox46.InitialImage = Nothing
        Me.PictureBox46.Location = New System.Drawing.Point(798, 458)
        Me.PictureBox46.Name = "PictureBox46"
        Me.PictureBox46.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox46.TabIndex = 266
        Me.PictureBox46.TabStop = False
        '
        'PictureBox47
        '
        Me.PictureBox47.BackColor = System.Drawing.Color.Green
        Me.PictureBox47.ErrorImage = Nothing
        Me.PictureBox47.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox47.InitialImage = Nothing
        Me.PictureBox47.Location = New System.Drawing.Point(742, 458)
        Me.PictureBox47.Name = "PictureBox47"
        Me.PictureBox47.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox47.TabIndex = 265
        Me.PictureBox47.TabStop = False
        '
        'PictureBox48
        '
        Me.PictureBox48.BackColor = System.Drawing.Color.Yellow
        Me.PictureBox48.ErrorImage = Nothing
        Me.PictureBox48.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox48.InitialImage = Nothing
        Me.PictureBox48.Location = New System.Drawing.Point(686, 458)
        Me.PictureBox48.Name = "PictureBox48"
        Me.PictureBox48.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox48.TabIndex = 264
        Me.PictureBox48.TabStop = False
        '
        'PictureBox49
        '
        Me.PictureBox49.BackColor = System.Drawing.Color.Red
        Me.PictureBox49.ErrorImage = Nothing
        Me.PictureBox49.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox49.InitialImage = Nothing
        Me.PictureBox49.Location = New System.Drawing.Point(798, 402)
        Me.PictureBox49.Name = "PictureBox49"
        Me.PictureBox49.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox49.TabIndex = 263
        Me.PictureBox49.TabStop = False
        '
        'PictureBox50
        '
        Me.PictureBox50.BackColor = System.Drawing.Color.Blue
        Me.PictureBox50.ErrorImage = Nothing
        Me.PictureBox50.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox50.InitialImage = Nothing
        Me.PictureBox50.Location = New System.Drawing.Point(742, 402)
        Me.PictureBox50.Name = "PictureBox50"
        Me.PictureBox50.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox50.TabIndex = 262
        Me.PictureBox50.TabStop = False
        '
        'PictureBox51
        '
        Me.PictureBox51.BackColor = System.Drawing.Color.Orange
        Me.PictureBox51.ErrorImage = Nothing
        Me.PictureBox51.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox51.InitialImage = Nothing
        Me.PictureBox51.Location = New System.Drawing.Point(686, 402)
        Me.PictureBox51.Name = "PictureBox51"
        Me.PictureBox51.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox51.TabIndex = 261
        Me.PictureBox51.TabStop = False
        '
        'PictureBox52
        '
        Me.PictureBox52.BackColor = System.Drawing.Color.Orange
        Me.PictureBox52.ErrorImage = Nothing
        Me.PictureBox52.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox52.InitialImage = Nothing
        Me.PictureBox52.Location = New System.Drawing.Point(798, 346)
        Me.PictureBox52.Name = "PictureBox52"
        Me.PictureBox52.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox52.TabIndex = 260
        Me.PictureBox52.TabStop = False
        '
        'PictureBox53
        '
        Me.PictureBox53.BackColor = System.Drawing.Color.Orange
        Me.PictureBox53.ErrorImage = Nothing
        Me.PictureBox53.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox53.InitialImage = Nothing
        Me.PictureBox53.Location = New System.Drawing.Point(742, 346)
        Me.PictureBox53.Name = "PictureBox53"
        Me.PictureBox53.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox53.TabIndex = 259
        Me.PictureBox53.TabStop = False
        '
        'PictureBox54
        '
        Me.PictureBox54.BackColor = System.Drawing.Color.Orange
        Me.PictureBox54.ErrorImage = Nothing
        Me.PictureBox54.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox54.InitialImage = Nothing
        Me.PictureBox54.Location = New System.Drawing.Point(686, 346)
        Me.PictureBox54.Name = "PictureBox54"
        Me.PictureBox54.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox54.TabIndex = 258
        Me.PictureBox54.TabStop = False
        '
        'PictureBox37
        '
        Me.PictureBox37.BackColor = System.Drawing.Color.Blue
        Me.PictureBox37.ErrorImage = Nothing
        Me.PictureBox37.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox37.InitialImage = Nothing
        Me.PictureBox37.Location = New System.Drawing.Point(966, 290)
        Me.PictureBox37.Name = "PictureBox37"
        Me.PictureBox37.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox37.TabIndex = 257
        Me.PictureBox37.TabStop = False
        '
        'PictureBox38
        '
        Me.PictureBox38.BackColor = System.Drawing.Color.Blue
        Me.PictureBox38.ErrorImage = Nothing
        Me.PictureBox38.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox38.InitialImage = Nothing
        Me.PictureBox38.Location = New System.Drawing.Point(910, 290)
        Me.PictureBox38.Name = "PictureBox38"
        Me.PictureBox38.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox38.TabIndex = 256
        Me.PictureBox38.TabStop = False
        '
        'PictureBox39
        '
        Me.PictureBox39.BackColor = System.Drawing.Color.Blue
        Me.PictureBox39.ErrorImage = Nothing
        Me.PictureBox39.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox39.InitialImage = Nothing
        Me.PictureBox39.Location = New System.Drawing.Point(854, 290)
        Me.PictureBox39.Name = "PictureBox39"
        Me.PictureBox39.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox39.TabIndex = 255
        Me.PictureBox39.TabStop = False
        '
        'PictureBox40
        '
        Me.PictureBox40.BackColor = System.Drawing.Color.Orange
        Me.PictureBox40.ErrorImage = Nothing
        Me.PictureBox40.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox40.InitialImage = Nothing
        Me.PictureBox40.Location = New System.Drawing.Point(966, 234)
        Me.PictureBox40.Name = "PictureBox40"
        Me.PictureBox40.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox40.TabIndex = 254
        Me.PictureBox40.TabStop = False
        '
        'PictureBox41
        '
        Me.PictureBox41.BackColor = System.Drawing.Color.Yellow
        Me.PictureBox41.ErrorImage = Nothing
        Me.PictureBox41.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox41.InitialImage = Nothing
        Me.PictureBox41.Location = New System.Drawing.Point(910, 234)
        Me.PictureBox41.Name = "PictureBox41"
        Me.PictureBox41.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox41.TabIndex = 253
        Me.PictureBox41.TabStop = False
        '
        'PictureBox42
        '
        Me.PictureBox42.BackColor = System.Drawing.Color.Yellow
        Me.PictureBox42.ErrorImage = Nothing
        Me.PictureBox42.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox42.InitialImage = Nothing
        Me.PictureBox42.Location = New System.Drawing.Point(854, 234)
        Me.PictureBox42.Name = "PictureBox42"
        Me.PictureBox42.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox42.TabIndex = 252
        Me.PictureBox42.TabStop = False
        '
        'PictureBox43
        '
        Me.PictureBox43.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox43.ErrorImage = Nothing
        Me.PictureBox43.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox43.InitialImage = Nothing
        Me.PictureBox43.Location = New System.Drawing.Point(966, 178)
        Me.PictureBox43.Name = "PictureBox43"
        Me.PictureBox43.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox43.TabIndex = 251
        Me.PictureBox43.TabStop = False
        '
        'PictureBox44
        '
        Me.PictureBox44.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox44.ErrorImage = Nothing
        Me.PictureBox44.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox44.InitialImage = Nothing
        Me.PictureBox44.Location = New System.Drawing.Point(910, 178)
        Me.PictureBox44.Name = "PictureBox44"
        Me.PictureBox44.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox44.TabIndex = 250
        Me.PictureBox44.TabStop = False
        '
        'PictureBox45
        '
        Me.PictureBox45.BackColor = System.Drawing.Color.Blue
        Me.PictureBox45.ErrorImage = Nothing
        Me.PictureBox45.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox45.InitialImage = Nothing
        Me.PictureBox45.Location = New System.Drawing.Point(854, 178)
        Me.PictureBox45.Name = "PictureBox45"
        Me.PictureBox45.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox45.TabIndex = 249
        Me.PictureBox45.TabStop = False
        '
        'PictureBox28
        '
        Me.PictureBox28.BackColor = System.Drawing.Color.Yellow
        Me.PictureBox28.ErrorImage = Nothing
        Me.PictureBox28.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox28.InitialImage = Nothing
        Me.PictureBox28.Location = New System.Drawing.Point(798, 290)
        Me.PictureBox28.Name = "PictureBox28"
        Me.PictureBox28.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox28.TabIndex = 248
        Me.PictureBox28.TabStop = False
        '
        'PictureBox29
        '
        Me.PictureBox29.BackColor = System.Drawing.Color.Yellow
        Me.PictureBox29.ErrorImage = Nothing
        Me.PictureBox29.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox29.InitialImage = Nothing
        Me.PictureBox29.Location = New System.Drawing.Point(742, 290)
        Me.PictureBox29.Name = "PictureBox29"
        Me.PictureBox29.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox29.TabIndex = 247
        Me.PictureBox29.TabStop = False
        '
        'PictureBox30
        '
        Me.PictureBox30.BackColor = System.Drawing.Color.Yellow
        Me.PictureBox30.ErrorImage = Nothing
        Me.PictureBox30.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox30.InitialImage = Nothing
        Me.PictureBox30.Location = New System.Drawing.Point(686, 290)
        Me.PictureBox30.Name = "PictureBox30"
        Me.PictureBox30.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox30.TabIndex = 246
        Me.PictureBox30.TabStop = False
        '
        'PictureBox31
        '
        Me.PictureBox31.BackColor = System.Drawing.Color.Blue
        Me.PictureBox31.ErrorImage = Nothing
        Me.PictureBox31.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox31.InitialImage = Nothing
        Me.PictureBox31.Location = New System.Drawing.Point(798, 234)
        Me.PictureBox31.Name = "PictureBox31"
        Me.PictureBox31.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox31.TabIndex = 245
        Me.PictureBox31.TabStop = False
        '
        'PictureBox32
        '
        Me.PictureBox32.BackColor = System.Drawing.Color.Orange
        Me.PictureBox32.ErrorImage = Nothing
        Me.PictureBox32.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox32.InitialImage = Nothing
        Me.PictureBox32.Location = New System.Drawing.Point(742, 234)
        Me.PictureBox32.Name = "PictureBox32"
        Me.PictureBox32.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox32.TabIndex = 244
        Me.PictureBox32.TabStop = False
        '
        'PictureBox33
        '
        Me.PictureBox33.BackColor = System.Drawing.Color.Red
        Me.PictureBox33.ErrorImage = Nothing
        Me.PictureBox33.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox33.InitialImage = Nothing
        Me.PictureBox33.Location = New System.Drawing.Point(686, 234)
        Me.PictureBox33.Name = "PictureBox33"
        Me.PictureBox33.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox33.TabIndex = 243
        Me.PictureBox33.TabStop = False
        '
        'PictureBox34
        '
        Me.PictureBox34.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox34.ErrorImage = Nothing
        Me.PictureBox34.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox34.InitialImage = Nothing
        Me.PictureBox34.Location = New System.Drawing.Point(798, 178)
        Me.PictureBox34.Name = "PictureBox34"
        Me.PictureBox34.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox34.TabIndex = 242
        Me.PictureBox34.TabStop = False
        '
        'PictureBox35
        '
        Me.PictureBox35.BackColor = System.Drawing.Color.Blue
        Me.PictureBox35.ErrorImage = Nothing
        Me.PictureBox35.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox35.InitialImage = Nothing
        Me.PictureBox35.Location = New System.Drawing.Point(742, 178)
        Me.PictureBox35.Name = "PictureBox35"
        Me.PictureBox35.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox35.TabIndex = 241
        Me.PictureBox35.TabStop = False
        '
        'PictureBox36
        '
        Me.PictureBox36.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox36.ErrorImage = Nothing
        Me.PictureBox36.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox36.InitialImage = Nothing
        Me.PictureBox36.Location = New System.Drawing.Point(686, 178)
        Me.PictureBox36.Name = "PictureBox36"
        Me.PictureBox36.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox36.TabIndex = 240
        Me.PictureBox36.TabStop = False
        '
        'PictureBox19
        '
        Me.PictureBox19.BackColor = System.Drawing.Color.Green
        Me.PictureBox19.ErrorImage = Nothing
        Me.PictureBox19.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox19.InitialImage = Nothing
        Me.PictureBox19.Location = New System.Drawing.Point(630, 290)
        Me.PictureBox19.Name = "PictureBox19"
        Me.PictureBox19.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox19.TabIndex = 239
        Me.PictureBox19.TabStop = False
        '
        'PictureBox20
        '
        Me.PictureBox20.BackColor = System.Drawing.Color.Blue
        Me.PictureBox20.ErrorImage = Nothing
        Me.PictureBox20.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox20.InitialImage = Nothing
        Me.PictureBox20.Location = New System.Drawing.Point(574, 290)
        Me.PictureBox20.Name = "PictureBox20"
        Me.PictureBox20.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox20.TabIndex = 238
        Me.PictureBox20.TabStop = False
        '
        'PictureBox21
        '
        Me.PictureBox21.BackColor = System.Drawing.Color.Red
        Me.PictureBox21.ErrorImage = Nothing
        Me.PictureBox21.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox21.InitialImage = Nothing
        Me.PictureBox21.Location = New System.Drawing.Point(518, 290)
        Me.PictureBox21.Name = "PictureBox21"
        Me.PictureBox21.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox21.TabIndex = 237
        Me.PictureBox21.TabStop = False
        '
        'PictureBox22
        '
        Me.PictureBox22.BackColor = System.Drawing.Color.Green
        Me.PictureBox22.ErrorImage = Nothing
        Me.PictureBox22.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox22.InitialImage = Nothing
        Me.PictureBox22.Location = New System.Drawing.Point(630, 234)
        Me.PictureBox22.Name = "PictureBox22"
        Me.PictureBox22.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox22.TabIndex = 236
        Me.PictureBox22.TabStop = False
        '
        'PictureBox23
        '
        Me.PictureBox23.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox23.ErrorImage = Nothing
        Me.PictureBox23.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox23.InitialImage = Nothing
        Me.PictureBox23.Location = New System.Drawing.Point(574, 234)
        Me.PictureBox23.Name = "PictureBox23"
        Me.PictureBox23.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox23.TabIndex = 235
        Me.PictureBox23.TabStop = False
        '
        'PictureBox24
        '
        Me.PictureBox24.BackColor = System.Drawing.Color.Red
        Me.PictureBox24.ErrorImage = Nothing
        Me.PictureBox24.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox24.InitialImage = Nothing
        Me.PictureBox24.Location = New System.Drawing.Point(518, 234)
        Me.PictureBox24.Name = "PictureBox24"
        Me.PictureBox24.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox24.TabIndex = 234
        Me.PictureBox24.TabStop = False
        '
        'PictureBox25
        '
        Me.PictureBox25.BackColor = System.Drawing.Color.Blue
        Me.PictureBox25.ErrorImage = Nothing
        Me.PictureBox25.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox25.InitialImage = Nothing
        Me.PictureBox25.Location = New System.Drawing.Point(630, 178)
        Me.PictureBox25.Name = "PictureBox25"
        Me.PictureBox25.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox25.TabIndex = 233
        Me.PictureBox25.TabStop = False
        '
        'PictureBox26
        '
        Me.PictureBox26.BackColor = System.Drawing.Color.Orange
        Me.PictureBox26.ErrorImage = Nothing
        Me.PictureBox26.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox26.InitialImage = Nothing
        Me.PictureBox26.Location = New System.Drawing.Point(574, 178)
        Me.PictureBox26.Name = "PictureBox26"
        Me.PictureBox26.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox26.TabIndex = 232
        Me.PictureBox26.TabStop = False
        '
        'PictureBox27
        '
        Me.PictureBox27.BackColor = System.Drawing.Color.Orange
        Me.PictureBox27.ErrorImage = Nothing
        Me.PictureBox27.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox27.InitialImage = Nothing
        Me.PictureBox27.Location = New System.Drawing.Point(518, 178)
        Me.PictureBox27.Name = "PictureBox27"
        Me.PictureBox27.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox27.TabIndex = 231
        Me.PictureBox27.TabStop = False
        '
        'PictureBox10
        '
        Me.PictureBox10.BackColor = System.Drawing.Color.Green
        Me.PictureBox10.ErrorImage = Nothing
        Me.PictureBox10.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox10.InitialImage = Nothing
        Me.PictureBox10.Location = New System.Drawing.Point(686, 514)
        Me.PictureBox10.Name = "PictureBox10"
        Me.PictureBox10.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox10.TabIndex = 230
        Me.PictureBox10.TabStop = False
        '
        'PictureBox11
        '
        Me.PictureBox11.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox11.ErrorImage = Nothing
        Me.PictureBox11.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox11.InitialImage = Nothing
        Me.PictureBox11.Location = New System.Drawing.Point(742, 514)
        Me.PictureBox11.Name = "PictureBox11"
        Me.PictureBox11.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox11.TabIndex = 229
        Me.PictureBox11.TabStop = False
        '
        'PictureBox12
        '
        Me.PictureBox12.BackColor = System.Drawing.Color.Yellow
        Me.PictureBox12.ErrorImage = Nothing
        Me.PictureBox12.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox12.InitialImage = Nothing
        Me.PictureBox12.Location = New System.Drawing.Point(798, 514)
        Me.PictureBox12.Name = "PictureBox12"
        Me.PictureBox12.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox12.TabIndex = 228
        Me.PictureBox12.TabStop = False
        '
        'PictureBox13
        '
        Me.PictureBox13.BackColor = System.Drawing.Color.Yellow
        Me.PictureBox13.ErrorImage = Nothing
        Me.PictureBox13.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox13.InitialImage = Nothing
        Me.PictureBox13.Location = New System.Drawing.Point(686, 570)
        Me.PictureBox13.Name = "PictureBox13"
        Me.PictureBox13.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox13.TabIndex = 227
        Me.PictureBox13.TabStop = False
        '
        'PictureBox14
        '
        Me.PictureBox14.BackColor = System.Drawing.Color.Red
        Me.PictureBox14.ErrorImage = Nothing
        Me.PictureBox14.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox14.InitialImage = Nothing
        Me.PictureBox14.Location = New System.Drawing.Point(742, 570)
        Me.PictureBox14.Name = "PictureBox14"
        Me.PictureBox14.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox14.TabIndex = 226
        Me.PictureBox14.TabStop = False
        '
        'PictureBox15
        '
        Me.PictureBox15.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox15.ErrorImage = Nothing
        Me.PictureBox15.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox15.InitialImage = Nothing
        Me.PictureBox15.Location = New System.Drawing.Point(798, 570)
        Me.PictureBox15.Name = "PictureBox15"
        Me.PictureBox15.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox15.TabIndex = 225
        Me.PictureBox15.TabStop = False
        '
        'PictureBox16
        '
        Me.PictureBox16.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.PictureBox16.ErrorImage = Nothing
        Me.PictureBox16.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox16.InitialImage = Nothing
        Me.PictureBox16.Location = New System.Drawing.Point(686, 626)
        Me.PictureBox16.Name = "PictureBox16"
        Me.PictureBox16.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox16.TabIndex = 224
        Me.PictureBox16.TabStop = False
        '
        'PictureBox17
        '
        Me.PictureBox17.BackColor = System.Drawing.Color.Yellow
        Me.PictureBox17.ErrorImage = Nothing
        Me.PictureBox17.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox17.InitialImage = Nothing
        Me.PictureBox17.Location = New System.Drawing.Point(742, 626)
        Me.PictureBox17.Name = "PictureBox17"
        Me.PictureBox17.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox17.TabIndex = 223
        Me.PictureBox17.TabStop = False
        '
        'PictureBox18
        '
        Me.PictureBox18.BackColor = System.Drawing.Color.Green
        Me.PictureBox18.ErrorImage = Nothing
        Me.PictureBox18.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox18.InitialImage = Nothing
        Me.PictureBox18.Location = New System.Drawing.Point(798, 626)
        Me.PictureBox18.Name = "PictureBox18"
        Me.PictureBox18.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox18.TabIndex = 222
        Me.PictureBox18.TabStop = False
        '
        'PictureBox9
        '
        Me.PictureBox9.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PictureBox9.ErrorImage = Nothing
        Me.PictureBox9.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox9.InitialImage = Nothing
        Me.PictureBox9.Location = New System.Drawing.Point(406, 290)
        Me.PictureBox9.Name = "PictureBox9"
        Me.PictureBox9.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox9.TabIndex = 221
        Me.PictureBox9.TabStop = False
        '
        'PictureBox8
        '
        Me.PictureBox8.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PictureBox8.ErrorImage = Nothing
        Me.PictureBox8.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox8.InitialImage = Nothing
        Me.PictureBox8.Location = New System.Drawing.Point(350, 290)
        Me.PictureBox8.Name = "PictureBox8"
        Me.PictureBox8.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox8.TabIndex = 220
        Me.PictureBox8.TabStop = False
        '
        'PictureBox7
        '
        Me.PictureBox7.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PictureBox7.ErrorImage = Nothing
        Me.PictureBox7.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox7.InitialImage = Nothing
        Me.PictureBox7.Location = New System.Drawing.Point(294, 290)
        Me.PictureBox7.Name = "PictureBox7"
        Me.PictureBox7.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox7.TabIndex = 219
        Me.PictureBox7.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PictureBox6.ErrorImage = Nothing
        Me.PictureBox6.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox6.InitialImage = Nothing
        Me.PictureBox6.Location = New System.Drawing.Point(406, 234)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox6.TabIndex = 218
        Me.PictureBox6.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PictureBox5.ErrorImage = Nothing
        Me.PictureBox5.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox5.InitialImage = Nothing
        Me.PictureBox5.Location = New System.Drawing.Point(350, 234)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox5.TabIndex = 217
        Me.PictureBox5.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PictureBox4.ErrorImage = Nothing
        Me.PictureBox4.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox4.InitialImage = Nothing
        Me.PictureBox4.Location = New System.Drawing.Point(294, 234)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox4.TabIndex = 216
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PictureBox3.ErrorImage = Nothing
        Me.PictureBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox3.InitialImage = Nothing
        Me.PictureBox3.Location = New System.Drawing.Point(406, 178)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox3.TabIndex = 215
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PictureBox2.ErrorImage = Nothing
        Me.PictureBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox2.InitialImage = Nothing
        Me.PictureBox2.Location = New System.Drawing.Point(350, 178)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox2.TabIndex = 214
        Me.PictureBox2.TabStop = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.PictureBox1.ErrorImage = Nothing
        Me.PictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PictureBox1.InitialImage = Nothing
        Me.PictureBox1.Location = New System.Drawing.Point(294, 178)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(50, 50)
        Me.PictureBox1.TabIndex = 213
        Me.PictureBox1.TabStop = False
        '
        'ButtonInportF
        '
        Me.ButtonInportF.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonInportF.Location = New System.Drawing.Point(350, 402)
        Me.ButtonInportF.Name = "ButtonInportF"
        Me.ButtonInportF.Size = New System.Drawing.Size(50, 50)
        Me.ButtonInportF.TabIndex = 26
        Me.ButtonInportF.Text = "To F"
        Me.ButtonInportF.UseVisualStyleBackColor = True
        '
        'ComboBoxUSB
        '
        Me.ComboBoxUSB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxUSB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.ComboBoxUSB.FormattingEnabled = True
        Me.ComboBoxUSB.Location = New System.Drawing.Point(11, 10)
        Me.ComboBoxUSB.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxUSB.Name = "ComboBoxUSB"
        Me.ComboBoxUSB.Size = New System.Drawing.Size(89, 33)
        Me.ComboBoxUSB.TabIndex = 344
        '
        'ButtonConnectDisconnect
        '
        Me.ButtonConnectDisconnect.Cursor = System.Windows.Forms.Cursors.Default
        Me.ButtonConnectDisconnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!)
        Me.ButtonConnectDisconnect.ForeColor = System.Drawing.Color.Green
        Me.ButtonConnectDisconnect.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ButtonConnectDisconnect.Location = New System.Drawing.Point(107, 10)
        Me.ButtonConnectDisconnect.Name = "ButtonConnectDisconnect"
        Me.ButtonConnectDisconnect.Size = New System.Drawing.Size(122, 50)
        Me.ButtonConnectDisconnect.TabIndex = 345
        Me.ButtonConnectDisconnect.Text = "Connect"
        Me.ButtonConnectDisconnect.UseVisualStyleBackColor = True
        '
        'Rubiks_Cube_Solver
        '
        Me.AccessibleDescription = ""
        Me.AccessibleName = ""
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.CancelButton = Me.ButtonClose
        Me.ClientSize = New System.Drawing.Size(1266, 686)
        Me.Controls.Add(Me.ComboBoxUSB)
        Me.Controls.Add(Me.ButtonConnectDisconnect)
        Me.Controls.Add(Me.LabelUitleg7)
        Me.Controls.Add(Me.LabelErrors)
        Me.Controls.Add(Me.ButtonSend)
        Me.Controls.Add(Me.ButtonTest3)
        Me.Controls.Add(Me.ButtonTest2)
        Me.Controls.Add(Me.LabelUitleg5)
        Me.Controls.Add(Me.LabelUitleg4)
        Me.Controls.Add(Me.LabelUitleg2)
        Me.Controls.Add(Me.LabelUitleg3)
        Me.Controls.Add(Me.LabelUitleg1)
        Me.Controls.Add(Me.ComboBox9)
        Me.Controls.Add(Me.ComboBox8)
        Me.Controls.Add(Me.ComboBox7)
        Me.Controls.Add(Me.ComboBox6)
        Me.Controls.Add(Me.ComboBox5)
        Me.Controls.Add(Me.ComboBox4)
        Me.Controls.Add(Me.ComboBox3)
        Me.Controls.Add(Me.ComboBox2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.ButtonSuperFlip)
        Me.Controls.Add(Me.LabelTimer)
        Me.Controls.Add(Me.ButtonReset)
        Me.Controls.Add(Me.LabelArduinoSteps)
        Me.Controls.Add(Me.ButtonClose)
        Me.Controls.Add(Me.ButtonStartStop)
        Me.Controls.Add(Me.LabelStep9)
        Me.Controls.Add(Me.LabelStep8)
        Me.Controls.Add(Me.LabelStep7)
        Me.Controls.Add(Me.ButtonArduino)
        Me.Controls.Add(Me.LabelStep6)
        Me.Controls.Add(Me.LabelStep5)
        Me.Controls.Add(Me.LabelStep4)
        Me.Controls.Add(Me.LabelStep3)
        Me.Controls.Add(Me.LabelStep2)
        Me.Controls.Add(Me.LabelStep1)
        Me.Controls.Add(Me.RichTextBoxOutput)
        Me.Controls.Add(Me.TextBoxInput)
        Me.Controls.Add(Me.LabelSteps)
        Me.Controls.Add(Me.ButtonSpam)
        Me.Controls.Add(Me.LabelToDo30)
        Me.Controls.Add(Me.LabelToDo29)
        Me.Controls.Add(Me.LabelToDo28)
        Me.Controls.Add(Me.LabelToDo27)
        Me.Controls.Add(Me.LabelToDo26)
        Me.Controls.Add(Me.LabelToDo25)
        Me.Controls.Add(Me.LabelToDo24)
        Me.Controls.Add(Me.LabelToDo23)
        Me.Controls.Add(Me.LabelToDo22)
        Me.Controls.Add(Me.LabelToDo21)
        Me.Controls.Add(Me.LabelToDo20)
        Me.Controls.Add(Me.LabelToDo19)
        Me.Controls.Add(Me.LabelToDo18)
        Me.Controls.Add(Me.LabelToDo16)
        Me.Controls.Add(Me.LabelToDo17)
        Me.Controls.Add(Me.LabelToDo15)
        Me.Controls.Add(Me.LabelToDo14)
        Me.Controls.Add(Me.LabelToDo13)
        Me.Controls.Add(Me.LabelToDo12)
        Me.Controls.Add(Me.LabelToDo11)
        Me.Controls.Add(Me.LabelToDo10)
        Me.Controls.Add(Me.LabelToDo9)
        Me.Controls.Add(Me.LabelToDo8)
        Me.Controls.Add(Me.LabelToDo7)
        Me.Controls.Add(Me.LabelToDo6)
        Me.Controls.Add(Me.LabelToDo5)
        Me.Controls.Add(Me.LabelToDo4)
        Me.Controls.Add(Me.LabelToDo3)
        Me.Controls.Add(Me.LabelToDo2)
        Me.Controls.Add(Me.LabelToDo1)
        Me.Controls.Add(Me.ButtonTest1)
        Me.Controls.Add(Me.PictureBoxRememberColor)
        Me.Controls.Add(Me.ButtonInportD)
        Me.Controls.Add(Me.ButtonInportU)
        Me.Controls.Add(Me.ButtonInportR)
        Me.Controls.Add(Me.ButtonInportL)
        Me.Controls.Add(Me.ButtonInportB)
        Me.Controls.Add(Me.PictureBox55)
        Me.Controls.Add(Me.PictureBox56)
        Me.Controls.Add(Me.PictureBox57)
        Me.Controls.Add(Me.PictureBox58)
        Me.Controls.Add(Me.PictureBox59)
        Me.Controls.Add(Me.PictureBox60)
        Me.Controls.Add(Me.PictureBox61)
        Me.Controls.Add(Me.PictureBox62)
        Me.Controls.Add(Me.PictureBox63)
        Me.Controls.Add(Me.PictureBox46)
        Me.Controls.Add(Me.PictureBox47)
        Me.Controls.Add(Me.PictureBox48)
        Me.Controls.Add(Me.PictureBox49)
        Me.Controls.Add(Me.PictureBox50)
        Me.Controls.Add(Me.PictureBox51)
        Me.Controls.Add(Me.PictureBox52)
        Me.Controls.Add(Me.PictureBox53)
        Me.Controls.Add(Me.PictureBox54)
        Me.Controls.Add(Me.PictureBox37)
        Me.Controls.Add(Me.PictureBox38)
        Me.Controls.Add(Me.PictureBox39)
        Me.Controls.Add(Me.PictureBox40)
        Me.Controls.Add(Me.PictureBox41)
        Me.Controls.Add(Me.PictureBox42)
        Me.Controls.Add(Me.PictureBox43)
        Me.Controls.Add(Me.PictureBox44)
        Me.Controls.Add(Me.PictureBox45)
        Me.Controls.Add(Me.PictureBox28)
        Me.Controls.Add(Me.PictureBox29)
        Me.Controls.Add(Me.PictureBox30)
        Me.Controls.Add(Me.PictureBox31)
        Me.Controls.Add(Me.PictureBox32)
        Me.Controls.Add(Me.PictureBox33)
        Me.Controls.Add(Me.PictureBox34)
        Me.Controls.Add(Me.PictureBox35)
        Me.Controls.Add(Me.PictureBox36)
        Me.Controls.Add(Me.PictureBox19)
        Me.Controls.Add(Me.PictureBox20)
        Me.Controls.Add(Me.PictureBox21)
        Me.Controls.Add(Me.PictureBox22)
        Me.Controls.Add(Me.PictureBox23)
        Me.Controls.Add(Me.PictureBox24)
        Me.Controls.Add(Me.PictureBox25)
        Me.Controls.Add(Me.PictureBox26)
        Me.Controls.Add(Me.PictureBox27)
        Me.Controls.Add(Me.PictureBox10)
        Me.Controls.Add(Me.PictureBox11)
        Me.Controls.Add(Me.PictureBox12)
        Me.Controls.Add(Me.PictureBox13)
        Me.Controls.Add(Me.PictureBox14)
        Me.Controls.Add(Me.PictureBox15)
        Me.Controls.Add(Me.PictureBox16)
        Me.Controls.Add(Me.PictureBox17)
        Me.Controls.Add(Me.PictureBox18)
        Me.Controls.Add(Me.PictureBox9)
        Me.Controls.Add(Me.PictureBox8)
        Me.Controls.Add(Me.PictureBox7)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ButtonInportF)
        Me.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Rubiks_Cube_Solver"
        Me.Text = "[J] Rubiks Cube Solver"
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        CType(Me.PictureBoxRememberColor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox55, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox56, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox57, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox58, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox59, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox60, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox61, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox62, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox63, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox54, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox45, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox19, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents LabelUitleg7 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents LabelErrors As System.Windows.Forms.Label
    Friend WithEvents ButtonSend As System.Windows.Forms.Button
    Friend WithEvents ButtonTest3 As System.Windows.Forms.Button
    Friend WithEvents ButtonTest2 As System.Windows.Forms.Button
    Friend WithEvents LabelUitleg5 As System.Windows.Forms.Label
    Friend WithEvents LabelUitleg4 As System.Windows.Forms.Label
    Friend WithEvents LabelUitleg2 As System.Windows.Forms.Label
    Friend WithEvents LabelUitleg3 As System.Windows.Forms.Label
    Friend WithEvents LabelUitleg1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox8 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonSuperFlip As System.Windows.Forms.Button
    Friend WithEvents LabelTimer As System.Windows.Forms.Label
    Friend WithEvents ButtonReset As System.Windows.Forms.Button
    Friend WithEvents LabelArduinoSteps As System.Windows.Forms.Label
    Friend WithEvents ButtonClose As System.Windows.Forms.Button
    Friend WithEvents ButtonStartStop As System.Windows.Forms.Button
    Friend WithEvents LabelStep9 As System.Windows.Forms.Label
    Friend WithEvents LabelStep8 As System.Windows.Forms.Label
    Friend WithEvents LabelStep7 As System.Windows.Forms.Label
    Friend WithEvents ButtonArduino As System.Windows.Forms.Button
    Friend WithEvents LabelStep6 As System.Windows.Forms.Label
    Friend WithEvents LabelStep5 As System.Windows.Forms.Label
    Friend WithEvents LabelStep4 As System.Windows.Forms.Label
    Friend WithEvents LabelStep3 As System.Windows.Forms.Label
    Friend WithEvents LabelStep2 As System.Windows.Forms.Label
    Friend WithEvents LabelStep1 As System.Windows.Forms.Label
    Friend WithEvents RichTextBoxOutput As System.Windows.Forms.RichTextBox
    Friend WithEvents TextBoxInput As System.Windows.Forms.TextBox
    Friend WithEvents LabelSteps As System.Windows.Forms.Label
    Friend WithEvents ButtonSpam As System.Windows.Forms.Button
    Friend WithEvents LabelToDo30 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo29 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo28 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo27 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo26 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo25 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo24 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo23 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo22 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo21 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo20 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo19 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo18 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo16 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo17 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo15 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo14 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo13 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo12 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo11 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo10 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo9 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo8 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo7 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo6 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo5 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo4 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo3 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo2 As System.Windows.Forms.Label
    Friend WithEvents LabelToDo1 As System.Windows.Forms.Label
    Friend WithEvents ButtonTest1 As System.Windows.Forms.Button
    Friend WithEvents PictureBoxRememberColor As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonInportD As System.Windows.Forms.Button
    Friend WithEvents ButtonInportU As System.Windows.Forms.Button
    Friend WithEvents ButtonInportR As System.Windows.Forms.Button
    Friend WithEvents ButtonInportL As System.Windows.Forms.Button
    Friend WithEvents ButtonInportB As System.Windows.Forms.Button
    Friend WithEvents PictureBox55 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox56 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox57 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox58 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox59 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox60 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox61 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox62 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox63 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox46 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox47 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox48 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox49 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox50 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox51 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox52 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox53 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox54 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox37 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox38 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox39 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox40 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox41 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox42 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox43 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox44 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox45 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox28 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox29 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox30 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox31 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox32 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox33 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox34 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox35 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox36 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox19 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox20 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox21 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox22 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox23 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox24 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox25 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox26 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox27 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox18 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox4 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonInportF As System.Windows.Forms.Button
    Friend WithEvents ComboBoxUSB As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonConnectDisconnect As System.Windows.Forms.Button

End Class
