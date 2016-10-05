Imports System.ComponentModel
Imports System.Data.SqlClient


Public Class Form1
  Inherits System.Windows.Forms.Form

  Dim ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
  Private conn As SqlConnection = Nothing
  Private adapter As SqlDataAdapter = Nothing
  Private ds As DataSet = Nothing
  Private dv As DataView
  Private curManager As CurrencyManager
  Private dsOrders As DataSet
  Private dsCustomers As DataSet



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
    Me.DataGrid1 = New System.Windows.Forms.DataGrid
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.AlternatingBackColor = System.Drawing.Color.White
    Me.DataGrid1.BackColor = System.Drawing.Color.White
    Me.DataGrid1.BackgroundColor = System.Drawing.Color.Ivory
    Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.DataGrid1.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
    Me.DataGrid1.CaptionForeColor = System.Drawing.Color.Lavender
    Me.DataGrid1.CaptionText = "DataGrid CaptionText"
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.FlatMode = True
    Me.DataGrid1.Font = New System.Drawing.Font("Tahoma", 8.0!)
    Me.DataGrid1.ForeColor = System.Drawing.Color.Black
    Me.DataGrid1.GridLineColor = System.Drawing.Color.Wheat
    Me.DataGrid1.HeaderBackColor = System.Drawing.Color.CadetBlue
    Me.DataGrid1.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
    Me.DataGrid1.HeaderForeColor = System.Drawing.Color.Black
    Me.DataGrid1.LinkColor = System.Drawing.Color.DarkSlateBlue
    Me.DataGrid1.Location = New System.Drawing.Point(16, 24)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.ParentRowsBackColor = System.Drawing.Color.Ivory
    Me.DataGrid1.ParentRowsForeColor = System.Drawing.Color.Black
    Me.DataGrid1.SelectionBackColor = System.Drawing.Color.Wheat
    Me.DataGrid1.SelectionForeColor = System.Drawing.Color.DarkSlateBlue
    Me.DataGrid1.Size = New System.Drawing.Size(384, 240)
    Me.DataGrid1.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(408, 277)
    Me.Controls.Add(Me.DataGrid1)
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    FillDataGrid()
    CreateNewDGTableStyle()
    'AddDataGridStyleMethod()
  End Sub

  Private Sub CreateNewDGTableStyle()
    Dim curManager As CurrencyManager
    Dim newTableStyle As DataGridTableStyle
    curManager = CType _
    (Me.BindingContext(ds, "Customers"), CurrencyManager)
    newTableStyle = New DataGridTableStyle(curManager)
    DataGrid1.TableStyles.Add(newTableStyle)
  End Sub

  Private Sub AddDataGridStyleMethod()
    ' Create a new DataGrudTableStyle
    Dim dgTableStyle As New DataGridTableStyle()
    dgTableStyle.MappingName = "Customers"
    dgTableStyle.BackColor = Color.Gray
    dgTableStyle.ForeColor = Color.Wheat
    dgTableStyle.AlternatingBackColor = Color.AliceBlue
    dgTableStyle.GridLineStyle = DataGridLineStyle.None
    ' Add some columns to the style 
    Dim boolCol As New DataGridBoolColumn()
    boolCol.MappingName = "boolCol"
    boolCol.HeaderText = "boolCol Text"
    boolCol.Width = 100
    ' Add column to GridColumnStyle
    dgTableStyle.GridColumnStyles.Add(boolCol)
    ' Text column
    Dim TextCol As New DataGridTextBoxColumn()
    TextCol.MappingName = "Name"
    TextCol.HeaderText = "Name Text"
    TextCol.Width = 200
    ' Add column to GridColumnStyle
    dgTableStyle.GridColumnStyles.Add(TextCol)
    ' Add DataGridTableStyle to the collection
    DataGrid1.TableStyles.Add(dgTableStyle)
  End Sub

  Private Sub FillDataGrid()
    ds = New DataSet()
    Dim ds1 As DataSet = New DataSet()
    Dim sql As String = "SELECT * FROM Customers"
    ds = New DataSet("Customers")
    conn = New SqlConnection()
    conn.ConnectionString = ConnectionString
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds1, "Customers")
    Dim ds2 As DataSet = New DataSet("Orders")
    sql = "SELECT * FROM Orders"
    adapter.Fill(ds2, "Orders")
    ds1.Merge(ds2)
    ds = ds1.Copy()
    DataGrid1.DataSource = ds1.DefaultViewManager
  End Sub


End Class
