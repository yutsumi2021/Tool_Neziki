using Neziki.Domain.Entities;

namespace Neziki.Domain.Services.Factory
{
    public static class Data_syuzokutiServiceFactory
    {
        private static IDataServices<Data_syuzokuti> _dataServices;

        public static void Initialize(IDataServices<Data_syuzokuti> dataServices)
        {
            _dataServices = dataServices;
        }

        public static IDataServices<Data_syuzokuti> GetDataServices()
        {
            return _dataServices;
        }
    }
}
