<%@ Control Language="c#" AutoEventWireup="True" CodeFile="Manage_Accounts.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.admin.Manage_Accounts" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
	<tr bgcolor="#d2dae4">
		<td colspan="2"><b>Manage Accounts</b> <br>[NOTE: in this version only the Add New Account funcionality is completed</td>
	</tr>
		<tr>
		<td colspan="2">
			<asp:label id="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:label>
		</td>
	</tr>
	<tr>
		<td>
			<asp:Table ID="tblUserDetailsForm" Runat="server" Visible="true">
				<asp:TableRow>
					<asp:TableCell>Account Number <br/>(only numbers allowed): </asp:TableCell>
					<asp:TableCell>
						<asp:TextBox ID="txtAccountNumber" Runat="server" />
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell>User: </asp:TableCell>
					<asp:TableCell>
						<asp:DropDownList ID="ddlUserIDs" Runat="server">							
						</asp:DropDownList>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell>Account Currency: </asp:TableCell>
					<asp:TableCell>
						<asp:TextBox ID="txtAccountCurrency" Runat="server" Enabled="False">USD</asp:TextBox>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell>Account Branch: </asp:TableCell>
					<asp:TableCell>
						<asp:TextBox ID="txtAccountBranch" Runat="server">New York</asp:TextBox>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell>Account Inital Balance: </asp:TableCell>
					<asp:TableCell>
						<asp:TextBox ID="txtAccountInitialBalance" Runat="server" enabled="False">0</asp:TextBox>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell>Account Type: </asp:TableCell>
					<asp:TableCell>
						<asp:DropDownList ID="ddlAccountType" Runat="server">
							<asp:ListItem Value="Gold" Selected="True">Gold</asp:ListItem>
							<asp:ListItem Value="Platinum">Platinum</asp:ListItem>
							<asp:ListItem Value="Silver">Silver</asp:ListItem>
						</asp:DropDownList>
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
						<asp:Button Runat="server" ID="btnCreateNewAccount" Text="Create New Account" onclick="btnCreateNewAccount_Click" />
					</asp:TableCell>
				</asp:TableRow>
			</asp:Table>			
		</td>
	</tr>
</table>
