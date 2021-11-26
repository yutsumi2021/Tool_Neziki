using Neziki.Domain.Entities;

namespace Neziki.Domain.Services.Factory
{
    public static class Data_ItemServiceFactory
    {
        private static IDataServices<Data_Item> _dataServices;

        public static void Initialize(IDataServices<Data_Item> dataServices)
        {
            _dataServices = dataServices;
        }

        public static IDataServices<Data_Item> GetDataServices()
        {
            return _dataServices;
        }
    }
}
