namespace HacmeBank_v2_Website.ascx
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for Header.
	/// </summary>
	public partial class Header : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{

		}
		#endregion

		//		This method is for logout from the session and goes back to Login.aspx form.
		protected void lnkBtnLogOut_Click(object sender, System.EventArgs e)
		{			
			Response.Cookies.Clear();			
			/// <BugReport>
			/// Causing Session.Abandon or Session.RemoveAll will cause an threading error in the response.redirect method
			/// this only gets resolved when the w3wp process is restarted
			/// </BugReport>						
			Session.RemoveAll();
			Session.Abandon();
			Session["FoundstoneMaketingMaterial"] = "";
			Server.Transfer("Login.aspx");
			//Response.Redirect("Login.aspx");

		}		

		protected void lnkBtnChangePassword_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("main.aspx?function=PasswordChange");
		}		

		protected void lnkBtnMyAccount_Click(object sender, System.EventArgs e)
		{			
			Response.Redirect ("Main.aspx?function=MyAccountForm");
		}



	}
}
