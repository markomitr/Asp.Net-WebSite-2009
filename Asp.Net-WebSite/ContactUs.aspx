<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" Title="Untitled Page" %>

<%@ Register src="MailForma.ascx" tagname="MailForma" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="sodrzina" Runat="Server">
<div id="contactTextTel" class="Kontakti" runat="server">
</div>
<div>
    <uc1:MailForma ID="MailForma1" runat="server" />
</div> 
</asp:Content>

