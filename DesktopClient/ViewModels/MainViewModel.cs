using Data.Enums;
using Data.Models;
using DesktopClient.Commands;
using DesktopClient.Util;
using System.Collections.Generic;
using System.ComponentModel;
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
        private ButtonCommand adminCommand;
        #endregion

        #region Constructor
        public MainViewModel()
        {
            UpdateViewCommand = new UpdateViewCommand(this);
        }
        #endregion

        #region Properties

        public ButtonCommand AdminCommand
        {
            get
            {
                if (adminCommand == null)
                {
                    adminCommand = new ButtonCommand(Add, CanExecuteShow);
                }
                return adminCommand;
            }
        }

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

        public UpdateViewCommand UpdateViewCommand { get; set; }

        public IEnumerable<Language> Languages
        {
            get
            {
                if (languages == null)
                {
                    languages = languageService.GetLanguages();
                    //languages = new List<Language>() { new Language() { Lenguage = LenguageEnum.English},
                    //                                    new Language() { Lenguage = LenguageEnum.Български } };
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
                var field = currentLanguage.Lenguage.GetType().GetField(currentLanguage.Lenguage.ToString());
                var attributes = field.GetCustomAttributes(false);

                TranslationSource.Instance.CurrentCulture = new System.Globalization.CultureInfo(attributes.Select(a=> (DescriptionAttribute) a).ElementAt(0).Description);
            }
        }

        #endregion

        #region Methods

        public bool CanExecuteShow(object _)
        {
            return true;
        }

        private void Add(object _)
        {
            UpdateViewCommand.ShowAdminPanel();
        }

        #endregion
    }
}
