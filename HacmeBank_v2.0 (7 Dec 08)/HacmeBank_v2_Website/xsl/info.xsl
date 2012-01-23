<?xml version="1.0" encoding="ISO-8859-1"?>
<!-- Edited with XML Spy v4.2 -->
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
 <xsl:template match="/">
   <html>
    <body>


  <table width="100%" border="0">
 	<tr>
 		<td>
			<table width="500" border="0" cellspacing="6" cellpadding="6" align="center">
			
			<tr><td>
					<table width="100%" border="0" cellspacing="0" cellpadding="0" >
					    <tr>
					      <td colspan="3" height="20"><strong>Foundstone Security Training</strong> <img src="images/red_arrows.gif"></img></td>
			      			</tr>
						<tr align="left" height="20">
							<td width="20%" background="images/rowheader_bg.gif" class="bluebox">Date</td>
							<td width="40%" background="images/rowheader_bg.gif" class="bluebox">Location</td>
							<td width="40%" background="images/rowheader_bg.gif" class="bluebox">Course</td>
						</tr>
						<tr><td  colspan="3" height="5"> </td></tr>
						<xsl:for-each select="adv/advertise/courseschedule">
							<tr align="left">
								<td><xsl:value-of select="date"/></td>
								<td><xsl:value-of select="location"/></td>
								<td><a href='http://www.foundstone.com/education/calendar.htm' target="_blank"><xsl:value-of select="title"/></a></td>

							</tr>
							<tr><td  colspan="5"><hr></hr></td></tr>
						</xsl:for-each>
					</table>
				</td>
			</tr>
			</table>
 		</td>
 		</tr>
 </table>
 
  <table width="100%" border="0">
  	<tr>
  		<td>
 	
  			 			
 			<table width="500" border="0" cellspacing="6" cellpadding="6" align="center">
 			
 			<tr><td>
 					<table width="100%" border="0" cellspacing="0" cellpadding="0" >
 					    <tr>
 					      <td colspan="5" height="20"><strong>Foundstone News</strong><img src="images/red_arrows.gif"></img></td>
 			      			</tr>
 						<tr align="left" height="20">
 							<td  colspan="5" background="images/rowheader_bg.gif" class="bluebox">News Items</td>
 						</tr>
 						<tr><td  colspan="5" height="5"> </td></tr>
  						<xsl:for-each select="adv/advertise/othernews">
  							<tr align="left">
  								<td><a href="http://www.foundstone.com/company/newsroom.htm" target="_blank"><xsl:value-of select="newitem"/></a></td>
  								</tr>
  							<tr><td  colspan="5"><hr></hr></td></tr>
  						</xsl:for-each>
 					</table>
 				</td>
 			</tr>
 			</table> 			
  		</td>
  		</tr>
 </table>
 <table width="100%" border="0">
 	<tr>
 		<td>
 			
 			
			<table width="500" border="0" cellspacing="6" cellpadding="6" align="center">
			
			<tr><td>
					<table width="100%" border="0" cellspacing="0" cellpadding="0" >
					    <tr>
					      <td colspan="5" height="20"><strong>Foundstone S3i Free Tools</strong><img src="images/red_arrows.gif"></img></td>
			      			</tr>
						<tr align="left" height="20">
							<td width="25%" background="images/rowheader_bg.gif" class="bluebox">Title</td>
							<td width="75%" background="images/rowheader_bg.gif" class="bluebox">Description</td>
							
				
						</tr>
						<tr><td  colspan="5" height="5"> </td></tr>
 						<xsl:for-each select="adv/advertise/tool">
 							<tr align="left">
 								<td><a href="http://www.foundstone.com/services/overview_s3i_des.htm" target="_blank"><xsl:value-of select="title"/></a></td>
 								<td><xsl:value-of select="description"/></td>
 								
 								</tr>
 							<tr><td  colspan="5"><hr></hr></td></tr>
 						</xsl:for-each>
					</table>
				</td>
			</tr>
			</table> 			
 		</td>
 		</tr>
 </table>

 
    <table width="100%" border="0">
 	<tr>
 		<td>
 			
			<table width="500" border="0" cellspacing="6" cellpadding="6" align="center">
			
			<tr><td>
					<table width="100%" border="0" cellspacing="0" cellpadding="0" >
					    <tr>
					      <td colspan="5" height="20"><strong>Foundstone White Papers</strong><img src="images/red_arrows.gif"></img></td>
			      			</tr>
						<tr align="left" height="20">
							
							<td width="100%" background="images/rowheader_bg.gif" class="bluebox">Title</td>
							
				
						</tr>
						<tr><td  colspan="5" height="5"> </td></tr>
 						<xsl:for-each select="adv/advertise/whitepaper">
						 							<tr align="left">
						 								
						 								<td><a href="http://www.foundstone.com/resources/whitepapers.htm" target="_blank"><xsl:value-of select="title"/></a></td>
						 								
						 								</tr>
						 							<tr><td  colspan="5"><hr></hr></td></tr>
 						</xsl:for-each>
					</table>
				</td>
			</tr>
			</table>  			
 		</td>
 		</tr>
 </table>



 </body>
 </html>
 </xsl:template>
 </xsl:stylesheet>

  
  