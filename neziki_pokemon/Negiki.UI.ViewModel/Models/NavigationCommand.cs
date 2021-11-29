using Negiki.UI.function;
using Negiki.UI.ViewModel;
using Negiki.UI.Views;
using System;
using System.Windows;

namespace Negiki.UI.ViewModel.Models
{
    public class NavigationCommand : INavigation
    {
        private static Window _CurrentWindow;
        private static Window _StartupWindow;
        private static Window _MainWindow;

        public void OpenWindow(string key)
        {
            switch(key)
            {
                //起動画面
                case nameof(StartupWindowViewModel):
                    OpenStartupWindow();
                    break;
                //メイン画面
                case nameof(MainWindowViewModel):
                    MainWindowViewModel();
                    break;
                //計算画面

                default:
                    throw new ArgumentException($"想定外の{(key)}が指定されました。");
            }
        }

        private void MainWindowViewModel()
        {
            _MainWindow = new MainWindow()
            {
                DataContext = new MainWindowViewModel()
            };
            _CurrentWindow = _MainWindow;
            _MainWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _MainWindow.Show();
            _MainWindow.Activate();
            if (IsDisposed(_StartupWindow))
            {
                _StartupWindow.Close();
            }
        }

        public void CloseWindow()
        {
            
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
            var ViewModel = new StartupWindowViewModel();
            _StartupWindow = new StartupWindow()
            {
                DataContext = ViewModel
            };
            _StartupWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _StartupWindow.ContentRendered += (sender, e) => ViewModel.TaskRun();
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
