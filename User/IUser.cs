using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    interface IUser
    {
        public string Name { get; }
        public string LastName { get; }
        public string Email { get; }
    }
}
