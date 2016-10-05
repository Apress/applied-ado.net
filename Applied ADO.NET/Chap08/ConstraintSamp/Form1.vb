Imports System.Drawing
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
  Friend WithEvents ForeignKeyConstraint As System.Windows.Forms.Button
  Friend WithEvents UniqueConstraint As System.Windows.Forms.Button
  Friend WithEvents PrimaryKeyConstraint As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.ForeignKeyConstraint = New System.Windows.Forms.Button()
    Me.UniqueConstraint = New System.Windows.Forms.Button()
    Me.PrimaryKeyConstraint = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(0, 96)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(376, 192)
    Me.DataGrid1.TabIndex = 0
    '
    'ForeignKeyConstraint
    '
    Me.ForeignKeyConstraint.Location = New System.Drawing.Point(8, 8)
    Me.ForeignKeyConstraint.Name = "ForeignKeyConstraint"
    Me.ForeignKeyConstraint.Size = New System.Drawing.Size(144, 32)
    Me.ForeignKeyConstraint.TabIndex = 1
    Me.ForeignKeyConstraint.Text = "ForeignKeyConstraint"
    '
    'UniqueConstraint
    '
    Me.UniqueConstraint.Location = New System.Drawing.Point(168, 8)
    Me.UniqueConstraint.Name = "UniqueConstraint"
    Me.UniqueConstraint.Size = New System.Drawing.Size(136, 32)
    Me.UniqueConstraint.TabIndex = 2
    Me.UniqueConstraint.Text = "UniqueConstraint"
    '
    'PrimaryKeyConstraint
    '
    Me.PrimaryKeyConstraint.Location = New System.Drawing.Point(8, 48)
    Me.PrimaryKeyConstraint.Name = "PrimaryKeyConstraint"
    Me.PrimaryKeyConstraint.Size = New System.Drawing.Size(144, 32)
    Me.PrimaryKeyConstraint.TabIndex = 3
    Me.PrimaryKeyConstraint.Text = "PrimaryKey Constraint"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(384, 293)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.PrimaryKeyConstraint, Me.UniqueConstraint, Me.ForeignKeyConstraint, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region


  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
   

  End Sub

  ' This method creates Customers table      
  Function CreateCustomersTable() As DataTable
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
    dtColumn.Unique = False
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
    Return custTable

  End Function

  ' This method creates Orders table with 
  Function CreateOrdersTable() As DataTable
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
    dtColumn.Unique = False
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
    ' Add couple of rows to the table
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
    Return ordersTable

  End Function

  Private Sub ForeignKeyConstraint_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ForeignKeyConstraint.Click

    ' Create two DataTable objects 
    ' Customer and Orders
    Dim custTable As DataTable = CreateCustomersTable()
    Dim ordersTable As DataTable = CreateOrdersTable()
    Try
      ' Add a foriegn key constraint
      Dim parentColumn As DataColumn = custTable.Columns("id")
      Dim childColumn As DataColumn = ordersTable.Columns("CustID")
      Dim fkConst As ForeignKeyConstraint = New ForeignKeyConstraint _
   ("CustOrderConts", parentColumn, childColumn)
      fkConst.DeleteRule = Rule.SetNull
      fkConst.UpdateRule = Rule.Cascade
      fkConst.AcceptRejectRule = AcceptRejectRule.Cascade
      ordersTable.Constraints.Add(fkConst)
    Catch exp As Exception
      MessageBox.Show(exp.Message)
    End Try

    ' Create a DataSet and add DataTables to it
    Dim ds As DataSet = New DataSet("CustOrderDataSet")
    Dim contCollection As ConstraintCollection = _
      ordersTable.Constraints
    Dim str As String = "Number of Constraints:" & _
     contCollection.Count.ToString()
    Dim i As Integer
    Dim cnst As Constraint
    For Each cnst In contCollection
      str = str + ", "
      str = str + cnst.ConstraintName
    Next
    ' Add DataTables to a DataSet
    ds.Tables.Add(custTable)
    ds.Tables.Add(ordersTable)
    ' Enforce Constraints
    ds.EnforceConstraints = True

    ' Using Contains, CanRemove and Remove methods
    ' Get the first constraint
    Dim cnst1 As Constraint = ordersTable.Constraints(0)
    Try
      If ordersTable.Constraints.Contains(cnst1.ConstraintName) Then
        If ordersTable.Constraints.CanRemove(cnst1) Then
          ordersTable.Constraints.Remove(cnst1)
        End If
      End If
    Catch myException As Exception
      Console.WriteLine(myException.Message)
    End Try

    DataGrid1.DataSource = ds.DefaultViewManager
  End Sub

  Private Sub UniqueConstraint_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles UniqueConstraint.Click
    ' Create two DataTable objects 
    ' Customer and Orders
    Dim custTable As DataTable = CreateCustomersTable()
    Dim ordersTable As DataTable = CreateOrdersTable()
    Try
      ' Create unique constraints
      Dim idCol As DataColumn = New DataColumn()
      idCol = custTable.Columns("id")
      Dim unqConst1 As UniqueConstraint = _
      New UniqueConstraint("idUnqConst1", idCol)
      idCol = ordersTable.Columns("OrderId")
      Dim unqConst2 As UniqueConstraint = _
      New UniqueConstraint("idUnqConst2", idCol)
      ' Add constraints to DataTables
      custTable.Constraints.Add(unqConst1)
      ordersTable.Constraints.Add(unqConst2)
    Catch exp As Exception
      MessageBox.Show(exp.Message)
    End Try
    ' Create a DataSet and add DataTables to it
    Dim ds As DataSet = New DataSet("CustOrderDataSet")
    ' Add DataTables to a DataSet
    ds.Tables.Add(custTable)
    ds.Tables.Add(ordersTable)
    ' Enforce Constraints
    ds.EnforceConstraints = True
    DataGrid1.DataSource = ds.DefaultViewManager
  End Sub

  Private Sub PrimaryKeyConstraint_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles PrimaryKeyConstraint.Click

    Dim custTable As DataTable = CreateCustomersTable()
    ' Make the ID column the primary key column.
    Dim PrimaryKeyColumns() As DataColumn = New DataColumn(1) {}
    PrimaryKeyColumns(0) = custTable.Columns("id")
    custTable.PrimaryKey = PrimaryKeyColumns


  

  End Sub
End Class
