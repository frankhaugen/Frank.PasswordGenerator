using System;

namespace Frank.PasswordGenerator.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Your new password:");
            var passwordGenerator = new PasswordGenerator();
            Console.WriteLine(passwordGenerator.GeneratePassword());
        }
    }
}