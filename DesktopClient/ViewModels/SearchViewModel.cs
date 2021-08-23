using Data.Enums;
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
        public event Action<IEnumerable<Car>,Locations> SearchEvent;
        private ButtonCommand buttonCommand;
        private ButtonCommand carCommand;
        private ButtonCommand eCarCommand;
        private ButtonCommand truckCommand;
        private bool isCarSelected;
        private bool isECarSelected;
        private bool isTruckSelected;
        private ObservableCollection<LocationRapper> locations;
        private List<Hours> hours;
        private LocationRapper selectedLocationFrom;
        private LocationRapper selectedLocationTo;
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

            IsCarSelected = true;
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

        public bool IsCarSelected
        {
            get
            {
                return isCarSelected;
            }
            set
            {
                isCarSelected = value;
                OnPropertyChanged(nameof(IsCarSelected));
            }
        }

        public bool IsECarSelected
        {
            get
            {
                return isECarSelected;
            }
            set
            {
                isECarSelected = value;
                OnPropertyChanged(nameof(IsECarSelected));
            }
        }
        public bool IsTruckSelected
        {
            get
            {
                return isTruckSelected;
            }
            set
            {
                isTruckSelected = value;
                OnPropertyChanged(nameof(IsTruckSelected));
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

        public List<Hours> HoursList
        {
            get
            {
                return hours;
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
        private void OnSearch(IEnumerable<Car> cars, Locations locationTo)
        {
            SearchEvent.Invoke(cars, locationTo);
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
            OnSearch(carService.GetCarsByPeriod(period), SelectedLocationTo.Location);
        }

        private void SelectCar(object o)
        {
            IsCarSelected = true;
            IsECarSelected = false;
            IsTruckSelected = false;
        }

        private void SelectECar(object o)
        {
            IsCarSelected = false;
            IsECarSelected = true;
            IsTruckSelected = false;
        }

        private void SelectTruck(object o)
        {
            IsCarSelected = false;
            IsECarSelected = false;
            IsTruckSelected = true;
        }
        #endregion
    }
}
