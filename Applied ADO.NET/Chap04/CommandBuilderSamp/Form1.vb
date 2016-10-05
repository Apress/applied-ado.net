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
  Friend WithEvents Constructors As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.Constructors = New System.Windows.Forms.MenuItem()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Constructors})
    Me.MenuItem1.Text = "CommandBuilder"
    '
    'Constructors
    '
    Me.Constructors.Index = 0
    Me.Constructors.Text = "Constructors"
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

  Private Sub Constructors_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Constructors.Click
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
         "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim SQL As String = "SELECT * FROM Employees"
    ' open a connection
    conn.Open()
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(SQL, conn)
    Dim builder1 As SqlCommandBuilder = New SqlCommandBuilder()
    builder1.DataAdapter = adapter
    Dim builder2 As SqlCommandBuilder = _
    New SqlCommandBuilder(adapter)

    ' Create a command builder object
    Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)
    ' Create a dataset object
    Dim ds As DataSet = New DataSet("EmployeeSet")
    adapter.Fill(ds, "Employees")
    ' Create a data table object and add a new row
    Dim EmployeeTable As DataTable = ds.Tables("Employees")
    Dim row As DataRow = EmployeeTable.NewRow()
    row("FirstName") = "Rodney"
    row("LastName") = "DangerField"
    row("Title") = "Manager"
    EmployeeTable.Rows.Add(row)
    ' Update data adapter
    adapter.Update(ds, "Employees")
    ' Dispose
    conn.Close()
    conn.Dispose()
  End Sub
End Class
