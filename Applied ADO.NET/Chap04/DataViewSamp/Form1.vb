Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  Private ConnectionString As String = "Integrated Security=SSPI;" & _
         "Initial Catalog=Northwind;Data Source=MCB;"
  Private conn As SqlConnection
  Private SQL As String = _
  "SELECT EmployeeID, CustomerID, ShipCity, ShipName FROM Orders"
  Private adapter As SqlDataAdapter
  Dim ds As DataSet = New DataSet()

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
  Friend WithEvents DataGrid2 As System.Windows.Forms.DataGrid
  Friend WithEvents LoadDataBtn As System.Windows.Forms.Button
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
  Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.DataGrid2 = New System.Windows.Forms.DataGrid()
    Me.LoadDataBtn = New System.Windows.Forms.Button()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.TextBox3 = New System.Windows.Forms.TextBox()
    Me.Label3 = New System.Windows.Forms.Label()
    Me.TextBox4 = New System.Windows.Forms.TextBox()
    Me.Label4 = New System.Windows.Forms.Label()
    Me.CheckBox1 = New System.Windows.Forms.CheckBox()
    Me.CheckBox2 = New System.Windows.Forms.CheckBox()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(184, 0)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(336, 152)
    Me.DataGrid1.TabIndex = 0
    '
    'DataGrid2
    '
    Me.DataGrid2.DataMember = ""
    Me.DataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid2.Location = New System.Drawing.Point(184, 152)
    Me.DataGrid2.Name = "DataGrid2"
    Me.DataGrid2.Size = New System.Drawing.Size(336, 160)
    Me.DataGrid2.TabIndex = 1
    '
    'LoadDataBtn
    '
    Me.LoadDataBtn.Location = New System.Drawing.Point(24, 280)
    Me.LoadDataBtn.Name = "LoadDataBtn"
    Me.LoadDataBtn.Size = New System.Drawing.Size(104, 24)
    Me.LoadDataBtn.TabIndex = 2
    Me.LoadDataBtn.Text = "Load Data"
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(24, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(144, 16)
    Me.Label1.TabIndex = 3
    Me.Label1.Text = "Filter Criteria: DataView1"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(24, 24)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(152, 20)
    Me.TextBox1.TabIndex = 4
    Me.TextBox1.Text = ""
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(24, 48)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(80, 16)
    Me.Label2.TabIndex = 5
    Me.Label2.Text = "Sort Column"
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(24, 64)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(152, 20)
    Me.TextBox2.TabIndex = 6
    Me.TextBox2.Text = ""
    '
    'TextBox3
    '
    Me.TextBox3.Location = New System.Drawing.Point(24, 168)
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Size = New System.Drawing.Size(152, 20)
    Me.TextBox3.TabIndex = 10
    Me.TextBox3.Text = ""
    '
    'Label3
    '
    Me.Label3.Location = New System.Drawing.Point(24, 192)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(80, 16)
    Me.Label3.TabIndex = 9
    Me.Label3.Text = "Sort Column"
    '
    'TextBox4
    '
    Me.TextBox4.Location = New System.Drawing.Point(24, 216)
    Me.TextBox4.Name = "TextBox4"
    Me.TextBox4.Size = New System.Drawing.Size(152, 20)
    Me.TextBox4.TabIndex = 8
    Me.TextBox4.Text = ""
    '
    'Label4
    '
    Me.Label4.Location = New System.Drawing.Point(24, 152)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(144, 16)
    Me.Label4.TabIndex = 7
    Me.Label4.Text = "Filter Criteria: DataView2"
    '
    'CheckBox1
    '
    Me.CheckBox1.Location = New System.Drawing.Point(24, 88)
    Me.CheckBox1.Name = "CheckBox1"
    Me.CheckBox1.Size = New System.Drawing.Size(112, 16)
    Me.CheckBox1.TabIndex = 11
    Me.CheckBox1.Text = "Descending"
    '
    'CheckBox2
    '
    Me.CheckBox2.Location = New System.Drawing.Point(24, 240)
    Me.CheckBox2.Name = "CheckBox2"
    Me.CheckBox2.Size = New System.Drawing.Size(112, 16)
    Me.CheckBox2.TabIndex = 12
    Me.CheckBox2.Text = "Descending"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(528, 317)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckBox2, Me.CheckBox1, Me.TextBox3, Me.Label3, Me.TextBox4, Me.Label4, Me.TextBox2, Me.Label2, Me.TextBox1, Me.Label1, Me.LoadDataBtn, Me.DataGrid2, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "DataView Sample"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataGrid2, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub LoadDataBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles LoadDataBtn.Click
    conn = New SqlConnection(ConnectionString)
    Try
      conn.Open()
      adapter = New SqlDataAdapter(SQL, conn)
      adapter.Fill(ds)
    Catch exp As SqlException
      exp.Message.ToString()
    End Try

    ' Create two DataView objects
    Dim dtView1 As DataView = New DataView(ds.Tables(0))
    Dim dtView2 As DataView = New DataView(ds.Tables(0))
    ' Set RowFilter and Sort proeprties of DataView1
    If (TextBox1.Text <> String.Empty) Then
      dtView1.RowFilter = TextBox1.Text
    End If
    Dim sortStr1 As String = TextBox2.Text
    If (sortStr1 <> String.Empty) Then
      If CheckBox1.Checked Then
        sortStr1 = sortStr1 + " DESC"
      Else
        sortStr1 = sortStr1 + " ASC"
      End If
      dtView1.Sort = sortStr1
    End If

    ' Set RowFilter and Sort proeprties of DataView2
    If (TextBox3.Text <> String.Empty) Then
      dtView2.RowFilter = TextBox3.Text
    End If
    Dim sortStr2 As String = TextBox4.Text
    If (sortStr2 <> String.Empty) Then
      If CheckBox2.Checked Then
        sortStr2 = sortStr2 + " DESC"
      Else
        sortStr2 = sortStr2 + " ASC"
      End If
      dtView2.Sort = sortStr2
    End If

    ' Bind both DataViews to two different DataGrids
    DataGrid1.DataSource = dtView1
    DataGrid2.DataSource = dtView2
    ' release objects
    conn.Close()
    conn.Dispose()
  End Sub
End Class
