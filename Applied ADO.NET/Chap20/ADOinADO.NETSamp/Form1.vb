Imports ADODB
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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 16)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(320, 248)
    Me.DataGrid1.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(336, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    ' Create SQL and Connection strings
    Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    "Data Source=c:\\Northwind.mdb"
    Dim sql As String = "SELECT CustomerId, CompanyName, ContactName From Customers"
    ' Create a Connection object and open it
    Dim conn As Connection = New Connection()
    Dim connMode As Integer = CType(ConnectModeEnum.adModeUnknown, Integer)
    conn.CursorLocation = CursorLocationEnum.adUseServer
    conn.Open(ConnectionString, "", "", connMode)
    Dim recAffected As Object = Nothing
    Dim cmdType As Integer = CType(CommandTypeEnum.adCmdText, Integer)
    Dim rs As _Recordset = conn.Execute(sql, recAffected, cmdType)
    ' Create dataset and data adpater objects 
    Dim ds As DataSet = New DataSet("Recordset")
    Dim da As OleDbDataAdapter = New OleDbDataAdapter()
    ' Call data adapter's Fill method to fill data from ADO
    ' Recordset to the dataset
    da.Fill(ds, rs, "Customers")
    ' Now use dataset
    DataGrid1.DataSource = ds.DefaultViewManager
  End Sub
End Class
