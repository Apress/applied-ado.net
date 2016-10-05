Imports System.Data
Imports System.Data.SqlClient

Public Class WebForm1
  Inherits System.Web.UI.Page
  Protected WithEvents Repeater1 As System.Web.UI.WebControls.Repeater
  Protected WithEvents dtList As System.Web.UI.WebControls.DataList

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
    If Not IsPostBack Then
      FillDataList()
    End If
  End Sub

  Sub FillDataList()
    Dim conn As SqlConnection
    Dim adapter As SqlDataAdapter
    Dim connectionString = _
    "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password=;"
    conn = New SqlConnection(connectionString)
    conn.Open()
    Dim sql = "SELECT CategoryID, CategoryName FROM Categories"
    adapter = New SqlDataAdapter(sql, conn)
    Dim ds As DataSet = New DataSet()
    adapter.Fill(ds)
    dtList.DataSource = ds
    dtList.DataBind()
  End Sub

  Private Sub dtList_ItemCommand(ByVal source As Object, _
  ByVal e As System.Web.UI.WebControls.DataListCommandEventArgs) _
  Handles dtList.ItemCommand
    Dim id As Integer
    dtList.SelectedIndex = e.Item.ItemIndex
    FillDataList()
    id = dtList.DataKeys(e.Item.ItemIndex)
    BindRepeater(id)
  End Sub

  Private Sub BindRepeater(ByVal id As Integer)
    Dim conn As SqlConnection
    Dim reader As SqlDataReader
    Dim connectionString = _
    "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password=;"
    conn = New SqlConnection(connectionString)
    conn.Open()
    Dim sql = "SELECT ProductName FROM Products WHERE CategoryID=@catID"
    Dim cmd As SqlCommand = New SqlCommand()
    cmd.Connection = conn
    cmd.CommandText = sql
    cmd.Parameters.Add("@catID", id)
    reader = cmd.ExecuteReader()
    dtList.DataSource = reader
    dtList.DataBind()
  End Sub

End Class
