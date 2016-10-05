Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common

Namespace EnterpriseVB.VideoStore.Data

    Public Class VideoCheckInCheckOut
        Private connectionString As String

        Public Sub New(ByVal connStr As String)
            Me.connectionString = connStr
        End Sub

        Public Function GetVideoTapesCheckedOutToUser(ByRef usr As User) As VideoTape()
            Dim cmd As New SqlDataAdapter("sp_SelectVideosCheckedOutToUser", New SqlConnection(connectionString))
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure
            cmd.SelectCommand.Parameters.Add("@UserID", SqlDbType.Decimal)
            cmd.SelectCommand.Parameters("@UserID").Value = usr.UserID
            Dim data As New VideoTapeData()
            cmd.Fill(data)
            Return VideoTapeDataAccess.GetVideoTapeArrayFromData(data)
        End Function

        Public Function GetVideoTapesCheckedIn() As VideoTape()
            Dim cmd As New SqlDataAdapter("sp_SelectVideosCheckedIn", New SqlConnection(connectionString))
            cmd.SelectCommand.CommandType = CommandType.StoredProcedure
            Dim data As New VideoTapeData()
            cmd.Fill(data)
            Return VideoTapeDataAccess.GetVideoTapeArrayFromData(data)
        End Function

        Public Function CheckOutVideoToUser(ByRef usr As User, ByRef toUsr As User, ByRef vt As VideoTape)
            If (Me.IsVideoCheckedOut(vt)) Then
                Throw New Exception("Video is already checked out to another user.")
            End If
            Dim cmd As New SqlCommand("sp_CheckOutVideo", New SqlConnection(connectionString))
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@CheckedOutByUserID", SqlDbType.Decimal)
            cmd.Parameters.Add("@CheckedOutToUserID", SqlDbType.Decimal)
            cmd.Parameters.Add("@VideoTapeID", SqlDbType.Decimal)
            cmd.Parameters("@CheckedOutToUserID").Value = usr.UserID
            cmd.Parameters("@CheckedOutByUserID").Value = toUsr.UserID
            cmd.Parameters("@VideoTapeID").Value = vt.VideoTapeID
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
        End Function

        Public Function CheckInVideoFromUser(ByRef usr As User, ByRef vt As VideoTape)
            Dim cmd As New SqlCommand("sp_CheckInVideo", New SqlConnection(connectionString))
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@UserID", SqlDbType.Decimal)
            cmd.Parameters.Add("@VideoTapeID", SqlDbType.Decimal)
            cmd.Parameters("@UserID").Value = usr.UserID
            cmd.Parameters("@VideoTapeID").Value = vt.VideoTapeID
            cmd.Connection.Open()
            cmd.ExecuteNonQuery()
            cmd.Connection.Close()
        End Function

        Public Function IsVideoCheckedOut(ByRef vt As VideoTape) As Boolean
            Dim cmd As New SqlCommand("sp_IsVideoCheckedOut", New SqlConnection(connectionString))
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@VideoTapeID", SqlDbType.Decimal)
            cmd.Parameters("@VideoTapeID").Value = vt.VideoTapeID
            cmd.Connection.Open()
            Dim isCheckedOut As Boolean
            isCheckedOut = cmd.ExecuteScalar()
            cmd.Connection.Close()
            Return isCheckedOut
        End Function
    End Class



End Namespace