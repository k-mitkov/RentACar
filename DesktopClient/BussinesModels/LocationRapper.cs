using Data.Enums;
using DesktopClient.Util;
using System.ComponentModel;
using System.Linq;

namespace DesktopClient.BussinesModels
{
    public class LocationRapper : INotifyPropertyChanged
    {
        #region Declarations
        private const string path = @"\Resources\Images\location-icon.png";
        private string locationStr;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Constructor
        public LocationRapper(Locations location)
        {
            Location = location;
            var field = Location.GetType().GetField(Location.ToString());
            var attributes = field.GetCustomAttributes(false);
            locationStr = TranslationSource.Instance[attributes.Select(a => (DescriptionAttribute)a).ElementAt(0).Description];
            TranslationSource.Instance.LanguageEvent += LanguageChangeHandler;
        }
        #endregion

        #region Proparties
        public Locations Location { get; set; }

        public string LocationStr
        {
            get
            {
                return locationStr;
            }
            set
            {
                var field = Location.GetType().GetField(Location.ToString());
                var attributes = field.GetCustomAttributes(false);
                locationStr = TranslationSource.Instance[attributes.Select(a => (DescriptionAttribute)a).ElementAt(0).Description];
                OnPropertyChanged(nameof(LocationStr));
            }
        }
        public string IconPath
        {
            get
            {
                return path;
            }
        }

        #endregion

        #region Methods
        public void LanguageChangeHandler()
        {
            LocationStr = locationStr;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
