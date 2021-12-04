using Neziki.Domain.Entities;
using Neziki.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq; 
using Neziki.XmlData.Data;

namespace Neziki.Repository
{
    public class syuzokutiRepository : IDataRepository<Data_syuzokuti>
    {
        private List<Data_syuzokuti> _master;

        public syuzokutiRepository()
        {
            //todo:xml読込→そのままDataクラスのほうがきれいだったかも...
            List<Data_syuzokuti> master = new List<Data_syuzokuti>();
            foreach (var Item in Xml_List.GetList_Xml_Kotaiti().List)
            {
               var nData = new Data_syuzokuti() { K_ID = Item.K_ID, Name = Item.Name, HP = Item.HP, A = Item.A, B = Item.B, C = Item.C, D = Item.D, S = Item.S };
                master.Add(nData);
            }
            _master = master;
        }

        public Data_syuzokuti Find(string key)
        {
            return _master.Where(x => x.K_ID == key).FirstOrDefault();
        }

        public IReadOnlyList<Data_syuzokuti> Find(Func<Data_syuzokuti, bool> func)
        {
            return _master.Where(x => func(x)).ToList();
        }

        public IReadOnlyList<Data_syuzokuti> FindAll()
        {
            return _master.ToList();
        }

    }
}
