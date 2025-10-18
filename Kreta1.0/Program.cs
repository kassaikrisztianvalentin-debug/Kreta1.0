﻿using System;
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
            Save.betolt("jegyek.txt");
            bejelentkezes();


            Console.ReadKey();
        }
        public static void bejelentkezes()
        {
            User feka = null;

            while (feka == null)
            {
                feka = Authorization.LogIn();

                if (feka == null)
                {
                    continue;
                }

                if (feka.Role == "Tanuló")
                {
                    Tanulo tanulo = feka as Tanulo;
                    if (tanulo != null)
                    {
                        Menu.menu(tanulo, Tanulo.tanulomenupontok, tanulo.parancs, Tanulo.tanulomenupontok.Count);
                    }
                    else
                    {
                        Console.WriteLine("Hiba: A felhasználó nem Tanuló típusú.");
                    }
                }
                else if (feka.Role == "Tanár")
                {
                    Tanar tanar = feka as Tanar;
                    if (tanar != null)
                    {
                        Menu.menu(feka, Tanar.tanarmenupontok, tanar.parancs, Tanar.tanarmenupontok.Count);
                    }
                    else
                    {
                        Console.WriteLine("Hiba: A felhasználó nem Tanár típusú.");
                    }
                }
                else
                {
                    Console.WriteLine("Ismeretlen szerepkör!");
                    feka = null;
                }
            }
        }
    }
}
