using Neziki.Domain.Entities;
using Neziki.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq; 
using Neziki.XmlData.Data;

namespace Neziki.Repository
{
    public class ItemRepository : IDataRepository<Data_Item>
    {
        private List<Data_Item> _master;

        public ItemRepository()
        {
            //todo:xml読込→そのままDataクラスのほうがきれいだったかも...
            List<Data_Item> master = new List<Data_Item>();
            foreach (var Item in Xml_List.GetList_Xml_Item().List)
            {
               var nData = new Data_Item() { ID = Item.ID, Name = Item.Name, Text = Item.Text, Magnification = Item.Magnification, Conditions = Item.Conditions };
                master.Add(nData);
            }
            _master = master;
        }

        public Data_Item Find(string key)
        {
            return _master.Where(x => x.ID == key).FirstOrDefault();
        }

        public IReadOnlyList<Data_Item> Find(Func<Data_Item, bool> func)
        {
            return _master.Where(x => func(x)).ToList();
        }

        public IReadOnlyList<Data_Item> FindAll()
        {
            return _master.ToList();
        }

    }
}
