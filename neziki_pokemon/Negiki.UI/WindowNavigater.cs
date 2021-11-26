using Neziki.Domain.function;

namespace Negiki.UI
{
    public class WindowNavigater 
    {
        private static INavigation _INavigation;

        public static void Setup(INavigation INavigation)
        {
            _INavigation = INavigation;
        }

        public static void CloseWindow()
        {
            _INavigation.CloseWindow();
        }

        public static void ExitAppcation()
        {
            _INavigation.ExitAppcation();
        }

        public static void OpenWindow(string key)
        {
            _INavigation.OpenWindow(key);
        }

        public static void ShowDialog(string key)
        {
            _INavigation.OpenWindow(key);
        }
    }
}
