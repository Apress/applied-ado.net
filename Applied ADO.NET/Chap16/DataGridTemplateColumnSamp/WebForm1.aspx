<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<html>
	<script language="VB" runat="server">
  Sub Page_Load(sender As Object, e As EventArgs) 
    If Not IsPostBack Then
       FillDataGrid()
    End If
  End SUb
  
  Sub FillDataGrid()
   Dim conn As SqlConnection 
      Dim adapter As SqlDataAdapter
      dim connectionString = _ 
      "Data Source=MCB;Initial Catalog=Northwind;" & _
      "user id=sa;password=;"
      conn = new SqlConnection(connectionString)
      conn.Open()
      dim sql = "SELECT * FROM Categories"
      adapter = new SqlDataAdapter(sql, conn)
      Dim ds As Dataset = new DataSet()
      adapter.Fill(ds)
      dtGrid.DataSource = ds
      dtGrid.DataBind()
  End Sub  
	</script>
	<body>
		<form id="Form1" runat="server">
			<ASP:DataGrid id="dtGrid" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="True" HeaderStyle-Font-Name="verdana" HeaderStyle-ForeColor="white" HeaderStyle-Font-Size="10" ItemStyle-BackColor="black" ItemStyle-Font-Name="verdana" ItemStyle-Font-Size="8" ItemStyle-ForeColor="#ffcc33" AlternatingItemStyle-BackColor="LightSteelBlue" AlternatingItemStyle-ForeColor="black" FooterStyle-BackColor="#ffff99" FooterStyle-Font-Name="tahoma" FooterStyle-Font-Size="6" FooterStyle-Font-Italic="True" EditItemStyle-BackColor="red" EditItemStyle-Font-Size="8" EditItemStyle-ForeColor="#ccffff" ShowHeader="True" ShowFooter="True" AutoGenerateColumns="False" runat="server">
				<Columns>
					<ASP:TemplateColumn>
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
							</FONT>
						</ItemTemplate>
						<HeaderTemplate>
							<font face="verdana" size="3">DataGrid with Template Columns </font>
						</HeaderTemplate>
						<FooterTemplate>
							<font face="verdana" size="2">DataGrid Footer </font>
						</FooterTemplate>
					</ASP:TemplateColumn>
				</Columns>
			</ASP:DataGrid>
		</form>
	</body>
</html>
