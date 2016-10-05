using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Data.OleDb;

namespace ReadingWritingImagesSamp
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button BrowseBtn;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button SaveImageBtn;
		private System.Windows.Forms.Button ReadImageBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.PictureBox pictureBox1;

		// User defined variables
		private Image curImage = null;
		private string curFileName = null;
		private string connectionString = 
		"Provider=Microsoft.Jet.OLEDB.4.0; Data Source=F:\\AppliedAdoNet.mdb" ;
		private string savedImageName = "F:\\ImageFromDb.BMP";		
		

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.BrowseBtn = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.SaveImageBtn = new System.Windows.Forms.Button();
			this.ReadImageBtn = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// BrowseBtn
			// 
			this.BrowseBtn.Location = new System.Drawing.Point(256, 8);
			this.BrowseBtn.Name = "BrowseBtn";
			this.BrowseBtn.Size = new System.Drawing.Size(96, 23);
			this.BrowseBtn.TabIndex = 0;
			this.BrowseBtn.Text = "Browse Image";
			this.BrowseBtn.Click += new System.EventHandler(this.BrowseBtn_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(8, 8);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(232, 20);
			this.textBox1.TabIndex = 1;
			this.textBox1.Text = "textBox1";
			// 
			// SaveImageBtn
			// 
			this.SaveImageBtn.Location = new System.Drawing.Point(16, 40);
			this.SaveImageBtn.Name = "SaveImageBtn";
			this.SaveImageBtn.Size = new System.Drawing.Size(96, 32);
			this.SaveImageBtn.TabIndex = 2;
			this.SaveImageBtn.Text = "Save Image";
			this.SaveImageBtn.Click += new System.EventHandler(this.SaveImageBtn_Click);
			// 
			// ReadImageBtn
			// 
			this.ReadImageBtn.Location = new System.Drawing.Point(136, 40);
			this.ReadImageBtn.Name = "ReadImageBtn";
			this.ReadImageBtn.Size = new System.Drawing.Size(104, 32);
			this.ReadImageBtn.TabIndex = 3;
			this.ReadImageBtn.Text = "Read Image";
			this.ReadImageBtn.Click += new System.EventHandler(this.ReadImageBtn_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(8, 88);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(472, 344);
			this.pictureBox1.TabIndex = 4;
			this.pictureBox1.TabStop = false;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 437);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pictureBox1,
																		  this.ReadImageBtn,
																		  this.SaveImageBtn,
																		  this.textBox1,
																		  this.BrowseBtn});
			this.Name = "Form1";
			this.Text = "Reading and Writing Images in a Database";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void BrowseBtn_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog openDlg = new OpenFileDialog();
			openDlg.Filter = "All Bitmap files|*.bmp";
			string filter = openDlg.Filter;
			openDlg.Title = "Open a Bitmap File";
			if(openDlg.ShowDialog() == DialogResult.OK)
			{
				curFileName = openDlg.FileName; 	
				textBox1.Text = curFileName;
			}
		}

		private void SaveImageBtn_Click(object sender, System.EventArgs e)
		{
			// Read a bitmap contents in a stream
			FileStream fs = new FileStream(curFileName, 
				FileMode.OpenOrCreate, FileAccess.Read);
			byte[] rawData = new byte[fs.Length];
			fs.Read(rawData, 0, System.Convert.ToInt32(fs.Length));			
			fs.Close();

			// Construct a SQL string and a connection object
			string sql = "SELECT * FROM Users";
			OleDbConnection conn = new OleDbConnection();
			conn.ConnectionString = connectionString;
			// Open connection
			if(conn.State != ConnectionState.Open)
				conn.Open();
			// Create a data adapter and data set
			OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
			OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
			DataSet ds = new DataSet("Users");
            adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;			
			
			// Fill data adapter
			adapter.Fill(ds,"Users");
		
			string userDes = "Mahesh Chand is a founder of C# Corner ";
			userDes += "Author: 1. A Programmer's Guide to ADO.NET;";
			userDes += ", 2. Applied ADO.NET. ";

			// Create a new row
			DataRow row = ds.Tables["Users"].NewRow();
			row["UserName"] = "Mahesh Chand";
			row["UserEmail"] = "mcb@mindcracker.com";
			row["UserDescription"] = userDes;
			row["UserPhoto"] = rawData;
			// Add row to the collection
			ds.Tables["Users"].Rows.Add(row);
			// Save changes to the database
			adapter.Update(ds, "Users");
			// Clean up connection
			if(conn != null)
			{
				if(conn.State == ConnectionState.Open)
					conn.Close();
				// Dispose connection
				conn.Dispose(); 
			}		
			MessageBox.Show("Image Saved");
		}

		private void ReadImageBtn_Click(object sender, System.EventArgs e)
		{
			// Construct a SQL string and a connection object
			string sql = "SELECT * FROM Users";
			OleDbConnection conn = new OleDbConnection();
			conn.ConnectionString = connectionString;
			// Open connection
			if(conn.State != ConnectionState.Open)
				conn.Open();
			// Create a data adapter and data set
			OleDbDataAdapter adapter = new OleDbDataAdapter(sql, conn);
			OleDbCommandBuilder cmdBuilder = new OleDbCommandBuilder(adapter);
			DataSet ds = new DataSet("Users");
			adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;			
			// Fill data adapter
			adapter.Fill(ds,"Users");
		
			// Get first row of the table
			DataRow row = ds.Tables["Users"].Rows[0];
			// Read data in a stream
			byte[] rawData = new byte[0];
			rawData =  (byte[])row["UserPhoto"];
			int len = new int();
			len = rawData.GetUpperBound(0); 
			// Save rawData as a bitmap
			FileStream fs = new FileStream
			(savedImageName, FileMode.OpenOrCreate, FileAccess.Write);
			fs.Write(rawData, 0, len);
			// Close stream
			fs.Close();
			// View Image in PictureBox
			curImage = Image.FromFile(savedImageName);
			pictureBox1.Image = curImage;

			// Clean up connection
			if(conn != null)
			{
				if(conn.State == ConnectionState.Open)
					conn.Close();
				// Dispose connection
				conn.Dispose(); 
			}		
		}
	}
}
