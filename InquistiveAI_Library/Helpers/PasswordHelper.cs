using System;
using System.Linq;
using System.Text;

namespace InquistiveAI_Library.Helpers
{
    public static class PasswordHelper
    {
        private static readonly Random _random = new Random();
        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";
        private const string SpecialChars = "!@#$%^&*()_-+=<>?";

        public static string GenerateRandomPassword(int length = 10)
        {
            if (length < 6) throw new ArgumentException("Password length must be at least 6 characters.");

            StringBuilder password = new StringBuilder();

            // Ensure at least one of each type of character
            password.Append(UppercaseChars[_random.Next(UppercaseChars.Length)]);
            password.Append(LowercaseChars[_random.Next(LowercaseChars.Length)]);
            password.Append(Digits[_random.Next(Digits.Length)]);
            password.Append(SpecialChars[_random.Next(SpecialChars.Length)]);

            // Fill the rest randomly
            string allChars = UppercaseChars + LowercaseChars + Digits + SpecialChars;
            for (int i = 4; i < length; i++)
            {
                password.Append(allChars[_random.Next(allChars.Length)]);
            }

            // Shuffle the password to randomize character order
            return new string(password.ToString().OrderBy(c => _random.Next()).ToArray());
        }
    }
}
