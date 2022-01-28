using System;
using Model;

namespace TestUser
{
    internal class Program
    {
        static void Main()
        {
            bool endWork = false;
            while (true)
            {
                Console.WriteLine("Type option (email, name, quit):\n");

                string mode = Console.ReadLine();

                switch (mode.ToLower())
                {
                    case "quit":
                        endWork = true;
                        break;
                    case "email":
                        CreateUserByEmail();
                        break;
                    case "name":
                        CreateUserByName();
                        break;
                }
                if (endWork) break;
            }
            FinishWork();
        }

        private static void FinishWork()
        {
            Console.WriteLine("Program end work\nPress any key to exit");
            Console.ReadKey();
        }

        private static void CreateUserByName()
        {
            string name = Console.ReadLine();
            string lastName = Console.ReadLine();

            User user = new(name, lastName);
            
            Console.WriteLine($"User created by name, lastname:\n\nUser name: {user.Name}\nUser lastname: {user.LastName}\nUser email:{user.Email}\n");
        }

        private static void CreateUserByEmail()
        {
            string email = Console.ReadLine();

            User user = new(email);

            Console.WriteLine($"User created by email:\n\nUser name: {user.Name}\nUser lastname: {user.LastName}\nUser email:{user.Email}\n");
        }
    }
}
