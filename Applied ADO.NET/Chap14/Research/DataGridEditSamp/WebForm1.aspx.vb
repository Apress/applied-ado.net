Imports System.Data
Imports System.Data.SqlClient
Imports System.Text
Imports System.Web.Services.Description


Public Class WebForm1
  Inherits System.Web.UI.Page
  Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid
  Protected WithEvents CheckBox1 As System.Web.UI.WebControls.CheckBox
  Protected WithEvents SearchBtn As System.Web.UI.WebControls.Button

  Private ConnectionString As String = "user id=sa;password=;" & _
   "Initial Catalog=Northwind;" & _
   "Data Source=MCB;"
  Private conn As SqlConnection = Nothing
  Private sql As String = Nothing
  Private sortExp As String = Nothing
  Protected WithEvents SearchFieldList As System.Web.UI.WebControls.DropDownList
  Protected WithEvents SearchBox As System.Web.UI.WebControls.TextBox
  Private searchExp As String = Nothing
  Private searchMode As Boolean = False

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
    ' Default Sort Item
    sortExp = "EmployeeID"
    conn = New SqlConnection(ConnectionString)
    If (Not IsPostBack) Then
      ' Add Items to Search Combo Box
      AddSearchItems()
      FillDataGrid(sortExp, True)
    End If
  End Sub

  Private Sub AddSearchItems()
    SearchFieldList.Items.Add("EmployeeID")
    SearchFieldList.Items.Add("FirstName")
    SearchFieldList.Items.Add("LastName")
    SearchFieldList.Items.Add("Title")
    SearchFieldList.Items.Add("City")
    SearchFieldList.Items.Add("Country")
  End Sub

  Public Sub FillDataGrid(ByVal sortFieldName As String, ByVal ascSort As Boolean)

    sql = "SELECT EmployeeID, FirstName, LastName, " & _
     "Title, City, Country FROM Employees"
    ' Open the connection
    Try
      If (conn.State <> ConnectionState.Open) Then
        conn.Open()
      End If
      Dim adapter As SqlDataAdapter = _
      New SqlDataAdapter(sql, conn)
      Dim ds As DataSet = New DataSet()
      adapter.Fill(ds, "Employees")
      ' Bind data set to the control
      Dim dtView As DataView = ds.Tables(0).DefaultView
      ' To sort in ascending order
      If ascSort = True Then
        dtView.Sort = sortFieldName + " ASC"
      Else
        dtView.Sort = sortFieldName + " DESC"
      End If
      ' Put Search criteria
      If (searchMode = True) Then
        dtView.RowFilter = "FirstName = 'mel'"
      End If

      ' Bind sorted DataView to the DataGrid
      DataGrid1.DataSource = dtView
      DataGrid1.DataBind()
    Catch exp As SqlException
      Page.Response.Write(exp.Message)
    Finally
      '  Close and dispose the connection
      If (conn.State = ConnectionState.Open) Then
        conn.Close()
      End If
      conn.Dispose()
    End Try
  End Sub

  Private Sub DataGrid1_SortCommand(ByVal source As Object, _
  ByVal e As System.Web.UI.WebControls.DataGridSortCommandEventArgs) _
  Handles DataGrid1.SortCommand
    sortExp = e.SortExpression
    If (CheckBox1.Checked) Then
      FillDataGrid(sortExp, False)
    Else
      FillDataGrid(sortExp, True)
    End If
  End Sub

  Private Sub DataGrid1_PageIndexChanged(ByVal source As Object, _
  ByVal e As System.Web.UI.WebControls.DataGridPageChangedEventArgs) _
 Handles DataGrid1.PageIndexChanged
    DataGrid1.CurrentPageIndex = e.NewPageIndex
    DataGrid1.DataBind()
    If (CheckBox1.Checked) Then
      FillDataGrid(sortExp, False)
    Else
      FillDataGrid(sortExp, True)
    End If
  End Sub

  Private Sub SearchBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles SearchBtn.Click
    Dim str As String = SearchFieldList.SelectedItem.ToString()
    'Page.Response.WriteFile(str)
    If Not str = String.Empty Then
      searchExp = str + "=" + SearchBox.Text
      ' Page.Response.WriteFile(searchExp)
    End If
    searchMode = True
  End Sub
End Class
