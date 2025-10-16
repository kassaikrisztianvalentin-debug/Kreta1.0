using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta1._0
{
    internal class Controller
    {
        private static int index = 0;
        public static int lepeget(string[] menuszoveg)
        {
            var m = Console.ReadKey().Key;
            if (m == ConsoleKey.UpArrow)
            {
                index--;
                if (index < 0) index = menuszoveg.Length - 1;
            }
            else if (m == ConsoleKey.DownArrow)
            {
                index++;
                if (index >= menuszoveg.Length) index = 0;
            }
            return index;
        }
    }
}
