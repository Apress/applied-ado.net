Imports System.Data.SqlClient

Module Module1
  Sub Main()
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
         "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim SQL As String = "SELECT * FROM Test"
    Dim adapter As SqlDataAdapter = New SqlDataAdapter(SQL, conn)
    Dim ds As DataSet = New DataSet()

    Try
      ' open a connection
      conn.Open()
      adapter.Fill(ds, "Customers")
    Catch exp As SqlException
      ' Generate error message
      Console.WriteLine("Error:" + exp.Message & _
      ", Number:" + exp.Number.ToString() & _
      ", Line Number: " + exp.LineNumber.ToString() & _
      ", Server:" + exp.Server.ToString() & _
       ", Source:" + exp.Source.ToString())
    Finally
      ' Close the connection
      If conn.State = ConnectionState.Open Then
        conn.Close()
      End If
      ' Dispose the connection
      If (Not conn Is Nothing) Then
        conn.Dispose()
      End If
    End Try

  End Sub

End Module
