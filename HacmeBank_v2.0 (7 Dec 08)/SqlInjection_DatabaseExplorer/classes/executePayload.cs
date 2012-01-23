using System;
using System.Threading;
using System.Windows.Forms;
using System.Configuration;
using System.Net;
using System.IO;
using System.Text;

namespace SqlInjection_DatabaseExplorer
{
	/// <summary>
	/// Summary description for executePayload.
	/// </summary>
	public class executePayload
	{
		private static bool bRawHttpCancelRequest=false;
		public executePayload()
		{
			//
			// TODO: Add constructor logic here
			//
		}
        /*
		public static string getNormalizedPayloadErrorMessage(string strPayload)
		{
			//string strRequestWithPayload = GenerateExploitHttpRequest(strPayload);
            string strRequestHttpContent = "";//executeSyncRequest(ConfigurationSettings.AppSettings["IP"], Int32.Parse(ConfigurationSettings.AppSettings["Port"]), strRequestWithPayload, ref bRawHttpCancelRequest);						
			string strErrorMessage = extractErrorMessageFromHttpContent(strRequestHttpContent);			
			return strErrorMessage;
		}

		public static string extractErrorMessageFromHttpContent(string strRequestHttpContent)
		{
			return extractString(strRequestHttpContent,
                ConfigurationSettings.AppSettings["ErrorMessageFilter_Before"], 
                ConfigurationSettings.AppSettings["ErrorMessageFilter_After"]);
		}
		public static string extractString(string strWorkString,string strSearchString_Begin,string strSearchString_End)
		{			 			 
			int iPosOfStrSearchString_Begin = strWorkString.IndexOf(strSearchString_Begin);
			if (iPosOfStrSearchString_Begin > -1)
			{
				iPosOfStrSearchString_Begin+= strSearchString_Begin.Length;
				string strTempSubString = strWorkString.Substring(iPosOfStrSearchString_Begin);
				int iPosOfStrSearchString_End = strTempSubString.IndexOf(strSearchString_End);
				if (iPosOfStrSearchString_End > -1)
					return strWorkString.Substring(iPosOfStrSearchString_Begin,iPosOfStrSearchString_End);
			}			
			return "";
		}
		
		public static string getViewStateOfLocalServer()
		{
//			string strSimpleGetRequest =	"GET /HacmeBank_v2_Website/aspx/login.aspx HTTP/1.0" + 
//				Environment.NewLine + 
//				"Host: " + ConfigurationSettings.AppSettings["IP"] + 
//				Environment.NewLine + Environment.NewLine;            
//			string strRequestHttpContent = executeSyncRequest(ConfigurationSettings.AppSettings["IP"],Int32.Parse(ConfigurationSettings.AppSettings["Port"]),strSimpleGetRequest,ref bRawHttpCancelRequest);						
            string strRequestHttpContent  = getWebPage(String.Format("http://"+ ConfigurationSettings.AppSettings["IP"] + ":"+ ConfigurationSettings.AppSettings["Port"] +"/HacmeBank_v2_Website/aspx/login.aspx"));

     


			string strViewState = extractString(strRequestHttpContent,"id=\"__VIEWSTATE\" value=\"","\" />");
            
			return strViewState;
		}
        */
        /*
		public static string executeSyncRequest(string strTargetIP, int iTargetPort, string strRequestToSend,ref bool bCancelRequest)
		{
			sendReceivedRequestObject srroRequest = new sendReceivedRequestObject(strTargetIP,iTargetPort,strRequestToSend);
			srroRequest.startSyncRequest();

			while (!srroRequest.bRequestCompleted)
			{
//				Application.DoEvents();
				Thread.Sleep(250);
				if (bCancelRequest)
					return "Request Canceled";
			}
			return srroRequest.strReceivedData;
		}*/


        
	}
}
