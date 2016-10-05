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
  
  Sub dtGridItem(obj as Object, args as DataGridCommandEventArgs)
    If (args.CommandName = "Yes") Then
      args.Item.BackColor = System.Drawing.Color.Gray
      args.Item.ForeColor = System.Drawing.Color.White
      args.Item.Font.Name = "tahoma"  
    Else
      args.Item.BackColor = System.Drawing.Color.Black
      args.Item.ForeColor = System.Drawing.Color.LightSteelBlue
      args.Item.Font.Name = "verdana" 
  End If
    
  End Sub
  
	</script>
	<body>
		<form id="Form1" runat="server">
			<ASP:DataGrid id="dtGrid" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="True" HeaderStyle-Font-Name="verdana" HeaderStyle-ForeColor="white" HeaderStyle-Font-Size="10" ItemStyle-BackColor="black" ItemStyle-Font-Name="verdana" ItemStyle-Font-Size="8" ItemStyle-ForeColor="#ffcc33" AlternatingItemStyle-BackColor="LightSteelBlue" AlternatingItemStyle-ForeColor="black" FooterStyle-BackColor="#ffff99" FooterStyle-Font-Name="tahoma" FooterStyle-Font-Size="6" FooterStyle-Font-Italic="True" EditItemStyle-BackColor="red" EditItemStyle-Font-Size="8" EditItemStyle-ForeColor="#ccffff" ShowHeader="True" ShowFooter="True" OnItemCommand="dtGridItem" runat="server">
				<Columns>
					<ASP:ButtonColumn 
					CommandName="Yes" 
					ButtonType=LinkButton
					Text="Select">
					</ASP:ButtonColumn>
					<ASP:ButtonColumn 
					CommandName="No" 
					ButtonType=LinkButton
					Text="UnSelect">
					</ASP:ButtonColumn>
				</Columns>
			</ASP:DataGrid>
		</form>
	</body>
</html>
