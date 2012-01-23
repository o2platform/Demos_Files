//this is the login page and the first page of this application
//user requires to enter username and password to logon into the application
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
using System.Net;
using System.IO;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.Threading;
using System.Net.Sockets;

namespace HacmeBank_v2_Website
{
	/// <summary>
	/// Summary description for WebForm1.
	/// </summary>
	public partial class Login : System.Web.UI.Page
	{
		//private string XMLUrl="http://www.foundstone.com/home/info.xml";		
		string strPathToWebCopyXmlFile = @"http://www.foundstone.com/home/info.xml";
		private bool bAreWeOnline = false;

		protected System.Web.UI.WebControls.Label lblPassword;
		private DataSet fsb_UserDataSet=new DataSet();
		
		protected int NoofAttempts;	//stores the number of attempts to login
		private DateTime now=DateTime.Now;
		protected System.Web.UI.WebControls.LinkButton lnkbtnScoreCard;
		protected System.Web.UI.WebControls.LinkButton lnkBtnChangePassword;
		protected System.Web.UI.WebControls.LinkButton lnkBtnMyAccount;
		protected System.Web.UI.WebControls.LinkButton lnkBtnFundsTransfer;
		protected System.Web.UI.WebControls.LinkButton lnkBtnLoans;
		protected System.Web.UI.WebControls.LinkButton lnkBillPay;
		protected System.Web.UI.WebControls.LinkButton lnkBtnServicesEnquiry;
		protected System.Web.UI.WebControls.LinkButton lnkbtnCorseSchedule;
		protected System.Web.UI.WebControls.LinkButton lnkbtnWhitePaper;
		protected System.Web.UI.WebControls.LinkButton lnkbtnTool;
		protected System.Web.UI.WebControls.LinkButton lnkbtnOtherNews;
		protected System.Web.UI.WebControls.Label lblUsrName;
		protected System.Web.UI.WebControls.Xml xmlInformationrmation;
				
		protected System.Web.UI.WebControls.Xml xmlInformation;
		protected System.Web.UI.WebControls.Label lblHeading;
		protected System.Web.UI.WebControls.LinkButton lnkBtnLogOut;
		protected System.Web.UI.WebControls.LinkButton lnkbtnPostMessage;
		
		protected void Page_Load(object sender, System.EventArgs e)
		{					
			if (!IsPostBack)
			{
				Global.LoginTime=DateTime.Now;  
				Global.bolFlag_Login=false;
				Request.Cookies.Clear ();

				HttpCookie AttemptCntCookie = new HttpCookie("CookieLoginAttempts");
				AttemptCntCookie.Expires=now.AddHours (10);	
				AttemptCntCookie.Value = Global.iLoginAttempt.ToString ();
				Response.Cookies.Add(AttemptCntCookie);
				HttpCookie bolCheckValidUser_Cookie=new HttpCookie("ValidUser");
				bolCheckValidUser_Cookie.Value="False";	
				Session.Add("LoginAttempts", NoofAttempts);				
			}			
			makebtnEnable(true);
			LoadFoundstoneXsmlAdds();
  
			//uncomment to automatically login 
/*
			txtUserName.Text = "a";
			txtPassword.Text = "a";
			btnSubmit_Click(null,null);
*/			
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

		private void LoadFoundstoneXsmlAdds()
		{
			string strPathToLocalCopyOfXmlFile = Path.Combine(MapPath("~/xml/"),"info.xml");		
			string strSourceInformation = ""; 
			try
			{
				string strTest = Session["FoundstoneMaketingMaterial"].ToString();
				if (Session["FoundstoneMaketingMaterial"].ToString()=="")
				{
					// return;	// comment here to disable this test
					XPathDocument myXPathDoc;
					// we are going to start a new thread and give it 500ms to complete (this is thread we open a TCP connection to www.foundstone.com)
					bAreWeOnline = false;						
					ThreadStart tsAreWeOnline = new ThreadStart(checkIfWeAreOnline);						
					tsAreWeOnline.BeginInvoke(null,null);
					Thread.Sleep(500);						
					if (false && bAreWeOnline)		// DC (nov 08)Removed this for now		// if the tcp connection was succssfull we are online
					{
						//Response.Write("<hr/> We are online <hr/>");
						myXPathDoc = new XPathDocument(strPathToWebCopyXmlFile);					
						strSourceInformation = "&nbsp;&nbsp;&nbsp;<i>[The information below is up-to-date and was downloaded from the foundstone website]</i><br>";
					}
					else
					{
						//Response.Write("<hr/> We are NOT online <hr/>");
						myXPathDoc = new XPathDocument(strPathToLocalCopyOfXmlFile);
						strSourceInformation = "&nbsp;&nbsp;&nbsp;<i>[ The current computer is not online, so the information below might be out-of-date]</i><br>";
					}

					// now that we have a file to work on (either the dynamic from the website of the one local) we can can do the transformation
					XslTransform myXslTrans = new XslTransform() ;
					myXslTrans.Load(Path.Combine(MapPath(Gui.pathToXslFolder),"info.xsl"));
					MemoryStream msXslTrans = new MemoryStream();				
					myXslTrans.Transform(myXPathDoc,null,msXslTrans, new XmlUrlResolver()) ;
					msXslTrans.Flush();
					msXslTrans.Position= 0;
					// after store the transformation in a session variable so that we don't have to do this everytime
					Session["FoundstoneMaketingMaterial"] =  (new StreamReader(msXslTrans)).ReadToEnd();												
				}
				lbXmlInformation.Text = strSourceInformation + Session["FoundstoneMaketingMaterial"].ToString();
			}
			catch (Exception ex)
			{
				Response.Write("<hr/>" + ex.Message + "<hr/>");
			}	
		}

		private void checkIfWeAreOnline()
		{
			TcpClient tcOnlineCheck = new TcpClient();
            try
            {
            //    tcOnlineCheck.Connect("www.foundstone.com", 80);			// use this to check if we are online			
                bAreWeOnline = true;
            }
            catch
            {}
		}

		private  void makebtnEnable(bool AttempValue)
		{
			try 
			{
				bool IsEnabled;
				HttpCookie MyCookie;							
				MyCookie = Request.Cookies["CookieLoginAttempts"];
				MyCookie.Expires =now.AddHours (10);
				if (MyCookie.Value.ToString()!="0")
				{
					IsEnabled=true;
				}
				else
				{
					IsEnabled=false;
					lblResult.Text ="Your Session has been Locked";					
					txtPassword.Enabled=false;
					btnSubmit.Enabled = false;
				}
				btnSubmit.Enabled = IsEnabled;
			}
			catch {}
		}
		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{			
			try 
			{
				string loginResult = Global.objUserManagement.Login(txtUserName.Text,txtPassword.Text);
				try
				{
					Int32.Parse(loginResult);
				}
				catch
				{				
					lblResult.Text= loginResult;	
					return;
				}
				if ("0" != loginResult)				
				{				
					dataClasses.userData objUserData = new UserManagement().setupUserSession(loginResult , txtUserName.Text);												
					Session.Add("userID",objUserData.userID);			
					Session.Add("username", objUserData.userName);
					Session.Add("SessionID", loginResult);	
					txtUserName.Text="";
					txtPassword.Text="";
					Global.bolFlag_Login =true;
					Global.objGui.setCookieValue("Admin","false");					
					Response.Redirect("main.aspx?function=Welcome",true);		
					//Response.Write("Before");					
					//Server.Transfer("main.aspx?function=Welcome");
				}
				else
				{					
					LogInAttempts_Method();	
				}
			}
			catch (Exception Ex)
			{				
				lblResult.Text= Ex.Message;				
			}
		}
		private void LogInAttempts_Method()
		{
			HttpCookie MyCookie;							
			MyCookie = Request.Cookies["CookieLoginAttempts"];
			int logInAtt=Convert.ToInt32(MyCookie.Value.ToString());
			if (logInAtt==0)
			{
				lblResult.Text ="Your Session has been Locked";					
				txtPassword.Enabled=false;
				btnSubmit.Enabled = false;
			}
			else
			{
				lblResult.Text="Invalid Login";
				UpdateLoginAttmptCookie();
			}
		}
		
		private void UpdateLoginAttmptCookie()
		{
			//updates the cookie value storing the no of attempts
			int CookieVal;
			//Read the present value			
			try
			{
				
				HttpCookie MyCookie;							
				MyCookie = Request.Cookies["CookieLoginAttempts"];
				MyCookie.Expires=now.AddHours(10);
				//decrement it
				int logInAtt=Convert.ToInt32(MyCookie.Value.ToString());
				CookieVal=int.Parse (MyCookie.Value.ToString());
				if (CookieVal > 0)
					CookieVal-=1;
				//store in response cookie
				HttpCookie AttemptCntCookie = new HttpCookie("CookieLoginAttempts");					
				AttemptCntCookie.Value = CookieVal.ToString ();
				AttemptCntCookie.Expires=now.AddHours (10);		
				Response.Cookies.Add(AttemptCntCookie);									
			}
			catch(Exception Ex)
			{
				lblResult.Text= Ex.Message;
			}
		}


/*
//		This method displays the Course Schedule value in the xml file
		private void lnkbtnCorseSchedule_Click(object sender, System.EventArgs e)
		{
			WebClient Client;
			try
			{
				Client=new WebClient();
				Client.DownloadFile(XMLUrl, Server.MapPath(null)+"/xml/info.xml");
				xmlInformation.DocumentSource="xml/info.xml";
				xmlInformation.TransformSource="CourseSchd.xsl";
				Client.Dispose();
			}
			catch (System.Exception Ex)
			{
				if (Ex.Message!="")
				{
					if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory+"images/infoTemp.xml"))
					{
					Client=new WebClient();
					xmlInformation.DocumentSource="images/infoTemp.xml";
					xmlInformation.TransformSource="CourseSchd.xsl";
					Client.Dispose();
					}
					else
					{
						Response.Write("<script>alert('XML File Not Found')</script>"); 
					}
				}
			}
		}

//		This method displays the White Paper value in the xml file
		private void lnkbtnWhitePaper_Click(object sender, System.EventArgs e)
		{
			WebClient Client;
			try
			{
				Client=new WebClient();
				Client.DownloadFile(XMLUrl, Server.MapPath(null)+"/xml/info.xml");
				xmlInformation.DocumentSource="xml/info.xml";
				xmlInformation.TransformSource="whitepaper.xsl";
				Client.Dispose();
				if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory+"xml/info.xml"))
				{
					File.Copy(System.AppDomain.CurrentDomain.BaseDirectory+"xml/info.xml",System.AppDomain.CurrentDomain.BaseDirectory+"images/infoTemp.xml",true);
				}
			}
			catch (System.Exception Ex)
			{
				if (Ex.Message!="")
				{
					if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory+"images/infoTemp.xml"))
					{
						Client=new WebClient();
						xmlInformation.DocumentSource="images/infoTemp.xml";
						xmlInformation.TransformSource="whitepaper.xsl";
						Client.Dispose();
					}
					else
					{
						Response.Write("<script>alert('XML File Not Found')</script>"); 
					}
				}
			}
		}
//		This method displays the Tool value in the xml file
		private void lnkbtnTool_Click(object sender, System.EventArgs e)
		{
			WebClient Client;
			try
			{
				Client=new WebClient();
				Client.DownloadFile(XMLUrl, System.AppDomain.CurrentDomain.BaseDirectory+"xml/info.xml");
				xmlInformation.DocumentSource="xml/info.xml";
				xmlInformation.TransformSource="tool.xsl";
				Client.Dispose();			
				if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory+"xml/info.xml"))
				{
					File.Copy(System.AppDomain.CurrentDomain.BaseDirectory+"xml/info.xml",System.AppDomain.CurrentDomain.BaseDirectory+"images/infoTemp.xml",true);
				}
			}
			catch (System.Exception Ex)
			{
				if (Ex.Message!="")
				{
					if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory+"images/infoTemp.xml"))
					{
						Client=new WebClient();
						xmlInformation.DocumentSource="images/infoTemp.xml";
						xmlInformation.TransformSource="tool.xsl";
						Client.Dispose();
					}
					else
					{
						Response.Write("<script>alert('XML File Not Found')</script>"); 
					}
				}
			}
		}
//		This method displays the Other News value in the xml file
		private void lnkbtnOtherNews_Click(object sender, System.EventArgs e)
		{
			WebClient Client;
			try
			{
				Client=new WebClient();
				Client.DownloadFile(XMLUrl, Server.MapPath(null)+"/xml/info.xml");
				xmlInformation.DocumentSource="xml/info.xml";
				Client.Dispose();
				xmlInformation.TransformSource="othernews.xsl";
				if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory+"xml/info.xml"))
				{
					File.Copy(System.AppDomain.CurrentDomain.BaseDirectory+"xml/info.xml",System.AppDomain.CurrentDomain.BaseDirectory+"images/infoTemp.xml",true);
				}
			}
			catch (System.Exception Ex)
			{
				if (Ex.Message!="")
				{
					if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory+"images/infoTemp.xml"))
					{
						
						Client=new WebClient();
						xmlInformation.DocumentSource="images/infoTemp.xml";
						xmlInformation.TransformSource="othernews.xsl";
						Client.Dispose();
					}
					else
					{
						Response.Write("<script>alert('XML File Not Found')</script>"); 
					}
				}
			}
		}			
	*/		
	}
}
