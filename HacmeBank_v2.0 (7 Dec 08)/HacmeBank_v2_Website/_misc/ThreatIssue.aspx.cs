using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using System.Runtime.InteropServices;



namespace HacmeBank_v2_Website.aspx
{
	/// <summary>
	/// Summary description for ThreatIssue.
	/// </summary>
	public partial class ThreatIssue : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			if (Request.QueryString["deleteHandle"]!=null)
			{
				if (CloseHandle(new IntPtr(Int32.Parse(Request.QueryString["deleteHandle"]))))
				{
					Response.Write("Handle " + Request.QueryString["deleteHandle"] +" was closed<br>");		
				}
				else
				{
					Response.Write("ERROR: Handle " + Request.QueryString["deleteHandle"] +" could not be closed<br>");		
				}
			}
			Response.Write("<font face=\"Arial\" size=\"2\" >");
			// Put user code to initialize the page here
			ArrayList listOfHandlesNames;
			listOfHandlesNames = returnArrayListWithCurrentHandles_usingBruteForceMethod(2000);
			Response.Write("Number of ObjectNames collected =" + listOfHandlesNames.Count.ToString());
			Response.Write("<hr>");
			Response.Write("  <a href=\"" + Request.Path + "\" > Refresh()</a>");
			Response.Write("<hr>");
			foreach(handleItemInfo handleItem in listOfHandlesNames)
			{
				if (handleItem._HandleName!="" && handleItem._HandleName.IndexOf("HacmeBank")>0)
				{
					Response.Write(handleItem._HandleNumber);
					Response.Write(":");
					Response.Write(handleItem._HandleName);
					Response.Write("  <a href=\"" + Request.Path + "?deleteHandle=" + handleItem._HandleNumber.ToString()+"\" >[del]</a>" );					
					Response.Write("<br>");					
				}
			}
			Response.Write("</font>");
			
		}

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion

		static public ArrayList returnArrayListWithCurrentHandles_usingBruteForceMethod(int numberOfHandlesToTry)
		{
			ArrayList listOfHandlesNames = new ArrayList();
			IntPtr ObjectInformation = Marshal.AllocHGlobal(512);						
			ulong Length = 512;
			ulong ResultLength = 0;
			int numberOfHandlesProcessed = 0;
			int numberOfHandlesPrinted = 0;
			for (int i=0; i<numberOfHandlesToTry;i++)
			{				
				long callReturnValue = NtQueryObject(i*4,OBJECT_INFORMATION_CLASS.ObjectNameInformation,ObjectInformation ,Length,ref ResultLength);				
				if (callReturnValue !=0 && callReturnValue != 0xc0000008)
				{
					listOfHandlesNames.Add(":::::ERROR::::: on Item " + Convert.ToString(i*4,16).ToString() + " the error " + Convert.ToString(callReturnValue,16).ToString() + " occured");
				}
				if (callReturnValue ==0)
				{
					numberOfHandlesProcessed++;					
					NAME_QUERY objectName = new NAME_QUERY();
					objectName = (NAME_QUERY)Marshal.PtrToStructure(ObjectInformation,objectName.GetType());					
					if (objectName.noIdeaWhatThisIs != "")
					{
						numberOfHandlesPrinted++;
						//Console.WriteLine(objectName.Name);	
						handleItemInfo tempHandleItemInfo = new handleItemInfo( i*4, objectName.Name);
						listOfHandlesNames.Add(tempHandleItemInfo);
						//listOfHandlesNames.Add(objectName.Name);
					}
					else
					{
						handleItemInfo tempHandleItemInfo = new handleItemInfo( 0, "");
						listOfHandlesNames.Add(tempHandleItemInfo);						
					}
				}						
			}	
			//Console.WriteLine("Processed {0} Handles and Printed {1}",numberOfHandlesProcessed, numberOfHandlesPrinted);
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

		[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto), BestFitMapping(false)]
			struct SYSTEM_HANDLE_TABLE_ENTRY_INFO
		{
			public uint UniqueProcessId;
			public uint CreatorBackTraceIndex;
			public char ObjectTypeIndex;
			public char HandleAttributes;
			public uint HandleValue;
			public IntPtr Object;
			public long GrantedAccess;
		};

		struct SYSTEM_HANDLE_INFORMATION 
		{
			public long NumberOfHandles;
			public SYSTEM_HANDLE_TABLE_ENTRY_INFO[] Handles;
		} 

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
