<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>

<script language="VB" runat=server>

Sub Page_Load(sender As Object, e As EventArgs) 
      Dim conn As SqlConnection 
      Dim adapter As SqlDataAdapter
      dim connectionString = _ 
      "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password=;"
      conn = new SqlConnection(connectionString)
      conn.Open()
      dim sql = "SELECT * FROM Employees"
      dim cmd as SqlCommand = new SqlCommand(sql, conn)
      Dim reader as SqlDataReader = cmd.ExecuteReader()
      repeaterControl.DataSource = reader
      repeaterControl.DataBind()
      reader.Close()
      conn.Close()
  End Sub
  
</script>

<HTML>
	<HEAD><title>Other Controls Data Binding</title></HEAD>
		<form id="Form1" method="post" runat="server">
		<asp:Repeater
		id="repeaterControl"
		runat="server">		
		<ItemTemplate>
			<asp:Button 
			id="Button1" 
			Text='<%# Container.DataItem("LastName") %>'
			runat="server">
			</asp:Button>
			<asp:TextBox 
			id="TextBox1" 			
			Text='<%# Container.DataItem("Title") %>'
			runat="server">
			</asp:TextBox>
			<asp:Image 
			id="Image1" 
			ImageUrl='<%# Container.DataItem("Photo") %>'
			runat="server">
			</asp:Image>
			</ItemTemplate>
			</asp:Repeater>
		</form>
</HTML>
