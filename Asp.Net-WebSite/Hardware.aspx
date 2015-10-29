<%@ Page Language="C#" MasterPageFile="~/HardSoft.master" AutoEventWireup="true" CodeFile="Hardware.aspx.cs" Inherits="Hardware" %>
<%@ MasterType VirtualPath="~/HardSoft.master"  %>
<%@ Register Src="~/NovostiBarControl.ascx" TagName="NovostiBarControl" TagPrefix="nasi" %>
<%@ Register Src="~/ProizvodControl.ascx" TagName="ProizvodControl" TagPrefix="nasi" %>
<%@ Reference Control="~/ProizvodControl.ascx"  %>
<asp:Content ID="head2CPHID" ContentPlaceHolderID="head2CPH" Runat="Server">
<style>
* {
  margin: 0;
  padding: 0;
  border: 0;
}
</style>
</asp:Content>
<asp:Content ID="HardwareLeftCPHID" ContentPlaceHolderID="leftCPH" Runat="Server">
    <ul id="meniHardware" class="HardmeniHul" runat="server">
   </ul>
</asp:Content>
<asp:Content ID="HardwareCenterCPHID" ContentPlaceHolderID="centerCPH" Runat="Server">
</asp:Content>

