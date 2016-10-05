Imports ADOX

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
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 273)
    Me.Name = "Form1"
    Me.Text = "Form1"

  End Sub

#End Region

  Private Sub Form1_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    ' Create SQL and Connection strings
    Dim ConnectionString As String = _
    "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\\Test.mdb"
    Try
      ' Create a Catalog object 
      Dim ct As Catalog = New Catalog()
      ct.Create(ConnectionString)
      ' Create a table and two columns
      Dim dt As Table = New Table()
      dt.Name = "MyTable"
      dt.Columns.Append("col1", DataTypeEnum.adInteger, 4)
      dt.Columns.Append("col2", DataTypeEnum.adVarWChar, 255)
      ' Add table to the tables collection
      ct.Tables.Append(CType(dt, Object))
    Catch exp As Exception
      MessageBox.Show(exp.Message.ToString())
    End Try
  End Sub
End Class
