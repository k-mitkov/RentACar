using Data.Enums;
using Data.Models;
using DesktopClient.BussinesModels;
using DesktopClient.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void SearchHandler(IEnumerable<CarPeriodRapper> rappers)
        {

            if (rappers != null && rappers.ToList().Count>0)
            {
                SelectViewModel selectViewModel = new SelectViewModel(rappers);
                viewModel.SelectedViewModel = selectViewModel;
            }
            else
            {
                SearchViewModel searchViewModel = new SearchViewModel();
                viewModel.SelectedViewModel = searchViewModel;
                searchViewModel.SearchEvent += SearchHandler;
            }
            
        }

        public void SelectHandler()
        {
           
        }
        #endregion
    }
}
