using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfLaba2
{
    public class PersonViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _dateOfBirth = DateTime.Now;
        private Person _person;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public ICommand ProceedCommand => new RelayCommand(async () => await ProceedAsync(), CanExecuteProceed);

        private bool CanExecuteProceed()
        {
            return !string.IsNullOrEmpty(FirstName) &&
                   !string.IsNullOrEmpty(LastName) &&
                   !string.IsNullOrEmpty(Email) &&
                   DateOfBirth != DateTime.MinValue;
        }

        private async Task ProceedAsync()
        {
            await Task.Run(() =>
            {
                // Реалізуйте логіку перевірки та обчислення тут
                // Виконайте перевірки з Лабораторної роботи 1, наприклад:
                bool isValidEmail = ValidateEmail(Email);
                bool isValidDateOfBirth = ValidateDateOfBirth(DateOfBirth);

                if ( isValidEmail && isValidDateOfBirth )
                {
                    _person = new Person(FirstName, LastName, Email, DateOfBirth);
                    // Виведіть значення полів класу Person
                    Console.WriteLine($"Ім'я: {_person.FirstName}");
                    Console.WriteLine($"Прізвище: {_person.LastName}");
                    Console.WriteLine($"Адреса електронної пошти: {_person.Email}");
                    Console.WriteLine($"Дата народження: {_person.DateOfBirth}");
                    Console.WriteLine($"IsAdult: {_person.IsAdult}");
                    Console.WriteLine($"SunSign: {_person.SunSign}");
                    Console.WriteLine($"ChineseSign: {_person.ChineseSign}");
                    Console.WriteLine($"IsBirthday: {_person.IsBirthday}");
                }
            });
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            _execute();
        }
    }
}