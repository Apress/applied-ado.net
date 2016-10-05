<%@ Page Language="vb" AutoEventWireup="false" Codebehind="ListVideos.aspx.vb" Inherits="VideoStoreWeb.ListVideos"%>
<%@ import namespace="VideoStoreDataModel.EnterpriseVB.VideoStore.Data" %>
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
			<table class="ApplicationTable" id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
				<tr>
					<td class="ApplicationHeader" align="right" colspan="2">
						<%= SelectedUser.FirstName +" "+ SelectedUser.LastName %>
					</td>
				</tr>
				<tr>
					<td align="left">
						<asp:DataGrid id="CheckedOutDataGrid" AutoGenerateColumns="False" runat="server" Width="100%" CssClass="ApplicationTable">
							<HeaderStyle CssClass="ApplicationHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="VideoTapeID" Visible="False"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Title">
									<ItemTemplate>
										<%# CType(Container.DataItem, VideoTape).Title %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn ButtonType="LinkButton" Text="Check In" CommandName="Edit"></asp:ButtonColumn>
							</Columns>
						</asp:DataGrid>
					</td>
					<td align="right">
						<A href="ChoosePerson.aspx">Choose Another User</A>
					</td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="2" width="100%" border="0">
				<tr>
					<td vAlign="top" align="left">
						<asp:datagrid id="VideoListGrid" runat="server" AutoGenerateColumns="False" Width="100%" CssClass="ApplicationTable">
							<HeaderStyle CssClass="ApplicationHeader"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="VideoTapeID" Visible="False"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Title">
									<ItemTemplate>
										<%# CType(Container.DataItem, VideoTape).Title %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Description">
									<ItemTemplate>
										<%# CType(Container.DataItem, VideoTape).Description %>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:ButtonColumn ButtonType="LinkButton" Text="Select" CommandName="Edit"></asp:ButtonColumn>
							</Columns>
						</asp:datagrid>
						<asp:linkbutton id="AddNewButton" runat="server">Add New Video</asp:linkbutton>
					</td>
					<td vAlign="top" align="left">
						<table class="ApplicationTable" id="VideoTapeEditor" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<tr>
								<td class="ApplicationHeader" align="right" colSpan="2">
									Video Tape
								</td>
							</tr>
							<tr>
								<td align="left">
									Title
								</td>
								<td align="left">
									<asp:textbox id="VideoTitleField" runat="server" BorderWidth="1px" BorderStyle="Solid"></asp:textbox>
								</td>
							</tr>
							<tr>
								<td align="left">
									Description
								</td>
								<td align="left">
									<asp:textbox id="VideoDescriptionField" runat="server" BorderStyle="Solid" BorderWidth="1px"></asp:textbox>
								</td>
							</tr>
							<tr>
								<td align="middle" colspan="2">
									<asp:Label id="CheckedOutLabel" runat="server"></asp:Label>
								</td>
							</tr>
							<tr class="ApplicationButtonRow">
								<td align="middle" colSpan="2">
									<asp:button id="SaveButton" runat="server" Text="Save"></asp:button>
									&nbsp;
									<asp:button id="CancelButton" runat="server" Text="Cancel"></asp:button>
									&nbsp;
									<asp:Button id="CheckOutButton" runat="server" Text="Check Out"></asp:Button>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
