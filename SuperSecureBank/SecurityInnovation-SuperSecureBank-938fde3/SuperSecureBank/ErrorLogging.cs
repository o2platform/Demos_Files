using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;

namespace SuperSecureBank
{
	static public class ErrorLogging
	{
		static public void AddException(string errorText, Exception ex)
		{
			string insertError = @"INSERT INTO ErrorLog values ('{0}', '{1}', '{2}')";
			SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString);
			conn.Open();
			insertError = String.Format(insertError, DateTime.Now, cleanForSQL(errorText), BuildExceptionText(ex));
			SqlCommand command = new SqlCommand(insertError, conn);
			command.ExecuteNonQuery();
			conn.Close();
		}

		static public string cleanForSQL(string foo)
		{
			if (null != foo)
			{
				return foo.Replace("'", "''");
			}
			else
				return "";
		}



        static public void AddEntry(string errorText, string exception)
        {
            try
            {
                string insertError = @"INSERT INTO ErrorLog values ('{0}', '{1}', '{2}')";
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ssbcon"].ConnectionString);
                conn.Open();
                insertError = String.Format(insertError, DateTime.Now, errorText, exception);
                SqlCommand command = new SqlCommand(insertError, conn);
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch
            {
                throw;
            }
        }


		private static string BuildExceptionText(Exception ex)
		{
			string exceptionText = @"<h3>{0}</h3>More Info: {1}<br/><h4>Stack</h4><br/><pre><code>{2}</code></pre>";

			return string.Format(exceptionText, cleanForSQL(ex.Message), cleanForSQL(ex.HelpLink), cleanForSQL(ex.StackTrace.Replace("\r\n", "<br>").Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;")));
		}
	}
}