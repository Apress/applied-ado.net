Imports System.Data.OleDb

Public Class ViewGuestBook
  Inherits System.Web.UI.Page
  Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
  Protected WithEvents Button1 As System.Web.UI.WebControls.Button

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

  End Sub

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    ' Create a connection object 
    Dim conn As OleDbConnection = New OleDbConnection()
    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
                "Data Source=C:\\GuestBook.mdb"
    Dim sql As String = "SELECT * FROM Guest"
    ' Create a data adapter
    Dim da As OleDbDataAdapter = New OleDbDataAdapter(sql, conn)
    ' Create and fill data set and bind it to the data grid
    Dim ds As DataSet = New DataSet()
    da.Fill(ds, "Guest")
    DataGrid1.DataSource = ds.Tables("Guest").DefaultView
    DataGrid1.DataBind()
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles Button1.Click
    Response.Redirect("http://www.c-sharpcorner.com")
  End Sub
End Class
