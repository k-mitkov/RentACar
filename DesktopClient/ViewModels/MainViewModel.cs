using Data.Enums;
using Data.Models;
using DesktopClient.Commands;
using DesktopClient.Util;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace DesktopClient.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Declarations
        private BaseViewModel selectedViewModel;
        private Language currentLanguage;
        private IEnumerable<Language> languages;
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

        public IEnumerable<Language> Languages
        {
            get
            {
                if (languages == null)
                {
                    languages = languageService.GetLanguages();
                }
                SelectedLanguage = languages.ToList().FirstOrDefault();
                return languages;
            }
        }

        public Language SelectedLanguage
        {
            get 
            {
                return currentLanguage;
            }
            set
            {
                currentLanguage = value;
                if (currentLanguage.Lenguage.Equals(LenguageEnum.English))
                {
                    TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en");
                }
                else if(currentLanguage.Lenguage.Equals(LenguageEnum.Български))
                {
                    TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("bg-BG");
                }
                else
                {
                    TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo("en");
                }
            }
        }
        #endregion
    }
}
