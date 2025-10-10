using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta1._0
{
    internal class Tantargy
    {
        string nev;
        string TanarNev;
        int[] jegyek;

        public Tantargy()
        {
        }

        public Tantargy(string nev, string tanarNev, int[] jegyek)
        {
            this.nev = nev;
            TanarNev = tanarNev;
            this.jegyek = jegyek;
        }
    }
}
