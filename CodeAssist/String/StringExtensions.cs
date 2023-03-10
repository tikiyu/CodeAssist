using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace CodeAssist.String
{
    public static partial class StringExtensions
    {

        /// <summary>
        /// Truncate: An extension method that truncates a string to a specified length and optionally adds an ellipsis at the end.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="maxLength"></param>
        /// <param name="addEllipsis"></param>
        /// <returns></returns>
        public static string Truncate(this string value, int maxLength, bool addEllipsis = false)
        {
            if (value.IsNullOrWhitespace()) return value;
            if (value.Length <= maxLength) return value;

            var truncated = value[..maxLength];
            if (addEllipsis)
                truncated += "...";

            return truncated;
        }

        /// <summary>
        /// RemoveDiacritics: An extension method that removes any diacritical marks (accents) from a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveDiacritics(this string value)
        {
            var normalized = value.Normalize(NormalizationForm.FormD);
            var bytes = new byte[normalized.Length * sizeof(char)];
            Buffer.BlockCopy(normalized.ToCharArray(), 0, bytes, 0, bytes.Length);
            Regex regex = new Regex("[^a-zA-Z0-9 ]");
            return regex.Replace(Encoding.ASCII.GetString(bytes), "");
        }


        /// <summary>
        /// RemoveHtmlTags: An extension method that removes all HTML tags from a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveHtmlTags(this string value)
        {
            return Regex.Replace(value, "<.*?>", string.Empty);
        }

        /// <summary>
        /// ExtractUrls: An extension method that extracts all URLs from a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<string> ExtractUrls(this string value)
        {
            var urls = new List<string>();
            var matches = Regex.Matches(value, @"((http|ftp|https):\/\/[\w\-_]+(\.[\w\-_]+)+([\w\-\.,@?^=%&amp;:/~\+#]*[\w\-\@?^=%&amp;/~\+#])?)");

            urls.AddRange(matches.Select(match => match.Value));

            return urls;
        }

        /// <summary>
        /// RemoveSpecialCharacters: An extension method that removes all special charactes from a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveSpecialCharacters(this string value)
        {
            return Regex.Replace(value, "[^a-zA-Z0-9]+", "");
        }

        /// <summary>
        /// RemoveNumbers: An extension method that removes all numbers from a string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveNumbers(this string value)
        {
            return Regex.Replace(value, "[0-9]+", "");
        }

        /// <summary>
        /// RomanToInt: An extension method that converts Roman numerals to integer.
        /// This method uses a dictionary to store the values of Roman numerals and a for loop to iterate through the input string.
        /// It then uses a simple algorithm to convert the Roman numeral string to an integer based on the values stored in the dictionary.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static int RomanToInt(this string value)
        {
            Dictionary<char, int> romanValues = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 },
                { 'D', 500 },
                { 'M', 1000 }
            };

            if (value.IsNullOrWhitespace())
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(value));

            int result = 0;
            for (int i = 0; i < value.Length; i++)
            {
                if (i > 0 && romanValues[value[i]] > romanValues[value[i - 1]])
                    result += romanValues[value[i]] - 2 * romanValues[value[i - 1]];
                else
                    result += romanValues[value[i]];
            }

            return result;
        }

        /// <summary>
        /// SplitLines: An extension method that splits a string into multiple lines.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string[] SplitLines(this string value)
        {
            return value.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
        }

        /// <summary>
        /// Removes a prefix and suffix on a string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="prefix"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string RemovePrefixAndSuffix(this string input, string prefix, string suffix)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (prefix == null)
                throw new ArgumentNullException(nameof(prefix));
            if (suffix == null)
                throw new ArgumentNullException(nameof(suffix));

            if (input.StartsWith(prefix) && input.EndsWith(suffix))
            {
                int startIndex = prefix.Length;
                int length = input.Length - prefix.Length - suffix.Length;
                return input.Substring(startIndex, length);
            }

            return input;
        }

        /// <summary>
        /// Removes prefix on a string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="prefix"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string RemovePrefix(this string input, string prefix)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (prefix == null)
                throw new ArgumentNullException(nameof(prefix));

            if (input.StartsWith(prefix))
                return input[prefix.Length..];

            return input;
        }

        /// <summary>
        /// Removes suffix on a string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="suffix"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string RemoveSuffix(this string input, string suffix)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));
            if (suffix == null)
                throw new ArgumentNullException(nameof(suffix));

            if (input.EndsWith(suffix))
                return input[..^suffix.Length];

            return input;
        }


    }

}

