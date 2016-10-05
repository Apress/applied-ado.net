Imports System.Data.SqlClient

Public Class WebForm1
  Inherits System.Web.UI.Page
  Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
  Protected WithEvents ListBox1 As System.Web.UI.WebControls.ListBox

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
    Dim ConnectionString As String = "user id=sa;password=;" & _
      "Initial Catalog=Northwind;" & _
      "Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Open the connection
    If (conn.State <> ConnectionState.Open) Then
      conn.Open()
    End If
    Dim adapter As SqlDataAdapter = New SqlDataAdapter _
    ("SELECT EmployeeID, LastName, FirstName FROM Employees", conn)
    Dim ds As DataSet = New DataSet()
    adapter.Fill(ds, "Employees")
    ' Bind data set to the control
    ' Set DataSource property of ListBox as DataSet’s DefaultView
    ListBox1.DataSource = ds
    ListBox1.SelectedIndex = 0
    ' Set Field Name you want to get data from
    ListBox1.DataTextField = "FirstName"
    'DataGrid1.DataSource = ds.DefaultViewManager
    DataGrid1.DataSource = ds
    ' DataGrid1.DataBind()
    DataBind()
    '  Close the connection
    If (conn.State = ConnectionState.Open) Then
      conn.Close()
    End If

  End Sub

End Class
