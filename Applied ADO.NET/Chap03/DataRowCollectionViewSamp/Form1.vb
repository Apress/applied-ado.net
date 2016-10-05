Public Class Form1
  Inherits System.Windows.Forms.Form
  Private dtSet As DataSet
  Private custTable As DataTable

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
    Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(320, 256)
    Me.DataGrid1.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(344, 273)
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
    Dim rows As DataRowCollection = custTable.Rows
    ' rows.Clear()
    Dim counter As Integer
    counter = rows.Count
    Dim row As DataRow
    If rows.Contains(1002) Then
      row = rows.Find(1002)
      rows.Remove(row)
      MessageBox.Show("Row Removed")
    Else
      MessageBox.Show("Row not found")
    End If

    Dim newRow As DataRow
    newRow = custTable.NewRow()
    newRow("id") = 1005
    newRow("Address") = "New Address"
    newRow("Name") = "New Name"
    rows.InsertAt(newRow, 3)

    If (Not rows(1).IsNull("id")) Then
      rows.RemoveAt(1)
    End If


    MessageBox.Show(counter.ToString())
    DataGrid1.DataSource = dtSet.DefaultViewManager
  End Sub

  ' This method creates Customers table      
  Private Sub CreateCustomersTable()
    ' Create a new DataTable.
    custTable = New DataTable("Customers")
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

End Class
