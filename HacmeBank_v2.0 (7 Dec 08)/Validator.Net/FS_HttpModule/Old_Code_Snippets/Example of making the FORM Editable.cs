/*
 * using System;
using System.Web;
using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

// #######################################################################
// ###### Work in progress example of invoking private method HttpContext.Current.Request.Form.MakeReadWrite() 
// #######################################################################
		/// <summary>
		/// Work in progress example of invoking private method HttpContext.Current.Request.Form.MakeReadWrite() 
		/// </summary>



namespace Foundstone
{
	/// <summary>
	/// Summary description for RequestToValidate.
	/// </summary>
	public class RequestToValidate
	{		
		public HttpRequest HttpRequestToAnalyse;
		
		public RequestToValidate()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		internal bool validateCurrentPage(ArrayList pagesToProcess)
		{
			
			if (-1 == pagesToProcess.IndexOf((string)HttpRequestToAnalyse.Path))
			{
				return false;
			}
			else
			{	
				return true;
			}
		}

		[DllImport("advapi32.dll")] public static extern int RevertToSelf();			
	
		private BindingFlags ___getCurrentSelectedBindingFlags()
		{
			BindingFlags objTempBindingFlags = new BindingFlags();
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Public;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.NonPublic;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Instance;
			objTempBindingFlags = objTempBindingFlags | BindingFlags.Static;
			//			objTempBindingFlags = objTempBindingFlags | BindingFlags.DeclaredOnly;
			//objTempBindingFlags = objTempBindingFlags | BindingFlags.FlattenHierarchy;			
			return objTempBindingFlags;
		}




		internal bool pageHasItemsToValidate()
		{

			object objectToReflect;
			string stringObjectType;
			Type objType;
			PropertyInfo[] objPropertiesInfo;
			// see all Form properties (including private ones)			

					objectToReflect = HttpContext.Current.Request.Form;	
					objType = objectToReflect.GetType();
					

					HttpContext.Current.Response.Write("<hr><font size=+2>Before</font><br>");										
					HttpContext.Current.Response.Write("<b>Request.Form(txtUserName)</b>:"  + HttpContext.Current.Request.Form["txtUserName"] +"<br>");
					objPropertiesInfo =  objType.GetProperties(___getCurrentSelectedBindingFlags());
					foreach (PropertyInfo objPropertyInfo in objPropertiesInfo)
					{
						try
						{
							object reflectedObject = objPropertyInfo.GetValue(objectToReflect,___getCurrentSelectedBindingFlags() | BindingFlags.GetProperty,null,null,null);
							
							if (reflectedObject != null)
							{						
								HttpContext.Current.Response.Write(@"<b>" + objPropertyInfo.Name.ToString()+ @"</b>:"  +reflectedObject.ToString() +"<br>");
							}
						}
						catch
						{					
						}
					}
			// This is another way to list this information (using the OWasp ASP.NET Reflector library)
//					PropertyInfo objTempType = objectToReflect.GetType().GetProperty(stringObjectType,objreflectionFunctions.___getCurrentSelectedBindingFlags() |  BindingFlags.GetProperty); 
//					HttpContext.Current.Response.Write(objTempType.ToString());
//					object reflectedObject = objTempType.GetValue(objectToReflect,objreflectionFunctions.___getCurrentSelectedBindingFlags()  |  BindingFlags.GetProperty,null,null,null);								
//					objectToReflect = reflectedObject;
//					reflectionFunctions.reflectedData objReflectedData = new reflectionFunctions.reflectedData();
//					objReflectedData = objreflectionFunctions.___getReflectedPropertiesAndItsValues_internal(objectToReflect);
//					
//					System.Collections.Specialized.NameValueCollection FormData = (System.Collections.Specialized.NameValueCollection)reflectedObject;
//					HttpContext.Current.Response.Write("<hr>");
//					//HttpContext.Current.Response.Write(objReflectedData.arrayReflectedData.Count);
//					foreach(string item in objReflectedData.arrayReflectedData)
//					{
//						HttpContext.Current.Response.Write(item);
//					}

			// invoke the private method in order to make the Request.Form writable

					
					objectToReflect = HttpContext.Current.Request.Form;	
					stringObjectType = "MakeReadWrite";

					MethodInfo objTempMethodType = objectToReflect.GetType().GetMethod(stringObjectType,BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance,null,CallingConventions.Any,new Type[0] {},null); 
					HttpContext.Current.Response.Write("<hr>");
					
					object invokeResult = objTempMethodType.Invoke(objectToReflect,BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,null,new object[0] {} ,null);								
					HttpContext.Current.Response.Write("the private method HttpContext.Current.Request.Form.MakeReadWrite() was successfully invoked");


			// Change the value of a Request.Form variable (usualy this would fail)
			
					HttpRequestToAnalyse.Form["txtUserName"] = "Dynamic Value";


			// see the same values again
					objectToReflect = HttpContext.Current.Request.Form;	
					objType = objectToReflect.GetType();
					HttpContext.Current.Response.Write("<hr><font size=+2>AFTER</font><br>");		
					HttpContext.Current.Response.Write("<b>Request.Form(txtUserName)</b>:"  + HttpContext.Current.Request.Form["txtUserName"] +"<br>");
					objPropertiesInfo =  objType.GetProperties(___getCurrentSelectedBindingFlags());
					foreach (PropertyInfo objPropertyInfo in objPropertiesInfo)
					{
						try
						{
							object reflectedObject2 = objPropertyInfo.GetValue(objectToReflect,___getCurrentSelectedBindingFlags() | BindingFlags.GetProperty,null,null,null);
							
							if (reflectedObject2 != null)
							{						
								HttpContext.Current.Response.Write(@"<b>" + objPropertyInfo.Name.ToString()+ @"</b>:"  +reflectedObject2.ToString() +"<br>");
							}
						}
						catch
						{					
						}
					}



			

			if ((HttpRequestToAnalyse.Form.Count>0) || (HttpRequestToAnalyse.QueryString.Count>0))
			{
				return true;
			}
			return false;
		}

		internal bool checkForInvalidInput()
		{	
		



			foreach (string pageFormItem in HttpRequestToAnalyse.Form.AllKeys)
			{
				if ("txtUserName" == pageFormItem)
				{								
					return true;

				}
			}
			return false;			
		}
	}
}
*/