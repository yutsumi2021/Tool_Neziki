using Neziki.Domain.Entities;

namespace Neziki.Domain.Services.Factory
{
    public static class Data_SpecialServiceFactory
    {
        private static IDataServices<Data_Special> _dataServices;

        public static void Initialize(IDataServices<Data_Special> dataServices)
        {
            _dataServices = dataServices;
        }

        public static IDataServices<Data_Special> GetDataServices()
        {
            return _dataServices;
        }
    }
}
