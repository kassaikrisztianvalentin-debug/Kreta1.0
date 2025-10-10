using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta1._0
{
    internal class Tanar
    {
        string nev;
        string tantargy;
        string[] osztalyok;
        DateTime szul_datum;
        int id;
        

        public Tanar()
        {
        }

        public Tanar(string nev, string tantargy, string[] osztalyok, DateTime szul_datum, int id)
        {
            this.nev = nev;
            this.tantargy = tantargy;
            this.osztalyok = osztalyok;
            this.szul_datum = szul_datum;
            this.id = id;
        }

    }
}
