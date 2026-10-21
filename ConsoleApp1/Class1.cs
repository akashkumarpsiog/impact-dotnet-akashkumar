using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement
{
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public Student (string name, int age)
        {
            Name = name;
            Age = age;
        }
        
        public void Introduce()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }
    }
}
