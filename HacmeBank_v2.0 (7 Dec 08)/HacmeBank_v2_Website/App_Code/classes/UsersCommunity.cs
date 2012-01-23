using System;
using System.Configuration;
using localhost;


namespace HacmeBank_v2_Website
{
	/// <summary>
	/// Summary description for UsersCommunity.
	/// </summary>
	public class UsersCommunity
	{
		public static string ipAddressOfWebService = ConfigurationSettings.AppSettings.Get("ipAddressOfWebService");
        private static WS_UsersCommunity objWS_UsersCommunity = new WS_UsersCommunity();
		
			
		public UsersCommunity()
		{
		}

		public dataClasses.postedMessage[] WS_GetPostedMessages(string sessionID)
		{
			object[] allPostedMessages = objWS_UsersCommunity.GetPostedMessages(sessionID);
			dataClasses.postedMessage[] postedMessages = new HacmeBank_v2_Website.dataClasses.postedMessage[allPostedMessages.Length];
			for (int i=0 ; i< allPostedMessages.Length;i++)
			{
				object[] postedMessage = (object[])allPostedMessages[i];
				postedMessages[i] = new dataClasses.postedMessage();
				postedMessages[i].messageID =  (decimal)postedMessage[0];
				postedMessages[i].userID =  (decimal)postedMessage[1];
				postedMessages[i].messageDate =  (DateTime)postedMessage[2];
				postedMessages[i].messageSubject =  (string)postedMessage[3];
				postedMessages[i].messageText =  (string)postedMessage[4];
			}
			return postedMessages;
		}

		public void WS_PostMessage(string sessionID,string userID,string messageSubject,string messageText)
		{
			objWS_UsersCommunity.PostMessage(sessionID,userID,messageSubject,messageText);
		}

		public int WS_DeleteMessage(string sessionID,string messageID)
		{
			return objWS_UsersCommunity.DeleteMessage(sessionID,messageID);
		}
	}
}
