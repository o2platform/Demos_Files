<%@ Page language="c#" Debug="true"%>
<%@ Assembly name="AspNetProcessor" %>
<%@ import namespace="Foundstone"%>
<%@ import namespace="System.Web"%>
<%@ import namespace="System.Web.Hosting"%>
<%@ import namespace="System.Runtime.Remoting"%>


<%
	loadertest();
%>

<script runat="server">

	public void loadertest()
	{
		Response.Write("Done");
//		Foundstone.AspNetProcessor host = (Foundstone.AspNetProcessor)ApplicationHost.CreateApplicationHost(typeof(Foundstone.AspNetProcessor), "/Foo", "C:\\Foundstone_Dev\\HacmeBank_Local");

		string virtualDir = "";
		string physicalDir = "C:\\Foundstone_Dev\\HacmeBank_Local\\";
		Type hostType = typeof(Foundstone.AspNetProcessor);

		string aspDir = HttpRuntime.AspInstallDirectory;
		string domainId = "ASPHOST_" +
			DateTime.Now.ToString().GetHashCode().ToString("x");
		string appName = (virtualDir + physicalDir).GetHashCode().ToString("x");
		AppDomainSetup setup = new AppDomainSetup();
		setup.ApplicationName = appName;
		setup.ApplicationBase = physicalDir+"Bin\\";
		setup.ConfigurationFile = "web.config"; // not necessary execept for debugging

		AppDomain loDomain = AppDomain.CreateDomain(domainId, null, setup);
		loDomain.SetData(".appDomain", "*");
		loDomain.SetData(".appPath", physicalDir);
		loDomain.SetData(".appVPath", virtualDir);
		loDomain.SetData(".domainId", domainId);
		loDomain.SetData(".hostingVirtualPath", virtualDir);
		loDomain.SetData(".hostingInstallDir", aspDir);
		

		ObjectHandle oh = loDomain.CreateInstance(hostType.Module.Assembly.FullName, hostType.FullName);
		// *** Save the AppDomain Reference
		Foundstone.AspNetProcessor loHost = (Foundstone.AspNetProcessor) oh.Unwrap();
		loHost.ProcessRequest("login.aspx");
					
		Response.Write(loHost.version);

		Response.Write(loHost.processedPageContents);	
	}
</script>