Imports System.Messaging

Public Class Form1
  Inherits System.Windows.Forms.Form

  Private currentQueue As MessageQueue = Nothing

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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
  Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents CreateQueueBtn As System.Windows.Forms.Button
  Friend WithEvents DeleteQueBtn As System.Windows.Forms.Button
  Friend WithEvents QuePropsBtn As System.Windows.Forms.Button
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.RadioButton2 = New System.Windows.Forms.RadioButton()
    Me.RadioButton1 = New System.Windows.Forms.RadioButton()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.RadioButton5 = New System.Windows.Forms.RadioButton()
    Me.RadioButton4 = New System.Windows.Forms.RadioButton()
    Me.RadioButton3 = New System.Windows.Forms.RadioButton()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.CreateQueueBtn = New System.Windows.Forms.Button()
    Me.DeleteQueBtn = New System.Windows.Forms.Button()
    Me.QuePropsBtn = New System.Windows.Forms.Button()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(8, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(112, 24)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "New Queue Name:"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(136, 8)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(152, 20)
    Me.TextBox1.TabIndex = 1
    Me.TextBox1.Text = "TextBox1"
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.RadioButton2, Me.RadioButton1})
    Me.GroupBox1.Location = New System.Drawing.Point(8, 48)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(152, 88)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Queue Type"
    '
    'RadioButton2
    '
    Me.RadioButton2.Location = New System.Drawing.Point(8, 48)
    Me.RadioButton2.Name = "RadioButton2"
    Me.RadioButton2.Size = New System.Drawing.Size(112, 24)
    Me.RadioButton2.TabIndex = 1
    Me.RadioButton2.Text = "Public Queue"
    '
    'RadioButton1
    '
    Me.RadioButton1.Checked = True
    Me.RadioButton1.Location = New System.Drawing.Point(8, 24)
    Me.RadioButton1.Name = "RadioButton1"
    Me.RadioButton1.Size = New System.Drawing.Size(112, 16)
    Me.RadioButton1.TabIndex = 0
    Me.RadioButton1.TabStop = True
    Me.RadioButton1.Text = "Private Queue"
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.RadioButton5, Me.RadioButton4, Me.RadioButton3})
    Me.GroupBox2.Location = New System.Drawing.Point(168, 48)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(144, 96)
    Me.GroupBox2.TabIndex = 3
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Queue Priority"
    '
    'RadioButton5
    '
    Me.RadioButton5.Location = New System.Drawing.Point(16, 72)
    Me.RadioButton5.Name = "RadioButton5"
    Me.RadioButton5.Size = New System.Drawing.Size(112, 16)
    Me.RadioButton5.TabIndex = 2
    Me.RadioButton5.Text = "Low"
    '
    'RadioButton4
    '
    Me.RadioButton4.Location = New System.Drawing.Point(16, 40)
    Me.RadioButton4.Name = "RadioButton4"
    Me.RadioButton4.Size = New System.Drawing.Size(112, 32)
    Me.RadioButton4.TabIndex = 1
    Me.RadioButton4.Text = "High"
    '
    'RadioButton3
    '
    Me.RadioButton3.Checked = True
    Me.RadioButton3.Location = New System.Drawing.Point(16, 24)
    Me.RadioButton3.Name = "RadioButton3"
    Me.RadioButton3.Size = New System.Drawing.Size(112, 24)
    Me.RadioButton3.TabIndex = 0
    Me.RadioButton3.TabStop = True
    Me.RadioButton3.Text = "Normal"
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(16, 176)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(216, 173)
    Me.ListBox1.TabIndex = 4
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(16, 152)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(136, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "Available Queues:"
    '
    'CreateQueueBtn
    '
    Me.CreateQueueBtn.Location = New System.Drawing.Point(256, 176)
    Me.CreateQueueBtn.Name = "CreateQueueBtn"
    Me.CreateQueueBtn.Size = New System.Drawing.Size(120, 32)
    Me.CreateQueueBtn.TabIndex = 6
    Me.CreateQueueBtn.Text = "Create Queue"
    '
    'DeleteQueBtn
    '
    Me.DeleteQueBtn.Location = New System.Drawing.Point(392, 320)
    Me.DeleteQueBtn.Name = "DeleteQueBtn"
    Me.DeleteQueBtn.Size = New System.Drawing.Size(120, 32)
    Me.DeleteQueBtn.TabIndex = 7
    Me.DeleteQueBtn.Text = "Delete Queue"
    '
    'QuePropsBtn
    '
    Me.QuePropsBtn.Location = New System.Drawing.Point(256, 216)
    Me.QuePropsBtn.Name = "QuePropsBtn"
    Me.QuePropsBtn.Size = New System.Drawing.Size(120, 32)
    Me.QuePropsBtn.TabIndex = 8
    Me.QuePropsBtn.Text = "Queue Properties"
    '
    'CheckBox1
    '
    Me.CheckBox1.Location = New System.Drawing.Point(336, 8)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(128, 24)
    Me.CheckBox1.TabIndex = 10
    Me.CheckBox1.Text = "Transactional"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(248, 328)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(136, 20)
    Me.TextBox2.TabIndex = 11
    Me.TextBox2.Text = ""
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(528, 373)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox2, Me.CheckBox1, Me.QuePropsBtn, Me.DeleteQueBtn, Me.CreateQueueBtn, Me.Label2, Me.ListBox1, Me.GroupBox2, Me.GroupBox1, Me.TextBox1, Me.Label1})
    Me.Name = "Form1"
    Me.Text = "Message Queue Manager"
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub CreateQueueBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CreateQueueBtn.Click
    Dim str As String = String.Empty
    Dim trn As Boolean = False
    ' If transactional type is true
    If CheckBox1.Checked Then
      trn = True
    End If
    ' If queue is private
    If RadioButton1.Checked Then
      str = ".\Private$\"
    End If
    str += TextBox1.Text
    If Not MessageQueue.Exists(str) Then
      currentQueue = MessageQueue.Create(str, trn)
      If currentQueue Is Nothing Then
        ' Set priority
        If RadioButton4.Checked Then
          currentQueue.BasePriority = _
          Convert.ToInt16(MessagePriority.High)
        ElseIf RadioButton5.Checked Then
          currentQueue.BasePriority = _
          Convert.ToInt16(MessagePriority.Low)
        Else
          currentQueue.BasePriority = 0
        End If
        ListBox1.Items.Add(TextBox1.Text)
        ListBox1.Update()
      End If
    End If
  End Sub

  Private Sub DeleteQueBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles DeleteQueBtn.Click
    Dim str As String = String.Empty
    ' If queue is private
    If RadioButton1.Checked Then
      str = ".\Private$\"
    End If
    str += TextBox2.Text
    ' Create and connect to a public Message Queuing queue.
    If MessageQueue.Exists(str) Then
      MessageQueue.Delete(str)
    End If
  End Sub

  Private Sub QuePropsBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles QuePropsBtn.Click
    Dim props As String = "Format Name: " + currentQueue.FormatName
    props += ", Base Priority:" + currentQueue.BasePriority.ToString()
    props += ", Create Time:" + currentQueue.CreateTime.ToString()
    props += ", ID:" + currentQueue.Id.ToString()
    props += ", Path:" + currentQueue.Path.ToString()
    props += ", Max Size:" + currentQueue.MaximumQueueSize.ToString()
    props += ", Transaction:" + currentQueue.Transactional.ToString()
    MessageBox.Show(props)
  End Sub

  Private Sub RefreshListBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    GetPrivateQueues()
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    GetPrivateQueues()
  End Sub

  Private Sub GetPublicQueues()
    Dim allQues() As MessageQueue
    Dim i As Integer
    allQues = MessageQueue.GetPublicQueuesByMachine(".")
    ListBox1.Items.Clear()
    For i = 0 To allQues.Length - 1
      ListBox1.Items.Add(allQues(i).Label)
    Next
  End Sub

  Private Sub GetPrivateQueues()
    Dim allQues() As MessageQueue
    Dim i As Integer
    ' Get all queues in an array
    allQues = MessageQueue.GetPrivateQueuesByMachine(".")
    Me.ListBox1.Items.Clear()
    ' Read and add all queues to the list
    For i = 0 To allQues.Length - 1
      ListBox1.Items.Add(allQues(i).Label)
    Next

    ' Other way to get all queues
    Dim mqEnum As MessageQueueEnumerator
    mqEnum = MessageQueue.GetMessageQueueEnumerator()
  End Sub


End Class
