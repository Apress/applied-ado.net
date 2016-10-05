Imports System.Data.OleDb

Public Class Form1
  Inherits System.Windows.Forms.Form

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
  Friend WithEvents DataSetCount As System.Windows.Forms.Button
  Friend WithEvents DataReaderCount As System.Windows.Forms.Button
  Friend WithEvents DistinctRows As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.DataSetCount = New System.Windows.Forms.Button()
    Me.DataReaderCount = New System.Windows.Forms.Button()
    Me.DistinctRows = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 48)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(368, 224)
    Me.DataGrid1.TabIndex = 0
    '
    'DataSetCount
    '
    Me.DataSetCount.Location = New System.Drawing.Point(8, 8)
    Me.DataSetCount.Name = "DataSetCount"
    Me.DataSetCount.Size = New System.Drawing.Size(104, 24)
    Me.DataSetCount.TabIndex = 1
    Me.DataSetCount.Text = "DataSet Count"
    '
    'DataReaderCount
    '
    Me.DataReaderCount.Location = New System.Drawing.Point(120, 8)
    Me.DataReaderCount.Name = "DataReaderCount"
    Me.DataReaderCount.Size = New System.Drawing.Size(136, 24)
    Me.DataReaderCount.TabIndex = 2
    Me.DataReaderCount.Text = "DataReader Count"
    '
    'DistinctRows
    '
    Me.DistinctRows.Location = New System.Drawing.Point(264, 8)
    Me.DistinctRows.Name = "DistinctRows"
    Me.DistinctRows.Size = New System.Drawing.Size(112, 24)
    Me.DistinctRows.TabIndex = 3
    Me.DistinctRows.Text = "Distinct Rows"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(384, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DistinctRows, Me.DataReaderCount, Me.DataSetCount, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub DataReaderCount_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles DataReaderCount.Click

    ' Connection string
    Dim strDSN As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    "Data Source=C:\\Northwind.mdb"
    ' Create a connection and open it
    Dim conn As OleDbConnection = New OleDbConnection(strDSN)
    Try
      conn.Open()
      Dim cmd As OleDbCommand = _
      New OleDbCommand("SELECT Count(*) FROM Orders", conn)
      Dim counter As Integer = CInt(cmd.ExecuteScalar())
      MessageBox.Show(counter.ToString())
    Catch exp As Exception
      MessageBox.Show(exp.Message.ToString())
    Finally
      ' Close the connection
      conn.Close()
      conn.Dispose()
    End Try
  End Sub

  Private Sub DistinctRows_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles DistinctRows.Click
    ' Connection string
    Dim strDSN As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    "Data Source=C:\\Northwind.mdb"
    ' Create a connection and open it
    Dim conn As OleDbConnection = New OleDbConnection(strDSN)
    Try
      conn.Open()
      ' Call GetOleDbSchemaTable to get the schema data table
      Dim sql As String = "SELECT DISTINCT(LastName)" & _
            "FROM Employees ORDER BY LastName"
      Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(sql, conn)
      Dim ds As DataSet = New DataSet()
      adapter.Fill(ds, "Employees")
      DataGrid1.DataSource = ds.DefaultViewManager
    Catch exp As Exception
      MessageBox.Show(exp.Message.ToString())
    Finally
      ' Close the connection
      conn.Close()
      conn.Dispose()
    End Try
  End Sub

  Private Sub DataSetCount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataSetCount.Click
    ' Connection string
    Dim strDSN As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    "Data Source=C:\\Northwind.mdb"
    ' Create a connection and open it
    Dim conn As OleDbConnection = New OleDbConnection(strDSN)
    Try
      conn.Open()
      ' Call GetOleDbSchemaTable to get the schema data table
      Dim sql As String = "SELECT * FROM Orders"
      Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(sql, conn)
      Dim ds As DataSet = New DataSet()
      adapter.Fill(ds, "Employees")
      Dim counter As Integer = ds.Tables(0).Rows.Count
      MessageBox.Show(counter.ToString())
    Catch exp As Exception
      MessageBox.Show(exp.Message.ToString())
    Finally
      ' Close the connection
      conn.Close()
      conn.Dispose()
    End Try
  End Sub
End Class
