using System;
using System.Collections;
using System.Configuration;
using localhost;

namespace HacmeBank_v2_Website
{
	/// <summary>
	/// Summary description for UserManagement.
	/// </summary>
	/// 

	public class UserManagement : System.Web.UI.Page
	{
		public static string ipAddressOfWebService = ConfigurationSettings.AppSettings.Get("ipAddressOfWebService");	
		private static WS_UserManagement objWS_UserManagement = new WS_UserManagement();

		public UserManagement()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string WS_Login(string logonID, string Password)
		{
			return objWS_UserManagement.Login(logonID,Password);
		}

		public dataClasses.userData setupUserSession(string sessionID, string loginID)
		{			
			object[] WS_userData = objWS_UserManagement.GetUserDetail_using_loginID("",loginID);
			dataClasses.userData objUserData = new HacmeBank_v2_Website.dataClasses.userData();
			objUserData.userID = (decimal)WS_userData[0];
			objUserData.userName = (string)WS_userData[1];
			objUserData.loginID= (string)WS_userData[2];
			objUserData.password = (string)WS_userData[3];
			objUserData.creationDate = (DateTime)WS_userData[4];
			return objUserData;		
		}

		public void WS_ChangeUserPassword(string sessionID, string userID, string newPassword)
		{
			objWS_UserManagement.ChangeUserPassword(sessionID,userID, newPassword);
		}

		public object[] WS_ListCurrentUsers(string sessionID)
		{
			return objWS_UserManagement.ListCurrentUsers(sessionID);			
		}

		public object[] WS_GetUserDetail_using_userName(string sessionID, string userName)
		{
			return objWS_UserManagement.GetUserDetail_using_userName(sessionID, userName);
		}

		public void WS_CreateUser(string sessionID, string userName, string loginID, string userPassword)
		{
			objWS_UserManagement.CreateUser(sessionID, userName, loginID, userPassword);
		}

		public int WS_DeleteUser(string sessionID,string userID)
		{
			return objWS_UserManagement.DeleteUser(sessionID,userID);			
		}
	
		public object[] WS_GetUserDetail_using_userID(string sessionID, string userID)
		{
			return objWS_UserManagement.GetUserDetail_using_userID(sessionID, userID);
		}
	}
}
