Imports System.Data
Imports System.Data.SqlClient
Imports System.Windows.Forms


Module Module1

  Sub Main()
    ' Create a Connection Object
    Dim ConnectionString As String = "Integrated Security=SSPI;" & _
         "Initial Catalog=Northwind;Data Source=MCB;"
    Dim conn As SqlConnection = New SqlConnection(ConnectionString)
    Dim SQL As String = "SELECT * FROM Customers; SELECT * FROM Orders"
    ' open a connection
    conn.Open()
    Dim cmd As SqlCommand = New SqlCommand(SQL, conn)
    ' Call ExecuteNonQuery on the Command Object to execute insert
    Dim res As Integer
    ' Call ExecuteReader to return a DataReader
    Dim reader As SqlDataReader = cmd.ExecuteReader()
    Dim str As String = ""
    Dim counter As Integer
    Dim bNextResult As Boolean = True
    While bNextResult = True
      While reader.Read()
        str += reader.GetValue(0).ToString() + " ,"
        counter = counter + 1
        If counter = 10 Then
          Exit While
        End If
      End While
      MessageBox.Show(str)
      bNextResult = reader.NextResult()
    End While
    ' release objects
    conn.Close()
    conn.Dispose()

  End Sub

End Module
