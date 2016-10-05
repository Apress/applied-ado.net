Public Class Form1
  Inherits System.Windows.Forms.Form
  Private custTable As DataTable
  Private dtSet As DataSet


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
  Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
  Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents SearchBtn As System.Windows.Forms.Button
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents SortBtn As System.Windows.Forms.Button
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
  Friend WithEvents AddRowBtn As System.Windows.Forms.Button
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
  Friend WithEvents Label7 As System.Windows.Forms.Label
  Friend WithEvents DeleteRowsBtn As System.Windows.Forms.Button
  Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
  Friend WithEvents SaveBtn As System.Windows.Forms.Button
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.GroupBox1 = New System.Windows.Forms.GroupBox()
    Me.Label7 = New System.Windows.Forms.Label()
    Me.Label6 = New System.Windows.Forms.Label()
    Me.TextBox7 = New System.Windows.Forms.TextBox()
    Me.TextBox6 = New System.Windows.Forms.TextBox()
    Me.DeleteRowsBtn = New System.Windows.Forms.Button()
    Me.GroupBox2 = New System.Windows.Forms.GroupBox()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.SortBtn = New System.Windows.Forms.Button()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.GroupBox3 = New System.Windows.Forms.GroupBox()
    Me.AddRowBtn = New System.Windows.Forms.Button()
    Me.TextBox5 = New System.Windows.Forms.TextBox()
    Me.TextBox4 = New System.Windows.Forms.TextBox()
    Me.Label5 = New System.Windows.Forms.Label()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.GroupBox4 = New System.Windows.Forms.GroupBox()
    Me.SearchBtn = New System.Windows.Forms.Button()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.GroupBox5 = New System.Windows.Forms.GroupBox()
    Me.SaveBtn = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    Me.GroupBox2.SuspendLayout()
    Me.GroupBox3.SuspendLayout()
    Me.GroupBox4.SuspendLayout()
    Me.GroupBox5.SuspendLayout()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(360, 216)
    Me.DataGrid1.TabIndex = 0
    '
    'GroupBox1
    '
    Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
    Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label7, Me.Label6, Me.TextBox7, Me.TextBox6, Me.DeleteRowsBtn})
    Me.GroupBox1.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.GroupBox1.Location = New System.Drawing.Point(0, 312)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(360, 72)
    Me.GroupBox1.TabIndex = 1
    Me.GroupBox1.TabStop = False
    Me.GroupBox1.Text = "Remove Rows Section"
    '
    'Label7
    '
    Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!)
    Me.Label7.Location = New System.Drawing.Point(144, 16)
    Me.Label7.Name = "Label7"
    Me.Label7.Size = New System.Drawing.Size(88, 16)
    Me.Label7.TabIndex = 7
    Me.Label7.Text = "Enter Value"
    '
    'Label6
    '
    Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!)
    Me.Label6.Location = New System.Drawing.Point(16, 16)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(120, 16)
    Me.Label6.TabIndex = 5
    Me.Label6.Text = "Enter Column Name"
    '
    'TextBox7
    '
    Me.TextBox7.AutoSize = False
    Me.TextBox7.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TextBox7.Font = New System.Drawing.Font("Verdana", 8.25!)
    Me.TextBox7.Location = New System.Drawing.Point(16, 40)
    Me.TextBox7.Name = "TextBox7"
    Me.TextBox7.Size = New System.Drawing.Size(120, 16)
    Me.TextBox7.TabIndex = 5
    Me.TextBox7.Text = ""
    '
    'TextBox6
    '
    Me.TextBox6.AutoSize = False
    Me.TextBox6.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TextBox6.Font = New System.Drawing.Font("Verdana", 8.25!)
    Me.TextBox6.Location = New System.Drawing.Point(144, 40)
    Me.TextBox6.Name = "TextBox6"
    Me.TextBox6.Size = New System.Drawing.Size(184, 16)
    Me.TextBox6.TabIndex = 6
    Me.TextBox6.Text = ""
    '
    'DeleteRowsBtn
    '
    Me.DeleteRowsBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.DeleteRowsBtn.Location = New System.Drawing.Point(240, 8)
    Me.DeleteRowsBtn.Name = "DeleteRowsBtn"
    Me.DeleteRowsBtn.Size = New System.Drawing.Size(112, 24)
    Me.DeleteRowsBtn.TabIndex = 5
    Me.DeleteRowsBtn.Text = "Delete Rows"
    '
    'GroupBox2
    '
    Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte))
    Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckBox1, Me.SortBtn, Me.TextBox3, Me.Label3})
    Me.GroupBox2.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
    Me.GroupBox2.Location = New System.Drawing.Point(368, 152)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(168, 136)
    Me.GroupBox2.TabIndex = 2
    Me.GroupBox2.TabStop = False
    Me.GroupBox2.Text = "Sort Section"
    '
    'CheckBox1
    '
    Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.CheckBox1.Font = New System.Drawing.Font("Verdana", 8.0!)
    Me.CheckBox1.Location = New System.Drawing.Point(16, 72)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(112, 24)
    Me.CheckBox1.TabIndex = 3
    Me.CheckBox1.Text = "DESC"
    '
    'SortBtn
    '
    Me.SortBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.SortBtn.Location = New System.Drawing.Point(24, 104)
    Me.SortBtn.Name = "SortBtn"
    Me.SortBtn.Size = New System.Drawing.Size(120, 24)
    Me.SortBtn.TabIndex = 2
    Me.SortBtn.Text = "Apply Sort"
    '
    'TextBox3
    '
    Me.TextBox3.AutoSize = False
    Me.TextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TextBox3.Font = New System.Drawing.Font("Verdana", 8.0!)
    Me.TextBox3.Location = New System.Drawing.Point(16, 48)
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(128, 16)
    Me.TextBox3.TabIndex = 1
    Me.TextBox3.Text = ""
    '
    'Label3
    '
    Me.Label3.Font = New System.Drawing.Font("Verdana", 8.0!)
    Me.Label3.Location = New System.Drawing.Point(16, 24)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(144, 16)
    Me.Label3.TabIndex = 0
    Me.Label3.Text = "Enter Column Name"
    '
    'GroupBox3
    '
    Me.GroupBox3.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(192, Byte), CType(192, Byte))
    Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.AddRowBtn, Me.TextBox5, Me.TextBox4, Me.Label5, Me.Label4})
    Me.GroupBox3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold)
    Me.GroupBox3.Location = New System.Drawing.Point(0, 224)
    Me.GroupBox3.Name = "GroupBox3"
    Me.GroupBox3.Size = New System.Drawing.Size(360, 72)
    Me.GroupBox3.TabIndex = 3
    Me.GroupBox3.TabStop = False
    Me.GroupBox3.Text = "Add Rows Section"
    '
    'AddRowBtn
    '
    Me.AddRowBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.AddRowBtn.Location = New System.Drawing.Point(240, 16)
    Me.AddRowBtn.Name = "AddRowBtn"
    Me.AddRowBtn.Size = New System.Drawing.Size(112, 24)
    Me.AddRowBtn.TabIndex = 4
    Me.AddRowBtn.Text = "Add Row"
    '
    'TextBox5
    '
    Me.TextBox5.AutoSize = False
    Me.TextBox5.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TextBox5.Font = New System.Drawing.Font("Verdana", 8.25!)
    Me.TextBox5.Location = New System.Drawing.Point(144, 48)
    Me.TextBox5.Name = "TextBox5"
    Me.TextBox5.Size = New System.Drawing.Size(184, 16)
    Me.TextBox5.TabIndex = 3
    Me.TextBox5.Text = ""
    '
    'TextBox4
    '
    Me.TextBox4.AutoSize = False
    Me.TextBox4.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TextBox4.Font = New System.Drawing.Font("Verdana", 8.25!)
    Me.TextBox4.Location = New System.Drawing.Point(16, 48)
    Me.TextBox4.Name = "TextBox4"
    Me.TextBox4.Size = New System.Drawing.Size(120, 16)
    Me.TextBox4.TabIndex = 2
    Me.TextBox4.Text = ""
    '
    'Label5
    '
    Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!)
    Me.Label5.Location = New System.Drawing.Point(144, 24)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(88, 16)
    Me.Label5.TabIndex = 1
    Me.Label5.Text = "Enter Address"
    '
    'Label4
    '
    Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!)
    Me.Label4.Location = New System.Drawing.Point(16, 24)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(104, 16)
    Me.Label4.TabIndex = 0
    Me.Label4.Text = "Enter Name"
    '
    'GroupBox4
    '
    Me.GroupBox4.BackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
    Me.GroupBox4.Controls.AddRange(New System.Windows.Forms.Control() {Me.SearchBtn, Me.TextBox2, Me.Label2, Me.TextBox1, Me.Label1})
    Me.GroupBox4.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
    Me.GroupBox4.Location = New System.Drawing.Point(368, 8)
    Me.GroupBox4.Name = "GroupBox4"
    Me.GroupBox4.Size = New System.Drawing.Size(168, 144)
    Me.GroupBox4.TabIndex = 4
    Me.GroupBox4.TabStop = False
    Me.GroupBox4.Text = "Search Section"
    '
    'SearchBtn
    '
    Me.SearchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.SearchBtn.Location = New System.Drawing.Point(24, 112)
    Me.SearchBtn.Name = "SearchBtn"
    Me.SearchBtn.Size = New System.Drawing.Size(112, 24)
    Me.SearchBtn.TabIndex = 4
    Me.SearchBtn.Text = "Search"
    '
    'TextBox2
    '
    Me.TextBox2.AutoSize = False
    Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TextBox2.Location = New System.Drawing.Point(8, 80)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(152, 16)
    Me.TextBox2.TabIndex = 3
    Me.TextBox2.Text = ""
    '
    'Label2
    '
    Me.Label2.Font = New System.Drawing.Font("Verdana", 8.0!)
    Me.Label2.Location = New System.Drawing.Point(8, 64)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(144, 16)
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Enter Value"
    '
    'TextBox1
    '
    Me.TextBox1.AutoSize = False
    Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
    Me.TextBox1.Location = New System.Drawing.Point(8, 40)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(152, 16)
    Me.TextBox1.TabIndex = 1
    Me.TextBox1.Text = ""
    '
    'Label1
    '
    Me.Label1.Font = New System.Drawing.Font("Verdana", 8.0!)
    Me.Label1.Location = New System.Drawing.Point(8, 24)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(144, 16)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "Enter Column Name"
    '
    'GroupBox5
    '
    Me.GroupBox5.BackColor = System.Drawing.SystemColors.Desktop
    Me.GroupBox5.Controls.AddRange(New System.Windows.Forms.Control() {Me.SaveBtn})
    Me.GroupBox5.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
    Me.GroupBox5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
    Me.GroupBox5.Location = New System.Drawing.Point(368, 288)
    Me.GroupBox5.Name = "GroupBox5"
    Me.GroupBox5.Size = New System.Drawing.Size(168, 96)
    Me.GroupBox5.TabIndex = 5
    Me.GroupBox5.TabStop = False
    Me.GroupBox5.Text = "Save Section"
    '
    'SaveBtn
    '
    Me.SaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
    Me.SaveBtn.Location = New System.Drawing.Point(16, 40)
    Me.SaveBtn.Name = "SaveBtn"
    Me.SaveBtn.Size = New System.Drawing.Size(128, 32)
    Me.SaveBtn.TabIndex = 0
    Me.SaveBtn.Text = "Save DataTable"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(536, 381)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox5, Me.GroupBox4, Me.GroupBox3, Me.GroupBox2, Me.GroupBox1, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Adding, Updating, Deleting, Sorting, and Searching in DataTable"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    Me.GroupBox2.ResumeLayout(False)
    Me.GroupBox3.ResumeLayout(False)
    Me.GroupBox4.ResumeLayout(False)
    Me.GroupBox5.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub

#End Region

  
  Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    CreateCustomersTable()
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
    dtColumn.AutoIncrement = True
    dtColumn.AutoIncrementSeed = 100
    dtColumn.AutoIncrementStep = 1
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
    dtSet = New DataSet("Customers")
    ' Add the custTable to the DataSet.
    dtSet.Tables.Add(custTable)
    RefreshData()
  End Sub

  Private Sub RefreshData()
    dataGrid1.DataSource = dtSet.DefaultViewManager
  End Sub

  Private Sub AddRowBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles AddRowBtn.Click
    ' Add rows to the custTable using its NewRow method
    ' I add three customers with thier addresses, name and id
    Dim myDataRow As DataRow = custTable.NewRow()
    myDataRow("Name") = TextBox4.Text.ToString()
    myDataRow("Address") = TextBox5.Text.ToString()
    custTable.Rows.Add(myDataRow)
    custTable.AcceptChanges()
    RefreshData()
  End Sub

  Private Sub DeleteRowsBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles DeleteRowsBtn.Click
    Dim str As String = TextBox7.Text + "='" + TextBox6.Text + "'"
    Dim rows() As DataRow = custTable.Select(str)
    ' If no record found
    If rows.Length = 0 Then
      MessageBox.Show("Record not found!")
      Return
    End If
    Dim i As Integer
    For i = 0 To rows.Length - 1 Step i + 1
      rows(i).Delete()
      rows(i).AcceptChanges()
    Next
    RefreshData()
  End Sub

  Private Sub SearchBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles SearchBtn.Click

    Dim searchTable As DataTable = New DataTable("SortTable")
    searchTable = custTable.Clone()
    Dim str As String = TextBox1.Text & " ='" & TextBox2.Text + "'"
    Dim rows() As DataRow = custTable.Select(str)
    ' If no record found
    If rows.Length = 0 Then
      MessageBox.Show("Name not found!")
      Return
    End If
    Dim i As Integer
    For i = 0 To rows.Length - 1 Step i + 1
      Dim row As DataRow = searchTable.NewRow()
      row("Name") = rows(i)("Name")
      row("Address") = rows(i)("Address")
      searchTable.Rows.Add(row)
    Next
    Dim sortdtSet As DataSet = New DataSet("SortedData")
    sortdtSet.Tables.Add(searchTable)
    DataGrid1.DataSource = sortdtSet.DefaultViewManager
  End Sub

  Private Sub SortBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles SortBtn.Click

    Dim sortTable As DataTable = New DataTable("SortTable")
    sortTable = custTable.Clone()
    Dim strSort As String = TextBox3.Text
    If (CheckBox1.Checked) Then
      strSort = strSort & " DESC"
    Else
      strSort = strSort & " ASC"
    End If
    Dim rows() As DataRow = _
    custTable.Select(String.Empty, strSort)
    Dim i As Integer
    For i = 0 To rows.Length - 1 Step i + 1
      Dim row As DataRow = sortTable.NewRow()
      row("Name") = rows(i)("Name")
      row("Address") = rows(i)("Address")
      sortTable.Rows.Add(row)
    Next
    Dim sortdtSet As DataSet = New DataSet("SortedData")
    sortdtSet.Tables.Add(sortTable)
    DataGrid1.DataSource = sortdtSet.DefaultViewManager
  End Sub

  Private Sub SaveBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles SaveBtn.Click
    Dim fdlg As SaveFileDialog = New SaveFileDialog()
    fdlg.Title = "C# Corner Save File Dialog"
    fdlg.InitialDirectory = "c:\\"
    fdlg.Filter = "XML files (*.xml)|*.*|All files (*.*)|*.*"
    If fdlg.ShowDialog() = DialogResult.OK Then
      dtSet.WriteXml(fdlg.FileName)
    End If

  End Sub
End Class
