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
    Me.DataGrid1.Size = New System.Drawing.Size(432, 256)
    Me.DataGrid1.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(440, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    'dcConstructorsTest()
    'CreateCustTable()
    CreateCustomersTable()
  End Sub

  Private Sub dcConstructorsTest()
    ' Create Customers table
    Dim custTable As DataTable = New DataTable("Customers")
    Dim dtSet As DataSet = New DataSet()
    ' Create Price Column          
    Dim myDataType As System.Type
    myDataType = System.Type.GetType("System.Int32")
    Dim priceCol As DataColumn = New DataColumn("Price", myDataType)
    priceCol.Caption = "Price"
    custTable.Columns.Add(priceCol)
    ' Create Quantity Column
    Dim qtCol As DataColumn = New DataColumn()
    qtCol.ColumnName = "Quantity"
    qtCol.DataType = System.Type.GetType("System.Int32")
    qtCol.Caption = "Quantity"
    custTable.Columns.Add(qtCol)
    ' Creating an expression
    Dim strExpr As String = "Price * Quantity"
    ' Create Total Column, which is result of Price*Quantity
    Dim totCol As DataColumn = New DataColumn("Total", myDataType, strExpr, _
                                               MappingType.Attribute)
    totCol.Caption = "Total"
    ' Add Name column to the table.
    custTable.Columns.Add(totCol)
    ' Add custTable to DataSet
    dtSet.Tables.Add(custTable)
    ' Bind dataset to the data grid
    DataGrid1.SetDataBinding(dtSet, "Customers")
  End Sub

  Private Sub CreateCustTable()
    ' Create a new DataTable
    Dim custTable As DataTable = New DataTable("Customers")
    ' Create ID Column
    Dim IdCol As DataColumn = New DataColumn()
    IdCol.ColumnName = "ID"
    IdCol.DataType = Type.GetType("System.Int32")
    IdCol.ReadOnly = True
    IdCol.AllowDBNull = False
    IdCol.Unique = True
    IdCol.AutoIncrement = True
    IdCol.AutoIncrementSeed = 1
    IdCol.AutoIncrementStep = 1
    custTable.Columns.Add(IdCol)
    ' Create Name Column
    Dim nameCol As DataColumn = New DataColumn()
    nameCol.ColumnName = "Name"
    nameCol.DataType = Type.GetType("System.String")
    custTable.Columns.Add(nameCol)
    ' Create Address Column
    Dim addCol As DataColumn = New DataColumn()
    addCol.ColumnName = "Address"
    addCol.DataType = Type.GetType("System.String")
    custTable.Columns.Add(addCol)
    ' Create DOB Column
    Dim dobCol As DataColumn = New DataColumn()
    dobCol.ColumnName = "DOB"
    dobCol.DataType = Type.GetType("System.DateTime")
    custTable.Columns.Add(dobCol)
    ' VAR Column
    Dim fullTimeCol As DataColumn = New DataColumn()
    fullTimeCol.ColumnName = "VAR"
    fullTimeCol.DataType = Type.GetType("System.Boolean")
    custTable.Columns.Add(fullTimeCol)
    ' Make the ID column the primary key column.
    Dim PrimaryKeyColumns() As DataColumn = New DataColumn(1) {}
    PrimaryKeyColumns(0) = custTable.Columns("ID")
    custTable.PrimaryKey = PrimaryKeyColumns
    ' Create a dataset
    Dim ds As DataSet = New DataSet("Customers")
    ' Add Customers table to the dataset
    ds.Tables.Add(custTable)
    ' Attach the data set to a DataGrid
    dataGrid1.DataSource = ds.DefaultViewManager
  End Sub


  ' This method creates Customers table      
  Private Sub CreateCustomersTable()
    ' Create a new DataTable.
    Dim custTable As System.Data.DataTable = New DataTable("Customers")
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
    Dim ds As DataSet = New DataSet("Customers")
    ' Add the custTable to the DataSet.
    ds.Tables.Add(custTable)
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
    ' row3.RejectChanges()
    ' MessageBox.Show(row2.RowState.ToString())
    'row2.Delete()
    ' MessageBox.Show(row3.RowState.ToString())
    ' Bind data set to the data grid           
    DataGrid1.DataSource = ds.DefaultViewManager
  End Sub



End Class
