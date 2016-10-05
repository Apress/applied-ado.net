<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ChoosePerson.aspx.vb" Inherits="VideoStoreWeb.ChoosePerson"%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
	<HEAD>
		<title></title>
		<meta content="Microsoft Visual Studio.NET 7.0" name="GENERATOR">
		<meta content="Visual Basic 7.0" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="Styles.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="2" width="100%" border="0">
				<tr>
					<td vAlign="top" align="left">
						<asp:datagrid id="ChooseUserDataGrid" runat="server" Width="100%" AutoGenerateColumns="False" CssClass="ApplicationTable">
							<HeaderStyle CssClass="ApplicationHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="UserID" Visible="False"></asp:BoundColumn>
								<asp:BoundColumn DataField="FirstName" HeaderText="First Name"></asp:BoundColumn>
								<asp:BoundColumn DataField="LastName" HeaderText="Last Name"></asp:BoundColumn>
								<asp:ButtonColumn ButtonType="LinkButton" CommandName="Select" Text="Select"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid>
					</td>
					<td vAlign="top" align="left">
						<table class="ApplicationTable" cellSpacing="0" cellPadding="2" width="100%" border="0">
							<tr>
								<td class="ApplicationHeader" align="right" colSpan="2">
									Customer
								</td>
							</tr>
							<tr>
								<td>
									First Name
								</td>
								<td>
									<asp:textbox id="FirstNameField" runat="server"></asp:textbox>
								</td>
							</tr>
							<tr>
								<td>
									Last Name
								</td>
								<td>
									<asp:textbox id="LastNameField" runat="server"></asp:textbox>
								</td>
							</tr>
							<tr>
								<td align="middle" colSpan="2">
									<asp:button id="SaveButton" runat="server" Text="Save"></asp:button>
									&nbsp;
									<asp:button id="CancelButton" runat="server" Text="Cancel"></asp:button>
									&nbsp;
									<asp:button id="CheckOutVideosButton" runat="server" Text="Check Out Videos"></asp:button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
