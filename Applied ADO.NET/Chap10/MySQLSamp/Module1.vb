Imports Microsoft.Data.Odbc

Module Module1

  Sub Main()
    Dim connectionString As String = "Driver={MySQL};SERVER=localhost;DATABASE=NorthwindMySQL;"
    Dim conn As OdbcConnection = New OdbcConnection(connectionString)
    conn.Open()
    Dim da As OdbcDataAdapter = New OdbcDataAdapter _
    ("SELECT CustomerID, ContactName, ContactTitle FROM Customers", conn)
    Dim ds As DataSet = New DataSet("Cust")
    da.Fill(ds, "Customers")
    dataGrid1.DataSource = ds.DefaultViewManager
    conn.Close()
    conn.Dispose()


  End Sub

End Module
