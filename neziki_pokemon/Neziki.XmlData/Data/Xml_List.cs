namespace Neziki.XmlData.Data
{
    public static class Xml_List
    {
        private static List_Xml_Pokemon _List_Xml_Pokemon;
        private static List_Xml_Item _List_Xml_Item;
        private static List_Xml_Skill _List_Xml_Skill;
        private static List_Xml_Special _List_Xml_Special;
        private static List_syuzokuti _List_Xml_Kotaiti;

        public static void InitializeAll()
        {
            Initialize(MyXmlSerializer.DeserializeFromString<List_Xml_Pokemon>(System.IO.Path.GetFullPath("..\\..\\..\\..\\Xml\\Xml_Pokemon.xml")));
            Initialize(MyXmlSerializer.DeserializeFromString<List_Xml_Item>(System.IO.Path.GetFullPath("..\\..\\..\\..\\Xml\\Xml_Item.xml")));
            Initialize(MyXmlSerializer.DeserializeFromString<List_Xml_Skill>(System.IO.Path.GetFullPath("..\\..\\..\\..\\Xml\\Xml_Skill.xml")));
            Initialize(MyXmlSerializer.DeserializeFromString<List_Xml_Special>(System.IO.Path.GetFullPath("..\\..\\..\\..\\Xml\\Xml_Special.xml")));
            Initialize(MyXmlSerializer.DeserializeFromString<List_syuzokuti>(System.IO.Path.GetFullPath("..\\..\\..\\..\\Xml\\Xml_syuzokuti.xml")));
        }

        public static void Initialize(List_Xml_Pokemon List)
        {
            _List_Xml_Pokemon = List;
        }
        public static void Initialize(List_Xml_Item List)
        {
            _List_Xml_Item = List;
        }
        public static void Initialize(List_Xml_Skill List)
        {
            _List_Xml_Skill = List;
        }
        public static void Initialize(List_Xml_Special List)
        {
            _List_Xml_Special = List;
        }
        public static void Initialize(List_syuzokuti List)
        {
            _List_Xml_Kotaiti = List;
        }

        public static List_Xml_Pokemon GetList_Xml_Pokemon()
        {
            return _List_Xml_Pokemon;
        }

        public static List_Xml_Item GetList_Xml_Item()
        {
            return _List_Xml_Item;
        }
        public static List_Xml_Skill GetList_Xml_Skill()
        {
            return _List_Xml_Skill;
        }
        public static List_Xml_Special GetList_Xml_Special()
        {
            return _List_Xml_Special;
        }
        public static List_syuzokuti GetList_Xml_Kotaiti()
        {
            return _List_Xml_Kotaiti;
        }
    }
}
