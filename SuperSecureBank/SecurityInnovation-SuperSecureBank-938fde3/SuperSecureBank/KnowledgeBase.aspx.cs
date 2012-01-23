using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SuperSecureBank
{
    public partial class KnowledgeBase : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //foreach (string f in Directory.EnumerateFiles(Server.MapPath("Content")))
                foreach (string f in Directory.GetFiles(Server.MapPath("Content")))
                {
                    if(Path.GetExtension(f) == ".dat")
                        FileList.Text += string.Format("<li><a href=\"ViewPage.aspx?Page=Content\\{0}\">{1}</a></li>", Path.GetFileName(f), GetTitle(f));
                }
            }
            catch (Exception ex)
            {
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);
                Response.Write(ex.ToString());
            }
        }

        private string GetTitle(string f)
        {
            string[] Lines = File.ReadAllLines(f);
            return Lines[0];
        }
    }
}