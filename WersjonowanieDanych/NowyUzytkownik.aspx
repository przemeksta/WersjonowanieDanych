<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NowyUzytkownik.aspx.cs" Inherits="WersjonowanieDanych.NowyUzytkownik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
 <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            height: 25px;
            text-align: left;
        }
        .auto-style4 {
            width: 300px;
            text-align: right;
        }
        .auto-style6 {
            height: 25px;
            width: 300px;
            text-align: right;
        }
        .auto-style7 {
            width: 182px;
        }
        .auto-style9 {
            height: 25px;
            width: 182px;
        }
        .auto-style10 {
            height: 26px;
            width: 300px;
            text-align: right;
        }
        .auto-style11 {
            height: 26px;
            width: 182px;
        }
        .auto-style12 {
            height: 26px;
            text-align: left;
        }
        .auto-style13 {
            text-align: left;
        }
        .auto-style14 {
            width: 80px;
            height: 30px;
            margin-top: 0px;
        }
        .auto-style16 {
            text-align: left;
            font-size: x-large;
        }
        .auto-style17 {
            font-size: large;
        }
     .auto-style18 {
         width: 300px;
         text-align: left;
         height: 30px;
     }
     .auto-style19 {
         width: 182px;
         height: 30px;
     }
     .auto-style20 {
         text-align: left;
         font-size: x-large;
         height: 30px;
     }
     .auto-style23 {
         text-align: left;
         font-size: x-large;
         height: 23px;
     }
     .auto-style24 {
         height: 23px;
         width: 300px;
         text-align: left;
     }
     .auto-style25 {
         height: 23px;
         width: 182px;
     }
        .auto-style2 {
            color: #00FFFF;
            font-size: large;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="auto-style16">



            <asp:Label ID="LabelWitam" runat="server" Text="Witam " Width="301px" CssClass="auto-style2" Font-Size="Large" ForeColor="#00CCFF"></asp:Label>



            </div>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style24">&nbsp;</td>
                    <td class="auto-style25">
                        </td>
                    <td class="auto-style23">
                        </td>
                </tr>
                <tr>
                    <td class="auto-style18">
                <asp:HyperLink ID="HyperLink4" runat="server" CssClass="auto-style17" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
                    </td>
                    <td class="auto-style19">
                        </td>
                    <td class="auto-style20">
                        <strong>Utowrzenie użytkownika</strong></td>
                </tr>
                <tr>
                    <td class="auto-style4"><strong>Użytkownik:</strong></td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBoxUzytkownik" runat="server" Width="160px"></asp:TextBox>
                    </td>
                    <td class="auto-style13">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUzytkownik" ErrorMessage="Brak użytkownika" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style6"><strong>Hasło:</strong></td>
                    <td class="auto-style9">
                        <asp:TextBox ID="TextBoxHaslo" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
                    </td>
                    <td class="auto-style3">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxHaslo" ErrorMessage="Brak hasła" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4"><strong>Potworz hasło:</strong></td>
                    <td class="auto-style7">
                        <asp:TextBox ID="TextBoxPowHaslo" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
                    </td>
                    <td class="auto-style13">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxPowHaslo" ErrorMessage="Brak hasla" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxHaslo" ControlToValidate="TextBoxPowHaslo" ErrorMessage="Błędne hasło" ForeColor="#3333CC"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style10">&nbsp;</td>
                    <td class="auto-style11">
                        &nbsp;</td>
                    <td class="auto-style12">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">
                        <asp:Button ID="ButtonZapisz" runat="server" Height="30px" OnClick="ButtonZapisz_Click" Text="Zapisz" Width="80px" />
                        <input id="Reset1" class="auto-style14" type="reset" value="Reset" /></td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
