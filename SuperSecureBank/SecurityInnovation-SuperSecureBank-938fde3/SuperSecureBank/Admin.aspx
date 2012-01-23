<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Admin.aspx.cs" Inherits="SuperSecureBank.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Admin Page</h1>
    <div>
        Hopefully you found this page through forceful browsing, but it's mostly just for
        making the site easy to reset if things get too wonky. Feel free to reset tables
        if need be.</div>
    <div>
        <asp:Button ID="ResetComments" Text="Reset Forum Comments" runat="server" 
            onclick="ResetComments_Click" /><br />
        <asp:Button ID="ResetSesions" Text="Reset Sessions" runat="server" 
            onclick="ResetSesions_Click" />
    </div>
</asp:Content>
