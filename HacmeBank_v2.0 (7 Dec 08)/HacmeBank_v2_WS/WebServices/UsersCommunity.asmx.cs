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
	/// Summary description for UsersCommunity.
	/// </summary>
	public class WS_UsersCommunity : System.Web.Services.WebService
	{
		public WS_UsersCommunity()
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
		public void PostMessage(string sessionID, string userID, string messageSubject, string messageText)
		{
			HacmeBank_v2_WS.DataFactory.PostMessage(userID,messageSubject,messageText);
		}

		[WebMethod]
		public ArrayList GetPostedMessages(string sessionID)
		{
			return HacmeBank_v2_WS.DataFactory.GetPostedMessages();
		}

		[WebMethod]
		public int DeleteMessage(string sessionID,string messageID)
		{
			return HacmeBank_v2_WS.DataFactory.DeleteMessage(messageID);
		}
		
	}
}
