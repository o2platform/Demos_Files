using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Web;
using System.Configuration;

namespace SqlInjection_DatabaseExplorer
{
    public class stringFilters
    {        

        public static string extractErrorMessageFromHttpContent(string strRequestHttpContent)
        {
         //   return extractString(strRequestHttpContent,
         //                        "<span id=\"lblResult\" class=\"errorMessage\" style=\"display:inline-block;width:60px;\">",
         //                        "</span>");
         
			return extractString(strRequestHttpContent,
                ConfigurationSettings.AppSettings["ErrorMessageFilter_Before"], 
                ConfigurationSettings.AppSettings["ErrorMessageFilter_After"]);		
        }
        public static string extractString(string strWorkString, string strSearchString_Begin, string strSearchString_End)
        {
            int iPosOfStrSearchString_Begin = strWorkString.IndexOf(strSearchString_Begin);
            if (iPosOfStrSearchString_Begin > -1)
            {
                iPosOfStrSearchString_Begin += strSearchString_Begin.Length;
                string strTempSubString = strWorkString.Substring(iPosOfStrSearchString_Begin);
                int iPosOfStrSearchString_End = strTempSubString.IndexOf(strSearchString_End);
                if (iPosOfStrSearchString_End > -1)
                    return strWorkString.Substring(iPosOfStrSearchString_Begin, iPosOfStrSearchString_End);
            }
            return "";
        }
    }
}
