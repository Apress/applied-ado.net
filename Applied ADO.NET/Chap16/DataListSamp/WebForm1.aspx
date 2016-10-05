<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<HTML>
	<BODY>
		<font color="#006699" size="4" face="verdana">DataList Server Control Sample </font>
		<script language="VB" runat="server">
	Sub Page_Load(sender As Object, e As EventArgs) 
     fillData()
  End SUb
  
  sub fillData()
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
      dtList.DataSource = ds
      dtList.DataBind()
  end sub  

		</script>
		<P>
			<ASP:DataList id="dtList" RepeatColumns="5" RepeatDirection="Horizontal" GridLines="Both" DataKeyField="CategoryID" runat="server">
				<HeaderTemplate>
					<FONT face="verdana" color="#cc3333" size="3"><B>DataList Control Header</B></FONT>
				</HeaderTemplate>
				<FooterTemplate>
					<FONT face="verdana" color="#996600" size="1">DataList Control footer </FONT>
				</FooterTemplate>
				<ItemTemplate>
					<FONT face="verdana" size="2">
						<BR>
						<B>Category ID: </B>
						<%# DataBinder.Eval(Container.DataItem, "CategoryID") %>
						<BR>
						<B>Category Name: </B>
						<%# DataBinder.Eval(Container.DataItem, "CategoryName")%>
						<BR>
						<B>Description: </B>
						<%# DataBinder.Eval(Container.DataItem, "Description") %>
						<BR>
						<B>Picture: </B>
						<%# DataBinder.Eval(Container.DataItem, "Picture") %>
						<P>
					</FONT>
				</ItemTemplate>
				<AlternatingItemTemplate>
					<FONT face="verdana" color="green" size="2">
						<BR>
						<B>Category ID: </B>
						<%# DataBinder.Eval(Container.DataItem, "CategoryID") %>
						<BR>
						<B>Category Name: </B>
						<%# DataBinder.Eval(Container.DataItem, "CategoryName")%>
						<BR>
						<B>Description: </B>
						<%# DataBinder.Eval(Container.DataItem, "Description") %>
						<BR>
						<B>Picture: </B>
						<%# DataBinder.Eval(Container.DataItem, "Picture") %>
						<P>
							<DIV></DIV>
					</FONT>
				</AlternatingItemTemplate>
			</ASP:DataList>
		</P>
	</BODY>
</HTML>
