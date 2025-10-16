using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kreta1._0
{
    internal class Authorization
    {

        public static List<User> userList = new List<User>();
        public static HashSet<string> osztalyok = new HashSet<string>();
        public static List<Tanulo> tanuloList = new List<Tanulo>();
        public static void fileRead(string Filepath)
        {
            string[] temp = File.ReadAllLines(Filepath);

            foreach (var item in temp)
            {
                string[] d = item.Split(';');
                string role = d[3];
                if (role == "Tanulo")
                {
                    string name = d[0];
                    string osztaly = d[1];
                    string password = d[2];
                    string username = d[4];
                    osztalyok.Add(osztaly);
                    tanuloList.Add(new Tanulo(username, password, name, osztaly));
                    userList.Add(new Tanulo(username, password, name, osztaly));
                }
                else if (role == "Tanar")
                {
                    string name = d[1];
                    string username = d[1].Trim().ToLower();
                    string password = d[0];
                    string tantargy = d[2];
                    userList.Add(new Tanar(username, password, name, tantargy));
                }
            }
        }
        
        public static User LogIn(List<User> list)
        {
            User user = new User();
            Console.Write("Felhasználónév: ");
            string fnev = Console.ReadLine();
            Console.Write("Jelszó: ");
            string jelszo = Console.ReadLine();
            foreach (var item in list)
            {
                if (item.Username == fnev && item.Password == jelszo)
                {
                    Console.WriteLine("Sikeres bejentkezés!");
                    user = item;
                    return user;
                }
            }
            return user;
        }
    }
}
