#define TRIAL_VERSION
using System;
using SchoolManagement;

//task 1.8
#if TRIAL_VERSION
Console.WriteLine("This is a trial version");
#else
Console.WriteLine("This is a full version");
#endif

Console.WriteLine("Hello Cohort");
//task 1.5
//SchoolManagement.Student student = new SchoolManagement.Student("Sam", 28);
//student.Introduce();


Student student = new Student("Sam", 28);
student.Introduce();
//task 1.6
Console.WriteLine("Starting Programs for different modules");
ModuleA.HelperA.Greet();
ModuleB.HelperB.Greet();

//task 1.7
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

//task 1.9
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


//task 1.10
Console.WriteLine("Enter a number between 0-6 (days of the week): ");
string? input = Console.ReadLine();
if (int.TryParse(input, out int dayNumber) && Enum.IsDefined(typeof(DaysOfWeek), dayNumber))
{
    DaysOfWeek day = (DaysOfWeek)dayNumber;
    Console.WriteLine($"You selected: {day}");

}

// the typeof(daysofweek) is used to get the type of the enum. The enum.isdefined method is used to check if the value is defined in the enum. The enum is casted to the enum type using (daysofweek)daynumber.
else
{
    Console.WriteLine("Invalid input. Please enter a number between 0 and 6.");
}

FilePermission permissions = FilePermission.Read | FilePermission.Execute;
//The Flags attribute tells .net that the enum is intended to represent combinations of bit flags. the | operator does the actual combination.

Console.WriteLine($"Numeric value: {(int)permissions}");
bool canRead = (permissions & FilePermission.Read) != 0;
bool canWrite = (permissions & FilePermission.Write) != 0;
bool canExecute = (permissions & FilePermission.Execute) != 0;

Console.WriteLine($"Can read? {canRead}");
Console.WriteLine($"Can write? {canWrite}");
Console.WriteLine($"can execute? {canExecute}");


//task 1.11
static double ApplyDiscount(double price, double? discount)
{
    double discountPercentage = discount ?? 5.0;
    double discountAmount = price * discountPercentage / 100;
    return price - discountAmount;
}


int? age = 20;
if (age.HasValue)
{
    Console.WriteLine($"Age: {age.Value}");
}
else
{
    Console.WriteLine("Age was not provided");
}

double defaultDiscountPrice = ApplyDiscount(1000, null);
double customDiscountPrice = ApplyDiscount(1000, 10);
Console.WriteLine(defaultDiscountPrice);
Console.WriteLine(customDiscountPrice);


//task 1.12
int numberInt = 10;
long numberLong = numberInt; // Implicit conversion from int to long
float numberFloat = numberLong;
double numberDouble = numberFloat;

Console.WriteLine($"Int: {numberInt}, Long: {numberLong}, Float: {numberFloat}, Double: {numberDouble}");

double originalDouble = 10.5;
int convertedInt = (int)originalDouble;
Console.WriteLine($"Original Double: {originalDouble}, Converted Int: {convertedInt}");

string input1 = "123";
object value = input1;

// is checks the runtime type
if (value is string text)
{
    Console.WriteLine($"is: The value is a string: {text}");
}

// as does a reference-type conversion
object anotherValue = input1;
string? result = anotherValue as string;

Console.WriteLine(
    result is not null
        ? $"as: Conversion succeeded: {result}"
        : "as: Conversion failed.");

// Convert.ToInt32()
int convertedNumber = Convert.ToInt32(input);
Console.WriteLine($"Convert.ToInt32: {convertedNumber}");

// int.TryParse()
if (int.TryParse(input, out int parsedNumber))
{
    Console.WriteLine($"TryParse: Successfully parsed {parsedNumber}");
}
else
{
    Console.WriteLine("TryParse: Input is not a valid integer.");
}


string invalidInput = "hello";

// Convert.ToInt32 throws for non-numeric text.
try
{
    int number = Convert.ToInt32(invalidInput);
    Console.WriteLine(number);
}
catch (FormatException)
{
    Console.WriteLine("Convert.ToInt32: FormatException for 'hello'.");
}

// TryParse returns false instead of throwing for invalid text.
if (int.TryParse(invalidInput, out int invalidNumber))
{
    Console.WriteLine(invalidNumber);
}
else
{
    Console.WriteLine("TryParse: Returned false for 'hello'.");
}


//task 1.13
// Part A: var reassignment — compile-time error
//var number1 = 10;

//we get compile error here because initually number1 is int and now we are assigning it to string.
//number1 = "Hello";

//Console.WriteLine($"var type: {number1.GetType().Name}");

dynamic value1 = "hello";
Console.WriteLine(value1.GetType().Name);

value1 = 15;
Console.WriteLine(value1.GetType().Name);

value1 = true;
Console.WriteLine(value1.GetType().Name);
//This works because dynamic allows variable to reference values of different types.

static dynamic Add(dynamic a, dynamic b)
{
    return a + b;
}
//this method works for both int and string because parameters are dynamic. C# resolves the operation at runtime. 
// This is called runtime binding - operation resolved when the program executes. 
// if we add int and string, it becomes invalid because they cant be added.
Console.WriteLine(Add(10, 20));
Console.WriteLine(Add("Hello", "Akash"));

//task 1.14
int[] numbers1 = { 13, 3, 24, 2, 15 };
(int Min, int Max) result1 = GetMinMax(numbers1);
Console.WriteLine($"Minimum: {result1.Min}, Maximum: {result1.Max}");
//here instead of holding the output in result1 and using Max and Min to get it. We can store the data directly in the min and max variables get it.
(int min, int max) = GetMinMax(numbers1);
Console.WriteLine($"Deconstructed: min = {min}, max = {max}");

(string Name, int Age, string Department) employee = GetEmployee(101);

Console.WriteLine($"Employee: {employee.Name}, {employee.Age}, {employee.Department}");

//deconstructing tuple 
(string name, int age1, string department) = GetEmployee(101);

Console.WriteLine($"Deconstructed: {name}, {age1}, {department}");

static (int Min, int Max) GetMinMax(int[] numbers1)
{

    int min = numbers1[0];
    int max = numbers1[0];

    foreach (int number in numbers1)
    {
        if (number < min)
        {
            min = number;
        }
        if (number > max)
            max = number;
    }
    return (min, max);
}

static (string Name, int Age, string Department) GetEmployee(int id)
{
    if (id == 101)
        return ("Alice", 30, "HR");
    return ("Unknown", 0, "None");
}

//task 1.15
// Pattern matching lets us make decisions based on what a value is, what range it falls into or what properties the object has.
PrintValue(12);
PrintValue("hello");
PrintValue(2.1);
PrintValue(null);
PrintValue(true);

Console.WriteLine($"Score >90: Grade {GetGrade(95)}");
Console.WriteLine($"Score >80: Grade {GetGrade(82)}");
Console.WriteLine($"Score >60: Grade {GetGrade(61)}");
Console.WriteLine($"Score >40: Grade {GetGrade(45)}");
Console.WriteLine($"Score >100: Grade {GetGrade(120)}");


//task 1.16
Student student1 = new Student("2026");
Console.WriteLine(student1.Year);
//student1.Year = 2027 cant do this because readonly fields can only be assigned in the constructor or at the point of declaration. readonly fields cannot be changed after the object is constructed.

Student student2 = new Student(18);
Console.WriteLine($"Year: {student2.Year}, Name: {student2.Name}, Age: {student2.Age}");
student2.DiplaySchoolAddress("xyz school"); //shows const value that cant be changed and assigned during compile time

//This is for type pattern matching. It checks the type of the value and executes the corresponding branch.
static void PrintValue(object? value1)
{
    switch (value1)
    {
        case int number:
            Console.WriteLine($"Integer branch: {number}");
            break;
        case string text:
            Console.WriteLine($"String branch: {text}");
            break;
        case double decimalNumber:
            Console.WriteLine($"Double Branch: {decimalNumber}");
            break;
        case null:
            Console.WriteLine("Null branch: no value");
            break;
        default:
            Console.WriteLine($"Other type branch: {value1.GetType().Name}");
            break;
    }
}

// This is for relational pattern matching. It checks the value against specified ranges and executes the corresponding branch.
static char GetGrade(int score)
{
    return score switch
    {
        < 0 or > 100 => 'X',
        >= 90 => 'A',
        >= 80 => 'B',
        >= 70 => 'C',
        >= 60 => 'D',
        _ => 'F'
    };
}

//property patterns with relational patterns.
static void PrintDiscount(Order order)
{
    decimal discount = order switch
    {// this is property pattern because the status and amount are properties of the object.
        { Status: "Completed", Amount: >= 1000 } => 0.10m,
        { Status: "Completed", Amount: >= 500 } => 0.05m,
        { Status: "Pending" } => 0.00m,
        _ => 0.00m
    };
    Console.WriteLine($"Status: {order.Status}, Amount: {order.Amount:C}, " + $"Discount: {discount:P0}");
}

class Order
{
    public string Status { get; set; } = "";
    public decimal Amount { get; set; }
}

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

    
enum DaysOfWeek
{
    Sunday,
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday
}

[Flags]
enum FilePermission
{
    Read = 1,
    Write = 2,
    Execute = 4
}
