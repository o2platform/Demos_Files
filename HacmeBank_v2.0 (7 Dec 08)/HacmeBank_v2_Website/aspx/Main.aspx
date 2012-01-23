<%@ Page language="c#" CodeFile="Main.aspx.cs" AutoEventWireup="True" Inherits="HacmeBank_v2_Website.Main" validateRequest=false%>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>WelcomeForm</title>
		<meta content="Microsoft Visual Studio 7.0" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<link href="../css/FoundStoneBank.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="WelComeForm" method="post" runat="server">
			<table width="664" border="1" align="center" cellpadding="0" cellspacing="0" bordercolor="#000000">
				<tr>
					<td><table border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td><img src="images/hacme_header.jpg" width="664" height="32"></td>
							</tr>
							<tr>
								<td background="images/blueheader_bg.gif" width="664" height="19">
									<asp:PlaceHolder id="ascxPlaceHolder_TopMenu" runat="server"></asp:PlaceHolder>
								</td>
							</tr>
							<tr>
								<td><table width="664" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td bgcolor="#46678e" width="154" valign="top"><p><img src="images/top_blue_menu.jpg" width="154" height="31">
													<asp:PlaceHolder id="ascxPlaceHolder_LeftMenu" runat="server"></asp:PlaceHolder></p>
											</td>
											<td width="1"><img src="images/clear.gif" width="1" height="31"></td>
											<td valign="top"><img src="images/onlinebanking.jpg" width="508" height="93">
												<table border="0" cellspacing="5" cellpadding="5">
													<tr>
														<td>
															<b>User :
																<asp:label id="lblWUserName" runat="server"></asp:label></b><br>
															<br>
															<asp:PlaceHolder id="ascxPlaceHolder_ContentArea" runat="server"></asp:PlaceHolder>
															<p>&nbsp;</p>
														</td>
													</tr>
												</table>
												<p>&nbsp;</p>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</TD></TR></TABLE>
			<asp:PlaceHolder id="ascxPlaceHolder_Footer" runat="server"></asp:PlaceHolder>
		</form>
	</body>
</HTML>
