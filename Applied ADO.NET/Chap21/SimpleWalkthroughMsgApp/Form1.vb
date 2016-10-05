Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents MessageQueue1 As System.Messaging.MessageQueue
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents SendMsgBtn As System.Windows.Forms.Button
  Friend WithEvents RecMsgBtn As System.Windows.Forms.Button
  Friend WithEvents titleTextBox As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents bodyTextBox As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents rc2RadioBtn As System.Windows.Forms.RadioButton
  Friend WithEvents rc4RadioBtn As System.Windows.Forms.RadioButton
  Friend WithEvents EncrptedMsgBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MessageQueue1 = New System.Messaging.MessageQueue()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.titleTextBox = New System.Windows.Forms.TextBox()
    Me.SendMsgBtn = New System.Windows.Forms.Button()
    Me.RecMsgBtn = New System.Windows.Forms.Button()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.bodyTextBox = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.rc2RadioBtn = New System.Windows.Forms.RadioButton()
    Me.rc4RadioBtn = New System.Windows.Forms.RadioButton()
    Me.EncrptedMsgBtn = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.SuspendLayout()
    '
    'MessageQueue1
    '
    Me.MessageQueue1.Path = "mcb\Private$\mcbQ"
    Me.MessageQueue1.SynchronizingObject = Me
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 208)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(432, 232)
    Me.DataGrid1.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(64, 24)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Title:"
    '
    'titleTextBox
    '
    Me.titleTextBox.Location = New System.Drawing.Point(128, 8)
    Me.titleTextBox.Name = "titleTextBox"
    Me.titleTextBox.Size = New System.Drawing.Size(312, 20)
    Me.titleTextBox.TabIndex = 2
    Me.titleTextBox.Text = ""
    '
    'SendMsgBtn
    '
    Me.SendMsgBtn.Location = New System.Drawing.Point(16, 160)
    Me.SendMsgBtn.Name = "SendMsgBtn"
    Me.SendMsgBtn.Size = New System.Drawing.Size(120, 24)
    Me.SendMsgBtn.TabIndex = 4
    Me.SendMsgBtn.Text = "Send Message"
    '
    'RecMsgBtn
    '
    Me.RecMsgBtn.Location = New System.Drawing.Point(152, 160)
    Me.RecMsgBtn.Name = "RecMsgBtn"
    Me.RecMsgBtn.Size = New System.Drawing.Size(120, 24)
    Me.RecMsgBtn.TabIndex = 5
    Me.RecMsgBtn.Text = "Recieve Messages"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(8, 40)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(104, 24)
    Me.Label2.TabIndex = 6
    Me.Label2.Text = "Message Body:"
    '
    'bodyTextBox
    '
    Me.bodyTextBox.Location = New System.Drawing.Point(128, 40)
    Me.bodyTextBox.Multiline = True
    Me.bodyTextBox.Name = "bodyTextBox"
    Me.bodyTextBox.Size = New System.Drawing.Size(312, 48)
    Me.bodyTextBox.TabIndex = 7
    Me.bodyTextBox.Text = ""
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.rc4RadioBtn, Me.rc2RadioBtn})
    Me.GroupBox1.Location = New System.Drawing.Point(128, 96)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(168, 48)
    Me.GroupBox1.TabIndex = 8
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Encryption"
    '
    'rc2RadioBtn
    '
    Me.rc2RadioBtn.Location = New System.Drawing.Point(8, 16)
    Me.rc2RadioBtn.Name = "rc2RadioBtn"
    Me.rc2RadioBtn.Size = New System.Drawing.Size(88, 24)
    Me.rc2RadioBtn.TabIndex = 0
    Me.rc2RadioBtn.Text = "RC2"
    '
    'rc4RadioBtn
    '
    Me.rc4RadioBtn.Location = New System.Drawing.Point(80, 16)
    Me.rc4RadioBtn.Name = "rc4RadioBtn"
    Me.rc4RadioBtn.Size = New System.Drawing.Size(72, 24)
    Me.rc4RadioBtn.TabIndex = 1
    Me.rc4RadioBtn.Text = "RC4"
    '
    'EncrptedMsgBtn
    '
    Me.EncrptedMsgBtn.Location = New System.Drawing.Point(304, 104)
    Me.EncrptedMsgBtn.Name = "EncrptedMsgBtn"
    Me.EncrptedMsgBtn.Size = New System.Drawing.Size(144, 32)
    Me.EncrptedMsgBtn.TabIndex = 9
    Me.EncrptedMsgBtn.Text = "Send Encrypted Message"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(456, 453)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.EncrptedMsgBtn, Me.GroupBox1, Me.bodyTextBox, Me.Label2, Me.RecMsgBtn, Me.SendMsgBtn, Me.titleTextBox, Me.Label1, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Simple Messaging Application"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub SendMsgBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles SendMsgBtn.Click
    Dim msg As System.Messaging.Message = _
       New System.Messaging.Message(titleTextBox.Text)
    msg.Label = titleTextBox.Text
    msg.Body = bodyTextBox.Text
    MessageQueue1.Send(msg)
  End Sub

  Private Sub RecMsgBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles RecMsgBtn.Click
    ' Create a DataTable in memory
    Dim dtTable As New DataTable()
    dtTable.Columns.Add("Title")
    dtTable.Columns.Add("Message Body")
    Dim messages() As System.Messaging.Message
    messages = MessageQueue1.GetAllMessages()
    ' Need a formatter to get the text of the message body.
    Dim stringFormatter As System.Messaging.XmlMessageFormatter = _
       New System.Messaging.XmlMessageFormatter(New String() _
       {"System.String"})
    Dim index As Integer
    Dim msg As System.Messaging.Message

    For index = 0 To messages.Length - 1
      messages(index).Formatter = stringFormatter
      msg = messages(index)
      Dim row As DataRow = dtTable.NewRow()
      row(0) = msg.Label
      row(1) = msg.Body.ToString()
      dtTable.Rows.Add(row)
    Next
    DataGrid1.DataSource = dtTable
  End Sub

  Private Sub GetEnumBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    ' Create a DataTable in memory
    Dim dtTable As New DataTable()
    dtTable.Columns.Add("Title")
    dtTable.Columns.Add("Message Body")
    Dim messages() As System.Messaging.Message
    messages = MessageQueue1.GetAllMessages()
    ' Need a formatter to get the text of the message body.
    Dim stringFormatter As System.Messaging.XmlMessageFormatter = _
       New System.Messaging.XmlMessageFormatter(New String() _
       {"System.String"})
    Dim index As Integer
    Dim msg As System.Messaging.Message

    For index = 0 To messages.Length - 1
      messages(index).Formatter = stringFormatter
      msg = messages(index)
      Dim row As DataRow = dtTable.NewRow()
      row(0) = msg.Label
      row(1) = msg.Body.ToString()
      dtTable.Rows.Add(row)
    Next
    DataGrid1.DataSource = dtTable
  End Sub

  Private Sub EncrptedMsgBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles EncrptedMsgBtn.Click

    Try
      Dim msg As System.Messaging.Message = _
        New System.Messaging.Message(titleTextBox.Text)
      MessageQueue1.EncryptionRequired = _
      Messaging.EncryptionRequired.Body
      msg.UseEncryption = True
      If (rc4RadioBtn.Checked) Then
        msg.EncryptionAlgorithm = Messaging.EncryptionAlgorithm.Rc4
      ElseIf (rc2RadioBtn.Checked) Then
        msg.EncryptionAlgorithm = Messaging.EncryptionAlgorithm.Rc2
      Else
        msg.EncryptionAlgorithm = Messaging.EncryptionAlgorithm.None
      End If

      msg.Label = titleTextBox.Text
      msg.Body = bodyTextBox.Text
      MessageQueue1.Send(msg)
    Catch exp As Exception
      MessageBox.Show(exp.Message)
    End Try

  End Sub
End Class


