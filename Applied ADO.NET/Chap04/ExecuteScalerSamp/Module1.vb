Imports System.Data
Imports System.Data.SqlClient

Module Module1

  Sub Main()
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
         "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' open an existing Connection to the Database and Create a 
    ' Command Object with it:
    conn.Open()
    Dim cmd As SqlCommand = New SqlCommand("Customers", conn)
    ' Assign the SQL Insert statement we want to execute to the CommandText
    cmd.CommandText = "SELECT Count(*) FROM Customers"
    ' Call ExecuteNonQuery on the Command Object to execute insert
    Dim res As Integer
    res = cmd.ExecuteScalar()
    Console.WriteLine("Total Rows :" + res.ToString())
    ' release objects
    conn.Close()
    conn.Dispose()

  End Sub

End Module
