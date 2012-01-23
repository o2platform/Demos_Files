namespace HacmeBank_v2_Website.ascx
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for AccountTransfer.
	/// </summary>
	public partial class AccountTransfer : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{	
			lblErrorMessage.Text = "";
			lblMessage.Text = "";

			if (!IsPostBack)
			{
				Global.objGui.populateDropDownListWithListOfUserAccounts(drpdwnSourceAcc,(string)Session["userID"].ToString());
				Global.objGui.populateDropDownListWithListOfUserAccounts(drpdwnDestinationAcc,(string)Session["userID"].ToString());
			}
		}
	

		protected void btnTransfer_Click(object sender, System.EventArgs e)
		{
			if (drpdwnSourceAcc.SelectedItem.Text==drpdwnDestinationAcc.SelectedItem.Text && rbInternalPayment.Checked)			
				lblErrorMessage.Text="Source and Destination Account cannot be the same. <br/>";							
			if ("" == txtAmt.Text)
				lblErrorMessage.Text+="You have to enter an amount to transfer.<br/>";				
			//if((rbExternalPayment.Checked) && (0 == Global.objAccountManagement.GetAccountTransactions_using_AccountID("",txtExternalPaymentAccount.Text).Length))
			if((rbExternalPayment.Checked))
			{
				if ("" == txtExternalPaymentAccount.Text)
					lblErrorMessage.Text+="The value of the supplied external account cannot be empty.<br/>";
				else if (null == Global.objAccountManagement.GetAccountDetails_using_AccountID("",txtExternalPaymentAccount.Text))
					lblErrorMessage.Text+="The supplied external account does not exist.<br/>";
			}
			if ("" == lblErrorMessage.Text)
			{	
				try
				{
					string sourceAccount=drpdwnSourceAcc.SelectedValue;
					string destinationAccount;
					if (rbInternalPayment.Checked)
						destinationAccount=drpdwnDestinationAcc.SelectedValue;
					else
						destinationAccount = txtExternalPaymentAccount.Text;				
					Int32 amount= Int32.Parse(txtAmt.Text);
					string comment=txtComment.Text;
					//				Response.Write(sourceAccount + "  :  " +
					//					destinationAccount + "  :  " +
					//					amount.ToString()+ "  :  " +
					//					comment);
					Global.objAccountManagement.TransferFunds("",sourceAccount,destinationAccount,amount,comment);
					lblMessage.Text = "Funds successfully transfered";
				}
				catch (Exception ex)
				{
					lblErrorMessage.Text+="Error: " + ex.Message;
				}
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
