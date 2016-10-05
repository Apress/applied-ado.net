Imports System
Imports System.Data
Imports System.Data.OracleClient

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
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.SuspendLayout()
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(16, 56)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(256, 199)
    Me.ListBox1.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    Dim connectionString As String = _
    "Data Source=ORCL;Integrated Security=yes"
    Dim conn As OracleConnection = New OracleConnection()
    conn.ConnectionString = connectionString
    Dim sql As String = "SELECT * FROM Tab"
    Dim cmd As OracleCommand = New OracleCommand(sql)
    conn.Open()
    Dim reader As OracleDataReader = cmd.ExecuteReader()
    While reader.Read()
      ListBox1.Items.Add(reader.GetString(0))
    End While
    reader.Close()
    conn.Close()
  End Sub
End Class



