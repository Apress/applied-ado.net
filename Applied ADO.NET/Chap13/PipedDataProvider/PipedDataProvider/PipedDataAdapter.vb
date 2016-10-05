Imports System
Imports System.Data
Imports System.Data.Common
Imports System.IO

Namespace AppliedADO.DataProvider
    Public Class PipedDataAdapter
        Inherits DbDataAdapter
        Implements IDbDataAdapter
        Public Sub New()

        End Sub

        Public Sub New(ByRef cmd As PipedDataCommand)
            _SelectCommand = cmd
        End Sub

        Private Sub NotSupported()
            Throw New NotSupportedException()
        End Sub

        Protected Overrides Function CreateRowUpdatingEvent(ByVal row As DataRow, ByVal cmd As IDbCommand, ByVal stmtType As StatementType, ByVal mapping As DataTableMapping) As RowUpdatingEventArgs
            NotSupported()
        End Function
        Protected Overrides Function CreateRowUpdatedEvent(ByVal row As DataRow, ByVal cmd As IDbCommand, ByVal stmtType As StatementType, ByVal mapping As DataTableMapping) As RowUpdatedEventArgs
            NotSupported()
        End Function

        Protected Overrides Sub OnRowUpdated(ByVal value As RowUpdatedEventArgs)

        End Sub
        Protected Overrides Sub OnRowUpdating(ByVal e As RowUpdatingEventArgs)
        End Sub

        Private _SelectCommand As IDbCommand
        Private _InsertCommand As IDbCommand
        Private _UpdateCommand As IDbCommand
        Private _DeleteCommand As IDbCommand

        Public Property SelectCommand() As IDbCommand Implements IDbDataAdapter.SelectCommand
            Get
                Return _SelectCommand
            End Get
            Set(ByVal Value As IDbCommand)
                _SelectCommand = Value
            End Set
        End Property

        Public Property InsertCommand() As IDbCommand Implements IDbDataAdapter.InsertCommand
            Get
                Return _InsertCommand
            End Get
            Set(ByVal Value As IDbCommand)
                _InsertCommand = Value
            End Set
        End Property

        Public Property UpdateCommand() As IDbCommand Implements IDbDataAdapter.UpdateCommand
            Get
                Return _UpdateCommand
            End Get
            Set(ByVal Value As IDbCommand)
                _UpdateCommand = Value
            End Set
        End Property

        Public Property DeleteCommand() As IDbCommand Implements IDbDataAdapter.DeleteCommand
            Get
                Return _DeleteCommand
            End Get
            Set(ByVal Value As IDbCommand)
                _DeleteCommand = Value
            End Set
        End Property

    End Class
End Namespace
