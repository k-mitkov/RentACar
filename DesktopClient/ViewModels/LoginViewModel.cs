using Data.Models;
using DesktopClient.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace DesktopClient.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Declaration

        private ButtonCommand loginCommand;
        private string name;
        private string password;
        private bool isInputValid = true;
        public event Action<Admin> LoginEvent;

        #endregion

        #region Proparties

        public ButtonCommand LoginCommand
        {
            get
            {
                if (loginCommand == null)
                {
                    loginCommand = new ButtonCommand(Login, CanExecuteShow);
                }
                return loginCommand;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public bool IsInputValid
        {
            get
            {
                return isInputValid;
            }
            set
            {
                isInputValid = value;
                OnPropertyChanged(nameof(IsInputValid));
            }
        }

        #endregion

        #region Methods
        private void OnLogin(Admin admin)
        {
            LoginEvent.Invoke(admin);
        }

        public bool CanExecuteShow(object o)
        {
            return true;
        }

        public void Login(object o)
        {
            PasswordBox passwordBox = (PasswordBox)o;
            Password = passwordBox.Password;
            Admin admin = administratorService.Login(Name, Password);
            if (admin != null)
            {
                OnLogin(admin);
            }
            else
            {
                IsInputValid = false;
            }
        }

        #endregion
    }
}
