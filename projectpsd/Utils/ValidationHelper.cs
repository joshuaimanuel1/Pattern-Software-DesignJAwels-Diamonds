using System;
using System.Text.RegularExpressions;

namespace projectpsd.Utils
{
    public static class ValidationHelper
    {
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            string emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailRegex);
        }

        public static bool IsAlphanumeric(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            return Regex.IsMatch(input, @"^[a-zA-Z0-9]*$");
        }

        public static bool IsLengthBetween(string input, int min, int max)
        {
            if (input == null) return false;
            return input.Length >= min && input.Length <= max;
        }

        public static bool IsNumeric(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return false;
            return double.TryParse(input, out _);
        }

        public static bool IsGreaterThan(decimal value, decimal threshold)
        {
            return value > threshold;
        }

        public static bool IsJewelReleaseYearValid(int year)
        {
            return year < 2025;
        }

        public static bool IsDateOfBirthEarlierThan2010(DateTime dob)
        {
            return dob < new DateTime(2010, 1, 1);
        }
    }
}