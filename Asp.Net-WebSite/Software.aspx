<%@ Page Trace="false" Language="C#" MasterPageFile="~/HardSoft.master" AutoEventWireup="true"
    CodeFile="Software.aspx.cs" Inherits="Software" Title="Untitled Page" MaintainScrollPositionOnPostback="true" %>
<%@ MasterType VirtualPath="~/HardSoft.master" %>
<%@ Reference Control="~/SoftwareControl.ascx"  %>
<asp:Content ContentPlaceHolderID="head2CPH" ID="Head2CPHID" runat="server">
<style>
* {
  margin: 0;
  padding: 0;
  border: 0;
}
</style>
</asp:Content>
<asp:Content ID="SoftwareLeftCPHID" ContentPlaceHolderID="leftCPH" runat="server">
    <ul class="SoftmeniHul">
        <li class="SoftmeniHli"><a href="Software.aspx?Id=1&ProductId=1"><asp:Literal runat="server" Text="<%$ Resources:Page,NaslovCfma %>"></asp:Literal></a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=2&ProductId=1"><asp:Literal runat="server" Text="<%$ Resources:Page,NaslovImos %>"></asp:Literal></a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=10&ProductId=1"><asp:Literal runat="server" Text="<%$ Resources:Page,NaslovKafana %>"></asp:Literal></a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=3&ProductId=1"><asp:Literal runat="server" Text="<%$ Resources:Page,NaslovRecepti %>"></asp:Literal></a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=4&ProductId=1"><asp:Literal runat="server" Text="<%$ Resources:Page,NaslovKadrovo %>"></asp:Literal></a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=5&ProductId=1"><asp:Literal runat="server" Text="<%$ Resources:Page,NaslovMagacinsko %>"></asp:Literal></a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=6&ProductId=1"><asp:Literal runat="server" Text="<%$ Resources:Page,NaslovOsnovniSredstva %>"></asp:Literal></a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=7&ProductId=1"><asp:Literal runat="server" Text="<%$ Resources:Page,NaslovMedicina %>"></asp:Literal></a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=8&ProductId=1"><asp:Literal runat="server" Text="<%$ Resources:Page,NaslovPopisMob %>"></asp:Literal></a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=9&ProductId=1"><asp:Literal runat="server" Text="<%$ Resources:Page,NaslovPlata %>"></asp:Literal></a></li>
<%--    <li class="SoftmeniHli"><a href="Software.aspx?Id=3&ProductId=1">Пописи со моб. уреди</a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=4&ProductId=1">Програм за малопродазба</a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=5&ProductId=1">Програм за основни средства</a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=6&ProductId=1">Програм за плати</a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=7&ProductId=1">Програм за кадрово</a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=8&ProductId=1">Програм за откуп на тутун</a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=90&ProductId=1">Програм за медицина</a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=10&ProductId=1">Програм за рецепти</a></li>
        <li class="SoftmeniHli"><a href="Software.aspx?Id=11&ProductId=1">Магацинско раб. со моб. уреди</a></li>--%>
    </ul>
</asp:Content>
<asp:Content ID="SoftwareCenterCPHID" ContentPlaceHolderID="centerCPH" runat="server">
    <div id="osnovna" class="osnovnaSoftware" style="margin: 0px;" runat="server">
        <div class="naslovAboutClients">
           <%-- <asp:Localize runat="server" Text="<%$ Resources:Sodrzina, %>"></asp:Localize> --%>
        </div> 
        <div class="tekstAboutUs software">
            <img src="Images/osnovni.jpg" />
            <asp:Localize runat="server" Text="<%$ Resources:Sodrzina,SoftwareVoved %>"></asp:Localize>
        </div>
    </div>
<div id="Programa" runat="server"></div> 
<div id="Skripta" runat="server"></div>
</asp:Content>
