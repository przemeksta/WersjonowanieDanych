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
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" DataKeyNames="ID_Pacjenta" DataSourceID="SqlDataSource1" GridLines="Horizontal">
                <AlternatingRowStyle BackColor="#F7F7F7" />
                <Columns>
                    <asp:BoundField DataField="ID_Pacjenta" HeaderText="ID_Pacjenta" ReadOnly="True" SortExpression="ID_Pacjenta" />
                    <asp:BoundField DataField="Imie" HeaderText="Imie" SortExpression="Imie" />
                    <asp:BoundField DataField="Nazwisko" HeaderText="Nazwisko" SortExpression="Nazwisko" />
                    <asp:BoundField DataField="Plec" HeaderText="Plec" SortExpression="Plec" />
                    <asp:BoundField DataField="KodPocztowy" HeaderText="KodPocztowy" SortExpression="KodPocztowy" />
                    <asp:BoundField DataField="Miasto" HeaderText="Miasto" SortExpression="Miasto" />
                    <asp:BoundField DataField="Ulica" HeaderText="Ulica" SortExpression="Ulica" />
                </Columns>
                <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
                <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
                <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
                <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
                <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
                <SortedAscendingCellStyle BackColor="#F4F4FD" />
                <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
                <SortedDescendingCellStyle BackColor="#D8D8F0" />
                <SortedDescendingHeaderStyle BackColor="#3E3277" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
