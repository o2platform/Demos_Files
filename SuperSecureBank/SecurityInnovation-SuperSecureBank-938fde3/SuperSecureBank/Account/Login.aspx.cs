using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using SuperSecureBank.Properties;

namespace SuperSecureBank.Account
{
	public partial class Login : System.Web.UI.Page
	{
protected void Page_Load(object sender, EventArgs e)
{
	if (null != Request.Cookies[Settings.Default.SessionCookieKey])
	{
		if (0 != UserMgmt.LookupSession(Request.Cookies[Settings.Default.SessionCookieKey].Value))
			Response.Redirect("~/Default.aspx");
	}
}

		protected void LoginButton_Click(object sender, EventArgs e)
		{
            try
            {
                if (UserMgmt.UserExists(UserName.Text))
                {
                    Int64 userID = UserMgmt.CheckUser(UserName.Text, Password.Text);
                    if (0 != userID)
                    {
                        Response.Cookies[Settings.Default.SessionCookieKey].Value = UserMgmt.CreateSession(userID).ToString();

                        string continueUrl = Request.QueryString["ReturnUrl"];
                        if (String.IsNullOrEmpty(continueUrl))
                        {
                            continueUrl = "~/";
                        }
                        Response.Redirect(continueUrl);
                    }
                    else
                    {
                        FailureText.Text = string.Format("Sorry {0}, that's not the password we have stored in the system. Please try again.", CleanUsername(UserName.Text));
                    }
                }
                else
                {
                    FailureText.Text = string.Format("Sorry, the username {0} doesn't exist in the system", CleanUsername(UserName.Text));
                }
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in Register", ex);
                FailureText.Text = ex.ToString();
            }
		}

		private string CleanUsername(string p)
		{
            p = p.Replace("<script>", "");
			
			return p;
		}
	}
}
