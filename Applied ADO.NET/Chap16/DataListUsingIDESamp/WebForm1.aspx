<%@ Page Language="vb" AutoEventWireup="false" Codebehind="WebForm1.aspx.vb" Inherits="DataListUsingIDESamp.WebForm1"%>
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
			<asp:DataList 
			id=DataList1 
			runat="server" 
			GridLines="Both" 
			DataSource="<%# DataSet11 %>" 
			DataKeyField="CategoryID" 
			DataMember="Categories" 
			RepeatDirection="Horizontal" 
			RepeatColumns="5" 
			Font-Size="X-Small" 
			Font-Names="Verdana" 
			ForeColor="Navy" 
			BackColor="LightGray" 
			BorderColor="Black">
				<SelectedItemStyle ForeColor="#FF0033" BackColor="#CCCC99"></SelectedItemStyle>
				<EditItemStyle Font-Size="10pt" Font-Names="Verdana" Font-Bold="True" BackColor="#FFE0C0"></EditItemStyle>
				<AlternatingItemStyle ForeColor="#006600" BackColor="Silver"></AlternatingItemStyle>
				<ItemStyle ForeColor="Black" BackColor="GhostWhite"></ItemStyle>
				<FooterStyle Font-Size="8pt" Font-Names="Tahoma" ForeColor="White" BackColor="Teal"></FooterStyle>
				<HeaderStyle Font-Size="X-Small" Font-Names="Verdana" Font-Bold="True" ForeColor="White" BackColor="#003399"></HeaderStyle>
			</asp:DataList>
		</form>
	</body>
</HTML>
