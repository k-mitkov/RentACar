using Data.Enums;
using DesktopClient.Commands;
using DesktopClient.Util;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace DesktopClient.BussinesModels
{
    public abstract class VehicleTypeButton : INotifyPropertyChanged
    { 
        #region Declarations 
        protected static List<VehicleTypeButton> buttons;
        private string name;
        private bool isSelected;
        private ButtonCommand buttonCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        private string iconPath;
        #endregion

        #region Constructor
        public VehicleTypeButton()
        {
            TranslationSource.Instance.LanguageEvent += LanguageChangeHandler;
        }
        #endregion

        #region Proparties
        public int Id { get; set; }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                var field = Type.GetType().GetField(Type.ToString());
                var attributes = field.GetCustomAttributes(false);

                name = TranslationSource.Instance[attributes.Select(a => (DescriptionAttribute)a).ElementAt(0).Description];
                OnPropertyChanged(nameof(Name));
            }
        }
        public string IconPath
        {
            get
            {
                if(IsSelected == false)
                {
                    return iconPath;
                }
                return IconPathBlue;
            }
            set
            {
                iconPath = value;
            }
        }
        public string IconPathBlue { get; set; }
        public TypeVehicle Type { get; set; }
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }

        }

        public ButtonCommand ButtonCommand
        {
            get
            {
                if (buttonCommand == null)
                {
                    buttonCommand = new ButtonCommand(SelectButton, CanExecuteShow);
                }
                return buttonCommand;
            }
        }

        #endregion

        #region Methods
        public static List<VehicleTypeButton> GetButtons()
        {
            if(buttons == null)
            {
                buttons = new List<VehicleTypeButton>();
                buttons.Add(new CarButton
                {
                    Id = 0,
                    IconPath = @"\Resources\Images\car_search_icon.png",
                    IconPathBlue = @"\Resources\Images\car_search_icon_blue.png",
                    Type = TypeVehicle.Car,
                    Name = "",
                    IsSelected = true
                });
                buttons.Add(new ECarButton
                {
                    Id = 1,
                    IconPath = @"\Resources\Images\e-car_search_icon.png",
                    IconPathBlue = @"\Resources\Images\e-car_search_icon_blue.png",
                    Type = TypeVehicle.Electric,
                    Name = "",
                    IsSelected = false
                });
                buttons.Add(new CargoButton
                {
                    Id = 2,
                    IconPath = @"\Resources\Images\truck_search_icon.png",
                    IconPathBlue = @"\Resources\Images\truck_search_icon_dark.png",
                    Type = TypeVehicle.Freight,
                    Name = "",
                    IsSelected = false
                });
            }
            return buttons;
        }

        public abstract void SelectButton(object _);

        public bool CanExecuteShow(object o)
        {
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void LanguageChangeHandler()
        {
            Name = name;
        }
        #endregion
    }
}
