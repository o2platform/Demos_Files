using System;
using System.Net;
using System.IO;

namespace HacmeBank_v2_Website
{
	/// <summary>
	/// Summary description for AdminFunctions.
	/// </summary>
	public class AdminFunctions : System.Web.UI.Page
	{
		public AdminFunctions()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string fetchWebPage(string webPageToFetch)
		{
			try
			{
				Stream streamOfHttpResponse;			

				WebRequest objWebRequest = WebRequest.Create(webPageToFetch);

				WebResponse objWebResponse = objWebRequest.GetResponse();				
				streamOfHttpResponse = objWebResponse.GetResponseStream();
				StreamReader objStreamReader = new StreamReader(streamOfHttpResponse);						 
				string httpResponse = objStreamReader.ReadToEnd();
				return httpResponse;
			}
			catch (Exception Ex)
			{
				return Ex.Message;
			}
		}
	}
}
