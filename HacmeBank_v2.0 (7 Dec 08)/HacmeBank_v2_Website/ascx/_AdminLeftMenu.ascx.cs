namespace HacmeBank_v2_Website.ascx
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.IO;

	/// <summary>
	///		Summary description for _AdminLeftMenu.
	/// </summary>
	public partial class _AdminLeftMenu : System.Web.UI.UserControl
	{



		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
			buildMenuDynamicalyFromFilesOnAscxFolder();
		}

		private void buildMenuDynamicalyFromFilesOnAscxFolder()
		{
			string dynamicMenuHtmlMenu = "";
			DirectoryInfo ascxAdminDirectory = new DirectoryInfo(MapPath(Gui.pathToAscxFolder) + "\\Admin");
			foreach(FileInfo ascxFile in ascxAdminDirectory.GetFiles("*.ascx"))
			{					
				string ascxControlName = ascxFile.Name.Substring(0,ascxFile.Name.LastIndexOf("."));	
				string friendlyName = ascxControlName.Replace("_"," ");
				ascxControlName = "admin\\" + ascxControlName;
				dynamicMenuHtmlMenu += returnDynamicMenuHtmlCode(friendlyName,ascxControlName);
				//string ascxControlToLoad=ascxFile.Name.Substring(0,ascxFile.Name.LastIndexOf("."));	
				//returnDynamicMenuHtmlCode
			}					
			ascxLabel_AdminLeftMenu.Text = dynamicMenuHtmlMenu;
		}

		private string returnDynamicMenuHtmlCode(string friendlyName, string ascxControlName)
		{
			string menuHtmlCode = "";
			menuHtmlCode += "	<tr class=\"menu_light\">";
			menuHtmlCode += "		<td><img src=\"images/clear.gif\" width=\"1\" height=\"1\"></td>";
			menuHtmlCode += "	</tr>";		
			menuHtmlCode += "	<tr class=\"menu_dark\">";
			menuHtmlCode += "		<td>";
			menuHtmlCode += "			<table border=\"0\" cellspacing=\"3\" cellpadding=\"3\">";
			menuHtmlCode += "				<tr>";
			menuHtmlCode += "					<td class=\"menu_dark\">";
			menuHtmlCode += "						<img src=\"images/nav_arrows.gif\">";
			menuHtmlCode += "						<a href=\"Main.aspx?function=" + ascxControlName + "\">" + friendlyName + "</a>";
			menuHtmlCode += "					</td>";
			menuHtmlCode += "				</tr>";
			menuHtmlCode += "			</table>";
			menuHtmlCode += "		</td>";
			menuHtmlCode += "	</tr>";
			return menuHtmlCode;
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
		///		Required method for Designer support - do not modify
		///		the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{			

		}
		#endregion

		protected void lnkBtnLoans_Click(object sender, System.EventArgs e)
		{
			Response.Redirect ("main.aspx?function=Loan");
		}
		
		protected void lnkBtnPostMessage_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("main.aspx?function=PostMessageForm");
		}		

		protected void lnkBtnFundsTransfer_Click(object sender, System.EventArgs e)
		{
			Response.Redirect("main.aspx?function=AccountTransfer");
		}
	}
}
