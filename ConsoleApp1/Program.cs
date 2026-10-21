using SchoolManagement;
Console.WriteLine("Hello Cohort");

//SchoolManagement.Student student = new SchoolManagement.Student("Sam", 28);
//student.Introduce();


Student student = new Student("Sam", 28);
student.Introduce();

Console.WriteLine("Starting Programs for different modules");
ModuleA.HelperA.Greet();
ModuleB.HelperB.Greet();


string studentName = "Sam";
int studentAge = 28;
double examScore = 97.5;
bool isEnrolled = true;
decimal tuitionFee = 15000.00m;
int @class = 1;

void ImCool()
{
    Console.WriteLine("Im Cool");
}

ImCool();
Console.WriteLine(studentName);
Console.WriteLine(studentAge);
Console.WriteLine(examScore);
Console.WriteLine(isEnrolled);
Console.WriteLine(tuitionFee);
Console.WriteLine(@class);