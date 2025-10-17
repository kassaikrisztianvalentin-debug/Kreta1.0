using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta1._0
{
    internal class Save
    {
        public static void mentes(List<Jegy> jegyek)
        {
            StreamWriter sw = new StreamWriter("jegyek.txt");
            foreach (var item in jegyek)
            {
                sw.WriteLine($"{item.Tantargy};{item.Ertek};{item.Datum};{item.TanarNeve};{item.TanuloNeve}");
            }
            sw.Close();
            Environment.Exit(0);
        }
        // Filepath
        public static void betolt(List<Jegy> jegyek)
        {
            if (File.Exists("jegyek.txt"))
            {
                string[] temp = File.ReadAllLines("jegyek.txt");
                foreach (var item in temp)
                {
                    string[] d = item.Split(';');
                    string tantargy = d[0];
                    int ertek = int.Parse(d[1]);
                    DateTime datum = DateTime.Parse(d[2]);
                    string tanarNeve = d[3];
                    string tanuloNeve = d[4];
                    jegyek.Add(new Jegy(tantargy, ertek, datum, tanarNeve, tanuloNeve));
                }
            }
        }
    }
}
