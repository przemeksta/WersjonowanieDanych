<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaUzytkownikow.aspx.cs" Inherits="WersjonowanieDanych.ListaUzytkownikow" %>

<!--          GOTOWY           -->

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lista użytkowników</title>
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
                    <asp:HyperLink ID="HyperLinkMenu" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
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
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>


        <div class="auto-style4">
            <asp:SqlDataSource ID="SqlDataSourceUzytkownicy" runat="server" ConnectionString="<%$ ConnectionStrings:SLOWNIKConnectionString %>" SelectCommand="SELECT * FROM [Uzytkownicy]" OnSelecting="SqlDataSourceUzytkownicy_Selecting" DeleteCommand="DELETE FROM [Uzytkownicy] WHERE [ID_Uzytkownika] = @ID_Uzytkownika" InsertCommand="INSERT INTO [Uzytkownicy] ([ID_Uzytkownika], [Nazwa], [Imie], [Nazwisko], [Haslo], [Nr_zawodu], [Funkcja]) VALUES (@ID_Uzytkownika, @Nazwa, @Imie, @Nazwisko, @Haslo, @Nr_zawodu, @Funkcja)" UpdateCommand="UPDATE [Uzytkownicy] SET [Nazwa] = @Nazwa, [Imie] = @Imie, [Nazwisko] = @Nazwisko, [Haslo] = @Haslo, [Nr_zawodu] = @Nr_zawodu, [Funkcja] = @Funkcja WHERE [ID_Uzytkownika] = @ID_Uzytkownika">
                <DeleteParameters>
                    <asp:Parameter Name="ID_Uzytkownika" Type="Int64" />
                </DeleteParameters>
                <InsertParameters>
                    <asp:Parameter Name="ID_Uzytkownika" Type="Int64" />
                    <asp:Parameter Name="Nazwa" Type="String" />
                    <asp:Parameter Name="Imie" Type="String" />
                    <asp:Parameter Name="Nazwisko" Type="String" />
                    <asp:Parameter Name="Haslo" Type="String" />
                    <asp:Parameter Name="Nr_zawodu" Type="String" />
                    <asp:Parameter Name="Funkcja" Type="String" />
                </InsertParameters>
                <UpdateParameters>
                    <asp:Parameter Name="Nazwa" Type="String" />
                    <asp:Parameter Name="Imie" Type="String" />
                    <asp:Parameter Name="Nazwisko" Type="String" />
                    <asp:Parameter Name="Haslo" Type="String" />
                    <asp:Parameter Name="Nr_zawodu" Type="String" />
                    <asp:Parameter Name="Funkcja" Type="String" />
                    <asp:Parameter Name="ID_Uzytkownika" Type="Int64" />
                </UpdateParameters>
            </asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID_Uzytkownika" DataSourceID="SqlDataSourceUzytkownicy" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="20">
                <Columns>
                    <asp:BoundField DataField="ID_Uzytkownika" HeaderText="ID_Uzytkownika" ReadOnly="True" SortExpression="ID_Uzytkownika" />
                    <asp:BoundField DataField="Nazwa" HeaderText="Nazwa" SortExpression="Nazwa" />
                    <asp:BoundField DataField="Imie" HeaderText="Imie" SortExpression="Imie" />
                    <asp:BoundField DataField="Nazwisko" HeaderText="Nazwisko" SortExpression="Nazwisko" />
                    <asp:BoundField DataField="Haslo" HeaderText="Haslo" SortExpression="Haslo" />
                    <asp:BoundField DataField="Nr_zawodu" HeaderText="Nr_zawodu" SortExpression="Nr_zawodu" />
                    <asp:BoundField DataField="Funkcja" HeaderText="Funkcja" SortExpression="Funkcja" />
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                </Columns>
                <FooterStyle BackColor="White" ForeColor="#000066" />
                <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                <RowStyle ForeColor="#000066" />
                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                <SortedDescendingHeaderStyle BackColor="#00547E" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
