using Neziki.Domain.Entities;
using Neziki.Domain.Repository;
using Neziki.Domain.Services;
using System;
using System.Collections.Generic;

namespace Neziki.Service
{
    public class Data_SpecialService : IDataServices<Data_Special>
    {
        private IDataRepository<Data_Special> _IDataRepository;

        public Data_SpecialService(IDataRepository<Data_Special> IDataRepository)
        {
            _IDataRepository = IDataRepository;
        }

        public Data_Special Find(string key)
        {
            return _IDataRepository.Find(key);
        }

        public IReadOnlyList<Data_Special> Find(Func<Data_Special, bool> func)
        {
            return _IDataRepository.Find(func);
        }

        public IReadOnlyList<Data_Special> FindAll()
        {
            return _IDataRepository.FindAll();
        }
    }
}
