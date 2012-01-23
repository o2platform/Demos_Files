<%@ Control Language="c#" AutoEventWireup="True" CodeFile="PasswordChange.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.PasswordChange" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
	<tr bgcolor="#d2dae4">
		<td><b>Change Password</b></td>
	</tr>
	<tr>
		<td height="100">
			<asp:label id="lblMessage" runat="server" CssClass="label1" Width=""></asp:label>
			<asp:label id="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:label>
			<table border="0" cellpadding="6">
				<tr>
					<td>
						<asp:label id="lblOldPassword" runat="server" Width="117px" CssClass="label1">Old Password</asp:label>
					</td>
					<td>
						<asp:textbox id="txtOldPassword" runat="server" CssClass="txtBox2" TextMode="Password" tabIndex="1"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:label id="lblNewPassword" runat="server" Width="117px" CssClass="label1">New Password</asp:label>
					</td>
					<td>
						<asp:textbox id="txtNewPassword" runat="server" CssClass="txtBox2" TextMode="Password" tabIndex="2"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:label id="lblConformPassword" runat="server" Width="117px" CssClass="label1">Confirm Password</asp:label>
					</td>
					<td>
						<asp:textbox id="txtConfirmPassword" runat="server" CssClass="txtBox2" TextMode="Password" tabIndex="2"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<asp:button id="btnSubmit" tabIndex="2" runat="server" CssClass="butnstyle2" Width="106px" Height="20px"
							Text="Submit" onclick="btnSubmit_Click"></asp:button>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
