using Data.Service;
using Data.Service.Impl;
using System.ComponentModel;

namespace DesktopClient.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Declarations
        protected ICarService carService;
        protected ILanguageService languageService;
        protected IAdministratorService administratorService;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public BaseViewModel()
        {
            carService = new CarService();
            languageService = new LanguageService();
            administratorService = new AdministratorService();
        }
        #endregion

        #region Methods
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
