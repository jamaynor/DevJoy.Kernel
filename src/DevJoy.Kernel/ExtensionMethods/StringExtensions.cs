using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace DevJoy.ExtensionMethods
{
    public static class StringExtensionMethods
    {

        /// <summary>Indicates whether the specified string is null or a <see cref="string.Empty"/>.</summary>
        public static bool IsNullOrEmpty(this string? seed) { return string.IsNullOrEmpty(seed); }

        /// <summary>Indicates whether the specified string is null or a <see cref="string.Empty"/> or just spacebar characters.</summary>
        public static bool IsNullOrWhitespace(this string? seed) { return string.IsNullOrWhiteSpace(seed); }



        /// <summary>Returns true if the string is formatted as a valid email address.</summary>
        public static bool IsValidEmailAddress(this string? seed)
        {
            if (seed.IsNullOrEmpty()) return false;

            bool isValid = false;
            MailAddress address;

            try
            {
                address = new MailAddress(seed!);
                isValid = true;
            }
            catch { }
            return isValid;
        }

        /// <summary>Returns true if the string is formatted as a valid phone number.</summary>
        public static bool IsValidPhoneNumber(this string? number)
        {
            if (number.IsNullOrEmpty()) return false;

            Regex regex = new Regex(@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$", RegexOptions.IgnoreCase);
            return regex.IsMatch(number!);
        }



        /// <summary>Encodes all the characters in the specified string into a sequence of bytes.</summary>
        public static byte[] ToBytes(this string? startString, Encoding encoding)
        {
            if (startString.IsNullOrEmpty()) return new byte[0];

            if (encoding is null) encoding = Encoding.UTF8;
            return encoding.GetBytes(startString!);
        }
        /// <summary>Encodes all the characters in the specified string into a sequence of bytes.</summary>
        public static byte[] ToBytes(this string? startString) { return startString.ToBytes(Encoding.UTF8); }



        /// <summary>Decodes the bytes in an array into a string using a specified encoder.</summary>
        public static string FromBytes(this byte[]? sourceData, Encoding encoding)
        {
            if (sourceData is null) return string.Empty;
            if (sourceData.Length == 0) return string.Empty;

            if (encoding is null) encoding = Encoding.UTF8;
            return encoding.GetString(sourceData);
        }
        /// <summary>Decodes the bytes in an array into a string using a specified encoder.</summary>
        public static string FromBytes(this byte[]? sourceData) { return sourceData.FromBytes(Encoding.UTF8); }



        /// <summary>Converts plain text to a Base64 encoded string using the UTF8 encoding suitable for the web and obfuscation.</summary>        
        public static string ToBase64String(this string? utf8String)
        {
            if (utf8String.IsNullOrEmpty()) return string.Empty;

            return Convert.ToBase64String(utf8String.ToBytes());
        }

        /// <summary>Decodes a Base64 string rendering UTF-8 string.</summary>        
        public static string FromBase64String(this string? base64EncodedData)
        {
            if (base64EncodedData.IsNullOrEmpty()) throw new ArgumentNullException(nameof(base64EncodedData));

            return Convert.FromBase64String(base64EncodedData!).FromBytes();
        }


        /// <summary>Converts a utf8 encoded string to a hexidecimal encoded string.</summary>                
        public static string ToHexString(this string? utf8String)
        {
            if (utf8String.IsNullOrEmpty()) throw new ArgumentNullException(nameof(utf8String));

            return Convert.ToHexString(utf8String!.ToBytes());
        }
        /// <summary>Converts a hexidecimal encoded string to a utf8 encoded string.</summary>
        public static string FromHexString(this string? hexString)
        {
            if (hexString.IsNullOrEmpty()) throw new ArgumentNullException(nameof(hexString));

            return Convert.FromHexString(hexString!).FromBytes();
        }
    }
}
