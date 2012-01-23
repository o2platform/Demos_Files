using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.IO;

namespace SuperSecureBank
{
	public partial class DoTransfer : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				AccountMgmt.Transfer(Convert.ToInt64(Request.Params["FromAccount"]),
										Convert.ToInt64(Request.Params["ToAccount"]),
										Convert.ToInt64(Request.Params["Amount"]));
				Response.Redirect("ActionDone.aspx?Title=Transfer Success&Text=Your transfer was successful. If you moved funds within SuperSecure Bank accounts your funds are immediately available.");
			}
			catch (ThreadAbortException tae)
			{
				//nothing
			}
			catch (Exception ex)
			{
                ErrorLogging.AddException("Error in " + Path.GetFileName(Request.PhysicalPath), ex);

				Response.Redirect("ActionDone.aspx?Title=Transfer Failed&Text=We're sorry, but there was an error transferring your funds. Please try again at a later date or call support at: 1-800-555-1212");
			}
		}
	}
}