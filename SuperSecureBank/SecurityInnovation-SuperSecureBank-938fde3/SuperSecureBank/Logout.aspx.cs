using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperSecureBank.Properties;
using System.IO;

namespace SuperSecureBank.Account
{
	public partial class Logout : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            try
            {
                if (!string.IsNullOrEmpty(Request.Cookies[Settings.Default.SessionCookieKey].Value))
                    UserMgmt.RemoveSession(Convert.ToInt64(Request.Cookies[Settings.Default.SessionCookieKey].Value));

                Response.Cookies[Settings.Default.SessionCookieKey].Value = "";
                Response.Redirect("~/");
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                Response.Write(ex.ToString());
            }
		}
	}
}