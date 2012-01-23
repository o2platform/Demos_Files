using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using CreateUser.SSBService;

namespace CreateUser
{
	public partial class MainPage : UserControl
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private void CreateUser_Click(object sender, RoutedEventArgs e)
		{

			SSBServiceClient sbc = new SSBServiceClient();

			sbc.CreateUserCompleted += new EventHandler<CreateUserCompletedEventArgs>(CreateUserCompleted);

			try
			{
				if (!string.IsNullOrEmpty(UserName.Text))
				{
					if (Password.Password == ConfirmPass.Password)
					{
						//bugbug this service has all kinds of other methods that shouldn't be exposed like Transfer and UpdateBalance
						sbc.CreateUserAsync(UserName.Text, Email.Text, Password.Password);
					}
					else
					{
						SetError("The usernames you typed did not match");
					}
				}
				else
				{
					SetError("Please type a username.");
				}
			}
			catch (Exception ex)
			{
				SetError(ex.ToString());
			}
		}

		void CreateUserCompleted(object sender, CreateUserCompletedEventArgs e)
		{
			try
			{
				SetError("User successfully created. New User ID: " + e.Result);
			}
			catch (Exception ex)
			{
				ErrorMessage.FontSize = 8;
				ErrorMessage.TextWrapping = TextWrapping.Wrap;
				SetError("Error: " + ex.ToString());
			}
		}

		private void SetError(string message)
		{
			ErrorMessage.Visibility = System.Windows.Visibility.Visible;
			ErrorMessage.Text = message;
			ErrorOK.Visibility = System.Windows.Visibility.Visible;
			ErrorBox.Visibility = System.Windows.Visibility.Visible;
		}

		private void ErrorOK_Click(object sender, RoutedEventArgs e)
		{
			ErrorMessage.Visibility = System.Windows.Visibility.Collapsed;
			ErrorOK.Visibility = System.Windows.Visibility.Collapsed;
			ErrorBox.Visibility = System.Windows.Visibility.Collapsed;
		}
	}
}
