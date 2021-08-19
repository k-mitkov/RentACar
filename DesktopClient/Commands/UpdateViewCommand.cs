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
        MainViewModel viewModel;
        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;

            SearchViewModel searchViewModel = new SearchViewModel();
            this.viewModel.SelectedViewModel = searchViewModel;
            //searchViewModel.SelectEvent += SearchHandler();
        }

        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            /* viewModel.SelectedViewModel = home;*/

            //if (parameter.ToString() == "Home")
            //{
            //    viewModel.SelectedViewModel = new HomeViewModel();
            //}
            //else if (parameter.ToString() == "Menu Books")
            //{
            //    viewModel.SelectedViewModel = new BooksMenuViewModel();
            //}
            //else if (parameter.ToString() == "Menu Authors")
            //{
            //    viewModel.SelectedViewModel = new AuthorsMenuViewModel();
            //}
        }

        /* public void SearchHandler()
         {
             BooksMenuViewModel books = new BooksMenuViewModel();
             viewModel.SelectedViewModel = books;
             books.Event += SelectHandler();
         }
         public void SelectHandler()
         {
             viewModel.SelectedViewModel = new AuthorsMenuViewModel();
         }*/
    }
}
