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

string myHtmlString = "<b><i>Some text</i></b>";
bool cleanString = myHtmlString.RemoveHtmlTags();

```

## Contributing

If you find a bug or have a feature request, please create an issue on the [GitHub repository](https://github.com/tikiyu/CodeAssist). Pull requests are also welcome!

## License

CodeAssist is released under the [MIT License](https://github.com/tikiyu/CodeAssist/blob/main/LICENSE).
