<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="OrderLookUpApp.WebForm1"%>
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
			<asp:DataGrid id="DataGrid1" style="Z-INDEX: 101; LEFT: 35px; POSITION: absolute; TOP: 89px" runat="server" Width="435px" Height="198px"></asp:DataGrid>
			<asp:Label id="Label1" style="Z-INDEX: 102; LEFT: 40px; POSITION: absolute; TOP: 29px" runat="server" Width="154px" Height="32px">Enter an OrderID</asp:Label>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 103; LEFT: 209px; POSITION: absolute; TOP: 29px" runat="server" Width="122px" Height="34px"></asp:TextBox>
			<asp:Button id="Button1" style="Z-INDEX: 104; LEFT: 349px; POSITION: absolute; TOP: 34px" runat="server" Width="115px" Height="31px" Text="Fill Order"></asp:Button>
		</form>
	</body>
</HTML>
