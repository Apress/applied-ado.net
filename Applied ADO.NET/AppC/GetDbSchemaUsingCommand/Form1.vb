Imports System.Data.SqlClient
Imports System.Object

Public Class Form1
  Inherits System.Windows.Forms.Form

  Shared str As String = Nothing
  Shared sql As String = Nothing
  Shared connectionString As String = _
  "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password="
  Shared conn As SqlConnection = Nothing
  Shared adapter As SqlDataAdapter = Nothing
  Shared ds As DataSet = Nothing


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
  Friend WithEvents LoadSchemaBtn As System.Windows.Forms.Button
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents GetTablesBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.LoadSchemaBtn = New System.Windows.Forms.Button()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    Me.GetTablesBtn = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'LoadSchemaBtn
    '
    Me.LoadSchemaBtn.Location = New System.Drawing.Point(288, 24)
    Me.LoadSchemaBtn.Name = "LoadSchemaBtn"
    Me.LoadSchemaBtn.Size = New System.Drawing.Size(120, 24)
    Me.LoadSchemaBtn.TabIndex = 1
    Me.LoadSchemaBtn.Text = "Load Schema"
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(136, 64)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(280, 192)
    Me.DataGrid1.TabIndex = 2
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(16, 56)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(88, 199)
    Me.ListBox1.TabIndex = 0
    '
    'GetTablesBtn
    '
    Me.GetTablesBtn.Location = New System.Drawing.Point(24, 16)
    Me.GetTablesBtn.Name = "GetTablesBtn"
    Me.GetTablesBtn.Size = New System.Drawing.Size(104, 24)
    Me.GetTablesBtn.TabIndex = 3
    Me.GetTablesBtn.Text = "Get Tables"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(440, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GetTablesBtn, Me.DataGrid1, Me.LoadSchemaBtn, Me.ListBox1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub LoadSchemaBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles LoadSchemaBtn.Click
    conn = New SqlConnection(connectionString)
    conn.Open()
    sql = "SELECT * FROM Employees"
    Dim cmd As SqlCommand = New SqlCommand(sql, conn)
    Dim reader As IDataReader = _
    cmd.ExecuteReader(CommandBehavior.SchemaOnly)
    Dim schemaTable As DataTable = New DataTable()
    schemaTable = reader.GetSchemaTable
    DataGrid1.DataSource = schemaTable
    Dim rowCollection As DataRowCollection = _
    reader.GetSchemaTable().Rows
    Dim row As DataRow
    For Each row In rowCollection
      str = row("ColumnName")
      ListBox1.Items.Add(str)
    Next

    conn.Close()

  End Sub

  Private Sub GetTablesBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles GetTablesBtn.Click
    conn = New SqlConnection(connectionString)
    conn.Open()
    sql = "SELECT * FROM sysobjects"
    Dim cmd As SqlCommand = New SqlCommand(sql, conn)
    Dim reader As SqlDataReader = _
    cmd.ExecuteReader()
    While reader.Read()

    End While
    conn.Close()
  End Sub
End Class

