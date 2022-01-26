using System;
using Model;

namespace Model
{
    public class User : IUser
    {
        private string _name;
        private string _lastname;
        private string _email;

        public string Name => _name;
        public string LastName => _lastname;
        public string Email => _email;

        public User()
        {

        }
    }
}
