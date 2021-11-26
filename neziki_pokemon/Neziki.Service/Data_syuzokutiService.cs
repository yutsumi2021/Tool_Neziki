using Neziki.Domain.Entities;
using Neziki.Domain.Repository;
using Neziki.Domain.Services;
using System;
using System.Collections.Generic;

namespace Neziki.Service
{
    public class Data_syuzokutiService : IDataServices<Data_syuzokuti>
    {
        private IDataRepository<Data_syuzokuti> _IDataRepository;

        public Data_syuzokutiService(IDataRepository<Data_syuzokuti> IDataRepository)
        {
            _IDataRepository = IDataRepository;
        }

        public Data_syuzokuti Find(string key)
        {
            return _IDataRepository.Find(key);
        }

        public IReadOnlyList<Data_syuzokuti> Find(Func<Data_syuzokuti, bool> func)
        {
            return _IDataRepository.Find(func);
        }

        public IReadOnlyList<Data_syuzokuti> FindAll()
        {
            return _IDataRepository.FindAll();
        }
    }
}
