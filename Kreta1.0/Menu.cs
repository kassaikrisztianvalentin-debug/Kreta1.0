using System;
using System.Collections.Generic;
using System.Reflection;

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
            int index = 0;
            string[] napokHu = new[] { "Hétfő", "Kedd", "Szerda", "Csütörtök", "Péntek" };
            List<Timetable> orak = new List<Timetable>();
            List<Action> orakAction = new List<Action>();
            Console.WriteLine("Óra");
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
                                orak.Add(item);
                            }
                        }
                    }
                }
            }
            Console.WriteLine(orak.Count);

            void Timetablekiiras()
            {
                foreach (var item in napokHu)
                {
                    Console.Write($"{item, -20}");
                }
                Console.WriteLine();
                for (int i = 0; i < orak.Count; i++)
                {
                    if (index == i)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    for (int k = 0; k < 8; k++)
                    {
                        if (i % 8 == 0 || i == 0)
                        {
                            for (int l = 0; l < 4; l++)
                            {
                                Console.Write($"{orak[i + l * 8+k].Subject}({orak[i + l * 8+k].Teacher}, {orak[i + l * 8+k].Terem}, {orak[i + l * 8+k].HourOfDay}:{orak[i + l * 8+k].DayOfWeek})\t");
                            }
                        }
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.White;


            }
            bool beker = true;
            while (beker)
            {
                Console.Clear();
                Timetablekiiras();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        do
                        {
                            index--;
                        } while (orak[index] == null);
                        break;

                    case ConsoleKey.DownArrow:
                        do
                        {
                            index++;
                        } while (orak[index] == null);
                        break;

                    case ConsoleKey.Enter:
                        if (orak[index] != null)
                        {
                            orakAction[index].Invoke();
                            beker = false;
                        }
                        break;
                    default:
                        continue;
                }
            }
        }
    }
}
