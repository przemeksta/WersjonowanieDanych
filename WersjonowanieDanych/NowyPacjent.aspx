<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NowyPacjent.aspx.cs" Inherits="WersjonowanieDanych.NowyPacjent" %>

<!--          GOTOWY           -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Nowy pacjent</title>
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
        .auto-style10 {
            width: 437px;
        }
        .auto-style11 {
            width: 145px;
            background-color: #FFCCFF;
        }
        .auto-style12 {
            width: 215px;
            background-color: #FFCCFF;
        }
        .auto-style13 {
            width: 145px;
            color: #000000;
            background-color: #FFCCFF;
        }
        .auto-style14 {
            width: 215px;
            color: #000000;
            background-color: #FFCCFF;
        }
        .auto-style15 {
            width: 156px;
            height: 23px;
        }
        .auto-style16 {
            width: 144px;
            height: 23px;
            background-color: #FF99FF;
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
        .auto-style21 {
            width: 156px;
            height: 21px;
        }
        .auto-style22 {
            width: 145px;
            background-color: #FFCCFF;
            height: 21px;
        }
        .auto-style23 {
            width: 215px;
            background-color: #FFCCFF;
            height: 21px;
        }
        .auto-style24 {
            width: 144px;
            color: #000000;
            background-color: #FF99FF;
            height: 21px;
        }
        .auto-style25 {
            width: 437px;
            height: 21px;
        }
        .auto-style29 {
            width: 144px;
            color: #000000;
            background-color: #FF99FF;
        }
        .auto-style30 {
            width: 144px;
            color: #FF0066;
            background-color: #99CCFF;
        }
        .auto-style31 {
            width: 144px;
            color: #FF0066;
            height: 23px;
            background-color: #99CCFF;
        }
        .auto-style32 {
            width: 144px;
            color: #000000;
            background-color: #CC99FF;
        }
        .auto-style33 {
            width: 144px;
            color: #000000;
            background-color: #CC99FF;
            height: 21px;
        }
        .auto-style34 {
            width: 144px;
            height: 23px;
            background-color: #CC99FF;
        }
        .auto-style35 {
            background-color: #FFCCFF;
            height: 23px;
            width: 215px;
        }
        .auto-style36 {
            color: #000000;
        }
        .auto-style37 {
            width: 437px;
            background-color: #FFFFFF;
        }
        .auto-style38 {
            width: 144px;
            color: #FF0066;
            background-color: #FFFFFF;
        }
        .auto-style41 {
            color: #000000;
            background-color: #FFFFFF;
            height: 23px;
        }
        .auto-style43 {
            width: 144px;
            color: #FF0066;
            background-color: #FFFFFF;
            height: 23px;
        }
        .auto-style44 {
            width: 437px;
            height: 23px;
            background-color: #FFFFFF;
        }
        .auto-style45 {
            height: 23px;
        }
        .auto-style46 {
            width: 215px;
            color: #000000;
            background-color: #99FF99;
        }
        .auto-style47 {
            width: 145px;
            color: #000000;
            background-color: #99FF99;
        }
        .auto-style48 {
            width: 145px;
            color: #000000;
            background-color: #FFFFFF;
            height: 23px;
        }
        .auto-style49 {
            width: 215px;
            color: #000000;
            background-color: #FFFFFF;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Label ID="LabelWitam" runat="server" Text="Witam " Width="301px" CssClass="auto-style2" Font-Size="Large" ForeColor="#00CCFF"></asp:Label>


        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style45">
            <asp:HyperLink ID="HyperLinkMenu" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
                </td>
                <td class="auto-style45"></td>
                <td class="auto-style45"></td>
                <td class="auto-style45"></td>
                <td class="auto-style45"></td>
                <td class="auto-style45"></td>
            </tr>
            <tr>
                <td>
                    <asp:HyperLink ID="HyperLinkListaPacv" runat="server" NavigateUrl="~/ListaPacjentow.aspx">Lista pacjentów</asp:HyperLink>
                </td>
                <td colspan="2"><strong>Pojedynczy pacjent</strong></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15">
                    &nbsp;</td>
                <td class="auto-style8">Dodanie Pacjenta</td>
                <td class="auto-style35">Losowanie</td>
                <td class="auto-style16">Count</td>
                <td class="auto-style34"></td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style21">
                    &nbsp;</td>
                <td class="auto-style22">Plec</td>
                <td class="auto-style23">
                    <asp:Label ID="LabelPlec" runat="server"></asp:Label>
                </td>
                <td class="auto-style24">
                    K</td>
                <td class="auto-style33">
                    M</td>
                <td class="auto-style25"></td>
            </tr>
            <tr>
                <td class="auto-style2">
                    &nbsp;</td>
                <td class="auto-style11">Imię</td>
                <td class="auto-style12">
                    <asp:Label ID="LabelImie" runat="server"></asp:Label>
                </td>
                <td class="auto-style29">
                    <asp:Label ID="LabelImieCountK" runat="server"></asp:Label>
                </td>
                <td class="auto-style32">
                    <asp:Label ID="LabelImieCountM" runat="server"></asp:Label>
                </td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style11">Nazwisko</td>
                <td class="auto-style12">
                    <asp:Label ID="LabelNazwisko" runat="server"></asp:Label>
                </td>
                <td class="auto-style29">
                    <asp:Label ID="LabelNazwiskoCountK" runat="server"></asp:Label>
                </td>
                <td class="auto-style32">
                    <asp:Label ID="LabelNazwiskoCountM" runat="server"></asp:Label>
                </td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style18">Adres</td>
                <td class="auto-style35">
                    <asp:Label ID="LabelAdresKod" runat="server"></asp:Label>
                </td>
                <td class="auto-style31">
                    <asp:Label ID="LabelAdresCount" runat="server" CssClass="auto-style36"></asp:Label>
                </td>
                <td class="auto-style31">&nbsp;</td>
                <td class="auto-style17"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">
                    <asp:Label ID="LabelAdresMiasto" runat="server"></asp:Label>
                </td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">
                    <asp:Label ID="LabelAdresUlica" runat="server"></asp:Label>
                </td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style13">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style13"><strong>
                    <asp:Button ID="ButtonDodaniePac" runat="server" CssClass="auto-style4" OnClick="ButtonDodaniePac_Click" Text="Dodanie Pacjenta" Width="130px" />
                    </strong></td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style30">&nbsp;</td>
                <td class="auto-style10">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style48"></td>
                <td class="auto-style49"></td>
                <td class="auto-style43"></td>
                <td class="auto-style43"></td>
                <td class="auto-style44"></td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style41" colspan="2"><strong>Grupowe dodawanie pacjentow</strong></td>
                <td class="auto-style43"></td>
                <td class="auto-style43"></td>
                <td class="auto-style44"></td>
            </tr>
            <tr>
                <td class="auto-style15"></td>
                <td class="auto-style48"></td>
                <td class="auto-style49"></td>
                <td class="auto-style43"></td>
                <td class="auto-style43"></td>
                <td class="auto-style44"></td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style47">Liczba pacjentów</td>
                <td class="auto-style46">
                    <asp:TextBox ID="TextBoxIloscPac" runat="server">0</asp:TextBox>
                </td>
                <td class="auto-style38">
                    <asp:RegularExpressionValidator ID="RegularExpressionValidatorIloscPac" runat="server" ErrorMessage="Tylko Int" ValidationExpression="^[0-9]+$" ControlToValidate="TextBoxIloscPac"></asp:RegularExpressionValidator>
                </td>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style37">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td class="auto-style47"><strong>
                    <asp:Button ID="ButtonDodaniePacGrupa" runat="server" CssClass="auto-style4" OnClick="ButtonDodaniePacGrupa_Click" Text="Dodanie Pacjenta" Width="130px" />
                    </strong></td>
                <td class="auto-style46">&nbsp;</td>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style38">&nbsp;</td>
                <td class="auto-style37">&nbsp;</td>
            </tr>
        </table>
        </div>
    </form>
</body>
</html>
