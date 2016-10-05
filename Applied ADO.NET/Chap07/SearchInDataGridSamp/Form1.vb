Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  ' Developer defined variables
  Private conn As SqlConnection = Nothing
  Private connectionString As String = _
   "Integrated Security=SSPI;Initial Catalog=Northwind;Data Source=MCB;"
  Private sql As String = Nothing
  Private searchView As DataView = Nothing
  Dim adapter As SqlDataAdapter = Nothing
  Dim ds As DataSet = Nothing


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
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents SearchBtn As System.Windows.Forms.Button
  Friend WithEvents SaveBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.Label1 = New System.Windows.Forms.Label()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.TextBox1 = New System.Windows.Forms.TextBox()
    Me.TextBox2 = New System.Windows.Forms.TextBox()
    Me.SearchBtn = New System.Windows.Forms.Button()
    Me.SaveBtn = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 72)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(416, 216)
    Me.DataGrid1.TabIndex = 0
    '
    'Label1
    '
    Me.Label1.Location = New System.Drawing.Point(16, 8)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(112, 24)
    Me.Label1.TabIndex = 1
    Me.Label1.Text = "Column Name:"
    '
    'Label2
    '
    Me.Label2.Location = New System.Drawing.Point(16, 32)
    Me.Label2.Name = "Label2"
    Me.Label2.TabIndex = 2
    Me.Label2.Text = "Value:"
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(120, 8)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(184, 20)
    Me.TextBox1.TabIndex = 3
    Me.TextBox1.Text = ""
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(120, 40)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(184, 20)
    Me.TextBox2.TabIndex = 4
    Me.TextBox2.Text = ""
    '
    'SearchBtn
    '
    Me.SearchBtn.Location = New System.Drawing.Point(336, 24)
    Me.SearchBtn.Name = "SearchBtn"
    Me.SearchBtn.Size = New System.Drawing.Size(88, 32)
    Me.SearchBtn.TabIndex = 5
    Me.SearchBtn.Text = "Search"
    '
    'SaveBtn
    '
    Me.SaveBtn.Location = New System.Drawing.Point(40, 304)
    Me.SaveBtn.Name = "SaveBtn"
    Me.SaveBtn.Size = New System.Drawing.Size(112, 32)
    Me.SaveBtn.TabIndex = 6
    Me.SaveBtn.Text = "Save Changes"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(432, 341)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.SaveBtn, Me.SearchBtn, Me.TextBox2, Me.TextBox1, Me.Label2, Me.Label1, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Searching in a DataGrid"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  ' Fill DataGrid
  Private Sub FillDataGrid()
    sql = "SELECT * FROM Orders"
    conn = New SqlConnection(connectionString)
    adapter = New SqlDataAdapter(sql, conn)
    ds = New DataSet("Orders")
    adapter.Fill(ds, "Orders")
    DataGrid1.DataSource = ds.Tables("Orders")
    searchView = New DataView(ds.Tables("Orders"))
    Dim cmdBuilder As SqlCommandBuilder = _
    New SqlCommandBuilder(adapter)
    ' Disconnect. Otherwise you would get 
    ' Access violations when try multiple operations
    conn.Close()
    conn.Dispose()
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    FillDataGrid()
  End Sub

  Private Sub SearchBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles SearchBtn.Click
    If (TextBox1.Text.Equals(String.Empty)) Then
      MessageBox.Show("Enter a column name")
      TextBox1.Focus()
      Return
    End If
    If (TextBox2.Text.Equals(String.Empty)) Then
      MessageBox.Show("Enter a value")
      TextBox1.Focus()
      Return
    End If
    ' Construct a row filter and apply on the DataView
    Dim str As String = TextBox1.Text + "=" + TextBox2.Text
    searchView.RowFilter = str
    ' Set DataView as DataSource of DataGrid
    DataGrid1.DataSource = searchView
  End Sub

  Private Sub SaveBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles SaveBtn.Click

    Dim changeDS As DataSet = New DataSet()
    ' Data is modified
    If (ds.HasChanges(DataRowState.Modified)) Then
      changeDS = ds.GetChanges(DataRowState.Modified)
      Dim changedRecords As Integer
      changedRecords = adapter.Update(changeDS, "Orders")
      If (changedRecords > 0) Then
        MessageBox.Show(changedRecords.ToString() & _
        " records modified.")
      End If
    End If
    ' Data is deleted
    If (ds.HasChanges(DataRowState.Deleted)) Then
      changeDS = ds.GetChanges(DataRowState.Deleted)
      Dim changedRecords As Integer
      changedRecords = adapter.Update(changeDS, "Orders")
      If (changedRecords > 0) Then
        MessageBox.Show(changedRecords.ToString() & _
        " records deleted.")
      End If
    End If
    ' Data is added
    If (ds.HasChanges(DataRowState.Added)) Then
      changeDS = ds.GetChanges(DataRowState.Added)
      Dim changedRecords As Integer
      changedRecords = adapter.Update(changeDS, "Orders")
      If (changedRecords > 0) Then
        MessageBox.Show(changedRecords.ToString() & _
        " records added.")
      End If
    End If
    ds.AcceptChanges()
    DataGrid1.Refresh()
  End Sub
End Class
