Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

  ' Developer defined variables
  Shared conn As SqlConnection = Nothing
  Shared connectionString As String = _
   "Integrated Security=SSPI;Initial Catalog=Northwind;Data Source=MCB;"
  Shared sql As String = Nothing
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
  Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
  Friend WithEvents SaveBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.SaveBtn = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 32)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(432, 232)
    Me.DataGrid1.TabIndex = 0
    '
    'SaveBtn
    '
    Me.SaveBtn.Location = New System.Drawing.Point(32, 272)
    Me.SaveBtn.Name = "SaveBtn"
    Me.SaveBtn.Size = New System.Drawing.Size(104, 32)
    Me.SaveBtn.TabIndex = 1
    Me.SaveBtn.Text = "Save Changes"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(448, 309)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.SaveBtn, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Select, Insert, Update, and Delete Database Operations"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  ' Form load
  Private Sub Form1_Load(ByVal sender As System.Object, _
ByVal e As System.EventArgs) Handles MyBase.Load
    FillDataGrid()
  End Sub

  ' Fill DataGrid
  Private Sub FillDataGrid()
    sql = "SELECT * FROM Orders"
    Dim ds1 As DataSet = GetDataSet(connectionString, sql)
    DataGrid1.DataSource = ds1.DefaultViewManager
  End Sub

  ' Method used to return data as a DataSet
  Public Function GetDataSet(ByVal connStr As String, _
  ByVal sql As String) As DataSet
    If (connStr.Equals(String.Empty) Or sql.Equals(String.Empty)) Then
      Return Nothing
    End If
    conn = New SqlConnection(connStr)
    ' Open connection if already not open
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    ds = New DataSet()
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds)
    ' Close and dispose connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
      conn.Dispose()
    End If
    Return ds
  End Function

  Private Sub SaveBtn_Click_1(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles SaveBtn.Click
    ' Find out changes 
    Dim changedDS As DataSet = New DataSet()
    ' Data is modified
    If (ds.HasChanges(DataRowState.Modified)) Then
      changedDS = ds.GetChanges(DataRowState.Modified)
      SaveChanges(changedDS)
    End If
    ' Data is deleted
    If (ds.HasChanges(DataRowState.Deleted)) Then
      changedDS = ds.GetChanges(DataRowState.Deleted)
      SaveChanges(changedDS)
    End If
    ' Data is added
    If (ds.HasChanges(DataRowState.Added)) Then
      changedDS = ds.GetChanges(DataRowState.Added)
      SaveChanges(changedDS)
    End If
  End Sub

  ' Save Changes method
  Private Sub SaveChanges(ByVal changedDS As DataSet)
    ' Open connection if already not open
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    ' Data is modified
    Dim changedRecords As Integer
    changedRecords = adapter.Update(changedDS, "Orders")
    If (changedRecords > 0) Then
      MessageBox.Show(changedRecords.ToString() & _
      " records affected.")
    End If
    ' Accept changes and refresh the DataGrid
    ds.AcceptChanges()
    ' Close and dispose connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
      conn.Dispose()
    End If
  End Sub

End Class
