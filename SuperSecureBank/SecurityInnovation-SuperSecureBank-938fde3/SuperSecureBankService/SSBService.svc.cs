using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Threading;

namespace SuperSecureBankService
{
	public class SSBService : ISSBService
	{
		public Int64 CreateUser(string username, string email, string pass)
		{
			try
			{
				string insertUser = @"INSERT INTO Users values ('{0}', '{1}', '{2}'); SELECT SCOPE_IDENTITY();";
				SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString);
				conn.Open();
				insertUser = String.Format(insertUser, username, email, pass);
				SqlCommand command = new SqlCommand(insertUser, conn);
				Int64 userID = Convert.ToInt64(command.ExecuteScalar());
				conn.Close();
				return userID;
			}
			catch (Exception)
			{
				throw;
			}
		}

		public Int64 LookupSession(string sessionValue)
		{
			Int64 userID = 0;
			Int64 sessionID = 0;
			if (Int64.TryParse(sessionValue, out sessionID))
			{
				string getUserID = "SELECT userID FROM sessions WHERE sessionID = {0}";
				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
				{
					conn.Open();
					getUserID = String.Format(getUserID, sessionValue);
					SqlCommand command = new SqlCommand(getUserID, conn);
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						userID = reader.GetInt64 (0);
					}
				}
			}
			return userID;
		}

		public string LookupUsername(Int64 userID)
		{
			string userName = "";

			string getUserName = "SELECT userName FROM Users WHERE userID = {0}";
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
			{
				conn.Open();
				getUserName = String.Format(getUserName, userID);
				SqlCommand command = new SqlCommand(getUserName, conn);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					userName = reader.GetString(0);
				}
			}
			return userName;
		}

		public Int64 CheckUser(string username, string password)
		{
			Int64 userID = 0;

			string getUserID = "SELECT userID FROM Users WHERE userName = '{0}' AND password = '{1}'";
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
			{
				conn.Open();
				getUserID = String.Format(getUserID, username, password);
				SqlCommand command = new SqlCommand(getUserID, conn);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					userID = reader.GetInt64 (0);
				}
			}
			return userID;
		}

		public bool UserExists(string username)
		{
			Int64 userID = 0;

			string getUserID = "SELECT userID FROM Users WHERE userName = '{0}'";
			using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
			{
				conn.Open();
				getUserID = String.Format(getUserID, username);
				SqlCommand command = new SqlCommand(getUserID, conn);
				SqlDataReader reader = command.ExecuteReader();

				while (reader.Read())
				{
					userID = reader.GetInt64 (0);
				}
			}
			return userID != 0;
		}

		public Int64 CreateSession(Int64 userID)
		{
			Int64 sessionID = SessionIDSingleton.Instance.NextSessionID;
			string insertSession = @"INSERT INTO sessions values ({0}, {1})";
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString);
			conn.Open();
			insertSession = String.Format(insertSession, userID, sessionID);
			SqlCommand command = new SqlCommand(insertSession, conn);
			command.ExecuteNonQuery();
			conn.Close();

			return sessionID;
		}

		public void RemoveSession(Int64 sessionID)
		{
			string deleteSession = @"DELETE FROM sessions WHERE sessionID = {0}";
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString);
			conn.Open();
			deleteSession = String.Format(deleteSession, sessionID);
			SqlCommand command = new SqlCommand(deleteSession, conn);
			command.ExecuteNonQuery();
			conn.Close();
		}

		public List<Int64> GetAllAccounts()
		{
			string selectAccounts = @"SELECT * FROM FriendlyAccounts";

			List<Int64> accountList = new List<long>();
			try
			{
				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
				{
					conn.Open();
					SqlCommand command = new SqlCommand(selectAccounts, conn);
					SqlDataReader reader = command.ExecuteReader();
					Int64 totalValue = 0;
					while (reader.Read())
					{
						accountList.Add(reader.GetInt64(1));
					}
				}
			}
			catch
			{
				throw;
			}
			return accountList;
		}

		public DataTable GetAccounts(Int64 UserID)
		{
			string selectAccounts = @"SELECT * FROM FriendlyAccounts
									WHERE userID = {0}";

			DataTable dt = new DataTable();
            dt.TableName = "GetAccountsTable";
			try
			{
				dt.Columns.Add("accountID");
				dt.Columns.Add("balance");
				dt.Columns.Add("LevelName");
				dt.Columns.Add("LevelDescription");
				dt.Columns.Add("TypeName");
				dt.Columns.Add("TypeDescription");
				dt.Columns.Add("Status");

				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
				{
					conn.Open();
					selectAccounts = String.Format(selectAccounts, UserID);
					SqlCommand command = new SqlCommand(selectAccounts, conn);
					SqlDataReader reader = command.ExecuteReader();
					Int64 totalValue = 0;
					while (reader.Read())
					{
						DataRow dr = dt.NewRow();
						dr["accountID"] = reader.GetInt64(1);
						dr["balance"] = string.Format("{0:C}", reader.GetInt64(2));
						dr["LevelName"] = reader.GetString(3);
						dr["LevelDescription"] = reader.GetString(4);
						dr["TypeName"] = reader.GetString(5);
						dr["TypeDescription"] = reader.GetString(6);
						dr["Status"] = reader.GetString(7);

						totalValue += reader.GetInt64(2);

						dt.Rows.Add(dr);
					}

					DataRow footer = dt.NewRow();
					footer["accountID"] = "<strong>Total:</strong>";
					footer["balance"] = string.Format("<strong>{0:C}</strong>", totalValue);
					footer["LevelName"] = "";
					footer["LevelDescription"] = "";
					footer["TypeName"] = "";
					footer["TypeDescription"] = "";
					footer["Status"] = "";
					dt.Rows.Add(footer);
				}
			}
			catch
			{
				throw;
			}
            return dt;
            /*try
            {
                var stringWriter = new System.IO.StringWriter();
                dt.WriteXml(stringWriter);
                var xmlText = stringWriter.ToString();
                return xmlText;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }*/
		}

		public Int64 GetBalance(Int64 accountID)
		{
			string selectAccount = @"SELECT balance FROM Accounts WHERE accountID = {0}";
			Int64 balance = 0;
			try
			{
				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
				{
					conn.Open();
					selectAccount = String.Format(selectAccount, accountID);
					SqlCommand command = new SqlCommand(selectAccount, conn);
					SqlDataReader reader = command.ExecuteReader();

					while (reader.Read())
					{
						balance = reader.GetInt64(0);
					}
				}
			}
			catch
			{
				throw;
			}
			return balance;
		}

		public void Transfer(Int64 FromAccount, Int64 ToAccount, Int64 Amount)
		{
			try
			{
				Int64 FromAccountBalance = GetBalance(FromAccount);
				Int64 ToAccountBalance = GetBalance(ToAccount);

				UpdateBalance(ToAccount, ToAccountBalance + Amount);
				Thread.Sleep(new Random().Next(1000, 5000)); //simulate a long account wire transfer that takes 1-5 seconds to happen
				UpdateBalance(FromAccount, FromAccountBalance - Amount);
			}
			catch
			{
				throw;
			}
		}

		public void UpdateBalance(Int64 Account, Int64 NewAmount)
		{
			try
			{
				string updateAmount = @"UPDATE Accounts SET balance={0} WHERE accountID = {1}";
				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
				{
					conn.Open();
					updateAmount = String.Format(updateAmount, NewAmount, Account);
					SqlCommand command = new SqlCommand(updateAmount, conn);
					command.ExecuteNonQuery();
				}
			}
			catch
			{
				throw;
			}
		}

		public void CreateAccount(Int64 userID, string accountType, string balance, string accountLevel, Int64 status)
		{
			try
			{
				string insertNewAccount = "INSERT INTO Accounts VALUES ({0}, {1}, {2}, {3}, {4})";
				insertNewAccount = string.Format(insertNewAccount, userID, accountType, balance, accountLevel, status);
				using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
				{
					conn.Open();
					SqlCommand command = new SqlCommand(insertNewAccount, conn);
					command.ExecuteNonQuery();
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
