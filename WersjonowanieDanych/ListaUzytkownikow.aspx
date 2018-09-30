<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaUzytkownikow.aspx.cs" Inherits="WersjonowanieDanych.ListaUzytkownikow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lista</title>
    <style type="text/css">

        .auto-style12 {
            font-size: medium;
        }
        .auto-style13 {
            height: 659px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:HyperLink ID="HyperLinkProgramGL" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
        </p>
        <div class="auto-style13">
            <asp:SqlDataSource ID="SqlDataSourceUzytkownicy" runat="server" ConnectionString="<%$ ConnectionStrings:SLOWNIKConnectionString %>" SelectCommand="SELECT * FROM [Uzytkownicy]" OnSelecting="SqlDataSourceUzytkownicy_Selecting"></asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID_Uzytkownika" DataSourceID="SqlDataSourceUzytkownicy" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" PageSize="20">
                <Columns>
                    <asp:BoundField DataField="ID_Uzytkownika" HeaderText="ID_Uzytkownika" ReadOnly="True" SortExpression="ID_Uzytkownika" />
                    <asp:BoundField DataField="Nazwa" HeaderText="Nazwa" SortExpression="Nazwa" />
                    <asp:BoundField DataField="Haslo" HeaderText="Haslo" SortExpression="Haslo" />
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
            <br />
                        <asp:HyperLink ID="HyperLinkNowyUzytkownik" runat="server" CssClass="auto-style12" NavigateUrl="~/NowyUzytkownik.aspx">Nowy użytkownik</asp:HyperLink>
        </div>
    </form>
</body>
</html>
