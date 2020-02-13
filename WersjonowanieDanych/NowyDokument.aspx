<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NowyDokument.aspx.cs" Inherits="WersjonowanieDanych.NowyDokument" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Nowy dokument</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            width: 164px;
            height: 23px;
        }
        .auto-style4 {
            height: 23px;
        }
        .auto-style5 {
            width: 238px;
            height: 23px;
        }
        .auto-style6 {
            height: 23px;
            width: 349px;
        }
        .auto-style7 {
            height: 23px;
            width: 270px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table class="auto-style1">
                <tr>
                    <td class="auto-style3">

            <asp:Label ID="LabelWitam" runat="server" Text="Witam " Width="164px" Font-Size="Large" ForeColor="#00CCFF"></asp:Label>

                    </td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style5">&nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">Czas Operacji</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBoxIloscDok" runat="server" Width="212px">1</asp:TextBox>
                    </td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        Dodanie losowego schematu</td>
                    <td class="auto-style5">
                        Dokumnt testowy</td>
                    <td class="auto-style6">
                        Dokument losowy</td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
            <asp:HyperLink ID="HyperLinkProgramGL" runat="server" NavigateUrl="~/Menu.aspx">Menu</asp:HyperLink>
                    </td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="ButtonDodajDokumntTEST" runat="server" Font-Bold="True" OnClick="ButtonDodajDokumntTEST_Click1" Text="Dodaj Dokumnt TEST" Width="220px" />
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="ButtonDodajDokumntTESTLosowy" runat="server" Font-Bold="True" OnClick="ButtonDodajDokumntTEST_Click1" Text="Dodaj Dokumnt TEST Losowy" Width="220px" />
                    </td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonDodajDokumntTESTUpdate" runat="server" Font-Bold="True" OnClick="ButtonDodajDokumntTESTUpdate_Click" Text="Dodaj Dokumnt TEST Update" Width="220px" />
                    </td>
                    <td class="auto-style4"></td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="TextBoxIloscDodacDoBazy" runat="server" Width="212px">0</asp:TextBox>
                    </td>
                    <td class="auto-style6">&nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="ButtonlosowanieCLOB" runat="server" Font-Bold="True" OnClick="ButtonlosowanieCLOB_Click" Text="Losowanie CLOB" Width="220px" />
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="ButtonDodajDokumntCLOB" runat="server" Text="Dodaj Dokumnt Cały" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntCLOB_Click" />
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="ButtonDodajDokumntCLOBLosowy" runat="server" Text="Dodaj Dokumnt CLOB Losowy" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntCLOBLosowy_Click" />
                    </td>
                    <td class="auto-style7">
                        &nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonTestBazaCLOB" runat="server" Font-Bold="True" OnClick="ButtonTestBazaCLOB_Click" Text="Test Baza CLOB" Width="220px" />
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="ButtonlosowanieXMLType" runat="server" Font-Bold="True" OnClick="ButtonlosowanieXMLType_Click" Text="Losowanie XMLType" Width="220px" />
                    </td>
                    <td class="auto-style5">
                        <asp:Button ID="ButtonDodajDokumntXMLtype" runat="server" Text="Dodaj Dokumnt Fragmenty" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntXMLtype_Click" />
                    </td>
                    <td class="auto-style6">
                        <asp:Button ID="ButtonDodajDokumntXMLtypeLosowy" runat="server" Text="Dodaj Dokumnt XMLType Losowy" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntCLOB_Click" />
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonDodajDokumntMongo" runat="server" Text="TEST Mongo" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntMongo_Click" />
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style6">
                        <asp:Button ID="ButtonDodajDokumntMongoLosowy" runat="server" Text="Dodaj Dokumnt Mongo Losowy" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntCLOB_Click" />
                    </td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonDodajDokumntMongo2" runat="server" Text="TEST Mongo zagniieżdzenie" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntMongo2_Click" />
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="ButtonDodajDokumntMongoCalyRef" runat="server" Text="MongoDB Dok Referencje" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntMongoCalyRef_Click" />
                    </td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonDodajDokumntMongo3" runat="server" Text="TEST Mongo Fragmenty referencje" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntMongo3_Click" />
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="ButtonDodajDokumntMongoCalyZag" runat="server" Text="MongoDB Dok Zagniezdzenie" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntMongoCalyZag_Click" />
                    </td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">
                        <asp:Button ID="ButtonDodajDokumntMongo4" runat="server" Text="TEST Mongo Fragmenty zag" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntMongo4_Click" />
                    </td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="ButtonDodajDokumntMongoFragRef" runat="server" Text="MongoDB Frag Referencje" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntMongoFragRef_Click" />
                    </td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style3">
                        &nbsp;</td>
                    <td class="auto-style5">
                        &nbsp;</td>
                    <td class="auto-style5">
                        <asp:Button ID="ButtonDodajDokumntMongoFragZag" runat="server" Text="MongoDB Ref Zagniezdzenie" Width="220px" Font-Bold="True" OnClick="ButtonDodajDokumntMongoFragZag_Click" />
                    </td>
                    <td class="auto-style6">
                        &nbsp;</td>
                    <td class="auto-style7">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                    <td class="auto-style4">&nbsp;</td>
                </tr>
                </table>
        </div>
        <p>
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
