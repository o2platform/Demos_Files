using System;
using System.Web;

namespace HacmeBank_v2_Website.httpModules
{
	/// <summary>
	/// Summary description for HttpModule_onlyAllowLocalAccess.
	/// </summary>
	public class HttpModule_onlyAllowLocalAccess : IHttpModule
	{
		public HttpModule_onlyAllowLocalAccess()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void Init(HttpApplication application)
		{								
			application.BeginRequest += new EventHandler(onlyAllowAccessFromLocalHost);						
		}

		public void Dispose()
		{
		}
		
		private void onlyAllowAccessFromLocalHost(object sender, EventArgs e)
		{			
			if (HttpContext.Current.Request.UserHostAddress != "127.0.0.1")
			{
				HttpContext.Current.Response.Write("<h2><center>This version of HacmeBank is designed to only Access from the localhost (i.e. 127.0.0.1)<h2>");
				HttpContext.Current.Response.Write("<h3> Your current IP is:  "+  HttpContext.Current.Request.UserHostAddress + "</center></h3>");				
				HttpContext.Current.Response.End();
			}

			
		}
	}
}
