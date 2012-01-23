using System;
using System.Web;

namespace Foundstone
{
	/// <summary>
	/// Summary description for LogRequestData.
	/// </summary>
	public class LogRequestData
	{
		private string messageToDisplay;		

		public LogRequestData()
		{					
			messageToDisplay = "<hr>";
			messageToDisplay += "<font face='Arial'><b><font size='2'>Foundstone HttpModule Asp.Net (using SiteValidator's XML Rules)</Font></b><br>";
			messageToDisplay += "<font size='1'>";					
		}
		
		public void addEntry(string entryToAdd)
		{
			messageToDisplay += "<br> - " + entryToAdd;
		}

		public void outputMessage()
		{	
			messageToDisplay += "</font>";
			messageToDisplay += "</font>";
			messageToDisplay += "<hr>";
			HttpContext.Current.Response.Write(messageToDisplay);
		}


	}
}
