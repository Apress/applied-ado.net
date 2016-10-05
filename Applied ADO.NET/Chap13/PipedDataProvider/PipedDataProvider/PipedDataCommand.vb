Imports System
Imports System.Data

Namespace AppliedADO.DataProvider

    Public Class PipedDataCommand
        Implements System.Data.IDbCommand

        Public Sub New()

        End Sub

        Public Sub New(ByVal cmd As String, ByRef pdc As PipedDataConnection)
            _CommandText = cmd
            _Connection = pdc
        End Sub

        Public Sub NotSupported()
            Throw New NotSupportedException()
        End Sub

        Public Sub NotImpl()
            Throw New NotImplementedException()
        End Sub

        Public Sub Cancel() Implements IDbCommand.Cancel
            NotSupported()
        End Sub

        Public Sub Prepare() Implements IDbCommand.Prepare
        End Sub

        Public Function ExecuteNonQuery() As Integer Implements IDbCommand.ExecuteNonQuery

            '			if (_Connection == null || _Connection.State != ConnectionState.Open) 
            '				throw new InvalidOperationException("Connection must valid and open"); 
            '
            '			int recs;
            '			MDirDataReader reader = new MDirDataReader(_CommandText);
            '			reader.GetDirectory(_CommandText);
            '			recs = reader.RecordsAffected;
            '			reader.Close();
            '			return recs;
            Return 0
        End Function

        Public Function CreateParameter() As IDataParameter Implements IDbCommand.CreateParameter
            NotSupported()
            Return Nothing
        End Function

        Public Function ExecuteReader() As IDataReader Implements IDbCommand.ExecuteReader
            Dim reader As PipedDataReader
            reader = New PipedDataReader("ALL", _Connection)
            Return reader
        End Function

        Public Function ExecuteReader(ByVal b As CommandBehavior) As IDataReader Implements IDbCommand.ExecuteReader
            Return ExecuteReader()
        End Function

        Public Function ExecuteScalar() As Object Implements IDbCommand.ExecuteScalar
            NotImpl()
            Return Nothing
        End Function

        Private _CommandText As String

        Public Property CommandText() As String Implements IDbCommand.CommandText
            Get
                Return _CommandText
            End Get
            Set(ByVal Value As String)
                _CommandText = Value
            End Set
        End Property

        Private _CommandTimeout = 0
        Public Property CommandTimeout() As Integer Implements IDbCommand.CommandTimeout
            Get
                Return _CommandTimeout
            End Get
            Set(ByVal Value As Integer)
                _CommandTimeout = Value
            End Set
        End Property

        Private _CommandType As CommandType

        Public Property CommandType() As CommandType Implements IDbCommand.CommandType
            Get
                Return _CommandType
            End Get
            Set(ByVal Value As CommandType)
                If (Value <> CommandType.Text) Then
                    NotSupported()
                End If
                _CommandType = Value
            End Set
        End Property

        Private _Connection As IDbConnection

        Public Property Connection() As IDbConnection Implements IDbCommand.Connection
            Get
                Return _Connection
            End Get
            Set(ByVal Value As IDbConnection)
                _Connection = Value
            End Set
        End Property

        Public ReadOnly Property Parameters() As IDataParameterCollection Implements IDbCommand.Parameters
            Get
                NotSupported()
                Return Nothing
            End Get
        End Property

        Public Property Transaction() As IDbTransaction Implements IDbCommand.Transaction
            Get
                NotSupported()
                Return Nothing
            End Get
            Set(ByVal Value As IDbTransaction)
                NotSupported()
            End Set
        End Property

        Public Property UpdatedRowSource() As UpdateRowSource Implements IDbCommand.UpdatedRowSource
            Get
                Return UpdatedRowSource.None
            End Get
            Set(ByVal Value As UpdateRowSource)

            End Set
        End Property


    End Class
End Namespace