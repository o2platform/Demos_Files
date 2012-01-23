<%@ Register TagPrefix="HacmeBank" TagName="Footer" Src="..\ascx\_Footer.ascx" %>
<%@ Page language="c#" CodeFile="Login.aspx.cs" AutoEventWireup="True" EnableViewState="false" Inherits="HacmeBank_v2_Website.Login" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Hacme Bank</title>
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1">
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="../css/FoundStoneBank.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="664" border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000">
				<tr>
					<td><table border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td><img src="images/hacme_header.jpg" width="664" height="32"></td>
							</tr>
							<tr>
								<td><img src="images/blueheaderblank.jpg"></td>
							</tr>
							<tr>
								<td><table width="664" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td bgcolor="#46678e" width="154" valign="top"><p><img src="images/top_blue_menu.jpg" width="154" height="31"><br>
												</p>
												<table width="145" border="0" cellspacing="0" cellpadding="0" align="center">
													<tr>
														<td><img src="images/login/top.gif" width="145" height="21"></td>
													</tr>
													<tr>
														<td background="images/login/topbg.gif"><table width="130" border="0" cellspacing="3" cellpadding="3">
																<tr>
																	<td><b>Username:</b></td>
																	<td><asp:textbox id="txtUserName" tabIndex="1" runat="server" CssClass="txtBox2" Width="60px"></asp:textbox></td>
																</tr>
																<tr>
																	<td><b>Password:</b></td>
																	<td><asp:textbox id="txtPassword" tabIndex="2" runat="server" CssClass="txtBox2" Width="60px" TextMode="Password">a</asp:textbox></td>
																</tr>
																<tr>
																	<td><asp:label id="lblResult" runat="server" Width="60px" CssClass="errorMessage"></asp:label></td>
																	<td><asp:button id="btnSubmit" tabIndex="3" runat="server" CssClass="loginbutton" Width="60px" Text="Submit" onclick="btnSubmit_Click"></asp:button></td>
																</tr>
															</table>
														</td>
													</tr>
													<tr>
														<td><img src="images/login/bottom.gif" width="145" height="6"></td>
													</tr>
												</table>
												<p>&nbsp;</p>
											</td>
											<td width="1"><img src="images/clear.gif" width="1" height="31"></td>
											<td><img src="images/onlinebanking.jpg" width="508" height="93">
												<table width="500" border="0" cellspacing="6" cellpadding="6" align="center">
													<tr>
														<td><b>Hacme Bank is a software security training application provided by Foundstone, 
																Inc.</b>
															<BR>
															<BR>
															This application is designed to teach application developers, programmers, 
															architects and security professionals how to create secure software. Hacme Bank 
															was designed with known vulnerabilities which allow users to see real exploits 
															and to demonstrate how to build more secure software. This application is 
															provided for free and is limited to Foundstone's Terms of Use and may not be 
															used for commercial purposes</td>
													</tr>
												</table>
												<asp:Label ID=lbXmlInformation Runat="server"></asp:Label>												
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			<HacmeBank:Footer runat="server" ID="Footer" />
		</form>
	</body>
</HTML>
