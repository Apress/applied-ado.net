Imports System.Data
Imports System.Data.OleDb

Module Module1

  Sub Main()

    ' Create a Connection Object
    Dim ConnectionString As String = "Provider=Microsoft.Jet.OLEDB.4.0;" & _
     "Data Source=c:\\Northwind.mdb"
    Dim conn As OleDbConnection = New OleDbConnection(ConnectionString)
    Dim cmd As OleDbCommand = New OleDbCommand()
    cmd.Connection = conn
    cmd.CommandText = "Customers"
    cmd.CommandType = CommandType.TableDirect
    conn.Open()
    Dim reader As OleDbDataReader = cmd.ExecuteReader()
    Console.WriteLine("Customer Id, Contact Name, Company Name")
    Console.WriteLine("=======================================")
    While reader.Read()
      Console.Write(reader("CustomerID").ToString())
      Console.Write(", " + reader("ContactName").ToString())
      Console.WriteLine(", " + reader("CompanyName").ToString())
    End While
    ' release objects
    reader.Close()
    conn.Close()
    conn.Dispose()
  End Sub
End Module
