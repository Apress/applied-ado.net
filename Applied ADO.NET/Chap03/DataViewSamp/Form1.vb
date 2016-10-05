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
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(16, 16)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(192, 240)
    Me.DataGrid1.TabIndex = 0
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(240, 32)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(136, 134)
    Me.ListBox1.TabIndex = 1
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(392, 285)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1, Me.DataGrid1})
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

    ' Creating a DataView from DataTable
    Dim dtView1 As DataView = New DataView(custTable)
    ' Creating a DataView through  DataSet
    Dim dtSet1 As DataSet = New DataSet()
    dtSet1.Tables.Add(ordersTable)
    Dim dtView2 As DataView = New DataView(dtSet1.Tables(0))
    dtView2.Sort = "Name"
    Dim val As Object = "Data Quest"
    Dim pos As Integer = dtView2.Find(Val)
    MessageBox.Show(pos.ToString())

    ' Set AllowDelete, AllowNew and AllowEdit to true
    dtView1.AllowDelete = True
    dtView1.AllowNew = True
    dtView1.AllowEdit = True
    ' Edit the data of first row 
    dtView1(0).BeginEdit()
    dtView1(0)("Name") = "Edited Name"
    dtView1(0)("Address") = "Edited Address"
    dtView1(0).EndEdit()
    ' Delete the first row from DataView
    ' the Delete method takes an index of row starting
    ' at 0
    If dtView1.AllowDelete Then
      dtView1.Delete(0)
    End If
    ' Add a new row
    Dim drv As DataRowView = dtView1.AddNew
    ' Change values in the DataRow.
    drv("id") = 1010
    drv("Name") = "New Name"
    drv("Address") = "New Address"
    drv.EndEdit()

    dtView1.RowFilter = "Name = 'Miranda'"
    dtView1.Sort = "Name, Address ASC"
    dtView1.Sort = "Name DESC"

    ' Count number of rows
    MessageBox.Show(dtView1.Count.ToString())

    DataGrid1.DataSource = dtView1
    ListBox1.DataSource = dtView2
    ListBox1.DisplayMember = "Name"
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
