using Neziki.Domain.Entities;
using Neziki.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq; 
using Neziki.XmlData.Data;

namespace Neziki.Repository
{
    public class SkillRepository : IDataRepository<Data_Skill>
    {
        private List<Data_Skill> _master;

        public SkillRepository()
        {
            //todo:xml読込→そのままDataクラスのほうがきれいだったかも...
            List<Data_Skill> master = new List<Data_Skill>();
            foreach (var Item in Xml_List.GetList_Xml_Skill().List)
            {
               var nData = new Data_Skill() { ID = Item.ID, Name = Item.Name, Text = Item.Text, Type = Item.Type, Power = Item.Power, Kinds = Item.Kinds, Conditions = Item.Conditions };
                master.Add(nData);
            }
            _master = master;
        }

        public Data_Skill Find(string key)
        {
            return _master.Where(x => x.ID == key).FirstOrDefault();
        }

        public IReadOnlyList<Data_Skill> Find(Func<Data_Skill, bool> func)
        {
            return _master.Where(x => func(x)).ToList();
        }

        public IReadOnlyList<Data_Skill> FindAll()
        {
            return _master.ToList();
        }
    }
}
