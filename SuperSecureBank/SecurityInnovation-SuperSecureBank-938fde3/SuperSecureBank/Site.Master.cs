using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using SuperSecureBank.Properties;
using System.IO;

namespace SuperSecureBank
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (null == Request.Cookies[Settings.Default.SessionCookieKey])
                    LoginInfo.Text = "Please <a href=\"Account/Login.aspx\">Log in</a>";
                else if (String.IsNullOrEmpty(Request.Cookies[Settings.Default.SessionCookieKey].Value))
                    LoginInfo.Text = "Please <a href=\"Account/Login.aspx\">Log in</a>";
                else
                {
                    Int64 UserID = UserMgmt.LookupSession(Request.Cookies[Settings.Default.SessionCookieKey].Value);
                    LoginInfo.Text = "Welcome to the world of secure banking, " + UserMgmt.LookupUsername(UserID) + "!<br />" +
                                                        "<a href=\"/Logout.aspx\">Log out</a>";
                }
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                Response.Write(ex.ToString());
            }
        }
    }
}
