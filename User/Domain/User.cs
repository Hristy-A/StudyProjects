using System;
using Formatting;
using System.Text.RegularExpressions;

namespace Model
{
    public class User : IUser
    {
        private const string DEFAULT_DOMAIN = "mail.com";

        private string _name;
        private string _lastName;
        private string _email;

        public string Name => _name;
        public string LastName => _lastName;
        public string Email => _email;

        public User(string name, string lastName)
        {
            CheckFormat(nameof(Name), name);
            CheckFormat(nameof(LastName), lastName);

            _name = name.ToValidFormat(FormatOperations.FormatOption.Naming);
            _lastName = lastName.ToValidFormat(FormatOperations.FormatOption.Naming);
            _email = CreateEmail(name, lastName);
        }

        public User(string email)
        {
            if (TryParseEmail(email, out string name, out string lastName))
            {
                _name = name;
                _lastName = lastName;
                _email = CreateEmail(_name, _lastName, GetDomain(email));
            }
            else
            {
                throw new UserException(nameof(email), ErrorMessages.INCORRECT_EMAIL_FORMAT);
            }
        }


        private static string GetDomain(string email)
        {
            return email.Substring(email.IndexOf('@') + 1);
        }
        private static bool TryParseEmail(string email, out string name, out string lastName)
        {
            name = lastName = string.Empty;
            Regex pattern = new Regex(@"^(?<name>[A-Za-z_]{2,255})\.(?<lastName>[A-Za-z_]{2,255})@\w{3,}\.\w{2,}");
            Match match = pattern.Match(email);
            if (match.Success)
            {
                name = match.Groups[1].Captures[0].Value.ToValidFormat(FormatOperations.FormatOption.Naming);
                lastName = match.Groups[2].Captures[0].Value.ToValidFormat(FormatOperations.FormatOption.Naming);
            }
            return match.Success;
        }
        private static void CheckFormat(string propertyName, string str)
        {
            if(str.Length < 2 || str.Length > 255)
                throw new UserException(propertyName, ErrorMessages.INCORRECT_LENGTH);
            if (Regex.IsMatch(str, @"[^A-Za-z- ]"))
                throw new UserException(propertyName, ErrorMessages.INCORRECT_CHARSET);
        }
        private static string CreateEmail(string name, string lastName, string domain = DEFAULT_DOMAIN)
        {
            string validName = name.ToValidFormat(FormatOperations.FormatOption.Email);
            string validLastName = lastName.ToValidFormat(FormatOperations.FormatOption.Email);

            return string.Format($"{validName}.{validLastName}@{domain}");
        }
    }
}
