<%@ Control Language="c#" AutoEventWireup="True" CodeFile="_TopMenu.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.Header" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>	

	<table border="0" cellpadding="0" cellspacing="0">
	  <tr>	  
	  <td><img src="images/clear.gif" width="341" height="19"></td>	  
	  <td width="140" align="left" class="blueheader"><asp:linkbutton id="lnkBtnChangePassword"  CausesValidation="False" onclick="lnkBtnChangePassword_Click" tabIndex="9" runat="server" CssClass="">Change Password</asp:linkbutton></td>
	  <td width="118" align="left" class="blueheader"><asp:linkbutton id="lnkBtnMyAccount"  CausesValidation="False" onclick="lnkBtnMyAccount_Click" tabIndex="10" runat="server" CssClass="" >My Accounts</asp:linkbutton></td>
	  <td width="77" align="left" class="blueheader"><asp:linkbutton id="lnkBtnLogOut" onclick="lnkBtnLogOut_Click" tabIndex="8" runat="server" CssClass="" CausesValidation="False" Visible="True">Logout</asp:linkbutton></td></tr>
	</table>