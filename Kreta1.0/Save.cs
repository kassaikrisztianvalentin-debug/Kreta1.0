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
        public static void mentes<T>(List<T> lista)
        {
            string fileName = typeof(T) == typeof(Jegy) ? "jegyek.txt" : "intok.txt";
            bool fileType = typeof(T) == typeof(Jegy);
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (var item in lista)
                {
                    if (item is Jegy jegy)
                    {
                        sw.WriteLine($"{jegy.Tantargy};{jegy.Ertek};{jegy.Datum};{jegy.TanarNeve};{jegy.TanuloNeve}");
                    }
                    else if (item is Into into)
                    {
                        sw.WriteLine($"{into.TanarNeve};{into.TanuloNeve};{into.Datum};{into.Szoveg};{into.Fokozat}");
                    }
                }
            }
        }

        public static void betolt(string Filepath)
        {
            if (File.Exists(Filepath))
            {
                string[] temp = File.ReadAllLines(Filepath);
                foreach (var item in temp)
                {
                    if (Filepath == "jegyek.txt")
                    {
                        string[] d = item.Split(';');
                        string tantargy = d[0];
                        int ertek = int.Parse(d[1]);
                        DateTime datum = DateTime.Parse(d[2]);
                        string tanarNeve = d[3];
                        string tanuloNeve = d[4];
                        Tanulo.jegyek.Add(new Jegy(tantargy, ertek, datum, tanarNeve, tanuloNeve));
                    }
                    else if (Filepath == "intok.txt")
                    {
                        string[] d = item.Split(';');
                        string tanarNeve = d[0];
                        string tanuloNeve = d[1];
                        DateTime datum = DateTime.Parse(d[2]);
                        string szoveg = d[3];
                        string fokozat = d[4];
                        Tanulo.Intok.Add(new Into(tanarNeve, tanuloNeve, datum, szoveg, fokozat));
                    }
                }
            }
        }
    }
}
