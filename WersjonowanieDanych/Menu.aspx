<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="WersjonowanieDanych.Menu" %>

<!--          GOTOWY           -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu</title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <asp:Label ID="LabelWitam" runat="server" Text="Witam " Width="301px" CssClass="auto-style2" Font-Size="Large" ForeColor="#00CCFF"></asp:Label>



        </div>
        <table class="auto-style2">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkListaMenu" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkListaUzytkownikow" runat="server" NavigateUrl="~/ListaUzytkownikow.aspx">Lista użytkowników</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkListaNowyUzytkownik" runat="server" NavigateUrl="~/NowyUzytkownik.aspx">Dodanie użytkowników</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkListaPacv" runat="server" NavigateUrl="~/ListaPacjentow.aspx">Lista pacjentów</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkDodaniePacjenta" runat="server" NavigateUrl="~/NowyPacjent.aspx">Dodanie pacjenta</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkHistoriaChoroby" runat="server" NavigateUrl="~/HistoriaChoroby.aspx">Historia Choroby</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkDodanieDokumntu0" runat="server" NavigateUrl="~/ListaDokumntow.aspx">Lista dokumentów</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkDodanieDokumntu" runat="server" NavigateUrl="~/NowyDokument.aspx">Dodanie dokumntu</asp:HyperLink>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <strong>
            <asp:Button ID="ButtonLogout" runat="server" CssClass="auto-style1" Height="42px" OnClick="ButtonLogout_Click" Text="Logout" Width="136px" />
        </strong>
    </form>
</body>
</html>
