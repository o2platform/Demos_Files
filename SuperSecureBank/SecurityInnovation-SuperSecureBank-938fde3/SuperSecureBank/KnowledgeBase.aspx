<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="KnowledgeBase.aspx.cs" Inherits="SuperSecureBank.KnowledgeBase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h1>
		Knowledge Base</h1>
	<p>
		This page includes a number of different articles copied from wikipedia on different
		banking practices. Please use this resource to learn more about finances.</p>
	<br />
	<ul>
		<asp:Literal ID="FileList" runat="server" />
	</ul>
	<br />
</asp:Content>
