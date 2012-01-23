using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.SessionState;
using localhost;

namespace HacmeBank_v2_Website
{
	/// <summary>
	/// Summary description for Global.
	/// </summary>/// 
	public class Global : System.Web.HttpApplication
	{

        public static WS_UserManagement objUserManagement = new WS_UserManagement();
        public static WS_AccountManagement objAccountManagement = new WS_AccountManagement();
        public static WS_UsersCommunity objUsersCommunity = new WS_UsersCommunity();			

		public static Gui objGui= new Gui();

		public static int igSuccess=0;
		public static int igAttempt=0;
		public static string UserName="";
		public static string UserID="";
		public static string AccType="B";
		public static int iLoginAttempt = Int32.Parse(System.Configuration.ConfigurationSettings.AppSettings.Get("Login_attempts"));
		public static DateTime LoginTime;
		public static bool bolFlag_Login=false;

		//public static Session mySession=new Session();

		public Global()
		{
			InitializeComponent();
		}	
		
		protected void Application_Start(Object sender, EventArgs e)
		{
			igSuccess=0;
			igAttempt=0;
		}
 
		protected void Session_Start(Object sender, EventArgs e)
		{			
			Session["LoginAttempts"]=iLoginAttempt;
			Session["FoundstoneMaketingMaterial"] = "";
//			Application.Lock ( );
//			Application. ('ActiveUsers')++ ;
//			Application.UnLock ( );
//			Session["UserID"]=UserID; 
//			Session["UserName"]=UserName; 
//			Session["SessionID"] = Request.Cookies[0].Value ;
//          long mySessionID = Session.SessionID; 
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			

		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{

			System.DateTime moment = new System.DateTime(2005, 1, 1, 12, 00, 00, 01);
			Response.Cache.SetCacheability(HttpCacheability.NoCache);
			Response.Cache.SetNoStore();
			Response.Expires=10;
			Response.ExpiresAbsolute=moment;
			Response.AddHeader("cache-control","private");
			Response.AddHeader("pragma","no-cache");


		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{

		}

		protected void Application_Error(Object sender, EventArgs e)
		{

		}

		protected void Session_End(Object sender, EventArgs e)
		{
			Global.igAttempt=0;
			Global.igSuccess=0;
			LoginTime=DateTime.Now;
			Session.Abandon();
			
		}

		protected void Application_End(Object sender, EventArgs e)
		{

		}
			
		#region Web Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			igSuccess=0;
			igAttempt=0;
		}
		#endregion
		
	}	
}

