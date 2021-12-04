using Neziki.Domain.Entities;
using Neziki.Domain.Repository;
using Neziki.Domain.function;
using System;
using System.Collections.Generic;
using System.Linq;
using Neziki.XmlData.Data;

namespace Neziki.Repository
{
    public class PokemonRepository : IDataRepository<Data_Pokemon>, ICalculationStatus
    {
        private List<Data_Pokemon> _master;

        public PokemonRepository(syuzokutiRepository syuzokutiRepository)
        {
            //todo:xml読込→そのままDataクラスのほうがきれいだったかも...
            List<Data_Pokemon> master = new List<Data_Pokemon>();
            foreach (var Item in Xml_List.GetList_Xml_Pokemon().List)
            {
                var nData = new Data_Pokemon()
                {
                    ID = Item.ID,
                    K_ID = Item.K_ID,
                    Name = Item.Name,
                    Personality = Item.Personality,
                    Special_1 = Item.Special_1,
                    Special_2 = Item.Special_2,
                    Item = Item.Item,
                    Skill_1 = Item.Skill_1,
                    Skill_2 = Item.Skill_2,
                    Skill_3 = Item.Skill_3,
                    Skill_4 = Item.Skill_4,
                    Circle = Item.Circle,
                    Doryokuti_1 = Item.Doryokuti_1,
                    Doryokuti_2 = Item.Doryokuti_2,
                    Doryokuti_3 = Item.Doryokuti_3,
                    HP = Calculation_status_HP(syuzokutiRepository.Find(Item.K_ID).HP, Calculation_kotaiti(Item.Circle), Calculation_doryokuti("HP", Item.Doryokuti_1, Item.Doryokuti_2, Item.Doryokuti_3)),
                    A = Calculation_status_A(syuzokutiRepository.Find(Item.K_ID).A, Calculation_kotaiti(Item.Circle), Calculation_doryokuti("A", Item.Doryokuti_1, Item.Doryokuti_2, Item.Doryokuti_3), Item.Personality),
                    B = Calculation_status_A(syuzokutiRepository.Find(Item.K_ID).B, Calculation_kotaiti(Item.Circle), Calculation_doryokuti("B", Item.Doryokuti_1, Item.Doryokuti_2, Item.Doryokuti_3), Item.Personality),
                    C = Calculation_status_A(syuzokutiRepository.Find(Item.K_ID).C, Calculation_kotaiti(Item.Circle), Calculation_doryokuti("C", Item.Doryokuti_1, Item.Doryokuti_2, Item.Doryokuti_3), Item.Personality),
                    D = Calculation_status_A(syuzokutiRepository.Find(Item.K_ID).D, Calculation_kotaiti(Item.Circle), Calculation_doryokuti("D", Item.Doryokuti_1, Item.Doryokuti_2, Item.Doryokuti_3), Item.Personality),
                    S = Calculation_status_A(syuzokutiRepository.Find(Item.K_ID).S, Calculation_kotaiti(Item.Circle), Calculation_doryokuti("S", Item.Doryokuti_1, Item.Doryokuti_2, Item.Doryokuti_3), Item.Personality)
                };
                master.Add(nData);
            }
            _master = master;
        }

        //((種族値×2+個体値+努力値÷4)×レベル÷100+5)×性格補正
        public int Calculation_status_A(int svalue, int kvalue, int dvalue, string Personality)
        {
            int status = (svalue * 2 + kvalue + dvalue / 4) + 5;
            switch (Personality)
            {
                case "PE1":
                case "PE8":
                    return (int)Math.Truncate(status * 1.1);
                case "PE10":
                case "PE3":
                case "PE9":
                case "PE6":
                    return (int)Math.Truncate(status * 0.9);
                default:
                    return status;
            }
        }

        public int Calculation_status_B(int svalue, int kvalue, int dvalue, string Personality)
        {
            int status = (svalue * 2 + kvalue + dvalue / 4) + 5;
            switch (Personality)
            {
                case "PE4":
                case "PE10":
                case "PE15":
                    return (int)Math.Truncate(status * 1.1);
                default:
                    return status;
            }
        }

        public int Calculation_status_C(int svalue, int kvalue, int dvalue, string Personality)
        {
            int status = (svalue * 2 + kvalue + dvalue / 4) + 5;
            switch (Personality)
            {
                case "PE3":
                case "PE5":
                case "PE13":
                    return (int)Math.Truncate(status * 1.1);
                case "PE1":
                case "PE4":
                case "PE2":
                    return (int)Math.Truncate(status * 0.9);
                default:
                    return status;
            }
        }

        public int Calculation_status_D(int svalue, int kvalue, int dvalue, string Personality)
        {
            int status = (svalue * 2 + kvalue + dvalue / 4) + 5;
            switch (Personality)
            {
                case "PE9":
                case "PE14":
                    return (int)Math.Truncate(status * 1.1);
                case "PE5":
                    return (int)Math.Truncate(status * 0.9);
                default:
                    return status;
            }
        }

        public int Calculation_status_S(int svalue, int kvalue, int dvalue, string Personality)
        {
            int status = (svalue * 2 + kvalue + dvalue / 4) + 5;
            switch (Personality)
            {
                case "PE6":
                case "PE2":
                    return (int)Math.Truncate(status * 1.1);
                case "PE8":
                case "PE13":
                case "PE14":
                case "PE15":
                    return (int)Math.Truncate(status * 0.9);
                default:
                    return status;
            }
        }
        public int Calculation_status_HP(int svalue, int kvalue, int dvalue)
        {
            //(種族値×2+個体値+努力値÷4)×レベル÷100+10+レベル
            return (svalue * 2 + kvalue + dvalue / 4) + 110;
        }
        public int Calculation_kotaiti(int Circle)
        {
            //(n-1)*4 n=周回数
            return (Circle - 1) * 4;
        }

        public int Calculation_doryokuti(string status_type, string value1, string value2, string value3)
        {
            if (status_type == value1 || status_type == value2 || status_type == value3)
            {
                if (string.IsNullOrEmpty(value3))
                {
                    return 252;
                }
                else
                {
                    return 168;
                }
            }
            else
            {
                return 0;
            }
        }

        public Data_Pokemon Find(string key)
        {
            return _master.Where(x => x.K_ID == key).FirstOrDefault();
        }

        public IReadOnlyList<Data_Pokemon> Find(Func<Data_Pokemon, bool> func)
        {
            return _master.Where(x => func(x)).ToList();
        }

        public IReadOnlyList<Data_Pokemon> FindAll()
        {
            return _master.ToList();
        }
    }
}
