using Neziki.Domain.Entities;
using Neziki.Domain.Services;
using Neziki.Domain.Services.Factory;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negiki.UI.ViewModel 
{
    public class MainWindowViewModel : BaseViewModel
    {
        IDataServices<Data_Pokemon> _Data_PokemonList;
        IDataServices<Data_Item> _Data_ItemList;
        IDataServices<Data_Skill> _Data_SkillList;
        IDataServices<Data_Special> _Data_SpecialList;
       

        public IReadOnlyList<string> CmbList { get; private set; }

        public MainWindowViewModel()
        {
            Initialize();
        }

        public override void Initialize()
        {
            GetDataList();
            SetDataList();

        }

        private void GetDataList()
        {
            _Data_PokemonList = Data_PokemonServiceFactory.GetDataServices();
            _Data_ItemList = Data_ItemServiceFactory.GetDataServices();
            _Data_SkillList = Data_SkillServiceFactory.GetDataServices();
            _Data_SpecialList = Data_SpecialServiceFactory.GetDataServices();
        }
       
        private void SetDataList()
        {
            var nameList = new List<string>();
            foreach(var vname in _Data_PokemonList.FindAll())
            {
                if(!nameList.Contains(vname.Name))
                {
                    nameList.Add(vname.Name);
                }
            }
            CmbList = nameList;
        }
    }
}
