using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kreta1._0
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Authorization.fileRead("diakok.txt");
            Save.betolt(Tanulo.jegyek);
            bejelentkezes();


            Console.ReadKey();
        }
        public static void bejelentkezes()
        {
            User feka = Authorization.LogIn();
            while (true)
            {
                if (feka.Role == "Tanuló")
                {
                    Menu.menu(feka, Tanulo.tanulomenupontok, Tanulo.parancs, Tanulo.tanulomenupontok.Count);
                    break;
                }
                else if (feka.Role == "Tanár")
                {
                    Menu.menu(feka, Tanar.tanarmenupontok, Tanar.parancs, Tanar.tanarmenupontok.Count);
                    break;
                }
                else
                {
                    Console.WriteLine("Sikertelen bejelentkezés!");
                    feka = Authorization.LogIn();
                }
            }
        }
    }
}
