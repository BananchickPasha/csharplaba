using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfLaba2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged(nameof(DateOfBirth));
                CheckCanProceed();
            }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                CheckCanProceed();
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                CheckCanProceed();
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
                CheckCanProceed();
            }
        }

        private bool _canProceed;

        public bool CanProceed
        {
            get { return _canProceed; }
            set
            {
                _canProceed = value;
                OnPropertyChanged(nameof(CanProceed));
            }
        }

        private bool _isProcessing;

        public bool IsProcessing
        {
            get { return _isProcessing; }
            set
            {
                _isProcessing = value;
                OnPropertyChanged(nameof(IsProcessing));
            }
        }

        private string _isAdultMessage;

        public string IsAdultMessage
        {
            get { return _isAdultMessage; }
            set
            {
                _isAdultMessage = value;
                OnPropertyChanged(nameof(IsAdultMessage));
            }
        }

        private string _sunSignMessage;

        public string SunSignMessage
        {
            get { return _sunSignMessage; }
            set
            {
                _sunSignMessage = value;
                OnPropertyChanged(nameof(SunSignMessage));
            }
        }

        private string _chineseSignMessage;

        public string ChineseSignMessage
        {
            get { return _chineseSignMessage; }
            set
            {
                _chineseSignMessage = value;
                OnPropertyChanged(nameof(ChineseSignMessage));
            }
        }
        
        private void CheckCanProceed()
        {
            CanProceed = !IsProcessing && 
                !string.IsNullOrEmpty(FirstName) &&
                !string.IsNullOrEmpty(LastName) &&
                !string.IsNullOrEmpty(Email) &&
                DateOfBirth != default(DateTime);
        }

        public ICommand ProceedCommand { get; }

        public MainViewModel()
        {
            DateOfBirth = DateTime.Now;
            ProceedCommand = new RelayCommand(Proceed);
        }

        private void Proceed()
        {
            IsProcessing = true;
            var t = Task.Run(async () =>
            {
                await Task.Delay(10000);
                var person = new Person(FirstName, LastName, Email, DateOfBirth);
                if (!person.IsAdult)
                {
                    MessageBox.Show("Введіть коректну дату народження!", "Помилка", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                    return;
                }

                if (person.IsBirthday)
                {
                    MessageBox.Show("Вітаємо з днем народження!", "Приємно", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                }

                ChineseSignMessage = person.ChineseSign;
                IsAdultMessage = person.IsAdult ? "Дорослий" : "";
                SunSignMessage = person.SunSign;
            }).ContinueWith(t => IsProcessing = false);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}