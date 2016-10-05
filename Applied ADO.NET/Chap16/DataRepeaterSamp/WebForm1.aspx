<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<HTML>
	<script language="VB" runat="server">
	Sub Page_Load(sender As Object, e As EventArgs) 
      Dim conn As SqlConnection 
      Dim adapter As SqlDataAdapter
      dim connectionString = _ 
      "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password=;"
      conn = new SqlConnection(connectionString)
      conn.Open()
      dim sql = "SELECT * FROM Categories"
      adapter = new SqlDataAdapter(sql, conn)
      Dim ds As Dataset = new DataSet()
      adapter.Fill(ds)
      repeaterControl.DataSource = ds
      repeaterControl.DataBind()
  End SUb

	</script>
	<body>
	<P>
	<ASP:Repeater id="repeaterControl" runat="server">
	<HeaderTemplate>
		<Table width="100%" style="font: 8pt verdana">
			<tr style="background-color:DFA894">
			<th>CategoryID</th>
			<th>CategoryName</th>
			<th>Description</th>
			<th>Picture</th>
			</tr>
			</HeaderTemplate>
			<ItemTemplate>
			<tr style="background-color:FFECD8">
			<td>
			<%# DataBinder.Eval(Container.DataItem, "CategoryID") %>
			</td>
			<td>
			<%# DataBinder.Eval(Container.DataItem, "CategoryName") %>
			</td>
			<td>
			<%# DataBinder.Eval(Container.DataItem, "Description") %>
			</td>
			<td>
			<%# DataBinder.Eval(Container.DataItem, "Picture") %>
			</td>
			</tr>
			</ItemTemplate>
			<FooterTemplate>					
			</FooterTemplate>
			</ASP:Repeater></P>
	</body>
</HTML>
