Imports System
Imports System.Data
Imports System.Data.SqlClient

Module Module1

  Sub Main()
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
     "Initial Catalog=Northwind;Data Source=MCB;"
    Dim SQL As String = "SELECT * FROM Orders"
    ' Create connection object
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    ' Create a SqlCommand with stored procedure as string
    Dim cmd As SqlCommand = New SqlCommand("Sales By Year", conn)
    cmd.Connection = conn
    ' set Command's CommandType as StoredProcedure
    cmd.CommandType = CommandType.StoredProcedure
    ' Create a SqlParameter and add a parameter
    Dim parm1 As SqlParameter = cmd.Parameters.Add("@Beginning_Date", _
    SqlDbType.DateTime, 20)
    parm1.Value = "7/1/1996"
    Dim parm2 As SqlParameter = cmd.Parameters.Add("@Ending_Date", _
    SqlDbType.DateTime, 20)
    parm2.Value = "7/31/1996"
    ' Open connection
    conn.Open()
    ' Call ExecuteReader to execute the stored procedure
    Dim reader As SqlDataReader = cmd.ExecuteReader()
    Dim orderlist As String = ""
    ' Read data from the reader

    While reader.Read()
      Dim nextID As String = reader("OrderID").ToString()
      Dim nextSubtotal As String = reader("Subtotal").ToString()
      orderlist += nextID + ", " + nextSubtotal + ", "
    End While


    '  While reader.Read()
    ' Dim result As String = reader("OrderID").ToString()
    ' orderlist += result + " "
    ' End While
    ' close the connection and reader
    reader.Close()
    conn.Close()
    conn.Dispose()
    ' Print data on the console
    Console.WriteLine("Orders in July")
    Console.WriteLine("===============")
    Console.WriteLine(orderlist)

  End Sub

End Module
