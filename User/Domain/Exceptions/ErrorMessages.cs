using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal static class ErrorMessages
    {
        public const string INCORRECT_LENGTH = "Invalid argument length. " +
                                               "The number of characters must " +
                                               "be between 2 and 255.";

        public const string INCORRECT_CHARSET = "An invalid character was found. " +
                                                "Use upper and lower case letters, " +
                                                "spaces and hyphens.";

        public const string INCORRECT_EMAIL_FORMAT = "You have used the wrong email " +
                                                     "entry format. Email must be of " +
                                                     "the form: <name>.<lastnamt>@mail.ru";
    }
}
