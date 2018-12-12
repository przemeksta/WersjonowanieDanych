<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="WersjonowanieDanych.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu</title>
        <style type="text/css">
        .auto-style1 {
            font-size: x-large;
            font-weight: bold;
        }
        .auto-style2 {
            color: #00FFFF;
            font-size: large;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
            width: 480px;
        }
        .auto-style5 {
            width: 139px;
        }
        .auto-style6 {
            width: 480px;
            height: 23px;
        }
        .auto-style7 {
            width: 139px;
            height: 23px;
        }
        .auto-style8 {
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <asp:Label ID="LabelWitam" runat="server" Text="Witam " Width="301px" CssClass="auto-style2" Font-Size="Large" ForeColor="#00CCFF"></asp:Label>



        </div>
        <table class="auto-style3">
            <tr>
                <td class="auto-style6">
                    </td>
                <td class="auto-style7"></td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:HyperLink ID="HyperLinkListaUzytkownikow0" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
                </td>
                <td class="auto-style7"></td>
                <td class="auto-style8"></td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLinkListaUzytkownikow" runat="server" NavigateUrl="~/ListaUzytkownikow.aspx">Lista użytkowników</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLinkListaUzytkownikow1" runat="server" NavigateUrl="~/NowyUzytkownik.aspx">Dodanie użytkowników</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLinkListaPacv" runat="server" NavigateUrl="~/ListaPacjentow.aspx">Lista pacjentów</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLinkDodaniePacjenta" runat="server" NavigateUrl="~/NowyPacjent.aspx">Dodanie pacjenta</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLinkDodanieDokumntu0" runat="server" NavigateUrl="~/ListaDokumntow.aspx">Lista dokumentów</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    <asp:HyperLink ID="HyperLinkDodanieDokumntu" runat="server" NavigateUrl="~/NowyDokument.aspx">Dodanie dokumntu</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">
                    &nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style4">&nbsp;</td>
                <td class="auto-style5"><strong>
            <asp:Button ID="ButtonLogout" runat="server" CssClass="auto-style1" Height="42px" OnClick="ButtonLogout_Click" Text="Logout" Width="136px" />
            </strong>
                </td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
