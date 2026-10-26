# Phase 1 — C# Learning Notes

## 1. C# and .NET Fundamentals
- **C#** is the language; **.NET** provides the runtime, libraries, SDK, and tools.
- **SDK vs runtime:** SDK builds projects; runtime executes applications.
- `dotnet --info` shows environment details; `dotnet --list-sdks` and `dotnet --list-runtimes` list installed SDKs and runtimes.
- `.csproj` defines a project, including target framework/dependencies. `.sln`/`.slnx` groups projects.
- A namespace organizes types and avoids naming conflicts: `namespace ProductCatalog { ... }`.
- Use meaningful identifiers; conventional naming is PascalCase for types/methods and camelCase for locals/parameters.
- Preprocessor directives (`#if`, `#else`, `#endif`) control compilation; they are not runtime `if` statements.

## 2. Value Types and Reference Types
- **Value types:** assignment copies the value. Examples: `int`, `long`, `float`, `double`, `decimal`, `bool`, `char`, `struct`, `enum`.
- **Reference types:** assignment copies a reference, so variables may refer to the same object. Examples: `class`, `string`, arrays, interfaces, delegates, `object`.
- `struct` is a value type; `string` is a reference type. Strings are **immutable**: reassignment does not modify the original string object.
- `object` is the base type of all C# types. **Boxing** wraps a value type as an object; **unboxing** extracts it.
- Nullable value types such as `int?` can hold `null`; nullable reference annotations such as `string?` indicate a reference may be null.
```csharp
int a = 10;
int b = a;
b = 20; // a remains 10
var first = new Person();
var second = first; // both references point to the same object
```

## 3. Types, Conversions, and Pattern Matching
- **Implicit conversion** needs no cast, e.g. `int` to `long`; some conversions can still lose precision, e.g. `long` to `float`.
- **Explicit conversion** uses a cast when information may be lost: `int whole = (int)3.9; // 3`.
- `int.Parse("42")` parses valid input and throws on invalid input; `int.TryParse(text, out int value)` handles invalid input without throwing; `Convert.ToInt32` converts supported input.
- `var` infers a static compile-time type; `dynamic` defers member/type checks until runtime.
- `is` checks type/pattern: `if (value is string text)`. The `text` variable is available when the pattern succeeds.
- `as` attempts a compatible reference/nullable conversion and returns `null` on failure; it does not perform general numeric conversions.
- Pattern matching can check types, values, ranges, and properties to simplify conditional logic.

## 4. Tuples, Enums, and Flags
- A tuple groups related values without defining a custom type: `static (int Min, int Max) GetRange() => (1, 10);`. Names/types are chosen for the task; `Min` and `Max` are not mandatory.
- An `enum` defines named constants, e.g. `enum Status { Pending, Active, Complete }`.
- `[Flags]` combines independent enum options. Use powers of two so each option has a unique bit.
```csharp
[Flags]
enum Permission { None = 0, Read = 1, Write = 2, Delete = 4 }
Permission access = Permission.Read | Permission.Write;
bool canWrite = access.HasFlag(Permission.Write);
```

## 5. Classes and Object-Oriented Design
- A **class** defines object state/behavior; `new` typically creates an instance.
- **Fields** store data; **properties** expose controlled access with `get`/`set`; **constructors** initialize objects and can be overloaded.
- **Encapsulation** protects state and exposes a clear API.
- Access modifiers: `public` (accessible where type is visible), `private` (containing type), `protected` (type and derived types), `internal` (same assembly), `protected internal` (same assembly **or** derived types), `private protected` (derived types **within the same assembly**).
- `const` is a compile-time constant and implicitly static. `readonly` fields can be assigned at declaration or in the appropriate constructor.
- `partial` types can be split across files; the compiler combines declarations.
- **Records** are data-centric types with value-based equality by default; records can be classes or structs.
- **Indexers** let objects use index syntax such as `collection[0]`.
- Strings are immutable; use `StringBuilder` for repeated string modifications in loops.

## 6. xUnit Unit Testing
- Unit tests automatically verify behavior and help prevent regressions.
- **Arrange–Act–Assert:** prepare inputs, execute behavior, check results.
- `[Fact]` tests one fixed scenario. `[Theory]` runs a test with multiple data sets; each `[InlineData(...)]` supplies one run's arguments.
- `Assert.Equal(expected, actual)` compares values; also use `Assert.True`, `Assert.False`, `Assert.Null`, and `Assert.Contains` as appropriate.
- Test normal, boundary, invalid/missing-input, empty-collection cases, and important branches. Name tests by behavior and outcome.
```csharp
[Theory]
[InlineData(0, 32)]
[InlineData(100, 212)]
public void CelsiusToFahrenheit_ReturnsExpected(double celsius, double expected)
{
    Assert.Equal(expected, Temperature.CelsiusToFahrenheit(celsius));
}
```

## 7. LINQ and Mini-Projects
- LINQ queries collections: `Where` filters, `Select` transforms, `GroupBy` groups, `OrderBy` sorts, `Count` counts.
- A lambda such as `p => p.Category` means “take `p` and return its `Category`.” A group has a key (`group.Key`) and its items.
- `List<T>` is resizable; `T[]` is fixed-length; tuples group a fixed set of typed/named values.
- **Product Catalog:** model product name/price/category; group with `GroupBy`; test multiple/repeated categories, one product, and empty input.
- **Temperature Converter:** use focused methods and meaningful overloads. `F = C * 9 / 5 + 32`; `K = C + 273.15`. Test `0°C = 32°F`, `100°C = 212°F`, `-40°C = -40°F`, plus relevant boundaries.
- **Contact Card:** store five contacts; search case-insensitively, e.g. with `StringComparison.OrdinalIgnoreCase`; test found/missing contacts, mixed casing, and empty input.

## 8. Code Coverage
- **Tests** report whether assertions pass; **coverage** measures code executed during tests. Neither alone proves correctness.
- **xUnit** runs tests; **Coverlet collector** collects coverage; **ReportGenerator** creates a readable HTML report.
- Target: at least **80% coverage** for the agreed metric and actual application/mini-project code. Confirm whether the requirement specifies line or branch coverage.
- Run tests with `--collect:"XPlat Code Coverage"`, find `coverage.cobertura.xml`, generate HTML, then inspect coverage and add tests for uncovered behavior.
```powershell
dotnet test .\ConsoleApp1.Tests\ConsoleApp1.Tests.csproj --collect:"XPlat Code Coverage"
reportgenerator "-reports:TestResults/**/coverage.cobertura.xml" "-targetdir:coverage-report" "-reporttypes:Html"
Invoke-Item .\coverage-report\index.html
```
- Run ReportGenerator from the directory containing `TestResults`, or adjust `-reports` to the actual XML path. Find the XML with `Get-ChildItem -Recurse -Filter coverage.cobertura.xml`.

## 9. SQL Server and SSMS
- SSMS is a client for connecting to/managing SQL Server; it is not the database engine.
- Connect using the installed server/instance name and configured authentication. Verify the connection in Object Explorer.
- Use `SandboxDb` if created and available:
```sql
USE SandboxDb;
GO
SELECT DB_NAME() AS CurrentDatabase;
GO
```
- A successful result of `SandboxDb` verifies the active database context. Never expose passwords/secrets in screenshots or source control.

## 10. Essential CLI Command Mental Models
- `dotnet new xunit -n MyProject.Tests` creates a test project; do not rerun if it already exists.
- `dotnet test path/to/Tests.csproj` builds and runs tests.
- `dotnet add path/to/Tests.csproj package coverlet.collector` adds the collector dependency.
- `Get-ChildItem -Recurse -Filter *.csproj` finds projects; `Get-ChildItem -Recurse -Filter coverage.cobertura.xml` finds coverage output.
- Paths are relative to the current directory. If a project/report is not found, check `Get-Location` and the real path.
- In PowerShell, a trailing backtick continues a command and must be the final character; single-line commands are safer while learning.