Imports System.Data
Imports System.Data.SqlClient

Module Module1

  Sub Main()
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
         "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim SQL As String = "SELECT * FROM Customers"
    ' open a connection
    conn.Open()
    Dim cmd As SqlCommand = New SqlCommand(SQL, conn)
    ' Call ExecuteNonQuery on the Command Object to execute insert
    Dim res As Integer
    ' Call ExecuteReader to return a DataReader
    Dim reader As SqlDataReader = cmd.ExecuteReader()
    Console.WriteLine("Customer ID, Contact Name," & _
    "Contact Title, Address")
    Console.WriteLine("===================================")
    While reader.Read()
      If Not reader.IsDBNull(0) Then
        Console.Write(reader("CustomerID").ToString() + ", ")
        Console.Write(reader("ContactName").ToString() + ", ")
        Console.Write(reader("ContactTitle").ToString() + ", ")
        Console.WriteLine(reader("Address").ToString() + ", ")
      End If
    End While
    Console.WriteLine("Affected Records: " & _
    reader.RecordsAffected.ToString())
    ' release objects
    conn.Close()
    conn.Dispose()

  End Sub

End Module
