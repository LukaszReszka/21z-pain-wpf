using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PAIN21Z_WPF2.MVVM
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> toExecute;
        private readonly Predicate<T> canExecute = null;
        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<T> toExec)
        {
            toExecute = toExec;
        }

        public RelayCommand(Action<T> toExec, Predicate<T> canExec)
        {
            toExecute = toExec;
            canExecute = canExec;
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute is null)
                return true;

            if (parameter is null)
                throw new ArgumentNullException(nameof(parameter));

            return canExecute.Invoke((T)parameter);
        }

        public void Execute(object parameter)
        {
            if (parameter is null)
                throw new ArgumentNullException(nameof(parameter));

            toExecute((T)parameter);
        }

        public void NotifyCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
