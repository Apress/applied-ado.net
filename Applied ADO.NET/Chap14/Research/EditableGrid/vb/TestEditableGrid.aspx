<%@ Page Language="VB" Trace="false" Inherits="BWSLib.MyPage" src="TestEditableGrid.vb" %>
<%@ Register TagPrefix="expo" Namespace="BWSLib.Controls" Assembly="MyEditableGrid" %>

<html>
<title>Testing the MyEditableGrid VB control</title>
<style>
  input		{font-family:verdana;font-size:xx-small;border:solid 1px black;}
  a:hover	{color:red;text-decoration:underline;}
  a			{text-decoration:none;}
</style>


<BODY bgcolor="ivory" link="blue" vlink="blue">
 
<!-- ASP.NET Form -->
<form runat="server">

<expo:MyEditableGrid id="grid" runat="server" 
	AutoGenerateColumns="false"
	PageSize="5"
	Font-Name = "verdana"
	Font-Size = "xx-small"
	DataKeyField="employeeid"
	CellSpacing="0" CellPadding="3"
	BorderStyle="solid" BorderColor="skyblue" BorderWidth="1" GridLines="both"
	
	OnInitRow="InitRow"
	OnUpdateView="UpdateView"
    OnSaveData="SaveData"
    OnInsertData="InsertData"
    OnDeleteData="DeleteData">
	
	<columns>
		<asp:boundcolumn runat="server" headertext="ID" datafield="employeeid" readonly="true" />
		<asp:boundcolumn runat="server" headertext="Name" datafield="firstname" />
		<asp:boundcolumn runat="server" headertext="LastName" datafield="lastname" />
		<asp:boundcolumn runat="server" headertext="Position" datafield="title" />
		<asp:boundcolumn runat="server" headertext="Country" datafield="country" />
	</columns>
	
	
	<headerstyle backcolor="skyblue" font-size="9pt" font-bold="true" />
	<itemstyle backcolor="#eeeeee" />
	<pagerstyle backcolor="skyblue" font-name="webdings" font-size="10pt" PrevPageText="3" NextPageText="4" />
</expo:MyEditableGrid>

<asp:linkbutton runat="server" 
	Font-Name = "verdana" Font-Size="x-small" 
	Text="Insert" onclick="OnInsert" />
</form>
</body>
</html>
