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
        private SelectViewModel selectViewModel;
        private readonly string ADD_CAR;
        private readonly string VIEW_CARS;
        private readonly string ADD_ADMIN;
        private readonly string VIEW_RESERVATIONS;
        private readonly string VIEW_CLIENTS;
        private readonly string LOGOUT;
        private Admin admin;
        #endregion

        #region Constructor
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;

            Execute(null);
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

        public void ShowAdminPanel()
        {
            if(admin == null)
            {
                LoginViewModel loginViewModel = new LoginViewModel();
                loginViewModel.LoginEvent += LoginHandler;
                viewModel.SelectedViewModel = loginViewModel;
            }
            else
            {
                AdminHomeViewModel adminHomeViewModel = new AdminHomeViewModel();
                adminHomeViewModel.AdminEvent += AdminEventHandler;
                viewModel.SelectedViewModel = adminHomeViewModel;
            }
        }

        public void LoginHandler(Admin admin)
        {
            this.admin = admin;
            ShowAdminPanel();
        }

        public void AdminEventHandler(object o)
        {
            var s = o.ToString();
            switch (s)
            {
                case nameof(ADD_CAR):
                    AddNewCarViewModel addNewCarViewModel = new AddNewCarViewModel();
                    viewModel.SelectedViewModel = addNewCarViewModel;
                    break;
                case nameof(VIEW_CARS):
                    ViewCarsViewModel viewCarsViewModel = new ViewCarsViewModel();
                    viewModel.SelectedViewModel = viewCarsViewModel;
                    break;
                case nameof(ADD_ADMIN):
                    
                    break;
                case nameof(VIEW_RESERVATIONS):
                    
                    break;
                case nameof(VIEW_CLIENTS):

                    break;
                case nameof(LOGOUT):
                    admin = null;
                    Execute(null);
                    break;
            }
        }

        public void AddCarHandler()
        {
            ShowAdminPanel();
        }
        #endregion
    }
}
