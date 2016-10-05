<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<HTML>
	<HEAD>
		<title>Editable DataGrid Sample</title>
		<script language="VB" runat="server">
Shared ConnectionString As String = "user id=sa;password=;" & _
     "Initial Catalog=Northwind;" & _
     "Data Source=MCB;"
  Shared conn As SqlConnection = Nothing
  Shared adapter As SqlDataAdapter = Nothing
  Shared sql As String = Nothing
  Shared cmd as SqlCommand = Nothing
  Shared ds as DataSet = Nothing


  Private Sub Page_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    'Put user code to initialize the page here
    If Not IsPostBack Then
      FillDataGrid()
    End If
  End Sub

  ' FillDataGrid method
  Private Sub FillDataGrid()
    conn = New SqlConnection(ConnectionString)
    If conn.State <> ConnectionState.Closed Then
      conn.Open()
    End If
    sql = "SELECT * FROM Categories"
    ds = New DataSet()
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds)
    dtGrid.DataSource = ds.Tables(0)
    dtGrid.DataBind()
    If conn.State = ConnectionState.Open Then
      conn.Close()
    End If
  End Sub
  
  ' EditCommand event handler
  Sub dtGridEdit(obj as Object, args as DataGridCommandEventArgs)
    dtGrid.EditItemIndex = args.Item.ItemIndex
    FillDataGrid()
  End Sub
  ' UpdateCommand Event handler
  Sub dtGridUpdate(obj as Object, args as DataGridCommandEventArgs)
    Dim catId as Integer 
    Dim strName as String
    Dim strDes as String
    Dim catNameTextBox as TextBox
    Dim desTextBox as TextBox
    ' Read text from text boxes
    catId = dtGrid.DataKeys(args.Item.ItemIndex)
    catNameTextBox = args.Item.Cells(1).Controls(0)
    desTextBox = args.Item.Cells(2).Controls(0)
    strName = catNameTextBox.Text
    strDes = desTextBox.Text
    ' Construct an UPDATE SQL statement
    sql = "UPDATE Categories SET CategoryName=@catName, " & _
    " Description=@desc WHERE CategoryID=@id"
    ' Construct a SqlCommand 
    cmd = new SqlCommand(sql, conn)
    ' Add parameters to the command with the values
    ' read from text boxes and category ID
    cmd.Parameters.Add("@id", catId)
    cmd.Parameters.Add("@catName", strName)
    cmd.Parameters.Add("@desc", strDes)
    ' Open the connection
    conn.Open()
    ' Execute SQL statement
    cmd.ExecuteNonQuery()
    ' Close the connection
    conn.Close()
    ' Close editing mode of DataGrid
    dtGrid.EditItemIndex = -1
    ' Refill DataGrid with the updated data
    FillDataGrid()  
    
  End Sub
  ' CancelCommand Event handler
  Sub dtGridCancel(obj as Object, args as DataGridCommandEventArgs)
    dtGrid.EditItemIndex = -1
    FillDataGrid()
  End Sub
  
  ' Sort Event handler
  Sub dtGridSort(obj as Object, args as DataGridSortCommandEventArgs)
    Dim sortExpr as String 
    ' Open the connection
    If conn.State <> ConnectionState.Closed Then
      conn.Open()
    End If    
    ' Get the column from SortCommand Event Args
    sortExpr = args.SortExpression
    ' Create a SELECT Statement with ORDER BY the expression    
    sql = "SELECT * FROM Categories ORDER BY " + sortExpr
    ds = New DataSet()
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds)
    dtGrid.DataSource = ds.Tables(0)
    dtGrid.DataBind()
    If conn.State = ConnectionState.Open Then
      conn.Close()
    End If
    
  End Sub
  
		</script>
	</HEAD>
	<BODY>
		<font face="verdana" size="4">Editable DataGrid Sample</font>
		<br>
		<form runat="server">
			<ASP:DataGrid id="dtGrid" HeaderStyle-BackColor="#003366" HeaderStyle-Font-Bold="True" HeaderStyle-Font-Name="verdana" HeaderStyle-ForeColor="white" HeaderStyle-Font-Size="10" ItemStyle-BackColor="black" ItemStyle-Font-Name="verdana" ItemStyle-Font-Size="8" ItemStyle-ForeColor="#ffcc33" AlternatingItemStyle-BackColor="LightSteelBlue" AlternatingItemStyle-ForeColor="black" FooterStyle-BackColor="#ffff99" FooterStyle-Font-Name="tahoma" FooterStyle-Font-Size="6" FooterStyle-Font-Italic="True" EditItemStyle-BackColor="red" EditItemStyle-Font-Size="8" EditItemStyle-ForeColor="#ccffff" ShowHeader="True" ShowFooter="True" OnCancelCommand="dtGridCancel" OnUpdateCommand="dtGridUpdate" OnEditCommand="dtGridEdit" DataKeyField="CategoryID" AutoGenerateColumns="False" AllowSorting="True" OnSortCommand="dtGridSort" runat="server">
				<FooterStyle Font-Size="6pt" Font-Names="tahoma" Font-Italic="True" BackColor="#FFFF99"></FooterStyle>
				<HeaderStyle Font-Size="10pt" Font-Names="verdana" Font-Bold="True" ForeColor="White" BackColor="#003366"></HeaderStyle>
				<EditItemStyle Font-Size="8pt" ForeColor="#CCFFFF" BackColor="Red"></EditItemStyle>
				<AlternatingItemStyle ForeColor="Black" BackColor="LightSteelBlue"></AlternatingItemStyle>
				<ItemStyle Font-Size="8pt" Font-Names="verdana" ForeColor="#FFCC33" BackColor="Black"></ItemStyle>
				<Columns>
					<asp:BoundColumn DataField="CategoryID" ReadOnly="True" HeaderText="ID" FooterText="Category ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="CategoryName" HeaderText="Category Name" FooterText="Name of Category"></asp:BoundColumn>
					<asp:BoundColumn DataField="Description" HeaderText="Description" FooterText="Category Description"></asp:BoundColumn>
					<asp:EditCommandColumn ButtonType="LinkButton" UpdateText="Save" CancelText="Cancel" EditText="Edit">
						<ItemStyle Font-Names="verdana" ForeColor="White" BackColor="Red"></ItemStyle>
					</asp:EditCommandColumn>
				</Columns>
			</ASP:DataGrid>
		</form>
	</BODY>
</HTML>
