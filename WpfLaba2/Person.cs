using System;
using System.Windows;

namespace WpfLaba2
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime DateOfBirth { get; }

        private readonly bool _isAdult;
        private readonly bool _isBirthday;
        private readonly string _sunSign;
        private readonly string _chineseSign;
        private readonly int _age;

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            _age = CalculateAge();
            _sunSign = CalculateSunSign();
            _chineseSign = CalculateChineseSign();

            _isBirthday = DateTime.Today.Day == DateOfBirth.Day && DateTime.Today.Month == DateOfBirth.Month;
            _isAdult = _age is >= 18 and <= 135;
        }

        public Person(string firstName, string lastName, string email)
            : this(firstName, lastName, email, DateTime.MinValue)
        {
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
            : this(firstName, lastName, string.Empty, dateOfBirth)
        {
        }

        public bool IsAdult => _isAdult;
        public string SunSign => _sunSign;
        public string ChineseSign => _chineseSign;
        public bool IsBirthday => _isBirthday;


        private string CalculateSunSign()
        {
            var month = DateOfBirth.Month;
            var day = DateOfBirth.Day;
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

        private string CalculateChineseSign() =>
            ((DateOfBirth.Year - 4) % 12) switch
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
        
        private int CalculateAge()
        {
            int age = DateTime.Now.Year - DateOfBirth.Year;
            if (DateTime.Now.Month < DateOfBirth.Month ||
                (DateTime.Now.Month == DateOfBirth.Month && DateTime.Now.Day < DateOfBirth.Day))
            {
                age--;
            }

            return age;
        }
    }
}