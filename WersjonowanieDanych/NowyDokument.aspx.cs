using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace WersjonowanieDanych
{
    public partial class NowyDokument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                LabelWitam.Text = Session["New"].ToString();
            }
            else
                Response.Redirect("LogIN.aspx");
        }

        protected void ButtonlosowanieCLOB_Click(object sender, EventArgs e)
        {
            WersjaDokumntu wersjaDok = new WersjaDokumntu();
            int wersja = 0;
            string insertQuery;
            int ilosc = Convert.ToInt32(TextBoxIloscDok.Text);
            SqlCommand com;

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();

                for (int i = 0; i < ilosc; i++)
                {
                    wersja = wersjaDok.Losowanie(1, 101);
                    insertQuery = "insert into HisCLOB(Wersja) values (@Wersja)";
                    com = new SqlCommand(insertQuery, conn);
                    com.Parameters.AddWithValue("@Wersja", wersja);
                    com.ExecuteNonQuery();
                }

                conn.Close();
                Response.Write("Sukces!!!");
            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.ToString());
            }
        }

        protected void ButtonlosowanieXMLType_Click(object sender, EventArgs e)
        {
            WersjaDokumntu wersjaDok = new WersjaDokumntu();
            int wersja = 0;
            int wersjaRecordTarget = 1;
            int wersjaAuthor = 1;
            int wersjaCustodian = 1;
            int wersjaLegalAuthenticator = 1;
            int wersjaComponentOf = 1;
            int wersjaComponent = 1;
            int losowanieKtory = 0;

            string insertQuery;
            int ilosc = Convert.ToInt32(TextBoxIloscDok.Text);
            SqlCommand com;

            System.Random x = new Random();

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();

                for (int i = 0; i < ilosc; i++)
                {
                    wersja = wersjaDok.Losowanie(1, 101);

                    insertQuery = "insert into HisXMLType(Wersja, RecordTarget, Author, Custodian, LegalAuthenticator, ComponentOf, Component) " +
                        "values(@Wersja, @RecordTarget, @Author, @Custodian, @LegalAuthenticator, @ComponentOf, @Component)";


                    com = new SqlCommand(insertQuery, conn);
                    com.Parameters.AddWithValue("@Wersja", wersja);

                    if (wersja > 1)
                    {
                        while (wersja > 1)
                        {
                            losowanieKtory = x.Next(1, 6);
                            //Response.Write(losowanieKtory.ToString());
                            if (losowanieKtory == 1) wersjaRecordTarget++;
                            if (losowanieKtory == 2) wersjaAuthor++;
                            if (losowanieKtory == 3) wersjaCustodian++;
                            if (losowanieKtory == 4) wersjaLegalAuthenticator++;
                            if (losowanieKtory == 5) wersjaComponentOf++;
                            if (losowanieKtory == 6) wersjaComponent++;

                            wersja--;
                        }
                    }

                    com.Parameters.AddWithValue("@RecordTarget", wersjaRecordTarget);
                    com.Parameters.AddWithValue("Author", wersjaAuthor);
                    com.Parameters.AddWithValue("@Custodian", wersjaCustodian);
                    com.Parameters.AddWithValue("@LegalAuthenticator", wersjaLegalAuthenticator);
                    com.Parameters.AddWithValue("@ComponentOf", wersjaComponentOf);
                    com.Parameters.AddWithValue("@Component", wersjaComponent);
                    com.ExecuteNonQuery();

                    wersjaRecordTarget = 1;
                    wersjaAuthor = 1;
                    wersjaCustodian = 1;
                    wersjaLegalAuthenticator = 1;
                    wersjaComponentOf = 1;
                    wersjaComponent = 1;
                }

                conn.Close();
                Response.Write("Sukces!!!");
            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.ToString());
            }
        }

        protected void ButtonDodajDokumntCLOB_Click(object sender, EventArgs e)
        {
            #region tworzenie XML
            XNamespace aw = "urn:hl7-org:v3";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace extPL = "http://www.csioz.gov.pl/xsd/extPL/r2";

            XEL_recordTarget recordTarget = new XEL_recordTarget();
            XEL_author author = new XEL_author();
            XEL_custodian custodian = new XEL_custodian();
            XEL_legalAuthenticator legalAuthenticator = new XEL_legalAuthenticator();
            XEL_componentOf componentOf = new XEL_componentOf();
            XEL_component component = new XEL_component();
            XEL_ClinicalDocument ClinicalDocument = new XEL_ClinicalDocument(recordTarget.ZrotWartosci(), author.ZrotWartosci(), custodian.ZrotWartosci(), legalAuthenticator.ZrotWartosci(), componentOf.ZrotWartosci(), component.ZrotWartosci());

            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XProcessingInstruction("xml-stylesheet", "href=\"CDA_PL_IG_1.3.1.xsl\" type=\"text/xsl\""), ClinicalDocument.ZrotWartosci()
            );

            #endregion
            // zapis xml do pliku
            //xmlDocument.Save(@"C:/Pliki/KartaInformacyjna.xml");

            string queryStringSQL = "select * from HisCLOB where CzyImport = 0";
            string nazwaBazy = "HisCLOB";
            string queryStringOracle;

            string connectionStringOracle = ConfigurationManager.ConnectionStrings["ConnectionStringDokMed"].ConnectionString;
            string connectionStringSQL = ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString;

            DataSet dataset = new DataSet();

            dataset = ZapytanieMsSql(connectionStringSQL, queryStringSQL, nazwaBazy);
            int iloscRekordow = dataset.Tables["HisCLOB"].Rows.Count;

            int ilosc = Convert.ToInt32(TextBoxIloscDok.Text);
            Label1.Text += " Ilosc rekordow " + iloscRekordow.ToString();

            int min = 1;
            int max = 100;
            int id_his = 0;
            int wersja = 0;

            while (iloscRekordow>0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if(i<iloscRekordow) // warownik jaezeli i jest wieksze niz ilosc rekordow
                    {
                        id_his = Convert.ToInt32(dataset.Tables["HisCLOB"].Rows[i].ItemArray.GetValue(0));
                        wersja = Convert.ToInt32(dataset.Tables["HisCLOB"].Rows[i].ItemArray.GetValue(1));

                        queryStringOracle = "DECLARE tymCLOB clob:='" + xmlDocument + "'; " +
                            "tymID_HIS number:=" + id_his + "; " +
                            "BEGIN insert into DOKUMENTY_CLOB(id, wersja, wersja_aktualna, autor, id_baza_his, dane_clob) " +
                            "VALUES(DOKMED.SEQ_ID_DOKUMENTY_CLOB.nextval,1,1,12345,tymID_HIS,tymCLOB); commit; END;";

                        ZapytanieOracle(connectionStringOracle, queryStringOracle);
                    }
                }

                Label1.Text += " Ilosc rekordow " + iloscRekordow.ToString();

                for (int i = 0; i < 100; i++)
                {
                    if (i < iloscRekordow) // warownik jaezeli i jest wieksze niz ilosc rekordow
                    {
                        id_his = Convert.ToInt32(dataset.Tables["HisCLOB"].Rows[i].ItemArray.GetValue(0));
                        wersja = Convert.ToInt32(dataset.Tables["HisCLOB"].Rows[i].ItemArray.GetValue(1));
                        if (wersja > 1)
                        {
                            for (int j = 1; j < wersja; j++) //dodanie tylu wersji ile jest potrzebnych
                            {
                                queryStringOracle = "BEGIN DOKMED.PRO_DODANIE_WERSJI(" + id_his + ", 'kurde czy sie uda');END;";
                                ZapytanieOracle(connectionStringOracle, queryStringOracle);
                                Label1.Text += " Numer rekordu " + id_his.ToString();
                            }
                        }
                    }
                }

                // dane wyeksportowane
                queryStringSQL = "update HisCLOB set Czyimport = 1 where ID_Dok between " + min + " AND " + max + ";";
                ZapytanieMsSql(connectionStringSQL, queryStringSQL);

                // obliczenie nowego zakresu danych
                queryStringSQL = "select * from HisCLOB where CzyImport = 0";
                dataset = ZapytanieMsSql(connectionStringSQL, queryStringSQL, nazwaBazy);
                iloscRekordow = dataset.Tables["HisCLOB"].Rows.Count;

                min += 100;
                max += 100;
            }
        }

        protected void ButtonDodajDokumntXMLtype_Click(object sender, EventArgs e)
        {
            #region tworzenie XML
            XNamespace aw = "urn:hl7-org:v3";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace extPL = "http://www.csioz.gov.pl/xsd/extPL/r2";

            XEL_recordTarget recordTarget = new XEL_recordTarget();
            XEL_author author = new XEL_author();
            XEL_custodian custodian = new XEL_custodian();
            XEL_legalAuthenticator legalAuthenticator = new XEL_legalAuthenticator();
            XEL_componentOf componentOf = new XEL_componentOf();
            XEL_component component = new XEL_component();
            XEL_ClinicalDocument clinicalDocument = new XEL_ClinicalDocument();

            //XEL_ClinicalDocument ClinicalDocument = new XEL_ClinicalDocument(recordTarget.ZrotWartosci(), author.ZrotWartosci(), custodian.ZrotWartosci(), legalAuthenticator.ZrotWartosci(), componentOf.ZrotWartosci(), component.ZrotWartosci());

            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XProcessingInstruction("xml-stylesheet", "href=\"CDA_PL_IG_1.3.1.xsl\" type=\"text/xsl\""), clinicalDocument.ZrotWartosci()
            );

            XDocument xmlDocument2 = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XProcessingInstruction("xml-stylesheet", "href=\"CDA_PL_IG_1.3.1.xsl\" type=\"text/xsl\""), component.ZrotWartosci()
);

            #endregion
            // zapis xml do pliku
            //xmlDocument.Save(@"C:/Pliki/KartaInformacyjna.xml");

            //xmlDocument.Save(@"C:/Pliki/Naglowek.xml");
            //xmlDocument2.Save(@"C:/Pliki/component.xml");

            XElement naglowekXE = new XElement(clinicalDocument.ZrotWartosci());
            XElement recordTargetXE = new XElement(recordTarget.ZrotWartosci());
            XElement authorXE = new XElement(author.ZrotWartosci());
            XElement custodianXE = new XElement(custodian.ZrotWartosci());
            XElement legalAuthenticatorXE = new XElement(legalAuthenticator.ZrotWartosci());
            XElement componentOfXE = new XElement(componentOf.ZrotWartosci());
            XElement componentXE = new XElement(component.ZrotWartosci());


            string queryStringSQL = "select * from HisXMLType where CzyImport = 0";
            string nazwaBazy = "HisXMLType";
            string queryStringOracle;

            string connectionStringOracle = ConfigurationManager.ConnectionStrings["ConnectionStringDokMedXML"].ConnectionString;
            string connectionStringSQL = ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString;

            DataSet dataset = new DataSet();

            dataset = ZapytanieMsSql(connectionStringSQL, queryStringSQL, nazwaBazy);
            int iloscRekordow = dataset.Tables[nazwaBazy].Rows.Count;

            int ilosc = Convert.ToInt32(TextBoxIloscDok.Text);
            Label1.Text += " Ilosc rekordow " + iloscRekordow.ToString();

            int min = 1;
            int max = 100;
            int id_his = 0;
            int wersja = 0;


            while (iloscRekordow > 0)
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i < iloscRekordow) // warownik jaezeli i jest wieksze niz ilosc rekordow
                    {
                        id_his = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(0));
                        wersja = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(1));

                        //queryStringOracle = "begin DOKMEDXML.PRO_DODANIE_WERSJI("+ id_his +", XMLType('<Building>Owned</Building>')); end;";
                        //queryStringOracle = "begin DOKMEDXML.PRO_DODANIE_WERSJI(" + id_his + ", XMLType('" + componentOfXE + "')); end;";
                        //queryStringOracle = "begin DOKMEDXML.PRO_DODANIE_WERSJI(" + id_his + ", XMLType('" + naglowekXE + "')); end;";
                        queryStringOracle = "begin DOKMEDXML.PRO_DODANIE_WERSJI(" + id_his + ", XMLType('" + naglowekXE + "'), XMLType('" + recordTargetXE + "')," +
                            "XMLType('" + authorXE + "'), XMLType('" + custodianXE + "'), XMLType('" + legalAuthenticatorXE + "'), XMLType('" + componentOfXE + "')," +
                            "XMLType('" + componentXE + "')); end;";

                        ZapytanieOracle(connectionStringOracle, queryStringOracle);
                    }
                }

                Label1.Text += " Ilosc rekordow " + iloscRekordow.ToString();

                //wersjonowanie

                //for (int i = 0; i < 100; i++)
                //{
                //    if (i < iloscRekordow) // warownik jaezeli i jest wieksze niz ilosc rekordow
                //    {
                //        id_his = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(0));
                //        wersja = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(1));
                //        if (wersja > 1)
                //        {
                //            for (int j = 1; j < wersja; j++) //dodanie tylu wersji ile jest potrzebnych
                //            {
                //                queryStringOracle = "BEGIN DOKMED.PRO_DODANIE_WERSJI(" + id_his + ", 'kurde czy sie uda');END;";
                //                ZapytanieOracle(connectionStringOracle, queryStringOracle);
                //                Label1.Text += " Numer rekordu " + id_his.ToString();
                //            }
                //        }
                //    }
                //}

                //dane wyeksportowane
                queryStringSQL = "update " + nazwaBazy + " set Czyimport = 1 where ID_Dok between " + min + " AND " + max + ";";
                ZapytanieMsSql(connectionStringSQL, queryStringSQL);

                // obliczenie nowego zakresu danych
                queryStringSQL = "select * from " + nazwaBazy + " where CzyImport = 0";
                dataset = ZapytanieMsSql(connectionStringSQL, queryStringSQL, nazwaBazy);
                iloscRekordow = dataset.Tables[nazwaBazy].Rows.Count;

                min += 100;
                max += 100;
            }
        }

        protected void ButtonDodajDokumntCLOBLosowy_Click(object sender, EventArgs e)
        {
            XEL_recordTarget recordTarget = new XEL_recordTarget();
            //XEL_recordTarget recordTarget = new XEL_recordTarget("01010101010101", "84848484848484", "inowrocław",
            //"88-100", "Kielbasiewicz", "24", "45", "Jasiu", "Tadeusz", "Okocim", "M", "19910101");
            //XEL_author author = new XEL_author("Roman", "Romanowski", "Szpital powiatowy w Inowroclawiu", "Oddzia Położniczy");
            XEL_author author = new XEL_author();
            XEL_custodian custodian = new XEL_custodian();
            XEL_legalAuthenticator legalAuthenticator = new XEL_legalAuthenticator();
            XEL_componentOf componentOf = new XEL_componentOf();
            XEL_component component = new XEL_component();
            XEL_ClinicalDocument ClinicalDocument = new XEL_ClinicalDocument(recordTarget.ZrotWartosci(), author.ZrotWartosci(), custodian.ZrotWartosci(), legalAuthenticator.ZrotWartosci(), componentOf.ZrotWartosci(), component.ZrotWartosci());

        }

        protected void ButtonDodajDokumntTESTUpdate_Click(object sender, EventArgs e)
        {
            XNamespace aw = "urn:hl7-org:v3";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace extPL = "http://www.csioz.gov.pl/xsd/extPL/r2";

            XEL_recordTarget recordTarget = new XEL_recordTarget();
            XEL_author author = new XEL_author();
            XEL_custodian custodian = new XEL_custodian();
            XEL_legalAuthenticator legalAuthenticator = new XEL_legalAuthenticator();
            XEL_componentOf componentOf = new XEL_componentOf();
            XEL_component component = new XEL_component();
            XEL_ClinicalDocument ClinicalDocument = new XEL_ClinicalDocument(recordTarget.ZrotWartosci(), author.ZrotWartosci(), custodian.ZrotWartosci(), legalAuthenticator.ZrotWartosci(), componentOf.ZrotWartosci(), component.ZrotWartosci());

            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XProcessingInstruction("xml-stylesheet", "href=\"CDA_PL_IG_1.3.1.xsl\" type=\"text/xsl\""), ClinicalDocument.ZrotWartosci()
            );

            xmlDocument.Save(@"C:/Pliki/KartaInformacyjna.xml");
            //string connectionString = "DATA SOURCE=orclcdb.localdomain;PASSWORD=dokmed1234;USER ID=DOKMED";
            //string connectionString = "<%$ ConnectionStrings:ConnectionStringDokMed %>";

            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDokMed"].ConnectionString;

            //string queryString = "DECLARE tym clob:='" + xmlDocument + "'; begin insert into DOKUMENTY(autor, dane_clob) VALUES(123, tym);commit;end;";
            //string queryString = "DECLARE tym clob:='" + xmlDocument + "'; begin update DOKUMENTY set dane_clob=tym, wersja = 10 where ID=25;commit;end;";
            string queryString = "DECLARE tym clob:='" + xmlDocument + "'; begin update DOKUMENTY set dane_clob=tym, wersja = 10 where ID=25;commit;end;";



            LabelWitam.Text += xmlDocument.ToString().Length.ToString();


            using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    OracleCommand command = connection.CreateCommand();
                    command.CommandText = queryString;

                    try
                    {
                        connection.Open();
                        OracleDataReader reader = command.ExecuteReader();

                    }
                    catch (Exception ex)
                    {
                        LabelWitam.Text += ex.Message;
                    }
                }

        }

        protected void ButtonDodajDokumntTEST_Click1(object sender, EventArgs e)
        {
            int ilosc = Convert.ToInt32(TextBoxIloscDok.Text);

            XNamespace aw = "urn:hl7-org:v3";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace extPL = "http://www.csioz.gov.pl/xsd/extPL/r2";

            //XEL_recordTarget recordTarget = new XEL_recordTarget();
            XEL_recordTarget recordTarget = new XEL_recordTarget("01010101010101", "84848484848484", "inowrocław",
                "88-100", "Kielbasiewicz", "24", "45", "Jasiu", "Tadeusz", "Okocim", "M", "19910101");
            XEL_author author = new XEL_author("Roman", "Romanowski", "Szpital powiatowy w Inowroclawiu", "Oddzia Położniczy");
            XEL_custodian custodian = new XEL_custodian();
            XEL_legalAuthenticator legalAuthenticator = new XEL_legalAuthenticator();
            XEL_componentOf componentOf = new XEL_componentOf();
            XEL_component component = new XEL_component();
            XEL_ClinicalDocument ClinicalDocument = new XEL_ClinicalDocument(recordTarget.ZrotWartosci(), author.ZrotWartosci(), custodian.ZrotWartosci(), legalAuthenticator.ZrotWartosci(), componentOf.ZrotWartosci(), component.ZrotWartosci());

            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XProcessingInstruction("xml-stylesheet", "href=\"CDA_PL_IG_1.3.1.xsl\" type=\"text/xsl\""), ClinicalDocument.ZrotWartosci()
            );

            xmlDocument.Save(@"C:/Pliki/KartaInformacyjna.xml");
            string connectionString = "DATA SOURCE=orclcdb.localdomain;PASSWORD=dokmed1234;USER ID=DOKMED";
            string queryString = "DECLARE tym clob:='" + xmlDocument + "'; begin insert into DOKUMENTY(ID,autor,wersja, dane_clob,id_baza_his) VALUES(DOKMED.SEQ_DOKUMENTY.nextval,123,1,tym,123);commit;end;";
            LabelWitam.Text += xmlDocument.ToString().Length.ToString();
            for (int i = 0; i < ilosc; i++)
            {

                using (OracleConnection connection = new OracleConnection(connectionString))
                {
                    OracleCommand command = connection.CreateCommand();
                    command.CommandText = queryString;

                    try
                    {
                        connection.Open();
                        OracleDataReader reader = command.ExecuteReader();

                    }
                    catch (Exception ex)
                    {
                        LabelWitam.Text += ex.Message;
                    }
                }
            }
        }



        //-------------------------- Funkcje ------------------------------------------------------------
        public void ZapytanieOracle(string connectionString, string queryString)
        {
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    OracleCommand command = connection.CreateCommand();
                    command.CommandText = queryString;
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    connection.Close();

                }
                catch (Exception ex)
                {
                    LabelWitam.Text += ex.Message;
                }
                connection.Close();
            }
        }

        public void ZapytanieMsSql(string connectionString, string queryString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = connection.CreateCommand();
                    command.CommandText = queryString;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("error: " + ex.ToString());
                }

            }
        }

        public DataSet ZapytanieMsSql(string connectionString, string queryString, string NazwaBazy)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter da = new SqlDataAdapter(queryString, connectionString);
                    da.Fill(dataset, NazwaBazy);
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("error: " + ex.ToString());
                }

            }
            return dataset;
        }

    }
}