using Neziki.Domain.Entities;
using Neziki.Domain.Repository;
using Neziki.Domain.Services;
using System;
using System.Collections.Generic;

namespace Neziki.Service
{
    public class Data_PokemonService : IDataServices<Data_Pokemon>
    {
        private IDataRepository<Data_Pokemon> _IDataRepository;

        public Data_PokemonService(IDataRepository<Data_Pokemon> IDataRepository)
        {
            _IDataRepository = IDataRepository;
        }

        public Data_Pokemon Find(string key)
        {
            return _IDataRepository.Find(key);
        }

        public IReadOnlyList<Data_Pokemon> Find(Func<Data_Pokemon, bool> func)
        {
            return _IDataRepository.Find(func);
        }

        public IReadOnlyList<Data_Pokemon> FindAll()
        {
            return _IDataRepository.FindAll();
        }

    }
}
