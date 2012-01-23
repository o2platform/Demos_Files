using System;
using System.Web;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Xml;

namespace Foundstone
{
	/// <summary>
	/// Summary description for RequestToValidate.
	/// </summary>
	public class RequestToValidate
	{		
		public HttpRequest HttpRequestToAnalyse;		
		public string pageClassName;		
		public RequestToValidate()
		{
		}

		private BindingFlags ___requiredBindingFlagsToAccessPrivateMembers()
		{
			BindingFlags objTempBindingFlags = new BindingFlags();
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Public;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.NonPublic;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Instance;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Static;
			return objTempBindingFlags;
		}
	


		internal bool validateCurrentPage(ArrayList pagesToProcess)
		{			
			if (-1 == pagesToProcess.IndexOf(pageClassName))
			{
				return false;
			}
			else
			{	
				return true;
			}
		}
	
		internal bool pageHasItemsToValidate()
		{
			if ((HttpRequestToAnalyse.Form.Count>0) || (HttpRequestToAnalyse.QueryString.Count>0))
			{
				return true;
			}
			return false;
		}

		internal ArrayList validateAndHandleMaliciousInput(XmlElement objXmlElementWithFormMappings,Hashtable hashtableWithValidator_FormRules)
		{				
			ArrayList listOfRulesProcessed = new ArrayList();			
			try 
			{				
				foreach (XmlNode objXmlControls in objXmlElementWithFormMappings)
				{
					if (objXmlControls.ChildNodes.Count >0 )	//i.e. there are rules in the Form's Control
					{		
						string fieldToAnalyse = objXmlControls.Attributes["ControlId"].InnerText;						
						if (null ==  HttpRequestToAnalyse.Form[fieldToAnalyse])		// this occours when we are dealing with a asp.net control (which for example looks like this _ctl3:txtPassword)						
							foreach(string sFormKey in  HttpRequestToAnalyse.Form.AllKeys)
							{								
								string[] sSplittedFormItem = sFormKey.Split(':');
								if (sSplittedFormItem.Length>1)								
									if (sSplittedFormItem[1] == fieldToAnalyse)
									{
										fieldToAnalyse = sFormKey;
										break;
									}										
							}
						string dataToAnalyse = HttpRequestToAnalyse.Form[fieldToAnalyse];											
						
						string FormsProcessed = "Applying to Field <b>'"+ fieldToAnalyse + "'</b> (containing '"+dataToAnalyse+"') :";

						foreach (XmlNode objXmlRules in objXmlControls)
						{
							string validatorRuleName = objXmlRules.Attributes["name"].InnerText;
							string RulesProcessed = " the Rule <b>'" + validatorRuleName + "'</b> which contains the classes: ";	
							XmlElement objRuleInformation = (XmlElement)hashtableWithValidator_FormRules[validatorRuleName];
							foreach (XmlNode objXmlRulesClass in objRuleInformation)
							{
								string validatorClassName = objXmlRulesClass.Attributes["name"].InnerText;											
								RulesProcessed += " <b>'" +validatorClassName + "</b>"; 
								switch (validatorClassName)
								{
									case "RequiredFieldValidator":
									{
										if (ValidatorFunctions.RuleClass_RequiredFieldValidator(dataToAnalyse))
										{
											RulesProcessed += htmlGreen(" [OK] , ");	
										}
										else
										{											
											RulesProcessed += htmlRed(" [FAILED] , ");	
										}
										break;
									}
									case "RegExValidator":
									{
									
										string regularExpersionString = objXmlRulesClass.Attributes["ValidationExpression"].InnerText;									
										if (ValidatorFunctions.RuleClass_RegExValidator(dataToAnalyse,regularExpersionString))
										{
											RulesProcessed += htmlGreen(" [OK] , ");	
										}
										else
										{
											HttpRequestToAnalyse.Form[fieldToAnalyse] = "";   // this cleans the value of the offending form field
											RulesProcessed += htmlRed(" [FAILED] , ");	
										}								
										break;
									}

									case "RangeValidator":
									{									
										if (ValidatorFunctions.RuleClass_RangeValidator(dataToAnalyse))
										{
											RulesProcessed += htmlOrange(" [Not Implemented yet] , ");	
										}
										else
										{
											HttpRequestToAnalyse.Form[fieldToAnalyse] = "";   // this cleans the value of the offending form field
											RulesProcessed += htmlRed(" [FAILED] , ");	
										}							
										break;
									}
									case "CustomValidator":
									{
										if (ValidatorFunctions.RuleClass_CustomValidator(dataToAnalyse))
										{
											RulesProcessed += htmlOrange("[Not Implemented yet] , ");	
										}
										else
										{
											HttpRequestToAnalyse.Form[fieldToAnalyse] = "";   // this cleans the value of the offending form field
											RulesProcessed += htmlRed(" [FAILED] , ");	
										}								
										break;
									}
									case "ValidationSummary":
									{
										if (ValidatorFunctions.RuleClass_ValidationSummary(dataToAnalyse))
										{
											RulesProcessed += htmlOrange(" [Not Implemented yet] , ");	
										}
										else
										{		
											HttpRequestToAnalyse.Form[fieldToAnalyse] = "";   // this cleans the value of the offending form field
											RulesProcessed += htmlRed(" [FAILED] , ");	
										}								
										break;
									}								
								}															
							}	
//							// This final rule is Hard coded (i.e. will always be executed (as long as there is 1 rule))
//							if (ValidatorFunctions.RuleClass_SQLInjectionDetector(dataToAnalyse))
//							{
//								// don't show message when no attack is detected
//								// RulesProcessed += "SQLInjectionDetector" + htmlGreen(" [OK] , ");	
//							}
//							else
//							{
//								HttpRequestToAnalyse.Form[fieldToAnalyse] = HttpRequestToAnalyse.Form[fieldToAnalyse].Replace("'","");
//								RulesProcessed += "<b>SQLInjectionDetector</b> " + htmlRed(" [FAILED: SQL INJECTION ATTACK DETECTED (and mitigated)] , ");	
//							}								
							listOfRulesProcessed.Add(FormsProcessed + RulesProcessed);	
						}									
					}			
				}
			}
			catch (Exception objEx)
			{			
				listOfRulesProcessed.Add(htmlRed("Exception in 'validateAndHandleMaliciousInput' method"));	
				listOfRulesProcessed.Add(htmlRed(objEx.GetType().ToString()));	
				listOfRulesProcessed.Add(htmlRed(objEx.Message));	
				listOfRulesProcessed.Add(htmlRed(objEx.StackTrace));	
			}
			return listOfRulesProcessed;			
		}

		public ArrayList protectAndMitigateSQLInjections()
		{
			ArrayList listOfRulesProcessed = new ArrayList();	
			// Handle Form data
			while(true)
			{		
				bool bFoundSQLInjection = false;
				foreach(string sFormKey in HttpRequestToAnalyse.Form)
				{
					string dataToAnalyse = HttpRequestToAnalyse.Form[sFormKey];

					if (ValidatorFunctions.RuleClass_SQLInjectionDetector(dataToAnalyse))
					{
						// don't show message when no attack is detected
						// RulesProcessed += "SQLInjectionDetector" + htmlGreen(" [OK] , ");	
					}
					else
					{
						HttpRequestToAnalyse.Form[sFormKey] = HttpRequestToAnalyse.Form[sFormKey].Replace("'","");
						listOfRulesProcessed.Add("<b>SQLInjectionDetector</b> " + htmlRed(" [FAILED: SQL INJECTION ATTACK DETECTED (and mitigated)] , "));	
						bFoundSQLInjection = true;
						break;
					}												
				}
				if (!bFoundSQLInjection)
					break;
			}
			// Handle Querystring			
			while(true)
			{		
				bool bFoundSQLInjection = false;
				foreach(string sQuerystringKey in HttpRequestToAnalyse.QueryString)
				{
					string dataToAnalyse = HttpRequestToAnalyse.QueryString[sQuerystringKey];

					if (ValidatorFunctions.RuleClass_SQLInjectionDetector(dataToAnalyse))
					{
						// don't show message when no attack is detected
						// RulesProcessed += "SQLInjectionDetector" + htmlGreen(" [OK] , ");	
					}
					else
					{
						//					string strCorrectedValue = HttpRequestToAnalyse.QueryString[sQuerystringKey].Replace("'","");
						//					//strCorrectedValue = strCorrectedValue.Replace("'","");
						//					HttpRequestToAnalyse.QueryString.Remove(sQuerystringKey);
						//					HttpRequestToAnalyse.QueryString.Add(sQuerystringKey,strCorrectedValue);
						HttpRequestToAnalyse.QueryString[sQuerystringKey] = HttpRequestToAnalyse.QueryString[sQuerystringKey].Replace("'","");
						listOfRulesProcessed.Add("<b>SQLInjectionDetector</b> " + htmlRed(" [FAILED: SQL INJECTION ATTACK DETECTED (and mitigated)] , "));	
						bFoundSQLInjection = true;
						break;
					}												
				}
				if (!bFoundSQLInjection)
					break;
			}
			return listOfRulesProcessed;
		}

		public ArrayList protectAndMitigateXSSAttacks()
		{
			ArrayList listOfRulesProcessed = new ArrayList();	
			for(int i=0;i<HttpRequestToAnalyse.Form.Count;i++)
			{
				string strEncodedFormValue = HttpUtility.HtmlEncode(HttpRequestToAnalyse.Form[i]);
				HttpRequestToAnalyse.Form.Set(HttpRequestToAnalyse.Form.AllKeys[i], strEncodedFormValue );				
					
			}
			return listOfRulesProcessed;
		}


		private string htmlRed(string htmlCodeToApplyFormating)
		{
			return "<font color='red'>" + htmlCodeToApplyFormating + "</font>";
		}

		private string htmlOrange(string htmlCodeToApplyFormating)
		{
			return "<font color='Orange'>" + htmlCodeToApplyFormating + "</font>";
		}
		private string htmlGreen(string htmlCodeToApplyFormating)
		{
			return "<font color='Green'>" + htmlCodeToApplyFormating + "</font>";
		}
	}
}
