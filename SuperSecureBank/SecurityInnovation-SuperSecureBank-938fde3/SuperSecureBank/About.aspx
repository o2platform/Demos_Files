<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
	CodeBehind="About.aspx.cs" Inherits="SuperSecureBank.About" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
	<h2>
		About
	</h2>
	<p>
		SuperSecure bank is very much a fictional online bank. Any resemblance to any other
		bank is purely coincidental and is actually quite regrettable. This website is truly
		riddled with security vulnerabilities, do not use any aspect of this site as an
		example of how to create a secure online site. Do not reproduce any line of code
		in a production system. Any failure to do so will likely cause your entire website
		to become very insecure.
	</p>
	<p>
		That said, this site is intended to help interested people learn about common web
		vulnerabilities. Each vulnerability in this system has been seen in the wild in
		recent history. These vulnerabilities represent a wide array of potential issues
		that hackers and other malicious users may attempt to exploit. Failure to protect
		yourself against these types of issues could result in any number of myriad vulnerabilities,
		not limited to complete server compromise and data loss.
	</p>
	<p>
		I’ve created this website to help teach, if you have questions about the code, or
		how to find or fix these issues please feel free to contact me directly at: <a href="mailto:jbasirico@securityinnovation.com">
			jbasirico@securityinnovation.com</a>
	</p>
	<p>
		I hope you have as much fun breaking this site as I had creating it. Happy Hacking!
	</p>
</asp:Content>
