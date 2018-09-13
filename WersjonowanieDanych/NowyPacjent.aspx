<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NowyPacjent.aspx.cs" Inherits="WersjonowanieDanych.NowyPacjent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 1465px;
        }
        .auto-style2 {
            width: 156px;
        }
        .auto-style4 {
            font-weight: bold;
        }
        .auto-style8 {
            background-color: #FFCCFF;
            height: 23px;
        }
        .auto-style9 {
            width: 129px;
            color: #FF0066;
            background-color: #FF66CC;
        }
        .auto-style10 {
            width: 437px;
        }
        .auto-style11 {
            width: 145px;
            background-color: #FFCCFF;
        }
        .auto-style12 {
            width: 146px;
            background-color: #FFCCFF;
        }
        .auto-style13 {
            width: 145px;
            color: #000000;
            background-color: #FFCCFF;
        }
        .auto-style14 {
            width: 146px;
            color: #000000;
            background-color: #FFCCFF;
        }
        .auto-style15 {
            width: 156px;
            height: 23px;
        }
        .auto-style16 {
            width: 129px;
            height: 23px;
            background-color: #FF66CC;
        }
        .auto-style17 {
            width: 437px;
            height: 23px;
        }
        .auto-style18 {
            width: 145px;
            background-color: #FFCCFF;
            height: 23px;
        }
        .auto-style19 {
            width: 146px;
            background-color: #FFCCFF;
            height: 23px;
        }
        .auto-style20 {
            width: 129px;
            color: #FF0066;
            height: 23px;
            background-color: #FF66CC;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style15">
            <asp:HyperLink ID="HyperLinkProgramGL" runat="server" NavigateUrl="~/Menu.aspx">Program główny</asp:HyperLink>
                </td>
                <td class="auto-style8" colspan="2">Dodanie Pacjenta</td>
                <td class="auto-style16">Count</td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:HyperLink ID="HyperLinkDodanieDokumntu" runat="server" NavigateUrl="~/NowyDokument.aspx">Dodanie dokumntu</asp:HyperLink>
                </td>
                <td class="auto-style11">Imię</td>
                <td class="auto-style12">
                    <asp:Label ID="LabelImie" runat="server"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:Label ID="LabelImieCount" runat="server"></asp:Label>
                </td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style11">Nazwisko</td>
                <td class="auto-style12">
                    <asp:Label ID="LabelNazwisko" runat="server"></asp:Label>
                </td>
                <td class="auto-style9">
                    <asp:Label ID="LabelNazwiskoCount" runat="server"></asp:Label>
                </td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style18">Pesel</td>
                <td class="auto-style19">
                    <asp:Label ID="LabelPesel" runat="server"></asp:Label>
                </td>
                <td class="auto-style20"></td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style13"><strong>
                    <asp:Button ID="ButtonDodaniePac" runat="server" CssClass="auto-style4" OnClick="ButtonDodaniePac_Click" Text="Dodanie Pacjenta" Width="130px" />
                    </strong></td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
