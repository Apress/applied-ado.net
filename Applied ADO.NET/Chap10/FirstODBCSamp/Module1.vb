Imports Microsoft.Data.Odbc
Module Module1
  Sub Main()
    ' Build a connection and SQL strings
    Dim connectionString As String = _
    "Driver={Microsoft Access Driver (*.mdb)};DBQ=c:\\Northwind.mdb"
    Dim SQL As String _
    = "SELECT EmployeeID, FirstName, LastName FROM Employees"
    ' Create connection object
    Dim conn As OdbcConnection = New OdbcConnection(connectionString)
    ' Create command object
    Dim cmd As OdbcCommand = New OdbcCommand(SQL)
    cmd.Connection = conn
    ' Open connection
    conn.Open()
    ' Call command's ExecuteReader
    Dim reader As OdbcDataReader = cmd.ExecuteReader()
    ' Read the reader and display results on the console
    Console.WriteLine("Employeed ID, First Name, Last Name ")
    While reader.Read()
      Console.Write(reader.GetInt32(0).ToString())
      Console.Write(", ")
      Console.Write(reader.GetString(1).ToString())
      Console.Write(", ")
      Console.WriteLine(reader.GetString(2).ToString())
    End While
    ' close reader and connection
    reader.Close()
    conn.Close()
    conn.Dispose()
  End Sub
End Module
