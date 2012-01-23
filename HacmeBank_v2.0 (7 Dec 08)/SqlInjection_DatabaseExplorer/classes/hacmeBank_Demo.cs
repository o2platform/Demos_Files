using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Web;

namespace SqlInjection_DatabaseExplorer
{
    public class hacmeBank_Demo
    {

        

        /*
        public static void loadRawHttpTestData(TextBox tbRawHttp_Request, TextBox tbRawHttp_PostData)
        {
            // HacmeBank login request
            tbRawHttp_Request.Text = "POST /HacmeBank_v2_Website/aspx/login.aspx HTTP/1.0" + Environment.NewLine +
                                     "Accept: image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, * /*" + Environment.NewLine +
                                     "Referer: http://" + ConfigurationSettings.AppSettings["IP"] + "/HacmeBank_v2_Website/aspx/login.aspx" + Environment.NewLine +
                                     "Accept-Language: en-us" + Environment.NewLine +
                                     "Content-Type: application/x-www-form-urlencoded" + Environment.NewLine +
                                     "Accept-Encoding: gzip, deflate" + Environment.NewLine +
                                     "User-Agent: Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.1.4322)" + Environment.NewLine +
                                     "Proxy-Connection: Keep-Alive" + Environment.NewLine +
                                     "Pragma: no-cache" + Environment.NewLine +
                                     "Host: " + ConfigurationSettings.AppSettings["IP"] + Environment.NewLine +
                                     "Content-Length: 106" + Environment.NewLine;
            string strViewState = executePayload.getViewStateOfLocalServer();
            if ("" == strViewState)
                MessageBox.Show(@"Error: Could not get Viewstate for this server (make sure the hacmebank website is located at http://" + ConfigurationSettings.AppSettings["IP"] + ":" + ConfigurationSettings.AppSettings["Port"] + "/HacmeBank_v2_Website/aspx/login.aspx ");
            // This is a valid user account in HacmeBank
            tbRawHttp_PostData.Text = "__VIEWSTATE=" + strViewState + "&txtUserName=jv&txtPassword=jv789&btnSubmit=Submit&__EVENTVALIDATION=%2FwEWBAKt9uW%2FDQKl1bKzCQK1qbSRCwLCi9reA%2F%2BgC4WsK%2BZY7DIbgqWC5CsMd6ts";
        }
         */
    }
}
