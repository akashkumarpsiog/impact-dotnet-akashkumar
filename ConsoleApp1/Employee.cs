using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Employee(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void Display()
        {
            Console.WriteLine($"{Id}: {Name}");
            LogEmployee();
        }
        public partial void LogEmployee();
    }
}
