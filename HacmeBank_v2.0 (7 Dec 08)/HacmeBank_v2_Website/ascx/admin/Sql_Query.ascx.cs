namespace HacmeBank_v2_Website.ascx.admin
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Collections;
	using System.Xml;

	/// <summary>
	///		Summary description for Sql_Query.
	/// </summary>
	public partial class Sql_Query : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion

		protected void btExecuteQuery_Click(object sender, System.EventArgs e)
		{
			populateDataGridWithSqlQueryResults();
		}		

		protected void ddlSampleQueries_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//txtSqlQueryToExecute.Text = Server.HtmlDecode(ddlSampleQueries.SelectedItem.Text).Replace("&#160;","_").Replace("&quot;;","\"__");			
			txtSqlQueryToExecute.Text = ddlSampleQueries.SelectedItem.Text;
		}

		private void populateDataGridWithSqlQueryResults()
		{
			try
			{
				string sqlQueryToexecute = Server.HtmlDecode(txtSqlQueryToExecute.Text);
				XmlNode[] sqlQueryResults = (XmlNode[])Global.objAccountManagement.ExecuteSqlQuery("",sqlQueryToexecute);										

				if (sqlQueryResults[0].ChildNodes.Count >0)
				{
					//Create DataGrid Table Headers
					DataTable dataTableWithSqlQueryResults = new DataTable();
					for (int i=0; i < sqlQueryResults[0].ChildNodes.Count;i++)
					{
						XmlNode resultItem = sqlQueryResults[0].ChildNodes[i];				
						BoundColumn dynamicDataGridColumn = new BoundColumn();				
						dynamicDataGridColumn.DataField = i.ToString();
						dynamicDataGridColumn.HeaderText = resultItem.InnerText;
						dgQueryResult.Columns.Add(dynamicDataGridColumn);
						dataTableWithSqlQueryResults.Columns.Add(i.ToString());
					}
					if (sqlQueryResults.Length>1)
					{
						//Populate DataGrid Table 
						for (int j=1; j<sqlQueryResults.Length;j++)
						{
							//DataRow dynamicDataRow = dataTableWithSqlQueryResults.NewRow();
							object[] rowData = new object[sqlQueryResults[j].ChildNodes.Count];
							for (int i=0; i < sqlQueryResults[j].ChildNodes.Count;i++)
							{
								XmlNode resultItem = sqlQueryResults[j].ChildNodes[i];					
								rowData[i] = Server.HtmlEncode(resultItem.InnerText);					
							}
							dataTableWithSqlQueryResults.Rows.Add(rowData);
						}
					}
					dgQueryResult.DataSource = dataTableWithSqlQueryResults;
					dgQueryResult.DataBind();			
				}
			}
			catch (Exception Ex)
			{
				lblErrorMessage.Text = Ex.Message;
			}
		}	
	}
}
