using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Reflection;
using System.IO;
using System.Configuration;
using System.Xml;
//using System.Threading;
//using System.Web.Hosting;
// using System.Runtime.Remoting;



namespace Foundstone
{
	/// <summary>
	/// Summary description for ProcessRequest.
	/// </summary>
	/// 

	public class ProcessRequest
	{
		static public XmlDocument xmlFile_Validator_FormMappings = new XmlDocument();
		static public Hashtable hashtableWithValidator_FormMappings = new Hashtable();
		static public Hashtable hashtableWithValidator_FormRules = new Hashtable();
		static public XmlDocument xmlFile_Validator_Rules = new XmlDocument();
		static public ArrayList pagesToProcess = new ArrayList();

		static private Foundstone.ValidatorNET_GAC_Assembly objValidatorNET_GAC_Assembly = new ValidatorNET_GAC_Assembly();
		
		public ProcessRequest()
		{
		}

		//		static public void ProcessRequest_Debug(object sender, EventArgs e)
		//		{
		//			///object send= sender;						
		//			
		//			HttpApplication ht = (HttpApplication)sender;
		//			string pageType = ht.Request.FilePath;
		//			ht.Request.RawUrl
		//			Console.WriteLine(pageType);
		//		}

		static public void ProcessRequest_Handler(object sender, EventArgs e)
		{			
			HttpApplication currentHttpApplication = (HttpApplication)sender; 						
			LogRequestData objLogRequestData = new LogRequestData();
			HttpRequest currentHttpRequest = currentHttpApplication.Request;					
			RequestToValidate objRequestToValidate = new RequestToValidate();
			objRequestToValidate.HttpRequestToAnalyse = currentHttpRequest;			
			/// handle Output Of Log Request Data			
			switch (objRequestToValidate.HttpRequestToAnalyse.QueryString["mode"])
			{
				case "debug":
				{
					currentHttpApplication.Session["ShowOutputMessage"] = "yes";
					break;
				}
				case "normal":
				{
					currentHttpApplication.Session["ShowOutputMessage"] = "no";
					break;
				}
				case "disable":
				{
					currentHttpApplication.Session["DisableValidator.Net"] = "yes";
					break;
				}
				case "enable":
				{
					currentHttpApplication.Session["DisableValidator.Net"] = "no";
					break;
				}
			}								
			if ("yes" != (string)currentHttpApplication.Session["DisableValidator.Net"])
			{									
				
		
				objLogRequestData.addEntry("Starting ProcessRequest_Handler Processing Page: " + objRequestToValidate.HttpRequestToAnalyse.Path);
				objRequestToValidate.pageClassName= resolvePageClassName((string)currentHttpRequest.QueryString["Function"]);		
				objLogRequestData.addEntry("Page's class identified has: <b>" + objRequestToValidate.pageClassName+"</b>");			

				// NOTE1: The current version of HacmeBank needs to run with FullTrust (the following two comments refer to HacmeBank version 1
				// if you want to test the GAC usage, register the ValidatorNET_GAC_Assembly.dll control in the GAC and delete it from the bin directory
				//	Note2: this call will not work if the website is NOT in Full Trust
				//	if (makeTheRequestFormDataEditable())			
				//	NOte3: this one will work because the code will be executed with Full Trust due to it's GAC location)				
				if (objValidatorNET_GAC_Assembly.makeTheRequestFormDataEditable())
				{	
					objValidatorNET_GAC_Assembly.makeTheRequestQueryStringDataEditable();
					objLogRequestData.addEntry("the private method HttpContext.Current.Request.Form.MakeReadWrite() was successfully invoked (the same for the QueryString)");					
				}
				else
				{
					objLogRequestData.addEntry("ERROR!!: makeTheRequestFormDataEditable failed");
				}		
				if (objRequestToValidate.validateCurrentPage(pagesToProcess))
				{
					objLogRequestData.addEntry((string)hashtableWithValidator_FormMappings[objRequestToValidate.pageClassName].ToString());
					objLogRequestData.addEntry("Validating Current Page");
					if (objRequestToValidate.pageHasItemsToValidate())
					{
						objLogRequestData.addEntry("Page has Items to Validated");					
								
						ArrayList listOfRulesProcessed = objRequestToValidate.validateAndHandleMaliciousInput((XmlElement)hashtableWithValidator_FormMappings[objRequestToValidate.pageClassName],hashtableWithValidator_FormRules);
						if (0 == listOfRulesProcessed.Count)
						{
							// Hardcoded rule to check for SQL Injections and XssAttacks
							objRequestToValidate.protectAndMitigateSQLInjections();
							objRequestToValidate.protectAndMitigateXSSAttacks();
						}
						else
						{
							foreach (string item in listOfRulesProcessed)
							{
								objLogRequestData.addEntry(item);
							}
						}
					}
					else
					{
						objLogRequestData.addEntry("Nothing to Validate");
					}
				}
				else
				{
					// Hardcoded rule to check for SQL Injections and XSS attacks
					objRequestToValidate.protectAndMitigateSQLInjections();
					objRequestToValidate.protectAndMitigateXSSAttacks();
					objLogRequestData.addEntry("Not Validating this page");
				}

			}
			else
			{
				objLogRequestData.addEntry("Validator.Net is Disabled");
			}
			if ((string)currentHttpApplication.Session["ShowOutputMessage"]== "yes")
				objLogRequestData.outputMessage();
		}


		// This funcionality was moved to the GAC assembly
		/*
				// invoke the private method in order to make the Request.Form writable
				static internal bool makeTheRequestFormDataEditable()
				{		
					try 
					{
						object objectToReflect = HttpContext.Current.Request.Form;	
						string stringObjectType = "MakeReadWrite";
						MethodInfo objTempMethodType = objectToReflect.GetType().GetMethod(
							stringObjectType,BindingFlags.Public | BindingFlags.NonPublic | 
							BindingFlags.Instance, null,CallingConventions.Any,new Type[0] {},null); 					
						object invokeResult = objTempMethodType.Invoke(
							objectToReflect,BindingFlags.Public | BindingFlags.NonPublic | 
							BindingFlags.Instance | BindingFlags.InvokeMethod,null,new object[0] {} ,null);								
						return true;
					}	
					catch
					{	
						return false;
					}			
				}
		*/

		// there must be be a better way to do this!
		// This code is very HacmeBank Specific! 
		static internal string resolvePageClassName(string strCurrentValueOfQuerystingFunctionVariable)
		{			
			// test to see if we are in a page that contains a pointer to an ascx function
			if (null !=strCurrentValueOfQuerystingFunctionVariable)
			{
				return strCurrentValueOfQuerystingFunctionVariable;
			}
			// if not resolve it by looking at the value of this page's <%@ Page Inherits 

			string resolvedPageClassName = "";
			string localPathToFile = HttpContext.Current.Request.PhysicalPath;			
			//FileStream objFileStream = new FileStream(localPathToFile,FileMode.Open);
			StreamReader objStreamReader = new StreamReader(localPathToFile);
			string fileContents = objStreamReader.ReadToEnd();
			try
			{
				string ASPNETpageDirective = fileContents.Substring(fileContents.IndexOf("<%@ Page"));
				ASPNETpageDirective = ASPNETpageDirective.Substring(0,ASPNETpageDirective.IndexOf("%>"));
				int InheritsPosition = ASPNETpageDirective.IndexOf("Inherits");
				if (-1 < InheritsPosition)
				{
					int firstQuotePos =	ASPNETpageDirective.IndexOf("\"",ASPNETpageDirective.IndexOf("Inherits"));
					int secondQuotePos = ASPNETpageDirective.IndexOf("\"",firstQuotePos+1);										
					string completePageClassName = ASPNETpageDirective.Substring(firstQuotePos +1 ,secondQuotePos-firstQuotePos-1);					
					resolvedPageClassName = completePageClassName.Substring(completePageClassName.LastIndexOf(".")+1, completePageClassName.Length-completePageClassName.LastIndexOf(".")-1);
				}								
			}
			catch {}						
			return resolvedPageClassName;
		}			

	}
}