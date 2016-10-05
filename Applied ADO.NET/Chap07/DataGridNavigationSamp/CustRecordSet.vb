Imports System.Data.SqlClient

Public Class CustRecordSet
  Private dataAdapter As SqlDataAdapter = Nothing
  Private dataSet As DataSet = Nothing
  Private dtGrid As DataGrid = Nothing
  Private frm As Form = Nothing
  Private mapName As String = Nothing

  Public Sub CreateRecordSet(ByVal conn As SqlConnection, _
  ByVal sql As String, ByVal grid As DataGrid, ByVal curForm As Form, _
  ByVal tableName As String)
    Me.dataAdapter = New SqlDataAdapter(sql, conn)
    Me.dataSet = New DataSet("Customers")
    Me.dataAdapter.Fill(Me.dataSet, "Customers")
    dtGrid = grid
    frm = curForm
    mapName = tableName
    dtGrid.DataSource = Me.dataSet
    dtGrid.DataMember = "Customers"
  End Sub

  Public Sub FirstRecord()
    If frm.BindingContext(Me.dataSet, mapName) Is Nothing Then
      Return
    End If
    frm.BindingContext(Me.dataSet, mapName).Position = 0
  End Sub
  Public Sub PrevRecord()
    If frm.BindingContext(Me.dataSet, mapName) Is Nothing Then
      Return
    End If
    frm.BindingContext(Me.dataSet, mapName).Position -= 1
  End Sub
  Public Sub NextRecord()
    If frm.BindingContext(Me.dataSet, mapName) Is Nothing Then
      Return
    End If
    frm.BindingContext(Me.dataSet, mapName).Position += 1

  End Sub
  Public Sub LastRecord()
    If frm.BindingContext(Me.dataSet, mapName) Is Nothing Then
      Return
    End If
    frm.BindingContext(Me.dataSet, mapName).Position = _
    frm.BindingContext(Me.dataSet, mapName).Count - 1
  End Sub

End Class