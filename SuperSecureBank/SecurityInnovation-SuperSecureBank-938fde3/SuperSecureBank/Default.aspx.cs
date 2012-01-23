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
	public partial class _Default : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            try
            {
                if (null != Request.Cookies[Settings.Default.SessionCookieKey])
                {
                    if (0 != UserMgmt.LookupSession(Request.Cookies[Settings.Default.SessionCookieKey].Value))
                    {
                        Anon.Visible = false;
                        Authen.Visible = true;
                    }
                    else
                    {
                        Anon.Visible = true;
                        Authen.Visible = false;
                    }
                }
                else
                {
                    Anon.Visible = true;
                    Authen.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
            }
		}
	}
}
