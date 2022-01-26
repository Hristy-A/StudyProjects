using System;
using Formatting;
using System.Text.RegularExpressions;

namespace Model
{
    public class User : IUser
    {
        private const string DOMAIN = "@mail.com";

        private string _name;
        private string _lastName;
        private string _email;

        public string Name => _name;
        public string LastName => _lastName;
        public string Email => _email;

        public User(string name, string lastName)
        {
            if (string.IsNullOrWhiteSpace(name)) 
                throw new ArgumentException(nameof(name));
            if (string.IsNullOrWhiteSpace(lastName)) 
                throw new ArgumentException(nameof(lastName));
                
            _name = lastName.ToValidFormat();
            _lastName = lastName.ToValidFormat();
            _email = _name.ToLower() + _lastName.ToLower() + DOMAIN;
        }
        public User(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) 
                throw new ArgumentException(nameof(email));

            Regex pattern = new Regex(@"^(?<name>[A-Za-z_]+)\.(?<lastName>[A-Za-z_]+)@");
            Match match = pattern.Match(email);

            if (match.Success)
            {
                _name = match.Groups[1].Captures[0].Value;
                _lastName = match.Groups[2].Captures[0].Value;
            }
        }
    }
}
