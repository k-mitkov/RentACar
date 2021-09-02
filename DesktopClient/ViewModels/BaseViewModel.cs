using Data.Service;
using Data.Service.Impl;
using System.ComponentModel;

namespace DesktopClient.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Declarations
        protected ICarService carService = new CarService();
        protected ILanguageService languageService = new LanguageService();
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
