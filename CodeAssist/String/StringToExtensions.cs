using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace CodeAssist.String
{
    public static class StringToExtensions
    {
        /// <summary>
        /// ToTitleCase: An extension method that converts a string to title case (the first letter of each word is capitalized)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToTitleCase(this string value)
        {
            var cultureInfo = CultureInfo.InvariantCulture;
            return cultureInfo.TextInfo.ToTitleCase(value.ToLower());
        }


        /// <summary>
        /// ToCamelCase: An extension method that converts a string to camel case.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToCamelCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;

            return char.ToLowerInvariant(value[0]) + value[1..];
        }

        /// <summary>
        /// ToPascalCase: An extension method that converts a string to Pascal case.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToPascalCase(this string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return value;

            return char.ToUpperInvariant(value[0]) + value[1..];
        }

        /// <summary>
        /// ToSafeFileName: An extension method that removes any invalid characters from a string and replaces them with an underscore, making it safe to use as a file name.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSafeFileName(this string value)
        {
            return Regex.Replace(value, "[^a-zA-Z0-9 _.-]", "_");
        }

        /// <summary>
        /// ToSlug: An extension method that converts a string to a URL-safe "slug" format, typically used for creating unique URLs for blog posts or articles.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSlug(this string value)
        {
            value = value.ToLowerInvariant().Replace(" ", "-");
            value = Regex.Replace(value, @"[^0-9a-z-]", "");
            return value;
        }

        /// <summary>
        /// ToInteger: An extension method that converts a string to integer.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInteger(this string value)
        {
            return int.TryParse(value, out int result) ? result : 0;
        }

        /// <summary>
        /// ToDouble: An extension method that converts a string to double.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(this string value)
        {
            return double.TryParse(value, out double result) ? result : 0;
        }

        /// <summary>
        /// ToDecimal: An extension method that converts a string to decimal.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value)
        {
            return decimal.TryParse(value, out decimal result) ? result : 0;
        }

        /// <summary>
        /// ToLong: An extension method that converts a string to long.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static long ToLong(this string value)
        {
            return long.TryParse(value, out long result) ? result : 0;
        }

        /// <summary>
        /// ToBool: An extension method that converts a string to bool.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool ToBool(this string value)
        {
            return bool.TryParse(value, out bool result) ? result : false;
        }

        /// <summary>
        /// ToEnum: An extension method that converts a string to an enumeration.
        /// This method first checks if the type passed as the generic parameter T is an enumeration, if not it throws an exception. 
        /// Then it uses the Enum.TryParse method to try to parse the string as an enumeration of type T. If the parsing is successful, 
        /// the method returns the enumeration value, otherwise it throws an exception.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ToEnum<T>(this string value) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
                throw new ArgumentException($"{typeof(T)} must be an enumerated type");

            if (Enum.TryParse(value, true, out T result))
                return result;
            else
                throw new ArgumentException("Invalid value for enumeration");
        }

    }

}

