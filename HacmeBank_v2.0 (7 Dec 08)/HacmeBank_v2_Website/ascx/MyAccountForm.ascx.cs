namespace HacmeBank_v2_Website.ascx
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for MyAccountForm.
	/// </summary>
	public partial class MyAccountForm : System.Web.UI.UserControl
	{


		protected void Page_Load(object sender, System.EventArgs e)
		{
			GetAccounts();
		}
		

		private void GetAccounts()
		{
		
			dataClasses.userAccount[] userAccountDetails = new AccountManagement().getAllUserAccountDetails("",(string)Session["userID"].ToString());						
			DataTable dataTableWithAccountDetails = new DataTable();
			dataTableWithAccountDetails.Columns.Add("account_no");
			dataTableWithAccountDetails.Columns.Add("branch");
			dataTableWithAccountDetails.Columns.Add("account_type");
			dataTableWithAccountDetails.Columns.Add("account_balance");
			foreach (dataClasses.userAccount objUserAccount in userAccountDetails)
			{	
				string accountBalanceAndCurrency = objUserAccount.accountBalance.ToString() + " " + objUserAccount.accountCurrency;
				dataTableWithAccountDetails.Rows.Add(new object[4] {objUserAccount.accountID,objUserAccount.accountBranch,objUserAccount.accountType,accountBalanceAndCurrency});	
			}						
			dgAccountDetails.DataSource = dataTableWithAccountDetails;
			dgAccountDetails.DataBind();
		}

		public void Display_Account_Data(object oss,DataGridCommandEventArgs e)
		{			
			try
			{
				string url="Main.aspx?function=TransactionDetails&";
				url +="account_no=" + e.Item.Cells[0].Text;				
				Response.Redirect(url);
			}
			catch(Exception Ex)
			{
				lblErrorMessage.Text=Ex.Message;
			}
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
