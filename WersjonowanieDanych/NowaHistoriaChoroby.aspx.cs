using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Xml.Schema;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Oracle.ManagedDataAccess.Client;

namespace WersjonowanieDanych
{

    public partial class HistoriaChoroby : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["New"] != null)
            {
                LabelWitam.Text = "Witam " + Session["New"].ToString();
            }
            else
                Response.Redirect("LogIN.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // pola do inserta
            string pacjent = DropDownPacjent.Text;
            string izba = DropDownIzba.Text;
            string oddzial1 = DropDownOddzial1.Text;
            string oddzial2 = DropDownOddzial2.Text;
            string rozpoznanie1 = DropDownRozpoznanie1.Text;
            string rozpoznanie2 = DropDownRozpoznanie2.Text;
            string procedura1 = DropDownProcedura1.Text;
            string procedura2 = DropDownProcedura2.Text;

            //wyswietlanie ID pól
            LabelIDPacjent.Text = pacjent;
            LabelIDIzba.Text = izba;
            LabelIDOddzial.Text = oddzial1;
            LabelIDOddzial2.Text = oddzial2;
            LabelIDRozpoznanie.Text = rozpoznanie1;
            LabelIDRozpoznanie2.Text = rozpoznanie2;
            LabelIDProcedura.Text = procedura1;
            LabelIDProcedura2.Text = procedura2;

            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["SLOWNIKConnectionString"].ConnectionString);
                conn.Open();
                string insertQuery = "insert into Hospitalizacja(FK_ID_Pacjenta, DATA_Od, DATA_Do,FK_ID_Pobyt_izba, FK_ID_Pobyt_odd1, FK_ID_Pobyt_odd2, FK_ID_KodChoroby1, FK_ID_KodChoroby2, " +
                    "FK_ID_Procedury1, FK_ID_Procedury2, FK_ID_Procedury3, FK_ID_Procedury4, FK_ID_Procedury5, Epikryza, Zalecenia_lek, DATA_Autoryzacji, FK_ID_Uzytkownika)" +
                    "values (@Pacjent, GETDATE(), GETDATE(), @Izba, @Oddzial1, @Oddzial2, @Rozpoznanie1, @Rozpoznanie2, @Procedura1, @Procedura2, @Procedura3, @Procedura4, @Procedura5, " +
                    "'Test12345', 'Test56789', GETDATE(), @Uzytkownik)";
                SqlCommand com2 = new SqlCommand(insertQuery, conn);

                string selectQuery = "select ID_Uzytkownika from Uzytkownicy where Nazwa='" + Session["New"].ToString() + "'";

                SqlCommand com = new SqlCommand(selectQuery, conn);

                /*
                com2.Parameters.AddWithValue("@Pacjent", pacjent);
                com2.Parameters.AddWithValue("@Izba", izba);
                com2.Parameters.AddWithValue("@Oddzial1", oddzial1);
                com2.Parameters.AddWithValue("@Oddzial2", oddzial2);
                com2.Parameters.AddWithValue("@Rozpoznanie1", rozpoznanie1);
                com2.Parameters.AddWithValue("@Rozpoznanie2", rozpoznanie2);
                com2.Parameters.AddWithValue("@Procedura1", procedura1);
                com2.Parameters.AddWithValue("@Procedura2", procedura2);*/


                com2.Parameters.AddWithValue("@Pacjent", "10");
                com2.Parameters.AddWithValue("@Izba", "2");
                com2.Parameters.AddWithValue("@Oddzial1", "4");
                com2.Parameters.AddWithValue("@Oddzial2", "5");
                com2.Parameters.AddWithValue("@Rozpoznanie1", "6");
                com2.Parameters.AddWithValue("@Rozpoznanie2", "7");
                com2.Parameters.AddWithValue("@Procedura1", "97");
                com2.Parameters.AddWithValue("@Procedura2", "98");


                com2.Parameters.AddWithValue("@Procedura3", "99");
                com2.Parameters.AddWithValue("@Procedura4", "100");
                com2.Parameters.AddWithValue("@Procedura5", "101");
                com2.Parameters.AddWithValue("@Uzytkownik", com.ExecuteScalar().ToString());

                LabelWitam.Text += com.ExecuteScalar().ToString();

                //co to jest
                com2.ExecuteNonQuery();

                conn.Close();
                Response.Write("Sukces!!!");

            }
            catch (Exception ex)
            {
                Response.Write("error: " + ex.ToString());
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            XmlReader reader = XmlReader.Create("c:/Pliki/KartaInformacyjna.xml");
            XmlSchemaSet schemaSet = new XmlSchemaSet();
            XmlSchemaInference schema = new XmlSchemaInference();
            XmlSchema myschema = new XmlSchema();

            schemaSet = schema.InferSchema(reader);

            //FileStream file = new FileStream("c:/Pliki/new.xsd", FileMode.Create, FileAccess.ReadWrite);
            FileStream file = new FileStream("XMLSchemaKI.xsd", FileMode.Create, FileAccess.ReadWrite);
            XmlTextWriter xwriter = new XmlTextWriter(file, new UTF8Encoding())
            {
                Formatting = Formatting.Indented
            };

            foreach (XmlSchema s in schemaSet.Schemas())
            {
                s.Write(xwriter);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //System.IO.StreamReader xmlStream = new System.IO.StreamReader("C:/Users/Administrator/source/repos/WersjonowanieDanych/WersjonowanieDanych/XMLSchemaKL.xsd");
            //DataSet dataSet = new DataSet();
            //dataSet.ReadXmlSchema(xmlStream);
            //xmlStream.Close();

            XNamespace aw = "urn:hl7-org:v3";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace extPL = "http://www.csioz.gov.pl/xsd/extPL/r2";

            XEL_recordTarget recordTarget = new XEL_recordTarget();
            XEL_author author = new XEL_author("Tomek", "Waligora", "Szpial Powiatowy w Inowrocławiu", "Oddzial chirurgi");
            XEL_custodian custodian = new XEL_custodian();
            XEL_legalAuthenticator legalAuthenticator = new XEL_legalAuthenticator("20190901");
            XEL_componentOf componentOf = new XEL_componentOf();
            XEL_component component = new XEL_component();
            XEL_ClinicalDocument ClinicalDocument = new XEL_ClinicalDocument(recordTarget.ZrotWartosci(), author.ZrotWartosci(), custodian.ZrotWartosci(), legalAuthenticator.ZrotWartosci(), componentOf.ZrotWartosci(), component.ZrotWartosci());

            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XProcessingInstruction("xml-stylesheet", "href=\"CDA_PL_IG_1.3.1.xsl\" type=\"text/xsl\""), ClinicalDocument.ZrotWartosci()
            );

            xmlDocument.Save(@"C:/Pliki/KartaInformacyjna.xml");

            string connectionString = "DATA SOURCE=orclcdb.localdomain;PASSWORD=dokmed1234;USER ID=DOKMED";
            //string queryString = "select count(*) from TESTXML";
            //string queryString = "insert into TEST VALUES('23','"+dane+"')";
            //string queryString = "insert into DOKUMENTY VALUES(,,,,123,'" + xmlDocument+"')";
            //string queryString = "insert into DOKUMENTY(autor, dane_xml) VALUES(123,'"+ xmlDocument + "')";
            //string queryString = "insert into DOKUMENTY(autor, dane_clob) VALUES(123,'"+ xmlDocument + "')";
            //string queryString = "DECLARE tym clob:='" + xmlDocument.ToString() + "'; begin insert into DOKUMENTY(autor, dane_clob) VALUES(123, tym);commit;end;";
            //string queryString = "insert into DOKUMENTY(autor, dane_xml) VALUES(123,'" + custodian + "')";,

            string queryString = "DECLARE tym clob:='" + xmlDocument + "'; begin insert into DOKUMENTY(autor, dane_clob) VALUES(123, tym);commit;end;";

            LabelWitam.Text += xmlDocument.ToString().Length.ToString();
            using (OracleConnection connection =
                       new OracleConnection(connectionString))
            {
                OracleCommand command = connection.CreateCommand();
                command.CommandText = queryString;

                try
                {
                    connection.Open();

                    OracleDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        LabelXML.Text = reader[0].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    LabelWitam.Text += ex.Message;
                }
            }

        }
    }
}