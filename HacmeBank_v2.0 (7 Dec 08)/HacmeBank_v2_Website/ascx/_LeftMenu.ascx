<%@ Control Language="c#" AutoEventWireup="True" CodeFile="_LeftMenu.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.LeftMenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr class="menu_light">
		<td><img src="images/clear.gif" width="1" height="1"></td>
	</tr>
	<tr class="menu_dark">
		<td><table border="0" cellspacing="3" cellpadding="3">
				<tr>
					<td class="menu_dark">
						<img src="images/nav_arrows.gif">
						<asp:linkbutton id="lnkBtnFundsTransfer" onclick="lnkBtnFundsTransfer_Click" tabIndex="11" runat="server"
							CssClass="" CausesValidation="False">Transfer Funds</asp:linkbutton></td>
				</tr>
			</table>
		</td>
	</tr>
	<tr class="menu_light">
		<td><img src="images/clear.gif" width="1" height="1"></td>
	</tr>
	<tr class="menu_dark">
		<td><table border="0" cellspacing="3" cellpadding="3">
				<tr>
					<td class="menu_dark">
						<img src="images/nav_arrows.gif">
						<asp:linkbutton id="lnkBtnLoans" onclick="lnkBtnLoans_Click" tabIndex="12" runat="server" CssClass=""
							CausesValidation="False">Request a Loan</asp:linkbutton></td>
				</tr>
			</table>
		</td>
	</tr>
	
	<tr class="menu_light">
		<td><img src="images/clear.gif" width="1" height="1"></td>
	</tr>
	<tr class="menu_dark">
		<td><table border="0" cellspacing="3" cellpadding="3">
				<tr>
					<td class="menu_dark">
						<img src="images/nav_arrows.gif">
						<asp:linkbutton id="lnkBtnPostMessage" onclick="lnkBtnPostMessage_Click" tabIndex="14" runat="server" CssClass="" CausesValidation="False">Posted Messages</asp:linkbutton></td>
				</tr>
			</table>
		</td>
	</tr>

	<tr class="menu_light">
		<td><img src="images/clear.gif" width="1" height="1"></td>
	</tr>
	
	<tr class="menu_dark">
		<td><table border="0" cellspacing="3" cellpadding="3">
				<tr>
					<td class="menu_dark">
						<img src="images/nav_arrows.gif">
						<asp:linkbutton id="lnkBtnAdminSection" onclick="lnkBtnAdminSection_Click" tabIndex="14" runat="server" CssClass="" CausesValidation="False">Admin Section</asp:linkbutton></td>
				</tr>
			</table>
		</td>
	</tr>
	
	
	
	<tr class="menu_light">
		<td><img src="images/clear.gif" width="1" height="1"></td>
	</tr>	

</table>
