# CodeAssist
CodeAssist is a .NET library that provides extension methods for strings that are frequently used by developers. With CodeAssist, you can easily access these extension methods without having to write them from scratch every time you need them.

## Installation

To use CodeAssist in your .NET project, you can install it via [NuGet](https://www.nuget.org/packages/CodeAssist/):

```sh
PM> Install-Package CodeAssist
```
## Usage

- ToTitleCase(): An extension method that converts a string to title case (the first letter of each word is capitalized)
- ToCamelCase(): An extension method that converts a string to camel case.
- ToPascalCase(): An extension method that converts a string to Pascal case.
- ToSafeFileName():  An extension method that removes any invalid characters from a string and replaces them with an underscore, making it safe to use as a file name.
- ToSlug(): An extension method that converts a string to a URL-safe "slug" format, typically used for creating unique URLs for blog posts or articles.
- ToInteger(): An extension method that converts a string to integer.
- Truncate(int length, bool addElipsis): An extension method that truncates a string to a specified length and optionally adds an ellipsis at the end.
- RemoveDiacritics(): An extension method that removes any diacritical marks (accents) from a string.
- RemoveHtmlTags(): An extension method that removes all HTML tags from a string.
- ExtractUrls():  An extension method that extracts all URLs from a string.
- IsValidEmail):  An extension method that validates an email address based on standard email format.
- IsAlpha(): An extension method that checks if a string contains only alphabetic characters.
- IsValidBase64():  An extension method that checks if a string is a valid base64 encoded string.
- and more...


To use these extension methods, simply include the CodeAssist namespace in your C# file:
```c#
using CodeAssist;

string inputString = "hello world";
string titleCaseString = inputString.ToTitleCase(); // Output: "Hello World"
```
```c#
string inputString = "this is a sample text";
string camelCaseString = inputString.ToCamelCase(); // Output: "thisIsASampleText"
```
```c#
string inputString = "this is a sample text";
string pascalCaseString = inputString.ToPascalCase(); // Output: "ThisIsASampleText"
```
```c#
string inputString = "my_file.txt?";
string safeFileName = inputString.ToSafeFileName(); // Output: "my_file.txt_"
```
```c#
string inputString = "This is a sample string";
string slug = inputString.ToSlug(); // Output: "this-is-a-sample-string"
```
```c#
string inputString = "42";
int integerValue = inputString.ToInteger(); // Output: 42
```
```c#
string inputString = "3.14";
double doubleValue = inputString.ToDouble(); // Output: 3.14
```
```c#
string inputString = "123.456";
decimal decimalValue = inputString.ToDecimal(); // Output: 123.456
```
```c#
string inputString = "9223372036854775807";
long longValue = inputString.ToLong(); // Output: 9223372036854775807
```
```c#
string inputString = "true";
bool boolValue = inputString.ToBool(); // Output: true
```
```c#
enum Colors { Red, Green, Blue };
string inputString = "Green";
Colors color = inputString.ToEnum<Colors>(); // Output: Colors.Green
```
```c#
string input = "This is a very long sentence that needs to be truncated.";
string truncatedString = input.Truncate(20, true);
Console.WriteLine(truncatedString); // output: "This is a very long..."
```
```c#
string input = "Héllo Wörld!";
string withoutDiacritics = input.RemoveDiacritics();
Console.WriteLine(withoutDiacritics); // output: "Hello World!"
```
```c#
string input = "<p>This is a paragraph.</p><a href=\"https://example.com\">This is a link</a>";
string withoutHtmlTags = input.RemoveHtmlTags();
Console.WriteLine(withoutHtmlTags); // output: "This is a paragraph.This is a link"
```
```c#
string input = "Visit my website at https://example.com or my blog at https://blog.example.com";
List<string> urls = input.ExtractUrls();
foreach (string url in urls)
{
    Console.WriteLine(url);
}
// output:
// https://example.com
// https://blog.example.com
```
```c#
string input = "This string contains @#$% special characters.";
string withoutSpecialCharacters = input.RemoveSpecialCharacters();
Console.WriteLine(withoutSpecialCharacters); // output: "Thisstringcontainsspecialcharacters"
```
```c#
string input = "This string contains 1234567890 numbers.";
string withoutNumbers = input.RemoveNumbers();
Console.WriteLine(withoutNumbers); // output: "This string contains  numbers."
```
```c#
string input = "MCMXCIV";
int result = input.RomanToInt();
Console.WriteLine(result); // output: 1994
```
```c#
string input = "MCMXCIV";
int result = input.RomanToInt();
Console.WriteLine(result); // output: 1994
```
```c#
string input = "This is a\nmultiline\nstring\nwith multiple\nlines.";
string[] lines = input.SplitLines();
foreach (string line in lines)
{
    Console.WriteLine(line);
}

// output:
// This is a
// multiline
// string
// with multiple
// lines.
```
```c#
string input = "This is a test string.";
string result = input.RemovePrefixAndSuffix("This is a ", " string.");
Console.WriteLine(result); // output: "test"
```
```c#
// Check if two strings are equal
string str1 = "Hello";
string str2 = "HELLO";
Console.WriteLine(str1.IsEqual(str2)); // true
```
```c#
// Check if two strings are not equal
string str3 = "world";
string str4 = "world!";
Console.WriteLine(str3.IsNotEqual(str4)); // true
```
```c#
// Check if a string is null, empty, or contains only whitespace characters
string str5 = " ";
Console.WriteLine(str5.IsNullOrWhitespace()); // true
```
```c#
// Check if a string is null or an empty string
string str6 = "";
Console.WriteLine(str6.IsNullOrEmpty()); // true
```
```c#
// Check if a string is a valid email address
string email = "email@example.com";
Console.WriteLine(email.IsValidEmail()); // true
```
```c#
// Check if a string is a valid URL
string url = "http://www.example.com";
Console.WriteLine(url.IsValidUrl()); // true
```
```c#
// Check if a string is a valid date format
string date = "2022-01-01";
Console.WriteLine(date.IsValidStringDate()); // true
```
```c#
// Check if a string is a valid date and time format
string dateTime = "2022-01-01 12:00:00";
Console.WriteLine(dateTime.IsValidStringDateTime()); // true
```
```c#
// Check if a string contains only numeric characters
string numericStr = "12345";
Console.WriteLine(numericStr.IsNumeric()); // true
```
```c#
// Check if a string contains only alphabetic characters
string alphabeticStr = "abcde";
Console.WriteLine(alphabeticStr.IsAlpha()); // true
```
```c#
// Check if a string contains only alphanumeric characters
string alphaNumericStr = "abcde12345";
Console.WriteLine(alphaNumericStr.IsAlphaNumeric()); // true

```

## Contributing

If you find a bug or have a feature request, please create an issue on the [GitHub repository](https://github.com/tikiyu/CodeAssist). Pull requests are also welcome!

## License

CodeAssist is released under the [MIT License](https://github.com/tikiyu/CodeAssist/blob/main/LICENSE).
