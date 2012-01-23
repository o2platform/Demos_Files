using System;
using System.Web;
using System.Reflection;
using System.Security;
using System.Diagnostics;

using System.Runtime.InteropServices;
using System.Security.Permissions;

[assembly: AssemblyVersion("1.0.0")]
//[assembly: AssemblyKeyFile(@"keypair.snk")]
[assembly: AllowPartiallyTrustedCallersAttribute()]

namespace Foundstone
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class ValidatorNET_GAC_Assembly
	{
		public ValidatorNET_GAC_Assembly()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public string test()
		{
			return "ValidatorNET_GAC_Assembly!!";
		}
		

		public bool makeTheRequestFormDataEditable()
		{					
			try 
			{			
				object objectToReflect = HttpContext.Current.Request.Form;			
				string stringObjectType = "MakeReadWrite";
				
				// Assert the retrival of information from a Private Method
				ReflectionPermission reflectionPerm = new ReflectionPermission(ReflectionPermissionFlag.TypeInformation);			
				reflectionPerm.Assert();			

				MethodInfo objTempMethodType = objectToReflect.GetType().GetMethod(
					stringObjectType,BindingFlags.Public | BindingFlags.NonPublic | 
					BindingFlags.Instance, null,CallingConventions.Any,new Type[0] {},null); 					
			
				// Revert the previous assert since it is only possible to have one active Assert
				ReflectionPermission.RevertAssert();
				// Assert the execution of a Private Method
				reflectionPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
				reflectionPerm.Assert();

				object invokeResult = 
					objTempMethodType.Invoke(
					objectToReflect,BindingFlags.Public | BindingFlags.NonPublic | 
					BindingFlags.Instance | BindingFlags.InvokeMethod,null,new object[0] {} ,null);												
				return true;
			}	
			catch (Exception ex) 
			{	
				HttpContext.Current.Response.Write(ex.Message);
				return false;
			}			
		}

		public bool makeTheRequestQueryStringDataEditable()
		{					
			try 
			{			
				object objectToReflect = HttpContext.Current.Request.QueryString;			
				string stringObjectType = "MakeReadWrite";
				
				// Assert the retrival of information from a Private Method
				ReflectionPermission reflectionPerm = new ReflectionPermission(ReflectionPermissionFlag.TypeInformation);			
				reflectionPerm.Assert();			

				MethodInfo objTempMethodType = objectToReflect.GetType().GetMethod(
					stringObjectType,BindingFlags.Public | BindingFlags.NonPublic | 
					BindingFlags.Instance, null,CallingConventions.Any,new Type[0] {},null); 					
			
				// Revert the previous assert since it is only possible to have one active Assert
				ReflectionPermission.RevertAssert();
				// Assert the execution of a Private Method
				reflectionPerm = new ReflectionPermission(ReflectionPermissionFlag.MemberAccess);
				reflectionPerm.Assert();

				object invokeResult = 
					objTempMethodType.Invoke(
					objectToReflect,BindingFlags.Public | BindingFlags.NonPublic | 
					BindingFlags.Instance | BindingFlags.InvokeMethod,null,new object[0] {} ,null);												
				return true;
			}	
			catch (Exception ex) 
			{	
				HttpContext.Current.Response.Write(ex.Message);
				return false;
			}			
		}
	}
}
