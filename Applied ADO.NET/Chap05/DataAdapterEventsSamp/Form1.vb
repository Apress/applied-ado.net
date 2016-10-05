Imports System.Data.SqlClient

Public Class Form1
  Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

  Public Sub New()
    MyBase.New()

    'This call is required by the Windows Form Designer.
    InitializeComponent()

    'Add any initialization after the InitializeComponent() call

  End Sub

  'Form overrides dispose to clean up the component list.
  Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
    If disposing Then
      If Not (components Is Nothing) Then
        components.Dispose()
      End If
    End If
    MyBase.Dispose(disposing)
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  Friend WithEvents DataAdapterEventsTestBtn As System.Windows.Forms.Button
  Friend WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
  Friend WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
  Friend WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
  Friend WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
  Friend WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
  Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.DataAdapterEventsTestBtn = New System.Windows.Forms.Button()
    Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter()
    Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
    Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SuspendLayout()
    '
    'DataAdapterEventsTestBtn
    '
    Me.DataAdapterEventsTestBtn.Location = New System.Drawing.Point(48, 40)
    Me.DataAdapterEventsTestBtn.Name = "DataAdapterEventsTestBtn"
    Me.DataAdapterEventsTestBtn.Size = New System.Drawing.Size(192, 32)
    Me.DataAdapterEventsTestBtn.TabIndex = 0
    Me.DataAdapterEventsTestBtn.Text = "DataAdapterEvents Test Button"
    '
    'SqlDataAdapter1
    '
    Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
    Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
    Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
    Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Customers", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("CustomerID", "CustomerID"), New System.Data.Common.DataColumnMapping("CompanyName", "CompanyName"), New System.Data.Common.DataColumnMapping("ContactName", "ContactName")})})
    Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
    '
    'SqlDeleteCommand1
    '
    Me.SqlDeleteCommand1.CommandText = "DELETE FROM Customers WHERE (CustomerID = @Original_CustomerID) AND (CompanyName " & _
    "= @Original_CompanyName) AND (ContactName = @Original_ContactName OR @Original_C" & _
    "ontactName IS NULL AND ContactName IS NULL)"
    Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
    '
    'SqlConnection1
    '
    Me.SqlConnection1.ConnectionString = "data source=MCB;initial catalog=Northwind;integrated security=SSPI;persist securi" & _
    "ty info=False;workstation id=MCB;packet size=4096"
    '
    'SqlInsertCommand1
    '
    Me.SqlInsertCommand1.CommandText = "INSERT INTO Customers(CustomerID, CompanyName, ContactName) VALUES (@CustomerID, " & _
    "@CompanyName, @ContactName); SELECT CustomerID, CompanyName, ContactName FROM Cu" & _
    "stomers WHERE (CustomerID = @CustomerID)"
    Me.SqlInsertCommand1.Connection = Me.SqlConnection1
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"))
    '
    'SqlSelectCommand1
    '
    Me.SqlSelectCommand1.CommandText = "SELECT CustomerID, CompanyName, ContactName FROM Customers"
    Me.SqlSelectCommand1.Connection = Me.SqlConnection1
    '
    'SqlUpdateCommand1
    '
    Me.SqlUpdateCommand1.CommandText = "UPDATE Customers SET CustomerID = @CustomerID, CompanyName = @CompanyName, Contac" & _
    "tName = @ContactName WHERE (CustomerID = @Original_CustomerID) AND (CompanyName " & _
    "= @Original_CompanyName) AND (ContactName = @Original_ContactName OR @Original_C" & _
    "ontactName IS NULL AND ContactName IS NULL); SELECT CustomerID, CompanyName, Con" & _
    "tactName FROM Customers WHERE (CustomerID = @CustomerID)"
    Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing))
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(292, 273)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DataAdapterEventsTestBtn})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  'FillError event handler
  Private Shared Sub FillError(ByVal sender As Object, _
  ByVal args As FillErrorEventArgs)
    If args.Errors.GetType() Is Type.GetType("System.OverflowException") Then
      MessageBox.Show("Error in Fill operation for table " & _
                    args.DataTable.TableName & _
                    ", Error Message: " + args.Errors.Message.ToString() & _
                    ", Source: " + args.Errors.Source.ToString())
      args.Continue = True
    End If
  End Sub

  'RowUpdating event handler
  Protected Shared Sub OnRowUpdating(ByVal sender As Object, _
  ByVal e As SqlRowUpdatingEventArgs)
    ' Inserting
    If e.StatementType = StatementType.Insert Then
      MessageBox.Show("Inserting")
    End If
    ' Updating
    If e.StatementType = StatementType.Update Then
      MessageBox.Show("Updating")
    End If
    'Deleting
    If e.StatementType = StatementType.Delete Then
      MessageBox.Show("Deleting")
    End If
    ' Selecting
    If e.StatementType = StatementType.Select Then
      MessageBox.Show("Selecting")
    End If
  End Sub

  'RowUpdated event handler
  Protected Shared Sub OnRowUpdated(ByVal sender As Object, _
  ByVal e As SqlRowUpdatedEventArgs)
    If e.Status = UpdateStatus.ErrorsOccurred Then
      MessageBox.Show("Error Message: " + e.Errors.Message.ToString() & _
                    ", Source: " + e.Errors.Source.ToString())
      e.Row.RowError = e.Errors.Message
      e.Status = UpdateStatus.SkipCurrentRow
    Else
      MessageBox.Show("Updated")
    End If
  End Sub

  Private Sub DataAdapterEventsTestBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles DataAdapterEventsTestBtn.Click
    ' Create InsertCommand      
    SqlDataAdapter1.InsertCommand = New SqlCommand _
    ("INSERT INTO Customers (CustomerID, CompanyName)" & _
                "VALUES(@CustomerID, @CompanyName)", SqlConnection1)
    SqlDataAdapter1.InsertCommand.Parameters.Add("@CustomerID", _
    SqlDbType.VarChar, 5, "CustomerID")
    SqlDataAdapter1.InsertCommand.Parameters.Add("@CompanyName", _
    SqlDbType.VarChar, 30, "CompanyName")
    ' Opening Connection
    SqlConnection1.Open()
    ' Create and Fill DataSet            
    Dim custDS As DataSet = New DataSet()
    SqlDataAdapter1.Fill(custDS, "Customers")
    ' add handlers
    AddHandler SqlDataAdapter1.RowUpdating, AddressOf OnRowUpdating
    AddHandler SqlDataAdapter1.RowUpdated, AddressOf OnRowUpdated
    ' Add a new data row and call Update method
    ' of data adapter
    Dim custRow As DataRow = custDS.Tables("Customers").NewRow()
    custRow("CustomerID") = "NEWCO"
    custRow("CompanyName") = "New Company"
    custDS.Tables("Customers").Rows.Add(custRow)
    SqlDataAdapter1.Update(custDS, "Customers")
    RemoveHandler SqlDataAdapter1.RowUpdating, AddressOf OnRowUpdating
    RemoveHandler SqlDataAdapter1.RowUpdated, AddressOf OnRowUpdated
    ' Close the connection
    SqlConnection1.Close()
    SqlConnection1.Dispose()
  End Sub
End Class
