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
            User feka = Authorization.LogIn("diakok.txt");
            Console.WriteLine(feka.Role);
            while (true)
            {
                if (feka.Role == "Tanuló")
                {
                    Menu.menu(feka, Tanulo.tanulomenupontok, Tanulo.parancs);
                    break;
                }
                else if (feka.Role == "Tanár")
                {
                    Menu.menu(feka, Tanar.menupontok, Tanar.parancs);
                    break;
                }
                else
                {
                    Console.WriteLine("Sikertelen bejelentkezés!");
                    feka = Authorization.LogIn("diakok.txt");
                }
            }
            

            Console.ReadKey();
        }
    }
}
