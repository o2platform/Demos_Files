<%@ Control Language="c#" AutoEventWireup="True" CodeFile="PostMessageForm.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.PostMessageForm" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>

<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
	<tr bgcolor="#d2dae4">
		<td><b>Posted Messages</b></td>
	</tr>
	<tr>
		<td height="100">
			<asp:label id="lblPostedMessages" runat="server" CssClass=""></asp:label>
		</td>
	</tr>
</table>
<br>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
	<tr bgcolor="#d2dae4">
		<td><b>Post new Message</b></td>
	</tr>
	<tr>
	<td colspan=2>
		<asp:label id="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:label>
	</td>
	</tr>
	<tr>
		<td height="100">
			<asp:label id="lblMessage" runat="server" CssClass="label1" Width=""></asp:label>
			<table border="0" cellpadding="6">
				<tr>
					<td>
						<asp:label id="Label1" runat="server" CssClass=""> Message Subject</asp:label>
					</td>
					<td>
						<asp:textbox id="txtSubject" tabIndex="1" runat="server" CssClass="txtBox2" Width="236px" Height="20px"></asp:textbox>
					</td>
				</tr>
				<tr>
					<td>
						<asp:label id="Label2" runat="server" CssClass="">Message Text</asp:label>
					</td>
					<td>
						<asp:textbox id="txtText" tabIndex="2" runat="server" CssClass="multiText1" Width="239px"
							MaxLength="2000" TextMode="MultiLine" Height="106px"></asp:textbox>
						<asp:label id="lblError" Visible="False" Runat="server"></asp:label>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
					<td>
						<asp:button id="btnPostMessage" tabIndex="3" runat="server" CssClass="butnStyle2" Text="Post Message"
							Width="117px" onclick="btnPostMessage_Click"></asp:button>
						<asp:button id="btnNewMessage" tabIndex="4" runat="server" CssClass="butnStyle2" Text="Clear"
							Width="117px"></asp:button>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>