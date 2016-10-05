<%@ Page Language="vb" AutoEventWireup="false" Codebehind="MyGuestBook.aspx.vb" Inherits="MyGuestBook.WebForm1"%>
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
			<P><FONT color="#cc0033" size="5"><STRONG><U>Welcome to My Guest Book</U></STRONG></FONT></P>
			<P><STRONG><FONT color="#000000">Name:
						<asp:TextBox id="NameTextBox" style="Z-INDEX: 101; LEFT: 102px; POSITION: absolute; TOP: 63px" runat="server" Width="243px" BorderStyle="Groove"></asp:TextBox></FONT></STRONG></P>
			<P><STRONG><FONT color="#000000">Address:
						<asp:TextBox id="AddressTextBox" style="Z-INDEX: 102; LEFT: 102px; POSITION: absolute; TOP: 97px" runat="server" Width="243px" BorderStyle="Groove"></asp:TextBox></FONT></STRONG></P>
			<P><STRONG><FONT color="#000000">Email:
						<asp:TextBox id="EmailTextBox" style="Z-INDEX: 103; LEFT: 101px; POSITION: absolute; TOP: 131px" runat="server" Width="244px" BorderStyle="Groove"></asp:TextBox></FONT></STRONG></P>
			<P><STRONG><FONT color="#000000">Comments:</FONT></STRONG></P>
			<P><STRONG><FONT color="#000000">
						<asp:TextBox id="CommentsTextBox" style="Z-INDEX: 104; LEFT: 100px; POSITION: absolute; TOP: 173px" runat="server" Width="247px" Height="155px" TextMode="MultiLine" BorderStyle="Groove"></asp:TextBox>
						<asp:Button id="Button1" style="Z-INDEX: 105; LEFT: 14px; POSITION: absolute; TOP: 348px" runat="server" Width="158px" Height="27px" BorderStyle="Ridge" Text="Sign In Guest Book" BackColor="#FFC080"></asp:Button>
						<asp:Button id="Button2" style="Z-INDEX: 106; LEFT: 195px; POSITION: absolute; TOP: 348px" runat="server" Width="150px" Height="27px" BorderStyle="Ridge" Text="View Guest Book" BackColor="#C0FFC0"></asp:Button></FONT></STRONG></P>
		</form>
	</body>
</HTML>
