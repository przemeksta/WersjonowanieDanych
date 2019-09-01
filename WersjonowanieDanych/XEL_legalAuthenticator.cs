using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WersjonowanieDanych
{
    public class XEL_legalAuthenticator
    {
        private static readonly XNamespace aw = "urn:hl7-org:v3";
        private XAttribute valueTime;
        private XElement legalAuthenticator;

        public XEL_legalAuthenticator()
        {
            legalAuthenticator = new XElement(aw + "legalAuthenticator",
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
        }

        public XEL_legalAuthenticator(string timeS)
        {
            valueTime = new XAttribute("displayName", timeS);
            legalAuthenticator = new XElement(aw + "legalAuthenticator",
                new XElement(aw + "templateId",
                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.6")),
                new XElement(aw + "time",
                    valueTime
                    ),
                new XElement(aw + "signatureCode",
                    new XAttribute("code", "S")),
                new XElement(aw + "assignedEntity",
                    new XElement(aw + "id",
                        new XAttribute("extension", "7724513"),
                        new XAttribute("root", "2.16.840.1.113883.3.4424.1.6.2"),
                        new XAttribute("displayable", "true"))));
        }

        public XElement ZrotWartosci()
        {
            return legalAuthenticator;
        }
    }
}