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
using MongoDB.Driver;
using Newtonsoft.Json;
using System.Xml;
using System.IO;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;

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
            // xmlDocument.Save(@"C:/Pliki/KartaInformacyjna.xml");

            //czyszczenie ekranu
            Label1.Text = " " ;
            string nazwaBazy = "HisCLOB";

            string queryStringSQL = "select TOP(100) * from " + nazwaBazy + " where CzyImport = 0";
            string queryStringOracle;

            // string do bazy testowej
            // string connectionStringOracle = ConfigurationManager.ConnectionStrings["ConnectionStringDokMed"].ConnectionString;
            string connectionStringOracle = ConfigurationManager.ConnectionStrings["ConnectionStringDokMed_CLOB"].ConnectionString;
            string connectionStringSQL = ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString;

            DataSet dataset = new DataSet();

            dataset = ZapytanieMsSql(connectionStringSQL, queryStringSQL, nazwaBazy);
            int iloscRekordow = dataset.Tables[nazwaBazy].Rows.Count;
            int ilosc = Convert.ToInt32(TextBoxIloscDodacDoBazy.Text);

            int id_his = 0;
            int wersja = 0;
            int min2 = 0;
            int max2 = 0;


            while ((iloscRekordow > 0) && (ilosc>0))
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i < iloscRekordow) // warownik jaezeli i jest wieksze niz ilosc rekordow
                    {
                        id_his = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(0));
                        wersja = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(1));

                        queryStringOracle = "DECLARE tymCLOB clob:='" + xmlDocument + "'; " +
                            "tymID_HIS number:=" + id_his + "; " +
                            "BEGIN insert into DOKUMENTY_CLOB(id, wersja, wersja_aktualna, autor, id_baza_his, dane_clob) " +
                            "VALUES(DOKMED_CLOB.SEQ_ID_DOKUMENTY_CLOB.nextval,1,1,12345,tymID_HIS,tymCLOB); commit; END;";

                        ZapytanieOracle(connectionStringOracle, queryStringOracle);
                    }
                }

                for (int i = 0; i < 100; i++)
                {
                    if (i < iloscRekordow) // warownik jaezeli i jest wieksze niz ilosc rekordow
                    {
                        id_his = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(0));
                        wersja = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(1));
                        if (wersja > 1)
                        {
                            for (int j = 1; j < wersja; j++) //dodanie tylu wersji ile jest potrzebnych
                            {
                                queryStringOracle = "DECLARE tymCLOB clob:='" + xmlDocument + "'; " +
                                    "BEGIN DOKMED_CLOB.PRO_DODANIE_WERSJI(" + id_his + ", tymCLOB);END;";

                                ZapytanieOracle(connectionStringOracle, queryStringOracle);
                            }
                        }
                    }
                }

                // okreslenie zaimportowanych dokumnetow
                min2=Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[0].ItemArray.GetValue(0));
                max2=Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[99].ItemArray.GetValue(0));
                Label1.Text += " ID-" + min2.ToString();
                Label1.Text += " IDmax- " + max2.ToString();

                // dane wyeksportowane update na bazie
                queryStringSQL = "update " + nazwaBazy + " set Czyimport = 1 where ID_Dok between " + min2 + " AND " + max2 + ";";
                ZapytanieMsSql(connectionStringSQL, queryStringSQL);

                // obliczenie nowego zakresu danych
                queryStringSQL = "select TOP(100) * from " + nazwaBazy + " where CzyImport = 0";

                dataset = ZapytanieMsSql(connectionStringSQL, queryStringSQL, nazwaBazy);
                iloscRekordow = dataset.Tables[nazwaBazy].Rows.Count;

                ilosc -= 100;
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

            //XDocument xmlDocument2 = new XDocument(
            //    new XDeclaration("1.0", "utf-8", "no"),
            //    new XProcessingInstruction("xml-stylesheet", "href=\"CDA_PL_IG_1.3.1.xsl\" type=\"text/xsl\""), component.ZrotWartosci()
            //   );

            //#endregion
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

            #endregion

            Label1.Text = " ";
            string nazwaBazy = "HisXMLType";
            string queryStringSQL = "select TOP(100) * from " + nazwaBazy + " where CzyImport = 0";
            //string queryStringSQL = "select * from " + nazwaBazy + " where CzyImport = 0";
            string queryStringOracle;

            string connectionStringOracle = ConfigurationManager.ConnectionStrings["ConnectionStringDokMedXML"].ConnectionString;
            string connectionStringSQL = ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString;

            DataSet dataset = new DataSet();

            dataset = ZapytanieMsSql(connectionStringSQL, queryStringSQL, nazwaBazy);
            int iloscRekordow = dataset.Tables[nazwaBazy].Rows.Count;
            Label1.Text = "ILOSC rekordow-----"  + iloscRekordow.ToString();
            int ilosc = Convert.ToInt32(TextBoxIloscDodacDoBazy.Text);

            int min2 = 0;
            int max2 = 0;

            int id_his = 0;
            int wersja = 0;
            int wersjaRecordTargetXE = 0;
            int wersjaAuthorXE = 0;
            int wersjaCustodianXE = 0;
            int wersjaLegalAuthenticatorXE= 0;
            int wersjaComponentOfXE = 0;
            int wersjaComponentXE = 0;


            while ((iloscRekordow > 0) && (ilosc > 0))
            {
                for (int i = 0; i < 100; i++)
                {
                    if (i < iloscRekordow) // warownik jaezeli i jest wieksze niz ilosc rekordow
                    {
                        id_his = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(0));

                        //queryStringOracle = "begin DOKMEDXML.PRO_DODANIE_WERSJI("+ id_his +", XMLType('<Building>Owned</Building>')); end;";
                        queryStringOracle = "begin DOKMEDXML.PRO_DODANIE_DOKUMENTU(" + id_his + ", XMLType('" + naglowekXE + "'), XMLType('" + recordTargetXE + "')," +
                            "XMLType('" + authorXE + "'), XMLType('" + custodianXE + "'), XMLType('" + legalAuthenticatorXE + "'), XMLType('" + componentOfXE + "')," +
                            "XMLType('" + componentXE + "')); end;";

                        ZapytanieOracle(connectionStringOracle, queryStringOracle);
                    }
                }

                Label1.Text += " Ilosc rekordow " + iloscRekordow.ToString();

                //wersjonowanie

                for (int i = 0; i < 100; i++)
                {
                    if (i < iloscRekordow) // warownik jaezeli i jest wieksze niz ilosc rekordow
                    {
                        id_his = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(0));
                        wersja = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(1));
                        wersjaRecordTargetXE = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(2));
                        wersjaAuthorXE = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(3));
                        wersjaCustodianXE = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(4));
                        wersjaLegalAuthenticatorXE = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(5));
                        wersjaComponentOfXE = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(6));
                        wersjaComponentXE = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[i].ItemArray.GetValue(7));

                        if (wersja > 1)
                        {
                            for (int j = 1; j < wersja; j++) //dodanie tylu wersji ile jest potrzebnych
                            {
                                if (wersjaRecordTargetXE>1)
                                {
                                    wersjaRecordTargetXE--;
                                    //queryStringOracle = "BEGIN DOKMED.PRO_DODANIE_WERSJI(" + id_his + ", XMLType('<Building>Owned</Building>'));END;";
                                    //queryStringOracle = "BEGIN DOKMEDXML.PRO_DODANIE_WERSJI(" + id_his + ", 2, XMLType('<Building>Owned</Building>'));END;";
                                    queryStringOracle = "BEGIN DOKMEDXML.PRO_DODANIE_WERSJI(" + id_his + ", 2, XMLType('" + recordTargetXE + "'));END;";
                                }
                                else
                                {
                                    if (wersjaAuthorXE>1)
                                    {
                                        wersjaAuthorXE--;
                                        queryStringOracle = "BEGIN DOKMEDXML.PRO_DODANIE_WERSJI(" + id_his + ", 3, XMLType('" + authorXE + "'));END;";
                                    }
                                    else
                                    {
                                        if (wersjaCustodianXE>1)
                                        {
                                            wersjaCustodianXE--;
                                            queryStringOracle = "BEGIN DOKMEDXML.PRO_DODANIE_WERSJI(" + id_his + ", 4, XMLType('" + custodianXE + "'));END;";
                                        }
                                        else
                                        {
                                            if (wersjaLegalAuthenticatorXE>1)
                                            {
                                                wersjaLegalAuthenticatorXE--;
                                                queryStringOracle = "BEGIN DOKMEDXML.PRO_DODANIE_WERSJI(" + id_his + ", 5, XMLType('" + legalAuthenticatorXE + "'));END;";
                                            }
                                            else
                                            {
                                                if (wersjaComponentOfXE>1)
                                                {
                                                    wersjaComponentOfXE--;
                                                    queryStringOracle = "BEGIN DOKMEDXML.PRO_DODANIE_WERSJI(" + id_his + ", 6, XMLType('" + componentOfXE + "'));END;";
                                                }
                                                else
                                                {
                                                    if (wersjaComponentXE>1)
                                                    {
                                                        wersjaComponentXE--;
                                                        queryStringOracle = "BEGIN DOKMEDXML.PRO_DODANIE_WERSJI(" + id_his + ", 7, XMLType('" + componentXE + "'));END;";
                                                    }
                                                    else queryStringOracle = "select * from dual;";
                                                }
                                            }
                                        }
                                    }
                                }

                                ZapytanieOracle(connectionStringOracle, queryStringOracle);
                            }
                        }
                    }
                }

                min2 = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[0].ItemArray.GetValue(0));
                max2 = Convert.ToInt32(dataset.Tables[nazwaBazy].Rows[99].ItemArray.GetValue(0));
                Label1.Text += " ID-" + min2.ToString();
                Label1.Text += " IDmax- " + max2.ToString();

                //dane wyeksportowane
                queryStringSQL = "update " + nazwaBazy + " set Czyimport = 1 where ID_Dok between " + min2 + " AND " + max2 + ";";
                ZapytanieMsSql(connectionStringSQL, queryStringSQL);

                // obliczenie nowego zakresu danych
                queryStringSQL = "select TOP(100) * from " + nazwaBazy + " where CzyImport = 0";

                dataset = ZapytanieMsSql(connectionStringSQL, queryStringSQL, nazwaBazy);
                iloscRekordow = dataset.Tables[nazwaBazy].Rows.Count;

                ilosc -= 100;
            }
        }

        protected void ButtonDodajDokumntMongo_Click(object sender, EventArgs e)
        {
            var connectionString = "mongodb://192.168.1.115:27017";
            connectionString = "mongodb://192.168.1.152:27017";

            MongoClient dbClient = new MongoClient(connectionString);

            //Database List  
            //var dbList = dbClient.ListDatabases().ToList();

            //foreach (var item in dbList)
            //{
            //    Label1.Text += " Ilosc rekordow " + item.ToString();
            //}

            IMongoDatabase db = dbClient.GetDatabase("dokmed");

            //var collList = db.ListCollections().ToList();
            //Console.WriteLine("The list of collections are :");
            //foreach (var item in collList)
            //{
            //    Label1.Text += " Ilosc  " + item.ToString();
            //}

            XEL_recordTarget recordTarget = new XEL_recordTarget();
            XEL_author author = new XEL_author();

            XElement xml = new XElement(recordTarget.ZrotWartosci());
            XElement authorXE = new XElement(author.ZrotWartosci());
            //string xml = "<tree id=\"0\">" +
            //            "<item text=\"Folder_name\" id=\"FOLDER_1\" parentId=\"0\">" +
            //                "<item text=\"Other folder name\" id=\"FOLDER_96\" parentId=\"1\">" +
            //                    "<item text=\"Third folder name\" id=\"FOLDER_127\" parentId=\"96\">" +
            //                        "<item text=\"New folder\" id=\"FOLDER_147\" parentId=\"127\" />" +
            //                        "<item text=\"item name\" id=\"959\" parentId=\"147\" />" +
            //                        "<item text=\"item name sdgdfh\" id=\"1152\" parentId=\"147\" />" +
            //                    "</item>" +
            //                "</item>" +
            //            "</item>" +
            //        "</tree>";

            //var xmlDocument = new XmlDocument();
            // xmlDocument.LoadXml(xml);

            //XEL_recordTarget recordTarget = new XEL_recordTarget();
            //XElement xml = new XElement(recordTarget.ZrotWartosci());


            XmlDocument xD = new XmlDocument();
            XmlDocument xD2 = new XmlDocument();
            xD.LoadXml(xml.ToString());
            xD2.LoadXml(authorXE.ToString());

            XmlNode xN = xD.FirstChild;
            XmlNode xN2 = xD2.FirstChild;

            string json = JsonConvert.SerializeXmlNode(xN);
            string json2 = JsonConvert.SerializeXmlNode(xN2);

            //Label1.Text = json.ToString();
            //File.WriteAllText(@"C:/Pliki/json.txt",json);

            BsonDocument document = BsonDocument.Parse(json);
            BsonDocument document2 = BsonDocument.Parse(json2);

            var document3 = new BsonDocument
                {
                  {"firstname", BsonValue.Create("Peter")},
                  {"lastname", new BsonString("Mbanugo")},
                  { "subjects", new BsonArray(new[] {"English", "Mathematics", "Physics"}) },
                  { "class", "JSS 3" },
                  { "age", int.MaxValue }
                };


            var things = db.GetCollection<BsonDocument>("dokumenty");
            things.InsertOne(document);
            things.InsertOne (document2);
            things.InsertOne(document3);

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

        protected void ButtonTestBazaCLOB_Click(object sender, EventArgs e)
        {
            string connectionStringOracle = ConfigurationManager.ConnectionStrings["ConnectionStringDokMed_CLOB"].ConnectionString;
            string queryStringOracle = "select count(*) from dual";
            Label1.Text += ZapytanieOracle(connectionStringOracle, queryStringOracle,1);
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

        public int ZapytanieOracle(string connectionString, string queryString, int duall)
        {
            int dual = 0;
            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                try
                {
                    OracleCommand command = connection.CreateCommand();
                    command.CommandText = queryString;
                    connection.Open();
                    OracleDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        dual = reader.GetInt32(0);
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    LabelWitam.Text += ex.Message;
                }
                connection.Close();

                return dual;
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