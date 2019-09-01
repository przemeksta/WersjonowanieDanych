using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Schema;
using System.Xml;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace WersjonowanieDanych
{
    public class XEL_author
    {
        private static readonly XNamespace aw = "urn:hl7-org:v3";
        private XElement given;
        private XElement family;
        private XElement nameSzpital;
        private XElement nameOddzial;
        private XAttribute displayNameOddzial;

        private XElement author;

        public XEL_author()
        {
            // domyslny Autor
            author = new XElement(aw + "author",
            #region author
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
                            new XElement(aw + "prefix", "dr n. med."),
                            new XElement(aw + "given", "Piotr"),
                            new XElement(aw + "family", "Nowak")
                            )),
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
                            new XElement(aw + "postalCode", "00-950"),
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
            #endregion
        }

        public XEL_author(string givenS, string familyS, string nameSzpitalS, string nameOddzialS)
        {
            given = new XElement(aw + "given", givenS);
            family = new XElement(aw + "family", familyS);
            nameSzpital = new XElement(aw + "name", nameSzpitalS);
            nameOddzial = new XElement(aw + "name", nameOddzialS);
            displayNameOddzial = new XAttribute("displayName", nameOddzialS);

            author = new XElement(aw + "author",
            #region author
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
                            new XElement(aw + "prefix", "dr n. med."),
                            given, 
                            family
                            )),
                    new XElement(aw + "representedOrganization",
                        new XElement(aw + "templateId",
                            new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.18")),
                        new XElement(aw + "id",
                            new XAttribute("extension", "2004-09"),
                            new XAttribute("root", "2.16.840.1.113883.3.4424.2.3.3"),
                            new XAttribute("displayable", "true")),
                        nameOddzial,
                        new XElement(aw + "telecom",
                            new XAttribute("use", "PUB"),
                            new XAttribute("value", "tel:22-1111123")),
                        new XElement(aw + "addr",
                            new XElement(aw + "postalCode", "00-950"),
                            new XElement(aw + "city", "Warszawa"),
                            new XElement(aw + "streetName", "Solec"),
                            new XElement(aw + "houseNumber", "12")),
                        new XElement(aw + "standardIndustryClassCode",
                            new XAttribute("code", "4220"),
                            new XAttribute("codeSystem", "2.16.840.1.113883.3.4424.11.2.4"),
                            displayNameOddzial
                            ),
                        new XElement(aw + "asOrganizationPartOf",
                            new XElement(aw + "wholeOrganization",
                                new XElement(aw + "id",
                                    new XAttribute("extension", "11223344901234"),
                                    new XAttribute("root", "2.16.840.1.113883.3.4424.2.2.2"),
                                    new XAttribute("displayable", "true")),
                                nameSzpital,
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
                                        nameSzpital
                                        )))))));
            #endregion
        }

        public XElement ZrotWartosci()
        {
            return author;
        }
    }

}