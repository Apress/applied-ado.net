<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="DataGridEditSamp.WebForm1"%>
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
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 22px; POSITION: absolute; TOP: 145px" runat="server" Width="310px" Height="166px" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" BackColor="Navy" CellPadding="4" GridLines="Horizontal" ForeColor="White" Font-Size="XX-Small" Font-Names="Verdana" AllowSorting="True" AllowPaging="True" ShowFooter="True" PageSize="5">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CC3333"></SelectedItemStyle>
				<AlternatingItemStyle BorderWidth="2px" BorderStyle="Solid" BorderColor="#FFC0C0" BackColor="Gray"></AlternatingItemStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="#333333"></HeaderStyle>
				<FooterStyle Font-Size="X-Small" Font-Names="Verdana" ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
				<Columns>
					<asp:HyperLinkColumn></asp:HyperLinkColumn>
				</Columns>
				<PagerStyle BorderColor="#FFC0C0" HorizontalAlign="Right" ForeColor="White" BackColor="Highlight" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>
			<asp:CheckBox id="CheckBox1" style="Z-INDEX: 102; LEFT: 25px; POSITION: absolute; TOP: 41px" runat="server" Font-Names="Verdana" Font-Size="X-Small" BackColor="#C0FFC0" BorderStyle="Groove" Height="22px" Width="175px" Text="Sort Descending"></asp:CheckBox>
			<asp:TextBox id="SearchBox" style="Z-INDEX: 103; LEFT: 222px; POSITION: absolute; TOP: 7px" runat="server" BorderStyle="Groove" Height="25px" Width="144px"></asp:TextBox>
			<asp:Button id="SearchBtn" style="Z-INDEX: 104; LEFT: 222px; POSITION: absolute; TOP: 44px" runat="server" BackColor="#C0FFFF" BorderStyle="Groove" Height="27px" Width="144px" Text="Search"></asp:Button>
			<asp:DropDownList id="SearchFieldList" style="Z-INDEX: 105; LEFT: 377px; POSITION: absolute; TOP: 8px" runat="server" Width="110px"></asp:DropDownList>
		</form>
	</body>
</HTML>
