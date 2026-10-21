using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement
{
    public class Student
    {
        #region Fields
        private int _id;
        #endregion
        #region Properties
        public string Name { get; set; }

        public int Age { get; set; }
        #endregion
        #region Constructors
        public Student (string name, int age)
        {
            Name = name;
            Age = age;
        }
        #endregion
        #region Methods
        public void Introduce()
        {
            Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
        }

        public int GetId()
        {
            return _id;
        }
        #endregion
    }
}

// The # is a preprocessor directive. They dont change what the code does, it helps organize code.