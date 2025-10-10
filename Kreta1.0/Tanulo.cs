using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kreta1._0
{
    internal class Tanulo
    {
        string nev;
        string jelszo;
        string osztaly;
        string szul_datum;
        int id = 0;
        string OM;

        public string Szul_datum { get { return szul_datum; } }
        public string Om { get { return OM; } }

        public Tanulo()
        {
        }

        public Tanulo(string nev, string jelszo, string osztaly, string szul_datum)
        {
            this.nev = nev;
            this.jelszo = jelszo;
            this.osztaly = osztaly;
            this.szul_datum = szul_datum;
            id = id + 1;
        }

        public Tanulo(string nev, string jelszo, string osztaly)
        {
            this.nev = nev;
            this.jelszo = jelszo;
            this.osztaly = osztaly;
            id = id + 1;
        }
  

        public Tanulo(string jelszo, string oM)
        {
            this.jelszo = jelszo;
            OM = oM;
        }
    }
}
