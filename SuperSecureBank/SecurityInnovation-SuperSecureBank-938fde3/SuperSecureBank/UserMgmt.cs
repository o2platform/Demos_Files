using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace SuperSecureBank
{
	public static class UserMgmt
	{
		public static Int64 CreateUser(string username, string email, string pass)
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

		public static Int64 LookupSession(string sessionValue)
		{
			Int64 userID = 0;
            try
            {
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
            }
            catch
            {
                throw;
            }
			return userID;
		}

		public static string LookupUsername(Int64 userID)
		{
			string userName = "";
            try
            {
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
            }
            catch
            {
                throw;
            }
			return userName;
		}

		public static Int64 CheckUser(string username, string password)
		{
			Int64 userID = 0;
            try
            {
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
            }
            catch
            {
                throw;
            }
			return userID;
		}

		public static bool UserExists(string username)
		{
            Int64 userID = 0;
            try
            {

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
            }
            catch
            {
                throw;
            }
			return userID != 0;
		}

		public static Int64 CreateSession(Int64 userID)
		{
            Int64 sessionID = 0;
            try
            {
                sessionID = SessionIDSingleton.Instance.NextSessionID;
                string insertSession = @"INSERT INTO sessions values ({0}, {1})";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString);
                conn.Open();
                insertSession = String.Format(insertSession, userID, sessionID);
                SqlCommand command = new SqlCommand(insertSession, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw;
            }
			return sessionID;
		}

		internal static void RemoveSession(Int64 sessionID)
		{
            try
            {
                string deleteSession = @"DELETE FROM sessions WHERE sessionID = {0}";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString);
                conn.Open();
                deleteSession = String.Format(deleteSession, sessionID);
                SqlCommand command = new SqlCommand(deleteSession, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw;
            }
		}
	}
}