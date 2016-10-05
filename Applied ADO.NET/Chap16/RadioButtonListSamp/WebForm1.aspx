<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="RadioButtonListSamp.WebForm1"%>
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
			<asp:RadioButtonList id="RadioButtonList1" style="Z-INDEX: 101; LEFT: 45px; POSITION: absolute; TOP: 67px" runat="server"></asp:RadioButtonList>
			<asp:CheckBox id="CheckBox1" style="Z-INDEX: 102; LEFT: 52px; POSITION: absolute; TOP: 24px" runat="server" Width="159px" Height="28px" Text="Use DataReader"></asp:CheckBox>
			<asp:Button id="LoadDataBtn" style="Z-INDEX: 103; LEFT: 167px; POSITION: absolute; TOP: 67px" runat="server" Width="127px" Text="Load Data"></asp:Button>
			<asp:Button id="GetSelBtn" style="Z-INDEX: 104; LEFT: 169px; POSITION: absolute; TOP: 107px" runat="server" Width="144px" Text="Get Selected Item"></asp:Button>
			<asp:Label id="Label1" style="Z-INDEX: 105; LEFT: 37px; POSITION: absolute; TOP: 342px" runat="server" Width="257px">Label</asp:Label>
		</form>
	</body>
</HTML>
