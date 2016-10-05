<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<HTML>
  <HEAD>
    <title>Editable DataGrid Sample</title>
    <script language="VB" runat="server">
Shared ConnectionString As String = "user id=sa;password=;" & _
     "Initial Catalog=Northwind;" & _
     "Data Source=MCB;"
  Shared conn As SqlConnection = Nothing
  Shared adapter As SqlDataAdapter = Nothing
  Shared sql As String = Nothing
  Shared cmd as SqlCommand = Nothing
  Shared ds as DataSet = Nothing


  Private Sub Page_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    'Put user code to initialize the page here
    If Not IsPostBack Then
     FillDataGrid("")
    End If
  End Sub

  ' FillDataGrid method
  Private Sub FillDataGrid(str as String)
    conn = New SqlConnection(ConnectionString)
    If conn.State <> ConnectionState.Closed Then
      conn.Open()
    End If
    if str = "" Then
         sql = "SELECT * FROM Categories"
    Else
      sql = "SELECT * FROM Categories ORDER BY " + str
    End If
    ds = New DataSet()
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds)
    dtGrid.DataSource = ds.Tables(0)
    dtGrid.DataBind()
    If conn.State = ConnectionState.Open Then
      conn.Close()
    End If
  End Sub
  
  
  
  ' Sort Event handler
  Sub dtGridSort(obj as Object, args as DataGridSortCommandEventArgs)
    Dim sortExpr as String 
    sortExpr = args.SortExpression
    FillDataGrid(sortExpr)    
  End Sub
  
    </script>
  </HEAD>
  <BODY>
    <font face="verdana" size="4">Sorting in DataGrid</font>
    <br>
    <form runat="server" ID="Form1">
      <ASP:DataGrid id="dtGrid" 
      AllowSorting="True" 
      OnSortCommand="dtGridSort"
      runat="server">
      </ASP:DataGrid>
    </form>
  </BODY>
</HTML>
