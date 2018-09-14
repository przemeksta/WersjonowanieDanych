<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaPacjentow.aspx.cs" Inherits="WersjonowanieDanych.ListaPacjentow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <p>
            <asp:HyperLink ID="HyperLinkProgramGL" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
        </p>
        <div>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SLOWNIKConnectionString %>" SelectCommand="SELECT * FROM [Pacjenci]"></asp:SqlDataSource>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_Pacjenta" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="ID_Pacjenta" HeaderText="ID_Pacjenta" ReadOnly="True" SortExpression="ID_Pacjenta" />
                    <asp:BoundField DataField="Imie" HeaderText="Imie" SortExpression="Imie" />
                    <asp:BoundField DataField="Nazwisko" HeaderText="Nazwisko" SortExpression="Nazwisko" />
                    <asp:BoundField DataField="Plec" HeaderText="Plec" SortExpression="Plec" />
                    <asp:BoundField DataField="KodPocztowy" HeaderText="KodPocztowy" SortExpression="KodPocztowy" />
                    <asp:BoundField DataField="Misto" HeaderText="Misto" SortExpression="Misto" />
                    <asp:BoundField DataField="Ulica" HeaderText="Ulica" SortExpression="Ulica" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
