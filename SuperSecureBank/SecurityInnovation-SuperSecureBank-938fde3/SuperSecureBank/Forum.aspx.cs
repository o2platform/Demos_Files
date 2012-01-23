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
	public partial class Forum : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (null != Request.Cookies[Settings.Default.SessionCookieKey])
			{
				if (0 == UserMgmt.LookupSession(Request.Cookies[Settings.Default.SessionCookieKey].Value))
					Response.Redirect("Account/Login.aspx?ReturnUrl=/Forum.aspx");
			}
		}

        protected void PostComment_Click(object sender, EventArgs e)
        {
            try
            {
                Int64 valid = Validated.Value == "False" ? 0 : 1;
                Int64 userID = UserMgmt.LookupSession(Request.Cookies[Settings.Default.SessionCookieKey].Value);
                string insertComment = "INSERT INTO Comments VALUES ({0}, '{1}', '{2}', '{3}', {4})";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString);
                conn.Open();
                insertComment = String.Format(insertComment, userID, TitleBox.Text, BodyBox.Text, DateTime.Now, valid);
                SqlCommand command = new SqlCommand(insertComment, conn);
                command.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("Forum.aspx");
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                Response.Write(ex.ToString());
            }
        }
	}
}