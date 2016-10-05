Imports System.Data
Imports System.Data.SqlClient

Module Module1

  Sub Main()

    ' Connection and SQL strings
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
             "Initial Catalog=Northwind;Data Source=MCB;"
    Dim SQL As String = "SELECT * FROM Orders"
    ' Create connection object
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Create command object
    Dim cmd As SqlCommand = New SqlCommand(SQL)
    cmd.Connection = conn
    ' Open connection
    conn.Open()
    ' Call command's ExecuteReader
    Dim reader As SqlDataReader = cmd.ExecuteReader()
    While reader.Read()
      If Not reader.IsDBNull(0) Then
        Console.Write("OrderID:" + reader.GetInt32(0).ToString())
        Console.Write(" ,")
        Console.WriteLine("Customer:" + reader.GetString(1).ToString())
      End If
    End While
    ' close reader and connection
    reader.Close()
    conn.Close()
    'Dispose
    conn.Dispose()

  End Sub

End Module
