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
      Dim errs As SqlErrorCollection = exp.Errors
      Dim i As Integer
      Dim err As SqlError
      For Each err In errs
        Console.WriteLine("Error #:" & i.ToString() & _
              ", Class:" & err.Class.ToString() & _
              ", Line Number :" & err.LineNumber & _
              ", Message:" & err.Message & _
              ", Source:" & err.Source & _
              ", Server:" & err.Server)
      Next
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
