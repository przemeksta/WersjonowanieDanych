using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WersjonowanieDanych
{
    public class XEL_custodian
    {
        private static readonly XNamespace aw = "urn:hl7-org:v3";
        private XElement custodian;

        public XEL_custodian()
        {
            custodian = new XElement(aw + "custodian",
                new XElement(aw + "templateId",
                    new XAttribute("root", "2.16.840.1.113883.3.4424.13.10.2.5")),
                new XElement(aw + "assignedCustodian",
                    new XElement(aw + "representedCustodianOrganization",
                        new XElement(aw + "id",
                            new XAttribute("extension", "1099"),
                            new XAttribute("root", "2.16.840.1.113883.3.4424.2.3.1"),
                            new XAttribute("displayable", "false")))));
        }
        public XElement ZrotWartosci()
        {
            return custodian;
        }
    }
}