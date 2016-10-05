Imports System.Data
Imports System.Data.SqlClient


Public Class WebForm1
  Inherits System.Web.UI.Page
  Protected WithEvents DataList1 As System.Web.UI.WebControls.DataList
  Protected WithEvents SqlSelectCommand1 As System.Data.SqlClient.SqlCommand
  Protected WithEvents SqlInsertCommand1 As System.Data.SqlClient.SqlCommand
  Protected WithEvents SqlUpdateCommand1 As System.Data.SqlClient.SqlCommand
  Protected WithEvents SqlDeleteCommand1 As System.Data.SqlClient.SqlCommand
  Protected WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
  Protected WithEvents SqlDataAdapter1 As System.Data.SqlClient.SqlDataAdapter
  Protected WithEvents DataSet11 As DataListUsingIDESamp.DataSet1
  Protected WithEvents DataView1 As System.Data.DataView

#Region " Web Form Designer Generated Code "

  'This call is required by the Web Form Designer.
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.SqlSelectCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
    Me.SqlInsertCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlUpdateCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlDeleteCommand1 = New System.Data.SqlClient.SqlCommand()
    Me.SqlDataAdapter1 = New System.Data.SqlClient.SqlDataAdapter()
    Me.DataSet11 = New DataListUsingIDESamp.DataSet1()
    Me.DataView1 = New System.Data.DataView()
    CType(Me.DataSet11, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DataView1, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'SqlSelectCommand1
    '
    Me.SqlSelectCommand1.CommandText = "SELECT CategoryID, CategoryName, Description, Picture FROM Categories"
    Me.SqlSelectCommand1.Connection = Me.SqlConnection1
    '
    'SqlConnection1
    '
    Me.SqlConnection1.ConnectionString = "data source=MCB;initial catalog=Northwind;user id=sa;password=;workstation id=MCB" & _
    ";packet size=4096"
    '
    'SqlInsertCommand1
    '
    Me.SqlInsertCommand1.CommandText = "INSERT INTO Categories(CategoryName, Description, Picture) VALUES (@CategoryName," & _
    " @Description, @Picture); SELECT CategoryID, CategoryName, Description, Picture " & _
    "FROM Categories WHERE (CategoryID = @@IDENTITY)"
    Me.SqlInsertCommand1.Connection = Me.SqlConnection1
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CategoryName", System.Data.SqlDbType.NVarChar, 15, "CategoryName"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 1073741823, "Description"))
    Me.SqlInsertCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Picture", System.Data.SqlDbType.VarBinary, 2147483647, "Picture"))
    '
    'SqlUpdateCommand1
    '
    Me.SqlUpdateCommand1.CommandText = "UPDATE Categories SET CategoryName = @CategoryName, Description = @Description, P" & _
    "icture = @Picture WHERE (CategoryID = @Original_CategoryID) AND (CategoryName = " & _
    "@Original_CategoryName); SELECT CategoryID, CategoryName, Description, Picture F" & _
    "ROM Categories WHERE (CategoryID = @CategoryID)"
    Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CategoryName", System.Data.SqlDbType.NVarChar, 15, "CategoryName"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Description", System.Data.SqlDbType.NVarChar, 1073741823, "Description"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Picture", System.Data.SqlDbType.VarBinary, 2147483647, "Picture"))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CategoryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CategoryID", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CategoryName", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CategoryName", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlUpdateCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@CategoryID", System.Data.SqlDbType.Int, 4, "CategoryID"))
    '
    'SqlDeleteCommand1
    '
    Me.SqlDeleteCommand1.CommandText = "DELETE FROM Categories WHERE (CategoryID = @Original_CategoryID) AND (CategoryNam" & _
    "e = @Original_CategoryName)"
    Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CategoryID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CategoryID", System.Data.DataRowVersion.Original, Nothing))
    Me.SqlDeleteCommand1.Parameters.Add(New System.Data.SqlClient.SqlParameter("@Original_CategoryName", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CategoryName", System.Data.DataRowVersion.Original, Nothing))
    '
    'SqlDataAdapter1
    '
    Me.SqlDataAdapter1.DeleteCommand = Me.SqlDeleteCommand1
    Me.SqlDataAdapter1.InsertCommand = Me.SqlInsertCommand1
    Me.SqlDataAdapter1.SelectCommand = Me.SqlSelectCommand1
    Me.SqlDataAdapter1.TableMappings.AddRange(New System.Data.Common.DataTableMapping() {New System.Data.Common.DataTableMapping("Table", "Categories", New System.Data.Common.DataColumnMapping() {New System.Data.Common.DataColumnMapping("CategoryID", "CategoryID"), New System.Data.Common.DataColumnMapping("CategoryName", "CategoryName"), New System.Data.Common.DataColumnMapping("Description", "Description"), New System.Data.Common.DataColumnMapping("Picture", "Picture")})})
    Me.SqlDataAdapter1.UpdateCommand = Me.SqlUpdateCommand1
    '
    'DataSet11
    '
    Me.DataSet11.DataSetName = "DataSet1"
    Me.DataSet11.Locale = New System.Globalization.CultureInfo("en-US")
    Me.DataSet11.Namespace = "http://www.tempuri.org/DataSet1.xsd"
    '
    'DataView1
    '
    Me.DataView1.Table = Me.DataSet11.Categories
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
    Dim conn As SqlConnection
    Dim adapter As SqlDataAdapter
    Dim connectionString = _
    "Data Source=MCB;Initial Catalog=Northwind;user id=sa;password=;"
    conn = New SqlConnection(connectionString)
    conn.Open()
    Dim sql = "SELECT * FROM Categories"
    adapter = New SqlDataAdapter(sql, conn)
    Dim ds As DataSet = New DataSet()
    adapter.Fill(ds)
    DataList1.DataSource = ds
    DataList1.DataBind()

    Dim keys As DataKeyCollection = DataList1.DataKeys
    Dim key As DataKey = New DataKe()
    for each 

  End Sub

End Class
