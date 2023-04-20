using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniPeppi
{
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string SID { get; set; }
            public string Group { get; set; }

            public Student(string firstName, string lastName, string sid, string group)
            {
                FirstName = firstName;
                LastName = lastName;
                SID = sid;
                Group = group;
            }

            public override string ToString()
            {
                return FirstName + " " + LastName + " " + SID + " " + Group;
            }
        }
        class Peppi
        {
        public void UsePeppi()
        {
            List<Student> students = new List<Student>
                {
                    new Student("Hanna", "Husso", "HH001", "TTV19S1"),
                    new Student("Kirsi", "Kernel", "KK002", "TTV19S2"),
                    new Student("Masa", "Niemi", "MN003", "TTV19S3"),
                    new Student("Teppo", "Tester", "TT004", "TTV19SM"),
                    new Student("Allan", "Aalto", "AA005", "TTV19SMM")
                };

            Console.WriteLine("MiniPeppi Program");
            Console.WriteLine("-----------------");

            while (true)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add student");
                Console.WriteLine("2. Delete student");
                Console.WriteLine("3. Search student");
                Console.WriteLine("4. List all students");
                Console.WriteLine("5. List all students in alphabetical order");
                Console.WriteLine("6. Exit");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AddStudent(students);
                        break;
                    case 2:
                        DeleteStudent(students);
                        break;
                    case 3:
                        SearchStudent(students);
                        break;
                    case 4:
                        ListAllStudents(students);
                        break;
                    case 5:
                        ListAllStudentsInOrder(students);
                        break;
                    case 6:
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice, try again.");
                        break;
                }

            }
        }
                static void AddStudent(List<Student> students)
                {
                    Console.WriteLine("\nAdding a new student:");

                    Console.Write("Enter SID: ");
                    string sid = Console.ReadLine();

                    foreach (Student s in students)
                    {
                        if (s.SID == sid)
                        {
                            Console.WriteLine("Error: Student with the same SID already exists.");
                            return;
                        }
                    }

                    Console.Write("Enter first name: ");
                    string firstName = Console.ReadLine();

                    Console.Write("Enter last name: ");
                    string lastName = Console.ReadLine();

                    Console.Write("Enter group: ");
                    string group = Console.ReadLine();

                    students.Add(new Student(firstName, lastName, sid, group));
                    Console.WriteLine("Student added successfully.");
                    Console.WriteLine("There are now {0} students in MiniPeppi.", students.Count);
                }

                static void DeleteStudent(List<Student> students)
                {
                    Console.WriteLine("\nDeleting a student:");

                    Console.Write("Enter SID: ");
                    string sid = Console.ReadLine();

                    int index = -1;

                    for (int i = 0; i < students.Count; i++)
                    {
                        if (students[i].SID == sid)
                        {
                            index = i;
                            break;
                        }
                    }

                    if (index == -1)
                    {
                        Console.WriteLine("Error: Student not found.");
                        return;
                    }

                    Console.WriteLine("Are you sure you want to delete {0}?", students[index]);
                    Console.Write("Enter Y/N: ");
                    string answer = Console.ReadLine();

                    if (answer.ToLower() == "y")
                    {
                        students.RemoveAt(index);
                        Console.WriteLine("Student deleted successfully.");
                        Console.WriteLine("There are now {0} students in MiniPeppi.", students.Count);
                    }
                    else
                    {
                        Console.WriteLine("Deletion cancelled.");
                    }
                }

                static void SearchStudent(List<Student> students)
                {
                    Console.WriteLine("\nSearching for a student:");

                    Console.Write("Enter SID: ");
                    string sid = Console.ReadLine();

                    foreach (Student s in students)
                    {
                        if (s.SID == sid)
                        {
                            Console.WriteLine(s);
                            return;
                        }
                    }

                    Console.WriteLine("Error: Student not found.");
                }

                static void ListAllStudents(List<Student> students)
                {
                    Console.WriteLine("\nAll students:");

                    foreach (Student s in students)
                    {
                        Console.WriteLine(s);
                    }

                    Console.WriteLine("There are {0} students in MiniPeppi.", students.Count);
                }

                static void ListAllStudentsInOrder(List<Student> students)
                {
                    Console.WriteLine("\nAll students in alphabetical order:");

                    students.Sort((s1, s2) => s1.LastName.CompareTo(s2.LastName));

                    foreach (Student s in students)
                    {
                        Console.WriteLine(s.FirstName + " " + s.LastName);
                    }
                }
            
        }

        class Program
        {
            static void Main(string[] args)
            {
                Peppi pep = new Peppi();
                pep.UsePeppi();
            }
        }
 }