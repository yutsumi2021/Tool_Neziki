using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Neziki.XmlData.Data
{
    [XmlRoot("Inf_syuzokuti")]
    public class List_syuzokuti
    {
        [XmlElement("member")]
        public List<Xml_syuzokuti> List { get; set; }
    }

    [XmlRoot("member")]
    public class Xml_syuzokuti
    {
        [XmlAttribute("K_ID")]
        public String K_ID { get; set; }
        [XmlElement("Name")]
        public String Name { get; set; }
        [XmlElement("HP")]
        public int HP { get; set; }
        [XmlElement("A")]
        public int A { get; set; }
        [XmlElement("B")]
        public int B { get; set; }
        [XmlElement("C")]
        public int C { get; set; }
        [XmlElement("D")]
        public int D { get; set; }
        [XmlElement("S")]
        public int S { get; set; }
    }
}
