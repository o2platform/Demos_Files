<%@ Control Language="c#" AutoEventWireup="True" CodeFile="Manage_Users.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.Manage_Users" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table borderColor="#899db1" cellSpacing="0" cellPadding="4" width="485" border="1">
	<tr bgColor="#d2dae4">
		<td><b><asp:label id="lblPageTitle" Runat="server"></asp:label></b></td>
	</tr>
	<tr>
		<td colSpan="2"><asp:label id="lblErrorMessage" CssClass="errorMessage" runat="server"></asp:label></td>
	</tr>
	<tr>
		<td height="100" align="center">
			<asp:datagrid id="dgUsersDetails" runat="server" Width="450px" GridLines="Horizontal" AutoGenerateColumns="False"
				OnItemCommand="processPageCommands" Height="56px" ForeColor="Black" BackColor="Beige" AlternatingItemStyle-BackColor="Gainsboro"
				HeaderStyle-BackColor="#C0C0C0" HeaderStyle-Font-Bold="True" Visible="true">
				<Columns>
					<asp:BoundColumn DataField="UserID" HeaderText="User ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="UserName" HeaderText="User Name"></asp:BoundColumn>
					<asp:BoundColumn DataField="LoginID" HeaderText="Login ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="UserAccounts" HeaderText="User Accounts"></asp:BoundColumn>
					<asp:ButtonColumn Text="Delete" CommandName="DeleteUser"></asp:ButtonColumn>
				</Columns>
			</asp:datagrid>
			<!-- 
				<asp:ButtonColumn Text="Edit" CommandName="EditUser"></asp:ButtonColumn>					
			-->
			<asp:Table ID="tblUserDetailsForm" Runat="server" Visible="false">
				<asp:TableRow>
					<asp:TableCell>User Name: </asp:TableCell>
					<asp:TableCell>
						<asp:TextBox ID="txtUsername" Runat="server" />
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell>Login ID: </asp:TableCell>
					<asp:TableCell>
						<asp:TextBox ID="txtLoginID" Runat="server" />
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell>Password: </asp:TableCell>
					<asp:TableCell>
						<asp:TextBox ID="txtUserPassword" Runat="server" />
					</asp:TableCell>
				</asp:TableRow>
				<asp:TableRow>
					<asp:TableCell ColumnSpan="2" HorizontalAlign="Right">
						<asp:Button Runat="server" ID="btnSubmitUserDetails" Text="Submit" onclick="btnSubmitUserDetails_Click" />
					</asp:TableCell>
				</asp:TableRow>
			</asp:Table>
			<br>
			<asp:Button Runat="server" ID="btnAddNewUser" Text="Add New User" visible="True" onclick="btnAddNewUser_Click" />
		</td>
	</tr>
</table>
