Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb
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
  Friend WithEvents Cosntructor As System.Windows.Forms.MenuItem
  Friend WithEvents Properties As System.Windows.Forms.MenuItem
  Friend WithEvents OleDbDataAdapter As System.Windows.Forms.Button
  Friend WithEvents SqlDataAdapter As System.Windows.Forms.Button
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
  Friend WithEvents TableMapping As System.Windows.Forms.MenuItem
  Friend WithEvents ColumnMapping As System.Windows.Forms.MenuItem
  Friend WithEvents UpdateMethod As System.Windows.Forms.MenuItem
  Friend WithEvents OleDbUpate As System.Windows.Forms.MenuItem
  Friend WithEvents DataTableMapping1 As System.Windows.Forms.MenuItem
  Friend WithEvents DataTableMapping2 As System.Windows.Forms.MenuItem
  Friend WithEvents DataColumnMapping As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.Cosntructor = New System.Windows.Forms.MenuItem()
    Me.Properties = New System.Windows.Forms.MenuItem()
    Me.MenuItem2 = New System.Windows.Forms.MenuItem()
    Me.UpdateMethod = New System.Windows.Forms.MenuItem()
    Me.TableMapping = New System.Windows.Forms.MenuItem()
    Me.ColumnMapping = New System.Windows.Forms.MenuItem()
    Me.OleDbDataAdapter = New System.Windows.Forms.Button()
    Me.SqlDataAdapter = New System.Windows.Forms.Button()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.OleDbUpate = New System.Windows.Forms.MenuItem()
    Me.DataTableMapping1 = New System.Windows.Forms.MenuItem()
    Me.DataTableMapping2 = New System.Windows.Forms.MenuItem()
    Me.DataColumnMapping = New System.Windows.Forms.MenuItem()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.Cosntructor, Me.Properties})
    Me.MenuItem1.Text = "DataAdapter"
    '
    'Cosntructor
    '
    Me.Cosntructor.Index = 0
    Me.Cosntructor.Text = "Cosntructor"
    '
    'Properties
    '
    Me.Properties.Index = 1
    Me.Properties.Text = "Properties"
    '
    'MenuItem2
    '
    Me.MenuItem2.Index = 1
    Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.UpdateMethod, Me.TableMapping, Me.ColumnMapping, Me.OleDbUpate, Me.DataTableMapping1, Me.DataTableMapping2, Me.DataColumnMapping})
    Me.MenuItem2.Text = "Methods"
    '
    'UpdateMethod
    '
    Me.UpdateMethod.Index = 0
    Me.UpdateMethod.Text = "UpdateMethod"
    '
    'TableMapping
    '
    Me.TableMapping.Index = 1
    Me.TableMapping.Text = "TableMapping"
    '
    'ColumnMapping
    '
    Me.ColumnMapping.Index = 2
    Me.ColumnMapping.Text = "ColumnMapping"
    '
    'OleDbDataAdapter
    '
    Me.OleDbDataAdapter.Location = New System.Drawing.Point(16, 8)
    Me.OleDbDataAdapter.Name = "OleDbDataAdapter"
    Me.OleDbDataAdapter.Size = New System.Drawing.Size(152, 32)
    Me.OleDbDataAdapter.TabIndex = 0
    Me.OleDbDataAdapter.Text = "OleDbDataAdapter"
    '
    'SqlDataAdapter
    '
    Me.SqlDataAdapter.Location = New System.Drawing.Point(200, 8)
    Me.SqlDataAdapter.Name = "SqlDataAdapter"
    Me.SqlDataAdapter.Size = New System.Drawing.Size(144, 32)
    Me.SqlDataAdapter.TabIndex = 1
    Me.SqlDataAdapter.Text = "SqlDataAdapter"
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 56)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(344, 224)
    Me.DataGrid1.TabIndex = 2
    '
    'OleDbUpate
    '
    Me.OleDbUpate.Index = 3
    Me.OleDbUpate.Text = "Update - OleDb"
    '
    'DataTableMapping1
    '
    Me.DataTableMapping1.Index = 4
    Me.DataTableMapping1.Text = "DataTableMapping1"
    '
    'DataTableMapping2
    '
    Me.DataTableMapping2.Index = 5
    Me.DataTableMapping2.Text = "DataTableMapping2"
    '
    'DataColumnMapping
    '
    Me.DataColumnMapping.Index = 6
    Me.DataColumnMapping.Text = "DataColumnMapping"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(360, 285)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1, Me.SqlDataAdapter, Me.OleDbDataAdapter})
    Me.Menu = Me.MainMenu1
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Cosntructor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cosntructor.Click

    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
         "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim SQL As String = "SELECT * FROM Customers"
    ' open a connection
    conn.Open()
    Dim cmd As SqlCommand = New SqlCommand(SQL, conn)
    ' Creating SqlDataAdapter using different constructors
    Dim da1 As SqlDataAdapter = New SqlDataAdapter(cmd)
    Dim da2 As SqlDataAdapter = New SqlDataAdapter()
    da2.SelectCommand = cmd
    Dim da3 As SqlDataAdapter = New SqlDataAdapter(SQL, conn)
    Dim da4 As SqlDataAdapter = New SqlDataAdapter(SQL, ConnectionString)

    ' release objects
    conn.Close()
    conn.Dispose()
  End Sub

  Private Sub Properties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Properties.Click

    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
         "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim SQL As String = "SELECT * FROM Customers"
    ' Open the connection
    conn.Open()
    ' Create an OleDbDataAdapter object
    Dim adapter As SqlDataAdapter = New SqlDataAdapter()
    adapter.SelectCommand = New SqlCommand(SQL, conn)
    adapter.AcceptChangesDuringFill = True
    adapter.ContinueUpdateOnError = True
    adapter.MissingSchemaAction = MissingSchemaAction.Error
    adapter.MissingMappingAction = MissingMappingAction.Error

    ' Create DataSet Object 
    Dim ds As DataSet = New DataSet("Orders")
    ' Call DataAdapter's Fill method to fill data from the 
    ' DataAdapter to the DataSet 
    adapter.Fill(ds)
    ' Bind data set to a DataGrid control
    DataGrid1.DataSource = ds.DefaultViewManager

    ' release objects
    conn.Close()
    conn.Dispose()

  End Sub

  Private Sub OleDbDataAdapter_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles OleDbDataAdapter.Click
    ' Create a Connection Object
    Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    "Data Source=c:\\Northwind.mdb"
    Dim SQL As String = "SELECT * FROM Orders"
    Dim conn As OleDbConnection = New OleDbConnection(ConnectionString)
    ' Open the connection
    conn.Open()
    ' Create an OleDbDataAdapter object
    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter()
    adapter.SelectCommand = New OleDbCommand(SQL, conn)
    ' Create DataSet Object 
    Dim ds As DataSet = New DataSet("Orders")
    ' Call DataAdapter's Fill method to fill data from the 
    ' DataAdapter to the DataSet 
    adapter.Fill(ds)
    ' Bind data set to a DataGrid control
    DataGrid1.DataSource = ds.DefaultViewManager

    ' release objects
    conn.Close()
    conn.Dispose()

  End Sub

  Private Sub SqlDataAdapter_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles SqlDataAdapter.Click
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
         "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim SQL As String = "SELECT * FROM Customers"
    ' Open the connection
    conn.Open()
    ' Create an OleDbDataAdapter object
    Dim adapter As SqlDataAdapter = New SqlDataAdapter()
    adapter.SelectCommand = New SqlCommand(SQL, conn)
    ' Create DataSet Object 
    Dim ds As DataSet = New DataSet("Orders")
    ' Call DataAdapter's Fill method to fill data from the 
    ' DataAdapter to the DataSet 
    adapter.Fill(ds)
    ' Adding a DataTable to the DataSet
    Dim table As DataTable() = _
     adapter.FillSchema(ds, SchemaType.Mapped, "Categories")
    ' Bind data set to a DataGrid control
    DataGrid1.DataSource = ds.DefaultViewManager
    ' release objects
    conn.Close()
    conn.Dispose()

  End Sub

  Private Sub Update_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles UpdateMethod.Click

    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
         "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim adapter As SqlDataAdapter = New SqlDataAdapter()
    Dim workParam As SqlParameter = Nothing
    adapter.DeleteCommand = New SqlCommand( _
    "DELETE from Employees where EmployeeID = 10", conn)
    workParam = adapter.DeleteCommand.Parameters.Add( _
 "@EmployeeID", OleDbType.Integer)
    workParam.SourceColumn = "EmployeeID"
    workParam.SourceVersion = DataRowVersion.Original
    adapter.SelectCommand = New SqlCommand("SELECT * FROM Employees", conn)
    Dim ds As DataSet = New DataSet("EmployeeSet")
    adapter.Fill(ds, "Employees")
    Dim Dt As DataTable = ds.Tables("Employees")
    Dim lastRow As Integer = Dt.Rows.Count - 1
    Dim firstName As String = Dt.Rows(lastRow)("FirstName").ToString()
    Dim lastName As String = Dt.Rows(lastRow)("LastName").ToString()
    Dt.Rows(Dt.Rows.Count - 1).Delete()
    adapter.Update(ds, "Employees")
    DataGrid1.DataSource = ds.DefaultViewManager
    ' release objects
    conn.Close()
    conn.Dispose()

  End Sub

  Private Sub TableMapping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableMapping.Click

  End Sub

  Private Sub ColumnMapping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColumnMapping.Click

  End Sub

  Private Sub OleDbUpate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OleDbUpate.Click
    Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
            "Data Source=c:\\Northwind.mdb"
    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter()
    Dim conn As OleDbConnection = New OleDbConnection(ConnectionString)
    ' Create an OleDbParameter object
    Dim workParam As OleDbParameter = Nothing
    ' Set DeleteCommand property
    adapter.DeleteCommand = New OleDbCommand( _
    "DELETE from Employees where EmployeeID = 10", conn)
    ' Set Parameter properties
    workParam = adapter.DeleteCommand.Parameters.Add( _
    "@EmployeeID", OleDbType.Integer)
    workParam.SourceColumn = "EmployeeID"
    workParam.SourceVersion = DataRowVersion.Original
    ' Set SelectCommand property
    adapter.SelectCommand = New OleDbCommand("SELECT * FROM Employees", conn)
    ' Create a DataSet and call its Fill method
    Dim ds As DataSet = New DataSet("EmployeeSet")
    adapter.Fill(ds, "Employees")
    ' remove the last row
    Dim Dt As DataTable = ds.Tables("Employees")
    ' find the last row in the Employee Table and 
    ' remember the first and last name of the employee
    Dim lastRow As Integer = Dt.Rows.Count - 1
    Dim firstName As String = Dt.Rows(lastRow)("FirstName").ToString()
    Dim lastName As String = Dt.Rows(lastRow)("LastName").ToString()
    ' Delete the row from the DataSet
    Dt.Rows(Dt.Rows.Count - 1).Delete()
    adapter.Update(ds, "Employees")
    ' Bind dataset's default view with the DataGrid
    DataGrid1.DataSource = ds.DefaultViewManager

    ' release objects
    conn.Close()
    conn.Dispose()

  End Sub

  Private Sub DataTableMapping1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataTableMapping1.Click
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=Northwind; Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Open the connection
    conn.Open()
    ' Create a DataTableMapping object 
    Dim dtMapping As DataTableMapping = New DataTableMapping("Orders", "mapOrders")
    Dim adapter As SqlDataAdapter = New SqlDataAdapter("Select * From Orders", conn)
    ' Call DataAdapter's TableMappings.Add method 
    adapter.TableMappings.Add(dtMapping)
    ' Create a DataSet Object and call DataAdapter's Fill method
    ' Make sure you use new name od DataTableMapping i.e., MayOrders
    Dim ds As DataSet = New DataSet()
    adapter.Fill(ds, "mapOrders")
    DataGrid1.DataSource = ds.DefaultViewManager
    'Dispose
    conn.Close()
    conn.Dispose()
  End Sub

  Private Sub DataTableMapping2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataTableMapping2.Click

    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=Northwind; Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Open the connection
    conn.Open()
    ' Create a DataTableMapping object 
    Dim dtMapping As DataTableMapping = New DataTableMapping("Table", "mapOrders")
    Dim adapter As SqlDataAdapter = New SqlDataAdapter("Select * From Orders", conn)
    ' Call DataAdapter's TableMappings.Add method 
    adapter.TableMappings.Add(dtMapping)
    ' Create a DataSet Object and call DataAdapter's Fill method
    ' Make sure you use new name od DataTableMapping i.e., MayOrders
    Dim ds As DataSet = New DataSet()
    adapter.Fill(ds)
    DataGrid1.DataSource = ds.DefaultViewManager
    'Dispose
    conn.Close()
    conn.Dispose()
  End Sub

  Private Sub DataColumnMapping_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataColumnMapping.Click

    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
    "Initial Catalog=Northwind; Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Open the connection
    conn.Open()
    ' Create a DataTableMapping object 
    Dim dtMapping As DataTableMapping = New DataTableMapping("Table", "Orders")
    Dim adapter As SqlDataAdapter = New SqlDataAdapter _
    ("SELECT OrderID, ShipName, ShipCity, OrderDate FROM Orders", conn)
    ' Call DataAdapter's TableMappings.Add method 
    adapter.TableMappings.Add(dtMapping)
    dtMapping.ColumnMappings.Add(New DataColumnMapping("OrderID", "mapID"))
    dtMapping.ColumnMappings.Add(New DataColumnMapping("ShipName", "mapName"))
    dtMapping.ColumnMappings.Add(New DataColumnMapping("ShipCity", "mapCity"))
    dtMapping.ColumnMappings.Add(New DataColumnMapping("OrderDate", "mapDate"))
    ' Create a DataSet Object and call DataAdapter's Fill method
    ' Make sure you use new name od DataTableMapping i.e., MayOrders
    Dim ds As DataSet = New DataSet()
    adapter.Fill(ds)
    DataGrid1.DataSource = ds.DefaultViewManager
    'Dispose
    conn.Close()
    conn.Dispose()

  End Sub
End Class
