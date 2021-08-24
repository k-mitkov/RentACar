using Data.Enums;
using DesktopClient.Commands;
using DesktopClient.Util;
using System.Collections.Generic;
using System.ComponentModel;

namespace DesktopClient.BussinesModels
{
    class VehicleTypeButton : INotifyPropertyChanged
    { 
        #region Declarations 
        private static List<VehicleTypeButton> buttons;
        private string name;
        private bool isSelected;
        private ButtonCommand carCommand;
        private ButtonCommand eCarCommand;
        private ButtonCommand truckCommand;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Proparties
        public int Id { get; set; }

        public string Name
        {
            get
            {
                return TranslationSource.Instance[name];
            }
            set
            {
                switch (Type)
                {
                    case TypeVehicle.Car:
                        name = "strCars";
                        break;
                    case TypeVehicle.Electric:
                        name = "strECars";
                        break;
                    case TypeVehicle.Freight:
                        name = "strCargo";
                        break;
                    default:
                        name = "";
                        break;
                }
            }
        }
        public string IconPath { get; set; }
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

        public ButtonCommand CarCommand
        {
            get
            {
                if (carCommand == null)
                {
                    carCommand = new ButtonCommand(SelectCar, CanExecuteShow);
                }
                return carCommand;
            }
        }

        public ButtonCommand ECarCommand
        {
            get
            {
                if (eCarCommand == null)
                {
                    eCarCommand = new ButtonCommand(SelectECar, CanExecuteShow);
                }
                return eCarCommand;
            }
        }

        public ButtonCommand TruckCommand
        {
            get
            {
                if (truckCommand == null)
                {
                    truckCommand = new ButtonCommand(SelectTruck, CanExecuteShow);
                }
                return truckCommand;
            }
        }
        #endregion

        #region Methods
        public static List<VehicleTypeButton> GetButtons()
        {
            if(buttons == null)
            {
                buttons = new List<VehicleTypeButton>();
                buttons.Add(new VehicleTypeButton
                {
                    Id = 0,
                    IconPath = @"\Resources\Images\car_search_icon.png",
                    IconPathBlue = @"\Resources\Images\car_search_icon_blue.png",
                    Type = TypeVehicle.Car,
                    Name = "",
                    IsSelected = true
                });
                buttons.Add(new VehicleTypeButton
                {
                    Id = 1,
                    IconPath = @"\Resources\Images\e-car_search_icon.png",
                    IconPathBlue = @"\Resources\Images\e-car_search_icon_blue.png",
                    Type = TypeVehicle.Electric,
                    Name = "",
                    IsSelected = false
                });
                buttons.Add(new VehicleTypeButton
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

        private void SelectCar(object o)
        {
            buttons[0].IsSelected = true;
            buttons[1].IsSelected = false;
            buttons[2].IsSelected = false;
        }

        private void SelectECar(object o)
        {
            buttons[0].IsSelected = false;
            buttons[1].IsSelected = true;
            buttons[2].IsSelected = false;
        }

        private void SelectTruck(object o)
        {
            buttons[0].IsSelected = false;
            buttons[1].IsSelected = false;
            buttons[2].IsSelected = true;
        }

        public bool CanExecuteShow(object o)
        {
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
