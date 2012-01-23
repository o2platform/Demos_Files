<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="ExecuteSQL.aspx.cs" Inherits="SuperSecureBank.ExecuteSQL" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:Label ID="message" runat="server" />
	Be _very _very careful with this.
	<asp:TextBox ID="SecretPhrase" runat="server" Width="100%" TextMode="Password"></asp:TextBox>
	<asp:TextBox ID="SQLCommand" runat="server" TextMode="MultiLine" Width="100%" Height="394px"></asp:TextBox>
	<asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
	<hr />
	<asp:Label ID="output" runat="server"></asp:Label>
	<asp:GridView ID="outputGrid" runat="server" CellPadding="4" ForeColor="#333333"
		GridLines="None">
		<RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
		<FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
		<PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
		<SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
		<HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
		<EditRowStyle BackColor="#999999" />
		<AlternatingRowStyle BackColor="White" ForeColor="#284775" />
	</asp:GridView>
</asp:Content>
