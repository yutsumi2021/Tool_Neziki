using Neziki.Domain.Entities;
using Neziki.Domain.Repository;
using Neziki.Domain.Services;
using System;
using System.Collections.Generic;

namespace Neziki.Service
{
    public class Data_ItemService : IDataServices<Data_Item>
    {
        private IDataRepository<Data_Item> _IDataRepository;

        public Data_ItemService(IDataRepository<Data_Item> IDataRepository)
        {
            _IDataRepository = IDataRepository;
        }

        public Data_Item Find(string key)
        {
            return _IDataRepository.Find(key);
        }

        public IReadOnlyList<Data_Item> Find(Func<Data_Item, bool> func)
        {
            return _IDataRepository.Find(func);
        }

        public IReadOnlyList<Data_Item> FindAll()
        {
            return _IDataRepository.FindAll();
        }

    }
}
