using Data.Enums;
using Data.Models;
using DesktopClient.ViewModels;
using DesktopClient.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace DesktopClient.Commands
{
    public class UpdateViewCommand : ICommand
    {
        #region Declarations
        MainViewModel viewModel;
        public event EventHandler CanExecuteChanged;
        #endregion

        #region Constructor
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;

            SearchViewModel searchViewModel = new SearchViewModel();
            this.viewModel.SelectedViewModel = searchViewModel;
            searchViewModel.SearchEvent += SearchHandler;
        }
        #endregion

        #region Methods
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            SearchViewModel searchViewModel = new SearchViewModel();
            viewModel.SelectedViewModel = searchViewModel;
            searchViewModel.SearchEvent += SearchHandler;
        }

        public void SearchHandler(Period period, Locations location)
        {
            SelectViewModel selectViewModel = new SelectViewModel();
            viewModel.SelectedViewModel = selectViewModel;
        }

        public void SelectHandler()
        {
           
        }
        #endregion
    }
}
