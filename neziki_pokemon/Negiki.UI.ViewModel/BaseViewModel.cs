using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Negiki.UI.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected bool SetValueRaisePropertyChanged<T>(ref T nowvalue,string membername,T setvalue)
        {
            if(nowvalue.Equals(setvalue))
            {
                return false;
            }

            nowvalue = setvalue;
            RaisePropertyChanged(membername);
            return true;
        }

        public abstract void Initialize();

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
