Imports Microsoft.Data.Odbc

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
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataGrid1 = New System.Windows.Forms.DataGrid()
    Me.ListBox1 = New System.Windows.Forms.ListBox()
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'DataGrid1
    '
    Me.DataGrid1.DataMember = ""
    Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
    Me.DataGrid1.Location = New System.Drawing.Point(8, 8)
    Me.DataGrid1.Name = "DataGrid1"
    Me.DataGrid1.Size = New System.Drawing.Size(304, 264)
    Me.DataGrid1.TabIndex = 0
    '
    'ListBox1
    '
    Me.ListBox1.Location = New System.Drawing.Point(328, 16)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(120, 225)
    Me.ListBox1.TabIndex = 1
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(456, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.ListBox1, Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    ' Connection string for ODBC Excel Driver    
    Dim ConnectionString As String = _
    "Driver={Microsoft Excel Driver (*.xls)};DBQ=c:\\Employees.xls"
    Dim conn As OdbcConnection = New OdbcConnection(ConnectionString)
    ' Tables in Excel can be thought of as sheets and are queried as shown
    Dim sql As String = "Select EmployeeID, FirstName, LastName FROM Employees"
    conn.Open()
    Dim da As OdbcDataAdapter = New OdbcDataAdapter(sql, conn)
    Dim ds As DataSet = New DataSet()
    da.Fill(ds, "Employees")
    DataGrid1.DataSource = ds.DefaultViewManager
    ListBox1.DataSource = ds.DefaultViewManager
    ListBox1.DisplayMember = "Employees.FirstName"
  End Sub
End Class
