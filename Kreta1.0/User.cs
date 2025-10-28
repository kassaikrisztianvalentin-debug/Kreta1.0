using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

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
        public static List<Jegy> jegyek = new List<Jegy>();
        public static List<Into> Intok = new List<Into>();
        public static List<string> tanulomenupontok = new List<string>() { "Jegyek ", "Beírások", "Átlag ", "Kijelentkezés", "Kilépés" };
        public List<Action> parancs = new List<Action>();
        public string Osztaly { get; set; }

        public Tanulo(string username, string password, string name, string osztaly)
           : base(username, password, "Tanuló", name)
        {
            parancs.Add(() => Értékelések());
            parancs.Add(() => beirasok());
            parancs.Add(() => atlag());
            parancs.Add(() => Program.bejelentkezes());
            parancs.Add(() =>
            {
                Save.mentes(jegyek);
                Save.mentes(Intok);
                Environment.Exit(0);
            });
            this.Osztaly = osztaly;
        }


        public Tanulo()
        {
        }

        void Értékelések()
        {
            List<string> tantargykiiras = new List<string>();
            List<Action> tantargyparancs = new List<Action>();
            foreach (var item in Authorization.tantagyak)
            {
                tantargykiiras.Add(item);
                tantargyparancs.Add(() => jegyekTantargy(item));
            }
            tantargykiiras.Add("Vissza");
            tantargyparancs.Add(() => Menu.menu(this, Tanulo.tanulomenupontok, this.parancs, Tanulo.tanulomenupontok.Count));
            Menu.menu(this, tantargykiiras, tantargyparancs, tantargyparancs.Count);
        }
        void jegyekTantargy(string tantargy)
        {
            List<string> jegyekkiiras = new List<string>();
            List<Action> jegyekparancs = new List<Action>();
            List<int> atlagList = new List<int>();
            foreach (var item in jegyek)
            {
                if (item.Tantargy == tantargy && item.TanuloNeve == Name)
                {
                    jegyekkiiras.Add($"{item.Tantargy}  -  {item.Datum:d}  -  {item.TanarNeve}  -  {item.Ertek}");
                    jegyekparancs.Add(() => jegyBovebben(item));
                    atlagList.Add(item.Ertek);
                }
            }
            Console.WriteLine();

            jegyekkiiras.Add($"Vissza");
            jegyekparancs.Add(() => Értékelések());
            try
            {
                jegyekkiiras.Add($"Átlag: {atlagList.Average()}");
            }
            catch (System.InvalidOperationException)
            {
                jegyekkiiras.Add($"Átlag: NA");
            }
            Menu.menu(this, jegyekkiiras, jegyekparancs, jegyekparancs.Count);

        }
        void jegyBovebben(Jegy jegy)
        {
            Console.Clear();
            Console.WriteLine($"{jegy.Ertek}\n{jegy.TanarNeve} - {jegy.Tantargy}\n");
            Console.WriteLine($"{jegy.Datum:d}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t\tVissza");
            Console.ForegroundColor = ConsoleColor.White;
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {
                Értékelések();
            }
            else
            {
                Értékelések();
            }
        }
        public double atlag()
        {
            return 1.0;
        }
        void beirasok()
        {
            List<string> beirasok = new List<string>();
            List<Action> beirasokParancs = new List<Action>();
            foreach (var item in Intok)
            {
                if (item.TanuloNeve == Name)
                {
                    beirasok.Add($"{item.TanarNeve} - {item.Datum} - {item.Fokozat} - {item.Szoveg}");
                    beirasokParancs.Add(() => beirasBovebben(item));
                }
            }
            beirasok.Add("Vissza");
            beirasokParancs.Add(() => Menu.menu(this, Tanulo.tanulomenupontok, this.parancs, Tanulo.tanulomenupontok.Count));
            Menu.menu(this, beirasok, beirasokParancs, beirasokParancs.Count);
        }
        void beirasBovebben(Into into)
        {

        }

    }
    public class Tanar : User
    {
        public static List<string> tanarmenupontok = new List<string>(){"Osztályok","Adataim", "Kijelentkezés", "Kilépés"};
        public List<Action> parancs = new List<Action>();
        public string tantargy { get; set; }
        public Tanar(string username, string password, string name, string tantargy)
            : base(username, password, "Tanár", name)
        {
            parancs.Add(() => osztalyok());
            parancs.Add(() => this.ToString());
            parancs.Add(() => Program.bejelentkezes());
            parancs.Add(() =>
            {
                Save.mentes(Tanulo.jegyek);
                Save.mentes(Tanulo.Intok);
                Environment.Exit(0);
            });
            this.tantargy = tantargy;
        }

        void osztalyok()
        {
            List<string> osztalykiiras = new List<string>();
            List<Action> osztalyparancs = new List<Action>();
            foreach (var item in Authorization.osztalyok)
            {
                osztalyparancs.Add(() => tanuloOsztaly(item));
            }
            foreach (var item in Authorization.osztalyok)
            {
                osztalykiiras.Add(item);
            }
            osztalykiiras.Add("Vissza");
            osztalyparancs.Add(() => Menu.menu(this, Tanar.tanarmenupontok, this.parancs, Tanar.tanarmenupontok.Count));
            Menu.menu(this, osztalykiiras, osztalyparancs, osztalyparancs.Count);
        }
        void tanuloOsztaly(string Osztaly)
        {
            List<string> tanuloosztalyszerint = new List<string>();
            List<Action> tanuloosztalyparancs = new List<Action>();
            Console.WriteLine($"{Osztaly} osztály");
            foreach (var item in Authorization.tanuloList)
            {
                if (item.Osztaly == Osztaly)
                {
                    tanuloosztalyszerint.Add(item.Name);
                    tanuloosztalyparancs.Add(() => tanuloFunkciok(item));
                }
            }
            tanuloosztalyszerint.Add("Órarend");
            tanuloosztalyparancs.Add(() => Timetablea(Osztaly));
            tanuloosztalyszerint.Add("Vissza");
            tanuloosztalyparancs.Add(() => osztalyok());
            Menu.menu(this, tanuloosztalyszerint, tanuloosztalyparancs, tanuloosztalyparancs.Count);
        }
        void tanuloFunkciok(Tanulo tanulo)
        {
            List<string> tanulofunkciokkiiras = new List<string>() { "Jegybeírás", "Intő", "Mulasztás", "Jegyek", "Vissza" };
            List<Action> tanulofunkciokparancs = new List<Action>() { () => jegybeiras(tanulo), () => Into(tanulo), () => mulasztas(), () => tanuloJegyek(tanulo),() => osztalyok()};
            Menu.menu(this, tanulofunkciokkiiras, tanulofunkciokparancs, tanulofunkciokparancs.Count);
        }
        void tanuloJegyek(Tanulo tanulo)
        {
            List<string> jegyekkiiras = new List<string>();
            List<Action> jegyekparancs = new List<Action>();
            foreach (var item in Tanulo.jegyek)
            {
                if (item.TanuloNeve == tanulo.Name && item.TanarNeve == Name)
                {
                    jegyekkiiras.Add($"{item.Tantargy}  -  {item.Datum:d}  -  {item.TanarNeve}  -  {item.Ertek}");
                    jegyekparancs.Add(() => jegyFunkciok(item));
                }
            }
            Console.WriteLine();
            jegyekkiiras.Add($"Vissza");
            jegyekparancs.Add(() => osztalyok());
            Menu.menu(this, jegyekkiiras, jegyekparancs, jegyekparancs.Count);
        }
        // static List<Jegy> jegyek = new List<Jegy>();
        #region jegy
        void jegybeiras(Tanulo tanulo)
        {
            Console.Write("Kérem a jegyet (1-5): ");
            int jegy = int.Parse(Console.ReadLine());
            //tanulo.jegyek.Add(new Jegy(this.tantargy ,jegy, DateTime.Now, this.Name, tanulo.Name));
            Tanulo.jegyek.Add(new Jegy(this.tantargy, jegy, DateTime.Now, this.Name, tanulo.Name));
            Console.WriteLine("Sikeres jegybeírás!");
            Thread.Sleep(1000);
            tanuloFunkciok(tanulo);
        }
        void jegyFunkciok(Jegy jegy)
        {
            Console.Clear();
            List<string> jegyFunkciokiiras = new List<string>() { "Jegy módosítása", "Jegy törlése", "Vissza" };
            List<Action> jegyFunkcioparancs = new List<Action>() { () => jegyModositas(jegy), () => jegyTorles(jegy), () => osztalyok() };
            Menu.menu(this, jegyFunkciokiiras, jegyFunkcioparancs, jegyFunkcioparancs.Count);
        }
        void jegyModositas(Jegy jegy)
        {
            Console.Write("Kérem az új jegyet (1-5): ");
            int ujJegy = int.Parse(Console.ReadLine());
            jegy.Ertek = ujJegy;
            Console.WriteLine("Sikeres jegymódosítás!");
            Thread.Sleep(1000);
            osztalyok();
        }
        void jegyTorles(Jegy jegy)
        {
            Tanulo.jegyek.Remove(jegy);
            Tanulo.jegyek.Remove(jegy);
            Console.WriteLine("Sikeres jegytörlés!");
            Thread.Sleep(1000);
            osztalyok();
        }
#endregion

        void mulasztas()
        {
            //mulasztás beírás logika
        }
        #region into
        void Into(Tanulo tanulo)
        {
            List<string> intokkiiras = new List<string>() { "Beírás", "Tanuló intői", "Vissza"};
            List<Action> intokparancs = new List<Action>() { () => Intobeiras(tanulo), () =>  IntoKiiras(tanulo), () => tanuloFunkciok(tanulo)};
            Menu.menu(this, intokkiiras, intokparancs, intokparancs.Count);
        }
        void Intobeiras(Tanulo tanulo)
        {
            Console.Clear();
            string[] intok = new string[] { "Szóbeli intő", "Osztályfőnöki intő", "Szakmai tanári intő", "Igazgatói intő", "Igazgatói megrovás" };
            Console.WriteLine("1. Szóbeli intő\n2. Osztályfőnöki intő\n3. Szakmai tanári intő\n4. Igazgatói intő\n5. Igazgatói megrovás");
            int beInto = int.Parse(Console.ReadLine());
            Console.Write("A beírás szövege: ");
            string szoveg = Console.ReadLine();
            Tanulo.Intok.Add(new Into(this.Name, tanulo.Name, DateTime.Now, szoveg, intok[beInto - 1]));
            Console.WriteLine("Sikeres rögzítés!");
            Thread.Sleep(1000);
            osztalyok();
        }
        void IntoKiiras(Tanulo tanulo)
        {
            List<string> intokkiirasstring = new List<string>();
            List<Action> intokparancs = new List<Action>();
            foreach (var item in Tanulo.Intok)
            {
                if (item.TanuloNeve == tanulo.Name && item.TanarNeve == Name)
                {
                    intokkiirasstring.Add($"{item.TanarNeve} - {item.Datum} - {item.Fokozat} - {item.Szoveg}");
                    intokparancs.Add(() => intoFunkciok(item));
                }
            }
            intokkiirasstring.Add("Vissza");
            intokparancs.Add(() => tanuloFunkciok(tanulo));
            Menu.menu(this, intokkiirasstring, intokparancs, intokparancs.Count);
        }
        void intoFunkciok(Into into)
        {
            Console.Clear();
            List<string> jegyFunkciokiiras = new List<string>() { "Jegy módosítása", "Jegy törlése", "Vissza" };
            List<Action> jegyFunkcioparancs = new List<Action>() { () => intoModositas(into), () => intoTorles(into), () => osztalyok() };
            Menu.menu(this, jegyFunkciokiiras, jegyFunkcioparancs, jegyFunkcioparancs.Count);
        }
        void intoModositas(Into into)
        {
            string[] intok = new string[] { "Szóbeli intő", "Osztályfőnöki intő", "Szakmai tanári intő", "Igazgatói intő", "Igazgatói megrovás" };
            Console.WriteLine("1. Szóbeli intő\n2. Osztályfőnöki intő\n3. Szakmai tanári intő\n4. Igazgatói intő\n5. Igazgatói megrovás");
            int beInto = int.Parse(Console.ReadLine());
            into.Fokozat = intok[beInto-1];
            Console.Write("Szöveg: ");
            string szoveg = Console.ReadLine();
            into.Fokozat = szoveg;
            Console.WriteLine("Sikeres jegymódosítás!");
            Thread.Sleep(1000);
            osztalyok();
        }
        void intoTorles(Into into)
        {
            Tanulo.Intok.Remove(into);
            Tanulo.Intok.Remove(into);
            Console.WriteLine("Sikeres jegytörlés!");
            Thread.Sleep(1000);
            osztalyok();
        }
        #endregion
        void Timetablea(string osztaly)
        {
            Timetable.CreateTimetable();
            List<string> timetablestring = new List<string>();
            List<Action> timetableparancs = new List<Action>();
            string[] napokHu = new[] { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek" };
            Console.Write("Óra", 5);

            foreach (var nap in napokHu)
            {
                Console.WriteLine($"{nap, -20}");
            }
            for (int i = 0; i < 50; i++)
            {
                Console.Write("-");
            }
            foreach (var item in Timetable.timetable)
            {
                if (item.Osztaly == osztaly)
                {
                    foreach (var day in new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" })
                    {
                        for (int hour = 1; hour <= 8; hour++)
                        {
                            if (item.DayOfWeek == day && item.HourOfDay == hour)
                            {
                                timetablestring.Add($"{hour}{item.Teacher}\n{item.Osztaly}\n{item.DayOfWeek}:{item.HourOfDay}\n{item.Terem}\n{item.Subject}");
                                timetableparancs.Add(() => Timetablea(osztaly));
                            }
                        }
                    }
                }
            }
            Menu.menu(this, timetablestring, timetableparancs, timetableparancs.Count);
        }
        public override string ToString()
        {
            return $"Név: {Name}\nFelhasználónév: {Username}\nJelszó: {Password}Tantárgy: {tantargy}";
        }
    }
}
