<%@ Import Namespace="System.Data.SqlClient" %>
<%@ Import Namespace="System.Data" %>
<HTML>
	<script language="VB" runat="server">
   Dim conn As SqlConnection
   dim connectionString as string = _
   "server=MCB;database=pubs;user id=sa;password=;"
   dim sql as string = "SELECT * FROM Authors"
         
   '  Create a connection to the "pubs" SQL database located on the 
   ' local computer. 
   Sub Page_Load(Src As Object, E As EventArgs) 
      conn = New SqlConnection(connectionString)
      ' Determine whether this page is a postback. If it is not a
      ' postback, call BindGrid.
      If Not IsPostBack Then 
         BindGrid()
      End If
   End Sub

   ' Create an index to the DataGrid row that is clicked and 
   ' call BindGrid.
   Sub MyDataGrid_Edit(sender As Object, E As DataGridCommandEventArgs)
      MyDataGrid.EditItemIndex = CInt(E.Item.ItemIndex)
      BindGrid()
   End Sub

   ' Cancel resets the index to the row's previous settings.
   Sub MyDataGrid_Cancel(sender As Object, E As DataGridCommandEventArgs)
      MyDataGrid.EditItemIndex = -1
      BindGrid()
   End Sub

   ' When the  Update link is clicked, build a SQL UPDATE command,    
   ' connect to the database, update the row's information in the 
   ' database, and rebind the DataGrid to show the updated information.
   Public Sub MyDataGrid_Update(sender As Object, _
      E As DataGridCommandEventArgs)
      Dim updateCmd As String = "UPDATE Authors SET au_id = @Id," _
         & " au_lname = @LName, au_fname = @FName, phone = @Phone," _
         & " address = @Address, city = @City, state = @State," _
         & " zip = @Zip, contract = @Contract WHERE au_id = @Id;"
      Dim  myCommand As SqlCommand = New SqlCommand(updateCmd, _
         conn)
      myCommand.Parameters.Add(New SqlParameter("@Id", SqlDbType.VarChar))
      myCommand.Parameters.Add(New SqlParameter("@LName", _
         SqlDbType.VarChar))
      myCommand.Parameters.Add(New SqlParameter("@FName", _
         SqlDbType.VarChar))
      myCommand.Parameters.Add(New SqlParameter("@Phone", _
         SqlDbType.VarChar))
      myCommand.Parameters.Add(New SqlParameter("@Address", _
         SqlDbType.VarChar))
      myCommand.Parameters.Add(New SqlParameter("@City", _
         SqlDbType.VarChar))
      myCommand.Parameters.Add(New SqlParameter("@State", _
         SqlDbType.VarChar))
      myCommand.Parameters.Add(New SqlParameter("@Zip", _
         SqlDbType.VarChar))
      myCommand.Parameters.Add(New SqlParameter("@Contract", _
         SqlDbType.VarChar))
      
      ' Initialize the SqlCommand "@ID" parameter to the ID of the row 
      ' that must be clicked.
      myCommand.Parameters("@Id").Value = _
         MyDataGrid.DataKeys(CInt(E.Item.ItemIndex))
      ' Create an array of column names.
      Dim cols() As String = {"@Id","@LName","@FName","@Phone", _
         "@Address", "@City","@State","@Zip","@Contract"}
      ' Skipping the first, second, and last columns, iterate through the 
      ' columns, checking for empty values. If an empty value is found, 
      '  display a message box. Also initialize the SqlCommand 
      ' parameter values.
      Dim numCols As Integer = E.Item.Cells.Count
      Dim i As Integer
      Dim colvalue As String
      Dim txtBox As Textbox
      For i = 2 To numCols-1
         txtBox = E.Item.Cells(i).Controls(0)
         colvalue = txtBox.Text
					Status.Text = colValue
         End If
         myCommand.Parameters(cols(i-1)).Value = colvalue
      Next i
      ' Append the last field, converting true/false values to 0/1.
      txtBox=E.Item.Cells(numCols-1).Controls(0)
    
        ' Connect to the database and update the information.
         myCommand.Connection.Open()
         ' Test  whether the data was updated and display the 
         ' appropriate message to the user.
         Try 
            myCommand.ExecuteNonQuery()
            Message.InnerHtml = "<b>Record Updated.</b><br>"
            MyDataGrid.EditItemIndex = -1
         Catch ex As SqlException
            Message.InnerHtml = "Error Updating records." 
         End Try

         ' Close the connection.
         myCommand.Connection.Close()
         ' Rebind the DataGrid to show the updated information.
         BindGrid()
   
   End Sub

   ' The BindGrid procedure connects to the database and implements
   ' a SQL SELECT query to get all the data in the "Authors" table.
   Public Sub BindGrid() 
      Dim conn As SqlConnection = _
         New SqlConnection(connectionString)
      Dim myCommand As SqlDataAdapter = New SqlDataAdapter(sql, conn)
      Dim ds As DataSet= New DataSet()
      myCommand.Fill(ds)
      MyDataGrid.DataSource = ds
      MyDataGrid.DataBind()
   End Sub
	</script>
	<%--  Display the data in the body of the page. --%>
	<body ms_positioning="GridLayout">
		<TABLE height="824" cellSpacing="0" cellPadding="0" width="208" border="0" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD width="208" height="824">
					<form runat="server">
						<TABLE height="191" cellSpacing="0" cellPadding="0" width="812" border="0" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD width="10" height="15"></TD>
								<TD width="802"></TD>
							</TR>
							<TR vAlign="top">
								<TD height="41"></TD>
								<TD>
									<h3><font face="Verdana">Updating a Row of Data.</font></h3>
								</TD>
							</TR>
							<TR vAlign="top">
								<TD height="135"></TD>
								<TD>
									<FORM runat="server">
										<TABLE height="191" cellSpacing="0" cellPadding="0" width="812" border="0" ms_2d_layout="TRUE">
											<span id="Message" EnableViewState="false" runat="server">
												<p>
													<ASP:DataGrid id="MyDataGrid" runat="server" Width="800" BackColor="#ccccff" BorderColor="black" ShowFooter="false" CellPadding="3" CellSpacing="0" Font-Name="Verdana" Font-Size="8pt" HeaderStyle-BackColor="#aaaadd" OnEditCommand="MyDataGrid_Edit" OnCancelCommand="MyDataGrid_Cancel" OnUpdateCommand="MyDataGrid_Update" DataKeyField="au_id">
														<Columns>
															<ASP:EditCommandColumn EditText="Edit" CancelText="Cancel" UpdateText="Update" />
														</Columns>
													</ASP:DataGrid>
													<asp:Label id="Status" runat="server" Font-Size="8pt" BackColor="Red" Width="395px" ForeColor="#C0FFC0">Label</asp:Label></TABLE>
									</FORM>
									</P></SPAN></TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
