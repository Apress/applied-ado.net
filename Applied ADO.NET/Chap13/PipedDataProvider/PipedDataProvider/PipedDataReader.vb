Imports System
Imports System.Data
Imports System.Data.Common
Imports System.IO

Namespace AppliedADO.DataProvider

    Public Class PipedDataReader
        Implements IDataReader, IDataRecord, IEnumerable

        Private _Command As String

        Public Sub New(ByVal cmd As String, ByRef conn As PipedDataConnection)
            _Command = cmd
            _Connection = conn
            'Taste The File To Fill In The Meta-Data
            Me.Read()
            'File Tasted, close and reopen the connection
            _Connection.Close()
            _Connection = New PipedDataConnection(_Connection.ConnectionString)
        End Sub

        Private Sub NotSupported()
            Throw New NotSupportedException()
        End Sub

        Public Function GetSchemaTable() As DataTable Implements IDataReader.GetSchemaTable
            Me.NotSupported()
        End Function

        Public Sub Close() Implements IDataReader.Close
            _isClosed = True
            If (Not _Connection Is Nothing) Then
                _Connection.Close()
            End If
        End Sub

        Public Function NextResult() As Boolean Implements IDataReader.NextResult
            Return False
        End Function

        Private splitter() As Char = {"|"}

        Public Function Read() As Boolean Implements IDataReader.Read

            Dim line As String
            line = _Connection.file.ReadLine()
            If (line = "") Then
                Return False
            End If
            Dim tCols() As String
            tCols = line.Split(splitter)
            _cols = tCols
            Return True
        End Function

        Private _depth = 3
        Public ReadOnly Property Depth() As Integer Implements IDataReader.Depth
            Get
                Return _depth
            End Get
        End Property

        Private _isClosed = False
        Public ReadOnly Property IsClosed() As Boolean Implements IDataReader.IsClosed
            Get
                Return _isClosed
            End Get
        End Property
        Private _RecordsAffected As Integer
        Public ReadOnly Property RecordsAffected() As Integer Implements IDataReader.RecordsAffected
            Get
                Return _RecordsAffected
            End Get
        End Property

        Public Function GetBoolean(ByVal i As Integer) As Boolean Implements IDataReader.GetBoolean
            Return CType(_cols(i), Integer)
        End Function

        Public Function GetByte(ByVal i As Integer) As Byte Implements IDataReader.GetByte
            Return CType(_cols(i), Byte)
        End Function

        Public Function GetBytes(ByVal i As Integer, ByVal fieldoffset As Long, ByVal bytes() As Byte, ByVal length As Integer, ByVal bufferoffset As Integer) As Long Implements IDataReader.GetBytes
            NotSupported()
            Return Nothing
        End Function

        Public Function GetChar(ByVal i As Integer) As Char Implements IDataReader.GetChar
            Return CType(_cols(i), Char)
        End Function

        Public Function GetChars(ByVal i As Integer, ByVal fieldoffset As Long, ByVal buffer As Char(), ByVal length As Integer, ByVal bufferoffset As Integer) As Long Implements IDataReader.GetChars
            NotSupported()
            Return Nothing
        End Function

        Public Function GetData(ByVal i As Integer) As IDataReader Implements IDataReader.GetData
            NotSupported()
            Return Nothing
        End Function

        Public Function GetDataTypeName(ByVal i As Integer) As String Implements IDataReader.GetDataTypeName
            Return GetType(String).ToString()
        End Function

        Public Function GetDateTime(ByVal i As Integer) As DateTime Implements IDataReader.GetDateTime
            Return CType(_cols(i), DateTime)
        End Function

        Public Function GetDecimal(ByVal i As Integer) As Decimal Implements IDataReader.GetDecimal
            Return CType(_cols(i), Decimal)
        End Function

        Public Function GetDouble(ByVal i As Integer) As Double Implements IDataReader.GetDouble
            Return CType(_cols(i), Integer)
        End Function

        Public Function GetFieldType(ByVal i As Integer) As Type Implements IDataReader.GetFieldType
            Return GetType(String)
        End Function

        Public Function GetFloat(ByVal i As Integer) As Single Implements IDataReader.GetFloat
            Return CType(_cols(i), Single)
        End Function

        Public Function GetString(ByVal i As Integer) As String Implements IDataReader.GetString
            Return CType(_cols(i), String)
        End Function

        Public Function GetGuid(ByVal i As Integer) As Guid Implements IDataReader.GetGuid
            Return CType(_cols(i), Guid)
        End Function

        Public Function GetInt16(ByVal i As Integer) As Short Implements IDataReader.GetInt16
            Return CType(_cols(i), Short)
        End Function

        Public Function GetInt32(ByVal i As Integer) As Int32 Implements IDataReader.GetInt32
            Return CType(_cols(i), Int32)
        End Function

        Public Function GetInt64(ByVal i As Integer) As Int64 Implements IDataReader.GetInt64
            Return CType(_cols(i), Int64)
        End Function

        Public Function GetName(ByVal i As Integer) As String Implements IDataReader.GetName
            Return "COLUMN" + i.ToString()
        End Function

        Public Function GetOrdinal(ByVal name As String) As Integer Implements IDataReader.GetOrdinal
            NotSupported()
            Return Nothing
        End Function

        Public Function GetValue(ByVal i As Integer) As Object Implements IDataReader.GetValue
            Return CType(_cols(i), Object)
        End Function

        Public Function GetValues(ByVal values As Object()) As Integer Implements IDataReader.GetValues
            Dim i As Integer
            If (FieldCount < 1) Then
                Return 0
            End If
            For i = 0 To FieldCount - 1
                values(i) = _cols(i)
            Next
            Return FieldCount
        End Function

        Public Function IsDBNull(ByVal i As Integer) As Boolean Implements IDataReader.IsDBNull
            Return False
        End Function

        Public ReadOnly Property FieldCount() As Integer Implements IDataReader.FieldCount
            Get
                Return _cols.Length - 1
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal name As String) As Object Implements IDataReader.Item
            Get
                Me.NotSupported()
                Return Nothing
                'Return _cols(Array.IndexOf(_names, name))
            End Get
        End Property

        Default Public ReadOnly Property Item(ByVal i As Integer) As Object Implements IDataReader.Item
            Get
                Return _cols(i)
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return New System.Data.Common.DbEnumerator(Me)
        End Function

        Private _Connection As PipedDataConnection

        Private _cols() As Object


    End Class
End Namespace
