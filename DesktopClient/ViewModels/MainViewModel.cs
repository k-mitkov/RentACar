using DesktopClient.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DesktopClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Declarations
        private BaseViewModel selectedViewModel;
        #endregion

        #region Constructor
        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
        #endregion

        #region Properties
        public BaseViewModel SelectedViewModel
        {
            get
            {
                return selectedViewModel;
            }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { get; set; }
        #endregion
    }
}
