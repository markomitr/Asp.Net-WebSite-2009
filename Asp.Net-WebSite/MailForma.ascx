<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MailForma.ascx.cs" Inherits="MailForma" %>
<style type="text/css">
    .style1
    {
        width:auto;
        height: auto;
    }
</style>
<table class="style1">
    <tr>
        <td class="style1">
            <asp:Label ID="imeLbl" runat="server" Text="Ime"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="imeTxtbox" runat="server"></asp:TextBox>
        </td>
        <td class="style1">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="kompanijaLbl" runat="server" Text="Kompanija"></asp:Label>
        </td>
        <td class="style1">
            <asp:TextBox ID="kompanijaTxtbox" runat="server"></asp:TextBox></td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label></td>
        <td class="style1">
            <asp:TextBox ID="emailTxtbox" runat="server" CausesValidation="True"></asp:TextBox>            
            <asp:RegularExpressionValidator ID="emailRegularExpressionValidator" runat="server" 
                ControlToValidate="emailTxtbox" ErrorMessage="*e-mail" 
                SetFocusOnError="True" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="emailRequiredFieldValidator" runat="server" 
                ControlToValidate="emailTxtbox" ErrorMessage="*e-mail" 
                EnableClientScript="False"></asp:RequiredFieldValidator>
            </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="subjcetLbl" runat="server" Text="Predmet"></asp:Label></td></td>
        <td class="style1">
        <asp:TextBox ID="subjectTxtbox" runat="server"></asp:TextBox>
        </td>
        <td class="style1">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style1" valign="top">
            <asp:Label ID="porakaLbl" runat="server" Text="Poraka"></asp:Label><br />
            <asp:Label ID="statusLbl" runat="server" Text="Status" Font-Bold="True" 
                ForeColor="#003399"></asp:Label>
        </td>
        
        <td class="style1">
            <asp:TextBox ID="sodrzinaTxtbox" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
        
        <td valign="bottom">
            <asp:Button ID="sendBtn" runat="server" onclick="sendBtn_Click" Text="Button" CssClass="kopceMailForma" />
        </td>
    </tr>
</table>
