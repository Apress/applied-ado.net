Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient

Module Module1

  Sub Main()
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
              "Initial Catalog=Northwind;" & _
              "Data Source=localhost;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Open the connection
    conn.Open()
    Dim sql As String = _
    "SELECT CategoryID, CategoryName, Description FROM Categories"
    Dim da As SqlDataAdapter = New SqlDataAdapter(sql, conn)
    da.InsertCommand = New SqlCommand("AddCat1", conn)
    da.InsertCommand.CommandType = CommandType.StoredProcedure

    ' Create a SqlParameter 
    Dim param As SqlParameter = _
    da.InsertCommand.Parameters.Add("@RowCount", SqlDbType.Int)
    param.Direction = ParameterDirection.ReturnValue
    da.InsertCommand.Parameters.Add _
("@CategoryName", SqlDbType.NChar, 15, "CategoryName")
    da.InsertCommand.Parameters.Add _
    ("@Description", SqlDbType.Char, 16, "Description")
    param = da.InsertCommand.Parameters.Add _
    ("@Identity", SqlDbType.Int, 0, "CategoryID")
    param.Direction = ParameterDirection.Output
    ' Creat a DataSet and fill it
    Dim ds As DataSet = New DataSet()
    da.Fill(ds, "Categories")
    ' Creat a DataRow and add it to the DataSet's DataTable
    Dim row As DataRow = ds.Tables("Categories").NewRow()
    row("CategoryName") = "Beverages"
    row("Description") = "Chai"
    ds.Tables("Categories").Rows.Add(row)
    ' Save changes to the database
    da.Update(ds, "Categories")
    ' Output
    Console.WriteLine(da.InsertCommand.Parameters _
    ("@RowCount").Value.ToString())

  End Sub

End Module
