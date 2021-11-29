using Neziki.Domain.Services.Factory;
using Neziki.Repository;
using Neziki.Service;
using Neziki.XmlData.Data;
using System;
using System.Threading.Tasks;

namespace Negiki.UI.ViewModel.Models
{
    public class StartupWindowModel
    {
        int persent = 0;

        public async void RunTask()
        {

        }

        public bool DoWork(IProgress<int> progress)
        {
            try
            {
                Task.Run(() =>
                {
                    while (persent < 100)
                    {
                        LoadData();
                        persent++;
                        // 状況通知
                        progress.Report(persent);
                    }
                });
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void LoadData()
        {
            //Xmlからデータ取得
            Xml_List.InitializeAll();
            //各データを生成
            Data_ItemServiceFactory.Initialize(new Data_ItemService(new ItemRepository()));
            Data_SkillServiceFactory.Initialize(new Data_SkillService(new SkillRepository()));
            Data_SpecialServiceFactory.Initialize(new Data_SpecialService(new SpecialRepository()));
            var syuzokutiRepository = new syuzokutiRepository();
            Data_syuzokutiServiceFactory.Initialize(new Data_syuzokutiService(syuzokutiRepository));
            Data_PokemonServiceFactory.Initialize(new Data_PokemonService(new PokemonRepository(syuzokutiRepository)));
        }
    }
}
