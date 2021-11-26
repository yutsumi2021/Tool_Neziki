using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Neziki.XmlData.Data
{
    [XmlRoot("Inf_Skill")]
    public class List_Xml_Skill
    {
        [XmlElement("member")]
        public List<Xml_Skill> List { get; set; }
    }

    [XmlRoot("member")]
    public class Xml_Skill
    {
        [XmlAttribute("ID")]
        public String ID { get; set; }
        [XmlElement("Name")]
        public String Name { get; set; }
        [XmlElement("Text")]
        public String Text { get; set; }
        [XmlElement("Type")]
        public String Type { get; set; }
        [XmlElement("Power")]
        public int Power { get; set; }
        [XmlElement("Kinds")]
        public String Kinds { get; set; }
        [XmlElement("Conditions")]
        public String Conditions { get; set; }
    }
}
