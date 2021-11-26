using Neziki.Domain.Entities;

namespace Neziki.Domain.Services.Factory
{
    public static class Data_SkillServiceFactory
    {
        private static IDataServices<Data_Skill> _dataServices;

        public static void Initialize(IDataServices<Data_Skill> dataServices)
        {
            _dataServices = dataServices;
        }

        public static IDataServices<Data_Skill> GetDataServices()
        {
            return _dataServices;
        }
    }
}
