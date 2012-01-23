<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
	CodeBehind="Forum.aspx.cs" Inherits="SuperSecureBank.Forum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>
		Welcome to the forum
	</h2>
	<p>
		Please use this page to speak with your fellow bank users. There may be some delay
		before you see your post as all posts must be validated by an administrator.
	</p>
	<div class="createNewComment">
	<h2>Post a New Comment</h2>
		<asp:TextBox ID="TitleBox" runat="server" Width="100%"></asp:TextBox>
		<br />
		<asp:TextBox ID="BodyBox" runat="server" TextMode="MultiLine" Width="100%" Height="150px"></asp:TextBox>
		<asp:HiddenField ID="Validated" Value="False" runat="server" />
		<asp:Button ID="PostComment" runat="server" Text="Post" 
			onclick="PostComment_Click" />
	</div>
	<asp:DataList ID="CommentList" runat="server" DataSourceID="SqlDataSource1" Width="100%">
		<ItemTemplate>
			<div class="postComment">
				<h3>
					<asp:Label ID="titleLabel" runat="server" Text='<%# Eval("title") %>' /></h3>
				<asp:Label ID="bodyLabel" runat="server" Text='<%# Eval("body") %>' CssClass="postCommentBody" />
				<br />
				posted at:
				<asp:Label ID="postTimeLabel" runat="server" Text='<%# Eval("postTime") %>' />
				by
				<asp:Label ID="userNameLabel" runat="server" Text='<%# Eval("userName") %>' />
				<br />
				<br />
			</div>
		</ItemTemplate>
		<SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
	</asp:DataList>
	<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ssbcon %>"
		SelectCommand="SELECT Users.userName, Comments.title, Comments.body, Comments.postTime FROM Comments INNER JOIN Users ON Comments.userID = Users.userID WHERE Comments.Validated = 1">
	</asp:SqlDataSource>
</asp:Content>
