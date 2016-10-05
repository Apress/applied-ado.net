<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ViewGuestBook.aspx.vb" Inherits="MyGuestBook.ViewGuestBook"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>ViewGuestBook</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 28px; POSITION: absolute; TOP: 59px" runat="server" Width="423px" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" BackColor="White" CellPadding="4" GridLines="Horizontal" Font-Names="Verdana" Font-Size="8pt" Height="174px">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#339966"></SelectedItemStyle>
				<ItemStyle ForeColor="#333333" BackColor="White"></ItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#336666"></HeaderStyle>
				<FooterStyle ForeColor="#333333" BackColor="White"></FooterStyle>
				<PagerStyle HorizontalAlign="Center" ForeColor="White" BackColor="#336666" Mode="NumericPages"></PagerStyle>
			</asp:DataGrid>&nbsp;&nbsp;&nbsp; <FONT size="5"><U>My Guest Boo
					<asp:Button id="Button1" style="Z-INDEX: 102; LEFT: 284px; POSITION: absolute; TOP: 16px" runat="server" Width="161px" BorderStyle="Ridge" BackColor="#FFE0C0" Text="Back to Home Page" Height="32px"></asp:Button>k 
					Entries</U></FONT>
		</form>
	</body>
</HTML>
