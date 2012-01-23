using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace SuperSecureBank
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ResetComments_Click(object sender, EventArgs e)
        {
            try
            {
                string deleteSessions = @"DELETE FROM Comments";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString);
                conn.Open();
                SqlCommand command = new SqlCommand(deleteSessions, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
			catch (Exception ex)
			{
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
				Response.Write( ex.ToString());
			}
            
        }

        protected void ResetSesions_Click(object sender, EventArgs e)
        {
            try{
            string deleteSessions = @"DELETE FROM sessions";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString);
            conn.Open();
            SqlCommand command = new SqlCommand(deleteSessions, conn);
            command.ExecuteNonQuery();
            conn.Close();
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                Response.Write(ex.ToString());
            }
        }
    }
}