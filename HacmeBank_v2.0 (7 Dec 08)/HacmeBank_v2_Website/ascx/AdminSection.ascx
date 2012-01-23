<%@ Control Language="c#" AutoEventWireup="True" CodeFile="AdminSection.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.AdminSection" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
	<tr bgcolor="#d2dae4">
		<td><b>Admin Section Login</b></td>
	</tr>
	<tr>
		<td height="100">
			<asp:label id="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:label>
			<table border="0" cellpadding="6">
				<tr>
					<td>
						<asp:label id="lblChallenge" runat="server" Width="117px" CssClass="label1">Challenge</asp:label>
					</td>
					<td>
						<asp:textbox id="txtChallenge" runat="server" CssClass="txtBox2" TextMode="SingleLine" tabIndex="1"
							Enabled="False">123312345</asp:textbox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:label id="lblResponse" runat="server" Width="117px" CssClass="label1">Response</asp:label>
					</td>
					<td>
						<asp:textbox id="txtResponse" runat="server" CssClass="txtBox2" TextMode="SingleLine" tabIndex="2"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<asp:button id="btnLoginAdminSection" tabIndex="2" runat="server" CssClass="butnstyle2" Width="106px"
							Height="20px" Text="Login" OnClick="btnLoginAdminSection_Click"></asp:button>
						<asp:Label id="lblResponseValue" runat="server" Visible="False">ResponseValue</asp:Label>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
