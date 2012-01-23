using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperSecureBank.Properties;
using System.IO;

namespace SuperSecureBank
{
	public partial class ApplyForAccount : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (null != Request.Cookies[Settings.Default.SessionCookieKey])
				{
					Int64 userID = UserMgmt.LookupSession(Request.Cookies[Settings.Default.SessionCookieKey].Value);
					if (0 == userID)
						Response.Redirect("Account/Login.aspx?ReturnUrl=/ApplyForAccount.aspx");
				}
			}
			catch (Exception ex)
			{
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
				message.Visible = true;
				message.Text = ex.ToString();
			}
		}

		protected void Submit_Click(object sender, EventArgs e)
		{
            try{
			AccountMgmt.CreateAccount(UserMgmt.LookupSession(Request.Cookies[Settings.Default.SessionCookieKey].Value),
				AccountType.SelectedValue, StartingBalance.Value, AccountLevel.SelectedValue, 1);
			Response.Redirect(string.Format(@"ActionDone.aspx?Title=Application Completed&Text=Thank you for applying for a new {0} account with SuperSecure Bank, your applicaiton will be reviewed and a banker will be with you shortly. At any time you can check on the status of your account by going to the <a href=""ViewAccount.aspx"">View Accounts Page</a>", AccountType.SelectedItem));
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                message.Visible = true;
                message.Text = ex.ToString();
            }
		}
	}
}