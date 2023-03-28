using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace WpfLaba2
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private DateTime _dateOfBirth;
        private string _age;
        private string _zodiacSigns;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                _dateOfBirth = value;
                OnPropertyChanged("DateOfBirth");
            }
        }

        public string Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged("Age");
            }
        }

        public string ZodiacSigns
        {
            get { return _zodiacSigns; }
            set
            {
                _zodiacSigns = value;
                OnPropertyChanged("ZodiacSigns");
            }
        }

        public ICommand CalculateAgeAndZodiacCommand { get; private set; }

        public MainViewModel()
        {
            DateOfBirth = DateTime.Now;
            CalculateAgeAndZodiacCommand = new RelayCommand(CalculateAgeAndZodiac);
        }

        private void CalculateAgeAndZodiac()
        {
            int age = CalculateAge(DateOfBirth);
            if (age < 0 || age > 135)
            {
                MessageBox.Show("Введіть коректну дату народження!", "Помилка", MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            Age = age.ToString();

            if (DateTime.Today.Day == DateOfBirth.Day && DateTime.Today.Month == DateOfBirth.Month)
            {
                MessageBox.Show("Вітаємо з днем народження!", "Приємно", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            }

            ZodiacSigns = $"{CalculateWesternZodiacSign(DateOfBirth)} | {CalculateChineseZodiacSign(DateOfBirth)}";
        }

        private string CalculateWesternZodiacSign(DateTime dateOfBirth)
        {
            var month = dateOfBirth.Month;
            var day = dateOfBirth.Day;
            return month switch
            {
                3 when day >= 21 => "Овен",
                4 when day <= 19 => "Овен",
                4 when day >= 20 => "Телець",
                5 when day <= 20 => "Телець",
                5 when day >= 21 => "Близнюки",
                6 when day <= 20 => "Близнюки",
                6 when day >= 21 => "Рак",
                7 when day <= 22 => "Рак",
                7 when day >= 23 => "Лев",
                8 when day <= 22 => "Лев",
                8 when day >= 23 => "Діва",
                9 when day <= 22 => "Діва",
                9 when day >= 23 => "Терези",
                10 when day <= 22 => "Терези",
                10 when day >= 23 => "Скорпіон",
                11 when day <= 21 => "Скорпіон",
                11 when day >= 22 => "Стрілець",
                12 when day <= 21 => "Стрілець",
                12 when day >= 22 => "Козоріг",
                1 when day <= 19 => "Козоріг",
                1 when day >= 20 => "Водолій",
                2 when day <= 18 => "Водолій",
                2 when day >= 19 => "Риби",
                3 when day <= 20 => "Риби",
                _ => "Невідомо"
            };
        }

        private string CalculateChineseZodiacSign(DateTime dateOfBirth) =>
            ((dateOfBirth.Year - 4) % 12) switch
            {
                0 => "Щур",
                1 => "Бик",
                2 => "Тигр",
                3 => "Кролик",
                4 => "Дракон",
                5 => "Змія",
                6 => "Кінь",
                7 => "Коза",
                8 => "Мавпа",
                9 => "Півень",
                10 => "Собака",
                11 => "Свиня",
                _ => "Невідомо"
            };

        private int CalculateAge(DateTime dateOfBirth)
        {
            int age = DateTime.Now.Year - dateOfBirth.Year;
            if (DateTime.Now.Month < dateOfBirth.Month ||
                (DateTime.Now.Month == dateOfBirth.Month && DateTime.Now.Day < dateOfBirth.Day))
            {
                age--;
            }

            return age;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}