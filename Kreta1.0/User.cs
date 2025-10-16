using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta1._0
{
    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; }
        public string Role { get; protected set; }

        public User(string username, string password, string role, string name)
        {
            Username = username;
            Password = password;
            Role = role;
            Name = name;
        }

        public User()
        {
        }
    }
    public class Tanulo : User
    {
        List<int> jegyek = new List<int>();
        public static List<string> tanulomenupontok = new List<string>() { "Jegyek ", "Átlag ", "Kilépés " };
        public static List<Action> parancs = new List<Action>();
        public string Osztaly { get; set; }
        public Tanulo(string username, string password, string name, string osztaly)
             : base(username, password, "Tanuló", name)
        {
            parancs.Add(() => Jegykiiras());
            parancs.Add(() => atlag());
            parancs.Add(() => Authorization.LogIn(Authorization.userList));
            this.Osztaly = osztaly;
        }
        void Jegykiiras()
        {
            foreach (var item in jegyek)
            {
                Console.WriteLine(item);
            }
        }
        void Jegybeiras(int jegy, string tantargy)
        {
            jegyek.Add(jegy);
        }

        public double atlag()
        {
            return jegyek.Average();
        }

    }
    public class Tanar : User
    {
        public static List<string> tanarmenupontok = new List<string>(){"Osztályok","Adataim","Kijelentkezés"};
        public static List<Action> parancs = new List<Action>();
        string tantargy;
        public Tanar(string username, string password, string name, string tantargy)
            : base(username, password, "Tanár", name)
        {
            parancs.Add(() => osztalyok());
            parancs.Add(() => this.ToString());
            parancs.Add(() => Authorization.LogIn(Authorization.userList));
        }
        void osztalyok()
        {
            List<string> osztalykiiras = new List<string>();
            var groupbyOsztaly = Authorization.tanuloList.GroupBy(x => x.Osztaly);
            List<Action> osztalyparancs = new List<Action>();
            foreach (var item in Authorization.osztalyok)
            {
                osztalyparancs.Add(() => tanuloOsztaly(item));
            }
            foreach (var item in Authorization.osztalyok)
            {
                osztalykiiras.Add(item);
            }
            Menu.menu(this, osztalykiiras, osztalyparancs);
        }
        void tanuloOsztaly(string osztaly)
        {

        }
        public override string ToString()
        {
            return $"Név: {Name}\nFelhasználónév: {Username}\nJelszó: {Password}Tantárgy: {tantargy}";
        }
    }
}
