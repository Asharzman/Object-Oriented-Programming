using System.Collections.Generic;
using System.Reflection;

namespace Employee_Data
{
    public class Employee
    {
        public Employee() 
        {
            Management = false;
            Name = "";
            Profession = "";
            Salary = 0;
            Car = "";
            Bonus = 0;
        }
        public bool Management { get; set; }
        public string Name { get; set; }
        public string Profession { get; set;}
        public float Salary { get; set;}
        public string Car { get; set;}
        public float Bonus { get; set;}

    }
    public class Employee_Handler
    {
        string[] check = { "exit", "q", "e", "quit" };
        public List<Employee> employees = new List<Employee>
        {
            new Employee { Management = true, Name = "Big Boss", Profession = "Big Boss", Salary = 5000, Car = "Ford Focus", Bonus = 700 },
            new Employee { Management = false, Name ="John Rieper", Profession = "Janitor", Salary = 1500},
            new Employee { Management = false, Name ="Jane Schmitt", Profession = "Secretary", Salary = 2700 }
        };
        public void ReadData()
        {
            foreach (Employee emp in employees)
            {
                if (emp.Management == true)
                {
                    Console.WriteLine($"Name: {emp.Name} Profession: {emp.Profession} Salary: {emp.Salary} Car: {emp.Car} Bonus: {emp.Bonus}");
                }
                else
                {
                    Console.WriteLine($"Name: {emp.Name} Profession: {emp.Profession} Salary: {emp.Salary}");
                }
            }
        }
        public void EditData()
        {
            Console.WriteLine("Select the employee whose details you want to edit.");
            Console.WriteLine($"Type 1 to edit {employees[0].Name}, 2 to edit {employees[1].Name}, 3 to edit {employees[2].Name}.");
            Console.WriteLine("Type exit to return to previous menu.");
            while (true)
            {
                string input = Console.ReadLine();
                bool isint = int.TryParse(input, out int value);
                if (check.Contains(input.ToLower()))
                {
                    { break; }
                }
                if (isint == true)
                {
                    value = value - 1;
                    if (employees.ElementAtOrDefault(value) != null)
                    {
                        Console.WriteLine($"You have chosen to edit {employees[value].Name}'s details.");
                        if (employees[value].Management == true)
                        {
                            Console.WriteLine($"Type new name for {employees[value].Name}.");
                            string newname = Console.ReadLine();
                            if (newname != "")
                            {
                                employees[value].Name = newname;
                            }
                            Console.WriteLine($"Type new profession for {employees[value].Name}.");
                            string newprofession = Console.ReadLine();
                            if (newprofession != "")
                            {
                                employees[value].Profession = newprofession;
                            }
                            Console.WriteLine($"Type new salary for {employees[value].Name}.");
                            while (true)
                            {
                                string newsalary = Console.ReadLine();
                                bool salaryint = int.TryParse(newsalary, out int newsalaryvalue);
                                if (salaryint == true)
                                {
                                    employees[value].Salary = newsalaryvalue;
                                    { break; }
                                }
                                else
                                {
                                    Console.WriteLine("Please give an integer.");
                                }
                            }
                            Console.WriteLine($"Type new car for {employees[value].Name}.");
                            string newcar = Console.ReadLine();
                            if (newcar != "")
                            {
                                employees[value].Car = newcar;
                            }
                            Console.WriteLine($"Type new bonus for {employees[value].Name}.");
                            while (true)
                            {
                                string newbonus = Console.ReadLine();
                                bool bonusint = int.TryParse(newbonus, out int newbonusvalue);
                                if (bonusint == true)
                                {
                                    employees[value].Bonus = newbonusvalue;
                                    { break; }
                                }
                                else
                                {
                                    Console.WriteLine("Please give an integer.");
                                }
                            }
                            Console.WriteLine($"Successfully finished editing {employees[value].Name}'s details!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            { break; }

                        }
                        else
                        {
                            Console.WriteLine($"Type new name for {employees[value].Name}.");
                            string newname = Console.ReadLine();
                            if (newname != "")
                            {
                                employees[value].Name = newname;
                            }
                            Console.WriteLine($"Type new profession for {employees[value].Name}.");
                            string newprofession = Console.ReadLine();
                            if (newprofession != "")
                            {
                                employees[value].Profession = newprofession;
                            }
                            Console.WriteLine($"Type new salary for {employees[value].Name}.");
                            while (true)
                            {
                                string newsalary = Console.ReadLine();
                                bool salaryint = int.TryParse(newsalary, out int newsalaryvalue);
                                if (salaryint == true)
                                {
                                    employees[value].Salary = newsalaryvalue;
                                    { break; }
                                }
                                else
                                {
                                    Console.WriteLine("Please give an integer.");
                                }
                            }
                            Console.WriteLine($"Successfully finished editing {employees[value].Name}'s details!");
                            System.Threading.Thread.Sleep(1000);
                            Console.Clear();
                            { break; }

                        }
                    }
                    else
                    {
                        Console.WriteLine("There is no employee assigned to your chosen number. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid option.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee_Handler handler = new Employee_Handler();
            string[] check = { "exit", "q", "e", "quit" };
            while (true)
            {
                Console.WriteLine(" ___              _                                                                         _   \r\n| __>._ _ _  ___ | | ___  _ _  ___  ___  ._ _ _  ___ ._ _  ___  ___  ___ ._ _ _  ___ ._ _ _| |_ \r\n| _> | ' ' || . \\| |/ . \\| | |/ ._>/ ._> | ' ' |<_> || ' |<_> |/ . |/ ._>| ' ' |/ ._>| ' | | |  \r\n|___>|_|_|_||  _/|_|\\___/`_. |\\___.\\___. |_|_|_|<___||_|_|<___|\\_. |\\___.|_|_|_|\\___.|_|_| |_|  \r\n            |_|          <___'                                 <___'                           ");
                Console.WriteLine("Current employee details:");
                handler.ReadData();
                Console.WriteLine("\nCurrent options:");
                Console.WriteLine("Type 1 to access employeer editor. Type 'exit' 'q' 'e' or 'quit' to exit program.");
                string input = Console.ReadLine();
                if (check.Contains(input.ToLower())) 
                {
                    { break; }
                }
                if (input == "1")
                {
                    handler.EditData(); 
                }
                else
                {
                    Console.WriteLine("Invalid command.");
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }

            }
        }
    }
}