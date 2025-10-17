using System;
using System.Collections.Generic;

namespace Kreta1._0
{
    internal class Menu
    {
        public static void menu(User current, List<string> menutext, List<Action> parancs, int hossz)
        {
            int index = 0;
            List<string> menuT = menutext;
            List<Action> menuP = parancs;

            void menukiiras()
            {
                Console.WriteLine($"Üdv {current.Name}");
                for (int i = 0; i < menuT.Count; i++)
                {
                    if (index == i)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine(menuT[i]);
                }
                Console.ForegroundColor = ConsoleColor.White;
            }

            bool beker = true;
            while (beker)
            {
                Console.Clear();
                menukiiras();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        index--;
                        if (index < 0) index = hossz - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        index++;
                        if (index >= hossz) index = 0;
                        break;

                    case ConsoleKey.Enter:
                        menuP[index].Invoke();
                        beker = false;
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
