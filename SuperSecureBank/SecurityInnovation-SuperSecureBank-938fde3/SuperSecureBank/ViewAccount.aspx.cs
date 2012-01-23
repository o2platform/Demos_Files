using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperSecureBank.Properties;
using System.Data;
using System.IO;

namespace SuperSecureBank
{
	public partial class ViewAccount : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (null != Request.Cookies[Settings.Default.SessionCookieKey])
				{
					Int64 userID = UserMgmt.LookupSession(Request.Cookies[Settings.Default.SessionCookieKey].Value);
					if (0 == userID)
						Response.Redirect("Account/Login.aspx?ReturnUrl=/Forum.aspx");
					else
					{
						Accounts.DataSource = AccountMgmt.GetAccounts(userID);
						Accounts.DataBind();
					}
				}
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