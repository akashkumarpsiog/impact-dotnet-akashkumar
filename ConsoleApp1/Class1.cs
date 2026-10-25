using SchoolManagement;
using System;
using System.Collections.Generic;
using System.Text;


namespace SchoolManagement
{
    public class Student
    {
        #region Fields
        private int _id;
        private int age;

        private const string state = "Tamil Nadu";
        #endregion
        #region Properties

        public string Name { get; set; }

        public readonly string Year;
        public int Age
        {
            get { return age; }
            set
            {
                if (value < 5 || value > 100)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(Age), "age must be between 5 and 100");
                }
                age = value;
            }
        }
        #endregion
        #region Constructors
        public Student(string name, int age)
        {
            Name = name;
            Age = age;
        }

        //this is an overloaded constructor , it has the same name as the other constructor but it has different parameters.
        public Student(string year)
        {
            Year = year;
        }
        public Student(int age) : this("Akash", age)
        {
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

        public int CalculateGrade(string performance)
        {
            return performance switch
            {
                "excellent" => 90,
                "average" => 75,
                "poor" => 50,
                _ => 40
            };
        }

        public int CalculateGrade(int hoursSpent)
        {
            return hoursSpent switch
            {
                > 10 => 90,
                > 5 => 75,
                _ => 40
            };
        }

        public void DiplaySchoolAddress(string SchoolName)
        {
            Console.WriteLine($"School Name: {SchoolName}, State: {state}");
        }
        #endregion
    }
}

