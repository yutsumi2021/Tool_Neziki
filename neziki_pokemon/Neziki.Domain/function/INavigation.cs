using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neziki.Domain.function
{
    public interface INavigation
    {
        void OpenWindow(string key);
        void CloseWindow();
        void ShowDialog(string key);
        void ExitAppcation();
    }
}
