using System;
using System.Configuration;
using localhost;

namespace HacmeBank_v2_Website
{
	/// <summary>
	/// Summary description for AccountManagement.
	/// </summary>
	public class AccountManagement
	{
		//public static string ipAddressOfWebService = ConfigurationSettings.AppSettings.Get("ipAddressOfWebService");
		private static WS_AccountManagement objWS_AccountManagement = new WS_AccountManagement();

		public AccountManagement()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public object[] WS_GetUserAccounts_using_UserID(string sessionID, string userID)
		{
			return objWS_AccountManagement.GetUserAccounts_using_UserID(sessionID,userID);
		}

		public dataClasses.userAccount WS_GetAccountDetails_using_AccountID(string sessionID,string accountID)
		{
			dataClasses.userAccount objUserAccount = new dataClasses.userAccount();
			object[] WS_AccountData = objWS_AccountManagement.GetAccountDetails_using_AccountID(sessionID,accountID);
			if (0 == WS_AccountData.Length )
			{
				return null;
			}
			else
			{
				objUserAccount.accountID = (decimal)WS_AccountData[0];
				objUserAccount.userID = (decimal)WS_AccountData[1];
				objUserAccount.accountCurrency = (string)WS_AccountData[2];
				objUserAccount.accountBranch = (string)WS_AccountData[3];
				objUserAccount.accountBalance = (decimal)WS_AccountData[4];
				objUserAccount.creationDate = (DateTime)WS_AccountData[5];
				objUserAccount.accountType = (string)WS_AccountData[6];
				return objUserAccount;
			}
		}
		public dataClasses.userAccount[] getAllUserAccountDetails(string sessionID,string userID)
		{
			object[] userAccounts = WS_GetUserAccounts_using_UserID(sessionID,userID);
			dataClasses.userAccount[] userAccountDetails = new HacmeBank_v2_Website.dataClasses.userAccount[userAccounts.Length];
			for (int i=0 ; i< userAccounts.Length;i++)
			{
				userAccountDetails[i] = WS_GetAccountDetails_using_AccountID("", (string)userAccounts[i] );
				
			}
			return userAccountDetails;
		}

		public object[] WS_GetAccountTransactions_using_AccountID(string sessionID, string accountID)
		{
			return objWS_AccountManagement.GetAccountTransactions_using_AccountID(sessionID,accountID);
		}

		public dataClasses.transactionDetail WS_GetAccountTransactionDetails_using_TransactionID(string sessionID,string transactionID)
		{
			dataClasses.transactionDetail objTransactionDetail= new dataClasses.transactionDetail();
			object[] WS_TransactionData = objWS_AccountManagement.GetAccountTransactionDetails_using_TransactionID(sessionID,transactionID);
			objTransactionDetail.transactionID = (decimal)WS_TransactionData[0];
			objTransactionDetail.accountID = (decimal)WS_TransactionData[1];
			objTransactionDetail.transactionDate = (DateTime)WS_TransactionData[2];
			objTransactionDetail.transactionMode = (string)WS_TransactionData[3];
			objTransactionDetail.transactionAmount = (decimal)WS_TransactionData[4];
			objTransactionDetail.transactionDescription = (string)WS_TransactionData[5];			
			return objTransactionDetail;
		}

		public dataClasses.transactionDetail[] getAllTransactionsDetails(string sessionID,string accountID)
		{
			object[] allAccountTransactions = WS_GetAccountTransactions_using_AccountID(sessionID,accountID);
			dataClasses.transactionDetail[] transactionDetails = new HacmeBank_v2_Website.dataClasses.transactionDetail[allAccountTransactions.Length];
			for (int i=0 ; i< allAccountTransactions.Length;i++)
			{
				transactionDetails [i] = WS_GetAccountTransactionDetails_using_TransactionID("",(string)allAccountTransactions[i]);				
			}
			return transactionDetails ;
		}

		public void WS_TransferFunds(string sessionID,string sourceAccount,string destinationAccount,Int32 amount,string comment)
		{
			objWS_AccountManagement.TransferFunds(sessionID,sourceAccount,destinationAccount,amount,comment);
		}

		public object[] WS_GetLoanRates(string sessionID)
		{
			return objWS_AccountManagement.GetLoanRates(sessionID);
		}

		public void WS_RequestALoan(string sessionID, string destinationAccount,int loanAmount,int loanPeriod,decimal loanInterestRate,string loanComment)
		{
			objWS_AccountManagement.RequestALoan(sessionID, destinationAccount,loanAmount,loanPeriod,loanInterestRate,loanComment);
		}

		public object WS_ExecuteSqlQuery(string sessionID, string sqlQueryToExecute)
		{
			return objWS_AccountManagement.ExecuteSqlQuery(sessionID,sqlQueryToExecute);
		}

		public void WS_CreateAccount(string sessionID, string accountNumber,string userID,string accountCurrency,string accountBranch,string accountInitialBalance,string accountType)
		{
			objWS_AccountManagement.CreateAccount( sessionID,  accountNumber, userID, accountCurrency, accountBranch, accountInitialBalance, accountType);
		}
	}
}
