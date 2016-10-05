<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Data.SqlClient" %>
<HTML>
	<HEAD>
		<title>Editable DataList</title>
		<script runat="server">

Sub Page_Load
	If not IsPostBack
		FillDataList()
	End If
End Sub

Sub FillDataList()
	Dim conn As SqlConnection 
   Dim adapter As SqlDataAdapter
   dim connectionString = _ 
   "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password=;"
   conn = new SqlConnection(connectionString)
   conn.Open()
   dim sql = "SELECT * FROM Categories"
   dim cmd as SqlCommand = new SqlCommand(sql, conn)
   dim reader as SqlDataReader = cmd.ExecuteReader()
   dtList.DataSource = reader
   dtList.DataBind()   
   reader.Close()
   conn.Close()   
End Sub

Sub EditCommandHandler(sender as object, _
args as DataListCommandEventArgs)
	dtList.EditItemIndex = args.Item.ItemIndex
	FillDataList()
End Sub

Sub CancelCommandHandler(sender as object, _
args as DataListCommandEventArgs)
	dtList.EditItemIndex = -1
	FillDataList()
End Sub

Sub DeleteCommandHandler(sender as object, _
args as DataListCommandEventArgs)
	Dim conn As SqlConnection 
   Dim adapter As SqlDataAdapter
   dim connectionString = _ 
   "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password=;"
   conn = new SqlConnection(connectionString)  
   dim strId as string = dtList.DataKeys(args.Item.ItemIndex)   
   dim sql = "DELETE Categories WHERE CategoryID=@catID"
   dim cmd as SqlCommand = new SqlCommand(sql, conn)
   cmd.Parameters.Add("@catID", strId)    
   conn.Open()  
   cmd.ExecuteNonQuery()
   conn.Close()   
   dtList.EditItemIndex = -1
   FillDataList()   
End Sub

Sub UpdateCommandHandler(sender as object, _
args as DataListCommandEventArgs)
	Dim conn As SqlConnection 
   Dim adapter As SqlDataAdapter
   dim connectionString = _ 
   "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password=;"
   conn = new SqlConnection(connectionString)  
   dim strId as string = dtList.DataKeys(args.Item.ItemIndex)  
   dim strCatName as TextBox = args.Item.FindControl("catNameTextBox")
   dim strDesc as TextBox = args.Item.FindControl("desTextBox")    
   dim sql = "UPDATE Categories SET CategoryName=@catName, " & _
   " Description=@desc WHERE CategoryID=@catID"
   dim cmd as SqlCommand = new SqlCommand(sql, conn)
   cmd.Parameters.Add("@catID", strId)
   cmd.Parameters.Add("@catName", strCatName.Text.ToString())
   cmd.Parameters.Add("@desc", strDesc.Text.ToString())       
   conn.Open()  
   cmd.ExecuteNonQuery()
   conn.Close()   
   dtList.EditItemIndex = -1
   FillDataList()
   
   
End Sub

		</script>
	</HEAD>
	<body>
		<form runat="server">
			<asp:datalist id="dtList" runat="server" CellPadding="4" RepeatDirection="Horizontal" GridLines="Horizontal" RepeatColumns="4" OnUpdateCommand="UpdateCommandHandler" OnDeleteCommand="DeleteCommandHandler" OnCancelCommand="CancelCommandHandler" OnEditCommand="EditCommandHandler" DataKeyField="CategoryID" BackColor="WhiteSmoke" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" ForeColor="Black" Font-Names="Verdana" Font-Size="8pt">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CC3333"></SelectedItemStyle>
				<HeaderTemplate>
					<FONT face="verdana" color="#FFFFFF" size="3"><B>Editable DataList</B></FONT>
				</HeaderTemplate>
				<EditItemStyle BackColor="#FFC080"></EditItemStyle>
				<FooterTemplate>
					<FONT face="verdana" color="#996600" size="1">DataList Control footer </FONT>
				</FooterTemplate>
				<ItemTemplate>
					<b>Category ID:</b>
					<%# Container.DataItem("CategoryID") %>
					<br>
					<b>Category Name:</b>
					<%# Container.DataItem("CategoryName") %>
					<br>
					<b>Description:</b>
					<%# Container.DataItem("Description") %>
					<br>
					<asp:LinkButton Text="Edit" CommandName="Edit" RunAt="server"></asp:LinkButton>
				</ItemTemplate>
				<AlternatingItemTemplate>
					<font face="verdana" color="green" size="1"><b>Category ID:</b>
						<%# Container.DataItem("CategoryID") %>
						<br>
						<b>Category Name:</b>
						<%# Container.DataItem("CategoryName") %>
						<br>
						<b>Description:</b>
						<%# Container.DataItem("Description") %>
						<br>
						<asp:LinkButton Text="Edit" CommandName="Edit" RunAt="server" ID="Linkbutton1" NAME="Linkbutton1"></asp:LinkButton>
					</font>
				</AlternatingItemTemplate>
				<FooterStyle ForeColor="Black" BackColor="#C0FFC0"></FooterStyle>
				<HeaderStyle Font-Bold="True" ForeColor="#C04000" BackColor="#FF8000"></HeaderStyle>
				<EditItemTemplate>
					<b>Category Name:</b>
					<br>
					<asp:TextBox ID="catNameTextBox" 
					Text='<%# Container.DataItem("CategoryName") %>' 
					Runat="server" 
					Font-Names="Verdana" Font-Size="8pt" 
					BorderStyle="Groove" />
					<br>
					<b>Description</b>
					<br>
					<asp:TextBox ID="desTextBox" 
					Text='<%# Container.DataItem("Description") %>' 
					Runat="server" 
					Font-Names="Verdana" Font-Size="8pt" 
					BorderStyle="Groove" />
					<br>
					<asp:LinkButton Text="Cancel" CommandName="cancel" Runat="server" />
					<asp:LinkButton Text="Delete" CommandName="delete" Runat="server" />
					<asp:LinkButton Text="Update" CommandName="update" Runat="server" />
				</EditItemTemplate>
			</asp:datalist></form>
	</body>
</HTML>
