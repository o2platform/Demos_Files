using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SuperSecureBank
{
	public partial class TransferSuccess : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            try
            {
                TitleText.Text = Request.Params["Title"];
                BodyText.Text = Request.Params["Text"];

                if (string.IsNullOrEmpty(TitleText.Text) && string.IsNullOrEmpty(BodyText.Text))        
                    Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                BodyText.Text = ex.ToString();
            }
		}
	}
}