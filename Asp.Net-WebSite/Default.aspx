<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" Title="Untitled Page"  %>
<%@ MasterType TypeName="MasterPage" %>
<%@ Reference Control="~/Opis.ascx"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

<style>
* {
  margin: 0;
  border: 0;
}
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sodrzina" Runat="Server">
<script src="src/jquery.cycle.all.js" type="text/javascript"></script>
<script type="text/javascript">
    $(document).ready(function() {
        $('#slikaHome').cycle({
            fx: 'fade',
            speed: 5000,
            delay: -3000
        });
    });
</script>
    <div id="slikaHome">
        <a href="News.aspx"><img src="Images/TaggyG.jpg" alt="SlikaTaggy"/></a>
        <a href="Hardware.aspx?ID=2"><img src="Images/MsiWin.jpg" alt="SlikaMsi"/></a>
        <a href="Hardware.aspx?ID=3"><img src="Images/SlikaSymbol.jpg" alt="SlikaInfoBiro"/> </a>       
    </div>
<asp:Localize ID="NaslovnaVoved" runat="server" Text="<%$ Resources:Sodrzina,NaslovnaVoved %>"></asp:Localize>
    <div id="CotrolConainer" runat="server">
    
    </div>
</asp:Content>