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
  Friend WithEvents OpenDB As System.Windows.Forms.MenuItem
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  Friend WithEvents MultipleTables As System.Windows.Forms.MenuItem
  Friend WithEvents MergeDataTable As System.Windows.Forms.MenuItem
  Friend WithEvents AcceptRejectMenu As System.Windows.Forms.MenuItem
  Friend WithEvents SaveChangedDataMenu As System.Windows.Forms.MenuItem
  Friend WithEvents MultipleDBControls As System.Windows.Forms.MenuItem
  Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
  Friend WithEvents AddUpdateDeleteMenu As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.OpenDB = New System.Windows.Forms.MenuItem()
    Me.MenuItem2 = New System.Windows.Forms.MenuItem()
    Me.MultipleTables = New System.Windows.Forms.MenuItem()
    Me.MergeDataTable = New System.Windows.Forms.MenuItem()
    Me.AcceptRejectMenu = New System.Windows.Forms.MenuItem()
    Me.SaveChangedDataMenu = New System.Windows.Forms.MenuItem()
    Me.MultipleDBControls = New System.Windows.Forms.MenuItem()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.DataGrid2 = New System.Windows.Forms.DataGrid()
    Me.AddUpdateDeleteMenu = New System.Windows.Forms.MenuItem()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.OpenDB})
    Me.MenuItem1.Text = "File"
    '
    'OpenDB
    '
    Me.OpenDB.Index = 0
    Me.OpenDB.Text = "Open Database"
    '
    'MenuItem2
    '
    Me.MenuItem2.Index = 1
    Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MultipleTables, Me.MergeDataTable, Me.AcceptRejectMenu, Me.SaveChangedDataMenu, Me.MultipleDBControls, Me.AddUpdateDeleteMenu})
    Me.MenuItem2.Text = "DataSet"
    '
    'MultipleTables
    '
    Me.MultipleTables.Index = 0
    Me.MultipleTables.Text = "Multiple Tables"
    '
    'MergeDataTable
    '
    Me.MergeDataTable.Index = 1
    Me.MergeDataTable.Text = "Merge DataSet"
    '
    'AcceptRejectMenu
    '
    Me.AcceptRejectMenu.Index = 2
    Me.AcceptRejectMenu.Text = "Accept Rejecting Changes"
    '
    'SaveChangedDataMenu
    '
    Me.SaveChangedDataMenu.Index = 3
    Me.SaveChangedDataMenu.Text = "Save Changed Data Only"
    '
    'MultipleDBControls
    '
    Me.MultipleDBControls.Index = 4
    Me.MultipleDBControls.Text = "Multiple DB Controls"
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(32, 184)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(424, 200)
    Me.DataGrid1.TabIndex = 0
    '
    'DataGrid2
    '
    Me.DataGrid2.DataMember = ""
    Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid2.Location = New System.Drawing.Point(32, 8)
    Me.DataGrid2.Name = "DataGrid2"
    Me.DataGrid2.Size = New System.Drawing.Size(416, 152)
    Me.DataGrid2.TabIndex = 1
    '
    'AddUpdateDeleteMenu
    '
    Me.AddUpdateDeleteMenu.Index = 5
    Me.AddUpdateDeleteMenu.Text = "Add, Update and Delete Data"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(480, 393)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid2, Me.DataGrid1})
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub OpenDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenDB.Click
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim SQL As String = "SELECT Name FROM SysObjects WHERE Type='U'"
    conn.Open()
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(SQL, conn)

    Dim ds As DataSet = New DataSet("Tables")
    adapter.Fill(ds)
    DataGrid1.DataSource = ds.DefaultViewManager

    ' Dispose
    conn.Close()
    conn.Dispose()
  End Sub

  Private Sub MultipleTables_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MultipleTables.Click

    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    conn.Open()
    Dim adapter As SqlDataAdapter = New SqlDataAdapter()
    adapter.SelectCommand = New SqlCommand("SELECT * FROM Customers")
    adapter.SelectCommand.Connection = conn
    Dim ds1 As DataSet = New DataSet()
    adapter.Fill(ds1)
    adapter.SelectCommand = New SqlCommand("SELECT * FROM Orders")
    adapter.SelectCommand.Connection = conn
    Dim ds2 As DataSet = New DataSet()
    adapter.Fill(ds2)
    ds1.Merge(ds2, False, MissingSchemaAction.Add)
    DataGrid1.DataSource = ds1.DefaultViewManager
    ' Dispose
    conn.Close()
    conn.Dispose()
  End Sub

  Private Sub MergeDataTable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MergeDataTable.Click

  End Sub

  Private Sub AcceptRejectMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcceptRejectMenu.Click
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim SQL As String = "SELECT * FROM Employees"
    ' open a connection
    conn.Open()
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(SQL, conn)
    ' Create a command builder object
    Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)
    ' Create a dataset object
    Dim ds As DataSet = New DataSet()
    adapter.Fill(ds, "Employees")
    ' Create a data table object and add a new row
    Dim EmployeeTable As DataTable = ds.Tables("Employees")
    Dim row As DataRow = EmployeeTable.NewRow()
    row("FirstName") = "New Name"
    row("LastName") = "Mr. Last"
    row("Title") = "New Employee"
    EmployeeTable.Rows.Add(row)
    ' Update data adapter
    If MessageBox.Show("Do you want to save change?", "DataSet AcceptReject Methods", _
           MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
      ds.AcceptChanges()
    Else
      ds.RejectChanges()
    End If
    adapter.Update(ds, "Employees")

    DataGrid1.DataSource = ds.DefaultViewManager
    ' Dispose
    conn.Close()
    conn.Dispose()

  End Sub

  Private Sub MultipleDBControls_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MultipleDBControls.Click
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    conn.Open()
    Dim adapter1 As SqlDataAdapter = New SqlDataAdapter()
    Dim adapter2 As SqlDataAdapter = New SqlDataAdapter()
    adapter1.SelectCommand = New SqlCommand("SELECT * FROM Customers")
    adapter2.SelectCommand = New SqlCommand("SELECT * FROM Orders")
    adapter1.SelectCommand.Connection = conn
    adapter2.SelectCommand.Connection = conn
    Dim ds1 As DataSet = New DataSet()
    Dim ds2 As DataSet = New DataSet()
    adapter1.Fill(ds1)
    adapter2.Fill(ds2)
    DataGrid1.DataSource = ds1.DefaultViewManager
    DataGrid2.DataSource = ds2.DefaultViewManager
    ' Dispose
    conn.Close()
    conn.Dispose()
  End Sub

  Private Sub AddUpdateDeleteMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddUpdateDeleteMenu.Click
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim SQL As String = "SELECT * FROM Employees"
    ' open a connection
    conn.Open()
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(SQL, conn)
    ' Create a command builder object
    Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)
    ' Create a dataset object
    Dim ds As DataSet = New DataSet()
    adapter.Fill(ds, "Employees")
    ' Create a data table object and add a new row
    Dim EmployeeTable As DataTable = ds.Tables("Employees")
    Dim row As DataRow = EmployeeTable.NewRow()
    row("FirstName") = "New Name"
    row("LastName") = "Mr. Last"
    row("Title") = "New Employee"
    EmployeeTable.AcceptChanges()
    EmployeeTable.Rows.Add(row)
    ' Get the last row
    Dim editedRow As DataRow = EmployeeTable.Rows _
    (EmployeeTable.Rows.Count - 1)
    editedRow("FirstName") = "Edited Name"
    editedRow("LastName") = "Mr. Edited"
    editedRow("Title") = "Edited Employee"
    EmployeeTable.AcceptChanges()
    ' Delete a row. Last row - 1
    Dim deletedRow As DataRow = EmployeeTable.Rows _
    (EmployeeTable.Rows.Count - 2)
    deletedRow.Delete()
    EmployeeTable.AcceptChanges()
    ' Save changes to the database
    adapter.Update(ds, "Employees")
    ' View in DataGrid
    DataGrid1.DataSource = ds.DefaultViewManager
    ' Dispose
    conn.Close()
    conn.Dispose()
  End Sub

  Private Sub SaveChangedDataMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SaveChangedDataMenu.Click
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim SQL As String = "SELECT * FROM Employees"
    ' open a connection
    conn.Open()
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(SQL, conn)
    ' Create a command builder object
    Dim builder As SqlCommandBuilder = New SqlCommandBuilder(adapter)
    ' Create a dataset object
    Dim ds As DataSet = New DataSet()
    adapter.Fill(ds, "Employees")
    ' Create a data table object and add a new row
    Dim EmployeeTable As DataTable = ds.Tables("Employees")
    Dim row As DataRow = EmployeeTable.NewRow()
    row("FirstName") = "Changed Name"
    row("LastName") = "Mr. Changed"
    row("Title") = "Changed Employee"
    EmployeeTable.Rows.Add(row)

    ' See if DataSet has changes or not
    If Not ds.HasChanges(DataRowState.Modified) Then Exit Sub
    Dim tmpDtSet As DataSet
    ' GetChanges for modified rows only.
    tmpDtSet = ds.GetChanges(DataRowState.Modified)
    If tmpDtSet.HasErrors Then
      MessageBox.Show("DataSet has errors")
      Exit Sub
    End If
    adapter.Update(tmpDtSet)

    ' Fill data set again with changed data
    adapter.Fill(ds, "Employees")
    DataGrid1.DataSource = ds.DefaultViewManager
    ' Dispose
    conn.Close()
    conn.Dispose()

  End Sub
End Class
