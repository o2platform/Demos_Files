<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="ViewAccount.aspx.cs" Inherits="SuperSecureBank.ViewAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h1>
		<img src="Images/balanceca6.png" alt="View Account Balances" />
		View Account Balances</h1>
		<br />
		<p>From this page you can view each of your accounts and balances.</p>
	<div>
		<asp:Label visible="false" ID="message" runat="server" />
		<asp:GridView ID="Accounts" runat="server" CellPadding="4" ForeColor="#333333"
			GridLines="Both" AutoGenerateColumns="False" DataKeyNames="accountID" 
			PageSize="1000" ShowFooter="True">
			<HeaderStyle BackColor="#4b6c9e" Font-Bold="True" ForeColor="White" />
			<Columns>
				<asp:BoundField DataField="accountID" HeaderText="Account ID" ReadOnly="True" 
					SortExpression="accountID" HtmlEncode="false" />
				<asp:BoundField DataField="balance" HeaderText="Balance" 
					SortExpression="balance"  HtmlEncode="false"/>
				<asp:BoundField DataField="LevelName" HeaderText="Level" 
					SortExpression="LevelName"  HtmlEncode="false"/>
				<asp:BoundField DataField="LevelDescription" HeaderText="Level Description" 
					SortExpression="LevelDescription"  HtmlEncode="false"/>
				<asp:BoundField DataField="TypeName" HeaderText="Type" 
					SortExpression="TypeName"  HtmlEncode="false"/>
				<asp:BoundField DataField="TypeDescription" HeaderText="Type Description" 
					SortExpression="TypeDescription"  HtmlEncode="false"/>
				<asp:BoundField DataField="Status" HeaderText="Current Status" 
					SortExpression="Status" HtmlEncode="false" />
			</Columns>
			<RowStyle BackColor="#FFFFFF" />
		</asp:GridView>
	</div>
</asp:Content>
