using System;
using System.Collections.Generic;
using AdminNamespace;
using UserNamespace;
using System.Threading;
using Post_hw;

Admin admin = new();
List<Admin> admins = new() { admin };

User user = new(1,"Murad","Eliyev",18);
List<User> users = new() { user };

var a = DateTime.Now;
Post post1 = new(1, "Life Is Better When You’re Laughing", a);

var b = DateTime.Now;
Post post2 = new(2, "The only thing stopping you is you", b);

var c = DateTime.Now;
Post post3 = new(3, "Success is a collection of problems solved", b);

List<Post> posts = new() { post1, post2, post3 };

void Notifications()
{
    Console.Clear();
    Console.Write("\t\t\t\t\tNotifications: ");
    int j = 0;
    for (int i = 0; i < posts.Count; i++)
    {       
        if (posts[i].ViewCount > 0 || posts[i].LikeCount > 0)
        { 
            Console.Beep();
            j=i+1;
            Console.Write($"{j}-ci posta {user.Name} terefinden like veya baxis edildi\n\t\t\t\t\t\t\t\b");       
        }
    }
    Console.WriteLine();
    foreach (var post in posts)
    {
        if (post.ViewCount > 0 || post.LikeCount > 0)
        {
            post.Show();
        }
    }
    Console.Write("Exit(0): ");
    var c =Console.ReadKey();
    if (c.Key== ConsoleKey.D0)
    {
        Console.Clear();
        AdminOrUser();
    }
    else
    {
        Console.WriteLine("You can choose 0");
    }
}
void AdminOrUser()
{
    Console.WriteLine(
        "1. Admin\n" +
        "2. User"
        );
    Console.Write("Choose=> ");
    int ch = int.Parse(Console.ReadLine());
    Console.Clear();
    RegisterOrLogin(ref ch);
}

void RegisterOrLogin(ref int ch)
{label:
    Console.WriteLine("1. SignUp" +
        "\n2. SignIn" +
        "\n3. Exit");
    int a = int.Parse(Console.ReadLine());
    if (ch == 1)
    {
        if (a == 1)
        {
            admin.SignUp( admins);
            goto label;
        }
        else if (a==2)
        {
            admin.SignIn( admins);
            Notifications();
            
        }
        else if (a == 3)
        {
            Console.Clear();
            AdminOrUser();
        }
    }
    else if (ch == 2)
    {
        if (a == 1)
        {
            user.SignUp(users);
            goto label;
        }
        else if (a == 2)
        {
            user.SignIn(users);
            ShowPosts();
        }
        else if (a == 3)
        {
            Console.Clear();
            AdminOrUser();
        }
    }    
    else
    {
        throw new Exception();
    }
}

try
{
    AdminOrUser();
}
catch (Exception ex)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Wrong Choice. You can choose only 1 and 2.");
    Console.ResetColor();
    Thread.Sleep(2000);
    Console.Clear();
    AdminOrUser();

}

void ShowPosts()
{
    Console.Clear();
    Console.WriteLine("\t\t--Posts--\n");
    foreach (var post in posts)
    {
        post.Show();
    }
    Console.WriteLine("\t\t\t\t(0)Back");
    Console.Write("Choose: ");
    var ch = Console.ReadKey();
    Thread.Sleep(400);
    if (ch.Key == ConsoleKey.D1)
    {
        Console.Clear();
        post1.ViewCount++;
        post1.Show();
        Like(ch.Key);
    }
    else if (ch.Key == ConsoleKey.D2)
    {
        Console.Clear();
        post2.ViewCount++;
        post2.Show();
        Like(ch.Key);
    }
    else if (ch.Key == ConsoleKey.D3)
    {
        Console.Clear();
        post3.ViewCount++;
        post3.Show();
        Like(ch.Key);
    }
    else if (ch.Key == ConsoleKey.D0)
    {
        Console.Clear();
        AdminOrUser();
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        try
        {
            throw new FormatException("Wrong Choice!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ResetColor();
        Console.WriteLine("Please try again.");
        Thread.Sleep(1500);
        Console.Clear();
        ShowPosts();
    }
}



void Like(ConsoleKey ch)
{
    label2:
    Console.Write("Like (+) or LeftArrow (<): ");
    var key = Console.ReadKey();
    if (key.Key == ConsoleKey.LeftArrow)
    {
        Console.Clear();
        ShowPosts();
    }
    else if (key.Key == ConsoleKey.Add || key.Key == ConsoleKey.OemPlus)
    {
        if (ch == ConsoleKey.D1)
        {
            Console.Clear();
            post1.LikeCount++;
            post1.Show();
            goto label2;
        }
        else if (ch == ConsoleKey.D2)
        {
            Console.Clear();
            post2.LikeCount++;
            post2.Show();
            goto label2;
        }
        else if (ch == ConsoleKey.D3)
        {
            Console.Clear();
            post3.LikeCount++;
            post3.Show();
            goto label2;
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nYou can choose + or LeftArrow");
        Console.ResetColor();
        goto label2;
    }
}
