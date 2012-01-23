using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace HacmeBank_v2_Website
{
	/// <summary>
	/// Summary description for Gui.
	/// </summary>
	public class Gui : System.Web.UI.Page
	{		
		public static string pathToAscxFolder =  "~/ascx/";
		public static string pathToXslFolder =  "~/xsl/";
		public static string pathToXmlFolder =  "~/xml/";
		public Gui()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public void loadDefaultPageControls(PlaceHolder ascx_LeftMenu,PlaceHolder ascx_TopMenu, PlaceHolder ascx_Footer)
		{
			if ((null != HttpContext.Current.Request.Cookies["Admin"]) && ("true" == HttpContext.Current.Request.Cookies["Admin"].Value))
			{
				loadControlOnPlaceHolder(ascx_LeftMenu,"_AdminLeftMenu");				
			}
			else
			{
				loadControlOnPlaceHolder(ascx_LeftMenu,"_LeftMenu");				
			}			
			loadControlOnPlaceHolder(ascx_TopMenu,"_TopMenu");
			loadControlOnPlaceHolder(ascx_Footer,"_Footer");		
		}

		public void preloadControlOnDummyLocation(string pathToControlToLoad)
		{
			string fullVirtualPathToControlToLoad = pathToAscxFolder + pathToControlToLoad + ".ascx";				
			this.LoadControl(fullVirtualPathToControlToLoad );											
		}

		public void loadControlOnPlaceHolder(PlaceHolder placeHolderToUse,string pathToControlToLoad)
		{
			string fullVirtualPathToControlToLoad = pathToAscxFolder + pathToControlToLoad + ".ascx";				
			Control loadedControl = this.LoadControl(fullVirtualPathToControlToLoad );					
			placeHolderToUse.Controls.Add(loadedControl);	
		}

		public void populateDropDownListWithListOfUserAccounts(DropDownList targetDropDownList,string userID)
		{
			object[] userAccounts = Global.objAccountManagement.GetUserAccounts_using_UserID("",userID);
			dataClasses.userAccount[] userAccountDetails = new HacmeBank_v2_Website.dataClasses.userAccount[userAccounts.Length];
			for (int i=0 ; i< userAccounts.Length;i++)
			{				
				targetDropDownList.Items.Add((string)userAccounts[i]);				
			}
		}

		public void populateDropDownListWithLoanRates(DropDownList targetDropDownList)
		{
			object[] loanRates = Global.objAccountManagement.GetLoanRates("");			
			foreach (object[] loanRate in loanRates)
			{		
				targetDropDownList.Items.Add(new ListItem((string)loanRate[0].ToString(),(string)loanRate[1].ToString()));
			}
		}

		public void setCookieValue(string cookieName, string cookieValue)
		{
			HttpCookie AdminSectionCookie = new HttpCookie(cookieName);			
			AdminSectionCookie.Value = cookieValue;
			HttpContext.Current.Response.Cookies.Add(AdminSectionCookie);
		}
	}
}
