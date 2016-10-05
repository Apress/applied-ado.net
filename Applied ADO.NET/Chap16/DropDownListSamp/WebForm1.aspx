<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="DropDownListSamp.WebForm2"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>WebForm2</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<asp:DropDownList id="DropDownList1" style="Z-INDEX: 101; LEFT: 33px; POSITION: absolute; TOP: 47px" runat="server" Width="155px" Height="147px"></asp:DropDownList>
			<asp:Button id="LoadDataBtn" style="Z-INDEX: 102; LEFT: 198px; POSITION: absolute; TOP: 44px" runat="server" Width="106px" Height="27px" Text="Load Data"></asp:Button>
			<asp:Button id="GetSelItem" style="Z-INDEX: 103; LEFT: 198px; POSITION: absolute; TOP: 86px" runat="server" Width="145px" Text="Get Selected Item"></asp:Button>
			<asp:CheckBox id="CheckBox1" style="Z-INDEX: 104; LEFT: 32px; POSITION: absolute; TOP: 11px" runat="server" Text="Use DataReader"></asp:CheckBox>
			<asp:Label id="Label1" style="Z-INDEX: 105; LEFT: 40px; POSITION: absolute; TOP: 146px" runat="server" Width="303px">Label</asp:Label>
		</form>
	</body>
</HTML>
