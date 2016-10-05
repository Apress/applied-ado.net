<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<script runat="server">
Sub Page_Load()
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

  Sub dtList_ItemCommand(ByVal source As Object, _
  ByVal e As DataListCommandEventArgs)
     Dim id As Integer
    dtList.SelectedIndex = e.Item.ItemIndex
    FillDataList()
    id = dtList.DataKeys(e.Item.ItemIndex)
    BindRepeater(id)
  End Sub

  Sub BindRepeater(ByVal id As Integer)
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
</script>
<HTML>
	<BODY>
		<font color="#006699" size="4" face="verdana">DataList Server Control Sample </font>
		<form runat="server">
			<asp:DataList id="dtList" DataKeyField="CategoryID" runat="server" Width="200" CellPadding="5" CellSpacing="5" OnItemCommand="dtList_ItemCommand">
				<ItemTemplate>
					<font face="verdana" size="2">
						<%# Container.DataItem("CategoryName") %>
					</font>
				</ItemTemplate>
				<AlternatingItemTemplate>
					<font face="verdana" color="green" size="2">
						<%# Container.DataItem("CategoryName") %>
					</font>
				</AlternatingItemTemplate>
				<SelectedItemTemplate>
					<font face="tahoma" color="red" size="2">
						<%# Container.DataItem("CategoryName") %>
					</font>
				</SelectedItemTemplate>
			</asp:DataList>
			<asp:Repeater id="Repeater1" runat="server">
				<ItemTemplate>
					<%# Container.DataItem("ProductName") %>
				</ItemTemplate>
				<SeparatorTemplate>
					<hr>
				</SeparatorTemplate>
			</asp:Repeater>
		</form>
	</BODY>
</HTML>
