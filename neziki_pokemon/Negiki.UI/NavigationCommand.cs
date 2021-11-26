using Negiki.UI.function;
using Negiki.UI.ViewModel;
using Negiki.UI.Views;
using System;
using System.Windows;

namespace Neziki.Service
{
    public class NavigationCommand : INavigation
    {
        private static Window _StartupWindow;

        public void OpenWindow(string key)
        {
            switch(key)
            {
                //起動画面
                case nameof(StartupWindowViewModel):
                    OpenStartupWindow();
                    break;
                //メイン画面

                //計算画面

                default:
                    throw new ArgumentException($"想定外の{(key)}が指定されました。");
            }
        }

        public void CloseWindow()
        {
            throw new NotImplementedException();
        }

        public void ShowDialog(string key)
        {
            switch (key)
            {
                //持ち物

                //技

                //特性
            }
        }

        public void ExitAppcation()
        {
            throw new NotImplementedException();
        }

        private void OpenStartupWindow()
        {
            _StartupWindow = new StartupWindow()
            {
                DataContext = new StartupWindowViewModel()
            };
            _StartupWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _StartupWindow.Show();
            _StartupWindow.Activate();
        }

        /// <summary>
        /// 画面のリソースを破棄してbool値を返します。
        /// </summary>
        /// <param name="window"></param>
        /// <returns></returns>
        private bool IsDisposed(Window window)
        {
            if (window == null)
                return true;

            var source = PresentationSource.FromVisual(window);

            return source == null || source.IsDisposed;
        }
    }
}
