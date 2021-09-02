using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;

namespace DesktopClient.Util
{
    public class TranslationSource : INotifyPropertyChanged
    {
        #region Declarations
        public event Action LanguageEvent;
        private static readonly TranslationSource instance = new TranslationSource();
        private readonly ResourceManager resManager = Resources.Localizations.Resources.ResourceManager;
        public event PropertyChangedEventHandler PropertyChanged;
        private CultureInfo currentCulture = null;
        #endregion

        #region Proparties
        public static TranslationSource Instance
        {
            get { return instance; }
        }

        public string this[string key]
        {
            get { return resManager.GetString(key, currentCulture); }
        }

        public CultureInfo CurrentCulture
        {
            get { return currentCulture; }
            set
            {
                if (currentCulture != value)
                {
                    currentCulture = value;
                    var @event = PropertyChanged;
                    if (@event != null)
                    {
                        @event.Invoke(this, new PropertyChangedEventArgs(string.Empty));
                        LanguageEvent.Invoke();
                    }
                }
            }
        }
        #endregion
    }
}
