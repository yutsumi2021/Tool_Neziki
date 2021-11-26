using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Xml.Serialization;

namespace Neziki.XmlData.Data
{
    [XmlRoot("Inf_Poke")]
    public class List_Xml_Pokemon
    {
        [XmlElement("member")]
        public List<Xml_Pokemon> List { get; set; }
    }

    [XmlRoot("member")]
    public class Xml_Pokemon
    {
        [XmlAttribute("ID")]
        public String ID { get; set; }
        [XmlElement("K_ID")]
        public String K_ID { get; set; }
        [XmlElement("Name")]
        public String Name { get; set; }
        [XmlElement("Personality")]
        public String Personality { get; set; }
        [XmlElement("Special_1")]
        public String Special_1 { get; set; }
        [XmlElement("Special_2")]
        public String Special_2 { get; set; }
        [XmlElement("Item")]
        public String Item { get; set; }
        [XmlElement("Skill_1")]
        public String Skill_1 { get; set; }
        [XmlElement("Skill_2")]
        public String Skill_2 { get; set; }
        [XmlElement("Skill_3")]
        public String Skill_3 { get; set; }
        [XmlElement("Skill_4")]
        public String Skill_4 { get; set; }
        [XmlElement("Circle")]
        public int Circle { get; set; }
        [XmlElement("Doryokuti_1")]
        public String Doryokuti_1 { get; set; }
        [XmlElement("Doryokuti_2")]
        public String Doryokuti_2 { get; set; }
        [XmlElement("Doryokuti_3")]
        public String Doryokuti_3 { get; set; }
    }
}
