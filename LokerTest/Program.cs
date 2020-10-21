using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LokerTest
{
    class Program : Menu
    {
        static void Main(string[] args)
        {

            Loker obj = new Loker();
            Menu menu = new Menu();
            Console.WriteLine(menu.Judul);
            Console.WriteLine("");
            Console.WriteLine("");

            login:
            var username = string.Empty;
            var password = string.Empty;
            Console.Write("Username : ");
            username = Console.ReadLine();
            Console.Write("Password : ");
            password = Console.ReadLine();

            menu.login(username, password);

            if (!menu.login(username, password))
            {
                Console.WriteLine("username and password incorect!");
                goto login;
            }
            Console.Clear();
            MainMenu();
            Console.ReadLine();

        }
    }
}
