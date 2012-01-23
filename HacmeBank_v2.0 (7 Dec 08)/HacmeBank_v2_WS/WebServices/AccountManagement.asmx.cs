using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace HacmeBank_v2_WS
{
	/// <summary>
	/// Summary description for AccountManagement.
	/// </summary>
	public class WS_AccountManagement : System.Web.Services.WebService
	{
		public WS_AccountManagement()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion


		[WebMethod]
		public ArrayList GetUserAccounts_using_UserID(string SessionID, string userID)
		{
			return HacmeBank_v2_WS.DataFactory.GetUserAccounts_using_userID(userID);
		}

		[WebMethod]
		public ArrayList GetAccountDetails_using_AccountID(string SessionID, string accountID)
		{
			return HacmeBank_v2_WS.DataFactory.GetAccountDetails_using_AccountID(accountID);
		}

		[WebMethod]
		public ArrayList GetAccountTransactions_using_AccountID(string SessionID, string accountID)
		{
			return HacmeBank_v2_WS.DataFactory.GetAccountTransactions_using_AccountID(accountID);
		}

		[WebMethod]
		public ArrayList GetAccountTransactionDetails_using_TransactionID(string SessionID, string transactionID)
		{
			return HacmeBank_v2_WS.DataFactory.GetAccountTransactionDetails_using_TransactionID(transactionID);
		}	

		[WebMethod]
		public int TransferFunds(string SessionID, string sourceAccount, string destinationAccount, double amount, string comment)
		{
			return HacmeBank_v2_WS.DataFactory.TransferFunds(sourceAccount,destinationAccount,amount,comment);
		}	

		[WebMethod]
		public ArrayList GetLoanRates(string SessionID)
		{
			return HacmeBank_v2_WS.DataFactory.GetLoanRates();
		}

		[WebMethod]
		public int RequestALoan(string SessionID, string destinationAccount, int amount,int loanPeriod, decimal loanInterestRate, string comment)
		{
			return HacmeBank_v2_WS.DataFactory.RequestALoan(destinationAccount,amount,loanPeriod, loanInterestRate,comment);
		}

		[WebMethod]
		public int MakePayment_Using_CreditCard(string SessionID, string sourceAccount_CCNumber,  string sourceAccount_CCExpiryDate, string destinationAccount, int amount, string comment)
		{
			return HacmeBank_v2_WS.DataFactory.MakePayment_Using_CreditCard(sourceAccount_CCNumber,sourceAccount_CCExpiryDate,destinationAccount,amount,comment);
		}	

		[WebMethod]
		public void CreateAccount(string SessionID, string accountNumber, string userID,  string accountCurrency, string accountBranch, string accountInitalBalance, string accountType)
		{
			HacmeBank_v2_WS.DataFactory.CreateAccount(accountNumber,userID,accountCurrency,accountBranch,accountInitalBalance,accountType);
		}	

		[WebMethod]
		public string recalculateAllAccountBalances()
		{
			return HacmeBank_v2_WS.DataFactory.recalculateAllAccountsBalances();
		}	

		[WebMethod]
		public ArrayList ExecuteSqlQuery(string SessionID, string sqlQueryToExecute)
		{
			return HacmeBank_v2_WS.DataFactory.executeSqlQuery(sqlQueryToExecute);
		}	

	}
}
