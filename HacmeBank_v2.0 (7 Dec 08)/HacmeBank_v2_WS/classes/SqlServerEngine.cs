using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace HacmeBank_v2_WS
{
	/// <summary>
	/// Summary description for DataFactory_SqlServer.
	/// </summary>
	public class SqlServerEngine
	{
		public SqlServerEngine()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#region General SQL Queries Methods

		public static int executeSQLCommand_onLocalSQLServer(string sqlQueryToExecute)
		{					
			Global.createSqlServerConnection();
//			SqlConnection Global.globalSqlServerConnection = new SqlConnection(ConfigurationSettings.AppSettings.Get("LocalSQLServer"));						
			string text1 = sqlQueryToExecute;
			SqlCommand command1 = new SqlCommand(text1, Global.globalSqlServerConnection);			
			Global.globalSqlServerConnection.Open();
			int executeNonQuery_Result = command1.ExecuteNonQuery();
			Global.globalSqlServerConnection.Close();
			return executeNonQuery_Result ;			
		}

		public static int executeSQLCommand(string sqlQueryToExecute)
		{	
			Global.createSqlServerConnection();
			//SqlConnection Global.globalSqlServerConnection = new SqlConnection(ConfigurationSettings.AppSettings.Get("FoundStone_Connection"));			
			string text1 = sqlQueryToExecute;
			SqlCommand command1 = new SqlCommand(text1, Global.globalSqlServerConnection);			
			Global.globalSqlServerConnection.Open();
			int executeNonQuery_Result = command1.ExecuteNonQuery();
			Global.globalSqlServerConnection.Close();
			return executeNonQuery_Result;			
		}

		public static SqlDataReader executeSQLCommand_returnSqldataReader(string sqlQueryToExecute)
		{						
			Global.createSqlServerConnection();
			//SqlConnection Global.globalSqlServerConnection = new SqlConnection(ConfigurationSettings.AppSettings.Get("FoundStone_Connection"));
			string text1 = sqlQueryToExecute;
			SqlCommand command1 = new SqlCommand(text1, Global.globalSqlServerConnection);			
			Global.globalSqlServerConnection.Open();
			SqlDataReader executeReader_Result = command1.ExecuteReader();			
			return executeReader_Result ;
		}

		public static ArrayList returnArrayListFromSQLQuery_containing_FirstRow(string sqlQuery)
		{
			ArrayList QueryResults = new ArrayList();
			SqlDataReader reader1 = executeSQLCommand_returnSqldataReader(sqlQuery);
			if (reader1.Read())
			{
				for (int i=0; i< reader1.FieldCount;i++)
				{
					QueryResults.Add(reader1[i]);
				}						
			}
			Global.globalSqlServerConnection.Close();
			return QueryResults;		
		}

		public static ArrayList returnArrayListFromSQLQuery_containing_FirstFieldFromAllRows(string sqlQuery)
		{
			ArrayList QueryResults = new ArrayList();
			SqlDataReader reader1 = executeSQLCommand_returnSqldataReader(sqlQuery);
			while (reader1.Read())
			{
				QueryResults.Add(reader1[0].ToString());					
			}			
			return QueryResults;		
		}

		public static ArrayList returnArrayListFromSQLQuery_containing_AllFieldsFromAllRows(string sqlQuery)
		{
			ArrayList QueryResults = new ArrayList();
			SqlDataReader reader1 = executeSQLCommand_returnSqldataReader(sqlQuery);
			while (reader1.Read())
			{
				ArrayList RowFieldsResults = new ArrayList();
				for (int i=0; i< reader1.FieldCount;i++)
				{
					if ("System.DBNull" == reader1[i].GetType().FullName)
					{
						RowFieldsResults.Add("[:NULL:]");
					}
					else
					{
						RowFieldsResults.Add(reader1[i]);
					}
				}			
				QueryResults.Add(RowFieldsResults);					
			}						
			return QueryResults;		
		}

		public static ArrayList returnArrayListFromSQLQuery_containing_AllFieldsFromAllRows_andResultingSchema(string sqlQuery)
		{
			ArrayList QueryResults = new ArrayList();
			SqlDataReader reader1 = executeSQLCommand_returnSqldataReader(sqlQuery);
			ArrayList rowFieldsSchemaResults = new ArrayList();
			for (int i=0; i< reader1.FieldCount;i++)
			{
				rowFieldsSchemaResults.Add(reader1.GetName(i));
			}
			QueryResults.Add(rowFieldsSchemaResults);			
			while (reader1.Read())
			{
				ArrayList rowFieldsResults = new ArrayList();
				for (int i=0; i< reader1.FieldCount;i++)
				{
					if ("System.DBNull" == reader1[i].GetType().FullName)
					{
						rowFieldsResults.Add("[:NULL:]");
					}
					else
					{
						rowFieldsResults.Add(reader1[i]);
					}
				}			
				QueryResults.Add(rowFieldsResults);					
			}						
			return QueryResults;		
		}

		public static object returnObjectFromSQLQuery_containing_FirstFieldFromFirstRow(string sqlQuery)
		{
			SqlDataReader reader1 = executeSQLCommand_returnSqldataReader(sqlQuery);			
			if (reader1.Read())					
			{
				object firstFieldFromFirstRow = (object)reader1[0];				
				return reader1[0];
			}					
			else
			{				
				return null;		
			}
		}

		#endregion
	}
}
