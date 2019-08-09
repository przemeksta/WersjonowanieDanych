<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaDokumntow.aspx.cs" Inherits="WersjonowanieDanych.ListaDokumntow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Lista dokumentów</title>
    <style type="text/css">

        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 298px;
            height: 23px;
        }
        .auto-style2 {
            width: 298px;
        }
        .auto-style4 {
            height: 23px;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">



            <asp:Label ID="LabelWitam" runat="server" Text="Witam " Width="301px" CssClass="auto-style2" Font-Size="Large" ForeColor="#00CCFF"></asp:Label>



                    </td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
            <asp:HyperLink ID="HyperLinkProgramGL" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
                    </td>
                    <td class="auto-style4">
                        &nbsp;</td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                    <td class="auto-style4"></td>
                </tr>
                </table>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BAZA1ConnectionString %>" ProviderName="<%$ ConnectionStrings:BAZA1ConnectionString.ProviderName %>" SelectCommand="SELECT * FROM &quot;TEST&quot;"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="DANE" HeaderText="DANE" SortExpression="DANE" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionStringDokMed %>" ProviderName="<%$ ConnectionStrings:ConnectionStringDokMed.ProviderName %>" SelectCommand="SELECT * FROM &quot;TESTXML&quot;" OnSelecting="SqlDataSource2_Selecting1"></asp:SqlDataSource>
    </form>
</body>
</html>
