using DesktopClient.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DesktopClient.ViewModels
{
    public class AdminHomeViewModel : BaseViewModel
    {
        #region Declarations

        private ICommand buttonCommand;
        public event Action<object> AdminEvent;

        #endregion

        #region Proparties

        public ICommand ButtonCommand
        {
            get
            {
                if (buttonCommand == null)
                {
                    buttonCommand = new ButtonCommand(Press, CanExecuteShow);
                }
                return buttonCommand;
            }
        }

        #endregion

        #region Methods

        public bool CanExecuteShow(object _)
        {
            return true;
        }

        private void Press(object o)
        {
            OnEvent(o);
        }

        private void OnEvent(object o)
        {
            AdminEvent?.Invoke(o);
        }

        #endregion
    }
}
