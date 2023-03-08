using System.Text.Json;
using System.Text.RegularExpressions;
using System.Xml;

namespace CodeAssist.String
{
    public static class StringIsExtensions
    {
        /// <summary>
        /// Case Insensitive comparison of 2 strings if they are equal
        /// </summary>
        /// <param name="value"></param>
        /// <param name="comparedValue"></param>
        /// <param name="stringComparison">Ignored casing by default, pass new value to override</param>
        /// <returns></returns>
        public static bool IsEqual(this string value, string comparedValue, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return string.Equals(value, comparedValue, stringComparison);
        }

        /// <summary>
        /// Case Insensitive comparison of 2 strings if they are not equal
        /// <param name="value"></param>
        /// <param name="comparedValue"></param>
        /// <param name="stringComparison">Ignored casing by default, pass new value to override</param>
        /// <returns></returns>
        public static bool IsNotEqual(this string value, string comparedValue, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            return !string.Equals(value, comparedValue, stringComparison);
        }

        /// <summary>
        /// IsNullOrWhitespace: A extension method that checks if a string is null, empty, or contains only whitespace characters.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhitespace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// IsNullOrEmpty: An extension method that checks if a string is null or an empty string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        /// IsValidEmail: An extension method that validates an email address based on standard email format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidEmail(this string value)
        {
            if (value.IsNullOrWhitespace()) return false;
            var pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var match = Regex.Match(value, pattern, RegexOptions.IgnoreCase);
            return match.Success;
        }

        /// <summary>
        /// IsValidUrl: An extension method that validates a url based on standard url format.
        /// Has a default standard regex pattern to check url, but you can override the value by passing a new pattern if needed.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidUrlRegex(this string value, string pattern = "")
        {
            if (value.IsNullOrWhitespace()) return false;

            if (pattern.IsNullOrWhitespace())
                pattern = @"^(http|https|ftp|ftps)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*$";

            var match = Regex.Match(value, pattern);
            return match.Success;
        }

        /// <summary>
        /// IsValidUrl: An extension method that checks if a string is a valid URL.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidUrl(this string value)
        {
            return Uri.TryCreate(value, UriKind.Absolute, out Uri uriResult) && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }

        /// <summary>
        /// IsValidStringDate: An extension method that validates a string if it is a valid date format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidStringDate(this string value)
        {
            return DateTime.TryParse(value, out _);
        }

        /// <summary>
        /// IsValidStringDateTime: An extension method that validates a string if it is a valid date and time format.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidStringDateTime(this string value)
        {
            return DateTime.TryParse(value, out _);
        }

        /// <summary>
        /// IsNumeric: An extension method that checks if a string contains only numeric characters.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string value)
        {
            return int.TryParse(value, out _);
        }

        /// <summary>
        /// IsAlpha: An extension method that checks if a string contains only alphabetic characters.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsAlpha(this string value)
        {
            return value.All(char.IsLetter);
        }

        /// <summary>
        /// IsAlphaNumeric: An extension method that checks if a string contains only alphanumeric characters.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsAlphaNumeric(this string value)
        {
            return value.All(char.IsLetterOrDigit);
        }

        /// <summary>
        /// IsValidBase64: An extension method that checks if a string is a valid base64 encoded string.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidBase64(this string value)
        {
            if (value.IsNullOrWhitespace()) return false;
            try
            {
                Convert.FromBase64String(value);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        /// <summary>
        /// IsValidGuid: An extension method that checks if a string is a valid guid.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidGuid(this string value)
        {
            if (value.IsNullOrWhitespace()) return false;
            return Guid.TryParse(value, out _);
        }

        /// <summary>
        /// IsValidPhoneNumber: An extension method that checks if a string is a valid phone number based on a specified regular expression pattern.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static bool IsValidPhoneNumber(this string value, string pattern)
        {
            if (value.IsNullOrWhitespace()) return false;

            if (pattern.IsNullOrWhitespace())
                pattern = "^(\\+\\d{1,2}\\s)?\\(?\\d{3}\\)?[\\s.-]\\d{3}[\\s.-]\\d{4}$";

            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// IsValidJson: An extension method that checks if a string is a valid JSON.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidJson(this string value)
        {
            try
            {
                JsonSerializer.Deserialize<object>(value);
                return true;
            }
            catch (JsonException)
            {
                return false;
            }
        }

        /// <summary>
        /// IsValidXml: An extension method that checks if a string is a valid XML.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidXml(this string value)
        {
            try
            {
                XmlDocument doc = new();
                doc.LoadXml(value);
                return true;
            }
            catch (XmlException)
            {
                return false;
            }
        }

        /// <summary>
        /// IsStrongPassword: This method uses a regular expression to check if the input string is a strong password
        /// It first checks the minimum length, then it checks if the password contains at least one uppercase letter, 
        /// one lowercase letter, one digit and one special character, 
        /// by default these checks are set to true but you can configure them.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minLength"></param>
        /// <param name="requireUppercase"></param>
        /// <param name="requireLowercase"></param>
        /// <param name="requireDigit"></param>
        /// <param name="requireSpecial"></param>
        /// <returns></returns>
        public static bool IsStrongPassword(this string value, int minLength = 8, bool requireUppercase = true, bool requireLowercase = true, bool requireDigit = true, bool requireSpecial = true)
        {
            string pattern = $@"^(?=.*[A-Z]{{{(requireUppercase ? 1 : 0)}}})(?=.*[a-z]{{{(requireLowercase ? 1 : 0)}}})(?=.*\d{{{(requireDigit ? 1 : 0)}}})(?=.*[^\w\d]{{{(requireSpecial ? 1 : 0)}}}).{{{minLength},}}$";
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// IsValidUsername: This method uses a regular expression to check if the input string is a valid username
        /// it first checks the minimum and maximum length of the username and then it checks if the
        /// username contains only alphanumeric characters and underscores.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public static bool IsValidUsername(this string value, int minLength = 8, int maxLength = 20)
        {
            string pattern = $@"^[a-zA-Z0-9_]{{{minLength},{maxLength}}}$";
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// IsValidHexColor: An extension method that checks if a string is a valid hex color code.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidHexColor(this string value)
        {
            string pattern = "^#(?:[0-9a-fA-F]{3}){1,2}$";
            return Regex.IsMatch(value, pattern);
        }

        /// <summary>
        /// IsValidMacAddress: An extension method that checks if a string is a valid MAC address.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsValidMacAddress(this string value)
        {
            string pattern = "^([0-9A-Fa-f]{2}[:-]){5}([0-9A-Fa-f]{2})$";
            return Regex.IsMatch(value, pattern);
        }

    }

}

