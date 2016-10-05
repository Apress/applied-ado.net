Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  ' Developer defined variables
  Private conn As SqlConnection = Nothing
  Private ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
  Private sql As String = Nothing
  Private ds As DataSet = Nothing
  Private adapter As SqlDataAdapter = Nothing



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
  Friend WithEvents ExchangeColsBtn As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents GetInfoBtn As System.Windows.Forms.Button
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.ExchangeColsBtn = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.GetInfoBtn = New System.Windows.Forms.Button()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 88)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(384, 240)
    Me.DataGrid1.TabIndex = 0
    '
    'ExchangeColsBtn
    '
    Me.ExchangeColsBtn.Location = New System.Drawing.Point(24, 8)
    Me.ExchangeColsBtn.Name = "ExchangeColsBtn"
    Me.ExchangeColsBtn.Size = New System.Drawing.Size(120, 32)
    Me.ExchangeColsBtn.TabIndex = 1
    Me.ExchangeColsBtn.Text = "Exchange Columns"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 48)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(56, 16)
    Me.Label1.TabIndex = 2
    Me.Label1.Text = "Column 1:"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(72, 48)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(56, 20)
    Me.TextBox1.TabIndex = 3
    Me.TextBox1.Text = ""
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(144, 48)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(72, 16)
    Me.Label2.TabIndex = 4
    Me.Label2.Text = "Column 2:"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(208, 48)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(48, 20)
    Me.TextBox2.TabIndex = 5
    Me.TextBox2.Text = ""
    '
    'GetInfoBtn
    '
    Me.GetInfoBtn.Location = New System.Drawing.Point(336, 16)
    Me.GetInfoBtn.Name = "GetInfoBtn"
    Me.GetInfoBtn.Size = New System.Drawing.Size(184, 32)
    Me.GetInfoBtn.TabIndex = 6
    Me.GetInfoBtn.Text = "Get Grid Columns and Tables Info"
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(392, 88)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(152, 238)
    Me.ListBox1.TabIndex = 7
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(552, 333)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1, Me.GetInfoBtn, Me.TextBox2, Me.Label2, Me.TextBox1, Me.Label1, Me.ExchangeColsBtn, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "DataGridTableStyle and DataGridColumnStyle Sample"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub FillDataGrid()
    sql = "SELECT * FROM Customers"
    conn = New SqlConnection(connectionString)
    adapter = New SqlDataAdapter(sql, conn)
    ds = New DataSet("Customers")
    adapter.Fill(ds, "Customers")
    DataGrid1.DataSource = ds.Tables(0).DefaultView
    ' By default there is no DataGridTableStyle object.
    ' Add all DataSet table's style to the DataGrid
    Dim dTable As DataTable
    For Each dTable In ds.Tables
      Dim dgStyle As DataGridTableStyle = New DataGridTableStyle()
      dgStyle.MappingName = dTable.TableName
      DataGrid1.TableStyles.Add(dgStyle)
    Next
    ' DataGrid settings
    DataGrid1.CaptionText = "DataGrid Customization"
    DataGrid1.HeaderFont = New Font("Verdana", 12)
  End Sub

  Private Sub ExchangeColsBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ExchangeColsBtn.Click
    If (TextBox1.Text.Length < 1) Then
      MessageBox.Show("Enter a number between 0 to 19")
      TextBox1.Focus()
      Return
    ElseIf (TextBox2.Text.Length < 1) Then
      MessageBox.Show("Enter a number between 0 to 19")
      TextBox1.Focus()
      Return
    End If
    ' Get column 1 and column 2 indexes
    Dim col1 As Integer = Convert.ToInt32(TextBox1.Text)
    Dim col2 As Integer = Convert.ToInt32(TextBox2.Text)
    ' Exchange columns
    ReshuffleColumns(col1, col2, "Customers", DataGrid1)
  End Sub

  Private Sub ReshuffleColumns(ByVal col1 As Integer, _
  ByVal col2 As Integer, ByVal mapName As String, ByVal grid As DataGrid)
    Dim existingTableStyle As DataGridTableStyle = grid.TableStyles(mapName)
    Dim counter As Integer = existingTableStyle.GridColumnStyles.Count
    Dim NewTableStyle As DataGridTableStyle = New DataGridTableStyle()
    NewTableStyle.MappingName = mapName
    Dim i As Integer
    For i = 0 To counter - 1 Step +1
      If i <> col1 And col1 < col2 Then
        NewTableStyle.GridColumnStyles.Add _
        (existingTableStyle.GridColumnStyles(i))
      End If
      If i = col2 Then
        NewTableStyle.GridColumnStyles.Add _
        (existingTableStyle.GridColumnStyles(col1))
      End If
      If i <> col1 And col1 > col2 Then
        NewTableStyle.GridColumnStyles.Add _
        (existingTableStyle.GridColumnStyles(i))
      End If
    Next
    ' Remove the existing table style and add new style
    grid.TableStyles.Remove(existingTableStyle)
    grid.TableStyles.Add(NewTableStyle)
  End Sub


  Private Sub GetInfoBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles GetInfoBtn.Click
    Dim infoStr As String = "Visible Rows: " + _
    DataGrid1.VisibleRowCount.ToString()
    ListBox1.Items.Add(infoStr)
    infoStr = "Visible Cols: " + _
    DataGrid1.VisibleColumnCount.ToString()
    ListBox1.Items.Add(infoStr)
    infoStr = "Total Rows: " + _
    ds.Tables(0).Rows.Count.ToString()
    ListBox1.Items.Add(infoStr)
    infoStr = "Total Cols: " + _
    ds.Tables(0).Columns.Count.ToString()
    ListBox1.Items.Add(infoStr)
    ' Get all table styles in the Grid and Column Styles
    ' which returns table and column names
    Dim gridStyle As DataGridTableStyle
    For Each gridStyle In DataGrid1.TableStyles
      infoStr = "Table Name: " + gridStyle.MappingName
      ListBox1.Items.Add(infoStr)
      Dim colStyle As DataGridColumnStyle
      For Each colStyle In gridStyle.GridColumnStyles
        infoStr = "Column: " + colStyle.MappingName
        ListBox1.Items.Add(infoStr)
      Next
    Next

  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    FillDataGrid()
  End Sub

  Private Sub DataGrid1_MouseDown(ByVal sender As Object, _
  ByVal e As System.Windows.Forms.MouseEventArgs) Handles DataGrid1.MouseDown

    Dim str As String = Nothing
    Dim pt As Point = New Point(e.X, e.Y)
    Dim hti As DataGrid.HitTestInfo = DataGrid1.HitTest(pt)
    ' If right mouse button clicked
    If e.Button = MouseButtons.Right Then
      If hti.Type = DataGrid.HitTestType.ColumnHeader Then
        Dim gridStyle As DataGridTableStyle = _
        DataGrid1.TableStyles("Customers")
        str = gridStyle.GridColumnStyles(hti.Column).MappingName.ToString()
        MessageBox.Show("Column Header " + str)
      End If
    End If
    ' If left mouse button clicked
    If e.Button = MouseButtons.Left Then
      If hti.Type = DataGrid.HitTestType.Cell Then
        str = "Column: " + hti.Column.ToString()
        str += ", Row: " + hti.Row.ToString()
        MessageBox.Show(str)
      End If
    End If
  End Sub
End Class
