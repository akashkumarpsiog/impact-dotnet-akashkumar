#define TRIAL_VERSION
using System;
using SchoolManagement;

#if TRIAL_VERSION
Console.WriteLine("This is a trial version");
#else
Console.WriteLine("This is a full version");
#endif

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

int firstNumber = 10;
int secondNumber = firstNumber;
secondNumber = 20;

Console.WriteLine($"firstNumber: {firstNumber}, secondNumber: {secondNumber}");
//int and structs are value types

int[] firstArray = { 1, 2, 3 };
int[] secondArray = firstArray;

secondArray[0] = 99;
Console.WriteLine($"firstArray[0]: {firstArray[0]}, secondArray[0]: {secondArray[0]}");
// arrays are reference types.

CoordinateStruct originalStruct = new CoordinateStruct(10, 20);
CoordinateStruct copiedStruct = originalStruct;

copiedStruct.X = 30;
Console.WriteLine($"originalStruct.X: {originalStruct.X}, copiedStruct.X: {copiedStruct.X}");
//structs are value types.

CoordinateClass originalClass = new CoordinateClass(10, 20);
CoordinateClass copiedClass = originalClass;


copiedClass.X = 30;
Console.WriteLine($"originalClass.X: {originalClass.X}, copiedClass.X: {copiedClass.X}");
//classes are reference types.

struct CoordinateStruct
{
    public int X;
    public int Y;
    public CoordinateStruct(int x, int y)
    {
        X = x;
        Y = y;
    }
}

class CoordinateClass
{
    public int X;
    public int Y;
    public CoordinateClass(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// int and structs copy values; arrays and classes copy references. That is why the integer and struct originals are unchanged.