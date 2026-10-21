using SchoolManagement;
Console.WriteLine("Hello Cohort");

//SchoolManagement.Student student = new SchoolManagement.Student("Sam", 28);
//student.Introduce();


Student student = new Student("Sam", 28);
student.Introduce();

Console.WriteLine("Starting Programs for different modules");
ModuleA.HelperA.Greet();
ModuleB.HelperB.Greet();