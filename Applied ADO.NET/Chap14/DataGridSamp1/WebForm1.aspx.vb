Imports System.Data.SqlClient

Public Class WebForm1
  Inherits System.Web.UI.Page
  Protected WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
  Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
  Protected WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
  Protected WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
  Protected WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
  Protected WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
  Protected WithEvents DataSet11 As DataGridSamp1.DataSet1
  Protected WithEvents DataView1 As System.Data.DataView
  Protected WithEvents Label1 As System.Web.UI.WebControls.Label
  Protected WithEvents Label2 As System.Web.UI.WebControls.Label
  Protected WithEvents Label3 As System.Web.UI.WebControls.Label
  Protected WithEvents Label4 As System.Web.UI.WebControls.Label
  Protected WithEvents TextBox1 As System.Web.UI.WebControls.TextBox
  Protected WithEvents TextBox2 As System.Web.UI.WebControls.TextBox
  Protected WithEvents TextBox3 As System.Web.UI.WebControls.TextBox
  Protected WithEvents TextBox4 As System.Web.UI.WebControls.TextBox
  Protected WithEvents AddBtn As System.Web.UI.WebControls.Button
  Protected WithEvents DeleteBtn As System.Web.UI.WebControls.Button
  Protected WithEvents UpdateBtn As System.Web.UI.WebControls.Button
  Protected WithEvents DataGrid1 As System.Web.UI.WebControls.DataGrid

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter()
    Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
    Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.DataSet11 = New DataGridSamp1.DataSet1()
    Me.DataView1 = New System.Data.DataView()
    CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataView1, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'SqlDataAdapter1
    '
    Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
    Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
    Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
    Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Employees", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("EmployeeID", "EmployeeID"), New System.Data.Common.DataColumnMapping("LastName", "LastName"), New System.Data.Common.DataColumnMapping("FirstName", "FirstName"), New System.Data.Common.DataColumnMapping("Title", "Title")})})
    Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
    '
    'SqlDeleteCommand1
    '
    Me.SqlDeleteCommand1.CommandText = "DELETE FROM Employees WHERE (EmployeeID = @Original_EmployeeID) AND (FirstName = " & _
    "@Original_FirstName) AND (LastName = @Original_LastName) AND (Title = @Original_" & _
    "Title OR @Original_Title IS NULL AND Title IS NULL)"
    Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_FirstName", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FirstName", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_LastName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastName", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
    '
    'SqlConnection1
    '
    Me.SqlConnection1.ConnectionString = "user id=sa;password=;Initial Catalog=Northwind;Data Source=MCB;"
    '
    'SqlInsertCommand1
    '
    Me.SqlInsertCommand1.CommandText = "INSERT INTO Employees(LastName, FirstName, Title) VALUES (@LastName, @FirstName, " & _
    "@Title); SELECT EmployeeID, LastName, FirstName, Title FROM Employees WHERE (Emp" & _
    "loyeeID = @@IDENTITY)"
    Me.SqlInsertCommand1.Connection = Me.SqlConnection1
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20, "LastName"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 10, "FirstName"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 30, "Title"))
    '
    'SqlSelectCommand1
    '
    Me.SqlSelectCommand1.CommandText = "SELECT EmployeeID, LastName, FirstName, Title FROM Employees"
    Me.SqlSelectCommand1.Connection = Me.SqlConnection1
    '
    'SqlUpdateCommand1
    '
    Me.SqlUpdateCommand1.CommandText = "UPDATE Employees SET LastName = @LastName, FirstName = @FirstName, Title = @Title" & _
    " WHERE (EmployeeID = @Original_EmployeeID) AND (FirstName = @Original_FirstName)" & _
    " AND (LastName = @Original_LastName) AND (Title = @Original_Title OR @Original_T" & _
    "itle IS NULL AND Title IS NULL); SELECT EmployeeID, LastName, FirstName, Title F" & _
    "ROM Employees WHERE (EmployeeID = @EmployeeID)"
    Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@LastName", System.Data.SqlDbType.NVarChar, 20, "LastName"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@FirstName", System.Data.SqlDbType.NVarChar, 10, "FirstName"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Title", System.Data.SqlDbType.NVarChar, 30, "Title"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_FirstName", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "FirstName", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_LastName", System.Data.SqlDbType.NVarChar, 20, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "LastName", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_Title", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Title", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"))
    '
    'DataSet11
    '
    Me.DataSet11.DataSetName = "DataSet1"
    Me.DataSet11.Locale = New System.Globalization.CultureInfo("en-US")
    Me.DataSet11.Namespace = "http://www.tempuri.org/DataSet1.xsd"
    '
    'DataView1
    '
    Me.DataView1.Table = Me.DataSet11.Employees
    CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DataView1, System.ComponentModel.ISupportInitialize).EndInit()

  End Sub

  Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
    'CODEGEN: This method call is required by the Web Form Designer
    'Do not modify it using the code editor.
    InitializeComponent()
  End Sub

#End Region

  Private Sub Page_Load(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles MyBase.Load
    'Put user code to initialize the page here
    SqlDataAdapter1.Fill(DataSet11)
    Page.DataBind()
  End Sub

  Sub Grid_Change(ByVal sender As Object, _
  ByVal e As DataGridPageChangedEventArgs)
    DataGrid1.CurrentPageIndex = e.NewPageIndex
    DataGrid1.DataBind()
  End Sub


  Public Function ExecuteSQL(ByVal strSQL As String) As Boolean
    ' Creating a connection 
    Dim conn As SqlConnection = New SqlConnection()
    conn = New SqlConnection(SqlConnection1.ConnectionString)
    Dim myCmd As SqlCommand = New SqlCommand(strSQL, conn)
    Try
      conn.Open()
      myCmd.ExecuteNonQuery()
    Catch exp As Exception
      'Error message
      Return False
    Finally
      ' clean up here
      conn.Close()
      conn.Dispose()
    End Try
    Return True
  End Function

  ' Refresh DataGrid 
  Private Sub FillDataGrid()
    SqlDataAdapter1.Fill(DataSet11)
    DataGrid1.DataBind()
  End Sub

  Private Sub AddBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles AddBtn.Click
    ' Build a SQL Statement
    Dim SQL As String = "INSERT INTO Employees(FirstName, LastName, Title)" & _
    " VALUES('" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "')"
    ' Execute SQL and refresh the data grid
    ExecuteSQL(SQL)
    FillDataGrid()
  End Sub

  Private Sub UpdateBtn_Click(ByVal sender As System.Object, _
ByVal e As System.EventArgs) Handles UpdateBtn.Click
    ' Build a SQL Statement
    Dim SQL As String = "UPDATE Employees SET FirstName='" & _
     TextBox2.Text + "',LastName='" + TextBox3.Text + "',Title='" + TextBox4.Text & _
     "' WHERE EmployeeID=" + TextBox1.Text
    ' Execute SQL and refresh the data grid
    ExecuteSQL(SQL)
    FillDataGrid()
  End Sub

  Private Sub DeleteBtn_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles DeleteBtn.Click
    ' Build a SQL Statement
    Dim SQL As String = "DELETE * FROM Employees WHERE EmployeeID= " + TextBox1.Text
    ' Execute SQL and refresh the data grid
    ExecuteSQL(SQL)
    FillDataGrid()
  End Sub
End Class
