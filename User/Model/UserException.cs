using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class UserException : Exception
    {
        public string PropertyName { get; set; }
        public UserException(string propertyName, string message) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
