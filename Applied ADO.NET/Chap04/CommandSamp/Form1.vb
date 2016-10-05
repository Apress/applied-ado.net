Imports System.Data
Imports System.Data.SqlClient


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
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents Properties As System.Windows.Forms.MenuItem
  Friend WithEvents Constructors As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.Properties = New System.Windows.Forms.MenuItem()
    Me.Constructors = New System.Windows.Forms.MenuItem()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Properties, Me.Constructors})
    Me.MenuItem1.Text = "Command"
    '
    'Properties
    '
    Me.Properties.Index = 0
    Me.Properties.Text = "SqlCommand Propeties"
    '
    'Constructors
    '
    Me.Constructors.Index = 1
    Me.Constructors.Text = "Constructor"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 273)
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "Form1"

  End Sub

#End Region

  Private Sub Properties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Properties.Click
    ' Connection and SQL strings
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
             "Initial Catalog=Northwind;Data Source=MCB;"
    Dim SQL As String = "SELECT * FROM Orders"
    ' Create connection object
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Create command object
    Dim cmd As SqlCommand = New SqlCommand()
    cmd.Connection = conn
    cmd.CommandText = SQL
    cmd.CommandTimeout = 30
    cmd.CommandType = CommandType.Text
    ' Open connection
    conn.Open()
    ' Read Command properties
    Dim str As String
    str = "Connection String: " + cmd.Connection.ConnectionString.ToString()
    str = str + " , SQL Statement :" + cmd.CommandText
    str = str + " , Timeout :" + cmd.CommandTimeout.ToString()
    str = str + " , CommandTyoe:" + cmd.CommandType.ToString()
    MessageBox.Show(str)
    ' close connection
    conn.Close()
    'Dispose
    conn.Dispose()
  End Sub

  Private Sub Constructors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Constructors.Click

    ' Connection and SQL strings
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
             "Initial Catalog=Northwind;Data Source=MCB;"
    ' Create connection object
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)

    Dim SQL As String = "SELECT * FROM Orders"
    ' Create command object
    Dim cmd1 As SqlCommand = New SqlCommand()
    cmd1.Connection = conn
    cmd1.CommandText = SQL
    cmd1.CommandTimeout = 30
    cmd1.CommandType = CommandType.Text

    Dim cmd2 As SqlCommand = New SqlCommand(SQL, conn)

    Dim cmd3 As SqlCommand = New SqlCommand(SQL)
    cmd3.Connection = conn


  End Sub
End Class
