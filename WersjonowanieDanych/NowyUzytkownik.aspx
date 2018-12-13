<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NowyUzytkownik.aspx.cs" Inherits="WersjonowanieDanych.NowyUzytkownik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Nowy</title>
    <link href="Style.css" rel="stylesheet" />
 <style type="text/css">
     .auto-style33 {
         width: 168px;
         height: 34px;
     }
     .auto-style34 {
         width: 258px;
         height: 34px;
     }
     .auto-style35 {
         width: 76px;
         height: 30px;
         margin-top: 0px;
         margin-bottom: 0px;
     }   
     .auto-style36 {
         height: 23px;
     }
     .auto-style37 {
         width: 168px;
         height: 23px;
     }
     .auto-style38 {
         width: 258px;
         height: 23px;
     }        
     .auto-style40 {
         text-align: right;
     }
     .auto-style41 {
         font-size: xx-large;
     }
     
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div class="auto-style16">



            <asp:Label ID="LabelWitam" runat="server" Text="Witam " Width="301px" CssClass="auto-style2" Font-Size="Large" ForeColor="#00CCFF"></asp:Label>



            </div>

                    <table class="auto-style2">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style27">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkListaMenu" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
                </td>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style27">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkListaNowyUzytkownik" runat="server" NavigateUrl="~/NowyUzytkownik.aspx">Dodanie użytkowników</asp:HyperLink>
                </td>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style27">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style27">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style30"></td>
                <td class="auto-style41"><strong>Nowy użytkownik</strong></td>
                <td class="auto-style29"></td>
                <td class="auto-style29"></td>
            </tr>
            <tr>
                <td class="auto-style40"><strong>Użytkownik:</strong></td>
                <td class="auto-style25">
                        <asp:TextBox ID="TextBoxUzytkownik" runat="server" Width="160px"></asp:TextBox>
                    </td>
                <td class="auto-style27">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUzytkownik" ErrorMessage="Brak użytkownika" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40"><strong>Imie:</strong></td>
                <td class="auto-style25">
                        <asp:TextBox ID="TextBoxImie" runat="server" Width="160px"></asp:TextBox>
                    </td>
                <td class="auto-style27">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxImie" ErrorMessage="Brak imienia" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40"><strong>Nazwisko:</strong></td>
                <td class="auto-style25">
                        <asp:TextBox ID="TextBoxNazwisko" runat="server" Width="160px"></asp:TextBox>
                    </td>
                <td class="auto-style27">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxNazwisko" ErrorMessage="Brak nazwiska" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40"><strong>Hasło:</strong></td>
                <td class="auto-style25">
                        <asp:TextBox ID="TextBoxHaslo" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
                    </td>
                <td class="auto-style27">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxHaslo" ErrorMessage="Brak hasła" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40"><strong>Powtórz hasło:</strong></td>
                <td class="auto-style25">
                        <asp:TextBox ID="TextBoxPowHaslo" runat="server" TextMode="Password" Width="160px"></asp:TextBox>
                    </td>
                <td class="auto-style27">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxPowHaslo" ErrorMessage="Brak hasla" ForeColor="Red"></asp:RequiredFieldValidator>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxHaslo" ControlToValidate="TextBoxPowHaslo" ErrorMessage="Błędne hasło" ForeColor="#3333CC"></asp:CompareValidator>
                    </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40"><strong>Nr prawa zawodu</strong></td>
                <td class="auto-style25">
                        <asp:TextBox ID="TextBoxNrZawodu" runat="server" Width="160px" MaxLength="7"></asp:TextBox>
                    </td>
                <td class="auto-style27">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style40"><strong>Funkcja</strong></td>
                <td class="auto-style37">
                    <asp:DropDownList ID="DropDownListFunkcja" runat="server" Height="30px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="165px">
                        <asp:ListItem>Lekarz</asp:ListItem>
                        <asp:ListItem>Pielegniarka</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td class="auto-style38"></td>
                <td class="auto-style36"></td>
                <td class="auto-style36"></td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style25">&nbsp;</td>
                <td class="auto-style27">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style32"></td>
                <td class="auto-style33">
                        <asp:Button ID="ButtonZapisz" runat="server" Height="30px" OnClick="ButtonZapisz_Click" Text="Zapisz" Width="80px" />
                        <input id="Reset1" class="auto-style35" type="reset" value="Reset" /></td>
                <td class="auto-style34"></td>
                <td class="auto-style32"></td>
                <td class="auto-style32"></td>
            </tr>
        </table>

        </div>
    </form>
</body>
</html>
