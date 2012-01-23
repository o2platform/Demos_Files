using System;
using System.Text.RegularExpressions;

namespace Foundstone
{
	/// <summary>
	/// Summary description for executeValidatorRuleClass.
	/// </summary>
	public class ValidatorFunctions
	{	
		public static bool RuleClass_RequiredFieldValidator(string dataToAnalyse)
		{			
			if ("" != dataToAnalyse)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool RuleClass_RegExValidator(string dataToAnalyse,string RegExToApply)
		{			
			if (null != dataToAnalyse)
			{
				Regex objRegEx = new Regex(RegExToApply,RegexOptions.IgnoreCase);			
				if (objRegEx.Match(dataToAnalyse).Success)
				{
					return false;
				}
			}	
			return true;
		}

		public static bool RuleClass_RangeValidator(string dataToAnalyse) { return true; }

		public static bool RuleClass_CustomValidator(string dataToAnalyse) { return true; }		

		public static bool RuleClass_ValidationSummary(string dataToAnalyse) { return true; }		

		public static bool RuleClass_SQLInjectionDetector(string dataToAnalyse)
		{
			if (null !=  dataToAnalyse)
			{
				if ( -1 < dataToAnalyse.IndexOf("'"))
				{										
					return false;
				}							
			}
			return true;
		}
	}
}
