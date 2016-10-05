Imports System.Data
Imports System.Data.SqlClient

Public Class WebForm1
  Inherits System.Web.UI.Page
  Protected WithEvents ListBox1 As System.Web.UI.WebControls.ListBox
  Protected WithEvents LoadDataBtn As System.Web.UI.WebControls.Button
  Protected WithEvents GetSetBtn As System.Web.UI.WebControls.Button
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label

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
    'Put user code to initialize the page here
  End Sub

  Private Sub LoadDataBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles LoadDataBtn.Click
    Dim conn As SqlConnection = Nothing
    Dim adapter As SqlDataAdapter = Nothing
    Dim reader As SqlDataReader = Nothing
    Dim cmd As SqlCommand = Nothing
    Dim connectionString = _
    "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password=;"
    conn = New SqlConnection(connectionString)
    conn.Open()
    Dim sql = "SELECT * FROM Products"
    ' Use DataSet
    adapter = New SqlDataAdapter(sql, conn)
      Dim ds As DataSet = New DataSet()
      adapter.Fill(ds)
    ListBox1.DataSource = ds
    ListBox1.DataTextFormatString = "Unit Price: {0:C}"
    ListBox1.DataTextField = "UnitPrice"
    ListBox1.DataBind()
  End Sub

  Private Sub GetSetBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles GetSetBtn.Click
    Label1.Text = "Selected Item: " & _
       ListBox1.SelectedItem.Value
  End Sub

  Private Sub StringFormatsBtn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

  End Sub
End Class
