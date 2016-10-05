Imports System.ComponentModel

Public Class Form1
  Inherits System.Windows.Forms.Form

  Private ds As DataSet = Nothing

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
  Friend WithEvents dtGrid As System.Windows.Forms.DataGrid
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.dtGrid = New System.Windows.Forms.DataGrid()
    CType(Me.dtGrid, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'dtGrid
    '
    Me.dtGrid.DataMember = ""
    Me.dtGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.dtGrid.Location = New System.Drawing.Point(8, 32)
    Me.dtGrid.Name = "dtGrid"
    Me.dtGrid.Size = New System.Drawing.Size(392, 240)
    Me.dtGrid.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(408, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtGrid})
    Me.Name = "Form1"
    Me.Text = "DataGridBool and DataGridTextBox Columns Sample"
    CType(Me.dtGrid, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region


  Private Sub FillDataGrid()
    ' Create a DataGridTableStyle and set its properties
    Dim dgTableStyle As DataGridTableStyle = New DataGridTableStyle()
    dgTableStyle.MappingName = "Employees"
    dgTableStyle.AlternatingBackColor = Color.Gray
    dgTableStyle.BackColor = Color.Black
    dgTableStyle.AllowSorting = True
    dgTableStyle.ForeColor = Color.White
    ' Create a DataGridColumnStyle. Add it to DataGridTableStyle
    Dim dgTextCol As DataGridColumnStyle = New DataGridTextBoxColumn()
    dgTextCol.MappingName = "Name" 'from dataset table
    dgTextCol.HeaderText = "Employee Name"
    dgTextCol.Width = 100
    dgTableStyle.GridColumnStyles.Add(dgTextCol)
    ' Get PropertyDescriptorCollection by calling GetItemProperties		
    Dim pdc As PropertyDescriptorCollection = Me.BindingContext _
    (ds, "Employees").GetItemProperties()
    'Create a DataGrodTextBoxColu
    Dim dgIntCol As DataGridTextBoxColumn = _
    New DataGridTextBoxColumn(pdc("EmployeeID"), "i", True)
    dgIntCol.MappingName = "EmployeeID"
    dgIntCol.HeaderText = "Employee ID"
    dgIntCol.Width = 100
    dgTableStyle.GridColumnStyles.Add(dgIntCol)
    ' Add CheckBox column using DataGridCoolColumn
    Dim dgBoolCol As DataGridColumnStyle = New DataGridBoolColumn()
    dgBoolCol.MappingName = "StillWorking"
    dgBoolCol.HeaderText = "Boolean Column"
    dgBoolCol.Width = 100
    dgTableStyle.GridColumnStyles.Add(dgBoolCol)
    ' Add table style to DataGrid
    dtGrid.TableStyles.Add(dgTableStyle)
  End Sub

  ' Create a DataSet with two tables and populate it.
  Private Sub CreateDataSet()
    ' Create a DataSet, add a DataTable
    ' Add DataTable to DataSet
    ds = New DataSet("ds")
    Dim EmployeeTable As DataTable = New DataTable("Employees")
    ' Create DataColumn objects and add to the DataTAable
    Dim dtType As System.Type
    dtType = System.Type.GetType("System.Int32")
    Dim EmpIDCol As DataColumn = _
    New DataColumn("EmployeeID", dtType)
    Dim EmpNameCol As DataColumn = New DataColumn("Name")
    dtType = System.Type.GetType("System.Boolean")
    Dim EmpStatusCol As DataColumn = New DataColumn("StillWorking", dtType)
    EmployeeTable.Columns.Add(EmpIDCol)
    EmployeeTable.Columns.Add(EmpNameCol)
    EmployeeTable.Columns.Add(EmpStatusCol)
    ' Add first records
    Dim row As DataRow = EmployeeTable.NewRow()
    row("EmployeeID") = 1001
    row("Name") = "Jay Leno"
    row("StillWorking") = False
    EmployeeTable.Rows.Add(row)
    ' Add second records
    row = EmployeeTable.NewRow()
    row("EmployeeID") = 1002
    row("Name") = "Peter Kurten"
    row("StillWorking") = True
    EmployeeTable.Rows.Add(row)
    ' Add third records
    row = EmployeeTable.NewRow()
    row("EmployeeID") = 1003
    row("Name") = "Mockes Pope"
    row("StillWorking") = False
    EmployeeTable.Rows.Add(row)
    ' Add fourth records
    row = EmployeeTable.NewRow()
    row("EmployeeID") = 1004
    row("Name") = "Rock Kalson"
    row("StillWorking") = True
    EmployeeTable.Rows.Add(row)
    ' Add the tables to the DataSet
    ds.Tables.Add(EmployeeTable)
  End Sub


  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    ' Create in memory DataSet. You can even create
    ' a DataSet from a database
    CreateDataSet()
    ' Bind DataSet to DataGrid 
    dtGrid.SetDataBinding(ds, "Employees")
    ' Fill data in DataGrid
    FillDataGrid()
  End Sub
End Class
