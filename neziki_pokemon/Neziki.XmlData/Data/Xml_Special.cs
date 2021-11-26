using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Neziki.XmlData.Data
{
    [XmlRoot("Inf_Special")]
    public class List_Xml_Special
    {
        [XmlElement("member")]
        public List<Xml_Special> List { get; set; }
    }

    [XmlRoot("member")]
    public class Xml_Special
    {
        [XmlAttribute("ID")]
        public String ID { get; set; }
        [XmlElement("Name")]
        public String Name { get; set; }
        [XmlElement("Text")]
        public String Text { get; set; }
        [XmlElement("Magnification")]
        public String Magnification { get; set; }
        [XmlElement("Conditions")]
        public String Conditions { get; set; }
    }
}
