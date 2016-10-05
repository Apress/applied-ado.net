<%@ Page Language="vb" AutoEventWireup="false" 
Codebehind="WebForm1.aspx.vb" Inherits="FirstWebApplication.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title>First ASP.NET Web Application</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio.NET 7.0">
		<meta name="CODE_LANGUAGE" content="Visual Basic 7.0">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/
		intellisense/ie5">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<P>
				<asp:TextBox id="TextBox1" style="Z-INDEX: 101; LEFT: 16px; 
				POSITION: absolute; TOP: 80px" runat="server"></asp:TextBox>
				<asp:Button id="Button1" style="Z-INDEX: 102; LEFT: 188px; 
				POSITION: absolute; TOP: 79px" runat="server" Text="Add" Width="106px" Height="27px" Font-Names="Verdana" ForeColor="Yellow" BackColor="#0000C0"></asp:Button>
				<asp:ListBox id="ListBox1" style="Z-INDEX: 103; LEFT: 
				14px; POSITION: absolute; TOP: 121px" runat="server" Width="284px" Height="170px"></asp:ListBox><FONT face="Verdana" size="4">My 
					First ASP.NET Web Application</FONT></P>
			<P><FONT face="Verdana" size="2">Click Add button to add TextBox contents to 
					ListBox</FONT></P>
			<P><FONT face="Verdana" size="2"></FONT>&nbsp;</P>
		</form>
	</body>
</HTML>
