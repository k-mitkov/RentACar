using Data.Enums;
using Data.Models;
using DesktopClient.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesktopClient.ViewModels
{
    class SearchViewModel : BaseViewModel
    {
        #region Declarations
        public event Action<Period,Locations> SearchEvent;
        private ButtonCommand buttonCommand;
        #endregion

        #region Proparties
        public ButtonCommand SearchCommand
        {
            get
            {
                if (buttonCommand == null)
                {
                    buttonCommand = new ButtonCommand(Search, CanExecuteShow);
                }
                return buttonCommand;
            }
        }

        #endregion

        #region Methods
        private void OnSearch()
        {
            SearchEvent.Invoke(new Period(),Locations.Sofia);
        }

        public bool CanExecuteShow(object o)
        {
            return true;
        }

        public void Search(object o)
        {
            OnSearch();
        }
        #endregion
    }
}
