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
        private MainViewModel viewModel;
        public event EventHandler CanExecuteChanged;
        private SelectViewModel selectViewModel;
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
                selectViewModel = new SelectViewModel(rappers);
                selectViewModel.selectEvent += SelectHandler;
                viewModel.SelectedViewModel = selectViewModel;
            }
            else
            {
                SearchViewModel searchViewModel = new SearchViewModel();
                viewModel.SelectedViewModel = searchViewModel;
                searchViewModel.SearchEvent += SearchHandler;
            }
            
        }

        public void SelectHandler(CarPeriodRapper car)
        {
            SelectedCarViewModel selectedCarViewModel = new SelectedCarViewModel(car);
            selectedCarViewModel.BackEvent += BackToResultsHandler;
            selectedCarViewModel.SelectEvent += SelectedCarHandler;
            viewModel.SelectedViewModel = selectedCarViewModel;
        }

        public void BackToResultsHandler()
        {
            selectViewModel.SelectedCar = null;
            viewModel.SelectedViewModel = selectViewModel;
        }

        public void SelectedCarHandler(CarPeriodRapper car)
        {
            ClientDataViewModel clientDataViewModel = new ClientDataViewModel();
            viewModel.SelectedViewModel = clientDataViewModel;
        }
        #endregion
    }
}
