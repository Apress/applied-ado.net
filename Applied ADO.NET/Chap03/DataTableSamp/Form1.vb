Public Class Form1
  Inherits System.Windows.Forms.Form
  Private dtSet As System.Data.DataSet


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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(0, 8)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(384, 256)
    Me.DataGrid1.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(392, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1})
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
    BindData()
  End Sub

  ' This method creates Customers table      
  Private Sub CreateCustomersTable()
    ' Create a new DataTable.
    Dim custTable As System.Data.DataTable = New DataTable("Customers")
    Dim dtColumn As DataColumn
    Dim myDataRow As DataRow
    ' Create id Column
    dtColumn = New DataColumn()
    dtColumn.DataType = System.Type.GetType("System.Int32")
    dtColumn.ColumnName = "id"
    dtColumn.Caption = "Cust ID"
    dtColumn.ReadOnly = False
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
    dtSet = New DataSet("Customers")
    ' Add the custTable to the DataSet.
    dtSet.Tables.Add(custTable)
    ' Add rows to the custTable using its NewRow method
    ' I add three customers with thier addresses, name and id
    myDataRow = custTable.NewRow()
    myDataRow("id") = 1001
    myDataRow("Address") = "43 Lanewood Road, Cito, CA"
    myDataRow("Name") = "George Bishop "
    custTable.Rows.Add(myDataRow)
    myDataRow = custTable.NewRow()
    myDataRow("id") = 1002
    myDataRow("Name") = "Rock Joe "
    myDataRow("Address") = "King of Prusssia, PA"
    custTable.Rows.Add(myDataRow)
    myDataRow = custTable.NewRow()
    myDataRow("id") = 1003
    myDataRow("Name") = "Miranda "
    myDataRow("Address") = "279 P. Avenue, Bridgetown, PA"
    custTable.Rows.Add(myDataRow)
  End Sub

  ' This method creates Orders table with 
  Private Sub CreateOrdersTable()
    ' Create Orders table.
    Dim ordersTable As DataTable = New DataTable("Orders")
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

    ' Add ordersTable to the dataset
    dtSet.Tables.Add(ordersTable)

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

  ' This method creates a customer order relationship and binds data tables 
  ' to the data grid cotnrol using data set.
  Private Sub BindData()
    Dim dtRelation As DataRelation
    Dim CustCol As DataColumn = dtSet.Tables("Customers").Columns("id")
    Dim orderCol As DataColumn = dtSet.Tables("Orders").Columns("CustId")

    dtRelation = New DataRelation("CustOrderRelation", CustCol, orderCol)
    dtSet.Tables("Orders").ParentRelations.Add(dtRelation)
    DataGrid1.SetDataBinding(dtSet, "Customers")
  End Sub



End Class
