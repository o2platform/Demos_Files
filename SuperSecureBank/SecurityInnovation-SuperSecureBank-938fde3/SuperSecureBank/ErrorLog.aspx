<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="ErrorLog.aspx.cs" Inherits="SuperSecureBank.ErrorLog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:DataList ID="ErrorList" runat="server" DataKeyField="errorID" DataSourceID="SqlDataSource1">
		<ItemTemplate>
			<div class="error">
				<h2>
					<asp:Label ID="errorIDLabel" runat="server" Text='<%# Eval("errorID") %>' />:
					<asp:Label ID="errorTextLabel" runat="server" Text='<%# Eval("errorText") %>' /></h2>
				<br />
				time:
				<asp:Label ID="timeLabel" runat="server" Text='<%# Eval("time") %>' />
				<br />
				<asp:Label ID="exceptionLabel" runat="server" Text='<%# Eval("exception") %>' />
				<br />
				<hr />
			</div>
		</ItemTemplate>
	</asp:DataList>
	<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ssbcon %>"
		SelectCommand="SELECT * FROM [ErrorLog] ORDER BY [time] DESC"></asp:SqlDataSource>
</asp:Content>
