<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HistoriaChoroby.aspx.cs" Inherits="WersjonowanieDanych.HistoriaChoroby" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menu</title>
    <link href="Style.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style5 {
            width: 219px;
        }
        .auto-style6 {
            height: 23px;
        }
        .auto-style7 {
            width: 219px;
            height: 23px;
        }
        .auto-style9 {
            width: 219px;
            font-size: large;
        }
        .auto-style12 {
            text-align: right;
            height: 26px;
        }
        .auto-style13 {
            width: 1490px;
            margin-left: 0px;
        }
        .auto-style14 {
            width: 111px;
        }
        .auto-style15 {
            height: 23px;
            width: 111px;
        }
        .auto-style17 {
            height: 23px;
            text-align: right;
        }
        .auto-style18 {
            width: 219px;
            height: 26px;
        }
        .auto-style19 {
            width: 111px;
            height: 26px;
        }
        .auto-style20 {
            height: 26px;
        }
        .auto-style21 {
            width: 158px;
        }
        .auto-style22 {
            height: 26px;
            width: 158px;
        }
        .auto-style23 {
            height: 23px;
            width: 158px;
        }
        .auto-style26 {
            font-weight: bold;
        }
        .auto-style31 {
            width: 161px;
        }
        .auto-style32 {
            height: 23px;
            width: 161px;
        }
        .auto-style33 {
            text-align: right;
        }
        .auto-style34 {
            text-align: right;
            height: 23px;
        }
        .auto-style35 {
            height: 23px;
            width: 120px;
        }
        .auto-style36 {
            width: 120px;
        }
        .auto-style38 {
            color: #FF0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" aria-checked="false">
        <div>



            <asp:Label ID="LabelWitam" runat="server" Text="Witam " Width="301px" CssClass="auto-style2" Font-Size="Large" ForeColor="#00CCFF"></asp:Label>



        </div>
        <table class="auto-style13">
            <tr>
                <td class="auto-style32"></td>
                <td class="auto-style7"></td>
                <td class="auto-style35"></td>
                <td class="auto-style15"></td>
                <td class="auto-style23"></td>
                <td class="auto-style6"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style31">
                    <asp:HyperLink ID="HyperLinkListaMenu" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
                </td>
                <td class="auto-style5"></td>
                <td class="auto-style36"></td>
                <td class="auto-style14"></td>
                <td class="auto-style21"></td>
                <td></td>
                <td></td>
            </tr>
            <tr>
                <td class="auto-style32">
                    <asp:HyperLink ID="HyperLinkListaPacv" runat="server" NavigateUrl="~/ListaPacjentow.aspx">Lista pacjentów</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style32">
                    <asp:HyperLink ID="HyperLinkDodaniePacjenta" runat="server" NavigateUrl="~/NowyPacjent.aspx">Dodanie pacjenta</asp:HyperLink>
                </td>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style21">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style31">&nbsp;</td>
                <td class="auto-style9"><strong>Tworzenie histori choroby</strong></td>
                <td class="auto-style36">&nbsp;</td>
                <td class="auto-style14">&nbsp;</td>
                <td class="auto-style21">Data pobytu od</td>
                <td class="auto-style14">Data pobytu do</td>
                <td class="auto-style14">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style33"><strong>Pacjent</strong></td>
                <td class="auto-style18">
                    <asp:DropDownList ID="DropDownPacjent" runat="server" DataSourceID="SqlDataPacjent" DataTextField="Dane" DataValueField="ID_Pacjenta" Width="215px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style12"><strong>Id pacjenta</strong></td>
                <td class="auto-style19">
                    <asp:Label ID="LabelIDPacjent" runat="server" CssClass="auto-style38"></asp:Label>
                </td>
                <td class="auto-style22"></td>
                <td class="auto-style20">&nbsp;</td>
                <td class="auto-style20"></td>
            </tr>
            <tr>
                <td class="auto-style33"><strong>Izba Przyjęć</strong></td>
                <td class="auto-style7">
                    <asp:DropDownList ID="DropDownIzba" runat="server" DataSourceID="SqlDataIzba" DataTextField="Nazwa" DataValueField="ID_Oddzialu" Width="215px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style17"><strong>Id izba</strong></td>
                <td class="auto-style15">
                    <asp:Label ID="LabelIDIzba" runat="server" CssClass="auto-style38"></asp:Label>
                </td>
                <td class="auto-style23"></td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style33" ><strong>Oddział</strong></td>
                <td class="auto-style7">
                    <asp:DropDownList ID="DropDownOddzial1" runat="server" DataSourceID="SqlDataOddzial" DataTextField="Nazwa" DataValueField="ID_Oddzialu" Width="215px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style17"><strong>Id oddział</strong></td>
                <td class="auto-style15">
                    <asp:Label ID="LabelIDOddzial" runat="server" CssClass="auto-style38"></asp:Label>
                </td>
                <td class="auto-style23"></td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style33"><strong>Oddział 2</strong></td>
                <td class="auto-style7">
                    <asp:DropDownList ID="DropDownOddzial2" runat="server" DataSourceID="SqlDataOddzial" DataTextField="Nazwa" DataValueField="ID_Oddzialu" Width="215px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style17"><strong>Id oddział 2</strong></td>
                <td class="auto-style15">
                    <asp:Label ID="LabelIDOddzial2" runat="server" CssClass="auto-style38"></asp:Label>
                </td>
                <td class="auto-style23">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style34"><strong>Rozpoznanie głowne</strong></td>
                <td>
                    <asp:DropDownList ID="DropDownRozpoznanie1" runat="server" DataSourceID="SqlDataRozpoznanie" DataTextField="DANE" DataValueField="ID_KodChoroby" Width="300px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style17"><strong>Id rozpoznania</strong></td>
                <td class="auto-style15">
                    <asp:Label ID="LabelIDRozpoznanie" runat="server" CssClass="auto-style38"></asp:Label>
                </td>
                <td class="auto-style23"></td>
                <td class="auto-style6"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style34"><strong>Rozpoznanie dodatkowe</strong></td>
                <td class="auto-style7">
                    <asp:DropDownList ID="DropDownRozpoznanie2" runat="server" DataSourceID="SqlDataRozpoznanie" DataTextField="DANE" DataValueField="ID_KodChoroby" Width="300px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style17"><strong>Id rozpozania 2</strong></td>
                <td class="auto-style15">
                    <asp:Label ID="LabelIDRozpoznanie2" runat="server" CssClass="auto-style38"></asp:Label>
                </td>
                <td class="auto-style23"></td>
                <td class="auto-style6"></td>
                <td class="auto-style6"></td>
            </tr>
            <tr>
                <td class="auto-style34"><strong>Procedura</strong></td>
                <td class="auto-style7">
                    <asp:DropDownList ID="DropDownProcedura1" runat="server" DataSourceID="SqlDataProcedura" DataTextField="DANE" DataValueField="ID_Procedury" Width="300px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style17"><strong>Id procedury</strong></td>
                <td class="auto-style15">
                    <asp:Label ID="LabelIDProcedura" runat="server" CssClass="auto-style38"></asp:Label>
                </td>
                <td class="auto-style23">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style34"><strong>Procedura 2</strong></td>
                <td class="auto-style7">
                    <asp:DropDownList ID="DropDownProcedura2" runat="server" DataSourceID="SqlDataProcedura" DataTextField="DANE" DataValueField="ID_Procedury" Width="300px">
                    </asp:DropDownList>
                </td>
                <td class="auto-style17"><strong>Id procedury 2</strong></td>
                <td class="auto-style15">
                    <asp:Label ID="LabelIDProcedura2" runat="server" CssClass="auto-style38"></asp:Label>
                </td>
                <td class="auto-style23">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style32">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style23">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style32">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style23">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style32">&nbsp;</td>
                <td class="auto-style7">&nbsp;</td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style23">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style32">&nbsp;</td>
                <td class="auto-style7">
                    <strong>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Pobierz dane" Width="213px" CssClass="auto-style26" />
                    </strong>
                </td>
                <td class="auto-style35">&nbsp;</td>
                <td class="auto-style15">&nbsp;</td>
                <td class="auto-style23">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
                <td class="auto-style6">&nbsp;</td>
            </tr>
        </table>

       
        <asp:SqlDataSource ID="SqlDataPacjent" runat="server" ConnectionString="<%$ ConnectionStrings:SLOWNIKConnectionString %>" SelectCommand="SELECT ID_Pacjenta, Imie + ' ' + Nazwisko AS Dane FROM Pacjenci"></asp:SqlDataSource>

       
        <asp:SqlDataSource ID="SqlDataIzba" runat="server" ConnectionString="<%$ ConnectionStrings:SLOWNIKConnectionString %>" SelectCommand="SELECT ID_Oddzialu, Nazwa FROM Oddzialy WHERE (Czy_izba_przyjec = 1) AND (Czy_aktywna = 1)"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataOddzial" runat="server" ConnectionString="<%$ ConnectionStrings:SLOWNIKConnectionString %>" SelectCommand="SELECT ID_Oddzialu, Nazwa FROM Oddzialy WHERE (Czy_aktywna = 1) AND (Czy_izba_przyjec = 0)"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataRozpoznanie" runat="server" ConnectionString="<%$ ConnectionStrings:SLOWNIKConnectionString %>" SelectCommand="SELECT ID_KodChoroby, KodChoroby + ' ' + NazwaChoroby AS DANE FROM KodChoroby"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataProcedura" runat="server" ConnectionString="<%$ ConnectionStrings:SLOWNIKConnectionString %>" SelectCommand="SELECT ID_Procedury, NrKatSzczegolowe + ' -  ' + NazwaKatSzczegolowe AS DANE FROM Procedury"></asp:SqlDataSource>

    </form>
    <p>
        &nbsp;</p>
</body>
</html>