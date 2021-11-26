using System;
using System.Windows.Input;

namespace Negiki.UI
{
    public class DelegateCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool> _canexecute;

        public DelegateCommand(Action execute)
            : this(new Action<object>((x) => execute()), null)
        {

        }

        public DelegateCommand(Action<object> execute)
            : this(execute, null)
        {

        }

        public DelegateCommand(Action execute, Func<bool> canexecute)
            : this(new Action<object>((x) => execute()), new Func<object, bool>((x) => canexecute()))
        {

        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canexecute)
        {
            _execute = execute;
            _canexecute = canexecute;
        }

        public event EventHandler CanExecuteChanged;
       
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        //_canexecuteはnullもしくはparameterを渡した結果のbool値を持つ
        public bool CanExecute(object parameter)
        {
            return _canexecute == null || _canexecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
