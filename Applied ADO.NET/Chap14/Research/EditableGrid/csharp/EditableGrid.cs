using System;
using System.Web.UI.WebControls;
using System.Data;


/*
 *    The Control assumes the following:
 * 
 *		1) It is bound to a DataView object.
 *		2) The app will use direct SQL commands to update the source (NO batch update).
 *		3) No custom paging is enabled.
 *		
 *	  If you plan to support sorting, then some aspects of this code should be reviewed
 *	  and adapted. 
 * 
 */

namespace BWSLib
{
	namespace Controls
	{
		public class EditableGrid : DataGrid
		{
			// Constructor that sets some styles and graphical properties	
			public EditableGrid()
			{
				AllowFullEditing = true;
				AddNewRow = false;
				RejectChanges = false;
				MustInsertRow = false;

				AllowPaging = true;

				// Handlers
				Init += new EventHandler(OnInit);
				PageIndexChanged += new DataGridPageChangedEventHandler(OnPageIndexChanged);

				ItemCreated += new DataGridItemEventHandler(OnItemCreated);
				CancelCommand += new DataGridCommandEventHandler(OnCancelCommand);
				EditCommand += new DataGridCommandEventHandler(OnEditCommand);
				UpdateCommand += new DataGridCommandEventHandler(OnUpdateCommand);
				DeleteCommand += new DataGridCommandEventHandler(OnDeleteCommand);
			}


			// PROPERTY: AllowFullEditing
			// Enable full editing
			public bool AllowFullEditing;

			// PROPERTY: AddNewRow
			// if true must add an empty row at the bottom of the data source
			public bool AddNewRow;
		
			// INTERNAL PROPERTY: RejectChanges
			// if true must reject changes on the last row of the data source
			protected bool RejectChanges;

			// INTERNAL PROPERTY: MustInsertRow
			// if true must INSERT instead of UPDATE and there's a pending change 
			protected bool MustInsertRow
			{
				get {return Convert.ToBoolean(ViewState["MustInsertRow"]);}
				set {ViewState["MustInsertRow"] = value;}
			}


			// PROPERTY: DataSource (override)
			public override object DataSource 
			{
				get {return base.DataSource;}
				set 
				{	
					base.DataSource = value;
					if (AllowFullEditing)
					{
						if (AddNewRow)
						{
							AddNewRow = false;
							InsertNewRow();
						}

						if (AllowFullEditing && RejectChanges)
						{
							RejectChanges = false;
							MustInsertRow = false;
							RejectChangesOnLastRow();
						}
					}
				}
			}

	
			// PROPERTY: command columns
			public bool ShowWebdings = false;
			public String EditColumnText = "Edit";
			public String EditColumnUpdateText = "OK";
			public String EditColumnCancelText = "Cancel";
			public String DeleteColumnText = "Delete";


			// EVENT: InitRow
			public delegate void DataGridInitRowEventHandler(Object sender, DataGridInitRowEventArgs e);
			public event DataGridInitRowEventHandler InitRow;
			private void OnInitRow(DataGridInitRowEventArgs e)
			{
				if (InitRow != null) 
					InitRow(this, e);
			}


			// EVENT: UpdateView 
			public event EventHandler UpdateView;
			protected virtual void OnUpdateView(EventArgs e)
			{
				if (UpdateView != null)
					UpdateView(this, e);
			}
		

			// EVENT: SaveData 
			public event DataGridCommandEventHandler SaveData;
			protected virtual void OnSaveData(DataGridCommandEventArgs e)
			{
				if (SaveData != null)
					SaveData(this, e);
			}
		
		
			// EVENT: InsertData 
			public event DataGridCommandEventHandler InsertData;
			protected virtual void OnInsertData(DataGridCommandEventArgs e)
			{
				if (InsertData != null)
					InsertData(this, e);
			}
		

			// EVENT: DeleteData 
			public event DataGridCommandEventHandler DeleteData;
			protected virtual void OnDeleteData(DataGridCommandEventArgs e)
			{
				if (DeleteData != null)
					DeleteData(this, e);
			}
		

		
			// EVENT HANDLER: Init
			public void OnInit(Object sender, EventArgs e)
			{
				if (AllowFullEditing)
					AddWorkerColumns();
			}


			// EVENT HANDLER: ItemCreated
			public void OnItemCreated(Object sender, DataGridItemEventArgs e)
			{
				ListItemType lit = e.Item.ItemType;
				if (lit == ListItemType.Item || lit == ListItemType.AlternatingItem)
					CustomizeItem(e);
			}


			// EVENT HANDLER: CancelCommand
			public void OnCancelCommand(Object sender, DataGridCommandEventArgs e)
			{
				if (e.Item.ItemIndex == 0)
					CurrentPageIndex = (CurrentPageIndex==0 ?0 :CurrentPageIndex-1);

				// Clears edit mode
				EditItemIndex = -1;

				// Reject changes on the last row
				RejectChanges = true;

				// Show/Hide DELETE column
				ToggleDeleteColumn(true);

				// Refresh view
				OnUpdateView(EventArgs.Empty);
			}


			// EVENT HANDLER: EditCommand
			public void OnEditCommand(Object sender, DataGridCommandEventArgs e)
			{
				// Reject changes on the last row (if any)
				RejectChanges = true;

				// Show/Hide DELETE column
				ToggleDeleteColumn(false);

				// Enable editing on the clicked row
				EditItemIndex = e.Item.ItemIndex;

				// Refresh view
				OnUpdateView(EventArgs.Empty);
			}


			// EVENT HANDLER: UpdateCommand
			public void OnUpdateCommand(Object sender, DataGridCommandEventArgs e)
			{
				// Clear edit mode
				EditItemIndex = -1;

				// Show/Hide DELETE column
				ToggleDeleteColumn(true);

				// Reject changes on the last row
				RejectChanges = true;

				// Update or insert data 
				if (MustInsertRow)
					OnInsertData(e);
				else
					OnSaveData(e);

				// Refresh view
				OnUpdateView(EventArgs.Empty);
			}
		

			// EVENT HANDLER: DeleteCommand
			public void OnDeleteCommand(Object sender, DataGridCommandEventArgs e)
			{
				// Clear edit mode
				EditItemIndex = -1;

				// Delete data 
				OnDeleteData(e);

				// First item in the row, one page back
				if (Items.Count == 1)
					CurrentPageIndex = (CurrentPageIndex==0 ?0 :CurrentPageIndex-1);

				// Refresh view
				OnUpdateView(EventArgs.Empty);
			}
		

			// EVENT HANDLER: PageIndexChanged
			public void OnPageIndexChanged(Object sender, DataGridPageChangedEventArgs e)
			{
				// Clears edit mode
				EditItemIndex = -1;

				// Reject changes on the last row
				RejectChanges = true;
			
				// Show/Hide DELETE column
				ToggleDeleteColumn(true);

				// Set the new page index
				CurrentPageIndex = e.NewPageIndex;

				// Refresh data
				OnUpdateView(EventArgs.Empty);
			}




		
			/* ---------------------------------------------------------------------*/
			/* ------------------------  INTERNALS ---------------------------------*/
			/* ---------------------------------------------------------------------*/


			// Reject changes on the last row
			private void RejectChangesOnLastRow()
			{
				// Get the underlying DataTable object
				DataTable dt = ((DataView) DataSource).Table;
				DataRow drLast = dt.Rows[dt.Rows.Count-1];
				if (drLast.RowState == DataRowState.Added)
					drLast.RejectChanges();
			}



			// Show/Hide the DELETE column when in edit mode 
			private void ToggleDeleteColumn(bool bViewState)
			{
				int nGridColCount = Columns.Count;
				Columns[nGridColCount-1].Visible = bViewState;
			}



			// Put the grid in edit mode by adding a blank row 
			private void InsertNewRow()
			{
				// Show/Hide DELETE column
				ToggleDeleteColumn(false);

				// Get the underlying DataTable object
				DataTable dt = ((DataView) DataSource).Table;
			
				// If any pending changes, stop here...
				DataTable tmpTableOfPendingChanges = dt.GetChanges(DataRowState.Added);
				if (tmpTableOfPendingChanges != null)
					return;

				// Add the new row
				DataRow row = dt.NewRow();
				dt.Rows.Add(row);

				// Initialize the row
				DataGridInitRowEventArgs dgire = new DataGridInitRowEventArgs();
				dgire.Row = row;
				OnInitRow(dgire);

				// Goto to last page (return last index in the page)
				int nNewItemIndex = SetIndexesToLastPage(dt);

				// Turn edit mode on for the newly added row
				EditItemIndex = nNewItemIndex;
			
				// Tracks that a new row has just been added
				MustInsertRow = true;
			}



			// Update indexes to point to last page
			private int SetIndexesToLastPage(DataTable dt)
			{
				int nRemainder = (dt.Rows.Count % PageSize);
				int nNewItemIndex = nRemainder;
				CurrentPageIndex = (dt.Rows.Count / PageSize)-1;	// 0-based
				if (CurrentPageIndex <0)
					CurrentPageIndex = 0;
				if (nNewItemIndex >0)
					CurrentPageIndex ++;

				if (nNewItemIndex == 0)
					nNewItemIndex = PageSize-1;
				else
					nNewItemIndex--;

				return nNewItemIndex;
			}

			

			// Add Edit and Delete columns
			private void AddWorkerColumns()
			{
				if (ShowWebdings)
				{
					EditColumnText = "/";
					EditColumnUpdateText = "R";
					EditColumnCancelText = "T";
					DeleteColumnText = "r";
				}

				// Edit column
				EditCommandColumn editColumn = new EditCommandColumn();
				editColumn.EditText = EditColumnText;
				editColumn.UpdateText = EditColumnUpdateText;
				editColumn.CancelText = EditColumnCancelText;
				if (ShowWebdings)
				{
					editColumn.ItemStyle.Font.Size = 11;
					editColumn.ItemStyle.Font.Name = "wingdings 2";
				}
				Columns.Add(editColumn);


				// Delete column
				ButtonColumn deleteColumn = new ButtonColumn();
				deleteColumn.CommandName = "delete";
				deleteColumn.Text = DeleteColumnText;
				if (ShowWebdings)
					deleteColumn.ItemStyle.Font.Name = "webdings";
				Columns.Add(deleteColumn);
			}



			// Customize items in the grid
			private void CustomizeItem(DataGridItemEventArgs e)
			{
				WebControl wc;

				// Adds a tooltip to Edit
				wc = ((WebControl) e.Item.Cells[Columns.Count-2]);
				wc.ToolTip = "Edit this row";
		
				// Adds a client-side onclick handler and a tooltip to Delete
				wc = ((WebControl) e.Item.Cells[Columns.Count-1]);
				String js = "return confirm('Do you really want to delete this row?');";
				wc.Attributes["onclick"] = js;
				wc.ToolTip = "Delete this row";
			}
		}

		public sealed class DataGridInitRowEventArgs : EventArgs
		{
			public DataRow Row;
		}
	}
}