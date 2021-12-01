using Neziki.Domain.Services.Factory;
using Neziki.Repository;
using Neziki.Service;
using Neziki.XmlData.Data;
using System;
using System.Threading.Tasks;

namespace Negiki.UI.ViewModel
{
    public class StartupWindowViewModel : BaseViewModel
    {
        private int persent;
        private int _Progress;
        public int Progress
        {
            get { return this._Progress; }
            set
            {
                if (!SetValueRaisePropertyChanged(ref _Progress, nameof(this.Progress), value))
                {
                    return;
                }
            }
        }

        private void ShowProgress(int persent)
        {
            Progress = persent;
        }

        public async void TaskRun()
        {
            var v = new Progress<int>(ShowProgress);
            bool result = await Task.Run(() => DoWork(v));
            if (result)
            {
                //メイン画面へ
                WindowNavigater.OpenWindow(nameof(MainWindowViewModel));
            }
            else
            {
                //例外処理
            }
        }
        private bool DoWork(IProgress<int> progress)
        {
            try
            {
                Task.Run(() =>
                {
                    while (persent < 100)
                    {
                        //LoadData();
                        persent++;
                        // 状況通知
                        progress.Report(persent);
                    }
                });
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        
        public override void Initialize()
        {

        }

    }
}
