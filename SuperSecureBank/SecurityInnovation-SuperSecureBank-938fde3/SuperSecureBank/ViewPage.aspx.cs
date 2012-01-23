using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;

namespace SuperSecureBank
{
    public partial class ViewPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Request["Page"]))
                {
                    string RealPath = Request.PhysicalApplicationPath + Request["Page"];
                    if (!File.Exists(RealPath))
                        Response.Redirect("404.aspx?AttemptedUrl=" + Request["Page"]);
                    else
                        content.Text = ProcessContent(File.ReadAllLines(RealPath));
                }
                else
                    Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                content.Text = ex.ToString();
            }
        }

        private string ProcessContent(string[] Lines)
        {
            string returnval = "";
            try
            {
                string newPage = "<h1>{0}</h1><div><a href=\"{1}\">{1}</a></div><div>{2}</div>";

                string title = Lines[0];
                string link = Lines[1];

                StringBuilder sb = new StringBuilder();
                for (Int64 i = 2; i < Lines.Length; i++)
                {
                    sb.AppendLine(Lines[i]);
                }
                returnval = string.Format(newPage, title, link, sb.ToString());
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                returnval = ex.ToString();
            }
            return returnval;
        }

    }
}