<%@ Control Language="c#" AutoEventWireup="True" CodeFile="Manage_Messages.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.AdminManageMessages" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
	<tr bgcolor="#d2dae4">
		<td><b>Manage Messages</b></td>
	</tr>
	<tr>
		<td colspan="2">
			<asp:label id="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:label>
		</td>
	</tr>
	<tr>
		<td height="100">
			<asp:label id="lblPostedMessages" runat="server" CssClass=""></asp:label>
			<asp:datagrid id="dgPostedMessages" runat="server" Width="450px" GridLines="Horizontal" AutoGenerateColumns="False"
				OnItemCommand="DeleteMessage" Height="56px">
				<Columns>
					<asp:BoundColumn DataField="messageID" HeaderText="Message ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="userID" HeaderText="User ID"></asp:BoundColumn>
					<asp:BoundColumn DataField="messageDate" HeaderText="Message Date"></asp:BoundColumn>
					<asp:BoundColumn DataField="messageSubject" HeaderText="Message Subject"></asp:BoundColumn>
					<asp:BoundColumn DataField="messageText" HeaderText="Message Text"></asp:BoundColumn>
					<asp:ButtonColumn Text="Delete Message" CommandName="Delete Message"></asp:ButtonColumn>
				</Columns>
			</asp:datagrid>
		</td>
	</tr>
</table>
