using Negiki.UI;
using Negiki.UI.ViewModel;
using Neziki.Domain.Services.Factory;
using Neziki.Repository;
using Neziki.Service;
using Neziki.XmlData.Data;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace App_Start
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //多重起動チェック
            using (var _mutex = new Mutex(false, "{09A3A76C-7099-43AC-B480-CF54DAE8B876}"))
            {
                if (!_mutex.WaitOne(0, false))
                {
                    _mutex.Close();
                    this.Shutdown();
                    return;
                }
            }

            // 未処理例外処理
            DispatcherUnhandledException += OnDispatcherUnhandledException;
            TaskScheduler.UnobservedTaskException += OnUnobservedTaskException;
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;

            //画面起動
            WindowNavigater.Setup(new NavigationCommand());
            WindowNavigater.OpenWindow(nameof(StartupWindowViewModel));
        }

        private void OnDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            var exception = e.Exception;
            HandleException(exception);
        }

        private void OnUnobservedTaskException(object sender, UnobservedTaskExceptionEventArgs e)
        {
            var exception = e.Exception.InnerException as Exception;
            HandleException(exception);
        }

        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            var exception = e.ExceptionObject as Exception;
            HandleException(exception);
        }

        private void HandleException(Exception e)
        {
            MessageBox.Show($"エラーが発生しました\n{e?.ToString()}");
            Environment.Exit(1);
        }

        //protected override void OnExit(ExitEventArgs e)
        //{
        //    base.OnExit(e);
        //}
    }
}


