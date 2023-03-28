namespace WpfLaba2
{
    using System;

    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime DateOfBirth { get; }

        private readonly bool _isAdult;
        private readonly string _sunSign;
        private readonly string _chineseSign;
        private readonly bool _isBirthday;

        public Person(string firstName, string lastName, string email, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            DateOfBirth = dateOfBirth;
            _isAdult = CalculateIsAdult();
            _sunSign = CalculateSunSign();
            _chineseSign = CalculateChineseSign();
            _isBirthday = CalculateIsBirthday();
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

        private bool CalculateIsAdult()
        {
            // Реалізуйте логіку обчислення IsAdult тут
        }

        private string CalculateSunSign()
        {
            // Реалізуйте логіку обчислення SunSign тут
        }

        private string CalculateChineseSign()
        {
            // Реалізуйте логіку обчислення ChineseSign тут
        }

        private bool CalculateIsBirthday()
        {
            // Реалізуйте логіку обчислення IsBirthday тут
        }
    }
}