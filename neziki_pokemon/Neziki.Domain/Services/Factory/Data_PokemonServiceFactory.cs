using Neziki.Domain.Entities;

namespace Neziki.Domain.Services.Factory
{
    public static class Data_PokemonServiceFactory
    {
        private static IDataServices<Data_Pokemon> _dataServices;

        public static void Initialize(IDataServices<Data_Pokemon> dataServices)
        {
            _dataServices = dataServices;
        }

        public static IDataServices<Data_Pokemon> GetDataServices()
        {
            return _dataServices;
        }
    }
}
