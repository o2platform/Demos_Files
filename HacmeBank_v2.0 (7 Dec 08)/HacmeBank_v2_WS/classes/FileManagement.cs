using System;
using System.IO;

namespace HacmeBank_v2_WS
{
	/// <summary>
	/// Summary description for FileManagement.
	/// </summary>
	public class FileManagement
	{
		public FileManagement()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public static string  returnFileContents(string fileToGet)
		{
			StreamReader fileContents;
			fileContents = File.OpenText(fileToGet);
			return fileContents.ReadToEnd();
		}
	}
}








