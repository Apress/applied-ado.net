Imports System.Data
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
    ' Create a SqlCommand object and pass mySP as the 
    ' SQL command and set CommandType property to 
    ' CommandType.StoredProcedure
    Dim cmd As SqlCommand = New SqlCommand("mySP", conn)
    cmd.CommandType = CommandType.StoredProcedure

    'Set the SqlParameter 
    Dim param As SqlParameter = New SqlParameter()
    param = cmd.Parameters.Add("@country", SqlDbType.VarChar, 50)
    param.Direction = ParameterDirection.Input
    param.Value = "UK"

    ' Call ExecuteReader of SqlCommand 
    Dim reader As SqlDataReader = cmd.ExecuteReader()
    ' Read all data and display on the console
    While reader.Read()
      Console.Write(reader(0).ToString())
      Console.Write(reader(1).ToString())
      Console.WriteLine(reader(2).ToString())
    End While
    Console.Read()
    ' Close reader and connection
    reader.Close()
    conn.Close()
  End Sub

End Module
