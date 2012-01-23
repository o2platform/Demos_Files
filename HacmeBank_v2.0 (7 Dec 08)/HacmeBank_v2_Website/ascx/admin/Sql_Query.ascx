<%@ Control Language="c#" AutoEventWireup="True" CodeFile="Sql_Query.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.admin.Sql_Query" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
	<tr bgcolor="#d2dae4">
		<td colspan="2"><b>Sql Query</b></td>
	</tr>
	<tr>
		<td colSpan="4">
			<asp:label id="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:label>
		</td>
	</tr>
	<tr>
		<td style="WIDTH: 405px">
			<asp:DropDownList id="ddlSampleQueries" runat="server" Width="360px" AutoPostBack="True" onselectedindexchanged="ddlSampleQueries_SelectedIndexChanged">
				<asp:ListItem Value="Select * from FoundStone_Bank..fsb_accounts">Select * from FoundStone_Bank..fsb_accounts</asp:ListItem>
				<asp:ListItem Value="Select * from FoundStone_Bank..fsb_fund_transfers">Select * from FoundStone_Bank..fsb_fund_transfers</asp:ListItem>
				<asp:ListItem Value="Select * from FoundStone_Bank..fsb_loan_rates">Select * from FoundStone_Bank..fsb_loan_rates</asp:ListItem>
				<asp:ListItem Value="Select * from FoundStone_Bank..fsb_messages">Select * from FoundStone_Bank..fsb_messages</asp:ListItem>
				<asp:ListItem Value="Select * from FoundStone_Bank..fsb_transactions">Select * from FoundStone_Bank..fsb_transactions</asp:ListItem>
				<asp:ListItem Value="Select * from FoundStone_Bank..fsb_users">Select * from FoundStone_Bank..fsb_users</asp:ListItem>
				<asp:ListItem Value="Select * from FoundStone_Bank..sysObjects">Select * from FoundStone_Bank..sysObjects</asp:ListItem>
				<asp:ListItem Value="Select * from master..SysDatabases">Select * from master..SysDatabases</asp:ListItem>
				<asp:ListItem Value="Select * from master..SysObjects">Select * from master..SysObjects</asp:ListItem>
				<asp:ListItem Value="exec master..xp_cmdshell &quot;dir c:\&quot;">exec master..xp_cmdshell &quot;dir c:\&quot;</asp:ListItem>
				<asp:ListItem Value="exec master..xp_cmdshell &quot;dir c:\hacmeBank_v2&quot;">exec master..xp_cmdshell &quot;dir c:\hacmeBank_v2&quot;</asp:ListItem>
				<asp:ListItem Value="exec master..xp_cmdshell &quot;Net Users&quot;">exec master..xp_cmdshell &quot;Net Users&quot;</asp:ListItem>
				<asp:ListItem Value="exec master..xp_cmdshell &quot;Net&nbsp;Localgroup&nbsp;Administrators&quot;">exec master..xp_cmdshell &quot;Net Localgroup Administrators&quot;</asp:ListItem>
				<asp:ListItem Value="exec master..xp_cmdshell &quot;net&nbsp;User&nbsp;NewUser Password$&nbsp;/add&quot;">exec master..xp_cmdshell &quot;net User NewUser Password$ /add&quot;</asp:ListItem>
				<asp:ListItem Value="exec master..xp_cmdshell &quot;Net&nbsp;Localgroup&nbsp;Administrators&nbsp;NewUser&nbsp;/Add&quot;">exec master..xp_cmdshell &quot;Net Localgroup Administrators NewUser /Add&quot;</asp:ListItem>
			</asp:DropDownList>
			<asp:TextBox id="txtSqlQueryToExecute" runat="server" Width="360px" Height="75px" TextMode="MultiLine">Select * from FoundStone_Bank..fsb_accounts</asp:TextBox>
		</td>
		<td>
			<asp:Button id="btExecuteQuery" runat="server" Text="Execute Query" Height="96px" Width="99px" onclick="btExecuteQuery_Click"></asp:Button>
		</td>
	</tr>
	<tr>
		<td colspan="2">
			<asp:datagrid id="dgQueryResult" Width="450px" runat="server" AutoGenerateColumns="False" Height="60px"
				GridLines="Horizontal" ForeColor="Black" BackColor="Beige" AlternatingItemStyle-BackColor="Gainsboro"
				HeaderStyle-BackColor="#C0C0C0" HeaderStyle-Font-Bold="True">
				<Columns></Columns>
			</asp:datagrid>
		</td>
	</tr>
</table>
