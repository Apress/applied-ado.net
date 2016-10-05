<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<HTML>
	<script language="VB" runat="server">
 dim connectionString = _ 
      "Data Source=MCB;Initial Catalog=pubs;user id=sa;password=;"      
  Dim MyConnection As SqlConnection

   Sub Page_Load(Src As Object, e As EventArgs)
      ' Create a connection to the "pubs" SQL database located on 
      ' the local computer.
      myConnection = New SqlConnection(connectionString)
      ' Check whether this page is a  postback. If it is not 
      ' a  postback, call a custom BindGrid function.
      If Not IsPostBack Then 
         BindGrid()
      End If
   End Sub

   ' Implement an AddAuthor_Click function. This function does some data 
   ' validation on the input form and builds a string containing all the 
   ' fields of the input form.  Then it adds this string to the database 
   ' and tests (using the try command) whether the data was added. 
   ' Finally, it rebinds the DataGrid to show the new data.
   Sub AddAuthor_Click(Sender As Object, e As EventArgs) 
      Dim myCommand As SqlCommand
      Dim insertCmd As String
      ' Check that four of the input values are not empty. If any of them
      '  is empty, show a message to the user and rebind the DataGrid.
      If (au_id.Value = "" Or au_fname.Value = "" Or au_lname.Value = "" _
         Or phone.Value = "") Then
         Message.InnerHtml = "ERROR: Null values not allowed for " _
            & "Author ID, Name or Phone"
         Message.Style("color") = "red"
         BindGrid()
         Exit Sub
      End If
      ' Build a SQL INSERT statement string for all the input-form
      ' field values.
      insertCmd = "insert into Authors values (@Id, @LName, @FName," _ 
         & "@Phone, @Address, @City, @State, @Zip, @Contract);"
      ' Initialize the SqlCommand with the new SQL string.
      myCommand = New SqlCommand(insertCmd, myConnection)
      ' Create new parameters for the SqlCommand object and
      ' initialize them to the input-form field values.
      myCommand.Parameters.Add(New SqlParameter("@Id", _
         SqlDbType.VarChar, 11))
      myCommand.Parameters("@Id").Value = au_id.Value
      myCommand.Parameters.Add(New SqlParameter("@LName", _
         SqlDbType.VarChar, 40))
      myCommand.Parameters("@LName").Value = au_lname.Value
      myCommand.Parameters.Add(New SqlParameter("@FName", _
         SqlDbType.VarChar, 20))
      myCommand.Parameters("@FName").Value = au_fname.Value
      myCommand.Parameters.Add(New SqlParameter("@Phone", _
         SqlDbType.Char, 12))
      myCommand.Parameters("@Phone").Value = phone.Value
      myCommand.Parameters.Add(New SqlParameter("@Address", _ 
         SqlDbType.VarChar, 40))
      myCommand.Parameters("@Address").Value = address.Value
      myCommand.Parameters.Add(New SqlParameter("@City", _
         SqlDbType.VarChar, 20))
      myCommand.Parameters("@City").Value = city.Value
      myCommand.Parameters.Add(New SqlParameter("@State", _
         SqlDbType.Char, 2))
      myCommand.Parameters("@State").Value = state.Value
      myCommand.Parameters.Add(New SqlParameter("@Zip", _
         SqlDbType.Char, 5))
      myCommand.Parameters("@Zip").Value = zip.Value
      myCommand.Parameters.Add(New SqlParameter("@Contract", _
         SqlDbType.VarChar,1))
      myCommand.Parameters("@Contract").Value = contract.Value
      myCommand.Connection.Open()
      ' Test whether the new row can be added and  display the 
      ' appropriate message box to the user.
      Try 
         myCommand.ExecuteNonQuery()
         Message.InnerHtml = "<b>Record Added</b><br>" & insertCmd
      Catch ex As SqlException
         If ex.Number = 2627 Then
            Message.InnerHtml = "ERROR: A record already exists with " _
               & "the same primary key"
         Else
            Message.InnerHtml = "ERROR: Could not add record, please " _
               & "ensure the fields are correctly filled out"
            Message.Style("color") = "red"
         End If
     End Try

     myCommand.Connection.Close()
     BindGrid()
   End Sub
    
   ' BindGrid connects to the database and implements a SQL 
   ' SELECT query to get all the data in the "Authors" table 
   ' of the database.
   Sub BindGrid() 
      Dim myConnection As SqlConnection
      Dim myCommand As SqlDataAdapter 
      ' Create a connection to the "pubs" SQL database located on 
      ' the local computer.
      myConnection = New SqlConnection(connectionString)
      ' Connect to the SQL database using a SQL SELECT query to get all 
      ' the data from the "Authors" table.
      myCommand = New SqlDataAdapter("SELECT * FROM authors", _
         myConnection)
      ' Create and fill a new DataSet.
      Dim ds As DataSet = New DataSet()
      myCommand.Fill(ds)
      ' Bind the DataGrid control to the DataSet.
      MyDataGrid.DataSource = ds
      MyDataGrid.DataBind()
   End Sub
	</script>
	<body style="FONT: 10pt verdana">
		<form runat="server" ID="Form1">
			<h3><font face="Verdana">Inserting a Row of Data</font></h3>
			<table width="95%">
				<tr>
					<td valign="top">
						<ASP:DataGrid id="MyDataGrid" runat="server" Width="700" BackColor="#ccccff" BorderColor="black" ShowFooter="false" CellPadding="3" CellSpacing="0" Font-Name="Verdana" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" EnableViewState="false" />
					</td>
					<td valign="top">
						<table style="FONT: 8pt verdana">
							<tr>
								<td colspan="2" bgcolor="#aaaadd">
									Add a New Author:</td>
							</tr>
							<tr>
								<td nowrap>Author ID:
								</td>
								<td><input type="text" id="au_id" value="000-00-0000" runat="server" NAME="au_id"></td>
							</tr>
							<tr>
								<td nowrap>Last Name:
								</td>
								<td><input type="text" id="au_lname" value="Doe" runat="server" NAME="au_lname"></td>
							</tr>
							<tr nowrap>
								<td>First Name:
								</td>
								<td><input type="text" id="au_fname" value="John" runat="server" NAME="au_fname"></td>
							</tr>
							<tr>
								<td>Phone:
								</td>
								<td><input type="text" id="phone" value="808 555-5555" runat="server" NAME="phone"></td>
							</tr>
							<tr>
								<td>Address:
								</td>
								<td><input type="text" id="address" value="One Microsoft Way" runat="server" NAME="address"></td>
							</tr>
							<tr>
								<td>City:
								</td>
								<td><input type="text" id="city" value="Redmond" runat="server" NAME="city"></td>
							</tr>
							<tr>
								<td>State:
								</td>
								<td>
									<select id="state" runat="server" NAME="state">
										<option selected>CA</option>
										<option>IN</option>
										<option>KS</option>
										<option>MD</option>
										<option>MI</option>
										<option>OR</option>
										<option>TN</option>
										<option>UT</option>
									</select>
								</td>
							</tr>
							<tr>
								<td nowrap>Zip Code:
								</td>
								<td><input type="text" id="zip" value="98005" runat="server" NAME="zip"></td>
							</tr>
							<tr>
								<td>Contract:
								</td>
								<td>
									<select id="contract" runat="server" NAME="contract">
										<option value="0" selected>False</option>
										<option value="1">True</option>
									</select>
								</td>
							</tr>
							<tr>
								<td></td>
								<td>
									<input type="submit" OnServerClick="AddAuthor_Click" value="Add Author" runat="server" ID="Submit1" NAME="Submit1">
								</td>
							</tr>
							<tr>
								<td colspan="2" align="middle">
									<span id="Message" EnableViewState="false" runat="server"></span>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
