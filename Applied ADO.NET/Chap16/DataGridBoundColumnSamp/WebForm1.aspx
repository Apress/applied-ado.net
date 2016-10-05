<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<HTML>
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
		<ASP:DataGrid id="dtGrid" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="True" HeaderStyle-Font-Name="verdana" HeaderStyle-ForeColor="white" HeaderStyle-Font-Size="10" ItemStyle-BackColor="black" ItemStyle-Font-Name="verdana" ItemStyle-Font-Size="8" ItemStyle-ForeColor="#ffcc33" AlternatingItemStyle-BackColor="LightSteelBlue" AlternatingItemStyle-ForeColor="black" FooterStyle-BackColor="#ffff99" FooterStyle-Font-Name="tahoma" FooterStyle-Font-Size="6" FooterStyle-Font-Italic="True" EditItemStyle-BackColor="red" EditItemStyle-Font-Size="8" EditItemStyle-ForeColor="#ccffff" ShowHeader="True" ShowFooter="True" AutoGenerateColumns="False" EnableViewState="False" runat="server">
			<Columns>
				<ASP:BoundColumn 
				DataField="Description" 
				HeaderText="Description"
				FooterText="Category Description"/>
				<ASP:BoundColumn 
				DataField="CategoryName" 
				HeaderText="Category Name"
				FooterText="Name of Category"/>
				<ASP:BoundColumn DataField="CategoryID" 
				HeaderText="ID"
				FooterText="Category ID"/>
			</Columns>
		</ASP:DataGrid>
	</body>
</HTML>
