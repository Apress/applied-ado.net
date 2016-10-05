<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="CalendarConrol.WebForm1"%>
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
			<asp:Calendar id="Calendar1" style="Z-INDEX: 101; LEFT: 20px; POSITION: absolute; TOP: 11px" runat="server" Width="292px" Height="141px"></asp:Calendar>
			<asp:Button id="GetPropsBtn" style="Z-INDEX: 102; LEFT: 23px; POSITION: absolute; TOP: 222px" runat="server" Height="33px" Width="182px" Text="Selected Date"></asp:Button>
			<asp:Label id="Label1" style="Z-INDEX: 103; LEFT: 30px; POSITION: absolute; TOP: 276px" runat="server" Height="74px" Width="371px">Label</asp:Label>
		</form>
	</body>
</HTML>
