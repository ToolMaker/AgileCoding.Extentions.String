namespace AgileCoding.Extentions.String
{
    using System;
    using System.Linq;
    using System.Text;

    public static class StringExtentions
    {
        public static void ThrowIfNotContains<TException>(this string data, string lookupString, string errorMessage = null)
            where TException : Exception
        {
            errorMessage = errorMessage == null ? $"Unable to find '{lookupString}' in data" : errorMessage;
            if (!data.Contains(lookupString))
            {
                throw (TException)Activator.CreateInstance(typeof(TException), errorMessage);
            }
        }

        public static void ThrowIfContains<TException>(this string data, char character, string errorMessage = null)
            where TException : Exception
        {
            errorMessage = errorMessage == null ? $"Invalid character '{character}' found in data" : errorMessage;
            if (data.Contains(character))
            {
                throw (TException)Activator.CreateInstance(typeof(TException), errorMessage);
            }
        }

        public static void ThrowIfContainsCharacters<TException>(this string data, char[] chars, string errorMessage = null)
            where TException : Exception
        {
            errorMessage = errorMessage == null ? $"Characters '{string.Join(",", chars)}' not allowed in data" : errorMessage;
            if (data.Any(x => chars.ToList().Any(y => y == x)))
            {
                throw (TException)Activator.CreateInstance(typeof(TException), errorMessage);
            }
        }

        public static string ReplaceIfContains(this string data, char[] chars, char replacementChar)
        {
            string tempString = data;
            foreach (var charToReplace in chars)
            {
                tempString = tempString.Replace(charToReplace, replacementChar);
            }

            return tempString;
        }

        public static string ThrowIfIsNullOrEmpty<TNullExceptionType, TEmptyExcpetionType>(this string data, string stringNullErrorMessage = null, string stringEmptyErrorMessage = null)
            where TNullExceptionType : Exception
            where TEmptyExcpetionType : Exception
        {
            if (data == null)
            {
                throw (TNullExceptionType)Activator.CreateInstance(typeof(TNullExceptionType), stringNullErrorMessage);
            }

            if (string.IsNullOrEmpty(data))
            {
                throw (TEmptyExcpetionType)Activator.CreateInstance(typeof(TEmptyExcpetionType), stringEmptyErrorMessage);
            }

            return data;
        }

        public static byte[] ToBytes(this string self, Encoding encoding)
        {
            return encoding.GetBytes(self);
        }

        public static Guid ToGuid(this string self)
        {
            Guid result;
            if (!Guid.TryParse(self, out result))
            {
                throw new InvalidOperationException($"Was unable to create Guid from string '{self}'.");
            }

            return result;
        }

        public static string ToBase64(this string self, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            return Convert.ToBase64String(self.ToBytes(encoding));
        }

        public static byte[] FromBase64(this string self, Encoding encoding = null)
        {
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            return Convert.FromBase64String(self);
        }

        public static string ToString(this byte[] self, Encoding encoding)
        {
            return encoding.GetString(self);
        }
    }
}
