<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/admin.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="Form1" runat="server">
    <div id="Celo">
        <div id="Header">
            <ul id="AdminMeni" runat="server" class="AdminMeni">
                <li><asp:LinkButton ID="KomitentiBtn" runat="server" OnClick="KomitentiBtn_Click">Комитент</asp:LinkButton></li>
                <li><asp:LinkButton ID="HardwareBtn" runat="server" OnClick="KomitentiBtn_Click">Hardware</asp:LinkButton></li>
            </ul>
            
            <p id="AdminInfo" runat="server"></p>
        </div>
        <div id="Content">
            <div id="LoginDiv" runat="server">
               <table id="LoginTable" runat="server">
               <tr>
                   <td>Корисник :</td>
                   <td><asp:TextBox ID="UserName" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                    <td>Лозинка :</td>
                    <td><asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox></td>
                </tr>
                <tr>
                <td><asp:LinkButton ID="LogOutLinkButton" runat="server" OnClick="Logout">Одјави се :</asp:LinkButton></td>
                <td><asp:Button ID="LoginButton" runat="server" Text="Влез"/></td>
                </tr>
                </table>
            </div>
            <div id="RezulatatDiv">
            <asp:ScriptManager ID="ScriptManagerAdmin" runat="server">
            </asp:ScriptManager>
                <p id="Rezultat" runat="server">
                    
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <table border="1px;" style="text-align: center; width: 300px; float: left;">
                                <tr>
                                    <td>
                                        Име
                                    </td>
                                    <td>
                                        <asp:TextBox ID="imeTexBox" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Дејност
                                    </td>
                                    <td>
                                        <asp:TextBox ID="dejnostTextBox" runat="server"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        URL
                                    </td>
                                    <td>
                                        <asp:TextBox ID="urlTexBox" runat="server"></asp:TextBox>
                                    </td>
                                    <td>
                                        <asp:Button ID="potvrdiBtn" runat="server" Text="Потврди" OnClick="potvrdiBtn_Click" />
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="statusLbl" runat="server" Text=""></asp:Label>
                            <ul id="listaIminja" runat="server" style="float: left; width: 200px;">
                            </ul>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </p>
            </div>
        </div>
        <div id="Footer">
        </div>
    </div>
    </form>
</body>
</html>
