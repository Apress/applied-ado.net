Imports System
Imports System.Data
Imports System.IO

Namespace AppliedADO.DataProvider

    Public Class PipedDataConnection
        Implements System.Data.IDbConnection

        Public FileName As String
        Friend file As System.IO.StreamReader


        Public Sub New(ByVal fn As String)
            Me.FileName = fn
            file = New StreamReader(New FileStream(Me.FileName, FileMode.Open))
            _State = ConnectionState.Open
        End Sub

        Public Sub NotSupported()
            Throw New System.NotSupportedException()
        End Sub

        Public Function BeginTransaction(ByVal iso As IsolationLevel) As IDbTransaction Implements IDbConnection.BeginTransaction
            NotSupported()
            Return Nothing
        End Function

        Public Function BeginTransaction() As IDbTransaction Implements IDbConnection.BeginTransaction
            NotSupported()
            Return Nothing
        End Function

        Public Sub ChangeDatabase(ByVal newDB As String) Implements IDbConnection.ChangeDatabase
            NotSupported()
        End Sub

        Public Function CreateCommand() As IDbCommand Implements IDbConnection.CreateCommand
            Dim idbCmd As IDbCommand
            idbCmd = New PipedDataCommand()
            Return idbCmd
        End Function

        Public Sub Close() Implements IDbConnection.Close
            file.Close()
            _State = ConnectionState.Closed
        End Sub

        Public Sub Open() Implements IDbConnection.Open
            _State = ConnectionState.Open
        End Sub

        Dim _State As ConnectionState

        Public ReadOnly Property State() As ConnectionState Implements IDbConnection.State
            Get
                Return _State
            End Get
        End Property

        Public Property ConnectionString() As String Implements IDbConnection.ConnectionString
            Get
                Return FileName
            End Get
            Set(ByVal Value As String)
                FileName = Value
            End Set
        End Property

        Private _ConnectionTimeout = 0

        Public ReadOnly Property ConnectionTimeout() As Integer Implements IDbConnection.ConnectionTimeout
            Get
                Return _ConnectionTimeout
            End Get
        End Property

        Private _Database = ""
        Public ReadOnly Property Database() As String Implements IDbConnection.Database
            Get
                Return _Database
            End Get
        End Property
    End Class
End Namespace
