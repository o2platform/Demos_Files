using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SuperSecureBank.Properties;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace SuperSecureBank
{
	public partial class ExecuteSQL : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (null != Request.Cookies[Settings.Default.SessionCookieKey])
				{
					Int64 userID = UserMgmt.LookupSession(Request.Cookies[Settings.Default.SessionCookieKey].Value);
					if (0 == userID || "admin" != UserMgmt.LookupUsername(userID).ToLower())
						Response.Redirect("404.aspx?AttemptedUrl=/ApplyForAccount.aspx");
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
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString))
                {
                    SqlCommand command = new SqlCommand(SQLCommand.Text, conn);
                    conn.Open();
                    if (!SQLCommand.Text.ToLower().Contains("select"))
                    {
                        output.Visible = true;
                        output.Text = command.ExecuteNonQuery() + " row(s) affected";
                        outputGrid.Visible = false;
                    }
                    else
                    {
                        outputGrid.Visible = true;
                        outputGrid.DataSource = command.ExecuteReader();
                        outputGrid.DataBind();
                        output.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                output.Text = ex.ToString();
            }
		}
	}
}