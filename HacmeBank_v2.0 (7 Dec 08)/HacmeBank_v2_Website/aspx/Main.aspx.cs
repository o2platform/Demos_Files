//Thispage is the second page which contains the links to allother pages
//and is get displayed after successful login
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
 

namespace HacmeBank_v2_Website
{
	/// <summary>
	/// Summary description for Welcome.
	/// </summary>
	public partial class Main : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.LinkButton lnkBtnPostMessage;
		protected System.Web.UI.WebControls.Label MyLabel2;
		protected System.Web.UI.WebControls.Button btnScordCard;
		protected System.Web.UI.WebControls.LinkButton lnkBtnChangePassword;
		protected System.Web.UI.WebControls.LinkButton lnkBtnMyAccount;
		protected System.Web.UI.WebControls.LinkButton lnkBtnLogOut;		
		protected System.Web.UI.WebControls.LinkButton lnkBtnFundsTransfer;
		protected System.Web.UI.WebControls.LinkButton lnkBtnLoans;
		protected System.Web.UI.WebControls.LinkButton lnkBillPay;
		//protected System.Web.UI.WebControls.HyperLink lnkPostMessage;
		protected System.Web.UI.WebControls.LinkButton lnkBtnServicesEnquiry;
		protected System.Web.UI.WebControls.Label lblHeading;
		protected System.Web.UI.WebControls.Label lblErrorMessage;
		protected System.Web.UI.WebControls.Label lblDynamicAscxControl;
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here			
//			try
			{	
				// Here it checks if the Session is a valid session or not.
				//Other wise redirectd the user to the login form again to relogin
				if (Session["userID"] !=null) 
				{						
					//load default Controls
					Global.objGui.loadDefaultPageControls(ascxPlaceHolder_LeftMenu,ascxPlaceHolder_TopMenu,ascxPlaceHolder_Footer);									

					if ("Welcome" ==Request.QueryString["function"])
					{
						// I have no Idea why this works, but if we preload the acxs like this the problem seems to be solved!
						ascxThreadingIssue.preloadAllAscxControls();
						// Load Welcome.ascx once all Ascx are loaded
						Global.objGui.loadControlOnPlaceHolder(ascxPlaceHolder_ContentArea,"Welcome");																
					}
					else
					{
						Global.objGui.loadControlOnPlaceHolder(ascxPlaceHolder_ContentArea,Request.QueryString["function"]);								
					}

					//	********* THIS IS THE SECTION THAT IS CAUSING THE ERRORS
					//	*** To replicate the problem, compile and do this sequence twice:
					//	***
					//	***	1) Kill w3wp.exe
					//	*** 2) open http://192.168.1.10/HacmeBank_v2_Website/aspx/main.aspx
					//	*** 3) login using a valid account account
					//	*** 4) click on any of the menu functions

					// load page Control (specified in the querystring variable 'function')

					//Global.objGui.loadControlOnPlaceHolder(ascxPlaceHolder_ContentArea,Request.QueryString["function"]);								
					// ************************************************************

					lblWUserName.Text= Session["username"].ToString ();
	
				}
				else
				{
					//goto login page 
					string lmsg;
					lmsg="Session Timed-out";
					Response.Redirect("Login.aspx?lmsg=" + lmsg);					
				}			
			}
//			catch (Exception ex)
//			{
//				Response.Write(ex.Message.ToString ());
//			}
		}


		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion


	}
}
