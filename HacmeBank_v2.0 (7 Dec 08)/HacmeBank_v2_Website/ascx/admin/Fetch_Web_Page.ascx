<%@ Control Language="c#" AutoEventWireup="True" CodeFile="Fetch_Web_Page.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.admin.Fetch_Web_Page" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
	<tr bgcolor="#d2dae4">
		<td colspan="2"><b>Fetch Web Page</b></td>
	</tr>
	<tr>
		<td>
			<asp:TextBox id="txtWebPageUrlToFetch" runat="server" Width="408px">http://127.0.0.1/HacmeBank_v2_WS/WebServices/</asp:TextBox>
		</td>
		<td>
			<asp:Button id="btFetchWebPage" runat="server" Text="Fetch" onclick="btFetchWebPage_Click"></asp:Button>
		</td>
	</tr>
	<tr>
		<td colspan="2">
			<asp:Label id="lbWebPageContents" runat="server" />
		</td>
	</tr>
</table>
