using System;
using System.Web;

namespace Foundstone
{
	/// <summary>
	/// Summary description for miscFunctions.
	/// </summary>
	public class miscFunctions
	{
		public miscFunctions()
		{
			//
			// TODO: Add constructor logic here
			//
		}

//		static public void outputMessage(HttpContext objHttpContext, string messageToOutput)
//		{
//			objHttpContext.Response.Write(messageToOutput);
//		}

	}
}



//		object CreatePrivateObject_of_Instance(string Assembly_Name,string Class_Name,string Method_Name,BindingFlags Public_or_Private_Flag)
//		{
//			Assembly System_web_Obj = Assembly.LoadFrom(Assembly_Name);
//			Type Reflected_Class = System_web_Obj.GetType(Class_Name);
//		
//			return Reflected_Class.InvokeMember(Method_Name,Public_or_Private_Flag | BindingFlags.Instance | BindingFlags.CreateInstance, null, Reflected_Class ,null);
//		}
//
//
//			string System_Web_Dll = Environment.GetEnvironmentVariable("windir") + "\\Microsoft.NET\\Framework\\v1.1.4322\\system.web.dll";
//			object objHttpApplicationFactory = CreatePrivateObject_of_Instance(System_Web_Dll ,"System.Web.HttpApplicationFactory","", BindingFlags.NonPublic);
//
//			object objectToReflect = objHttpApplicationFactory;	
//			string stringObjectType = "GetApplicationInstance";
//			MethodInfo objTempMethodType = objectToReflect.GetType().GetMethod(
//				stringObjectType,BindingFlags.Public | BindingFlags.NonPublic | 
//				BindingFlags.Instance, null,CallingConventions.Any,new Type[0] {},null); 		
//			IHttpHandler handler1 = (IHttpHandler )objTempMethodType.Invoke(
//													objectToReflect,BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod
//													,null,new object[1] {HttpContext.Current} ,null);		
//			IHttpHandler handler1 = HttpApplicationFactory.GetApplicationInstance(HttpContext.Current);
