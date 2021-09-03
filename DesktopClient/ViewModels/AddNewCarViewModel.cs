using Data.Enums;
using Data.Models;
using DesktopClient.BussinesModels;
using DesktopClient.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace DesktopClient.ViewModels
{
    public class AddNewCarViewModel : BaseViewModel
    {
        #region Declarations

        private ICommand browsCommand;
        private ICommand addCommand;
        private string imagePath;
        private string brand;
        private string model;
        private LocationRapper selectedLocation;
        private List<LocationRapper> locations;
        private int year;
        private int capacity;
        private decimal consumation;
        private decimal price;
        private IEnumerable<VehicleTypeButton> vehicleTypes;
        private VehicleTypeButton selectedType;
        private bool isBrandValid;
        private bool isModelValid;
        private bool isYearValid;
        private bool isCapacityValid;
        private bool isConsumationValid;
        private bool isPathValid;
        private bool isPriceValid;
        private readonly string path= @"\Resources\Images\";

        #endregion

        #region Constructor
        public AddNewCarViewModel()
        {
            InitialaizeIsValid();

            InitialaizeLocations();
            SelectedLocation = locations[0];

            VehicleTypes = VehicleTypeButton.GetButtons();

            SelectedType = vehicleTypes.First(t => t.IsSelected == true);
        }
        #endregion

        #region Proparties

        public ICommand AddCommand
        {
            get
            {
                if (addCommand == null)
                {
                    addCommand = new ButtonCommand(Add, CanExecuteShow);
                }
                return addCommand;
            }
        }

        public ICommand BrowsCommand
        {
            get
            {
                if(browsCommand == null)
                {
                    browsCommand = new ButtonCommand(Brows, CanExecuteShow);
                }
                return browsCommand;
            }
        }

        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {

                imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }

        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {

                brand = value.Trim();
                IsBrandValid = brand != null && brand.Length > 1;
                OnPropertyChanged(nameof(Brand));
            }
        }

        public string Model
        {
            get
            {
                return model;
            }
            set
            {

                model = value.Trim();
                IsModelValid = model != null && model.Length > 1;
                OnPropertyChanged(nameof(Model));
            }
        }

        public int Year
        {
            get
            {
                return year;
            }
            set
            {

                year = value;
                IsYearValid = year > 1950;
                OnPropertyChanged(nameof(Year));
            }
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
            set
            {

                capacity = value;
                IsCapacityValid = capacity > 0;
                OnPropertyChanged(nameof(Capacity));
            }
        }

        public decimal Consumation
        {
            get
            {
                return consumation;
            }
            set
            {

                consumation = value;
                IsConsumationValid = consumation > 0;
                OnPropertyChanged(nameof(Consumation));
            }
        }

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {

                price = value;
                IsPriceValid = Price > 0;
                OnPropertyChanged(nameof(Price));
            }
        }

        public LocationRapper SelectedLocation
        {
            get
            {
                return selectedLocation;
            }
            set
            {

                selectedLocation = value;
                OnPropertyChanged(nameof(SelectedLocation));
            }
        }

        public VehicleTypeButton SelectedType
        {
            get
            {
                return selectedType;
            }
            set
            {
                if(selectedType != value)
                {
                    selectedType = value;
                    selectedType.SelectButton(null);
                    VehicleTypes = VehicleTypeButton.GetButtons();
                    OnPropertyChanged(nameof(SelectedType));
                }
            }
        }

        public IEnumerable<LocationRapper> LocationsList { get; set; }

        public IEnumerable<VehicleTypeButton> VehicleTypes
        {
            get
            {
                return vehicleTypes;
            }
            set
            {
                vehicleTypes = value.ToList();
                OnPropertyChanged(nameof(VehicleTypes));
            }
        }

        public bool IsBrandValid
        {
            get
            {
                return isBrandValid;
            }
            set
            {
                isBrandValid = value;
                OnPropertyChanged(nameof(IsBrandValid));
            }
        }

        public bool IsModelValid
        {
            get
            {
                return isModelValid;
            }
            set
            {
                isModelValid = value;
                OnPropertyChanged(nameof(IsModelValid));
            }
        }

        public bool IsCapacityValid
        {
            get
            {
                return isCapacityValid;
            }
            set
            {
                isCapacityValid = value;
                OnPropertyChanged(nameof(IsCapacityValid));
            }
        }

        public bool IsYearValid
        {
            get
            {
                return isYearValid;
            }
            set
            {
                isYearValid = value;
                OnPropertyChanged(nameof(IsYearValid));
            }
        }

        public bool IsConsumationValid
        {
            get
            {
                return isConsumationValid;
            }
            set
            {
                isConsumationValid = value;
                OnPropertyChanged(nameof(IsConsumationValid));
            }
        }

        public bool IsPriceValid
        {
            get
            {
                return isPriceValid;
            }
            set
            {
                isPriceValid = value;
                OnPropertyChanged(nameof(IsPriceValid));
            }
        }

        public bool IsPathValid
        {
            get
            {
                return isPathValid;
            }
            set
            {
                isPathValid = value;
                OnPropertyChanged(nameof(IsPathValid));
            }
        }

        #endregion

        #region Methods

        private void Add(object _)
        {
            if (Validate())
            {
                string shortPath = path + imagePath.Split('\\').Last();

                Car car = new Car()
                {
                    Brand = brand,
                    Model = model,
                    Year = year,
                    Capacity = capacity,
                    Consumation = consumation,
                    Path = shortPath,
                    Price = price
                };

                carService.AddNewCar(car, selectedLocation.Location);
            }
        }

        private bool Validate()
        {
            IsBrandValid = brand != null && brand.Length > 1;
            IsModelValid = model != null && model.Length > 1;
            IsYearValid = year > 1950;
            IsCapacityValid = capacity > 0;
            IsConsumationValid = consumation > 0.0m;
            IsPriceValid = price > 0;
            IsPathValid = imagePath != null && File.Exists(imagePath);

            return IsBrandValid && IsModelValid && IsYearValid && IsCapacityValid && IsConsumationValid &&IsPriceValid && IsPathValid;
        }

        public bool CanExecuteShow(object o)
        {
            return true;
        }

        private void Brows(object _)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.png;*.img;*.gif";
            if (openFileDialog.ShowDialog() == true)
            {
                ImagePath = openFileDialog.FileName;
            }
        }

        private void InitialaizeLocations()
        {
            locations = new List<LocationRapper>();

            locations.Add(new LocationRapper(Locations.Sofia));
            locations.Add(new LocationRapper(Locations.Plovdiv));
            locations.Add(new LocationRapper(Locations.Varna));
            locations.Add(new LocationRapper(Locations.Burgas));

            LocationsList = locations;
        }

        private void InitialaizeIsValid()
        {
            isBrandValid = true;
            isModelValid = true;
            isYearValid = true;
            isCapacityValid = true;
            isConsumationValid = true;
            isPathValid = true;
            isPriceValid = true;
        }

        #endregion

    }
}
