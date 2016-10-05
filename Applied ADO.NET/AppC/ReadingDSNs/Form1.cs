using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Microsoft.Win32;

namespace ReadingDSNs
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListBox listBox1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.Location = new System.Drawing.Point(24, 16);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(232, 238);
			this.listBox1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 273);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listBox1});
			this.Name = "Form1";
			this.Text = "ODBC Data Sources";
			this.Load += new System.EventHandler(this.Form1_Load);
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

		private void Form1_Load(object sender, System.EventArgs e)
		{
			ReadODBCSNs();
		
		}

		private void ReadODBCSNs()
		{
			string str; 
			RegistryKey rootKey, subKey;
			String[] dsnList;
			rootKey = Registry.LocalMachine;
			str = "SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources";
			subKey = rootKey.OpenSubKey(str);
			dsnList = subKey.GetValueNames();
			listBox1.Items.Add("System DSNs");
			listBox1.Items.Add("================");
			foreach(String dsnName in dsnList)
			{
				listBox1.Items.Add(dsnName);
			}
			subKey.Close();
			rootKey.Close();
			// Load User DSNs
			rootKey = Registry.CurrentUser;
			str = "SOFTWARE\\ODBC\\ODBC.INI\\ODBC Data Sources";
			subKey = rootKey.OpenSubKey(str);
			dsnList = subKey.GetValueNames();
			listBox1.Items.Add("================");
			listBox1.Items.Add("User DSNs");
			listBox1.Items.Add("================");
			foreach(String dsnName in dsnList)
			{
				listBox1.Items.Add(dsnName);
			}
			subKey.Close();
			rootKey.Close();
		}
	}
}
