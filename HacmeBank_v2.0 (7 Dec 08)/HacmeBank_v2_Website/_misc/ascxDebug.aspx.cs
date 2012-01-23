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


using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace HacmeBank_v2_Website.aspx
{
	/// <summary>
	/// Summary description for ascxDebug.
	/// </summary>
	public partial class ascxDebug : System.Web.UI.Page
	{
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}
/*
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	
		[DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)]
		internal static extern IntPtr FindFirstFile(string pFileName, 
			[In, Out] WIN32_FIND_DATA pFindFileData);
 

		[DllImport("kernel32.dll", SetLastError=true)] static extern int GetFileInformationByHandle ( int hFile, ref BY_HANDLE_FILE_INFORMATION lpFileInformation);

		[DllImport("kernel32.dll")]
		internal static extern int GetFileType(IntPtr handle);

		[DllImport("kernel32.dll", SetLastError=true)]
		internal static extern int GetFileSize(IntPtr hFile, out int highSize);

		public void test()
		{
			string workDir = MapPath(Request.ApplicationPath);
			workDir = workDir.Replace("\\","\\\\");

			DirectoryInfo objDirectoryInfo = new DirectoryInfo(Request.ApplicationPath);
			Response.Write(workDir);
			string pFileName = workDir;
			WIN32_FIND_DATA pFindFileData = new WIN32_FIND_DATA();
			IntPtr directoryPtr = FindFirstFile(pFileName,pFindFileData);
			Response.Write("<br>");			
			//BY_HANDLE_FILE_INFORMATION lpFileInformation = new BY_HANDLE_FILE_INFORMATION();
			//Response.Write(GetFileInformationByHandle(264,ref lpFileInformation));

//			FileReader objFileReader = new FileReader();
//			Response.Write( objFileReader.Open(@"C:\test\"));			
			//Response.Write( FileReader.OpenFile(@"C:\test\onlyAdmins.txt"));			
//						int hFile = 2; 			
						for (int i=0;i<150;i++)
						{
							try 
							{
								//BY_HANDLE_FILE_INFORMATION lpFileInformation = new BY_HANDLE_FILE_INFORMATION();
								//Response.Write(GetFileInformationByHandle(i,ref lpFileInformation));
								IntPtr tempIntPrt = new IntPtr(i*4);
								int highSize; 
								int response = GetFileSize(tempIntPrt,out highSize);								
								if (response==0)
								{
										Response.Write(Convert.ToString((i*4),16) + " : " + highSize.ToString());								
								}
								
							}
							catch (Exception ex)
							{
								Response.Write(ex.Message);
							}
							Response.Write("<br>");
						}
						//Response.Write(Convert.ToString(directoryPtr.ToInt32(),16));
					
		}
	}

	[Serializable, StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto), BestFitMapping(false)]
	internal class  FILETIME
	{
		internal long dwLowDateTime;
		internal long dwHighDateTime;	
		public FILETIME()
		{
			dwLowDateTime = 0;
			dwHighDateTime = 0;
		}
	}

	[Serializable, StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto), BestFitMapping(false)]
	internal class BY_HANDLE_FILE_INFORMATION
	{
		internal long dwFileAttributes ;
		internal FILETIME ftCreationTime;
		internal FILETIME ftLastAccessTime;
		internal FILETIME ftLastWriteTime ;
		internal long dwVolumeSerialNumber ;
		internal long nFileSizeHigh ;
		internal long nFileSizeLow ;
		internal long nNumberOfLinks; 
		internal long nFileIndexHigh ;
		internal long nFileIndexLow ;
		public BY_HANDLE_FILE_INFORMATION()
		{
			this.dwFileAttributes = 0;
			this.ftCreationTime = new FILETIME();
			this.ftLastAccessTime = new FILETIME();
			this.ftLastWriteTime = new FILETIME();
			this.dwVolumeSerialNumber = 0;
			this.nFileSizeHigh = 0;
			this.nFileSizeLow = 0;
			this.nNumberOfLinks = 0;
			this.nFileIndexHigh = 0;
			this.nFileIndexLow = 0;
		}
	}

	[Serializable, StructLayout(LayoutKind.Sequential, CharSet=CharSet.Auto), BestFitMapping(false)]
	internal class WIN32_FIND_DATA
	{
		internal int dwFileAttributes;
		internal int ftCreationTime_dwLowDateTime;
		internal int ftCreationTime_dwHighDateTime;
		internal int ftLastAccessTime_dwLowDateTime;
		internal int ftLastAccessTime_dwHighDateTime;
		internal int ftLastWriteTime_dwLowDateTime;
		internal int ftLastWriteTime_dwHighDateTime;
		internal int nFileSizeHigh;
		internal int nFileSizeLow;
		internal int dwReserved0;
		internal int dwReserved1;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=260)]
		internal string cFileName;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=14)]
		internal string cAlternateFileName;
		public WIN32_FIND_DATA()
		{
			this.dwFileAttributes = 0;
			this.ftCreationTime_dwLowDateTime = 0;
			this.ftCreationTime_dwHighDateTime = 0;
			this.ftLastAccessTime_dwLowDateTime = 0;
			this.ftLastAccessTime_dwHighDateTime = 0;
			this.ftLastWriteTime_dwLowDateTime = 0;
			this.ftLastWriteTime_dwHighDateTime = 0;
			this.nFileSizeHigh = 0;
			this.nFileSizeLow = 0;
			this.dwReserved0 = 0;
			this.dwReserved1 = 0;
			this.cFileName = null;
			this.cAlternateFileName = null;
		}
	}

	class FileReader
	{
		const uint FILE_SHARE_READ = 0x00000001;
		const uint FILE_SHARE_WRITE = 0x00000002;
		const uint FILE_SHARE_DELETE = 0x00000004;
		const uint OPEN_EXISTING = 3;

		const uint GENERIC_READ = (0x80000000);
		const uint GENERIC_WRITE = (0x40000000);

		const uint FILE_FLAG_NO_BUFFERING = 0x20000000;
		const uint FILE_READ_ATTRIBUTES = (0x0080);
		const uint FILE_WRITE_ATTRIBUTES = 0x0100;
		const uint ERROR_INSUFFICIENT_BUFFER = 122;

		const int FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;
		
		IntPtr handle;
 
		[DllImport("kernel32", SetLastError=true)]
		static extern unsafe IntPtr CreateFile(
			string FileName,                    // file name
			uint DesiredAccess,                 // access mode
			uint ShareMode,                     // share mode
			uint SecurityAttributes,            // Security Attributes
			uint CreationDisposition,           // how to create
			uint FlagsAndAttributes,            // file attributes
			int hTemplateFile                   // handle to template file
			);
 
		[DllImport("kernel32", SetLastError=true)]
		static extern unsafe bool ReadFile(
			IntPtr hFile,                       // handle to file
			void* pBuffer,                      // data buffer
			int NumberOfBytesToRead,            // number of bytes to read
			int* pNumberOfBytesRead,            // number of bytes read
			int Overlapped                      // overlapped buffer
			);
 
		[DllImport("kernel32", SetLastError=true)]
		static extern unsafe bool CloseHandle(
			IntPtr hObject   // handle to object
			);
      

		static public IntPtr OpenFile(string path)
		{
			IntPtr hFile;
			hFile = CreateFile(
				path,
				FILE_READ_ATTRIBUTES ,
				FILE_SHARE_READ ,
				0,
				OPEN_EXISTING,
				0,
				0);
//			if ((int)hFile == -1)
//			{
//				(Marshal.GetLastWin32Error().ToString());
//			}
			return hFile;
		}




		public IntPtr Open(string FileName)
		{
			// open the existing file for reading          
//			handle = CreateFile(
//				FileName,
//				GENERIC_READ,
//				0, 
//				0, 
//				OPEN_EXISTING,
//				0,
//				0);			
			handle = CreateFile (
				FileName,
				GENERIC_READ,
				FILE_SHARE_READ|FILE_SHARE_WRITE|FILE_SHARE_DELETE,
				0,
				OPEN_EXISTING,
				FILE_FLAG_BACKUP_SEMANTICS,
				0
				);
			if (handle != IntPtr.Zero)
				return handle;
			else
				return IntPtr.Zero;
		}
 
		public unsafe int Read(byte[] buffer, int index, int count) 
		{
			int n = 0;
			fixed (byte* p = buffer) 
			{
				if (!ReadFile(handle, p + index, count, &n, 0))
					return 0;
			}
			return n;
		}
 
		public bool Close()
		{
			// close file handle
			return CloseHandle(handle);
		}
	 	*/
	}
}

	
