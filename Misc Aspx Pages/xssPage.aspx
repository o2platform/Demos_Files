<%@ Page Language="C#" ValidateRequest ="false"%>
<html>	
	<body>
			<h2> this is a page with XSS</h2>
			<a href="xssPage.aspx?xss=<h3>here</h3>">show xss</a>
			<%= Request["xss"]  %> <br>
	</body>
</html>