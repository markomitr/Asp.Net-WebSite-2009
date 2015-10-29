<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Sitemap.aspx.cs" Inherits="Sitemap" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<title>Info Biro - Sitemap</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sodrzina" Runat="Server">
    <div>
    <asp:SiteMapDataSource ID="SiteMapDataSource1" ShowStartingNode="true" runat="server" />       
    <asp:TreeView ID="TreeView1" runat="server" DataSourceID="SiteMapDataSource1"  ImageSet="BulletedList2" ShowExpandCollapse="False">
        <ParentNodeStyle Font-Bold="False" />
        <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
        <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" 
            HorizontalPadding="0px" VerticalPadding="0px" />
        <NodeStyle Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" 
            HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
    </asp:TreeView>
    
</div>
</asp:Content>

