
<script  runat="server">
Sub Page_Load
   link1.HRef="http://www.w3schools.com/?value=" + Request("payload")
   link1.Target="_blank"
   link1.Title="W3Schools"

   link2.HRef="http://www.microsoft.com"
   link2.Target="_blank"
   link2.Title="Microsoft"
End Sub
</script>

<html>
<body>

<form runat="server">
<a id="link1" runat="server">Visit W3Schools!</a>
<br />
<a id="link2" runat="server">Visit Microsoft!</a>
</form>

</body>
</html>