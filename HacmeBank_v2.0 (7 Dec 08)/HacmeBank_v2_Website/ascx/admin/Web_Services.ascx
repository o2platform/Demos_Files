<%@ Control Language="c#" AutoEventWireup="True" CodeFile="Web_Services.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.WebServices" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485" height=400>
	<tr bgcolor="#d2dae4" height=10>
		<td colspan=3><b>Web Services</b></td>
	</tr>
	<tr height="10">
		<td>	
			<A href="/HacmeBank_v2_WS/WebServices/AccountManagement.asmx" target="Iframe_WebServices">AccountManagement.asmx</A>
		</td>	
		<td>
			<A href="/HacmeBank_v2_WS/WebServices/UserManagement.asmx" target="Iframe_WebServices">UserManagement.asmx</A>
		</td>	
		<td>
			<A href="/HacmeBank_v2_WS/WebServices/UsersCommunity.asmx" target="Iframe_WebServices">UsersCommunity.asmx</A>
		</td>	
	</tr>
	<tr>
		<td colspan=3>
			<iframe name="Iframe_WebServices"  width="100%" height="100%"/>
		</td>
	</tr>
</table>

