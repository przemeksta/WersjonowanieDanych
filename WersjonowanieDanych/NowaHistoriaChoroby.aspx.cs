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

            XNamespace aw= "urn:hl7-org:v3";
            XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
            XNamespace extPL = "http://www.csioz.gov.pl/xsd/extPL/r2";

            XElement author = new XElement(aw + "author",
                new XElement(aw + "templateId",
                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.4")),
                new XElement(aw + "functionCode",
                    new XAttribute("code", "LEK"),
                    new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.11.3.18"),
                    new XAttribute("displayName", "Lekarz")),
                new XElement(aw + "time",
                    new XAttribute("value", "20140906")),        //data
                new XElement(aw + "assignedAuthor",
                    new XElement(aw + "id",
                            new XAttribute("extension", "7724513"),
                            new XAttribute("root", "2.16.840.1.113883.3.4424.1.6.2"),
                            new XAttribute("displayable", "false")),
                    new XElement(aw + "assignedPerson",
                        new XElement(aw + "templateId",
                            new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.1")),
                        new XElement(aw + "name",
                            new XElement(aw + "prefix", "dr n.med."),
                            new XElement(aw + "given", "Piotr"),
                            new XElement(aw + "family", "Nowak"))),
                    new XElement(aw + "representedOrganization",
                        new XElement(aw + "templateId",
                            new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.18")),
                        new XElement(aw + "id",
                            new XAttribute("extension", "2004-09"),
                            new XAttribute("root", "2.16.840.1.113883.3.4424.2.3.3"),
                            new XAttribute("displayable", "true")),
                        new XElement(aw + "name", "Oddział neurologii"),
                        new XElement(aw + "telecom",
                            new XAttribute("use", "PUB"),
                            new XAttribute("value", "tel:22-1111123")),
                        new XElement(aw + "addr",
                            new XElement(aw + "postalCode", "00 - 950"),
                            new XElement(aw + "city", "Warszawa"),
                            new XElement(aw + "streetName", "Solec"),
                            new XElement(aw + "houseNumber", "12")),
                        new XElement(aw + "standardIndustryClassCode",
                            new XAttribute("code", "4220"),
                            new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.11.2.4"),
                            new XAttribute("displayName", "Oddział neurologiczny")),
                        new XElement(aw + "asOrganizationPartOf",
                            new XElement(aw + "wholeOrganization",
                                new XElement(aw + "id",
                                    new XAttribute("extension", "11223344901234"),
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.2.2.2"),
                                    new XAttribute("displayable", "true")),
                                new XElement(aw + "name", "Wojewódzki szpital specjalistyczny"),
                                new XElement(aw + "asOrganizationPartOf",
                                    new XElement(aw + "wholeOrganization",
                                        new XElement(aw + "id",
                                            new XAttribute("extension", "2004"),
                                            new XAttribute("root", "2.16.840.1.113883.3.4424.2.3.1"),
                                            new XAttribute("displayable", "true")),
                                        new XElement(aw + "id",
                                            new XAttribute("extension", "121212445"),
                                            new XAttribute("root", "2.16.840.1.113883.3.4424.2.2.1"),
                                            new XAttribute("displayable", "true")),
                                        new XElement(aw + "name", "Wojewódzki Szpital Specjalistyczny"))))))));

            XElement custodian = new XElement(aw + "custodian",
                new XElement(aw + "templateId",
                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.5")),
                new XElement(aw + "assignedCustodian",
                    new XElement(aw + "representedCustodianOrganization",
                        new XElement(aw + "id",
                            new XAttribute("extension", "1099"),
                            new XAttribute("root", "2.16.840.1.113883.3.4424.2.3.1"),
                            new XAttribute("displayable", "false")))));

            XElement legalAuthenticator = new XElement(aw + "legalAuthenticator",
                new XElement(aw + "templateId",
                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.6")),
                new XElement(aw + "time",
                    new XAttribute("value", "20140906")),
                new XElement(aw + "signatureCode",
                    new XAttribute("code", "S")),
                new XElement(aw + "assignedEntity",
                    new XElement(aw + "id",
                        new XAttribute("extension", "7724513"),
                        new XAttribute("root", "2.16.840.1.113883.3.4424.1.6.2"),
                        new XAttribute("displayable", "true"))));

            XElement componentOf = new XElement(aw + "componentOf",
                new XAttribute("typeCode", "COMP"),
                new XElement(aw + "templateId",
                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.66")),
                new XElement(aw + "encompassingEncounter",
                    new XAttribute("classCode", "ENC"),
                    new XAttribute("moodCode", "EVN"),
                    new XElement(aw + "id",
                        new XAttribute("extension", "323432"),
                        new XAttribute("root", "2.16.840.1.113883.3.4424.2.7.0.98"),
                        new XAttribute("displayable", "true")),
                    new XElement(aw + "code",
                        new XAttribute("code", "4220"),
                        new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.11.2.4"),
                        new XAttribute("displayName", "Oddział neurologiczny")),
                    new XElement(aw + "effectiveTime",
                        new XElement(aw + "low",
                            new XAttribute("value", "20140901")),
                        new XElement(aw + "high",
                            new XAttribute("value", "20140906"))),
                    new XElement(aw + "dischargeDispositionCode",
                        new XAttribute("code", "1"),
                        new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.11.3.21"),
                        new XAttribute("displayName", "zakończenie procesu terapeutycznego lub diagnostycznego"))));
            /*
            XElement component = new XElement("component",
                new XAttribute("typeCode", "COMP"),
                new XAttribute("contextConductionInd", "true"),
                new XElement("templateId",
                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.60")),
                new XElement("structuredBody",
                    new XAttribute("classCode", "DOCBODY"),
                    new XAttribute("moodCode", "EVN"),
                    new XElement("component",
                        new XElement("section",
                            new XElement("templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.56"),
                                new XElement("text",
                                    new XElement("list",
                                        new XElement("caption", "Pobyty na oddziałach:"),
                                        new XElement("item", "01.09.2014 - 03.09.2014 Oddział kardiologii",
                                            new XAttribute("ID", "ENC_1")),
                                        new XElement("item", "03.09.2014 - 06.09.2014 Oddział neurologii",
                                            new XAttribute("ID", "ENC_2"))))),
                            new XElement("entry",
                                new XElement("encounter",
                                    new XAttribute("newclassCode", "ENC"),
                                    new XAttribute("moodCode", "EVN"),
                                    new XElement("templateId",
                                        new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.50")),
                                    new XElement("code",
                                        new XAttribute("code", "4100"),
                                        new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.11.2.4"),
                                        new XAttribute("displayName", "Oddział kardiologiczny")),
                                    new XElement("text",
                                        new XElement("reference",
                                            new XAttribute("value", "#ENC_1"))),
                                    new XElement("effectiveTime",
                                        new XElement("low",
                                            new XAttribute("value", "20140901")),
                                        new XElement("high",
                                            new XAttribute("value", "20140903"))))),
                            new XElement("entry",
                                new XElement("encounter",
                                    new XAttribute("classCode", "ENC"),
                                    new XAttribute("moodCode", "EVN"),
                                    new XElement("templateId",
                                        new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.50")),
                                    new XElement("code",
                                        new XAttribute("code", "4220"),
                                        new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.11.2.4"),
                                        new XAttribute("displayName", "Oddział neurologiczny")),
                                    new XElement("text",
                                        new XElement("reference",
                                            new XAttribute("value", "#ENC_2"))),
                                    new XElement("effectiveTime",
                                        new XElement("low",
                                            new XAttribute("value", "20140903")),
                                        new XElement("high",
                                            new XAttribute("value", "20140906"))))))),                  
                    new XElement("component",
                        new XElement("section",
                            new XElement("templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.1")),
                            new XElement("code",
                                new XAttribute("code", "29548-5"),
                                new XAttribute("codeSystem", "2.16.840.1.113883.6.1"),
                                new XAttribute("codeSystemName", "LOINC"),
                                new XAttribute("displayName", "Diagnosis")),
                            new XElement("title", "Rozpoznania"),
                            new XElement("text",
                                new XElement("table",
                                    new XElement("tbody",
                                        new XElement("tr",
                                            new XAttribute("ID", "DIAG_1"),
                                            new XElement("td", "Udar niedokrwienny mózgu"),
                                            new XElement("td", "I63.3")),
                                        new XElement("tr",
                                            new XAttribute("ID", "DIAG_2"),
                                            new XElement("td", "Nadciśnienie tętnicze"),
                                            new XElement("td", "I10"))))),
                            new XElement("entry",
                                new XElement("templateId",
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.1")),
                                new XElement("organizer",
                                    new XAttribute("classCode", "BATTERY"),
                                    new XAttribute("moodCode", "EVN"),
                                    new XElement("code",
                                        new XAttribute("code", "8319008"),
                                        new XAttribute("codeSystem", "2.16.840.1.113883.6.96"),
                                        new XAttribute("codeSystemName", "SNOMED CT"),
                                        new XAttribute("displayName", "Principal diagnosis")),
                                    new XElement("statusCode",
                                        new XAttribute("code", "completed")),
                                    new XElement("component",
                                        new XElement("observation",
                                            new XAttribute("classCode", "OBS"),
                                            new XAttribute("moodCode", "EVN"),
                                            new XElement("code",
                                                new XAttribute("code", "I63.3"),
                                                new XAttribute("codeSystem", "2.16.840.1.113883.6.3"),
                                                new XAttribute("codeSystemName", "icd10"),
                                                new XAttribute("displayName", "Zawał mózgu wywołany przez zakrzep tętnic mózgowych"),
                                                new XElement("text",
                                                    new XElement("reference",
                                                        new XAttribute("value", "#DIAG_1")))))))),
                            new XElement("entry",
                                new XElement("templateId",
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.2")),
                                new XElement("organizer",
                                    new XAttribute("classCode", "BATTERY"),
                                    new XAttribute("moodCode", "EVN"),
                                    new XElement("code",
                                        new XAttribute("code", "85097005"),
                                        new XAttribute("codeSystem", "2.16.840.1.113883.6.96"),
                                        new XAttribute("codeSystemName", "SNOMED CT"),
                                        new XAttribute("displayName", "Secondary diagnosis")),
                                    new XElement("statusCode",
                                        new XAttribute("code", "completed")),
                                    new XElement("component",
                                        new XElement("observation",
                                            new XAttribute("classCode", "OBS"),
                                            new XAttribute("moodCode", "EVN"),
                                            new XElement("code",
                                                new XAttribute("code", "I10"),
                                                new XAttribute("codeSystem", "2.16.840.1.113883.6.3"),
                                                new XAttribute("codeSystemName", "icd10"),
                                                new XAttribute("displayName", "Samoistne (pierwotne) nadciśnienie")),
                                            new XElement("text",
                                                new XElement("reference",
                                                    new XAttribute("value", "#DIAG_2"))))))))),
                    new XElement("component",
                        new XElement("section",
                            new XElement("templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.35")),
                            new XElement("code",
                                new XAttribute("code", "30954 -2"),
                                new XAttribute("codeSystem", "2.16.840.1.113883.6.1"),
                                new XAttribute("codeSystemName", "LOINC"),
                                new XAttribute("displayName", "Relevant diagnostic tests/laboratory data")),
                            new XElement("title", "Wyniki badań"),
                                new XElement("text",
                                    new XElement("table",
                                        new XElement("thead",
                                            new XElement("tr",
                                                new XElement("th", "Nazwa badania"),
                                                new XElement("th", "Wynik badania"),
                                                new XElement("th", "Zakres referencyjny"))),
                                        new XElement("tbody",
                                            new XElement("tr",
                                                new XAttribute("ID", "OBS_1"),
                                                new XElement("td", "Morfologia krwi obwodowej",
                                                    new XAttribute("colspan", "3"),
                                                    new XAttribute("styleCode", "Bold"))),
                                            new XElement("tr",
                                                new XAttribute("ID", "OBS_2"),
                                                new XElement("td", "WBC Krwinki białe"),
                                                new XElement("td", "8,3 K / &#181;l"),
                                                new XElement("td", "4,0 - 10,0")),
                                            new XElement("tr",
                                                new XAttribute("ID", "OBS_3"),
                                                new XElement("td", "RBC Krwinki czerwone"),
                                                new XElement("td", "3,35 M / &#181;l"),
                                                new XElement("td", "4,0 - 5,0")),
                                            new XElement("tr",
                                                new XAttribute("ID", "OBS_4"),
                                                new XElement("td", "PLT Płytki krwi"),
                                                new XElement("td", "331,0 K / &#181;l"),
                                                new XElement("td", "0 - 400,0")),
                                            new XElement("tr",
                                                new XAttribute("ID", "OBS_5"),
                                                new XElement("td", "HGB Hemoglobina"),
                                                new XElement("td", "7,8 g / dl"),
                                                new XElement("td", "12,0 - 16,0")),
                                            new XElement("tr",
                                                new XAttribute("ID", "OBS_6"),
                                                new XElement("td", "HCT Hematokryt"),
                                                new XElement("td", "27,1 %"),
                                                new XElement("td", "37,0 - 47,0")),
                                            new XElement("tr",
                                                new XAttribute("ID", "OBS_7"),
                                                new XElement("td", "MCHC"),
                                                new XElement("td", "28,8 g / dl"),
                                                new XElement("td", "31,0 - 36,0")),
                                            new XElement("tr",
                                                new XAttribute("ID", "OBS_8"),
                                                new XElement("td", "MCV"),
                                                new XElement("td", "80,9 fl"),
                                                new XElement("td", "80,0 - 96,0")),
                                            new XElement("tr",
                                                new XAttribute("ID", "OBS_9"),
                                                new XElement("td", "MCH"),
                                                new XElement("td", "23 pg"),
                                                new XElement("td", "26,0 - 32,0"))))))),
                    new XElement("component",
                        new XElement("section",
                            new XElement("templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.36")),
                            new XElement("code",
                                new XAttribute("code", "55753 -8"),
                                new XAttribute("codeSystem", "2.16.840.1.113883.6.1"),
                                new XAttribute("codeSystemName", "LOINC"),
                                new XAttribute("displayName", "Treatment information")),
                            new XElement("title", "Leczenie"),
                            new XElement("text",
                                new XElement("paragraph", "Farmakoterapia i rehabilitacja ruchowa.")))),
                    new XElement("component",
                        new XElement("section",
                            new XElement("templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.37")),
                            new XElement("code",
                                new XAttribute("code", "11493 -4"),
                                new XAttribute("codeSystem", "2.16.840.1.113883.6.1"),
                                new XAttribute("codeSystemName", "LOINC"),
                                new XAttribute("displayName", "Hospital discharge studies summary Narrative")),
                            new XElement("title", "Epikryza"),
                            new XElement("text",
                                new XElement("paragraph", "52 - letni pacjent przyjęty do Kliniki z powodu nagłego wystąpienia osłabienia siły mięśniowej lewych kończyn." +
                                "W badaniu neurologicznym przy przyjęciu - centralny niedowład n. VII lewego, niedoczulica lewej połowy twarzy, średniego stopnia niedowład lewej kończyny górnej, " +
                                "wzmożone napięcie mięśniowe kk.górnych typu pozapiramidowego, drżenie w obrębie prawej kończyny górnej, średniego stopnia niedowład lewej kończyny dolnej, " +
                                "wzmożone napięcie mięśniowe kk. dolnych typu pozapiramidowego, dodatni objaw Babińskiego po stronie lewej. W wywiadzie -nadciśnienie tętnicze, zespół parkinsonowski, " +
                                "łagodny przerost gruczołu krokowego, stan po cholecystektomii.W badaniu tomografii komputerowej głowy przy przyjęciu - " +
                                "wieloogniskowe naczyniopochodne uszkodzenie mózgu oraz zanik korowo-podkorowy mózgu.W badaniu USG tt. domózgowych - " +
                                "po stronie lewej zwężenie początkowego odcinka tętnicy szyjnej wewnętrznej o ok. 40 - 60 %, po stronie prawej stopień zwężenia trudny do oceny ze względu na cienie akustyczne od zwapnień - " +
                                "bez zaburzeń hemodynamiki przepływu krwi. W badaniu przezczaszkowym USG tt.mózgowych - bez zaburzeń przepływu. " +
                                "Ze względu na stwierdzane podczas ostatniej hospitalizacji na Oddziale Kardiologii poszerzenie aorty wstępującej w obrazie echokardiograficznym wykonano badanie kontrolne - " +
                                "obraz serca i naczyń porównywany w badaniem poprzednim.W trakcie hospitalizacji stosowano leczenie przeciwobrzękowe, przeciwpłytkowe, " +
                                "przeciwnadciśnieniowe, hipolipemizujące oraz rehabilitację ruchową uzyskując dużą poprawę stanu neurologicznego w zakresie sprawności lewych kończyn.Ze względu na objawy pozapiramidowe włączono " +
                                "Madopar w dawce 250mg / dobę w czterech dawkach podzielonych. Chorego w stanie ogólnym dobrym wypisano do domu.W badaniu neurologicznym w dniu wypisu - dyskretny niedowład lewej kończyny górnej, " +
                                "wzmożone napięcie mięśniowe kk.górnych typu pozapiramidowego - o mniejszym nasileniu, dyskretny niedowład lewej kończyny dolnej, wmożone napięcie mięśniowe kk.dolnych typu pozapiramidowego -" +
                                " o mniejszym nasileniu, bez objawów patologicznych.")))),
                    new XElement("component",
                        new XElement("section",
                            new XElement("templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.32")),
                            new XElement("code",
                                new XAttribute("code", "57828 -6"),
                                new XAttribute("codeSystem", "2.16.840.1.113883.6.1"),
                                new XAttribute("codeSystemName", "LOINC"),
                                new XAttribute("displayName", "Prescriptions /Prescription list")),
                            new XElement("title", "Zalecenia"),
                            new XElement("text",
                                new XElement("list",
                                    new XElement("item", "Polocard 150 mg, 2 x 1 tabl.",
                                        new XAttribute("ID", "SBADM_1")),
                                    new XElement("item", "Atoris 20 mg, 2 x 1 tabl. (rano i wieczorem)",
                                        new XAttribute("ID", "SBADM_2")),
                                    new XElement("item", "Pić przynajmniej 2 litry wody dziennie"))),
                            new XElement("entry",
                                new XElement("templateId",
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.22")),
                                new XElement("substanceAdministration",
                                    new XAttribute("classCode", "SBADM"),
                                    new XAttribute("moodCode", "RQO"),
                                    new XElement("text",
                                        new XElement("reference",
                                            new XAttribute("value", "#SBADM_1"))),
                                    new XElement("consumable",
                                        new XElement("manufacturedProduct",
                                            new XElement("templateId",
                                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.21")),
                                            new XElement("manufacturedLabeledDrug",
                                                new XElement("code",
                                                    new XAttribute("code", "100997"),
                                                    new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.6.1"),
                                                    new XAttribute("displayName", "Polocard 150 mg tabletki"))))))),
                            new XElement("entry",
                                new XElement("templateId",
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.22")),
                                new XElement("substanceAdministration",
                                    new XAttribute("classCode", "SBADM"),
                                    new XAttribute("moodCode", "RQO"),
                                    new XElement("text",
                                        new XElement("reference",
                                            new XAttribute("value", "#SBADM_2"))),
                                    new XElement("consumable",
                                        new XElement("manufacturedProduct",
                                            new XElement("templateId",
                                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.21")),
                                            new XElement("manufacturedLabeledDrug",
                                                new XElement("code",
                                                    new XAttribute("code", "100996"),
                                                    new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.6.1"),
                                                    new XAttribute("displayName", "Atoris 20 mg tabletki"))))))))))); */
                                           
            XElement component = new XElement(aw + "component",
                new XAttribute("typeCode", "COMP"),
                new XAttribute("contextConductionInd", "true"),
                new XElement(aw + "templateId",
                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.60")),
                new XElement(aw + "structuredBody",
                    new XAttribute("classCode", "DOCBODY"),
                    new XAttribute("moodCode", "EVN"),
                    new XElement(aw + "component",
                        new XElement(aw + "section",
                            new XElement(aw + "templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.56")),
                                new XElement(aw + "text",
                                    new XElement(aw + "list",
                                        new XElement(aw + "caption", "Pobyty na oddziałach:"),
                                        new XElement(aw + "item",
                                            new XAttribute("ID", "ENC_1"),"01.09.2014 - 03.09.2014 Oddział kardiologii"),
                                        new XElement(aw + "item",
                                            new XAttribute("ID", "ENC_2"),"03.09.2014 - 06.09.2014 Oddział neurologii"))),

                            new XElement(aw + "entry",
                                new XElement(aw + "encounter",
                                    new XAttribute("newclassCode", "ENC"),
                                    new XAttribute("moodCode", "EVN"),
                                    new XElement(aw + "templateId",
                                        new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.50")),
                                    new XElement(aw + "code",
                                        new XAttribute("code", "4100"),
                                        new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.11.2.4"),
                                        new XAttribute("displayName", "Oddział kardiologiczny")),
                                    new XElement(aw + "text",
                                        new XElement(aw + "reference",
                                            new XAttribute("value", "#ENC_1"))),
                                    new XElement(aw + "effectiveTime",
                                        new XElement(aw + "low",
                                            new XAttribute("value", "20140901")),
                                        new XElement(aw + "high",
                                            new XAttribute("value", "20140903"))))),
                            new XElement(aw + "entry",
                                new XElement(aw + "encounter",
                                    new XAttribute("classCode", "ENC"),
                                    new XAttribute("moodCode", "EVN"),
                                    new XElement(aw + "templateId",
                                        new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.50")),
                                    new XElement(aw + "code",
                                        new XAttribute("code", "4220"),
                                        new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.11.2.4"),
                                        new XAttribute("displayName", "Oddział neurologiczny")),
                                    new XElement(aw + "text",
                                        new XElement(aw + "reference",
                                            new XAttribute("value", "#ENC_2"))),
                                    new XElement(aw + "effectiveTime",
                                        new XElement(aw + "low",
                                            new XAttribute("value", "20140903")),
                                        new XElement(aw + "high",
                                            new XAttribute("value", "20140906"))))))),                  
                    new XElement(aw + "component",
                        new XElement(aw + "section",
                            new XElement(aw + "templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.1")),
                            new XElement(aw + "code",
                                new XAttribute("code", "29548-5"),
                                new XAttribute("codeSystem", "2.16.840.1.113883.6.1"),
                                new XAttribute("codeSystemName", "LOINC"),
                                new XAttribute("displayName", "Diagnosis")),
                            new XElement(aw + "title", "Rozpoznania"),
                            new XElement(aw + "text",
                                new XElement(aw + "table",
                                    new XElement(aw + "tbody",
                                        new XElement(aw + "tr",
                                            new XAttribute("ID", "DIAG_1"),
                                            new XElement(aw + "td", "Udar niedokrwienny mózgu"),
                                            new XElement(aw + "td", "I63.3")),
                                        new XElement(aw + "tr",
                                            new XAttribute("ID", "DIAG_2"),
                                            new XElement(aw + "td", "Nadciśnienie tętnicze"),
                                            new XElement(aw + "td", "I10"))))),
                            new XElement(aw + "entry",
                                new XElement(aw + "templateId",
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.1")),
                                new XElement(aw + "organizer",
                                    new XAttribute("classCode", "BATTERY"),
                                    new XAttribute("moodCode", "EVN"),
                                    new XElement(aw + "code",
                                        new XAttribute("code", "8319008"),
                                        new XAttribute("codeSystem", "2.16.840.1.113883.6.96"),
                                        new XAttribute("codeSystemName", "SNOMED CT"),
                                        new XAttribute("displayName", "Principal diagnosis")),
                                    new XElement(aw + "statusCode",
                                        new XAttribute("code", "completed")),
                                    new XElement(aw + "component",
                                        new XElement(aw + "observation",
                                            new XAttribute("classCode", "OBS"),
                                            new XAttribute("moodCode", "EVN"),
                                            new XElement(aw + "code",
                                                new XAttribute("code", "I63.3"),
                                                new XAttribute("codeSystem", "2.16.840.1.113883.6.3"),
                                                new XAttribute("codeSystemName", "icd10"),
                                                new XAttribute("displayName", "Zawał mózgu wywołany przez zakrzep tętnic mózgowych"),
                                                new XElement(aw + "text",
                                                    new XElement(aw + "reference",
                                                        new XAttribute("value", "#DIAG_1")))))))),
                            new XElement(aw + "entry",
                                new XElement(aw + "templateId",
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.2")),
                                new XElement(aw + "organizer",
                                    new XAttribute("classCode", "BATTERY"),
                                    new XAttribute("moodCode", "EVN"),
                                    new XElement(aw + "code",
                                        new XAttribute("code", "85097005"),
                                        new XAttribute("codeSystem", "2.16.840.1.113883.6.96"),
                                        new XAttribute("codeSystemName", "SNOMED CT"),
                                        new XAttribute("displayName", "Secondary diagnosis")),
                                    new XElement(aw + "statusCode",
                                        new XAttribute("code", "completed")),
                                    new XElement(aw + "component",
                                        new XElement(aw + "observation",
                                            new XAttribute("classCode", "OBS"),
                                            new XAttribute("moodCode", "EVN"),
                                            new XElement(aw + "code",
                                                new XAttribute("code", "I10"),
                                                new XAttribute("codeSystem", "2.16.840.1.113883.6.3"),
                                                new XAttribute("codeSystemName", "icd10"),
                                                new XAttribute("displayName", "Samoistne (pierwotne) nadciśnienie")),
                                            new XElement(aw + "text",
                                                new XElement(aw + "reference",
                                                    new XAttribute("value", "#DIAG_2"))))))))),
                    new XElement(aw + "component",
                        new XElement(aw + "section",
                            new XElement(aw + "templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.35")),
                            new XElement(aw + "code",
                                new XAttribute("code", "30954 -2"),
                                new XAttribute("codeSystem", "2.16.840.1.113883.6.1"),
                                new XAttribute("codeSystemName", "LOINC"),
                                new XAttribute("displayName", "Relevant diagnostic tests/laboratory data")),
                            new XElement(aw + "title", "Wyniki badań"),
                                new XElement(aw + "text",
                                    new XElement(aw + "table",
                                        new XElement(aw + "thead",
                                            new XElement(aw + "tr",
                                                new XElement(aw + "th", "Nazwa badania"),
                                                new XElement(aw + "th", "Wynik badania"),
                                                new XElement(aw + "th", "Zakres referencyjny"))),
                                        new XElement(aw + "tbody",
                                            new XElement(aw + "tr",
                                                new XAttribute("ID", "OBS_1"),
                                                new XElement(aw + "td", "Morfologia krwi obwodowej",
                                                    new XAttribute("colspan", "3"),
                                                    new XAttribute("styleCode", "Bold"))),
                                            new XElement(aw + "tr",
                                                new XAttribute("ID", "OBS_2"),
                                                new XElement(aw + "td", "WBC Krwinki białe"),
                                                new XElement(aw + "td", "8,3 K / &#181;l"),
                                                new XElement(aw + "td", "4,0 - 10,0")),
                                            new XElement(aw + "tr",
                                                new XAttribute("ID", "OBS_3"),
                                                new XElement(aw + "td", "RBC Krwinki czerwone"),
                                                new XElement(aw + "td", "3,35 M / &#181;l"),
                                                new XElement(aw + "td", "4,0 - 5,0")),
                                            new XElement(aw + "tr",
                                                new XAttribute("ID", "OBS_4"),
                                                new XElement(aw + "td", "PLT Płytki krwi"),
                                                new XElement(aw + "td", "331,0 K / &#181;l"),
                                                new XElement(aw + "td", "0 - 400,0")),
                                            new XElement(aw + "tr",
                                                new XAttribute("ID", "OBS_5"),
                                                new XElement(aw + "td", "HGB Hemoglobina"),
                                                new XElement(aw + "td", "7,8 g / dl"),
                                                new XElement(aw + "td", "12,0 - 16,0")),
                                            new XElement(aw + "tr",
                                                new XAttribute("ID", "OBS_6"),
                                                new XElement(aw + "td", "HCT Hematokryt"),
                                                new XElement(aw + "td", "27,1 %"),
                                                new XElement(aw + "td", "37,0 - 47,0")),
                                            new XElement(aw + "tr",
                                                new XAttribute("ID", "OBS_7"),
                                                new XElement(aw + "td", "MCHC"),
                                                new XElement(aw + "td", "28,8 g / dl"),
                                                new XElement(aw + "td", "31,0 - 36,0")),
                                            new XElement(aw + "tr",
                                                new XAttribute("ID", "OBS_8"),
                                                new XElement(aw + "td", "MCV"),
                                                new XElement(aw + "td", "80,9 fl"),
                                                new XElement(aw + "td", "80,0 - 96,0")),
                                            new XElement(aw + "tr",
                                                new XAttribute("ID", "OBS_9"),
                                                new XElement(aw + "td", "MCH"),
                                                new XElement(aw + "td", "23 pg"),
                                                new XElement(aw + "td", "26,0 - 32,0"))))))),
                    new XElement(aw + "component",
                        new XElement(aw + "section",
                            new XElement(aw + "templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.36")),
                            new XElement(aw + "code",
                                new XAttribute("code", "55753 -8"),
                                new XAttribute("codeSystem", "2.16.840.1.113883.6.1"),
                                new XAttribute("codeSystemName", "LOINC"),
                                new XAttribute("displayName", "Treatment information")),
                            new XElement(aw + "title", "Leczenie"),
                            new XElement(aw + "text",
                                new XElement(aw + "paragraph", "Farmakoterapia i rehabilitacja ruchowa.")))),
                    new XElement(aw + "component",
                        new XElement(aw + "section",
                            new XElement(aw + "templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.37")),
                            new XElement(aw + "code",
                                new XAttribute("code", "11493 -4"),
                                new XAttribute("codeSystem", "2.16.840.1.113883.6.1"),
                                new XAttribute("codeSystemName", "LOINC"),
                                new XAttribute("displayName", "Hospital discharge studies summary Narrative")),
                            new XElement(aw + "title", "Epikryza"),
                            new XElement(aw + "text",
                                new XElement(aw + "paragraph", "52 - letni pacjent przyjęty do Kliniki z powodu nagłego wystąpienia osłabienia siły mięśniowej lewych kończyn." +
                                "W badaniu neurologicznym przy przyjęciu - centralny niedowład n. VII lewego, niedoczulica lewej połowy twarzy, średniego stopnia niedowład lewej kończyny górnej, " +
                                "wzmożone napięcie mięśniowe kk.górnych typu pozapiramidowego, drżenie w obrębie prawej kończyny górnej, średniego stopnia niedowład lewej kończyny dolnej, " +
                                "wzmożone napięcie mięśniowe kk. dolnych typu pozapiramidowego, dodatni objaw Babińskiego po stronie lewej. W wywiadzie -nadciśnienie tętnicze, zespół parkinsonowski, " +
                                "łagodny przerost gruczołu krokowego, stan po cholecystektomii.W badaniu tomografii komputerowej głowy przy przyjęciu - " +
                                "wieloogniskowe naczyniopochodne uszkodzenie mózgu oraz zanik korowo-podkorowy mózgu.W badaniu USG tt. domózgowych - " +
                                "po stronie lewej zwężenie początkowego odcinka tętnicy szyjnej wewnętrznej o ok. 40 - 60 %, po stronie prawej stopień zwężenia trudny do oceny ze względu na cienie akustyczne od zwapnień - " +
                                "bez zaburzeń hemodynamiki przepływu krwi. W badaniu przezczaszkowym USG tt.mózgowych - bez zaburzeń przepływu. " +
                                "Ze względu na stwierdzane podczas ostatniej hospitalizacji na Oddziale Kardiologii poszerzenie aorty wstępującej w obrazie echokardiograficznym wykonano badanie kontrolne - " +
                                "obraz serca i naczyń porównywany w badaniem poprzednim.W trakcie hospitalizacji stosowano leczenie przeciwobrzękowe, przeciwpłytkowe, " +
                                "przeciwnadciśnieniowe, hipolipemizujące oraz rehabilitację ruchową uzyskując dużą poprawę stanu neurologicznego w zakresie sprawności lewych kończyn.Ze względu na objawy pozapiramidowe włączono " +
                                "Madopar w dawce 250mg / dobę w czterech dawkach podzielonych. Chorego w stanie ogólnym dobrym wypisano do domu.W badaniu neurologicznym w dniu wypisu - dyskretny niedowład lewej kończyny górnej, " +
                                "wzmożone napięcie mięśniowe kk.górnych typu pozapiramidowego - o mniejszym nasileniu, dyskretny niedowład lewej kończyny dolnej, wmożone napięcie mięśniowe kk.dolnych typu pozapiramidowego -" +
                                " o mniejszym nasileniu, bez objawów patologicznych.")))),
                    new XElement(aw + "component",
                        new XElement(aw + "section",
                            new XElement(aw + "templateId",
                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.3.32")),
                            new XElement(aw + "code",
                                new XAttribute("code", "57828 -6"),
                                new XAttribute("codeSystem", "2.16.840.1.113883.6.1"),
                                new XAttribute("codeSystemName", "LOINC"),
                                new XAttribute("displayName", "Prescriptions /Prescription list")),
                            new XElement(aw + "title", "Zalecenia"),
                            new XElement(aw + "text",
                                new XElement(aw + "list",
                                    new XElement(aw + "item", "Polocard 150 mg, 2 x 1 tabl.",
                                        new XAttribute("ID", "SBADM_1")),
                                    new XElement(aw + "item", "Atoris 20 mg, 2 x 1 tabl. (rano i wieczorem)",
                                        new XAttribute("ID", "SBADM_2")),
                                    new XElement(aw + "item", "Pić przynajmniej 2 litry wody dziennie"))),
                            new XElement(aw + "entry",
                                new XElement(aw + "templateId",
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.22")),
                                new XElement(aw + "substanceAdministration",
                                    new XAttribute("classCode", "SBADM"),
                                    new XAttribute("moodCode", "RQO"),
                                    new XElement(aw + "text",
                                        new XElement(aw + "reference",
                                            new XAttribute("value", "#SBADM_1"))),
                                    new XElement(aw + "consumable",
                                        new XElement(aw + "manufacturedProduct",
                                            new XElement(aw + "templateId",
                                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.21")),
                                            new XElement(aw + "manufacturedLabeledDrug",
                                                new XElement(aw + "code",
                                                    new XAttribute("code", "100997"),
                                                    new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.6.1"),
                                                    new XAttribute("displayName", "Polocard 150 mg tabletki"))))))),
                            new XElement(aw + "entry",
                                new XElement(aw + "templateId",
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.22")),
                                new XElement(aw + "substanceAdministration",
                                    new XAttribute("classCode", "SBADM"),
                                    new XAttribute("moodCode", "RQO"),
                                    new XElement(aw + "text",
                                        new XElement(aw + "reference",
                                            new XAttribute("value", "#SBADM_2"))),
                                    new XElement(aw + "consumable",
                                        new XElement(aw + "manufacturedProduct",
                                            new XElement(aw + "templateId",
                                                new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.4.21")),
                                            new XElement(aw + "manufacturedLabeledDrug",
                                                new XElement(aw + "code",
                                                    new XAttribute("code", "100996"),
                                                    new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.6.1"),
                                                    new XAttribute("displayName", "Atoris 20 mg tabletki")))))))))));

            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "no"),
                new XProcessingInstruction("xml-stylesheet", "href=\"CDA_PL_IG_1.3.1.xsl\" type=\"text/xsl\""),
                new XElement(aw + "ClinicalDocument",
                    new XAttribute(XNamespace.Xmlns + "xsi", xsi.NamespaceName),
                    new XAttribute(XNamespace.Xmlns + "extPL", extPL.NamespaceName),
                    new XComment("Karta informacyjna leczenia szpitalnego"),
                    new XElement(aw + "typeId",
                        new XAttribute("extension", "POCD_HD000040"),
                        new XAttribute("root", "2.16.840.1.113883.1.3")),
                    new XElement(aw + "templateId",
                        new XAttribute("extension", "1.1.1"),
                        new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.1.18")),
                    new XElement(aw + "id",
                        new XAttribute("extension", "2345678"),
                        new XAttribute("root", "2.16.840.1.113883.3.4424.2.7.0.7.1"),
                        new XAttribute("displayable", "false")),
                    // CODE
                    new XElement(aw + "code",
                        new XAttribute("code", "18842-5"),
                        new XAttribute("codeSystem", "2.16.840.1.113883.6.1"),
                        new XAttribute("codeSystemName", "LOINC"),
                        new XAttribute("displayName", "Discharge summary"),
                        new XElement(aw + "translation",
                            new XAttribute("code", "00.20"),
                            new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.11.1.32"),
                            new XAttribute("codeSystemName", "KLAS_DOK_P1"),
                            new XAttribute("displayName", "Karta informacyjna z leczenia szpitalnego"))),
                    new XElement(aw + "title", "Karta informacyjna z leczenia szpitalnego"),
                    new XElement(aw + "effectiveTime",
                        new XAttribute("value", "20140906")),
                    new XElement(aw + "confidentialityCode",
                        new XAttribute("code", "N"),
                        new XAttribute("codeSystem", "2.16.840.1.113883.5.25")),
                    new XElement(aw + "languageCode",
                        new XAttribute("code", "pl-PL")),
                    new XElement(aw + "setId",
                        new XAttribute("extension", "432231"),
                        new XAttribute("root", "2.16.840.1.113883.3.4424.2.7.0.7.2")),
                    new XElement(aw + "versionNumber",
                        new XAttribute("value", 1)),
                    // Osoba 
            #region
                    new XElement(aw + "recordTarget",
                        new XElement(aw + "templateId",
                            new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.3")),
                        new XElement(aw + "patientRole",
                            new XElement(aw + "id",
                                new XAttribute("extension", "12345"),           //Id Pacjenta
                                new XAttribute("root", "2.16.840.1.113883.3.4424.2.7.0.17.1"),
                                new XAttribute("displayable", "false")),
                            new XElement(aw + "id",
                                new XAttribute("extension", "62091599999"),     // Pesel
                                new XAttribute("root", "2.16.840.1.113883.3.4424.1.1.616"),
                                new XAttribute("displayable", "true")),
                            new XElement(aw + "addr",
                                new XElement(aw + "city", "Warszawa"),                // Adres 
                                new XElement(aw + "postalCode", "01-134"),
                                new XElement(aw + "streetName", "Odkryta"),
                                new XElement(aw + "houseNumber", 41),
                                new XElement(aw + "unitID", 12)),
                            new XElement(aw + "patient",                             // Dane Osobowe
                                new XElement(aw + "name",
                                    new XElement(aw + "given", "Jan"),
                                    new XElement(aw + "given", "Franciszek"),
                                    new XElement(aw + "family", "Kowalski")),
                                new XElement(aw + "birthTime",
                                    new XAttribute("value", "19620915"))),
                            new XElement(aw + "providerOrganization",
                                new XAttribute("classCode", "ORG"),
                                new XElement(aw + "templateId",
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.2")),
                                new XElement(aw + "id",
                                    new XAttribute("extension", "1099"),
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.2.3.1"),
                                    new XAttribute("displayable", "false"))))),
            #endregion
            author,custodian,legalAuthenticator, componentOf,component

            //author
                 )
            );
       
            xmlDocument.Save(@"C:/Pliki/KartaInformacyjna.xml");

            string dane = "Pier23";
            string connectionString = "DATA SOURCE=orclcdb.localdomain;PASSWORD=dokmed1234;USER ID=DOKMED";
            //string queryString = "select count(*) from TESTXML";
            //string queryString = "insert into TEST VALUES('23','"+dane+"')";
            //string queryString = "insert into DOKUMENTY VALUES(,,,,123,'" + xmlDocument+"')";
            //string queryString = "insert into DOKUMENTY(autor, dane_xml) VALUES(123,'"+ xmlDocument + "')";
            //string queryString = "insert into DOKUMENTY(autor, dane_clob) VALUES(123,'"+ xmlDocument + "')";
            string queryString = "DECLARE tym clob:='" + xmlDocument.ToString() + "'; begin insert into DOKUMENTY(autor, dane_clob) VALUES(123, tym);commit;end;";

            //string queryString = "insert into DOKUMENTY(autor, dane_xml) VALUES(123,'" + custodian + "')";,

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