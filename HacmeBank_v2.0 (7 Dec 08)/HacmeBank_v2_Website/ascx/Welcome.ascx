<%@ Control Language="c#" AutoEventWireup="True"  CodeFile="Welcome.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.Welcome" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
	<tr bgcolor="#d2dae4">
		<td><b>Welcome</b></td>
	<tr>
		<td height="100">
			<asp:label id="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:label>
			Thank you for banking with Hacme Bank.
		</td>
	</tr>
</table>
