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
            User feka = Authorization.LogIn(Authorization.userList);
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
                    Menu.menu(feka, Tanar.tanarmenupontok, Tanar.parancs);
                    break;
                }
                else
                {
                    Console.WriteLine("Sikertelen bejelentkezés!");
                    feka = Authorization.LogIn(Authorization.userList);
                }
            }
            

            Console.ReadKey();
        }
    }
}
