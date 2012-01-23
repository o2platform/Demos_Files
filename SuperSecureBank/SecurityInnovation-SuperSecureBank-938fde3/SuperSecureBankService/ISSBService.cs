using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace SuperSecureBankService
{
	[ServiceContract]
	public interface ISSBService
	{
		//User Management
		[OperationContract]
		Int64 CreateUser(string username, string email, string pass);
		[OperationContract]
		Int64 LookupSession(string sessionValue);
		[OperationContract]
		bool UserExists(string username);
		[OperationContract]
		void RemoveSession(Int64 sessionID);
		[OperationContract]
		Int64 CheckUser(string username, string password);
		[OperationContract]
		string LookupUsername(Int64 userID);
		[OperationContract]
		Int64 CreateSession(Int64 userID);
		

		//Account Management
		[OperationContract]
        DataTable GetAccounts(Int64 UserID);
		[OperationContract]
		List<Int64> GetAllAccounts();
		[OperationContract]
		Int64 GetBalance(Int64 accountID);
		[OperationContract]
		void Transfer(Int64 FromAccount, Int64 ToAccount, Int64 Amount);
		[OperationContract]
		void UpdateBalance(Int64 Account, Int64 NewAmount);
		[OperationContract]
		void CreateAccount(Int64 userID, string accountType, string balance, string accountLevel, Int64 status);
	}
}
