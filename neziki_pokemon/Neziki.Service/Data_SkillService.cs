using Neziki.Domain.Entities;
using Neziki.Domain.Repository;
using Neziki.Domain.Services;
using System;
using System.Collections.Generic;

namespace Neziki.Service
{
    public class Data_SkillService : IDataServices<Data_Skill>
    {
        private IDataRepository<Data_Skill> _IDataRepository;

        public Data_SkillService(IDataRepository<Data_Skill> IDataRepository)
        {
            _IDataRepository = IDataRepository;
        }

        public Data_Skill Find(string key)
        {
            return _IDataRepository.Find(key);
        }

        public IReadOnlyList<Data_Skill> Find(Func<Data_Skill, bool> func)
        {
            return _IDataRepository.Find(func);
        }

        public IReadOnlyList<Data_Skill> FindAll()
        {
            return _IDataRepository.FindAll();
        }
    }
}
