using System;

namespace HacmeBank_v2_WS
{
	/// <summary>
	/// Summary description for PaymentProviders.
	/// </summary>
	public class PaymentProviders
	{
		public PaymentProviders()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static int makeCCPayment(string sourceAccount_CCNumber,  string sourceAccount_CCExpiryDate, string destinationAccount, int amount, string comment)
		{
			if 	(1 == validateCCDetails(sourceAccount_CCNumber,sourceAccount_CCExpiryDate))	
			{
				string externalCCPaymentTransaction =	"Insert into fsb_transactions " + 
					"(account_no, transaction_date, transaction_mode, transaction_amount, description) " + 
					"Values " + 
					"('" + destinationAccount + "','" + DateTime.Now + "','CR','" + amount + "',' Received $" + amount +" from CC " + sourceAccount_CCNumber + ":" + sourceAccount_CCExpiryDate+ " (" + comment + ")')";	

				return SqlServerEngine.executeSQLCommand(externalCCPaymentTransaction);					
			}
			else
			{
				return 0;
			}
		}
		private static int validateCCDetails(string sourceAccount_CCNumber,  string sourceAccount_CCExpiryDate)
		{
			// for now assume that the CC details are valid
			return 1;
		}
	}
}
