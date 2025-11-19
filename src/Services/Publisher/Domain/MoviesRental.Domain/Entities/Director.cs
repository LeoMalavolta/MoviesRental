using MoviesRental.Core.DomainObjects;
using System.Text.RegularExpressions;

namespace MoviesRental.Domain.Entities
{
    public class Director : Entity
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }

        private List<Dvd> _dvds = new List<Dvd>();
        public IReadOnlyList<Dvd> Dvds => _dvds;


        public const int MIN_NAME_LENGTH = 3;
        public const int MAX_NAME_LENGTH = 30;


        public string FullName => $"{Name} {Surname}";

        protected Director() { }

        public Director(string name, string surname)
        {
            UpdateName(name);
            UpdateSurname(surname);
        }

        public void UpdateName(string name)
        {
            if(!ValidateName(name))
                throw new DomainException($"Invalid name for director.");

            Name = name;
        }

        public void UpdateSurname(string surname)
        {
            if (!ValidateName(surname))
                throw new DomainException($"Invalid surname for director.");

            Surname = surname;
        }

        private bool ValidateName(string value)
        {
            if (string.IsNullOrEmpty(value) || value.Length < MIN_NAME_LENGTH || value.Length > MAX_NAME_LENGTH)
                return false;

            return Regex.IsMatch(value, "^(?=.*[A-ZÀ-ÿ~])(?=.*[a-zà-ÿ~])[A-Za-zÀ-ÿ~]+$");
        }
    }
}
