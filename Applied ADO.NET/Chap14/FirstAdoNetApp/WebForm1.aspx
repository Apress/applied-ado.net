<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="FirstAdoNetApp.WebForm1"%>
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
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 30px; POSITION: absolute; TOP: 35px" runat="server" Width="255px" Height="180px" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" BackColor="White" CellPadding="4" GridLines="Horizontal" ForeColor="Black">
				<SelectedItemStyle Font-Bold="True" ForeColor="White" BackColor="#CC3333"></SelectedItemStyle>
				<HeaderStyle Font-Bold="True" ForeColor="White" BackColor="#333333"></HeaderStyle>
				<FooterStyle ForeColor="Black" BackColor="#CCCC99"></FooterStyle>
				<PagerStyle HorizontalAlign="Right" ForeColor="Black" BackColor="White"></PagerStyle>
			</asp:DataGrid>
			<asp:ListBox id="ListBox1" style="Z-INDEX: 102; LEFT: 403px; POSITION: absolute; TOP: 47px" runat="server" Width="102px" Height="176px"></asp:ListBox>
		</form>
	</body>
</HTML>
