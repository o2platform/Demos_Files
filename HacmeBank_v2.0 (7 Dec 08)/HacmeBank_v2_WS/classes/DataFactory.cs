using System;
using System.Collections;
using System.Data.SqlClient;
using System.Configuration;

namespace HacmeBank_v2_WS
{
	/// <summary>
	/// Summary description for DataFactory.
	/// </summary>
	public class DataFactory
	{		
		public DataFactory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		// WS_UserManagement.asmx Methods
		#region UserManagement
		public static ArrayList ListCurrentUsers()
		{				
			string sqlQuery = "select user_name from  fsb_users";	
			return SqlServerEngine.returnArrayListFromSQLQuery_containing_FirstFieldFromAllRows(sqlQuery);
		}

		public static ArrayList GetUserDetail(string fieldToUse,string valueToSearch)
		{
			string sqlQuery = "select * from  fsb_users where " + fieldToUse + " = '" + valueToSearch + "'";	
			return SqlServerEngine.returnArrayListFromSQLQuery_containing_FirstRow(sqlQuery);	
		}


		public static void CreateUser(string userName, string loginID, string userPassword)
		{
			SqlServerEngine.executeSQLCommand("Insert into fsb_users (user_name,login_id,password, creation_date) Values ('" + userName + "','" + loginID + "','" + userPassword + "','" + DateTime.Now + "')");	
		}

		public static void UpdateUser(string userID,string userName, string loginID, string userPassword)
		{
			SqlServerEngine.executeSQLCommand("Update fsb_users set user_name = '" + userName + "',login_id = '" + loginID + "',password = '" + userPassword + "' where user_id = " + userID + "");	
		}

		public static int ValidateUserPassword(string loginID,string password)
		{
			string sqlQuery = "select user_id from  fsb_users where login_id = '" + loginID+ "' and password = '" + password + "'";
			object queryResult = SqlServerEngine.returnObjectFromSQLQuery_containing_FirstFieldFromFirstRow(sqlQuery);
			if (null != queryResult)
			{
				return (int)(decimal)queryResult;
			}					
			else
			{
				return 0;		
			}
		}
		public static void ChangeUserPassword(string userID, string newPassword)
		{
			SqlServerEngine.executeSQLCommand("Update fsb_users Set password = '" + newPassword + "' where user_id = " + userID + "");	
		}

		public static int DeleteUser(string userID)
		{
			return SqlServerEngine.executeSQLCommand("Delete from fsb_users where  user_ID ='" + userID + "'");	
		}

		#endregion



		// WS_AccountManagement.asmx Methods
		#region AccountManagement
		public static ArrayList GetUserAccounts_using_userID(string userID)
		{
			string sqlQuery = "select account_no from  fsb_accounts where user_ID = " + userID;	
			return SqlServerEngine.returnArrayListFromSQLQuery_containing_FirstFieldFromAllRows(sqlQuery);
		}
		public static ArrayList GetAccountDetails_using_AccountID(string accountID)
		{
			string sqlQuery = "select * from  fsb_accounts  where account_no = '" + accountID + "'";	
			return SqlServerEngine.returnArrayListFromSQLQuery_containing_FirstRow(sqlQuery);	
		}

		public static ArrayList GetAccountTransactions_using_AccountID(string accountID)
		{
			string sqlQuery = "select transaction_id from  fsb_transactions  where account_no = '" + accountID + "'";	
			return SqlServerEngine.returnArrayListFromSQLQuery_containing_FirstFieldFromAllRows(sqlQuery);
		}

		public static ArrayList GetAccountTransactionDetails_using_TransactionID(string transactionID)
		{
			string sqlQuery = "select * from  fsb_transactions  where transaction_id = '" + transactionID + "'";	
			return SqlServerEngine.returnArrayListFromSQLQuery_containing_FirstRow(sqlQuery);	
		}

		public static int TransferFunds(string sourceAccount, string destinationAccount, double amount, string comment)
		{
			string sourceAccountTransaction =	"Insert into fsb_transactions " + 
												"(account_no, transaction_date, transaction_mode, transaction_amount, description) " + 
												"Values " + 
												"('" + sourceAccount + "','" + DateTime.Now + "','DB','" + amount + "',' Transfered $" + amount +" to " + destinationAccount + " (" + comment + ")')";	
			
			string destinationAccountTransaction =	"Insert into fsb_transactions " + 
													"(account_no, transaction_date, transaction_mode, transaction_amount, description) " + 
													"Values " + 
													"('" + destinationAccount + "','" + DateTime.Now + "','CR','" + amount + "',' Received $" + amount +" from " + sourceAccount + " (" + comment + ")')";	

			string createFundTransferItem =	"Insert into fsb_fund_transfers " + 
										"(transfer_date, source_account_no, destination_account_no, transfer_amount, remark) " + 
										"Values " + 
										"('" + DateTime.Now + "','" + sourceAccount + "','" + destinationAccount + "','" + amount + "','" +comment + "')";			
			if (1 == SqlServerEngine.executeSQLCommand(sourceAccountTransaction))
				if (1 == SqlServerEngine.executeSQLCommand(destinationAccountTransaction))
					if (1 == SqlServerEngine.executeSQLCommand(createFundTransferItem))						
					{
						recalculateAllAccountsBalances();
						return 1;
					}
			return 0;
		}

		public static ArrayList GetLoanRates()
		{
			string sqlQuery = "Select * from fsb_loan_rates";
			return SqlServerEngine.returnArrayListFromSQLQuery_containing_AllFieldsFromAllRows(sqlQuery);
		}

		public static int RequestALoan(string destinationAccount, int amount, int loanPeriod, decimal loanInterestRate, string comment)
		{
			comment = "[loan for " + loanPeriod.ToString()+" yrs at " + loanInterestRate.ToString() + "%] " + comment;
			string hardCodedInternalBankAccountNumber = "1234123412341234";
			return TransferFunds(hardCodedInternalBankAccountNumber,destinationAccount,amount,comment);
		}

		public static int MakePayment_Using_CreditCard(string sourceAccount_CCNumber,  string sourceAccount_CCExpiryDate, string destinationAccount, int amount, string comment)
		{
			string hardCodedInternalBankAccountNumber = "1234123412341234";
			if (1 == PaymentProviders.makeCCPayment(sourceAccount_CCNumber,sourceAccount_CCExpiryDate,hardCodedInternalBankAccountNumber,amount,"CC Payment"))
			{
				comment = "[CC Payment from " + sourceAccount_CCNumber +":" +sourceAccount_CCExpiryDate +"] " + comment;
				
				return TransferFunds(hardCodedInternalBankAccountNumber,destinationAccount,amount,comment);	
			}
			return 0;
			
		}

		public static void CreateAccount(string accountNumber, string userID,  string accountCurrency, string accountBranch, string accountInitalBalance, string accountType)
		{
			SqlServerEngine.executeSQLCommand(	"Insert into fsb_accounts " +
				"(account_no,user_id,currency,branch,balance_amount,creation_date,account_type) " +
				"Values " +
				"('" + accountNumber + "','" + userID + "','" + accountCurrency + "','" + accountBranch + "','" + accountInitalBalance + "','" + DateTime.Now + "','" + accountType + "')");	
			recalculateAllAccountsBalances();
		}

		public static string recalculateAllAccountsBalances()
		{
			string result = "";
			string sqlQuery = "select account_no from  fsb_accounts";	
			ArrayList bankAccounts = SqlServerEngine.returnArrayListFromSQLQuery_containing_FirstFieldFromAllRows(sqlQuery);			
			foreach(object account in bankAccounts)
				result += recalculateAccountBalance((string) account );
			return result;
		}

		private static string recalculateAccountBalance(string AccountID)
		{
			string debitValueSQLQuery =	"SELECT SUM(transaction_amount) " +
										"FROM dbo.fsb_transactions " + 
										"WHERE (account_no = " + AccountID + ") " + 
										" AND (transaction_mode = 'DB')";			
			string creditValueSQLQuery =	"SELECT SUM(transaction_amount) " +
										"FROM dbo.fsb_transactions " + 
										"WHERE (account_no = " + AccountID + ") " + 
										" AND (transaction_mode = 'CR')";
			string debitValue = (string)SqlServerEngine.returnArrayListFromSQLQuery_containing_FirstRow(debitValueSQLQuery)[0].ToString();	
			if ("" == debitValue) {debitValue = "0";}
			string creditValue = (string)SqlServerEngine.returnArrayListFromSQLQuery_containing_FirstRow(creditValueSQLQuery)[0].ToString();	
			if ("" == creditValue) {creditValue = "0";}
			decimal accountBalance = decimal.Parse(creditValue) - decimal.Parse(debitValue);
			string updateAcccountBalanceSQLQuery = "Update fsb_accounts set balance_amount = " + accountBalance.ToString() + " where account_no = " + AccountID + "";
			SqlServerEngine.executeSQLCommand(updateAcccountBalanceSQLQuery).ToString();				
			return updateAcccountBalanceSQLQuery;
		}

		public static ArrayList executeSqlQuery(string sqlQueryToExecute)
		{
			return SqlServerEngine.returnArrayListFromSQLQuery_containing_AllFieldsFromAllRows_andResultingSchema(sqlQueryToExecute);
		}

		#endregion

		// WS_UsersCommunity.asmx Methods
		#region UsersCommunity

		public static void PostMessage(string userID, string messageSubject, string messageText)
		{
			SqlServerEngine.executeSQLCommand(	"Insert into fsb_messages " +
												"(user_id,message_date,subject,text) " +
												"Values " +
												"('" + userID + "','" + DateTime.Now + "','" + messageSubject + "','" + messageText + "')");	
		}

		public static ArrayList GetPostedMessages()
		{
			string sqlQuery = "Select * from fsb_messages";
			return SqlServerEngine.returnArrayListFromSQLQuery_containing_AllFieldsFromAllRows(sqlQuery);
		}

		public static int DeleteMessage(string messageID)
		{
			string sqlQuery = "Delete from fsb_messages where message_id =" + messageID;
			return SqlServerEngine.executeSQLCommand(sqlQuery);
		}
		#endregion
	}
}
