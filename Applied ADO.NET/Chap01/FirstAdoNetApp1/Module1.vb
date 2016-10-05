Imports System.Data.OleDb

Module Module1

  Sub Main()
    Dim connectionString As String
    Dim sql As String
    ' Construct a connection string
    connectionString = "Provider=Microsoft.JET.OLEDB.4.0;" & _
    "data source=C:\\Northwind.mdb"
    ' Create a connection object
    Dim conn As OleDbConnection = New OleDbConnection(connectionString)
    sql = "SELECT CustomerID, ContactName, ContactTitle FROM Customers"
    ' create a Command object
    Dim cmd As OleDbCommand = New OleDbCommand(sql, conn)
    ' Open the connection
    conn.Open()
    ' Creat a DataReader and call Command's ExecuteReader method
    Dim reader As OleDbDataReader
    reader = cmd.ExecuteReader()
    Console.WriteLine("Contact Name, Contact Title")
    Console.WriteLine("=======================")

    ' Read until reader has records
    While reader.Read()
      Console.Write(reader.GetString(0).ToString() + " ,")
      Console.Write(reader.GetString(1).ToString() + " ,")
      Console.WriteLine("")
    End While
    ' Close reader
    reader.Close()
    ' Close the connection
    conn.Close()
  End Sub

End Module
