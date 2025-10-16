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
        public static string[] tanulomenupontok = { "Jegyek ", "Átlag ", "Kilépés " };
        public static Action[] parancs;
        public string Osztaly { get; set; }
        public Tanulo(string username, string password, string name, string osztaly)
             : base(username, password, "Tanuló", name)
        {
            parancs = new Action[] { () => Jegykiiras() , () => atlag(), () => Authorization.LogIn("belepesiAdat.txt") };
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
        public static string[] menupontok = { "Osztályok", "Adataim", "Kijelentkezés" };
        public static Action[] parancs;
        string tantargy;
        public Tanar(string username, string password, string name, string tantargy)
            : base(username, password, "Tanár", name)
        {
            parancs = new Action[] {() => osztalyok(),  };
        }
        void osztalyok()
        {

        }
        public override string ToString()
        {
            return $"Név: {Name}\nFelhasználónév: {Username}\nJelszó: {Password}Tantárgy: {tantargy}";
        }
    }
}
