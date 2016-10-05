Imports System.Data
Imports System.Data.SqlClient

Public Class DbOpsClass
  Shared conn As SqlConnection = Nothing
  Shared adapter As SqlDataAdapter = Nothing
  Shared reader As SqlDataReader = Nothing
  Shared ds As DataSet = Nothing
  Shared cmd As SqlCommand = Nothing

  ' Method used to return data as a DataSet
  Public Function GetDataSet(ByVal connStr As String, _
  ByVal sql As String) As DataSet
    If (connStr.Equals(String.Empty) Or sql.Equals(String.Empty)) Then
      Return Nothing
    End If
    conn = New SqlConnection(connStr)
    ' Open connection if already not open
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    ds = New DataSet()
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Fill(ds)
    ' Close and dispose connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
      conn.Dispose()
    End If
    Return ds
  End Function
  
  ' Executes a SQL Statement. Useful in Deleting 
  ' and Updating database
  Public Sub ExecuteSqlStmt(ByVal connStr As String, _
  ByVal sql As String)
    If (connStr.Equals(String.Empty) Or sql.Equals(String.Empty)) Then
      Return
    End If
    conn = New SqlConnection(connStr)
    ' Open connection if already not open
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    cmd = New SqlCommand(sql)
    cmd.Connection = conn
    cmd.ExecuteNonQuery()
    ' Close and dispose connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
      conn.Dispose()
    End If
  End Sub

  ' Save a changed DataSet
  Public Sub SaveDataSet(ByVal connStr As String, _
  ByVal sql As String, ByVal ds As DataSet)
    If (connStr.Equals(String.Empty)) Then
      Return
    End If
    conn = New SqlConnection(connStr)
    ' Open connection if already not open
    If conn.State <> ConnectionState.Open Then
      conn.Open()
    End If
    ds = New DataSet()
    adapter = New SqlDataAdapter(sql, conn)
    adapter.Update(ds)
    ' Close and dispose connection
    If conn.State = ConnectionState.Open Then
      conn.Close()
      conn.Dispose()
    End If
  End Sub

End Class
