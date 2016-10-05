Imports System.Data
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
  Friend WithEvents ReadBtn As System.Windows.Forms.Button
  Friend WithEvents WriteBtn As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.ReadBtn = New System.Windows.Forms.Button()
    Me.WriteBtn = New System.Windows.Forms.Button()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 48)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(312, 216)
    Me.DataGrid1.TabIndex = 0
    '
    'ReadBtn
    '
    Me.ReadBtn.Location = New System.Drawing.Point(8, 8)
    Me.ReadBtn.Name = "ReadBtn"
    Me.ReadBtn.Size = New System.Drawing.Size(112, 24)
    Me.ReadBtn.TabIndex = 1
    Me.ReadBtn.Text = "Read DiffGram"
    '
    'WriteBtn
    '
    Me.WriteBtn.Location = New System.Drawing.Point(152, 8)
    Me.WriteBtn.Name = "WriteBtn"
    Me.WriteBtn.Size = New System.Drawing.Size(112, 23)
    Me.WriteBtn.TabIndex = 2
    Me.WriteBtn.Text = "Write DiffGrams"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(328, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.WriteBtn, Me.ReadBtn, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub ReadBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ReadBtn.Click

    Dim connectionString As String = _
      "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\\Northwind.mdb"
    Dim sql As String = _
      "SELECT EmployeeID, FirstName, LastName, Title FROM Employees"
    Dim conn As OleDbConnection = Nothing
    Dim ds As DataSet = Nothing
    ' Create and open connection
    conn = New OleDbConnection(connectionString)
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    ' Create a data adapter
    Dim adapter As OleDbDataAdapter = New OleDbDataAdapter(sql, conn)
    ' Create and fill a DataSet
    ds = New DataSet("TempDtSet")
    adapter.Fill(ds, "DtSet")
    ' Write XML in DiffGram format
    ds.WriteXml("DiffGramFile.xml", XmlWriteMode.DiffGram)
    ' Close connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
    End If
    MessageBox.Show("Done")
  End Sub

  Private Sub WriteBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles WriteBtn.Click
    '  Create a DataSet Object
    Dim ds As DataSet = New DataSet()
    ' Fill with the data
    ds.ReadXml("DiffGramFile.xml", XmlReadMode.DiffGram)

  End Sub
End Class
