namespace HacmeBank_v2_Website.ascx
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for PasswordChange.
	/// </summary>
	public partial class PasswordChange : System.Web.UI.UserControl
	{

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// Put user code to initialize the page here
		}

		/// <summary>
		/// vulnerability: The check for the old password is never made before the password is changed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void btnSubmit_Click(object sender, System.EventArgs e)
		{			
			lblErrorMessage.Text = "";
			if (txtOldPassword.Text.ToString() == "")
					lblErrorMessage.Text+=("Old password field cannot be empty. ");
			if( txtNewPassword.Text.ToString() == "") 
					lblErrorMessage.Text+=("New password field cannot be empty. ");
			if (txtNewPassword.Text!=txtConfirmPassword.Text)
				lblErrorMessage.Text+=("New passwords are not equal. ");
			if (lblErrorMessage.Text =="")
			{							
				try
				{
					Global.objUserManagement.ChangeUserPassword("",(string)Session["userID"].ToString(),txtNewPassword.Text);
					lblMessage.Text = "Password changed successfully.";
				}
				catch(Exception Ex)
				{
					lblMessage.Text=Ex.Message;
				}
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
	}
}
