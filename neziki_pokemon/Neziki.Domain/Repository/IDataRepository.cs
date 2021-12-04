using System;
using System.Collections.Generic;

namespace Neziki.Domain.Repository
{
    /// <summary>
    /// Entitiesに関する機能のインターフェースを定義
    /// </summary>
    public interface IDataRepository<Etype>
    {
        //条件指定で検索します。
        Etype Find(string key);

        //条件指定でリストを検索します
        IReadOnlyList<Etype> Find(Func<Etype, bool> func);

        //全てのデータを取得します。
        IReadOnlyList<Etype> FindAll();

    }

}
