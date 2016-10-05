Imports System.Data
Imports System.Data.OleDb

Module Module1

  Sub Main()
    ' Connection and SQL strings
    Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
    "Data Source=c:\\Northwind.mdb"
    Dim SQL As String = "SELECT * FROM Orders"
    ' Create connection object
    Dim conn As OleDbConnection = New OleDbConnection(ConnectionString)
    ' Create command object
    Dim cmd As OleDbCommand = New OleDbCommand(SQL)
    cmd.Connection = conn
    ' Open connection
    conn.Open()
    ' Call command's ExecuteReader
    Dim reader As OleDbDataReader = cmd.ExecuteReader()
    While reader.Read()
      Console.Write("OrderID:" + reader.GetInt32(0).ToString())
      Console.Write(" ,")
      Console.WriteLine("Customer:" + reader.GetString(1).ToString())
    End While
    ' close reader and connection
    reader.Close()
    conn.Close()
    conn.Dispose()
  End Sub

End Module
