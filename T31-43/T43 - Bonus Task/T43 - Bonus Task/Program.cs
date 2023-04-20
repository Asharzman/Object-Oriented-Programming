using Microsoft.VisualBasic;
using System.Globalization;

namespace Bonus
{
    public class Person
    {
        public string Initials { get; set; }
        public List<WorkingDay> WorkingDays { get; set; }

        public Person(string initials)
        {
            Initials = initials;
            WorkingDays = new List<WorkingDay>();
        }

        public void AddWorkingDay(DateTime date, string projectId, double hours)
        {
            WorkingDay day = new WorkingDay(date, projectId, hours);
            WorkingDays.Add(day);
        }

        public double GetTotalHours()
        {
            return WorkingDays.Sum(day => day.Hours);
        }

        public double GetHoursForProject(string projectId)
        {
            return WorkingDays.Where(day => day.ProjectId == projectId).Sum(day => day.Hours);
        }
    }
    public class WorkingDay
    {
        public DateTime Date { get; set; }
        public string ProjectId { get; set; }
        public double Hours { get; set; }

        public WorkingDay(DateTime date, string projectId, double hours)
        {
            Date = date;
            ProjectId = projectId;
            Hours = hours;
        }
    }
    public class WorkingHoursTracker
    {
        public List<Person> People { get; set; }

        public WorkingHoursTracker()
        {
            People = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            People.Add(person);
        }
        public Person FindPerson(string initials)
        {
            foreach (Person person in People)
            {
                if (person.Initials == initials)
                {
                    return person;
                }
            }

            return null;
        }

        public void AddWorkingDay(string initials, DateTime date, string projectId, double hours)
        {
            Person person = People.FirstOrDefault(p => p.Initials == initials);
            if (person != null)
            {
                person.AddWorkingDay(date, projectId, hours);
            }
        }

        public double GetTotalHoursForPerson(string initials)
        {
            Person person = People.FirstOrDefault(p => p.Initials == initials);
            if (person != null)
            {
                return person.GetTotalHours();
            }
            return 0;
        }

        public double GetHoursForProject(string projectId)
        {
            return People.Sum(person => person.GetHoursForProject(projectId));
        }
        public void SaveToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Person person in People)
                {
                    writer.WriteLine(person.Initials);
                    foreach (WorkingDay day in person.WorkingDays)
                    {
                        writer.WriteLine("{0},{1},{2}", day.Date, day.ProjectId, day.Hours);
                    }
                    writer.WriteLine("TOTAL HOURS: {0}", person.GetTotalHours());
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            WorkingHoursTracker tracker = new WorkingHoursTracker();
            Person bb = new Person("BB");
            Person ryan = new Person("RY");
            Person charlie = new Person("CH");
            DateTime date1 = new DateTime(1995, 7, 1);
            DateTime date2 = new DateTime(1985, 12, 31);
            DateTime date3 = new DateTime(2005, 7, 1);
            DateTime date4 = new DateTime(2023, 4, 20);
            tracker.AddPerson(bb);
            tracker.AddPerson(ryan);
            tracker.AddPerson(charlie);
            tracker.AddWorkingDay("BB", date1, "Webpage", 42);
            tracker.AddWorkingDay("BB", date3, "System", 108);
            tracker.AddWorkingDay("RY", date1, "System", 96);
            tracker.AddWorkingDay("CH", date4, "FrontEnd", 1);

            while (true)
            {
                Console.WriteLine("Enter person's initials (or type 'done' to finish adding):");
                string initials = Console.ReadLine().ToUpper();
                if (initials == "DONE")
                {
                    break;
                }

                Console.WriteLine("Enter date (format yyyy-mm-dd):");
                DateTime date = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter project ID:");
                string projectId = Console.ReadLine().ToUpper();

                Console.WriteLine("Enter number of hours worked (decimal format allowed):");
                double hoursWorked = double.Parse(Console.ReadLine());

                Person person = tracker.FindPerson(initials);
                if (person != null)
                {
                    person.AddWorkingDay(date, projectId, hoursWorked);
                }
                else
                {
                    Console.WriteLine("Invalid initials. Please try again.");
                }
            }

            tracker.SaveToFile("working_hours.txt");

            Console.WriteLine("HOURS BY PERSON:\n");
            Console.WriteLine("BIG BOSS: {0}", tracker.GetTotalHoursForPerson("BB"));
            Console.WriteLine("RYAN: {0}", tracker.GetTotalHoursForPerson("RY"));
            Console.WriteLine("CHARLIE: {0}", tracker.GetTotalHoursForPerson("CH"));
            Console.WriteLine("\n");
            Console.WriteLine("HOURS BY PROJECT:\n");
            Console.WriteLine("Webpage: {0}", tracker.GetHoursForProject("Webpage"));
            Console.WriteLine("System: {0}", tracker.GetHoursForProject("System"));
            Console.WriteLine("FrontEnd: {0}", tracker.GetHoursForProject("FrontEnd"));

            Console.ReadLine();
        }
    }
}
