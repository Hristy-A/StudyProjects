using System;
using Model;

namespace TestUser
{
    internal class Program
    {
        static void Main()
        {
            User user = new User("Test.Data@mail.ru");
            Console.WriteLine($"{user.Name} {user.LastName}");
            Console.ReadKey();
        }
    }
}
