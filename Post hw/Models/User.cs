using System;
using System.Collections.Generic;
using System.Threading;

namespace UserNamespace
{
    class User
    {
        public User(int id, string name, string surname, short age)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;         
        }
        public User()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public short Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public void SignUp(List<User> users)
        {
            User user = new();
            Console.WriteLine("\t\t--SignUp--");
            Console.WriteLine("Enter Email: ");
            user.Email = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            user.Password = Console.ReadLine();
            users.RemoveAt(0);
            users.Add(user);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Has Successfully SignUp...");
            Thread.Sleep(900);
            Console.ResetColor();
            Console.Clear();

        }
        public void SignIn(List<User> users)
        {
            
            if (users[0].Email==null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ilk once SignUp olmalisiz");
                Console.ResetColor();

                SignUp(users);
                Console.Clear();
            }
            label:
            string email, password;
            Console.WriteLine("\t\t--SignIn--");
            Console.WriteLine("Enter Email: ");
            email = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            password = Console.ReadLine();
            bool b = false;
            for (int i = 0; i < users.Count; i++)
            {
                if (email == users[i].Email && password == users[i].Password)
                {
                    b = true;
                }
                else
                {
                    b = false;
                }
            }
            try
            {
                if (b == false)
                {
                    throw new ArgumentException();
                }
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Email or Password !");
                Console.ResetColor();
                Console.WriteLine("Please try again");
                Thread.Sleep(1500);
                Console.Clear();
                goto label;
            }
        }
    }
}
