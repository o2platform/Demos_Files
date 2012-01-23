<%@ Control Language="c#" AutoEventWireup="True" CodeFile="AccountTransfer.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.AccountTransfer" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1" width="485">
	<tr bgcolor="#d2dae4">
		<td><b>Transfer Funds</b></td>
	</tr>
	<tr>
		<td height="100">
			<asp:label id="lblErrorMessage" runat="server" CssClass="errorMessage"></asp:label>
			<asp:label id="lblMessage" runat="server" CssClass="errorMessage"></asp:label>
			<table border="0">
				<tr valign="top">
					<td>Source</td>
					<td><asp:dropdownlist id="drpdwnSourceAcc" tabIndex="1" runat="server" CssClass="drpDown2" Width="152px"></asp:dropdownlist>
						<br>
						<br>
					</td>
				</tr>
				<tr>
					<td valign="top">Destination</td>
					<td>
						<table width="100%" cellpadding="0" cellspacing="0">
							<tr>
								<td style="WIDTH: 157px">
									<asp:dropdownlist id="drpdwnDestinationAcc" tabIndex="1" CssClass="drpDown2" runat="server" Width="152px"></asp:dropdownlist>
								</td>
								<TD>
									<asp:RadioButton id="rbInternalPayment" runat="server" Text="Internal Account" GroupName="InternalOrExternalPayment"
										Checked="True"></asp:RadioButton>
								</TD>
							</tr>
							<tr>
								<td style="WIDTH: 157px" valign="top">
									<asp:TextBox id="txtExternalPaymentAccount" CssClass="txtBox2" runat="server" Width="152px"></asp:TextBox>
								</td>
								<TD valign="top">
									<asp:RadioButton id="rbExternalPayment" runat="server" Text="External Account" GroupName="InternalOrExternalPayment"></asp:RadioButton>
									<asp:rangevalidator id="Rangevalidator1" runat="server" CssClass="errorMessage" MinimumValue="0" MaximumValue="999999999999999999"
										ForeColor=" " ErrorMessage="Error : Invalid Account Number" ControlToValidate="txtExternalPaymentAccount"
										Type="Double"></asp:rangevalidator></TD>
							</tr>
						</table>
					</td>
				</tr>
				<TR>
					<TD>Amount</TD>
					<TD>
						<asp:textbox id="txtAmt" tabIndex="3" CssClass="txtBox2" runat="server" Width="152px">100</asp:textbox>
						<asp:rangevalidator id="rvfCheckAmount" runat="server" CssClass="errorMessage" MinimumValue="1" MaximumValue="10000"
							ForeColor=" " ErrorMessage="Error : Enter positive integer value" ControlToValidate="txtAmt" Type="Double"></asp:rangevalidator></TD>
				</TR>
				<tr>
					<td>Comment</td>
					<td><asp:TextBox id="txtComment" tabIndex="4" runat="server" CssClass="txtBox2" Height="40" Width="392px"
							Rows="4" TextMode="MultiLine"></asp:TextBox></td>
				</tr>
				<!--				
				<tr>
					<td>&nbsp;</td>
					<td>
						Transfers within the same account are not permitted</td>
				</tr>
-->
				<tr>
					<td>&nbsp;</td>
					<td>
						<asp:button id="btnTransfer" tabIndex="5" runat="server" CssClass="butnstyle2" Width="106px"
							Text="Transfer" Height="20px" onclick="btnTransfer_Click"></asp:button>
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
