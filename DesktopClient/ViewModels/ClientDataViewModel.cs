using Data.Models;
using DesktopClient.BussinesModels;
using DesktopClient.Commands;
using System;
using System.Text.RegularExpressions;

namespace DesktopClient.ViewModels
{
    class ClientDataViewModel : BaseViewModel
    {
        #region Declarations
        private Client client;
        private ButtonCommand bookCommand;
        private ButtonCommand backCommand;
        private const string mailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
        private const string phoneRegex = @"^(\+){1}[0-9]{12}$|^08[0-9]{8}$";
        private CarPeriodRapper carPeriodRapper;
        public event Action BookEvent;
        public event Action BackEvent;
        private bool isMailValid;
        private bool isNameValid;
        private bool isLastNameValid;
        private bool isPhoneValid;
        private bool isDateOfBirthValid;
        #endregion

        #region Constructor
        public ClientDataViewModel(CarPeriodRapper carPeriodRapper)
        {
            this.carPeriodRapper = carPeriodRapper;
            client = new Client();
            DateOfBirth = DateTime.Now;
            IsMailValid = true;
            IsNameValid = true;
            IsPhoneValid = true;
            IsLastNameValid = true;
            IsDateOfBirthValid = true;
        }
        #endregion

        #region Proparties
        public string Mail
        {
            get
            {
                return client.Mail;
            }
            set
            {
                client.Mail = value;
                IsMailValid = client.Mail != null && Regex.IsMatch(client.Mail, mailRegex);
            }
        }

        public string Name
        {
            get
            {
                return client.FirstName;
            }
            set
            {
                client.FirstName = value;
                IsNameValid = client.FirstName != null && client.FirstName.Length > 1;
            }
        }

        public string LastName
        {
            get
            {
                return client.LastName;
            }
            set
            {
                client.LastName = value;
                IsLastNameValid = client.LastName != null && client.LastName.Length > 1;
            }
        }

        public string Phone
        {
            get
            {
                return client.Phone;
            }
            set
            {
                client.Phone = value;
                IsPhoneValid = client.Phone != null && Regex.IsMatch(client.Phone, phoneRegex);
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return client.DateOfBirth;
            }
            set
            {
                client.DateOfBirth = value;
                IsDateOfBirthValid = client.DateOfBirth != null && client.DateOfBirth < DateTime.Now.AddYears(-18);
            }
        }

        public bool IsMailValid
        {
            get
            {
                return isMailValid;
            }
            set
            {
                isMailValid = value;
                OnPropertyChanged(nameof(IsMailValid));
            }
        }

        public bool IsNameValid
        {
            get
            {
                return isNameValid;
            }
            set
            {
                isNameValid = value;
                OnPropertyChanged(nameof(IsNameValid));
            }
        }

        public bool IsLastNameValid
        {
            get
            {
                return isLastNameValid;
            }
            set
            {
                isLastNameValid = value;
                OnPropertyChanged(nameof(IsLastNameValid));
            }
        }

        public bool IsPhoneValid
        {
            get
            {
                return isPhoneValid;
            }
            set
            {
                isPhoneValid = value;
                OnPropertyChanged(nameof(IsPhoneValid));
            }
        }

        public bool IsDateOfBirthValid
        {
            get
            {
                return isDateOfBirthValid;
            }
            set
            {
                isDateOfBirthValid = value;
                OnPropertyChanged(nameof(IsDateOfBirthValid));
            }
        }
        public ButtonCommand BookCommand
        {
            get
            {
                if (bookCommand == null)
                {
                    bookCommand = new ButtonCommand(Book, CanExecuteShow);
                }
                return bookCommand;
            }
        }

        public ButtonCommand BackCommand
        {
            get
            {
                if (backCommand == null)
                {
                    backCommand = new ButtonCommand(Back, CanExecuteShow);
                }
                return backCommand;
            }
        }
        #endregion

        #region Methods
        private bool CanExecuteShow(object o)
        {
            return true;
        }

        private void Book(object o)
        {
            if (ValidateInput())
            {
                if (carService.ReserveCar(carPeriodRapper.GetCar(), carPeriodRapper.GetPeriod(), client, carPeriodRapper.GetLocationTo()))
                {
                    OnBook();
                }
            }
        }

        private void Back(object o)
        {
            BackEvent.Invoke();
        }

        private bool ValidateInput()
        {
            IsMailValid = client.Mail != null && Regex.IsMatch(client.Mail, mailRegex);
            IsNameValid = client.FirstName != null && client.FirstName.Length > 1;
            IsLastNameValid = client.LastName != null && client.LastName.Length > 1;
            IsPhoneValid = client.Phone != null && Regex.IsMatch(client.Phone, phoneRegex);
            IsDateOfBirthValid = client.DateOfBirth != null && client.DateOfBirth < DateTime.Now.AddYears(-18);
            return IsMailValid && IsNameValid && IsLastNameValid && IsPhoneValid && IsDateOfBirthValid;
        }

        private void OnBook()
        {
            BookEvent.Invoke();
        }
        #endregion
    }
}
