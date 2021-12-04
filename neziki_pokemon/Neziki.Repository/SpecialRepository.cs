using Neziki.Domain.Entities;
using Neziki.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq; 
using Neziki.XmlData.Data;

namespace Neziki.Repository
{
    public class SpecialRepository : IDataRepository<Data_Special>
    {
        private List<Data_Special> _master;

        public SpecialRepository()
        {
            //todo:xml読込→そのままDataクラスのほうがきれいだったかも...
            List<Data_Special> master = new List<Data_Special>();
            foreach (var Item in Xml_List.GetList_Xml_Special().List)
            {
               var nData = new Data_Special() { ID = Item.ID, Name = Item.Name, Text = Item.Text, Magnification = Item.Magnification, Conditions = Item.Conditions };
                master.Add(nData);
            }
            _master = master;
        }

        public Data_Special Find(string key)
        {
            return _master.Where(x => x.ID == key).FirstOrDefault();
        }

        public IReadOnlyList<Data_Special> Find(Func<Data_Special, bool> func)
        {
            return _master.Where(x => func(x)).ToList();
        }

        public IReadOnlyList<Data_Special> FindAll()
        {
            return _master.ToList();
        }

    }
}
