﻿using Data.Enums;
using Data.Models;
using DesktopClient.BussinesModels;
using DesktopClient.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DesktopClient.ViewModels
{
    class SearchViewModel : BaseViewModel
    {
        #region Declarations
        public event Action<IEnumerable<CarPeriodRapper>> SearchEvent;
        private ButtonCommand buttonCommand;
        private ObservableCollection<LocationRapper> locations;
        private List<Hours> hours;
        private List<VehicleTypeButton> buttons;
        private LocationRapper selectedLocationFrom;
        private LocationRapper selectedLocationTo;
        private VehicleTypeButton carButton;
        private VehicleTypeButton eCarButton;
        private VehicleTypeButton truckButton;
        #endregion

        #region Constructor
        public SearchViewModel()
        {
            locations = new ObservableCollection<LocationRapper>();

            locations.Add(new LocationRapper()
            {
                Location = Locations.Sofia
            });
            locations.Add(new LocationRapper()
            {
                Location = Locations.Plovdiv
            });
            locations.Add(new LocationRapper()
            {
                Location = Locations.Varna
            });
            locations.Add(new LocationRapper()
            {
                Location = Locations.Burgas
            });

            hours = Hours.GetHours();

            GetButtons();

            SelectedLocationFrom = locations.First(l => l.Location == Locations.Sofia);
            SelectedLocationTo = locations.First(l => l.Location == Locations.Sofia);
            SelectedHourFrom = hours.First(h => h.Hour.Equals("11:00"));
            SelectedHourTo = hours.First(h => h.Hour.Equals("11:00"));
            SelectedDateFrom = DateTime.Now;
            SelectedDateTo = DateTime.Now;
        }
        #endregion

        #region Proparties
        public ButtonCommand SearchCommand
        {
            get
            {
                if (buttonCommand == null)
                {
                    buttonCommand = new ButtonCommand(Search, CanExecuteShow);
                }
                return buttonCommand;
            }
        }

        public ObservableCollection<LocationRapper> LocationsList
        {
            get
            {
                return locations;
            }
            set
            {
                locations = value;
                OnPropertyChanged(nameof(LocationsList));
            }
        }

        public IEnumerable<Hours> HoursList
        {
            get
            {
                return hours;
            }
        }

        //public IEnumerable<Button> Buttons
        //{
        //    get
        //    {
        //        return buttons;
        //    }
        //    set
        //    {
        //        buttons = value.ToList();
        //        OnPropertyChanged(nameof(Buttons));
        //    }
        //}

        public VehicleTypeButton CarButton
        {
            get
            {
                return carButton;
            }
            set
            {
                carButton = value;
                OnPropertyChanged(nameof(CarButton));
            }
        }
        public VehicleTypeButton ECarButton
        {
            get
            {
                return eCarButton;
            }
            set
            {
                eCarButton = value;
                OnPropertyChanged(nameof(ECarButton));
            }
        }

        public VehicleTypeButton TruckButton
        {
            get
            {
                return truckButton;
            }
            set
            {
                truckButton = value;
                OnPropertyChanged(nameof(TruckButton));
            }
        }

        public LocationRapper SelectedLocationFrom
        {
            get
            {
                return selectedLocationFrom;
            }
            set
            {
                selectedLocationFrom = value;
                OnPropertyChanged(nameof(SelectedLocationFrom));
            }
        }

        public LocationRapper SelectedLocationTo
        {
            get
            {
                return selectedLocationTo;
            }
            set
            {
                selectedLocationTo = value;
                OnPropertyChanged(nameof(SelectedLocationTo));
            }
        }
        public Hours SelectedHourFrom { get; set; }

        public Hours SelectedHourTo { get; set; }

        public DateTime SelectedDateFrom { get; set; }

        public DateTime SelectedDateTo { get; set; }
        #endregion

        #region Methods
        private void OnSearch(IEnumerable<CarPeriodRapper> rappers)
        {
            SearchEvent.Invoke(rappers);
        }

        public bool CanExecuteShow(object o)
        {
            return true;
        }

        public void Search(object o)
        {
            Period period = new Period()
            {
                From = new DateTime(SelectedDateFrom.Year, SelectedDateFrom.Month, SelectedDateFrom.Day, int.Parse(SelectedHourFrom.Hour.Split(":").First()), 0, 0),
                To = new DateTime(SelectedDateTo.Year, SelectedDateTo.Month, SelectedDateTo.Day, int.Parse(SelectedHourTo.Hour.Split(":").First()), 0, 0),
                Location = SelectedLocationFrom.Location
            };
            TypeVehicle type = buttons.Where(b => b.IsSelected == true).First().Type;

            List<Car> cars = carService.GetCarsByPeriodAndType(period, type).ToList();
            List<CarPeriodRapper> rappers=new List<CarPeriodRapper>();
            foreach(Car car in cars)
            {
                rappers.Add(new CarPeriodRapper(car, period, SelectedLocationTo.Location));
            }

            OnSearch(rappers);
        }

        public void GetButtons()
        {
            buttons = VehicleTypeButton.GetButtons();
            CarButton = buttons[0];
            ECarButton = buttons[1];
            TruckButton = buttons[2];
        }

        #endregion
    }
}
