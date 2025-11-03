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
                        do
                        {
                            index--;
                            if (index < 0) index = hossz - 1;
                        } while(menuP[index] == null);
                        break;

                    case ConsoleKey.DownArrow:
                        do
                        {
                           index++;
                            if (index >= hossz) index = 0;
                        } while (menuP[index] == null);
                        break;

                    case ConsoleKey.Enter:
                        if (menuP[index] != null)
                        {
                            menuP[index].Invoke();
                            beker = false;
                        }
                        break;
                    default:
                        continue;
                }
            }
        }
        public static void TimetableMenu(string osztaly)
        {
            string[] napokHu = new[] { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek" };
            Console.WriteLine("Óra");
            foreach (var nap in napokHu)
            {
                Console.WriteLine($"{nap, -20}");
            }
            foreach (var item in Timetable.timetable)
            {
                if (item.Osztaly == osztaly)
                {
                    for (int hour = 1; hour <= 8; hour++)
                    {
                        foreach (var day in new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" })
                        {
                            if (item.DayOfWeek == day && item.HourOfDay == hour)
                            {

                            }
                        }
                    }
                }
            }

        }
    }
}
