namespace HacmeBank_v2_Website.ascx
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		Summary description for PostMessageForm.
	/// </summary>
	public partial class Manage_Users : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Table buttonSubmitUserDetails;	

		protected void Page_Load(object sender, System.EventArgs e)
		{			
			// Put user code to initialize the page here
			if (!IsPostBack)
			{
				lblPageTitle.Text = "Manage Users";
				LoadUsersDetails();
			}
		}

		private void LoadUsersDetails()
		{
			dgUsersDetails.Visible = true;
			btnAddNewUser.Visible=true;
			tblUserDetailsForm.Visible = false;			
			try
			{
				object[] currentUsers = Global.objUserManagement.ListCurrentUsers("");
				DataTable dataTableWithUserDetails= new DataTable();
				dataTableWithUserDetails.Columns.Add("UserID");
				dataTableWithUserDetails.Columns.Add("UserName");
				dataTableWithUserDetails.Columns.Add("LoginID");
				dataTableWithUserDetails.Columns.Add("UserAccounts");
				foreach (object currentUser in currentUsers)
				{					
					object[] userDetails = Global.objUserManagement.GetUserDetail_using_userName("",currentUser.ToString());
					string userID = ((decimal)userDetails[0]).ToString();
					string loginID = (string)userDetails[2];
					object[] userAccounts = Global.objAccountManagement.GetUserAccounts_using_UserID("",userID);
					string normalizedUserAccounts = "";
					foreach(object userAccount in userAccounts)
					{
						normalizedUserAccounts += userAccount + " <br>";
					}
					dataTableWithUserDetails.Rows.Add(new object[4] {	userID ,currentUser,loginID , normalizedUserAccounts});	
				}						
				dgUsersDetails.DataSource = dataTableWithUserDetails;
				dgUsersDetails.DataBind();					
			}
			catch (Exception Ex)
			{
				lblErrorMessage.Text = Ex.Message;
			}
		}
	
		public void processPageCommands(object oss,DataGridCommandEventArgs e)
		{			
			
			switch (e.CommandName)
			{
				case "NewUser":
				{
					lblPageTitle.Text = "New User";
					break;
				}
				case "EditUser":
				{
					lblPageTitle.Text = "Edit User";
					dgUsersDetails.Visible = false;
					btnAddNewUser.Visible = false;
					tblUserDetailsForm.Visible=true;
					break;
				}
				case "DeleteUser":
				{
					try
					{						
						if ( Global.objUserManagement.DeleteUser("",e.Item.Cells[0].Text) > 0)
						{							
							lblErrorMessage.Text= "User '" + e.Item.Cells[1].Text+ "' deleted";
							LoadUsersDetails();
						}
						else   
						{
							lblErrorMessage.Text= "Error deleting user '" + e.Item.Cells[0].Text+ "'";
						}
					}
					catch(Exception Ex)
					{
						lblErrorMessage.Text=Ex.Message;
					}
					break;
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

		protected void btnAddNewUser_Click(object sender, System.EventArgs e)
		{
			lblPageTitle.Text = "Add new User";
			dgUsersDetails.Visible = false;
			tblUserDetailsForm.Visible = true;
			btnAddNewUser.Visible=false;
		}

		protected void btnSubmitUserDetails_Click(object sender, System.EventArgs e)
		{
			Global.objUserManagement.CreateUser("",txtUsername.Text,txtLoginID.Text,txtUserPassword.Text);
			LoadUsersDetails();
		}
	}
}
