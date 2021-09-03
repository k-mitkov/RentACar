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
                CarsNotFoundViewModel carNotFoundViewModel = new CarsNotFoundViewModel();
                viewModel.SelectedViewModel = carNotFoundViewModel;
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
            ClientDataViewModel clientDataViewModel = new ClientDataViewModel(car);
            clientDataViewModel.BookEvent += BookHandler;
            clientDataViewModel.BackEvent += BackToResultsHandler;
            viewModel.SelectedViewModel = clientDataViewModel;
        }

        public void BookHandler()
        {
            SuccesfulReservedViewModel succesfulReservedViewModel = new SuccesfulReservedViewModel();
            viewModel.SelectedViewModel = succesfulReservedViewModel;
        }

        public void ShowAddNewCarView()
        {
            AddNewCarViewModel addNewCarViewModel = new AddNewCarViewModel();
            viewModel.SelectedViewModel = addNewCarViewModel;
        }

        #endregion
    }
}
