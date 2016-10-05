Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Namespace EnterpriseVB.VideoStore.Data


    Public Class User

        Protected data As DataTable
        Protected index As Integer

        Protected Friend ReadOnly Property MyData() As DataRow()
            Get
                Dim myRow() As DataRow = {Me.data.Rows(index)}
                Return myRow
            End Get
        End Property

        Public Sub New(ByRef data As UserData, ByVal index As Integer)
            Me.data = data
            Me.index = index
        End Sub

        Public Function GetColumn(ByRef ColumnName As String) As Object
            Return data.Rows(index)(ColumnName)
        End Function

        Public Function SetColumn(ByRef ColumnName As String, ByRef ColumnValue As Object)
            data.Rows(index)(ColumnName) = ColumnValue
        End Function

        Public Property UserID() As Decimal
            Get
                If (GetColumn("UserID").GetType() Is Type.GetType("System.DBNull")) Then
                    Return -1
                End If
                Return CType(GetColumn("UserID"), Decimal)
            End Get
            Set(ByVal Value As Decimal)
                SetColumn("UserID", Value)
            End Set
        End Property

        Public Property FirstName() As String
            Get
                Return CType(GetColumn("FirstName"), String).Trim()
            End Get
            Set(ByVal Value As String)
                SetColumn("FirstName", Value)
            End Set
        End Property

        Public Property LastName() As String
            Get
                Return CType(GetColumn("LastName"), String).Trim()
            End Get
            Set(ByVal Value As String)
                SetColumn("LastName", Value)
            End Set
        End Property

        Public ReadOnly Property FullName() As String
            Get
                Return FirstName + " " + LastName
            End Get
        End Property

    End Class

    Public Class UserData
        Inherits DataTable

        Public Sub New()
            MyBase.New("Users")
            Me.Columns.Add("UserID", Type.GetType("System.Decimal"))
            Me.Columns.Add("FirstName", Type.GetType("System.String"))
            Me.Columns.Add("LastName", Type.GetType("System.String"))

        End Sub
    End Class

    Public Class UserDataAccess

        Public connectionString As String
        Protected adapter As SqlDataAdapter
        Protected loadAll As SqlDataAdapter

        Public Sub New()
            connectionString = "Password=1deadrat;User ID=sa;" + _
    "Initial Catalog=VideoStore2;Data Source=grimsaado2k;" + _
    "Workstation ID=GRIMSAADO2K;"


            adapter = New SqlDataAdapter()
            adapter.SelectCommand = New SqlCommand("sp_UsersLoadByID", New SqlConnection(connectionString))
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand.Parameters.Add _
            ("@UserID", SqlDbType.Decimal, 0, "UserID")

            adapter.InsertCommand = New SqlCommand("sp_UsersInsert", New SqlConnection(connectionString))
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure
            adapter.InsertCommand.Parameters.Add("@UserID", SqlDbType.Decimal, 0, "UserID")
            adapter.InsertCommand.Parameters("@UserID").Direction = ParameterDirection.Output
            adapter.InsertCommand.Parameters.Add("@FirstName", SqlDbType.Char, 50, "FirstName")
            adapter.InsertCommand.Parameters.Add("@LastName", SqlDbType.Text, 0, "LastName")

            adapter.UpdateCommand = New SqlCommand("sp_UsersUpdate", New SqlConnection(connectionString))
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure
            adapter.UpdateCommand.Parameters.Add("@UserID", SqlDbType.Decimal, 0, "UserID")
            adapter.UpdateCommand.Parameters.Add("@FirstName", SqlDbType.Char, 50, "FirstName")
            adapter.UpdateCommand.Parameters.Add("@LastName", SqlDbType.Text, 0, "LastName")

            adapter.DeleteCommand = New SqlCommand("sp_UsersDelete", New SqlConnection(connectionString))
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            adapter.DeleteCommand.Parameters.Add("@UserID", SqlDbType.Decimal, 0, "UserID")

            loadAll = New SqlDataAdapter()
            loadAll.SelectCommand = New SqlCommand("sp_UsersLoadAll", New SqlConnection(connectionString))
            loadAll.SelectCommand.CommandType = CommandType.StoredProcedure

        End Sub

        Public Function GetUserByID(ByVal userID As Decimal) As User

            Dim data As New UserData()
            adapter.SelectCommand.Parameters("@UserID").Value = userID
            adapter.Fill(data)
            If (data.Rows.Count < 1) Then
                Return Nothing
            End If
            Dim vt As New User(data, 0)
            Return vt
        End Function

        Public Function GetAllUsers() As User()
            Dim data As New UserData()
            loadAll.Fill(data)
            Dim uArray(data.Rows.Count - 1) As User
            Dim i As Integer

            For i = 0 To (data.Rows.Count - 1)
                uArray(i) = New User(data, i)
            Next i

            Return uArray
        End Function

        Public Function SetUser(ByRef user As User)
            adapter.Update(user.MyData)
        End Function

        Public Function RemoveUser(ByRef user As User)
            adapter.DeleteCommand.Parameters("@UserID").Value = user.UserID
            adapter.DeleteCommand.Connection.Open()
            adapter.DeleteCommand.ExecuteNonQuery()
            adapter.DeleteCommand.Connection.Close()
        End Function
    End Class

End Namespace
