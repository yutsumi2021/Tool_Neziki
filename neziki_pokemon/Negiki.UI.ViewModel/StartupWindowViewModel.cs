﻿using Neziki.Domain.Services.Factory;
using Neziki.Repository;
using Neziki.Service;
using Neziki.XmlData.Data;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Negiki.UI.ViewModel
{
    public class StartupWindowViewModel : BaseViewModel
    {
        private int _Progress;
        public int Progress
        {
            get { return this._Progress; }
            set
            {
               if (SetValueRaisePropertyChanged(ref _Progress, nameof(this.Progress), value))
                {

                }
            }
        }

        public StartupWindowViewModel()
        {
            Initialize();
        }

        public override void Initialize()
        {
            
        }

        /// <summary>
        /// 何かしらの処理を行う
        /// </summary>
        private async void RunMethodASync()
        {
            await Task.Run(async () =>
            {
                while (_Progress < 100)
                {
                    _Progress += 1;
                    await Task.Run(() => LoadData());
                }
            });
            
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
