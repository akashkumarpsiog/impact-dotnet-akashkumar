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
