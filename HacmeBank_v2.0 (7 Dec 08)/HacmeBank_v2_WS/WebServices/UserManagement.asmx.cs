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
	/// Summary description for Service1.
	/// </summary>
	public class WS_UserManagement : System.Web.Services.WebService
	{
		public WS_UserManagement()
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
		public string Login(string loginID, string password)
		{
			try
			{
				string sessionID = "";
				string sessionGUID = "0"; //"[SessionGUID]";
				string userID = HacmeBank_v2_WS.DataFactory.ValidateUserPassword(loginID,password).ToString();
				if ("0" != userID)
				{
					sessionID = sessionGUID + "0000" + userID;
				}
				else
				{
					sessionID = userID;
				}
				return sessionID;
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		[WebMethod]
		public ArrayList ListCurrentUsers(string sessionID)
		{
			return HacmeBank_v2_WS.DataFactory.ListCurrentUsers();			
		}

		[WebMethod]
		public ArrayList GetUserDetail_using_userName(string sessionID,string userName)
		{
			return HacmeBank_v2_WS.DataFactory.GetUserDetail("user_name",userName);
		}

		[WebMethod]
		public ArrayList GetUserDetail_using_userID(string sessionID,string userID)
		{
			return HacmeBank_v2_WS.DataFactory.GetUserDetail("user_id",userID);
		}

		[WebMethod]
		public ArrayList GetUserDetail_using_loginID(string sessionID,string loginID)
		{
			return HacmeBank_v2_WS.DataFactory.GetUserDetail("login_id",loginID);
		}

		[WebMethod]
		public void CreateUser(string sessionID, string userName, string loginID, string userPassword)
		{
			 HacmeBank_v2_WS.DataFactory.CreateUser(userName,loginID,userPassword);
		}

		[WebMethod]
		public void UpdateUserDetails(string sessionID,string userID, string userName, string loginID, string userPassword)
		{
			HacmeBank_v2_WS.DataFactory.UpdateUser(userID,userName,loginID,userPassword);
		}

		[WebMethod]
		public void ChangeUserPassword(string sessionID,string userID, string newPassword)
		{
			HacmeBank_v2_WS.DataFactory.ChangeUserPassword(userID,newPassword);
		}

		[WebMethod]
		public int DeleteUser(string sessionID,string userID)
		{
			return HacmeBank_v2_WS.DataFactory.DeleteUser(userID);
		}
	}
}
