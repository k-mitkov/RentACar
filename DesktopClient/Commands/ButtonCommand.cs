using System;
using System.Windows.Input;

namespace DesktopClient.Commands
{
    public class ButtonCommand : ICommand
    {
        #region Declaration
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;
        #endregion

        #region Constructor
        public ButtonCommand(Action<object> action, Func<object, bool> func)
        {
            execute = action;
            canExecute = func;
        }
        #endregion

        #region Proparties
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
            {
                return canExecute(parameter);
            }
            else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
        #endregion
    }
}
