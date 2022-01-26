using System;
using Formatting;
using System.Text.RegularExpressions;

namespace Model
{
    public class User : IUser
    {
        private const string DEFAULT_DOMAIN = "@mail.com";

        #region Variables

        private string _name;
        private string _lastName;
        private string _email;

        public string Name => _name;
        public string LastName => _lastName;
        public string Email => _email;

        #endregion

        #region Constructors

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
            Regex pattern = new Regex(@"^(?<name>[A-Za-z_]{2,255})\.(?<lastName>[A-Za-z_]{2,255})@\w{3,}\.\w{2,}");
            Match match = pattern.Match(email);

            if (match.Success)
            {
                _name = match.Groups[1].Captures[0].Value.ToValidFormat(FormatOperations.FormatOption.Naming);
                _lastName = match.Groups[2].Captures[0].Value.ToValidFormat(FormatOperations.FormatOption.Naming);
                _email = CreateEmail(_name, _lastName, email.Substring(email.IndexOf('@')));
            }
            else throw new UserException(nameof(email), ErrorMessages.INCORRECT_EMAIL_FORMAT);
        }

        #endregion

        #region HelpMethods

        private static void CheckFormat(string propertyName, string str)
        {
            if(str.Length < 2 || str.Length > 255)
                throw new UserException(propertyName, ErrorMessages.INCORRECT_LENGTH);
            if (Regex.IsMatch(str, @"[^A-Za-z- ]"))
                throw new UserException(propertyName, ErrorMessages.INCORRECT_CHARSET);
        }
        private string CreateEmail(string name, string lastName, string domain = DEFAULT_DOMAIN)
        {
            return name.ToValidFormat(FormatOperations.FormatOption.Email) + "."
                + lastName.ToValidFormat(FormatOperations.FormatOption.Email)
                + domain;
        }

        #endregion
    }
}
