Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common


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
  Friend WithEvents Constructors As System.Windows.Forms.MenuItem
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.Constructors = New System.Windows.Forms.MenuItem()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Constructors})
    Me.MenuItem1.Text = "SqlParameter"
    '
    'Constructors
    '
    Me.Constructors.Index = 0
    Me.Constructors.Text = "Construtors"
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(16, 16)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(264, 248)
    Me.DataGrid1.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1})
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Constructors_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles Constructors.Click
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
         "Initial Catalog=Northwind;Data Source=MCB;"
    ' Create connection object
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Create a SqlCommand with stored procedure as string
    Dim cmd As SqlCommand = New SqlCommand("Employees", conn)
    cmd.Connection = conn

    ' Create a SqlParameter and add a parameter
    Dim parm1 As SqlParameter = cmd.Parameters.Add("@FirstName", _
    SqlDbType.Text, 255)
    parm1.Value = "New Name"
    parm1.Direction = ParameterDirection.Input
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(cmd)
    Dim ds As DataSet = New DataSet()

    Try
      ' Open connection
      conn.Open()
      adapter.Fill(ds)
    Catch exp As SqlException
      exp.Message.ToString()
    End Try
    DataGrid1.DataSource = ds.DefaultViewManager

    ' release objects
    conn.Close()
    conn.Dispose()
  End Sub
End Class
