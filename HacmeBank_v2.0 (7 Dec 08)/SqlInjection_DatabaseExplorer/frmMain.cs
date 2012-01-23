using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;
using System.Threading;
using System.Configuration;
using System.Web;

namespace SqlInjection_DatabaseExplorer
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		//my global vars
		public int iNumberRequestsSend=0;		
		public int iNumberRequestsReceived=0;	
		public int iNumberOfRequestsToSend = 1000;
		public int iNumberOfActiveThreads = 0;
		public int iMaxNumberOfActiveThreads = 50;
		public bool bUpdating = false;
		public bool bRawHttpCancelRequest = false;
        public bool bCancelRequest = false;			
		string strPayload_Before = "";
		string strPayload_After = "";

		//end of my global vars
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbRawHttp_Request;
		private System.Windows.Forms.TextBox tbRawHttp_Response;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btSendRawHttpRequest;
		private System.Windows.Forms.Button btRawHttp_CancelRequest;
		private System.Windows.Forms.TextBox tbRawHttp_PostData;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Button btDBSchema_Start;
		private System.Windows.Forms.ListBox lbDbSchema_AvailableDatabases;
		private System.Windows.Forms.TabControl tcUserGui;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label lbDbSchema_TablesInDatabase;
		private System.Windows.Forms.Button btDBSchema_Stop;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ListView lvDbSchema_AvailableColumns;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label lbDbSchema_ColumnsInTable;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label lbDbSchema_DataInColumn;
		private System.Windows.Forms.ListBox lbDbSchema_AvailableTables;
		private System.Windows.Forms.ListBox lbDbSchema_ColumnData;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TextBox tbDebugMessages;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
        private Label label3;
        private SplitContainer splitContainer1;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tcUserGui = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvDbSchema_AvailableColumns = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label8 = new System.Windows.Forms.Label();
            this.btDBSchema_Stop = new System.Windows.Forms.Button();
            this.lbDbSchema_TablesInDatabase = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbDbSchema_AvailableDatabases = new System.Windows.Forms.ListBox();
            this.btDBSchema_Start = new System.Windows.Forms.Button();
            this.lbDbSchema_AvailableTables = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbDbSchema_ColumnsInTable = new System.Windows.Forms.Label();
            this.lbDbSchema_ColumnData = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.lbDbSchema_DataInColumn = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRawHttp_PostData = new System.Windows.Forms.TextBox();
            this.btRawHttp_CancelRequest = new System.Windows.Forms.Button();
            this.btSendRawHttpRequest = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRawHttp_Request = new System.Windows.Forms.TextBox();
            this.tbRawHttp_Response = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbDebugMessages = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tcUserGui.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcUserGui
            // 
            this.tcUserGui.Controls.Add(this.tabPage2);
            this.tcUserGui.Controls.Add(this.tabPage1);
            this.tcUserGui.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcUserGui.Location = new System.Drawing.Point(0, 0);
            this.tcUserGui.Name = "tcUserGui";
            this.tcUserGui.SelectedIndex = 0;
            this.tcUserGui.Size = new System.Drawing.Size(944, 296);
            this.tcUserGui.TabIndex = 8;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvDbSchema_AvailableColumns);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.btDBSchema_Stop);
            this.tabPage2.Controls.Add(this.lbDbSchema_TablesInDatabase);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.lbDbSchema_AvailableDatabases);
            this.tabPage2.Controls.Add(this.btDBSchema_Start);
            this.tabPage2.Controls.Add(this.lbDbSchema_AvailableTables);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.lbDbSchema_ColumnsInTable);
            this.tabPage2.Controls.Add(this.lbDbSchema_ColumnData);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.lbDbSchema_DataInColumn);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(936, 270);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Download Database Schema";
            // 
            // lvDbSchema_AvailableColumns
            // 
            this.lvDbSchema_AvailableColumns.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvDbSchema_AvailableColumns.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvDbSchema_AvailableColumns.FullRowSelect = true;
            this.lvDbSchema_AvailableColumns.Location = new System.Drawing.Point(456, 65);
            this.lvDbSchema_AvailableColumns.MultiSelect = false;
            this.lvDbSchema_AvailableColumns.Name = "lvDbSchema_AvailableColumns";
            this.lvDbSchema_AvailableColumns.Size = new System.Drawing.Size(234, 199);
            this.lvDbSchema_AvailableColumns.TabIndex = 5;
            this.lvDbSchema_AvailableColumns.UseCompatibleStateImageBehavior = false;
            this.lvDbSchema_AvailableColumns.View = System.Windows.Forms.View.Details;
            this.lvDbSchema_AvailableColumns.SelectedIndexChanged += new System.EventHandler(this.lvDbSchema_AvailableColumns_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 118;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Type";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Identity";
            this.columnHeader3.Width = 50;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(456, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 2;
            this.label8.Text = "Columns In Table";
            // 
            // btDBSchema_Stop
            // 
            this.btDBSchema_Stop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDBSchema_Stop.Location = new System.Drawing.Point(816, 16);
            this.btDBSchema_Stop.Name = "btDBSchema_Stop";
            this.btDBSchema_Stop.Size = new System.Drawing.Size(120, 24);
            this.btDBSchema_Stop.TabIndex = 4;
            this.btDBSchema_Stop.Text = "Stop";
            this.btDBSchema_Stop.Click += new System.EventHandler(this.btDBSchema_Stop_Click);
            // 
            // lbDbSchema_TablesInDatabase
            // 
            this.lbDbSchema_TablesInDatabase.Location = new System.Drawing.Point(352, 49);
            this.lbDbSchema_TablesInDatabase.Name = "lbDbSchema_TablesInDatabase";
            this.lbDbSchema_TablesInDatabase.Size = new System.Drawing.Size(120, 16);
            this.lbDbSchema_TablesInDatabase.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(8, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 16);
            this.label6.TabIndex = 2;
            this.label6.Text = "Databases";
            // 
            // lbDbSchema_AvailableDatabases
            // 
            this.lbDbSchema_AvailableDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDbSchema_AvailableDatabases.Location = new System.Drawing.Point(8, 65);
            this.lbDbSchema_AvailableDatabases.Name = "lbDbSchema_AvailableDatabases";
            this.lbDbSchema_AvailableDatabases.Size = new System.Drawing.Size(224, 199);
            this.lbDbSchema_AvailableDatabases.TabIndex = 1;
            this.lbDbSchema_AvailableDatabases.SelectedIndexChanged += new System.EventHandler(this.lbDbSchema_AvailableDatabases_SelectedIndexChanged);
            // 
            // btDBSchema_Start
            // 
            this.btDBSchema_Start.Location = new System.Drawing.Point(8, 15);
            this.btDBSchema_Start.Name = "btDBSchema_Start";
            this.btDBSchema_Start.Size = new System.Drawing.Size(264, 24);
            this.btDBSchema_Start.TabIndex = 0;
            this.btDBSchema_Start.Text = "Start (GetDatabases)";
            this.btDBSchema_Start.Click += new System.EventHandler(this.btDBSchema_Start_Click);
            // 
            // lbDbSchema_AvailableTables
            // 
            this.lbDbSchema_AvailableTables.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lbDbSchema_AvailableTables.Location = new System.Drawing.Point(240, 65);
            this.lbDbSchema_AvailableTables.Name = "lbDbSchema_AvailableTables";
            this.lbDbSchema_AvailableTables.Size = new System.Drawing.Size(208, 199);
            this.lbDbSchema_AvailableTables.TabIndex = 1;
            this.lbDbSchema_AvailableTables.SelectedIndexChanged += new System.EventHandler(this.lbDbSchema_AvailableTables_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(240, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 16);
            this.label7.TabIndex = 2;
            this.label7.Text = "Tables in Database";
            // 
            // lbDbSchema_ColumnsInTable
            // 
            this.lbDbSchema_ColumnsInTable.Location = new System.Drawing.Point(560, 49);
            this.lbDbSchema_ColumnsInTable.Name = "lbDbSchema_ColumnsInTable";
            this.lbDbSchema_ColumnsInTable.Size = new System.Drawing.Size(120, 16);
            this.lbDbSchema_ColumnsInTable.TabIndex = 3;
            // 
            // lbDbSchema_ColumnData
            // 
            this.lbDbSchema_ColumnData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDbSchema_ColumnData.Location = new System.Drawing.Point(696, 65);
            this.lbDbSchema_ColumnData.Name = "lbDbSchema_ColumnData";
            this.lbDbSchema_ColumnData.Size = new System.Drawing.Size(232, 199);
            this.lbDbSchema_ColumnData.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(696, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(104, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "Data in Column";
            // 
            // lbDbSchema_DataInColumn
            // 
            this.lbDbSchema_DataInColumn.Location = new System.Drawing.Point(784, 40);
            this.lbDbSchema_DataInColumn.Name = "lbDbSchema_DataInColumn";
            this.lbDbSchema_DataInColumn.Size = new System.Drawing.Size(120, 16);
            this.lbDbSchema_DataInColumn.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.tbRawHttp_PostData);
            this.tabPage1.Controls.Add(this.btRawHttp_CancelRequest);
            this.tabPage1.Controls.Add(this.btSendRawHttpRequest);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbRawHttp_Request);
            this.tabPage1.Controls.Add(this.tbRawHttp_Response);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(920, 302);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Send raw HTTP Request";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(131, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(333, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "THIS FUNCTIONALITY IS NOT IMPLEMENTED IN THIS VERSION";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "POST data";
            // 
            // tbRawHttp_PostData
            // 
            this.tbRawHttp_PostData.Location = new System.Drawing.Point(8, 232);
            this.tbRawHttp_PostData.Multiline = true;
            this.tbRawHttp_PostData.Name = "tbRawHttp_PostData";
            this.tbRawHttp_PostData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRawHttp_PostData.Size = new System.Drawing.Size(384, 64);
            this.tbRawHttp_PostData.TabIndex = 4;
            // 
            // btRawHttp_CancelRequest
            // 
            this.btRawHttp_CancelRequest.Enabled = false;
            this.btRawHttp_CancelRequest.Location = new System.Drawing.Point(400, 144);
            this.btRawHttp_CancelRequest.Name = "btRawHttp_CancelRequest";
            this.btRawHttp_CancelRequest.Size = new System.Drawing.Size(64, 40);
            this.btRawHttp_CancelRequest.TabIndex = 3;
            this.btRawHttp_CancelRequest.Text = "Cancel Request";
            this.btRawHttp_CancelRequest.Click += new System.EventHandler(this.btRawHttp_CancelRequest_Click);
            // 
            // btSendRawHttpRequest
            // 
            this.btSendRawHttpRequest.Enabled = false;
            this.btSendRawHttpRequest.Location = new System.Drawing.Point(400, 24);
            this.btSendRawHttpRequest.Name = "btSendRawHttpRequest";
            this.btSendRawHttpRequest.Size = new System.Drawing.Size(64, 88);
            this.btSendRawHttpRequest.TabIndex = 2;
            this.btSendRawHttpRequest.Text = "SEND";
            this.btSendRawHttpRequest.Click += new System.EventHandler(this.btSendRawHttpRequest_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Request";
            // 
            // tbRawHttp_Request
            // 
            this.tbRawHttp_Request.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tbRawHttp_Request.Location = new System.Drawing.Point(8, 24);
            this.tbRawHttp_Request.Multiline = true;
            this.tbRawHttp_Request.Name = "tbRawHttp_Request";
            this.tbRawHttp_Request.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRawHttp_Request.Size = new System.Drawing.Size(384, 192);
            this.tbRawHttp_Request.TabIndex = 0;
            this.tbRawHttp_Request.WordWrap = false;
            // 
            // tbRawHttp_Response
            // 
            this.tbRawHttp_Response.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbRawHttp_Response.Location = new System.Drawing.Point(472, 24);
            this.tbRawHttp_Response.Multiline = true;
            this.tbRawHttp_Response.Name = "tbRawHttp_Response";
            this.tbRawHttp_Response.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbRawHttp_Response.Size = new System.Drawing.Size(440, 272);
            this.tbRawHttp_Response.TabIndex = 0;
            this.tbRawHttp_Response.WordWrap = false;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(472, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 16);
            this.label4.TabIndex = 1;
            this.label4.Text = "Response";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(936, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // tbDebugMessages
            // 
            this.tbDebugMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbDebugMessages.Location = new System.Drawing.Point(97, 3);
            this.tbDebugMessages.Multiline = true;
            this.tbDebugMessages.Name = "tbDebugMessages";
            this.tbDebugMessages.Size = new System.Drawing.Size(847, 76);
            this.tbDebugMessages.TabIndex = 11;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(1, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(90, 19);
            this.label10.TabIndex = 10;
            this.label10.Text = "Debug Messages";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(472, 24);
            this.label1.TabIndex = 12;
            this.label1.Text = "SQL Injection Database Explorer";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Location = new System.Drawing.Point(0, 66);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tcUserGui);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.tbDebugMessages);
            this.splitContainer1.Size = new System.Drawing.Size(948, 390);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(944, 453);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Sql Injection Database Explorer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tcUserGui.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
//			try
//			{
				Application.Run(new Form1());
//			}
//			catch (Exception ex)
//			{	
//				MessageBox.Show(ex.Message);
//			}
		}
		

		private void Form1_Load(object sender, System.EventArgs e)
		{
            if (this.DesignMode == false)
                debugInfo.setTargetTextBoxForDebugMessages(tbDebugMessages);
			//hacmeBank_Demo.loadRawHttpTestData(tbRawHttp_Request,tbRawHttp_PostData);			
			//loadTestData();
			//getAvailableDatabases();		
		}

		private void loadTestData()
		{
			lbDbSchema_AvailableDatabases.Items.Add("Foundstone_Bank");
			lbDbSchema_AvailableDatabases.SelectedIndex = 0;		
			while (lbDbSchema_AvailableTables.Items.Count<7)
				Thread.Sleep(500);
			lbDbSchema_AvailableTables.SelectedIndex=6;
		}

		private void btSendRawHttpRequest_Click(object sender, System.EventArgs e)
		{
            // rewrite using better Raw HTTP request module
            /*
			debugInfo.addDebugMessageOnTop("sending Raw Http request on " + DateTime.Now.ToLongTimeString());
			bRawHttpCancelRequest = false;
			if (tbRawHttp_PostData.Text.Length>0)
			{
				int iContentLengthPos = tbRawHttp_Request.Text.IndexOf("Content-Length:");
				if (iContentLengthPos > -1)
				{
					int iEndOfContentLengthString = tbRawHttp_Request.Text.Substring(iContentLengthPos).IndexOf(Environment.NewLine);
					if (iEndOfContentLengthString>-1)
					{
						string strContentLenghtString = tbRawHttp_Request.Text.Substring(iContentLengthPos,iEndOfContentLengthString+2);
						tbRawHttp_Request.Text = tbRawHttp_Request.Text.Replace(strContentLenghtString,"");										
					}
				}
				tbRawHttp_Request.Text =	tbRawHttp_Request.Text.Trim() +  Environment.NewLine + 
											"Content-Length: " + tbRawHttp_PostData.Text.Length.ToString() + 
											Environment.NewLine;
			}

			string strRequestToSend =	tbRawHttp_Request.Text.Trim() +
										Environment.NewLine + Environment.NewLine +
										tbRawHttp_PostData.Text;
		//	MessageBox.Show(strRequestToSend);

            sendReceivedRequestObject srroRequest = new sendReceivedRequestObject(ConfigurationSettings.AppSettings["IP"], Int32.Parse(ConfigurationSettings.AppSettings["Port"]), strRequestToSend);
			srroRequest.startSyncRequest();

			while (!srroRequest.bRequestCompleted)
			{
				Application.DoEvents();
				Thread.Sleep(250);
				if (bRawHttpCancelRequest)
					return;
			}
			tbRawHttp_Response.Text = srroRequest.strReceivedData;
            */
		}

		private void btRawHttp_CancelRequest_Click(object sender, System.EventArgs e)
		{
			bRawHttpCancelRequest = true;
		}

		

		
		private void btDBSchema_Start_Click(object sender, System.EventArgs e)
		{
			getData.getAvailableDatabases(lbDbSchema_AvailableDatabases, lbDbSchema_AvailableTables, lvDbSchema_AvailableColumns, lbDbSchema_ColumnData, ref bCancelRequest);
		}
			
        /*
		private string executeSyncRequest(string strTargetIP, int iTargetPort, string strRequestToSend,ref bool bCancelRequest)
		{
			sendReceivedRequestObject srroRequest = new sendReceivedRequestObject(strTargetIP,iTargetPort,strRequestToSend);
			srroRequest.startSyncRequest();

			while (!srroRequest.bRequestCompleted)
			{
				Application.DoEvents();
				Thread.Sleep(250);
				if (bCancelRequest)
					return "Request Canceled";
			}
			return srroRequest.strReceivedData.Trim();
		}*/

		private void lbDbSchema_AvailableDatabases_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            lbDbSchema_TablesInDatabase.Text = lbDbSchema_AvailableDatabases.SelectedItem.ToString();
			getData.GetDatabaseTables(lbDbSchema_AvailableDatabases.SelectedItem.ToString(),
                lbDbSchema_AvailableDatabases, lbDbSchema_AvailableTables, lvDbSchema_AvailableColumns, lbDbSchema_ColumnData, ref bCancelRequest);
		}

		private void btDBSchema_Stop_Click(object sender, System.EventArgs e)
		{
            bCancelRequest = true;
		}

		private void lbDbSchema_AvailableTables_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            lbDbSchema_ColumnsInTable.Text = lbDbSchema_AvailableDatabases.SelectedItem.ToString();
			getData.GetTableColumns(lbDbSchema_AvailableDatabases.SelectedItem.ToString(),lbDbSchema_AvailableTables.SelectedItem.ToString(),
                   lbDbSchema_AvailableDatabases, lbDbSchema_AvailableTables, lvDbSchema_AvailableColumns, lbDbSchema_ColumnData, ref bCancelRequest);
        }       

		private void lvDbSchema_AvailableColumns_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lvDbSchema_AvailableColumns.SelectedItems.Count>0)
				getData.GetColumnData(	lbDbSchema_AvailableDatabases.SelectedItem.ToString(),
							lbDbSchema_AvailableTables.SelectedItem.ToString(),							
							lvDbSchema_AvailableColumns.SelectedItems[0].SubItems[0].Text,
							lvDbSchema_AvailableColumns.SelectedItems[0].SubItems[1].Text,
                            lbDbSchema_ColumnData, ref bCancelRequest);
		}

	}

    // rewrite using better Raw HTTP request module
    /*
	class sendReceivedRequestObject
	{
		public NetworkStream nsNetworkStream;
		public TcpClient tcTcpClient; 
		public byte[] receivedData = new byte[0xFFFF];
		public string strReceivedData = "";
		public int iBytesReceived = 0; 
		public bool bRequestCompleted = false;
		string strMessageToSend;

		public sendReceivedRequestObject(string strTargetIPAddress, int iTargetPort, string strMessageToSend )
		{
			tcTcpClient = new TcpClient();
			tcTcpClient.Connect(strTargetIPAddress,iTargetPort);
			nsNetworkStream = tcTcpClient.GetStream();	
			this.strMessageToSend = strMessageToSend;
		}

		public void startASyncRequest()
		{
			nsNetworkStream.BeginRead(receivedData,0,receivedData.Length,new AsyncCallback(receiveData),this);
			nsNetworkStream.Write(Encoding.ASCII.GetBytes(strMessageToSend),0,strMessageToSend.Length);			
		}

		public void startSyncRequest()
		{
			ThreadStart tsSyncRequest = new ThreadStart(syncRequestThread);
			tsSyncRequest.BeginInvoke(null,null);
		}

		private void syncRequestThread()
		{			
			nsNetworkStream.Write(Encoding.ASCII.GetBytes(strMessageToSend),0,strMessageToSend.Length);		
			iBytesReceived = nsNetworkStream.Read(receivedData,0,receivedData.Length);			
			strReceivedData = Encoding.ASCII.GetString(receivedData);			
			bRequestCompleted = true;
		}
		
		
		private void receiveData(IAsyncResult iarReceivedData)
		{
			try
			{
				sendReceivedRequestObject srroCurrentRequest = (sendReceivedRequestObject)iarReceivedData.AsyncState;		
				iBytesReceived = srroCurrentRequest.nsNetworkStream.EndRead(iarReceivedData);
				strReceivedData = Encoding.ASCII.GetString( srroCurrentRequest.receivedData);			
			}
			catch (Exception ex)
			{
				strReceivedData = ex.Message;
			}
			bRequestCompleted = true;
		}				
	}
     */ 
}
