<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="DataGridSamp1.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm1</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 25px; POSITION: absolute; TOP: 24px" runat="server" Width="510px" Height="206px" BorderColor="#3300FF" BorderStyle="Double" BorderWidth="3px" BackColor="Yellow" CellPadding="4" ForeColor="Blue" HorizontalAlign="Left" DataSource="<%# DataSet11 %>" DataKeyField="EmployeeID" AllowSorting="True" DataMember="Employees" ShowFooter="True" AutoGenerateColumns="False" PageSize="5" AllowPaging="True" Font-Size="XX-Small" Font-Names="Verdana" OnPageIndexChanged="Grid_Change">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#339966"></SelectedItemStyle>
				<ItemStyle ForeColor="#333333" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" HorizontalAlign="Center" ForeColor="White" VerticalAlign="Top" BackColor="#336666"></HeaderStyle>
				<FooterStyle Font-Size="XX-Small" Font-Names="Verdana" HorizontalAlign="Left" ForeColor="#FF3366" BackColor="White"></FooterStyle>
				<Columns>
					<asp:BoundColumn DataField="EmployeeID" SortExpression="EmployeeID" ReadOnly="True" HeaderText="ID" FooterText="Employee ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="LastName" SortExpression="LastName" HeaderText="LastName" FooterText="Employees Last Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="FirstName" SortExpression="FirstName" HeaderText="FirstName" FooterText="Employees Last Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="Title" SortExpression="Title" HeaderText="Title" FooterText="Title of Employee"></asp:BoundColumn>
				</Columns>
				<PagerStyle NextPageText="Next Page" Font-Size="X-Small" Font-Names="Arial" Font-Bold="True" PrevPageText="Previous Page" HorizontalAlign="Center" ForeColor="Crimson" Position="TopAndBottom" BackColor="#CCFF66"></PagerStyle>
			</asp:DataGrid>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 28px; POSITION: absolute; TOP: 251px" runat="server" Height="18px" Width="38px">ID</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 103; LEFT: 130px; POSITION: absolute; TOP: 249px" runat="server" Height="29px" Width="83px">First Name</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 104; LEFT: 273px; POSITION: absolute; TOP: 248px" runat="server" Height="30px" Width="90px">Last Name</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 105; LEFT: 418px; POSITION: absolute; TOP: 246px" runat="server" Height="28px" Width="72px">Title</asp:Label>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 106; LEFT: 29px; POSITION: absolute; TOP: 279px" runat="server" Height="24px" Width="59px"></asp:TextBox>
			<asp:TextBox id="TextBox2" style="Z-INDEX: 107; LEFT: 128px; POSITION: absolute; TOP: 279px" runat="server" Height="26px" Width="130px"></asp:TextBox>
			<asp:TextBox id="TextBox3" style="Z-INDEX: 108; LEFT: 277px; POSITION: absolute; TOP: 280px" runat="server" Height="26px" Width="122px"></asp:TextBox>
			<asp:TextBox id="TextBox4" style="Z-INDEX: 109; LEFT: 416px; POSITION: absolute; TOP: 280px" runat="server" Height="25px" Width="117px"></asp:TextBox>
			<asp:Button id="AddBtn" style="Z-INDEX: 110; LEFT: 23px; POSITION: absolute; TOP: 321px" runat="server" Height="31px" Width="84px" Text="Add"></asp:Button>
			<asp:Button id="DeleteBtn" style="Z-INDEX: 111; LEFT: 243px; POSITION: absolute; TOP: 324px" runat="server" Height="30px" Width="89px" Text="Delete"></asp:Button>
			<asp:Button id="UpdateBtn" style="Z-INDEX: 112; LEFT: 125px; POSITION: absolute; TOP: 322px" runat="server" Height="32px" Width="91px" Text="Update"></asp:Button>
		</form>
	</body>
</HTML>
