using System;

namespace Studentt
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Major { get; set; }

        public Student(string name, int age, string major)
        {
            Name = name;
            Age = age;
            Major = major;
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Age: {Age}, Major: {Major}");
        }
        class Program
        {
            static void Main(string[] args)
            {
                var students = new List<Student>();
                students.Add(new Student("Alice", 20, "Computer Science"));
                students.Add(new Student("Bob", 21, "Mathematics"));
                students.Add(new Student("Charlie", 19, "Biology"));
                students.Add(new Student("David", 22, "History"));
                students.Add(new Student("Eve", 18, "Art"));

                foreach (var student in students)
                {
                    student.PrintInfo();
                }
            }
        }
    }
}