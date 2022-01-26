using System;
using Model;

namespace TestUser
{
    internal class Program
    {
        static void Main()
        {
            while (true)
            {
                User user = new User(Console.ReadLine());
                Console.WriteLine($"{user.Name} {user.LastName}");
            }
            //Console.ReadKey();
        }
    }
}
