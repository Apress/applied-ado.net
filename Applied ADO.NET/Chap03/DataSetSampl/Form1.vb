Public Class Form1
  Inherits System.Windows.Forms.Form
  Private custTable As DataTable
  Private ordersTable As DataTable

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
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
  Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
  Friend WithEvents DtSetProperties As System.Windows.Forms.MenuItem
  Friend WithEvents CopyCloneClear As System.Windows.Forms.MenuItem
  Friend WithEvents AddDataTables As System.Windows.Forms.MenuItem
  Friend WithEvents MergeDataSets As System.Windows.Forms.MenuItem
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.MainMenu1 = New System.Windows.Forms.MainMenu()
    Me.MenuItem1 = New System.Windows.Forms.MenuItem()
    Me.DtSetProperties = New System.Windows.Forms.MenuItem()
    Me.CopyCloneClear = New System.Windows.Forms.MenuItem()
    Me.AddDataTables = New System.Windows.Forms.MenuItem()
    Me.MergeDataSets = New System.Windows.Forms.MenuItem()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(24, 16)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(256, 240)
    Me.DataGrid1.TabIndex = 0
    '
    'MainMenu1
    '
    Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
    '
    'MenuItem1
    '
    Me.MenuItem1.Index = 0
    Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.DtSetProperties, Me.CopyCloneClear, Me.AddDataTables, Me.MergeDataSets})
    Me.MenuItem1.Text = "DataSet"
    '
    'DtSetProperties
    '
    Me.DtSetProperties.Index = 0
    Me.DtSetProperties.Text = "Properties"
    '
    'CopyCloneClear
    '
    Me.CopyCloneClear.Index = 1
    Me.CopyCloneClear.Text = "Copy, Clone and Clear"
    '
    'AddDataTables
    '
    Me.AddDataTables.Index = 2
    Me.AddDataTables.Text = "Add DataTables"
    '
    'MergeDataSets
    '
    Me.MergeDataSets.Index = 3
    Me.MergeDataSets.Text = "Merge DataSets"
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

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    CreateCustomersTable()
    CreateOrdersTable()
  End Sub

  Private Sub MergeDataSets_Click(ByVal sender As System.Object, _
 ByVal e As System.EventArgs) Handles MergeDataSets.Click
    Dim dtSet1 As DataSet = New DataSet("EmpDataSet")
    Dim dtSet2 As DataSet = New DataSet("OrdersDataSet")
    Dim str As String = "OrderId >= 2 "
    Dim rows() As DataRow = ordersTable.Select(str)
    dtSet1.Tables.Add(custTable)
    dtSet2.Tables.Add(ordersTable)
    dtSet1.Merge(dtSet2, False, MissingSchemaAction.Add)
    DataGrid1.DataSource = dtSet1.DefaultViewManager
  End Sub

  Private Sub AddDataTables_Click(ByVal sender As System.Object, _
 ByVal e As System.EventArgs) Handles AddDataTables.Click
    Dim tbl1 As DataTable = New DataTable("One")
    Dim tbl2 As DataTable = New DataTable("Two")
    Dim tbl3 As DataTable = New DataTable("Three")
    Dim dtSet1 As DataSet = New DataSet("CustDtSet")
    dtSet1.Tables.Add(custTable)
    dtSet1.Tables.Add(tbl1)
    dtSet1.Tables.Add(tbl2)
    dtSet1.Tables.Add(tbl3)
    DataGrid1.DataSource = dtSet1.DefaultViewManager
  End Sub

  Private Sub CopyCloneClear_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles CopyCloneClear.Click
    Dim dtSet1 As DataSet = New DataSet("CustDtSet")
    dtSet1.Tables.Add(custTable)
    Dim dtSet2 As DataSet = New DataSet()
    dtSet2 = dtSet1.Clone()
    dtSet2 = dtSet1.Copy()
    dtSet1.Clear()
    DataGrid1.DataSource = dtSet1.DefaultViewManager
  End Sub

  Private Sub DtSetProperties_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtSetProperties.Click
    Dim dtSet1 As DataSet
    dtSet1 = New DataSet("DataSet1")
    dtSet1.DataSetName = "CustomDataSet"
    MessageBox.Show(dtSet1.DataSetName.ToString())
    dtSet1.ExtendedProperties.Add("Description", "The Name Column")
    dtSet1.ExtendedProperties.Add("Author", "Mahesh Chand")
    dtSet1.ExtendedProperties.Add("UserId", "MCB")
    dtSet1.ExtendedProperties.Add("PWD", "Password")
    ' Remove Author property
    dtSet1.ExtendedProperties.Remove("Author")
    ' Read custom properties
    Dim str As String
    Dim i As Integer
    str = dtSet1.ExtendedProperties("Description").ToString()
    str = str + ", " + dtSet1.ExtendedProperties("UserId").ToString()
    str = str + ", " + dtSet1.ExtendedProperties("PWD").ToString()
    Dim cInfo As System.Globalization.CultureInfo
    cInfo = dtSet1.Locale
    Console.WriteLine(cInfo.DisplayName, cInfo.EnglishName)
    dtSet1.Namespace = "CustDSNamespace"
    dtSet1.Prefix = "CustPrefix"
    MessageBox.Show(str)
  End Sub

  ' This method creates Customers table      
  Private Sub CreateCustomersTable()
    ' Create a new DataTable.
    custTable = New DataTable("Customers")
    Dim dtColumn As DataColumn
    ' Create id Column
    dtColumn = New DataColumn()
    dtColumn.DataType = System.Type.GetType("System.Int32")
    dtColumn.ColumnName = "id"
    dtColumn.Caption = "Cust ID"
    dtColumn.ReadOnly = True
    dtColumn.Unique = True
    ' Add id Column to the DataColumnCollection.
    custTable.Columns.Add(dtColumn)
    ' Create Name column.
    dtColumn = New DataColumn()
    dtColumn.DataType = System.Type.GetType("System.String")
    dtColumn.ColumnName = "Name"
    dtColumn.Caption = "Cust Name"
    dtColumn.AutoIncrement = False
    dtColumn.ReadOnly = False
    dtColumn.Unique = False
    ' Add Name column to the table.
    custTable.Columns.Add(dtColumn)
    ' Create Address column.
    dtColumn = New DataColumn()
    dtColumn.DataType = System.Type.GetType("System.String")
    dtColumn.ColumnName = "Address"
    dtColumn.Caption = "Address"
    dtColumn.ReadOnly = False
    dtColumn.Unique = False
    ' Add Address column to the table.
    custTable.Columns.Add(dtColumn)
    ' Make the ID column the primary key column.
    Dim PrimaryKeyColumns() As DataColumn = New DataColumn(1) {}
    PrimaryKeyColumns(0) = custTable.Columns("id")
    custTable.PrimaryKey = PrimaryKeyColumns
    ' Instantiate the DataSet variable.
    ' Add rows to the custTable using its NewRow method
    ' I add three customers with thier addresses, name and id
    Dim row1 As DataRow = custTable.NewRow()
    row1("id") = 1001
    row1("Address") = "43 Lanewood Road, Cito, CA"
    row1("Name") = "George Bishop "
    custTable.Rows.Add(row1)
    Dim row2 As DataRow = custTable.NewRow()
    row2("id") = 1002
    row2("Name") = "Rock Joe "
    row2("Address") = "King of Prusssia, PA"
    custTable.Rows.Add(row2)
    Dim row3 As DataRow = custTable.NewRow()
    row3("id") = 1003
    row3("Name") = "Miranda "
    row3("Address") = "279 P. Avenue, Bridgetown, PA"
    custTable.Rows.Add(row3)
  End Sub


  ' This method creates Orders table with 
  Private Sub CreateOrdersTable()
    ' Create Orders table.
    ordersTable = New DataTable("Orders")
    Dim dtColumn As DataColumn
    Dim dtRow As DataRow

    ' Create OrderId column
    dtColumn = New DataColumn()
    dtColumn.DataType = System.Type.GetType("System.Int32")
    dtColumn.ColumnName = "OrderId"
    dtColumn.AutoIncrement = True
    dtColumn.Caption = "Order ID"
    dtColumn.ReadOnly = True
    dtColumn.Unique = True
    ordersTable.Columns.Add(dtColumn)

    ' Create Name column.
    dtColumn = New DataColumn()
    dtColumn.DataType = System.Type.GetType("System.String")
    dtColumn.ColumnName = "Name"
    dtColumn.Caption = "Item Name"
    ordersTable.Columns.Add(dtColumn)

    ' Create CustId column which reprence CustId from 
    ' the custTable
    dtColumn = New DataColumn()
    dtColumn.DataType = System.Type.GetType("System.Int32")
    dtColumn.ColumnName = "CustId"
    dtColumn.AutoIncrement = False
    dtColumn.Caption = "CustId"
    dtColumn.ReadOnly = False
    dtColumn.Unique = False
    ordersTable.Columns.Add(dtColumn)

    ' Create Description column.
    dtColumn = New DataColumn()
    dtColumn.DataType = System.Type.GetType("System.String")
    dtColumn.ColumnName = "Description"
    dtColumn.Caption = "Description Name"
    ordersTable.Columns.Add(dtColumn)

    ' Add two rows to Customer Id 1001
    dtRow = ordersTable.NewRow()
    dtRow("OrderId") = 0
    dtRow("Name") = "ASP Book"
    dtRow("CustId") = 1001
    dtRow("Description") = "Same Day"
    ordersTable.Rows.Add(dtRow)

    dtRow = ordersTable.NewRow()
    dtRow("OrderId") = 1
    dtRow("Name") = "C# Book"
    dtRow("CustId") = 1001
    dtRow("Description") = "2 Day Air"
    ordersTable.Rows.Add(dtRow)

    ' Add two rows to Customer Id 1002
    dtRow = ordersTable.NewRow()
    dtRow("OrderId") = 2
    dtRow("Name") = "Data Quest"
    dtRow("Description") = "Monthly Magazine"
    dtRow("CustId") = 1002
    ordersTable.Rows.Add(dtRow)

    dtRow = ordersTable.NewRow()
    dtRow("OrderId") = 3
    dtRow("Name") = "PC Magazine"
    dtRow("Description") = "Monthly Magazine"
    dtRow("CustId") = 1002
    ordersTable.Rows.Add(dtRow)

    ' Add two rows to Customer Id 1003
    dtRow = ordersTable.NewRow()
    dtRow("OrderId") = 4
    dtRow("Name") = "PC Magazine"
    dtRow("Description") = "Monthly Magazine"
    dtRow("CustId") = 1003
    ordersTable.Rows.Add(dtRow)

    dtRow = ordersTable.NewRow()
    dtRow("OrderId") = 5
    dtRow("Name") = "C# Book"
    dtRow("CustId") = 1003
    dtRow("Description") = "2 Day Air"
    ordersTable.Rows.Add(dtRow)
  End Sub

End Class
