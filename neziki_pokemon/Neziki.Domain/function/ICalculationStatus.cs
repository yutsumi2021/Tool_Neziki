using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neziki.Domain.function
{
    /// <summary>
    /// ステータス計算に関する機能のインターフェースを定義
    /// </summary>
    public interface ICalculationStatus
    {
        //HPステータス計算
        int Calculation_status_HP(int svalue,int kvalue,int dvalue);

        //その他ステータス計算
        int Calculation_status_A(int svalue, int kvalue, int dvalue,string Personality);
        int Calculation_status_B(int svalue, int kvalue, int dvalue, string Personality);
        int Calculation_status_C(int svalue, int kvalue, int dvalue, string Personality);
        int Calculation_status_D(int svalue, int kvalue, int dvalue, string Personality);
        int Calculation_status_S(int svalue, int kvalue, int dvalue, string Personality);

        //個体値計算
        int Calculation_kotaiti(int Circle);

        //努力値計算
        int Calculation_doryokuti(string status_type, string value1, string value2, string value3);
    }
}
