namespace HacmeBank_v2_Website.ascx
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for TransactionDetails.
	/// </summary>
	public partial class TransactionDetails : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			LoadTransactionDetails();
		}

		private void LoadTransactionDetails()
		{
			string accountToProcess = Request.QueryString["account_no"];
			dataClasses.transactionDetail[] transactionDetails = new AccountManagement().getAllTransactionsDetails("",accountToProcess);						
			DataTable dataTableWithTransactionDetails = new DataTable();
			dataTableWithTransactionDetails.Columns.Add("transaction_id");
			dataTableWithTransactionDetails.Columns.Add("transaction_date");
			dataTableWithTransactionDetails.Columns.Add("description");
			dataTableWithTransactionDetails.Columns.Add("transaction_mode");
			dataTableWithTransactionDetails.Columns.Add("transaction_amount");
			foreach (dataClasses.transactionDetail objTransactionDetails in transactionDetails)
			{	
				//string accountBalanceAndCurrency = objUserAccount.accountBalance.ToString() + " " + objUserAccount.accountCurrency;
				dataTableWithTransactionDetails.Rows.Add(new object[5] {   objTransactionDetails.transactionID, 
																		   objTransactionDetails.transactionDate,
																		   objTransactionDetails.transactionDescription,
																		   objTransactionDetails.transactionMode,																		   
																		   objTransactionDetails.transactionAmount});	
			}						
			dg_AccountBal.DataSource = dataTableWithTransactionDetails;
			dg_AccountBal.DataBind();

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

	}
}
