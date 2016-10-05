Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  Private ConnectionString As String = "Integrated Security=SSPI;" & _
 "Initial Catalog=Northwind;Data Source=MCB;"
  Private conn As SqlConnection = Nothing
  Private sql As String = Nothing
  Private adapter As SqlDataAdapter = Nothing
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
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents MoveFirstBtn As System.Windows.Forms.Button
  Friend WithEvents MovePreBtn As System.Windows.Forms.Button
  Friend WithEvents MoveNext As System.Windows.Forms.Button
  Friend WithEvents MoveLastBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.MoveFirstBtn = New System.Windows.Forms.Button()
    Me.MovePreBtn = New System.Windows.Forms.Button()
    Me.MoveNext = New System.Windows.Forms.Button()
    Me.MoveLastBtn = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 48)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(392, 200)
    Me.DataGrid1.TabIndex = 0
    '
    'MoveFirstBtn
    '
    Me.MoveFirstBtn.Location = New System.Drawing.Point(8, 16)
    Me.MoveFirstBtn.Name = "MoveFirstBtn"
    Me.MoveFirstBtn.Size = New System.Drawing.Size(72, 24)
    Me.MoveFirstBtn.TabIndex = 1
    Me.MoveFirstBtn.Text = "Move First"
    '
    'MovePreBtn
    '
    Me.MovePreBtn.Location = New System.Drawing.Point(80, 16)
    Me.MovePreBtn.Name = "MovePreBtn"
    Me.MovePreBtn.Size = New System.Drawing.Size(72, 24)
    Me.MovePreBtn.TabIndex = 2
    Me.MovePreBtn.Text = "Move Prev"
    '
    'MoveNext
    '
    Me.MoveNext.Location = New System.Drawing.Point(256, 16)
    Me.MoveNext.Name = "MoveNext"
    Me.MoveNext.Size = New System.Drawing.Size(72, 24)
    Me.MoveNext.TabIndex = 3
    Me.MoveNext.Text = "Move Next"
    '
    'MoveLastBtn
    '
    Me.MoveLastBtn.Location = New System.Drawing.Point(328, 16)
    Me.MoveLastBtn.Name = "MoveLastBtn"
    Me.MoveLastBtn.Size = New System.Drawing.Size(64, 24)
    Me.MoveLastBtn.TabIndex = 4
    Me.MoveLastBtn.Text = "Move Last"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(408, 253)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.MoveLastBtn, Me.MoveNext, Me.MovePreBtn, Me.MoveFirstBtn, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "DataGrid Navigation System"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region


  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    FillDataSet()

  End Sub

  ' Fill DataSEt
  Private Sub FillDataSet()
    ds = New DataSet()
    sql = "SELECT * FROM Employees"
    ds = New DataSet()
    conn = New SqlConnection()
    conn.ConnectionString = ConnectionString
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds)
    DataGrid1.DataSource = ds.Tables(0)
    ' conn.Close()
    ' conn.Dispose()
  End Sub

  Private Sub MovePreBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MovePreBtn.Click
    Dim idx As Int32 = _
       DataGrid1.BindingContext(Me.ds, "Employees").Position
    DataGrid1.BindingContext(Me.ds, "Employees").Position = idx - 1
  End Sub

  Private Sub MoveFirstBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveFirstBtn.Click
    Me.BindingContext(Me.ds, "Employees").Position = 0
  End Sub

  Private Sub MoveNext_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveNext.Click
    Dim idx As Int32 = _
       Me.BindingContext(Me.ds, "Employees").Position
    Me.BindingContext(Me.ds, "Employees").Position = idx + 1
  End Sub

  Private Sub MoveLastBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MoveLastBtn.Click
    Me.BindingContext(Me.ds, "Employees").Position = _
    Me.BindingContext(Me.ds, "Employees").Count - 1
  End Sub
End Class
