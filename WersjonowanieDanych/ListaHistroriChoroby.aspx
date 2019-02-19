<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaHistroriChoroby.aspx.cs" Inherits="WersjonowanieDanych.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu</title>
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style5 {
            width: 286px;
        }
        .auto-style6 {
            width: 297px;
            height: 23px;
            text-align: right;
        }
        .auto-style34 {
            width: 295px;
        }
        .auto-style35 {
            width: 286px;
            height: 18px;
        }
        .auto-style36 {
            width: 295px;
            height: 18px;
            text-align: right;
        }
        .auto-style37 {
            height: 18px;
        }
        .auto-style38 {
            width: 297px;
            height: 18px;
            text-align: right;
        }
        .auto-style39 {
            text-align: right;
            height: 23px;
        }
        .auto-style40 {
            width: 286px;
            height: 23px;
        }
        .auto-style41 {
            width: 295px;
            height: 23px;
            text-align: right;
        }
        .auto-style42 {
            height: 23px;
        }
        .auto-style43 {
            width: 295px;
            text-align: right;
        }
        .auto-style44 {
            width: 297px;
            height: 20px;
        }
        .auto-style45 {
            width: 286px;
            height: 20px;
        }
        .auto-style46 {
            width: 295px;
            text-align: right;
            height: 20px;
        }
        .auto-style47 {
            text-align: left;
            height: 20px;
        }
        .auto-style48 {
            height: 20px;
        }
        .auto-style49 {
            text-align: left;
        }
        .auto-style50 {
            text-align: justify;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>



            <asp:Label ID="LabelWitam" runat="server" Text="Witam " Width="301px" CssClass="auto-style2" Font-Size="Large" ForeColor="#00CCFF"></asp:Label>



        </div>
        <table class="auto-style2">
            <tr>
                <td>&nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style34">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkListaMenu" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style34">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    <asp:HyperLink ID="HyperLinkNowaHistoriaChoroby" runat="server" NavigateUrl="~/NowaHistoriaChoroby.aspx">Dodanie Historii Choroby</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style34">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style34">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <strong>Historia choroby</strong></td>
                <td class="auto-style5">
                    &nbsp;</td>
                <td class="auto-style34">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <strong>Pacjent</strong></td>
                <td class="auto-style5">
                    <asp:DropDownList ID="DropDownListPacjent" runat="server" DataSourceID="SqlDataSource1" DataTextField="Pacjent" DataValueField="ID_Hospitalizacji" Height="16px" Width="264px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style34">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <strong>ID_Hospitalizacji</strong></td>
                <td class="auto-style40">
                    <asp:Label ID="LabelID_Hospitalizacji" runat="server"></asp:Label>
                </td>
                <td class="auto-style41"><strong>Kod choroby</strong></td>
                <td class="auto-style42">
                    <asp:Label ID="LabelKod_choroby" runat="server"></asp:Label>
                </td>
                <td class="auto-style42"></td>
            </tr>
            <tr>
                <td class="auto-style38">
                    <strong>Pacjent adres</strong></td>
                <td class="auto-style35">
                    <asp:Label ID="LabelPacjebt_adres" runat="server"></asp:Label>
                </td>
                <td class="auto-style36"><strong>Kod choroby 2</strong></td>
                <td class="auto-style37">
                    <asp:Label ID="LabelKod_choroby2" runat="server"></asp:Label>
                </td>
                <td class="auto-style37"></td>
            </tr>
            <tr>
                <td class="auto-style38">
                    <strong>Izba Przyjęć</strong></td>
                <td class="auto-style35">
                    <asp:Label ID="LabelIzba_Przyjec" runat="server"></asp:Label>
                </td>
                <td class="auto-style41"><strong>Procedura 1</strong></td>
                <td class="auto-style42">
                    <asp:Label ID="LabelProcedura1" runat="server"></asp:Label>
                </td>
                <td class="auto-style42"></td>
            </tr>
            <tr>
                <td class="auto-style39" ><strong>Oddział</strong></td>
                <td class="auto-style40">
                    <asp:Label ID="LabelOddzial" runat="server"></asp:Label>
                </td>
                <td class="auto-style41"><strong>Procedura 2</strong></td>
                <td class="auto-style42">
                    <asp:Label ID="LabelProcedura2" runat="server"></asp:Label>
                </td>
                <td class="auto-style42"></td>
            </tr>
            <tr>
                <td class="auto-style39"><strong>Oddział 2</strong></td>
                <td class="auto-style40" aria-checked="undefined">
                    <asp:Label ID="LabelOddzial2" runat="server"></asp:Label>
                </td>
                <td class="auto-style43"><strong>Procedura 3</strong></td>
                <td>
                    <asp:Label ID="LabelProcedura3" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <strong>Data_od</strong></td>
                <td class="auto-style5">
                    <asp:Label ID="LabelData_od" runat="server"></asp:Label>
                </td>
                <td class="auto-style43"><strong>Procedura 4</strong></td>
                <td>
                    <asp:Label ID="LabelProcedura4" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <strong>Data_do</strong></td>
                <td class="auto-style5">
                    <asp:Label ID="LabelData_do" runat="server"></asp:Label>
                </td>
                <td class="auto-style43"><strong>Procedura 5</strong></td>
                <td>
                    <asp:Label ID="LabelProcedura5" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style43"><strong>Epikryza</strong></td>
                <td class="auto-style49">
                    <asp:Label ID="LabelEpikryza" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style44">
                    </td>
                <td class="auto-style45"></td>
                <td class="auto-style46"><strong>Zalecenia lekarza</strong></td>
                <td class="auto-style47">
                    <asp:Label ID="LabelZalecenia_lekarza" runat="server"></asp:Label>
                </td>
                <td class="auto-style48"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style34">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <strong>Data autotyzacji</strong></td>
                <td class="auto-style40">
                    <asp:Label ID="LabelData_autotyzacji" runat="server"></asp:Label>
                </td>
                <td class="auto-style41"><strong>Użytkownik autoryzacji</strong></td>
                <td class="auto-style42">
                    <asp:Label ID="LabelUzytkownik_autoryzacji" runat="server"></asp:Label>
                </td>
                <td class="auto-style42"></td>
            </tr>
            <tr>
                <td class="auto-style3">
                    &nbsp;</td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style34">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style50">
                    <asp:Button ID="ButtonSzukaj" runat="server" OnClick="ButtonSzukaj_Click" Text="Szukaj" Width="278px" />
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style34">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SLOWNIKConnectionString %>" SelectCommand="SELECT Hospitalizacja.ID_Hospitalizacji, Pacjenci.Imie + ' ' + Pacjenci.Nazwisko +' ' + Convert(varchar(2),Hospitalizacja.DATA_Od,6) + '-' +
            Convert(varchar(11),Hospitalizacja.DATA_Do,106) AS Pacjent FROM Hospitalizacja INNER JOIN Pacjenci ON Hospitalizacja.FK_ID_Pacjenta = Pacjenci.ID_Pacjenta;"></asp:SqlDataSource>
    </form>
</body>
</html>

