Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Namespace EnterpriseVB.VideoStore.Data


Public Class VideoTape

        Protected data As DataTable
        Protected index As Integer

        Protected Friend ReadOnly Property MyData() As DataRow()
            Get
                Dim myRow() As DataRow = {Me.data.Rows(index)}
                Return myRow
            End Get
        End Property

        Public Sub New(ByRef data As VideoTapeData, ByVal index As Integer)
            Me.data = data
            Me.index = index
        End Sub
        Public Sub New()
            Me.data = New VideoTapeData()
            data.Rows.Add(data.NewRow())
            Me.index = 0
        End Sub

        Public Function GetColumn(ByRef ColumnName As String) As Object
            Return data.Rows(index)(ColumnName)
        End Function

        Public Function SetColumn(ByRef ColumnName As String, ByRef ColumnValue As Object)
            data.Rows(index)(ColumnName) = ColumnValue
        End Function

        Public Property VideoTapeID() As Decimal
            Get
                If (GetColumn("VideoTapeID").GetType() Is Type.GetType("System.DBNull")) Then
                    Return -1
                End If
                Return CType(GetColumn("VideoTapeID"), Decimal)
            End Get
            Set(ByVal Value As Decimal)
                SetColumn("VideoTapeID", Value)
            End Set
        End Property

        Public Property Title() As String
            Get
                Return "" + GetColumn("Title")
            End Get
            Set(ByVal Value As String)
                SetColumn("Title", Value)
            End Set
        End Property

        Public Property Description() As String
            Get
                Return "" + GetColumn("Description")
            End Get
            Set(ByVal Value As String)
                SetColumn("Description", Value)
            End Set
        End Property

End Class

Public Class VideoTapeData
    Inherits DataTable

    Public Sub New()
        MyBase.New("VideoTape")
        Me.Columns.Add("VideoTapeID", Type.GetType("System.Decimal"))
        Me.Columns.Add("Title", Type.GetType("System.String"))
        Me.Columns.Add("Description", Type.GetType("System.String"))

    End Sub
End Class

Public Class VideoTapeDataAccess

    Public connectionString As String
        Protected adapter As SqlDataAdapter
        Protected loadAll As SqlDataAdapter

        Public Sub New()
            connectionString = "Password=1deadrat;User ID=sa;" + _
    "Initial Catalog=VideoStore;Data Source=grimsaado2k;" + _
    "Workstation ID=GRIMSAADO2K;"


            adapter = New SqlDataAdapter()
            adapter.SelectCommand = New SqlCommand("sp_VideoTapeLoadByID", New SqlConnection(connectionString))
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            adapter.SelectCommand.Parameters.Add _
            ("@VideoTapeID", SqlDbType.Decimal, 0, "VideoTapeID")

            adapter.InsertCommand = New SqlCommand("sp_VideoTapeInsert", New SqlConnection(connectionString))
            adapter.InsertCommand.CommandType = CommandType.StoredProcedure
            adapter.InsertCommand.Parameters.Add("@VideoTapeID", SqlDbType.Decimal, 0, "VideoTapeID")
            adapter.InsertCommand.Parameters("@VideoTapeID").Direction = ParameterDirection.Output
            adapter.InsertCommand.Parameters.Add("@Title", SqlDbType.Char, 50, "Title")
            adapter.InsertCommand.Parameters.Add("@Description", SqlDbType.Text, 0, "Description")

            adapter.UpdateCommand = New SqlCommand("sp_VideoTapeUpdate", New SqlConnection(connectionString))
            adapter.UpdateCommand.CommandType = CommandType.StoredProcedure
            adapter.UpdateCommand.Parameters.Add("@VideoTapeID", SqlDbType.Decimal, 0, "VideoTapeID")
            adapter.UpdateCommand.Parameters.Add("@Title", SqlDbType.Char, 50, "Title")
            adapter.UpdateCommand.Parameters.Add("@Description", SqlDbType.Text, 0, "Description")

            adapter.DeleteCommand = New SqlCommand("sp_VideoTapeDelete", New SqlConnection(connectionString))
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure
            adapter.DeleteCommand.Parameters.Add("@VideoTapeID", SqlDbType.Decimal, 0, "VideoTapeID")

            loadAll = New SqlDataAdapter()
            loadAll.SelectCommand = New SqlCommand("sp_VideoTapeLoadAll", New SqlConnection(connectionString))
            loadAll.SelectCommand.CommandType = CommandType.StoredProcedure

        End Sub

        Public Function GetVideoTapeByID(ByVal vtID As Decimal) As VideoTape

            Dim data As New VideoTapeData()
            adapter.SelectCommand.Parameters("@VideoTapeID").Value = vtID
            adapter.Fill(data)
            If (data.Rows.Count < 1) Then
                Return Nothing
            End If
            Dim vt As New VideoTape(data, 0)
            Return vt
        End Function

        Public Function GetAllVideoTapes() As VideoTape()
            Dim data As New VideoTapeData()
            loadAll.Fill(data)
            Return GetVideoTapeArrayFromData(data)
        End Function

        Public Shared Function GetVideoTapeArrayFromData(ByRef data As VideoTapeData) As VideoTape()
            Dim vArray(data.Rows.Count - 1) As VideoTape
            Dim i As Integer
            For i = 0 To (data.Rows.Count - 1)
                vArray(i) = New VideoTape(data, i)
            Next i
            Return vArray
        End Function

        Public Function SetVideoTape(ByRef vTape As VideoTape)
            adapter.Update(vTape.MyData)
        End Function

        Public Function RemoveVideoTape(ByRef vTape As VideoTape)
            adapter.DeleteCommand.Parameters("@VideoTapeID").Value = vTape.VideoTapeID
            adapter.DeleteCommand.Connection.Open()
            adapter.DeleteCommand.ExecuteNonQuery()
            adapter.DeleteCommand.Connection.Close()
        End Function
End Class

End Namespace
