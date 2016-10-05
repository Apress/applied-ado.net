// InsertStep2.cs - code-behind file

namespace BWSLib 
{
	using System;
	using System.Web.UI;
	using System.Web.UI.WebControls;
	using System.Text;
	using System.Data;
	using System.Data.OleDb;
	using BWSLib.Controls;

	public class MyPage : Page 
	{
		// Declare as PUBLIC or PROTECTED members all 
		// the controls in the layout
		protected EditableGrid grid;
		protected String m_connString;


		// Page OnLoad
		protected override void OnLoad(EventArgs e)
		{
			m_connString = "PROVIDER=Microsoft.Jet.OLEDB.4.0;DATA SOURCE={0};";
			m_connString = String.Format(m_connString, Server.MapPath("myemployees.mdb"));
			
			if (!IsPostBack)
			{
				// Load data and refresh the view
				DataFromSourceToMemory();
				UpdateDataView();
			}
		}


		// DataFromSourceToMemory
		private void DataFromSourceToMemory()
		{
			// Gets rows from the data source
			DataSet oDS = PhysicalDataRead();
	
			// Stores it in the Cache cache
			Cache["MyData"] = oDS;
		}


		// PhysicalDataRead
		private DataSet PhysicalDataRead()
		{
			// Command  and connection string
			String strCmd = "SELECT * FROM Employees";
		
			OleDbDataAdapter da = new OleDbDataAdapter(strCmd, m_connString);
			DataSet ds = new DataSet();
			da.Fill(ds, "Employees");
			return ds;
		}


		// Returns data
		private DataView GetData()
		{			
			// Retrieves the data
			DataSet ds = (DataSet) Cache["MyData"];
			DataView dv = ds.Tables["Employees"].DefaultView;
			return dv;
		}



		// Refresh the UI
		private void UpdateDataView()
		{
			grid.DataSource = GetData();
			grid.DataBind();
		}



		///////////////////////    EVENT HANDLERS   ///////////////////////


		// EVENT HANDLER: SaveData
		public void SaveData(Object sender, DataGridCommandEventArgs e)
		{
			StringBuilder sb = new StringBuilder("");
			sb.Append("UPDATE Employees SET ");
			sb.Append("firstname='{0}',");
			sb.Append("lastname='{1}',");
			sb.Append("title='{2}',");
			sb.Append("country='{3}' ");
			sb.Append("WHERE employeeid={4}");
			String cmd = sb.ToString();
			sb = null;
			
			// fName and lName come from the custom template
            TextBox fName    = (TextBox) e.Item.FindControl("fName");
			TextBox lName    = (TextBox) e.Item.FindControl("lName");
			TextBox position = (TextBox) e.Item.Cells[2].Controls[0];
			TextBox country  = (TextBox) e.Item.Cells[3].Controls[0];
	
			cmd = String.Format(cmd, fName.Text, lName.Text, position.Text, country.Text,
				grid.DataKeys[e.Item.ItemIndex]);

			// Executes the command
			OleDbConnection conn = new OleDbConnection(m_connString);
			OleDbCommand c = new OleDbCommand(cmd, conn);
			c.Connection.Open();
			c.ExecuteNonQuery();
			c.Connection.Close();

			DataFromSourceToMemory();
		}


		// EVENT HANDLER: InsertData
		public void InsertData(Object sender, DataGridCommandEventArgs e)
		{
			StringBuilder sb = new StringBuilder("");
			sb.Append("INSERT INTO Employees (firstname, lastname, title, country) VALUES(");
			sb.Append("'{0}', '{1}', '{2}', '{3}')");
			String cmd = sb.ToString();		
			sb = null;

			// fName and lName come from the custom template
			TextBox fName    = (TextBox) e.Item.FindControl("fName");
			TextBox lName    = (TextBox) e.Item.FindControl("lName");
			TextBox position = (TextBox) e.Item.Cells[2].Controls[0];
			TextBox country  = (TextBox) e.Item.Cells[3].Controls[0];
	
			cmd = String.Format(cmd, fName.Text, lName.Text, position.Text, country.Text); 

			// Executes the command
			OleDbConnection conn = new OleDbConnection(m_connString);
			OleDbCommand c = new OleDbCommand(cmd, conn);
			c.Connection.Open();
			c.ExecuteNonQuery();
			c.Connection.Close();

//			Trace.Warn("INSERT", cmd);
			DataFromSourceToMemory();
		}


		// EVENT HANDLER: DeleteData
		public void DeleteData(Object sender, DataGridCommandEventArgs e)
		{
			String cmd = "DELETE FROM Employees WHERE employeeid={0}";
			cmd = String.Format(cmd, grid.DataKeys[e.Item.ItemIndex]);

			// Executes the command
			OleDbConnection conn = new OleDbConnection(m_connString);
			OleDbCommand c = new OleDbCommand(cmd, conn);
			c.Connection.Open();
			c.ExecuteNonQuery();
			c.Connection.Close();

//			Trace.Warn("DELETE", cmd);
			DataFromSourceToMemory();
		}


		// EVENT HANDLER: OnInsert
		public void OnInsert(Object sender, EventArgs e)
		{
			grid.AddNewRow = true;
			UpdateDataView();
		}


		// EVENT HANDLER: InitRow
		public void InitRow(Object sender, DataGridInitRowEventArgs e)
		{
			e.Row["LastName"] = "Esposito";
		}
	

		// EVENT HANDLER: UpdateView
		public void UpdateView(Object sender, EventArgs e)
		{
			UpdateDataView();
		}

	}
}
