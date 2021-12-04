using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neziki.Domain.Services
{
    public interface IDataServices<Etype>
    {
        /// <summary>
        /// 条件指定で検索します。
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Etype Find(string key);

        /// <summary>
        /// 条件指定でリストを検索します
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        IReadOnlyList<Etype> Find(Func<Etype, bool> func);

        /// <summary>
        /// 全てのデータを取得します。
        /// </summary>
        /// <returns></returns>
        IReadOnlyList<Etype> FindAll();

    }
}
