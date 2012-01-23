<%@ Control Language="c#" AutoEventWireup="True" CodeFile="Loan.ascx.cs" Inherits="HacmeBank_v2_Website.ascx.Loan" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<table border="1" cellspacing="0" cellpadding="4" bordercolor="#899db1">
	<tr bgcolor="#d2dae4">
		<td><b>Request a Loan
				<asp:label id="lblHeading" runat="server" CssClass=""></asp:label></b></td>
	</tr>
	<tr>
		<td height="100">
			<table border="0">
				<tr>
					<td colSpan="4">
						<asp:label id="lblMessg" runat="server" CssClass="errorMessage"></asp:label>
						<asp:label id="lblConfirmMessage" runat="server" Height="24px" Width="443px" CssClass="label1"
							Visible="False"></asp:label>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 161px" vAlign="top"><asp:label id="lblCreditAccNo" runat="server" Height="24px" Width="135px">Credit Account No.</asp:label></td>
					<td vAlign="top" colSpan="3"><asp:dropdownlist id="drpdwnCreditAccNo" tabIndex="1" runat="server" Height="20px" CssClass="drpDown2"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td style="WIDTH: 161px"><asp:label id="lblLoanAmount" runat="server" Height="24px" Width="135px">Loan Amount</asp:label></td>
					<td colSpan="1"><asp:textbox id="txtAmount" runat="server" CssClass="txtBox2" MaxLength="9"></asp:textbox>
					</td>
					<td><asp:label id="lblUSD" runat="server">USD</asp:label></td>
					<td>
						<asp:rangevalidator id="RangeValidator1" runat="server" Height="23px" Width="160px" CssClass="errorMessage"
							ErrorMessage="Error : Invalid Amount" ControlToValidate="txtAmount" ForeColor=" " MinimumValue="0"
							MaximumValue="9999999.99"></asp:rangevalidator>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 161px"><asp:label id="lblLoanPeriod" runat="server" Height="24px" Width="135px">Loan Period</asp:label></td>
					<td colSpan="3"><asp:dropdownlist id="drpdwnLoanPeriodAndInterestRate" tabIndex="4" runat="server" Height="24px" Width="67px"
							CssClass="drpDown2" AutoPostBack="True" onselectedindexchanged="drpdwnLoanPeriodAndInterestRate_SelectedIndexChanged"></asp:dropdownlist>
						<asp:label id="lblYears" runat="server">Yrs.</asp:label></td>
				</tr>
				<tr>
					<td style="WIDTH: 161px"><asp:label id="lblRateofInterest" runat="server" Height="24" Width="99px">Rate of Interest</asp:label></td>
					<td colSpan="3"><asp:label id="lblRate_Of_Interest" runat="server" Height="24px" Width="58px">&nbsp</asp:label>
						<asp:label id="lblPercentage" runat="server" Height="24" Width="11px">%</asp:label>
					</td>
				</tr>
				<tr>
					<td style="WIDTH: 161px">Comment</td>
					<td colSpan="3"><asp:TextBox id="txtComment" tabIndex="4" runat="server" CssClass="txtBox2" Height="40" Width="320px"
							Rows="4" TextMode="MultiLine"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 161px">&nbsp;</td>
					<td colSpan="3">
						<asp:button id="btnSubmit" tabIndex="5" runat="server" Height="20px" Width="106px" CssClass="butnstyle2"
							Text="Submit" onclick="btnSubmit_Click"></asp:button>
						<INPUT id="hlblCreditAccNo" type="hidden" size="8" name="hlblCreditAccNo" runat="server">
						<INPUT id="hlblDebitAccNo" type="hidden" size="6" name="hlblDeditAccNo" runat="server">
						<INPUT id="hlblRate_Of_Interest" type="hidden" size="8" name="hlblRate_Of_Interest" runat="server">
					</td>
				</tr>
			</table>
		</td>
	</tr>
</table>
