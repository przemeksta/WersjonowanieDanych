<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIN.aspx.cs" Inherits="WersjonowanieDanych.LogIN" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>LogIn</title>
    <style type="text/css">
        .auto-style1 {
            font-size: x-large;
            text-align: center;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style3 {
            width: 491px;
            text-align: left;
        }
        .auto-style4 {
            width: 491px;
            text-align: right;
        }
        .auto-style7 {
            text-align: left;
        }
        .auto-style8 {
            width: 491px;
            text-align: right;
            height: 31px;
        }
        .auto-style10 {
            height: 31px;
            text-align: left;
        }
        .auto-style11 {
            font-size: x-large;
            font-weight: bold;
        }
        .auto-style13 {
            font-size: larger;
            color: #0000CC;
        }
        .auto-style14 {
            text-align: left;
            font-size: xx-large;
            color: #0000CC;
        }
        .auto-style15 {
            text-align: left;
            color: #CC3399;
            font-size: xx-large;
        }
        .auto-style16 {
            text-align: left;
            font-size: x-large;
        }
        .auto-style17 {
            font-size: larger;
        }
        .auto-style18 {
            text-align: left;
            width: 146px;
        }
        .auto-style19 {
            height: 31px;
            text-align: left;
            width: 146px;
        }
        .auto-style20 {
            width: 146px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <table class="auto-style2"> 
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style14" colspan="2">
                        <span class="auto-style13"><strong>Strona </strong></span><strong><span class="auto-style17">logowania</span>
                        <br />
                        </strong>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">Użytkownik</td>
                    <td class="auto-style18">
                        <asp:TextBox ID="TextBoxUzytkownik" runat="server" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style7">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxUzytkownik" ErrorMessage="Wprowadź użytkownika" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">Hasło</td>
                    <td class="auto-style19">
                        <asp:TextBox ID="TextBoxHaslo" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                    </td>
                    <td class="auto-style10">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxHaslo" ErrorMessage="Wprowadź hasło" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style20">
                        <strong>
                        <asp:Button ID="ButtonLogin" runat="server" OnClick="ButtonLogin_Click" Text="Login" Width="200px" CssClass="auto-style11" Height="40px" />
                        </strong>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style7" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style15" colspan="2"><strong>Program</strong></td>
                </tr>
                <tr>
                    <td class="auto-style3">&nbsp;</td>
                    <td class="auto-style16" colspan="2"><strong><em>Analiza sposobów wersjonowania danych w relacyjnych i nierelacyjnych<br />
                        systemach przechowywania danych na przykładzie dokumentacji medycznej.</em></strong></td>
                </tr>
            </table>
    </form>
</body>
</html>
