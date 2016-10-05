<%@ Page Language="vb" AutoEventWireup="false" Codebehind="LazyLoading.aspx.vb" Inherits="LazyLoadingWeb.WebForm1"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" border="0">
				<tr>
					<td vAlign="top" align="left">
						<asp:table id="CategoryTree" runat="server"></asp:table>
					</td>
					<td vAlign="top" align="left" width="100%">
						<asp:DataGrid id="VideoTapesGrid" runat="server" AutoGenerateColumns="False" Width="100%">
							<Columns>
								<asp:BoundColumn DataField="VideoTapeID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Title"></asp:BoundColumn>
							</Columns>
						</asp:DataGrid>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
