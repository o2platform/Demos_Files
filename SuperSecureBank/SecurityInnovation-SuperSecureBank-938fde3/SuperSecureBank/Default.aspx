<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="Default.aspx.cs" Inherits="SuperSecureBank._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<asp:Panel runat="server" ID="Anon">
		<h2>
			Get started with online banking
		</h2>
		<div>
			With our secure online banking solution you can:
			<ul>
				<li>View Account Balances</li>
				<li>Transfer funds to other accounts</li>
				<li>Open a new account</li>
				<li>Apply for a line of credit</li>
				<li>Contact other bank users in the forum</li>
			</ul>
			<a href="Account/Register.aspx">Click here to register today!</a><br />
			If you're brave and would like to help us test our <a href="CreateUserTestPage.aspx">new silverlight registration control click here!</a><br />
			Or use the link in the upper right hand corner to <a href="Account/Login.aspx">login</a>.
		</div>
	</asp:Panel>
	<asp:Panel runat="server" ID="Authen">
		<div class="Action">
			<a href="ViewAccount.aspx">
				<img src="Images/balanceca6.png" alt="View Account Balances" />
				View Accounts & Balances</a></div>
		<div class="Action">
			<a href="Transfer.aspx">
				<img src="Images/MapsALT.png" alt="Transfer Funds" />
				Transfer funds to other accounts</a></div>
		<div class="Action">
			<a href="ApplyForAccount.aspx"><img src="Images/ToDo.png" alt="Open New Account" />
			Open a new account</a></div>
		<div class="Action">
			<a href="ApplyForCredit.aspx"><img src="Images/Calculator_alt.png" alt="Apply for new credit" />
			Apply for a line of credit</a></div>
		<div class="Action">
			<a href="Forum.aspx">
				<img src="Images/Mail2.png" alt="Forum" />
				Contact other bank users in the forum</a></div>
	</asp:Panel>
</asp:Content>
