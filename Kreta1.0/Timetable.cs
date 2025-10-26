using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta1._0
{
    internal class Timetable
    {
        public string Osztaly { get; set; }
        public string DayOfWeek { get; set; }
        public string Subject { get; set; }
        public string HourOfDay { get; set; }
        public string Teacher { get; set; }
        public Timetable(string osztaly, string dayOfWeek, string subject, string hourofday, string teacher)
        {
            Osztaly = osztaly;
            DayOfWeek = dayOfWeek;
            Subject = subject;
            HourOfDay = hourofday;
            Teacher = teacher;
        }

        public static void CreateTimetable()
        {
            List<Timetable> timetable = new List<Timetable>();
            Random rnd = new Random();
            foreach (var osztaly in Authorization.osztalyok)
            {
                foreach (var day in new[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" })
                {
                    for (int hour = 1; hour <= 8; hour++)
                    {
                        Tanar randomTeacher = Authorization.tanarList[rnd.Next(0, Authorization.tanarList.Count)];
                        string subject = randomTeacher.tantargy; 
                        string teacher = randomTeacher.ToString();

                        timetable.Add(new Timetable(osztaly, day, subject, hour.ToString(), teacher));
                    }
                }
            }
        }
    }
}
