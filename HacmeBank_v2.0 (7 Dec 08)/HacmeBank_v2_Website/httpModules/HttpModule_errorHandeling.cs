using System;
using System.Web;
using System.Threading;

namespace HacmeBank_v2_Website.httpModules
{
	/// <summary>
	/// Summary description for HttpModule_errorHandeling.
	/// </summary>
	public class HttpModule_errorHandeling : IHttpModule
	{
		public HttpModule_errorHandeling()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public void Init(HttpApplication application)
		{
			//application.EndRequest += new EventHandler(globalErrorManagement);						
			application.Error += new EventHandler(globalErrorManagement);						
		}

		public void Dispose()
		{
		}
		
		private void globalErrorManagement(object sender, EventArgs e)
		{	
			Exception lastError =  HttpContext.Current.Server.GetLastError();
			Exception innerException = lastError.InnerException;
			
			if (innerException.Message.IndexOf("Failed to map the path") > -1)		
			{				

				HacmeBank_v2_Website.ascxThreadingIssue.closeOpenHacmeBankHandles();
			
				HttpContext.Current.Response.Flush();
				int count=10;
				HttpContext.Current.Response.Write("Redirecting to HomePage in: ");
				while (count>0)
				{
					HttpContext.Current.Response.Write(count.ToString() +  " ");
					HttpContext.Current.Response.Flush();
					count--;
					Thread.Sleep(500);
				}
			
				string redirectTo = "http://"+ HttpContext.Current.Request.Url.Host+ "/"+  HttpContext.Current.Request.ApplicationPath;
				HttpContext.Current.Response.Write("<script> document.location='"  + redirectTo + "';</script>;");
				HttpContext.Current.Response.Flush();			
				HttpContext.Current.Response.End();
			}
		}
	}
}

