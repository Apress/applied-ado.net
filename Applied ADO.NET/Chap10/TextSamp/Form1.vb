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
    Me.DataGrid1.Size = New System.Drawing.Size(352, 248)
    Me.DataGrid1.TabIndex = 0
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(360, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataGrid1})
    Me.Name = "Form1"
    Me.Text = "Form1"
    CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub DataGrid1_Navigate(ByVal sender As System.Object, ByVal ne As System.Windows.Forms.NavigateEventArgs) Handles DataGrid1.Navigate
    
  End Sub

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    ' Connection string for a Text File
    Dim connectionString As String = _
    "Driver={Microsoft Text Driver (*.txt; *.csv)};DBQ=c:\\"
    ' Query the Employees.txt file as a table
    'Dim conn As OdbcConnection = New OdbcConnection("DSN=TxtDSN")
    Dim conn As OdbcConnection = New OdbcConnection(connectionString)
    conn.Open()
    ' Create a data adapter and fill a DataSet
    Dim da As OdbcDataAdapter = New OdbcDataAdapter _
    ("Select * FROM Employees.txt", conn)
    Dim ds As DataSet = New DataSet()
    da.Fill(ds, "TextDB")
    ' Bind the DataSet to a DataGrid
    DataGrid1.DataSource = ds.DefaultViewManager
    ' Close the connection
    conn.Close()
    conn.Dispose();

  End Sub
End Class
