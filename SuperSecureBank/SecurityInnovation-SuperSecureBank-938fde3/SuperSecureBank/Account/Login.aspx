<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Login.aspx.cs" Inherits="SuperSecureBank.Account.Login" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
<script>
    function Validate() {
        var Url = "^[A-Za-z0-9]+$"
        var tempURL = document.getElementById("<%=UserName.ClientID%>").value;
        var matchURL = tempURL.match(Url);
        if (matchURL == null) {
            alert("the username doesn't seem to be valid, please try again");
            return false;
        }
        else {

            return true;
        }
    }
</script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<h2>
		Log In
	</h2>
	<p>
		Please enter your username and password.
		<a href="Register.aspx">Register</a>
		if you don't have an account.
	</p>
	<span class="failureNotification">
		<asp:Literal ID="FailureText" runat="server"></asp:Literal>
	</span>
	<asp:ValidationSummary ID="LoginUserValidationSummary" runat="server" CssClass="failureNotification"
		ValidationGroup="LoginUserValidationGroup" />
	<div class="accountInfo">
		<fieldset class="login">
			<legend>Account Information</legend>
			<p>
				<asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Username:</asp:Label>
				<asp:TextBox ID="UserName" runat="server" CssClass="textEntry"></asp:TextBox>
				<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
					CssClass="failureNotification" ErrorMessage="User Name is required." ToolTip="User Name is required."
					ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
			</p>
			<p>
				<asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
				<asp:TextBox ID="Password" runat="server" CssClass="passwordEntry" TextMode="Password"></asp:TextBox>
				<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
					CssClass="failureNotification" ErrorMessage="Password is required." ToolTip="Password is required."
					ValidationGroup="LoginUserValidationGroup">*</asp:RequiredFieldValidator>
			</p>
		</fieldset>
		<p class="submitButton">
			<asp:Button ID="LoginButton" runat="server" Text="Log In" 
				ValidationGroup="LoginUserValidationGroup" onclick="LoginButton_Click" OnClientClick="return Validate()"  />
		</p>
	</div>

	<!--Remove all test accounts before release:
		test/test
		username/password
		admin/admin-->
</asp:Content>
