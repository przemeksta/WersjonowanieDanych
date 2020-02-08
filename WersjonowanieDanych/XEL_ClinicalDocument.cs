using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WersjonowanieDanych
{
    public class XEL_ClinicalDocument
    {
        private static readonly XNamespace aw = "urn:hl7-org:v3";
        private static readonly XNamespace xsi = "http://www.w3.org/2001/XMLSchema-instance";
        private static readonly XNamespace extPL = "http://www.csioz.gov.pl/xsd/extPL/r2";

        private XElement ClinicalDocument;

        public XEL_ClinicalDocument()
        {
            ClinicalDocument = new XElement(aw + "ClinicalDocument",
            #region ClinicalDocument 
                        new XAttribute(XNamespace.Xmlns + "xsi", xsi.NamespaceName),
                        new XAttribute(XNamespace.Xmlns + "extPL", extPL.NamespaceName),
                        //new XComment("Karta informacyjna leczenia szpitalnego"),
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
                            new XAttribute("value", 1))
                    );
            #endregion
        }

        public XEL_ClinicalDocument(XElement recordTarget, XElement author, XElement custodian, XElement legalAuthenticator, XElement componentOf, XElement component)
        {
            ClinicalDocument = new XElement(aw + "ClinicalDocument",
                    #region ClinicalDocument 
                        new XAttribute(XNamespace.Xmlns + "xsi", xsi.NamespaceName),
                        new XAttribute(XNamespace.Xmlns + "extPL", extPL.NamespaceName),
                        //new XComment("Karta informacyjna leczenia szpitalnego"),
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
                        recordTarget, author, custodian, legalAuthenticator, componentOf, component
                        //recordTarget.ZrotWartosci(), author.ZrotWartosci(), custodian.ZrotWartosci(), legalAuthenticator.ZrotWartosci(), componentOf.ZrotWartosci(), component.ZrotWartosci()
                    );
                        #endregion
        }

        public XElement ZrotWartosci()
        {
            return ClinicalDocument;
        }
    }
}