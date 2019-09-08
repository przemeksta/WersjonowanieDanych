using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WersjonowanieDanych
{
    public class XEL_recordTarget
    {
        private static readonly XNamespace aw = "urn:hl7-org:v3";

        private XElement recordTarget;

        private XElement city;
        private XElement postalCode;
        private XElement streetName;
        private XElement houseNumber;
        private XElement unitID;
        private XElement given1;
        private XElement given2;
        private XElement family;

        public XEL_recordTarget()
        {
            recordTarget = new XElement(aw + "recordTarget",
            #region recordTarget 
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
                        new XElement(aw + "administrativeGenderCode",
                            new XAttribute("code", "M"),
                            new XAttribute("codeSystem", "2.16.840.1.113883.5.1")),
                        new XElement(aw + "birthTime",
                            new XAttribute("value", "19620915"))),
                    new XElement(aw + "providerOrganization",
                        new XAttribute("classCode", "ORG"),
                        new XElement(aw + "templateId",
                            new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.2")),
                        new XElement(aw + "id",
                            new XAttribute("extension", "1099"),
                            new XAttribute("root", "2.16.840.1.113883.3.4424.2.3.1"),
                            new XAttribute("displayable", "false")))));
                        #endregion
        }

        public XEL_recordTarget(string IDpacjentaS, string peselS, string adresMiastoS, string adresKodPocztowyS,
            string adresUlicaS, string adresNrDomuS, string adresNrMieszkanieS, string imie1S, string imie2S, 
            string nazwiskoS, string plecS, string dataUrodzeniaS)
        {
            city = new XElement(aw + "city", adresMiastoS);
            postalCode = new XElement(aw + "postalCode", adresKodPocztowyS);
            streetName = new XElement(aw + "streetName", adresUlicaS);
            houseNumber = new XElement(aw + "houseNumber", adresNrDomuS);
            unitID = new XElement(aw + "unitID", adresNrMieszkanieS);
            given1 = new XElement(aw + "given", imie1S);
            given2 = new XElement(aw + "given", imie2S);
            family = new XElement(aw + "family", nazwiskoS);

            recordTarget = new XElement(aw + "recordTarget",
            #region recordTarget 
                new XElement(aw + "templateId",
                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.3")),
                new XElement(aw + "patientRole",
                    new XElement(aw + "id",
                        new XAttribute("extension", IDpacjentaS),           //Id Pacjenta
                        new XAttribute("root", "2.16.840.1.113883.3.4424.2.7.0.17.1"),
                        new XAttribute("displayable", "false")),
                    new XElement(aw + "id",
                        new XAttribute("extension", peselS),     // Pesel
                        new XAttribute("root", "2.16.840.1.113883.3.4424.1.1.616"),
                        new XAttribute("displayable", "true")),
                    new XElement(aw + "addr",                               //Adres
                        city, postalCode, streetName, houseNumber, unitID),
                    new XElement(aw + "patient",                             // Dane Osobowe
                        new XElement(aw + "name", given1, given2,family),
                        new XElement(aw + "administrativeGenderCode",
                            new XAttribute("code", plecS),                       // plec
                            new XAttribute("codeSystem", "2.16.840.1.113883.5.1")),
                        new XElement(aw + "birthTime",                       // data urodzenia
                            new XAttribute("value", dataUrodzeniaS))),
                    new XElement(aw + "providerOrganization",
                        new XAttribute("classCode", "ORG"),
                        new XElement(aw + "templateId",
                            new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.2")),
                        new XElement(aw + "id",
                            new XAttribute("extension", "1099"),
                            new XAttribute("root", "2.16.840.1.113883.3.4424.2.3.1"),
                            new XAttribute("displayable", "false")))));
            #endregion
        }

        public XElement ZrotWartosci()
        {
            return recordTarget;
        }
    }
}