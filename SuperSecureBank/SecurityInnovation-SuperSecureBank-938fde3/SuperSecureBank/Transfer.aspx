<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Transfer.aspx.cs" Inherits="SuperSecureBank.Transfer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		.style1
		{
			width: 183px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h1>
		<img src="Images/MapsALT.png" alt="Transfer Funds" />
		Transfer funds to other accounts</h1>
	<div>
		<asp:Label ID="message" runat="server" /><br />
		<table style="width: 437px">
			<tr>
				<td class="style1">
					From Account:
				</td>
				<td>
					<asp:DropDownList ID="FromAccount" runat="server" Width="250px">
					</asp:DropDownList>
				</td>
			</tr>
			<tr>
				<td class="style1">
					To Account:
				</td>
				<td>
					<asp:TextBox ID="ToAccount" runat="server" Width="250px"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td class="style1">
					Amount to Transfer:
				</td>
				<td>
					<asp:TextBox ID="AmountToTransfer" runat="server" Width="250px"></asp:TextBox>
				</td>
			</tr>
			<tr>
				<td colspan="2">
					<asp:Button ID="DoTransfer" runat="server" Text="Submit Transfer" OnClick="DoTransfer_Click" />
				</td>
			</tr>
		</table>
		<br />
		<br />
		<br />
	</div>
</asp:Content>
