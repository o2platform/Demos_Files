<%@ Control Language="c#" AutoEventWireup="True" CodeFile="MyAccountForm.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.MyAccountForm" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1">
	<tr bgcolor="#d2dae4">
		<td><b>
				<asp:label id="lblHeading1" Width="" Runat="server" CssClass="" BorderStyle="None">My Account Information</asp:label>
			</b>
		</td>
	</tr>
	<tr>
		<td height="100">
			<asp:label id="lblContactNo" runat="server" CssClass="label1" Width=""></asp:label>
			<asp:label id="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:label>
			<asp:label id="lblHeading2" Width="" Runat="server" CssClass="">Please click on the links to transact further</asp:label><br>
			<br>
			<asp:datagrid id="dgAccountDetails" runat="server" Width="450px" GridLines="Horizontal" AutoGenerateColumns="False"
				OnItemCommand="Display_Account_Data" Height="56px">
				<Columns>
					<asp:BoundColumn DataField="account_no" HeaderText="Account No"></asp:BoundColumn>
					<asp:BoundColumn DataField="branch" HeaderText="Branch"></asp:BoundColumn>
					<asp:BoundColumn DataField="account_type" HeaderText="Account Type"></asp:BoundColumn>
					<asp:BoundColumn DataField="account_balance" HeaderText="Current Balance"></asp:BoundColumn>
					<asp:ButtonColumn Text="View Transactions" CommandName="DisplayMessage"></asp:ButtonColumn>
				</Columns>
			</asp:datagrid>
		</td>
	</tr>
</table>
