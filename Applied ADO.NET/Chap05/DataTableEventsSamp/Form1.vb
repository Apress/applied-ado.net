Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
  Friend WithEvents ColumnChange As System.Windows.Forms.Button
  Friend WithEvents UpdateRow As System.Windows.Forms.Button
  Friend WithEvents DeleteRow As System.Windows.Forms.Button
  <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
    Me.ColumnChange = New System.Windows.Forms.Button()
    Me.UpdateRow = New System.Windows.Forms.Button()
    Me.DeleteRow = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'ColumnChange
    '
    Me.ColumnChange.Location = New System.Drawing.Point(72, 24)
    Me.ColumnChange.Name = "ColumnChange"
    Me.ColumnChange.Size = New System.Drawing.Size(152, 32)
    Me.ColumnChange.TabIndex = 0
    Me.ColumnChange.Text = "ColumnChange Events"
    '
    'UpdateRow
    '
    Me.UpdateRow.Location = New System.Drawing.Point(72, 80)
    Me.UpdateRow.Name = "UpdateRow"
    Me.UpdateRow.Size = New System.Drawing.Size(152, 32)
    Me.UpdateRow.TabIndex = 1
    Me.UpdateRow.Text = "UpdateRow Event"
    '
    'DeleteRow
    '
    Me.DeleteRow.Location = New System.Drawing.Point(72, 144)
    Me.DeleteRow.Name = "DeleteRow"
    Me.DeleteRow.Size = New System.Drawing.Size(152, 32)
    Me.DeleteRow.TabIndex = 2
    Me.DeleteRow.Text = "DeleteRow Event"
    '
    'Form1
    '
    Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
    Me.ClientSize = New System.Drawing.Size(376, 285)
    Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.DeleteRow, Me.UpdateRow, Me.ColumnChange})
    Me.Name = "Form1"
    Me.Text = "Form1"
    Me.ResumeLayout(False)

  End Sub

#End Region

  Private Sub ColumnChange_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles ColumnChange.Click

    Dim custTable As DataTable = New DataTable("Customers")
    ' add columns
    custTable.Columns.Add("id", Type.GetType("System.Int32"))
    custTable.Columns.Add("name", Type.GetType("System.String"))
    custTable.Columns.Add("address", Type.GetType("System.String"))
    ' add a ColumnChanged & ColumnChanging event handler for the table.
    AddHandler custTable.ColumnChanged, New DataColumnChangeEventHandler _
    (AddressOf Column_Changed)
    AddHandler custTable.ColumnChanging, New DataColumnChangeEventHandler _
    (AddressOf Column_Changing)
    ' add Two rows
    custTable.Rows.Add(New Object() {1, "name1", "address1"})
    custTable.Rows.Add(New Object() {2, "name2", "address2"})
    ' Save changes
    custTable.AcceptChanges()
    ' change Address column in all the rows
    Dim row As DataRow
    For Each row In custTable.Rows
      row("address") = "New address"
    Next
    ' Removing event handlers
    RemoveHandler custTable.ColumnChanged, AddressOf Column_Changed
    RemoveHandler custTable.ColumnChanging, AddressOf Column_Changing
  End Sub

  ' Column changed event handler
  Private Shared Sub Column_Changed(ByVal sender As Object, _
  ByVal e As DataColumnChangeEventArgs)

    MessageBox.Show("Column_Changed Event: " + " ," & _
   e.Row("name") + " ," + e.Column.ColumnName + " ," & _
    e.Row("name", DataRowVersion.Original))

  End Sub
  ' Column Changing event handler
  Private Shared Sub Column_Changing(ByVal sender As Object, _
  ByVal e As DataColumnChangeEventArgs)
    MessageBox.Show("Column_Changing Event: " + " ," & _
    e.Row("name") + " ," + e.Column.ColumnName + " ," & _
    e.Row("name", DataRowVersion.Original))
  End Sub




  ' Row Changed and Row Changing Events Caller
  Private Sub UpdateRow_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles UpdateRow.Click

    Dim custTable As DataTable = New DataTable("Customers")
    ' add columns
    custTable.Columns.Add("id", Type.GetType("System.Int32"))
    custTable.Columns.Add("name", Type.GetType("System.String"))
    custTable.Columns.Add("address", Type.GetType("System.String"))
    ' add a ColumnChanged & ColumnChanging event handler for the table.
    AddHandler custTable.RowChanged, New DataRowChangeEventHandler _
    (AddressOf Row_Changed)
    AddHandler custTable.RowChanged, New DataRowChangeEventHandler _
    (AddressOf Row_Changing)
    ' add Two rows
    custTable.Rows.Add(New Object() {1, "name1", "address1"})
    custTable.Rows.Add(New Object() {2, "name2", "address2"})
    ' Save changes
    custTable.AcceptChanges()
    ' change Address column in all the rows
    Dim row As DataRow
    For Each row In custTable.Rows
      row("name") = "New name"
    Next
    ' Removing event handlers
    RemoveHandler custTable.RowChanged, AddressOf Row_Changed
    RemoveHandler custTable.RowChanging, AddressOf Row_Changing
  End Sub
  ' Row Changed event handler
  Private Shared Sub Row_Changed(ByVal sender As Object, _
  ByVal e As DataRowChangeEventArgs)
    MessageBox.Show("Row_Changed Event:" & _
    e.Row("name", DataRowVersion.Original).ToString() & _
    e.Action.ToString())
  End Sub
  ' Row Changing event handler
  Private Shared Sub Row_Changing(ByVal sender As Object, _
  ByVal e As DataRowChangeEventArgs)
    MessageBox.Show("Row_Changing Event:" & _
    e.Row("name", DataRowVersion.Original).ToString() & _
    e.Action.ToString())
  End Sub




  ' Row Deleted and Row Deleting Events Caller
  Private Sub DeleteRow_Click(ByVal sender As System.Object, _
  ByVal e As System.EventArgs) Handles DeleteRow.Click
    Dim custTable As DataTable = New DataTable("Customers")
    ' add columns
    custTable.Columns.Add("id", Type.GetType("System.Int32"))
    custTable.Columns.Add("name", Type.GetType("System.String"))
    custTable.Columns.Add("address", Type.GetType("System.String"))
    ' add a ColumnChanged & ColumnChanging event handler for the table.
    AddHandler custTable.RowDeleted, New DataRowChangeEventHandler _
    (AddressOf Row_Deleted)
    AddHandler custTable.RowDeleting, New DataRowChangeEventHandler _
    (AddressOf Row_Deleting)
    ' add Two rows
    custTable.Rows.Add(New Object() {1, "name1", "address1"})
    custTable.Rows.Add(New Object() {2, "name2", "address2"})
    ' Save changes
    custTable.AcceptChanges()
    ' change Address column in all the rows
    Dim row As DataRow
    ' Go through all rows 
    For Each row In custTable.Rows
      ' Delete the row
      row.Delete()
    Next
    ' Removing event handlers
    RemoveHandler custTable.RowDeleted, AddressOf Row_Deleted
    RemoveHandler custTable.RowDeleting, AddressOf Row_Deleting
  End Sub
  ' Row Deleted event handler
  Private Shared Sub Row_Deleted(ByVal sender As Object, _
  ByVal e As DataRowChangeEventArgs)
    MessageBox.Show("Row_Deleted Event:" & _
   e.Row("name", DataRowVersion.Original).ToString() & _
   e.Action.ToString())
  End Sub
  'Row Deleting event handler
  Private Shared Sub Row_Deleting(ByVal sender As Object, _
  ByVal e As DataRowChangeEventArgs)
    MessageBox.Show("Row_Deleting Event:" & _
    e.Row("name", DataRowVersion.Original).ToString() & _
    e.Action.ToString())
  End Sub
End Class
