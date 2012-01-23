using System;
using System.Web;
using System.Web.UI;
using System.Collections;
using System.Runtime.InteropServices;
using System.IO;





namespace HacmeBank_v2_Website
{
	/// <summary>
	/// Summary description for ascxThreadingIssue.
	/// </summary>
	public class ascxThreadingIssue : System.Web.UI.Page
	{
		public ascxThreadingIssue()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		static public void preloadAllAscxControls()
		{			
			//return;
			string pathToAdminAscxFolder = Gui.pathToAscxFolder + "admin/";
			preloadUsingMethod_I(Gui.pathToAscxFolder);
			preloadUsingMethod_II(pathToAdminAscxFolder);
		}

		static private void preloadUsingMethod_I(string pathToDirWithAscxControls)
		{
			//return;
			string fullPathToDirWithAscxControls = HttpContext.Current.Request.MapPath(pathToDirWithAscxControls);
			DirectoryInfo ascxDirectory = new DirectoryInfo(fullPathToDirWithAscxControls);
			foreach(FileInfo ascxFile in ascxDirectory.GetFiles("*.ascx"))
			{				
				string ascxControlToLoad=ascxFile.Name.Substring(0,ascxFile.Name.LastIndexOf("."));
				Global.objGui.preloadControlOnDummyLocation(ascxControlToLoad);
				//				Response.Write("loaded " + ascxControlToLoad + "<br>");
			}			
		}

		static private void preloadUsingMethod_II(string pathToDirWithAscxControls)
		{
			//return;
			string fullPathToDirWithAscxControls = HttpContext.Current.Request.MapPath(pathToDirWithAscxControls);
			DirectoryInfo ascxDirectory = new DirectoryInfo(fullPathToDirWithAscxControls );
			foreach(FileInfo ascxFile in ascxDirectory.GetFiles("*.ascx"))
			{	
				string ascxControlToLoad =	"http://" + 
					HttpContext.Current.Request.Url.Host + 
					HttpContext.Current.Request.ApplicationPath + 
					pathToDirWithAscxControls + 
					ascxFile.Name;								
				ascxControlToLoad = ascxControlToLoad.Replace("~","");				
				AdminFunctions.fetchWebPage(ascxControlToLoad);				
			}						
		}



		static public void closeOpenHacmeBankHandles()
		{
			
			HttpContext.Current.Response.Write("<font face=\"Arial\" size=\"2\" >");
			// Put user code to initialize the page here
			ArrayList listOfHandlesNames;
			listOfHandlesNames = returnArrayListWithCurrentHandles_usingBruteForceMethod(2000);
			HttpContext.Current.Response.Write("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\">");
			HttpContext.Current.Response.Write("	<tr>");
			HttpContext.Current.Response.Write("		<td><img src=\"images/hacme_header.jpg\" width=\"664\" height=\"32\"></td>");
			HttpContext.Current.Response.Write("	</tr>");
			HttpContext.Current.Response.Write("	<tr>");
			HttpContext.Current.Response.Write("		<td><img src=\"images/blueheaderblank.jpg\"></td>");
			HttpContext.Current.Response.Write("	</tr>");
			HttpContext.Current.Response.Write("</table>");
			HttpContext.Current.Response.Write("<br>");
			// Display a user friendly error message
			HttpContext.Current.Response.Write("<h3>Session Timed-Out</h3>");

//			Exception lastError =  HttpContext.Current.Server.GetLastError();
//			HttpContext.Current.Response.Write(lastError.Message);
//			HttpContext.Current.Response.Write("<br>");
//			HttpContext.Current.Response.Write("<br>");
//			HttpContext.Current.Response.Write(lastError.InnerException.Message);			
//			HttpContext.Current.Response.Write("<br>");
//			HttpContext.Current.Response.Write("Closing all process object handles with 'HacmeBank' in its name");
//			HttpContext.Current.Response.Write("<br>");
//			HttpContext.Current.Response.Write("Number of ObjectNames collected =" + listOfHandlesNames.Count.ToString());
//			HttpContext.Current.Response.Write("<hr>");
			foreach(handleItemInfo handleItem in listOfHandlesNames)
			{
				if (handleItem._HandleName!="" && handleItem._HandleName.IndexOf("HacmeBank")>0)
				{
					if ( CloseHandle(new IntPtr(handleItem._HandleNumber)))
					{
//						HttpContext.Current.Response.Write("Handle " + Convert.ToString(handleItem._HandleNumber,16) +"("+handleItem._HandleName+") was closed");		
					}
					else
					{
//						HttpContext.Current.Response.Write("ERROR: Handle " + Convert.ToString(handleItem._HandleNumber,16) +"("+handleItem._HandleName+")  could not be closed");		
					}
//					HttpContext.Current.Response.Write("<br>");	
									
				}
			}
			HttpContext.Current.Response.Write("</font>");
//			HttpContext.Current.Response.Write("<br><br>");
			
		}


		static public ArrayList returnArrayListWithCurrentHandles_usingBruteForceMethod(int numberOfHandlesToTry)
		{
			ArrayList listOfHandlesNames = new ArrayList();
			IntPtr ObjectInformation = Marshal.AllocHGlobal(512);						
			ulong Length = 512;
			ulong ResultLength = 0;
			for (int i=0; i<numberOfHandlesToTry;i++)
			{				
				long callReturnValue = NtQueryObject(i*4,OBJECT_INFORMATION_CLASS.ObjectNameInformation,ObjectInformation ,Length,ref ResultLength);				
				if (callReturnValue !=0 && callReturnValue != 0xc0000008)
				{
					listOfHandlesNames.Add(":::::ERROR::::: on Item " + Convert.ToString(i*4,16).ToString() + " the error " + Convert.ToString(callReturnValue,16).ToString() + " occured");
				}
				if (callReturnValue ==0)
				{								
					NAME_QUERY objectName = new NAME_QUERY();
					objectName = (NAME_QUERY)Marshal.PtrToStructure(ObjectInformation,objectName.GetType());					
					if (objectName.noIdeaWhatThisIs != "")
					{													
						handleItemInfo tempHandleItemInfo = new handleItemInfo( i*4, objectName.Name);
						listOfHandlesNames.Add(tempHandleItemInfo);						
					}
					else
					{
						handleItemInfo tempHandleItemInfo = new handleItemInfo( 0, "");
						listOfHandlesNames.Add(tempHandleItemInfo);						
					}
				}						
			}				
			return listOfHandlesNames;
		}

		public struct handleItemInfo
		{
			public int _HandleNumber;
			public string _HandleName;
			public handleItemInfo(int HandleNumber, string HandleName)
			{
				_HandleNumber = HandleNumber;
				_HandleName = HandleName;
			}
		}

		const uint SystemHandleInformation = 16;

		[DllImport("kernel32.dll")]
		internal static extern bool CloseHandle(IntPtr handle);

		[DllImport("ntdll.dll", CharSet=CharSet.Auto)]
		public static extern uint NtQuerySystemInformation(	uint SystemInformationClass,
															IntPtr SystemInformation,
															long SystemInformationLength,
															uint ReturnLength );
		[DllImport("ntdll.dll", CharSet=CharSet.Auto)]
		public static extern uint NtQueryObject(int ObjectHandle,
												OBJECT_INFORMATION_CLASS ObjectInformationClass,
												IntPtr ObjectInformation,
												ulong Length,
												ref ulong ResultLength);

		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto), BestFitMapping(false)]
			public struct NAME_QUERY
		{
			[MarshalAs(UnmanagedType.ByValTStr,SizeConst=4)] 
			public string noIdeaWhatThisIs;
			[MarshalAs(UnmanagedType.ByValTStr,SizeConst=512)] 
			public string Name;
		} ;

		public enum OBJECT_INFORMATION_CLASS
		{
			ObjectBasicInformation,			// Result is OBJECT_BASIC_INFORMATION structure
			ObjectNameInformation,			// Result is OBJECT_NAME_INFORMATION structure
			ObjectTypeInformation,			// Result is OBJECT_TYPE_INFORMATION structure
			ObjectAllInformation,			// Result is OBJECT_ALL_INFORMATION structure
			ObjectDataInformation			// Result is OBJECT_DATA_INFORMATION structure
		
		}
	}
}
