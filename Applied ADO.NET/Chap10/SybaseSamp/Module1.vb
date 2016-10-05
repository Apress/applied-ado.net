Imports System.Data.OleDb
Module Module1
  Sub Main()
    Dim connectionString As String = _
    "Provider=Sybase ASE OLE DB Provider;Datasource=sydev;" & _
    "User ID=userid;Password=password"
    Dim conn As OleDbConnection = New OleDbConnection(connectionString)
    conn.Open()
    Dim sql As String = "SELECT * FROM TABLE1"
    Dim cmd As OleDbCommand = New OleDbCommand()
    cmd.CommandType = CommandType.Text
    Dim reader As OleDbDataReader = cmd.ExecuteReader()
    While reader.Read()
      Console.WriteLine(reader("Column1").ToString() & _
      " " + reader("Column2") + " " + reader("Column3"))
    End While
    conn.Close()
    conn.Dispose()
    Console.Read()
  End Sub
End Module
