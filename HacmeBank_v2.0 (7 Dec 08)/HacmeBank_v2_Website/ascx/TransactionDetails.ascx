<%@ Control Language="c#" AutoEventWireup="True" CodeFile="TransactionDetails.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.TransactionDetails" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table borderColor="#899db1" cellSpacing="0" cellPadding="4" border="1">
	<tr bgColor="#d2dae4">
		<td><b><asp:label id="lblHeading1" BorderStyle="None" CssClass="" Runat="server" Width="">Transaction Details</asp:label></b></td>
	</tr>
	<tr>
		<td height="100" valign="top">
		<asp:label id="lblContactNo" CssClass="label1" Width="" runat="server"></asp:label><asp:label id="lblErrorMessage" CssClass="errorMessage" runat="server"></asp:label>
		<asp:datagrid id="dg_AccountBal" Width="450px" runat="server" AutoGenerateColumns="False" Height="60px">
				<Columns>
					<asp:BoundColumn DataField="transaction_id" HeaderText="SL No" HeaderStyle-Wrap="False" ItemStyle-Wrap="False"></asp:BoundColumn>
					<asp:BoundColumn DataField="transaction_date" HeaderText="Date" ItemStyle-Wrap="False"></asp:BoundColumn>
					<asp:BoundColumn DataField="description" HeaderText="Description" ItemStyle-Width="150px" ItemStyle-Wrap="False"></asp:BoundColumn>
					<asp:BoundColumn DataField="transaction_mode" HeaderText="CR/DR"></asp:BoundColumn>
					<asp:BoundColumn DataField="transaction_amount" HeaderText="Amount(USD)" ItemStyle-HorizontalAlign="Left" 
 ItemStyle-Width="80px" ItemStyle-Wrap="False"></asp:BoundColumn>
				</Columns>
			</asp:datagrid>
		</td>
	</tr>
</table>
