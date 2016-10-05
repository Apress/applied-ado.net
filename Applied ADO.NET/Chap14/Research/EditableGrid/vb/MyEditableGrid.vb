Imports System
Imports System.Data
Imports System.Web.UI.WebControls

'/*
' *    The Control assumes the following:
' * 
' *		1) It is bound to a DataView object.
' *		2) The app will use direct SQL commands to update the source (NO batch update).
' *		3) No custom paging is enabled.
' *		
' *	  If you plan to support sorting, then some aspects of this code should be reviewed
' *	  and adapted. 
' * 
' */

Namespace BWSLib
    Namespace Controls

        Public Class MyEditableGrid
            Inherits DataGrid

            Public Sub New()
                AllowFullEditing = True
                AddNewRow = False
                RejectChanges = False
                MustInsertRow = False
                AllowPaging = True


                'ItemCreated += new DataGridItemEventHandler(OnItemCreated)
                'CancelCommand += new DataGridCommandEventHandler(OnCancelCommand)
                'EditCommand += new DataGridCommandEventHandler(OnEditCommand)
                'UpdateCommand += new DataGridCommandEventHandler(OnUpdateCommand)
                'DeleteCommand += new DataGridCommandEventHandler(OnDeleteCommand)
            End Sub



            ' *** PROPERTIES



            ' *** PROPERTY: AllowFullEditing
            Public AllowFullEditing As Boolean

            ' *** PROPERTY: AddNewRow
            Public AddNewRow As Boolean

            ' *** INTERNAL PROPERTY: RejectChanges
            Protected RejectChanges As Boolean

            ' *** INTERNAL PROPERTY: MustInsertRow
            Protected Property MustInsertRow()
                Get
                    Return Convert.ToBoolean(ViewState("MustInsertRow"))
                End Get
                Set(ByVal Value)
                    ViewState("MustInsertRow") = Value
                End Set
            End Property

            ' *** PROPERTY: ShowWebdings
            Public ShowWebdings As Boolean = False

            ' *** PROPERTY: EditColumnText
            Public EditColumnText As String = "Edit"

            ' *** PROPERTY: EditColumnUpdateText
            Public EditColumnUpdateText As String = "OK"

            ' *** PROPERTY: EditColumnCancelText
            Public EditColumnCancelText As String = "Cancel"

            ' *** PROPERTY: DeleteColumnText
            Public DeleteColumnText As String = "Delete"

            ' *** PROPERTY: DataSource (override)
            Public Overrides Property DataSource() As Object
                Get
                    Return MyBase.DataSource
                End Get
                Set(ByVal Value As Object)
                    MyBase.DataSource = Value

                    If AllowFullEditing Then
                        If AddNewRow Then
                            AddNewRow = False
                            InsertNewRow()
                        End If

                        If AllowFullEditing And RejectChanges Then
                            RejectChanges = False
                            MustInsertRow = False
                            RejectChangesOnLastRow()
                        End If
                    End If
                End Set
            End Property



            ' *** EVENTS


            ' *** EVENT: InitRow
            Public Delegate Sub DataGridInitRowEventHandler(ByVal sender As Object, ByVal e As DataGridInitRowEventArgs)
            Public Event InitRow As DataGridInitRowEventHandler
            Private Sub OnInitRow(ByVal e As DataGridInitRowEventArgs)
                RaiseEvent InitRow(Me, e)
            End Sub


            ' *** EVENT: UpdateView 
            Public Event UpdateView As EventHandler
            Protected Sub OnUpdateView(ByVal e As EventArgs)
                RaiseEvent UpdateView(Me, e)
            End Sub


            ' *** EVENT: SaveData 
            Public Event SaveData As DataGridCommandEventHandler
            Protected Sub OnSaveData(ByVal e As DataGridCommandEventArgs)
                RaiseEvent SaveData(Me, e)
            End Sub


            ' *** EVENT: InsertData 
            Public Event InsertData As DataGridCommandEventHandler
            Protected Sub OnInsertData(ByVal e As DataGridCommandEventArgs)
                RaiseEvent InsertData(Me, e)
            End Sub


            ' *** EVENT: DeleteData 
            Public Event DeleteData As DataGridCommandEventHandler
            Protected Sub OnDeleteData(ByVal e As DataGridCommandEventArgs)
                RaiseEvent DeleteData(Me, e)
            End Sub



            ' *** EVENT HANDLERS



            ' *** EVENT HANDLER: Init
            Sub MyOnInit(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Init
                If AllowFullEditing Then
                    AddWorkerColumns()
                End If
            End Sub

            ' *** EVENT HANDLER: PageIndexChanged
            Sub MyPageIndexChanged(ByVal sender As Object, ByVal e As DataGridPageChangedEventArgs) Handles MyBase.PageIndexChanged
                ' Clears edit mode
                EditItemIndex = -1

                ' Reject changes on the last row
                RejectChanges = True

                ' Show/Hide DELETE column
                ToggleDeleteColumn(True)

                ' Set the new page index
                CurrentPageIndex = e.NewPageIndex

                ' Refresh data
                OnUpdateView(EventArgs.Empty)
            End Sub

            ' *** EVENT HANDLER: DeleteCommand
            Sub MyDeleteCommand(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles MyBase.DeleteCommand
                ' Clear edit mode
                EditItemIndex = -1

                ' Delete data 
                OnDeleteData(e)

                ' First item in the row, one page back
                If Items.Count = 1 Then
                    If CurrentPageIndex > 0 Then
                        CurrentPageIndex = CurrentPageIndex - 1
                    End If
                End If

                ' Refresh view
                OnUpdateView(EventArgs.Empty)
            End Sub

            ' *** EVENT HANDLER: UpdateCommand
            Sub MyUpdateCommand(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles MyBase.UpdateCommand
                ' Clear edit mode
                EditItemIndex = -1

                ' Show/Hide DELETE column
                ToggleDeleteColumn(True)

                ' Reject changes on the last row
                RejectChanges = True

                ' Update or insert data 
                If MustInsertRow Then
                    OnInsertData(e)
                Else
                    OnSaveData(e)
                End If

                ' Refresh view
                OnUpdateView(EventArgs.Empty)
            End Sub

            ' *** EVENT HANDLER: EditCommand
            Sub MyEditCommand(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles MyBase.EditCommand
                ' Reject changes on the last row (if any)
                RejectChanges = True

                ' Show/Hide DELETE column
                ToggleDeleteColumn(False)

                ' Enable editing on the clicked row
                EditItemIndex = e.Item.ItemIndex

                ' Refresh view
                OnUpdateView(EventArgs.Empty)
            End Sub

            ' *** EVENT HANDLER: CancelCommand
            Sub MyCancelCommand(ByVal sender As Object, ByVal e As DataGridCommandEventArgs) Handles MyBase.CancelCommand
                If e.Item.ItemIndex = 0 Then
                    If CurrentPageIndex > 0 Then
                        CurrentPageIndex = CurrentPageIndex - 1
                    End If
                End If

                ' Clears edit mode
                EditItemIndex = -1

                ' Reject changes on the last row
                RejectChanges = True

                ' Show/Hide DELETE column
                ToggleDeleteColumn(True)

                ' Refresh view
                OnUpdateView(EventArgs.Empty)
            End Sub

            ' *** EVENT HANDLER: ItemCreated
            Sub MyItemCreated(ByVal sender As Object, ByVal e As DataGridItemEventArgs) Handles MyBase.ItemCreated
                Dim lit As ListItemType = e.Item.ItemType
                If (lit = ListItemType.Item Or lit = ListItemType.AlternatingItem) Then
                    CustomizeItem(e)
                End If
            End Sub



            ' *** CLASS HELPERS



            ' Add Edit and Delete columns
            Private Sub AddWorkerColumns()
                If ShowWebdings Then
                    EditColumnText = "/"
                    EditColumnUpdateText = "R"
                    EditColumnCancelText = "T"
                    DeleteColumnText = "r"
                End If

                ' Edit column
                Dim editColumn As EditCommandColumn = New EditCommandColumn()
                editColumn.EditText = EditColumnText
                editColumn.UpdateText = EditColumnUpdateText
                editColumn.CancelText = EditColumnCancelText
                If ShowWebdings Then
                    editColumn.ItemStyle.Font.Size = FontUnit.Point(11)
                    editColumn.ItemStyle.Font.Name = "wingdings 2"
                End If
                Columns.Add(editColumn)


                ' Delete column
                Dim deleteColumn As ButtonColumn = New ButtonColumn()
                deleteColumn.CommandName = "delete"
                deleteColumn.Text = DeleteColumnText
                If ShowWebdings Then
                    deleteColumn.ItemStyle.Font.Name = "webdings"
                End If
                Columns.Add(deleteColumn)
            End Sub

            ' Reject changes on the last row
            Private Sub RejectChangesOnLastRow()
                ' Get the underlying data source
                Dim dt As DataTable = CType(DataSource, DataView).Table

                Dim drLast As DataRow = dt.Rows(dt.Rows.Count - 1)
                If drLast.RowState = DataRowState.Added Then
                    drLast.RejectChanges()
                End If
            End Sub

            ' Show/Hide the DELETE column when in edit mode 
            Private Sub ToggleDeleteColumn(ByVal bViewState As Boolean)
                Dim nGridColCount As Integer = Columns.Count
                Columns(nGridColCount - 1).Visible = bViewState
            End Sub

            ' Put the grid in edit mode by adding a blank row 
            Private Sub InsertNewRow()
                ' Show/Hide DELETE column
                ToggleDeleteColumn(False)

                ' Get the underlying DataTable object
                Dim dt As DataTable = CType(DataSource, DataView).Table

                ' If any pending changes, stop here...
                Dim tmpTableOfPendingChanges As DataTable = dt.GetChanges(DataRowState.Added)
                If Not (tmpTableOfPendingChanges Is Nothing) Then
                    Return
                End If

                ' Add the new row
                Dim row As DataRow = dt.NewRow()
                dt.Rows.Add(row)

                ' Initialize the row
                Dim dgire As DataGridInitRowEventArgs = New DataGridInitRowEventArgs()
                dgire.Row = row
                OnInitRow(dgire)

                ' Goto to last page (return last index in the page)
                Dim nNewItemIndex As Integer = SetIndexesToLastPage(dt)

                ' Turn edit mode on for the newly added row
                EditItemIndex = nNewItemIndex

                ' Tracks that a new row has just been added
                MustInsertRow = True
            End Sub

            ' Update indexes to point to last page
            Private Function SetIndexesToLastPage(ByVal dt As DataTable) As Integer
                Dim nRemainder As Integer = (dt.Rows.Count Mod PageSize)
                Dim nNewItemIndex As Integer = nRemainder

                CurrentPageIndex = (dt.Rows.Count / PageSize) ' 0-based
                If nNewItemIndex = 0 Then
                    CurrentPageIndex = CurrentPageIndex - 1
                    nNewItemIndex = PageSize - 1

                Else
                    nNewItemIndex = nNewItemIndex - 1
                End If

                Return nNewItemIndex
            End Function

            ' Customize items in the grid
            Private Sub CustomizeItem(ByVal e As DataGridItemEventArgs)
                Dim wc As WebControl

                ' Adds a tooltip to Edit
                wc = CType(e.Item.Cells(Columns.Count - 2), WebControl)
                wc.ToolTip = "Edit this row"

                ' Adds a client-side onclick handler and a tooltip to Delete
                wc = CType(e.Item.Cells(Columns.Count - 1), WebControl)
                Dim js As String = "return confirm('Do you really want to delete this row?');"
                wc.Attributes("onclick") = js
                wc.ToolTip = "Delete this row"
            End Sub

        End Class



        ' *** EVENT CLASS



        Public NotInheritable Class DataGridInitRowEventArgs
            Inherits EventArgs
            Public Row As DataRow
        End Class

    End Namespace
End Namespace