using System;

namespace HacmeBank_v2_Website
{
	/// <summary>
	/// Summary description for dataClasses.
	/// </summary>
	public class dataClasses
	{
		public dataClasses()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public class userData
		{
			public decimal userID;
			public string userName;
			public string loginID;
			public string password;
			public DateTime creationDate;
		}

		public class userAccount
		{
			public decimal accountID;
			public decimal userID;
			public string accountCurrency;
			public string accountBranch;			
			public decimal accountBalance;
			public DateTime creationDate;
			public string accountType;
		}
		
		public class transactionDetail
		{
			public decimal transactionID;
			public decimal accountID;
			public DateTime transactionDate;
			public string transactionMode;
			public decimal transactionAmount;
			public string transactionDescription;			
		}

		public class postedMessage
		{
			public decimal messageID;
			public decimal userID;
			public DateTime messageDate; 
			public string messageSubject;
			public string messageText;
		}
	}
}
