using System;

namespace Frank.PasswordGenerator.Cli
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var passwordGenerator = new PasswordGenerator();

            Console.Write("Default password length:\n");
            Console.WriteLine(PasswordGenerator.DefaultPasswordLength);

            Console.Write("\nYour new password using default settings:\n");
            Console.WriteLine(passwordGenerator.GeneratePassword());

            Console.Write("\nYour new password using default settings:\n");
            Console.WriteLine(passwordGenerator.GeneratePassword());

            Console.Write("\nYour new password using default settings (Uppercase, Lowercase and Digits), but custom length:\n");
            Console.WriteLine(passwordGenerator.GeneratePassword(16));

            Console.Write("\nYour new password using default length, but custom variants:\n");
            Console.WriteLine(passwordGenerator.GeneratePassword(CharacterVariant.Digits, CharacterVariant.Lowercase, CharacterVariant.Special, CharacterVariant.Uppercase));

            Console.Write("\nYour new password using all custom settings:\n");
            Console.WriteLine(passwordGenerator.GeneratePassword(32, CharacterVariant.Lowercase, CharacterVariant.Digits, CharacterVariant.Uppercase));

            // Should look like this:
            //Default password length:
            //12

            //Your new password using default settings:
            //D5cbWL3UUCuC

            //Your new password using default settings(Uppercase, Lowercase and Digits), but custom length:
            //vvnim8MIuoje4W4j

            //Your new password using default length, but custom variants:
            //& Xq)Sjr | 0YC

            //Your new password using all custom settings:
            //G!,#=<*{<QX%*<*X@HPJ$,G:E%A,O]-
        }
    }
}