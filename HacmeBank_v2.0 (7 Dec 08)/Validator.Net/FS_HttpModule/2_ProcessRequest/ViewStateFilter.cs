using System;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;
using System.Collections;

namespace Foundstone
{
	/// <summary>
	/// Summary description for ViewStateFilter.
	/// </summary>
	/// 
	

	public class ViewStateFilter : Stream 
	{

		static Hashtable htViewStateData = new Hashtable();
 
		#region properties
 
		Stream responseStream;
		long position;
		StringBuilder sbHtml = new StringBuilder();
//		string strSavedViewState;
 
		#endregion
 
		#region constructor

		public ViewStateFilter(Stream inputStream , Hashtable htViewStateData) 
		{
 
			responseStream = inputStream;
			//this.htViewStateData = htViewStateData;
 
		}
 
		#endregion

		#region implemented abstract members
 
		public override bool CanRead 
		{
			get { return true; }
		}

		public override bool CanSeek 
		{
			get { return true; }
		}

		public override bool CanWrite 
		{
			get { return true; }
		}

		public override void Close() 
		{
			responseStream.Close();
		}

		public override void Flush() 
		{
			responseStream.Flush();
		}
 
		public override long Length 
		{
			get { return 0; }
		}

		public override long Position 
		{
			get { return position; }
			set { position = value; }
		}

		public override long Seek(long offset, System.IO.SeekOrigin direction) 
		{
			return responseStream.Seek(offset, direction);
		}

		public override void SetLength(long length) 
		{
			responseStream.SetLength(length);
		}

		public override int Read(byte[] buffer, int offset, int count) 
		{
			return responseStream.Read(buffer, offset, count);
		}
 
		#endregion

		#region write method
 
		public override void Write(byte[] buffer, int offset, int count) 
		{
 
			// string version of the buffer
			string sBuffer = System.Text.UTF8Encoding.UTF8.GetString(buffer, offset, count);

			// end of the HTML file
			Regex oEndFile = new Regex("</html>", RegexOptions.IgnoreCase);
			if ((oEndFile.IsMatch(sBuffer))) 
			{   
				// Append the last buffer of data
				sbHtml.Append(sBuffer);
   
				string strResponseString = sbHtml.ToString();
  
				Regex reViewState = new Regex ("(<input.*?__VIEWSTATE.*?/>)", RegexOptions.IgnoreCase);
				
				string strGUID = System.Guid.NewGuid().ToString() ;
				Match mViewState = reViewState.Match(strResponseString);
				if (mViewState .Success)					// if there is a ViewState item process it
				{
					string strOriginalViewState = strResponseString.Substring(mViewState.Index,mViewState.Length);					
					int iFirstQuote = strOriginalViewState.IndexOf("value=\"")+(("value=\"").Length);
					int iLastQuote = strOriginalViewState.Substring(iFirstQuote).IndexOf("\"");
					strOriginalViewState = strOriginalViewState.Substring(iFirstQuote,iLastQuote);
					htViewStateData.Add(strGUID, strOriginalViewState);
					string strNewViewState = "<input type=\"hidden\" name=\"__VIEWSTATE\" value=\""+strGUID+"\">";
					strResponseString = reViewState.Replace(strResponseString, strNewViewState);  // replace the ViewState
				}
				byte[] data = System.Text.UTF8Encoding.UTF8.GetBytes(strResponseString);   
				responseStream.Write(data, 0, data.Length);
			}
			else 
			{
				sbHtml.Append(sBuffer);
			}
  
		}
  
		#endregion

		public static void handleViewState(object sender, EventArgs e)
		{
			HttpApplication currentHttpApplication = (HttpApplication)sender; 
			// Set output filter
			currentHttpApplication.Response.Filter = new ViewStateFilter(currentHttpApplication.Response.Filter,htViewStateData);
			// if there is a ViewState replace the current GUID with it
			if (null != currentHttpApplication.Request.Form["__VIEWSTATE"])//(htViewStateData.Count>0)
			{
				// make the Form object edititable (by default it is not)
				new ValidatorNET_GAC_Assembly().makeTheRequestFormDataEditable();				
				string strViewStateGUID = currentHttpApplication.Request.Form["__VIEWSTATE"];
				// make the change
				currentHttpApplication.Request.Form["__VIEWSTATE"] =  (string)htViewStateData[strViewStateGUID];
				// remove item from HashTable
				htViewStateData.Remove(strViewStateGUID);
			}
		}
  
	}	
}
