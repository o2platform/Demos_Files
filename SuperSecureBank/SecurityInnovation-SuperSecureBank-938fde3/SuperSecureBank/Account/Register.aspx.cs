using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using SuperSecureBank.Properties;

namespace SuperSecureBank.Account
{
	public partial class Register : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void CreateUserButton_Click(object sender, EventArgs e)
		{
			try
			{
                if (!string.IsNullOrEmpty(UserName.Text))
                {
                    if (!UserMgmt.UserExists(UserName.Text))
                    {
                        Int64 userID = UserMgmt.CreateUser(UserName.Text, Email.Text, Password.Text);
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
                            ErrorMessage.Text = "There was an error creating your user, please try again.";
                        }
                    }
                    else
                    {
                        ErrorMessage.Text = "A user witht that username already exists";
                    }
                }
                else
                {
                    ErrorMessage.Text = "Your username must be at least one character long";
                }
			}
			catch (Exception ex)
			{
				ErrorLogging.AddException("Error in Register", ex);
				ErrorMessage.Text = ex.ToString();
			}
		}

		private void SetUserCookie(Int64 userID)
		{
			Response.Cookies[Settings.Default.SessionCookieKey].Value = UserMgmt.CreateSession(userID).ToString();
		}
	}
}
