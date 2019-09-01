using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WersjonowanieDanych
{
    public class XEL_componentOf
    {
        private static readonly XNamespace aw = "urn:hl7-org:v3";

        private XElement componentOf;

        public XEL_componentOf()
        {
            componentOf = new XElement(aw + "componentOf",
            #region componentOf
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
                        #endregion
        }
        public XElement ZrotWartosci()
        {
            return componentOf;
        }
    }
}