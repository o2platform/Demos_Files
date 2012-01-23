<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="ApplyForCredit.aspx.cs" Inherits="SuperSecureBank.ApplyForCredit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h1>
		<img src="Images/ToDo.png" alt="Open New Account" />
		Open a New Line of Credit</h1>
	<asp:Label ID="message" runat="server" />
	<p>
		Thank you for applying for a new line of credit! Please use the form below to apply,
		your case will be reviewed and if accepted you will see it in your account list.</p>
	<table border="0" cellpadding="0" cellspacing="0">
		<tr>
			<td>
				Name
			</td>
			<td>
				<asp:TextBox runat="server" ID="ApplicantName" />
			</td>
		</tr>
		<tr>
			<td>
				Account Type
			</td>
			<td>
				<asp:DropDownList ID="AccountType" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name"
					DataValueField="type">
				</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
				Level
			</td>
			<td>
				<asp:DropDownList ID="AccountLevel" runat="server" DataSourceID="SqlDataSource2"
					DataTextField="Name" DataValueField="level">
				</asp:DropDownList>
			</td>
		</tr>
		<tr>
			<td>
				Credit Limit or Loan Amount
			</td>
			<td>
				<asp:TextBox runat="server" ID="CreditAmount" />
			</td>
		</tr>
		<tr>
			<td colspan="2">
				<asp:Button Text="Submit" runat="server" ID="Submit" OnClick="Submit_Click" />
			</td>
		</tr>
	</table>
	<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ssbcon %>"
		SelectCommand="SELECT [level], [Name] FROM [AccountLevels] ORDER BY [level]">
	</asp:SqlDataSource>
	<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ssbcon %>"
		SelectCommand="SELECT * FROM [AccountTypes] WHERE IsLoan = 1"></asp:SqlDataSource>
</asp:Content>
