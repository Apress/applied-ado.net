<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="AddOrderClientApp.WebForm1"%>
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
			<asp:Label id="Label1" style="Z-INDEX: 101; LEFT: 31px; POSITION: absolute; TOP: 30px" runat="server" Width="92px" Height="30px">Order Date</asp:Label>
			<asp:Label id="Label2" style="Z-INDEX: 102; LEFT: 34px; POSITION: absolute; TOP: 69px" runat="server" Width="70px" Height="29px">Name</asp:Label>
			<asp:Label id="Label3" style="Z-INDEX: 103; LEFT: 35px; POSITION: absolute; TOP: 114px" runat="server" Width="77px" Height="29px">Address</asp:Label>
			<asp:Label id="Label4" style="Z-INDEX: 104; LEFT: 32px; POSITION: absolute; TOP: 159px" runat="server" Width="78px" Height="26px">City</asp:Label>
			<asp:Label id="Label5" style="Z-INDEX: 105; LEFT: 31px; POSITION: absolute; TOP: 199px" runat="server" Width="76px" Height="28px">Country</asp:Label>
			<asp:Label id="Label6" style="Z-INDEX: 106; LEFT: 30px; POSITION: absolute; TOP: 243px" runat="server" Width="76px" Height="29px">Zip</asp:Label>
			<asp:TextBox id="TextBox1" style="Z-INDEX: 107; LEFT: 131px; POSITION: absolute; TOP: 34px" runat="server" Width="193px" Height="22px"></asp:TextBox>
			<asp:TextBox id="TextBox2" style="Z-INDEX: 108; LEFT: 131px; POSITION: absolute; TOP: 70px" runat="server" Width="192px" Height="27px"></asp:TextBox>
			<asp:TextBox id="TextBox3" style="Z-INDEX: 109; LEFT: 129px; POSITION: absolute; TOP: 112px" runat="server" Width="196px" Height="28px"></asp:TextBox>
			<asp:TextBox id="TextBox4" style="Z-INDEX: 110; LEFT: 129px; POSITION: absolute; TOP: 152px" runat="server" Width="197px" Height="25px"></asp:TextBox>
			<asp:TextBox id="TextBox5" style="Z-INDEX: 111; LEFT: 129px; POSITION: absolute; TOP: 192px" runat="server" Width="201px" Height="28px"></asp:TextBox>
			<asp:TextBox id="TextBox6" style="Z-INDEX: 112; LEFT: 129px; POSITION: absolute; TOP: 234px" runat="server" Width="201px" Height="29px"></asp:TextBox>
			<asp:Button id="Button1" style="Z-INDEX: 113; LEFT: 48px; POSITION: absolute; TOP: 290px" runat="server" Width="105px" Text="Enter Order"></asp:Button>
		</form>
	</body>
</HTML>
