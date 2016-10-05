Imports System.Data.OleDb

Module Module1



    Sub Main()
        Dim str As String
        Dim connectionString As String = _
        "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=F:\\AppliedAdoNet.mdb"
        ' Create and open a connection
        Dim conn As OleDbConnection = _
        New OleDbConnection(connectionString)
        conn.Open()
        ' Start a transaction
        Dim tran As OleDbTransaction = conn.BeginTransaction()
        Dim cmd As OleDbCommand = New OleDbCommand()
        cmd.Connection = conn
        cmd.Transaction = tran

        Try
            str = "INSERT INTO Users (UserName, UserDescription)" & _
            " VALUES ('New User', 'New Description')"
            cmd.CommandText = str
            cmd.ExecuteNonQuery()
            str = "UPDATE Users SET UserName = 'Updated User' WHERE " & _
                  " UserName = 'New User'"
            cmd.CommandText = str
            cmd.ExecuteNonQuery()
            str = "DELETE * FROM Users WHERE UserName = 'Updated User'"
            cmd.CommandText = str
            cmd.ExecuteNonQuery()
            ' Commit transaction
            tran.Commit()
            Console.WriteLine("Changes saved.")
        Catch e As Exception
            ' Rollback transaction
            tran.Rollback()
            Console.WriteLine(e.Message.ToString())
            Console.WriteLine("No changes were made to database.")
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub

End Module
