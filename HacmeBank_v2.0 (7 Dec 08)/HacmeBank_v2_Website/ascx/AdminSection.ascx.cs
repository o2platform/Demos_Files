namespace HacmeBank_v2_Website.ascx
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using System.Configuration;

	/// <summary>
	///		Summary description for AdminSection.
	/// </summary>
	public partial class AdminSection : System.Web.UI.UserControl
	{


		protected void Page_Load(object sender, System.EventArgs e)
		{

			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				allocatedRamdomNumberToTextBox();											
			}
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

		protected void btnLoginAdminSection_Click(object sender, System.EventArgs e)
		{
			
			if (txtResponse.Text.Trim() == lblResponseValue.Text.Trim())
			{
				Global.objGui.setCookieValue("Admin","true");
				Response.Redirect("main.aspx?function=Welcome");
			}
			else
			{
				lblErrorMessage.Text = "Wrong Response, Please try again.";				
				allocatedRamdomNumberToTextBox();
			}
		}
	
		private void allocatedRamdomNumberToTextBox()
		{
			txtChallenge.Text = new Random().Next().ToString();			
			// the response is the Challenge XORed with the AdminSectionKey				
			lblResponseValue.Text = (Int64.Parse(txtChallenge.Text) ^ Int64.Parse(ConfigurationSettings.AppSettings.Get("AdminSectionKey"))).ToString();
            if (Request.QueryString["ShowPassword"] == "yes")
			    Response.Write("<div style=\"COLOR: #f0f0f0;LEFT: 1px; POSITION: absolute; TOP: 1px\">"+lblResponseValue.Text+ "</div>");
		}




	}
}
