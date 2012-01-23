using System;
using System.Web;
using System.Web.UI;
using System.Configuration;
using System.Collections;
using System.Xml;
using System.IO;

namespace Foundstone
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// <remarks>
	/// You have to kill w3wp.exe process to see any changes made in this process
	/// </remarks>
	/// 

	public class FS_HttpModule : IHttpModule
	{		
		private string FS_HttpModule_XMLRulesDatabase;
		private string FS_HttpModule_Validator_FormMappings;
		private string FS_HttpModule_Validator_Rules;	
		private Hashtable htViewStateData = new Hashtable();

		public FS_HttpModule()
		{
			//
			// TODO: Add constructor logic here
			//				
		}


		public void Init(HttpApplication application) 
		{	
			loadXmlValidatorRules();				
													
			//application.AcquireRequestState +=new EventHandler(handleViewState);	
			application.AcquireRequestState +=new EventHandler(ViewStateFilter.handleViewState);	
			application.PreRequestHandlerExecute  += (new EventHandler(ProcessRequest.ProcessRequest_Handler));									
			

		}
          
		public void Dispose() 
		{
		}

		private void handleViewState(object sender, EventArgs e)
		{
			HttpApplication currentHttpApplication = (HttpApplication)sender; 
			// Set output filter
			currentHttpApplication.Response.Filter = new ViewStateFilter(currentHttpApplication.Response.Filter,htViewStateData);
			// if there is a ViewState replace the current GUID with it
			if (null != currentHttpApplication.Request.Form["__VIEWSTATE"])//(htViewStateData.Count>0)
			{
				// make the Form object edititable (by default it is not)
				new ValidatorNET_GAC_Assembly().makeTheRequestFormDataEditable();				
				string strViewStateGUID = currentHttpApplication.Request.Form["__VIEWSTATE"];
				// make the change
				currentHttpApplication.Request.Form["__VIEWSTATE"] =  (string)htViewStateData[strViewStateGUID];
				// remove item from HashTable
				htViewStateData.Remove(strViewStateGUID);
			}
		}
		

		private void loadXmlValidatorRules()
		{
			FS_HttpModule_XMLRulesDatabase = ConfigurationSettings.AppSettings["FS_HttpModule_XMLRulesDatabase"]	;
			FS_HttpModule_Validator_FormMappings = ConfigurationSettings.AppSettings["FS_HttpModule_Validator_FormMappings"];
			FS_HttpModule_Validator_Rules = ConfigurationSettings.AppSettings["FS_HttpModule_Validator_Rules"];

			string resolvedAddressOf_Validator_FormMappings	= AppDomain.CurrentDomain.BaseDirectory + "/" +  FS_HttpModule_XMLRulesDatabase + "/" + FS_HttpModule_Validator_FormMappings;
			string resolvedAddressOf_Validator_Rules = AppDomain.CurrentDomain.BaseDirectory + "/" + FS_HttpModule_XMLRulesDatabase + "/" + FS_HttpModule_Validator_Rules;			
					
			ProcessRequest.xmlFile_Validator_FormMappings.Load(resolvedAddressOf_Validator_FormMappings);			
			ProcessRequest.xmlFile_Validator_Rules.Load(resolvedAddressOf_Validator_Rules);

			loadPagesToProcessList();
			convertValidatorFormMappingsXML_into_Hashtable();
			convertValidatorRulesMappingsXML_into_Hashtable();
		}

		private void loadPagesToProcessList()
		{				
			foreach (XmlNode objXmlNode in ProcessRequest.xmlFile_Validator_FormMappings.DocumentElement.ChildNodes[0].ChildNodes)
			{  
				string pageFormName = objXmlNode.Attributes["FormName"].InnerText;				
				ProcessRequest.pagesToProcess.Add(pageFormName);
			}		
		}	  

		private void convertValidatorFormMappingsXML_into_Hashtable()
		{				
			foreach (XmlNode objXmlNode in ProcessRequest.xmlFile_Validator_FormMappings.DocumentElement.ChildNodes[0].ChildNodes)
			{  			
				try
				{
					string pageFormName = objXmlNode.Attributes["FormName"].InnerText;									
					ProcessRequest.hashtableWithValidator_FormMappings.Add(pageFormName,objXmlNode);				
				}
				catch
				{
					// an exception occours here is there is a duplication in the pageFormName (since in a hash table we cannot have two identical keys)
				}
			}				
		}	
  
		private void convertValidatorRulesMappingsXML_into_Hashtable()
		{								
			foreach (XmlNode objXmlNode in ProcessRequest.xmlFile_Validator_Rules.DocumentElement.ChildNodes)
			{  	
				string ruleName = objXmlNode.Attributes["name"].InnerText;				
				ProcessRequest.hashtableWithValidator_FormRules.Add(ruleName,objXmlNode);				
			}		 
		}


	}   
}
