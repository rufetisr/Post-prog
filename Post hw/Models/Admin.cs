using Post_hw;
using System;
using System.Collections.Generic;
using System.Threading;
namespace AdminNamespace
{
    class Admin
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Post> Posts { get; set; }
        public List<Notification> Notifications { get; set; }
        public Admin()
        {

        }

        public Admin(int id, string username, string email, string password)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
        }

        public void SignUp( List<Admin> admins)
        {
            Admin admin = new();
            Console.WriteLine("\t\t--SignUp--");
            Console.WriteLine("Enter Email: ");
            admin.Email = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            admin.Password = Console.ReadLine();
            admins.RemoveAt(0);
            admins.Add(admin);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Has Successfully SignUp...");
            Thread.Sleep(900);
            Console.ResetColor();
            Console.Clear();

        }

        public void SignIn( List<Admin> admins)
        {
            if (admins[0].Email == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ilk once SignUp olmalisiz");
                Console.ResetColor();

                SignUp( admins);
                Console.Clear();
            }
            label:
            Console.WriteLine("\t\t--SignIn--");
            string email, password;
            Console.WriteLine("Enter Email: ");
            email = Console.ReadLine();
            Console.WriteLine("Enter Password: ");
            password = Console.ReadLine();
            bool b = false;
            if (email == admins[0].Email && password == admins[0].Password)
            {
                b = true;
            }
            else
            {
                b = false;
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