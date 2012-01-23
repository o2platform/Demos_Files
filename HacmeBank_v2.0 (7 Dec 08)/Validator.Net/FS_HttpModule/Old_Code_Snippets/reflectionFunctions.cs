using System;
using System.Reflection;
using System.Collections;
using System.Runtime.InteropServices;

namespace Foundstone
{
	/// <summary>
	/// Summary description for reflectionFunctions.
	/// </summary>
	public class reflectionFunctions
	{
		public reflectionFunctions()
		{
			//
			// TODO: Add constructor logic here
			//
		}

// From my OWASP WORK

		[DllImport("advapi32.dll")] public static extern int RevertToSelf();			

		public  BindingFlags ___getCurrentSelectedBindingFlags()
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

		static public object createInstanceOfReflectedClass(string Assembly_name,string Class_Name,string Method_Name,BindingFlags Public_or_Private_Flag)
		{			
			Assembly objAssembly =  Assembly.LoadFrom(Assembly_name);			
			Type objReflected_Class = objAssembly.GetType(Class_Name);			
			return objReflected_Class.InvokeMember(Method_Name,Public_or_Private_Flag | BindingFlags.Instance | BindingFlags.CreateInstance,null ,objReflected_Class,null);					
		}

		static public object  InvokePrivateMember_Static(object objClassToReflect, string strPrivateMethodToCall, object[] objArrayWithParameters)
		{
			Type objType = objClassToReflect.GetType();
			return objType.InvokeMember(strPrivateMethodToCall,BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.InvokeMethod, null, objClassToReflect,objArrayWithParameters);			
		}

		static public object getReflectedObject_Instance(object objReflectedObject, string strObjectToGet)
		{
			FieldInfo objectFieldInfo = objReflectedObject.GetType().GetField(strObjectToGet,BindingFlags.Instance | BindingFlags.NonPublic);    
			return (object)objectFieldInfo.GetValue(objReflectedObject);
		}

		static public object getReflectedObject_Static(object objReflectedObject, string strObjectToGet)
		{
			FieldInfo objectFieldInfo = objReflectedObject.GetType().GetField(strObjectToGet,BindingFlags.Static | BindingFlags.NonPublic);    
			return (object)objectFieldInfo.GetValue(objReflectedObject);
		}
		
//		public object lateGetReflectedPublicFunction(object objReflectedObject,string strFunctionToExecute,object[] objectArrayWithParameters)
//		{			
//			return LateBinding.LateGet(objReflectedObject , null,strFunctionToExecute,objectArrayWithParameters,null,null);
//		}



// ###############################################################
// ### From ASP.NET Reflector

		public class reflectedData
		{
			

			public string processedPath;
			public string typeOfReflectedData;
			public string groupTypeOfReflectedData;			

			public string methodInvoked;
			public string methodInvokeResult;

			public ArrayList arrayReflectedData;
		}

		public class FieldData
		{
			public string fieldName;
			public string fieldValue;
		}

		public reflectedData ___getReflectedMembers_internal(object objectToReflect)
		{			
			Type objType = objectToReflect.GetType();
			reflectedData objReflectedData = new reflectedData();
			objReflectedData.groupTypeOfReflectedData = "Members";
			objReflectedData.typeOfReflectedData = "Member";
			objReflectedData.arrayReflectedData = new ArrayList();			
			MemberInfo[] objMembersInfo =  objType.GetMembers(___getCurrentSelectedBindingFlags());
			foreach (MemberInfo objMemberInfo in objMembersInfo)
			{
				objReflectedData.arrayReflectedData.Add(objMemberInfo.Name.ToString() + " : " + objMemberInfo.ToString());										
			}
			return objReflectedData;
		}

		public reflectedData ___getReflectedProperties_internal(object objectToReflect)
		{
			Type objType = objectToReflect.GetType();
			reflectedData objReflectedData = new reflectedData();			
			objReflectedData.groupTypeOfReflectedData = "Properties";
			objReflectedData.typeOfReflectedData = "Property";
			objReflectedData.arrayReflectedData = new ArrayList();				
			PropertyInfo[] objPropertiesInfo =  objType.GetProperties(___getCurrentSelectedBindingFlags());
			foreach (PropertyInfo objPropertyInfo in objPropertiesInfo)
			{
				try
				{
					object reflectedObject = objPropertyInfo.GetValue(objectToReflect,___getCurrentSelectedBindingFlags() | BindingFlags.GetProperty,null,null,null);
					
					if (reflectedObject != null)
					{
						objReflectedData.arrayReflectedData.Add(objPropertyInfo.Name.ToString()); //  + "  [" +reflectedObject.ToString() +"]");  // + "  : " + objPropertyInfo.ToString());;						
					}
				}
				catch  //(Exception objException)
				{
					//					objReflectedData.arrayReflectedData.Add("[ERROR '" + objException.Message+ "' RESOLVING :" + objPropertyInfo.Name.ToString()); 
				}
			}
			return objReflectedData;
		}

		public reflectedData ___getReflectedMethods_internal(object objectToReflect)
		{
			Type objType = objectToReflect.GetType();
			reflectedData objReflectedData = new reflectedData();
			objReflectedData.groupTypeOfReflectedData = "Methods";
			objReflectedData.typeOfReflectedData = "Method";
			objReflectedData.arrayReflectedData = new ArrayList();			
			MethodInfo[] objMethodsInfo =  objType.GetMethods(___getCurrentSelectedBindingFlags() | BindingFlags.DeclaredOnly);
			foreach (MethodInfo objMethodInfo in objMethodsInfo)
			{
				string methodName =  objMethodInfo.Name.ToString();
				ParameterInfo[] objParametersInfo = objMethodInfo.GetParameters();
				string methodParameterInformation = "(";
				foreach (ParameterInfo objParameterInfo in objParametersInfo)
				{
					methodParameterInformation += objParameterInfo.ParameterType + " " + objParameterInfo.Name;
					if ((objParameterInfo.Position + 1) < objParametersInfo.Length)
					{
						methodParameterInformation += ",";
					}						
				}
				methodParameterInformation +=")";				
				string completeMethodNameWithHtmlMarkup;
				if (objParametersInfo.Length>0)
				{
					completeMethodNameWithHtmlMarkup = "<b>" +methodName + "</b>" + methodParameterInformation;
				}
				else
				{
					completeMethodNameWithHtmlMarkup = @"<a href=""Javascript:invokeMethod(':Methods;','"+methodName + @"','Method','invokeMethod','methodInvokeResult');""><b>" + objMethodInfo.Name.ToString()+ "</b>" + methodParameterInformation;					
				}
				objReflectedData.arrayReflectedData.Add(completeMethodNameWithHtmlMarkup);
			}
			return objReflectedData;
		}

		public reflectedData ___getReflectedFields_internal(object objectToReflect)
		{
			Type objType = objectToReflect.GetType();
			reflectedData objReflectedData = new reflectedData();
			objReflectedData.groupTypeOfReflectedData = "Fields";
			objReflectedData.typeOfReflectedData = "Field";

			objReflectedData.arrayReflectedData = new ArrayList();				
			FieldInfo[] objFieldsInfo =  objType.GetFields(___getCurrentSelectedBindingFlags());
			foreach (FieldInfo objFieldrInfo in objFieldsInfo)
			{				
				object reflectedObject = objFieldrInfo.GetValue(objectToReflect);
				if (reflectedObject != null)
				{
					FieldData objFieldData = new FieldData();
					objFieldData.fieldName = objFieldrInfo.Name.ToString();
					objFieldData.fieldValue = reflectedObject.ToString();

					objReflectedData.arrayReflectedData.Add(@"<name><td class=""td_verySmall_font""><b>"+ objFieldData.fieldName  +@"</b></td></name><value><td class=""td_verySmall_font""><i>"  + objFieldData.fieldValue+"</i></td></value>");						
				}				
			}
			return objReflectedData;
		}

		public reflectedData ___getReflectedPropertiesAndItsValues_internal(object objectToReflect)
		{
			Type objType = objectToReflect.GetType();
			reflectedData objReflectedData = new reflectedData();			
			objReflectedData.groupTypeOfReflectedData = "Properties";
			objReflectedData.typeOfReflectedData = "Property";
			objReflectedData.arrayReflectedData = new ArrayList();				
			PropertyInfo[] objPropertiesInfo =  objType.GetProperties(___getCurrentSelectedBindingFlags());
			foreach (PropertyInfo objPropertyInfo in objPropertiesInfo)
			{
				try
				{
					object reflectedObject = objPropertyInfo.GetValue(objectToReflect,___getCurrentSelectedBindingFlags() | BindingFlags.GetProperty,null,null,null);
					
					if (reflectedObject != null)
					{
						objReflectedData.arrayReflectedData.Add(@"<name><td class=""td_verySmall_font""><b>" + objPropertyInfo.Name.ToString()+ @"</b></td></name><value><td class=""td_verySmall_font""><i>"  +reflectedObject.ToString() +"</i></td></value>");
					}
				}
				catch //(Exception objException)
				{
					//					objReflectedData.arrayReflectedData.Add("[ERROR '" + objException.Message+ "' RESOLVING :" + objPropertyInfo.Name.ToString()); 
				}
			}
			return objReflectedData;
		}


	}
}
