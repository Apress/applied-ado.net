<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="ListBoxWebSamp.WebForm1"%>
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
			<asp:ListBox id="ListBox1" style="Z-INDEX: 101; LEFT: 21px; POSITION: absolute; TOP: 27px" runat="server" Width="190px" Height="218px"></asp:ListBox>
			<asp:Button id="LoadDataBtn" style="Z-INDEX: 102; LEFT: 243px; POSITION: absolute; TOP: 67px" runat="server" Width="138px" Height="29px" Text="Load Data"></asp:Button>
			<asp:Button id="GetSetBtn" style="Z-INDEX: 103; LEFT: 245px; POSITION: absolute; TOP: 108px" runat="server" Width="138px" Height="29px" Text="Get Selected Item"></asp:Button>
			<asp:Label id="Label1" style="Z-INDEX: 104; LEFT: 26px; POSITION: absolute; TOP: 261px" runat="server" Width="343px" Height="23px">Label</asp:Label>
		</form>
	</body>
</HTML>
