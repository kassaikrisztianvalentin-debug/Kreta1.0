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
        public Tanulo tanuloo = new Tanulo();
        public Tanulo LogIn(string Filepath)
        {
            List<Tanulo> tanuloList = new List<Tanulo>();
            string[] temp = File.ReadAllLines(Filepath);
            foreach (var item in temp)
            {
                string[] d = item.Split(';');
                Tanulo a = new Tanulo(d[0], d[1]);

                tanuloList.Add(a);
            }
            Console.WriteLine("Felhasználónév: ");
            string fnev = Console.ReadLine();
            Console.WriteLine("Jelszó: ");
            string jelszo = Console.ReadLine();
            foreach (var item in tanuloList)
            {
                if (item.Om == fnev && item.Szul_datum == jelszo)
                {
                    tanuloo = item;
                }
            }
            if (tanuloo != null)
            {
                return tanuloo;
            }
            else
            {
                return tanuloo;
            }
        }
    }
}
