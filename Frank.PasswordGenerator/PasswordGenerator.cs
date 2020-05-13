using System.Collections.Generic;

namespace Frank.PasswordGenerator
{
    /// <summary>
    /// A simple password generator
    /// </summary>
    public class PasswordGenerator
    {
        private Dictionary<CharacterVariant, string> _characters;
        private PasswordGeneratorHelper _generatorHelper;

        public PasswordGenerator()
        {
            _characters = new Dictionary<CharacterVariant, string>();
            _generatorHelper = new PasswordGeneratorHelper(_characters);
        }

        /// <summary>
        /// Generate a password string
        /// </summary>
        /// <param name="characterCount">A positive integer of how many characters the password should be</param>
        /// <param name="characterVariants">The variants of characters to use</param>
        /// <returns>The password string</returns>
        public string GeneratePassword(int characterCount = 12, params CharacterVariant[] characterVariants)
        {
            _generatorHelper.EnsurePositiveCharacterCount(characterCount);
            _generatorHelper.EnsurePositiveCharacterVariantCount(characterVariants);
            _generatorHelper.AddCharacterVariantsToDictionary(characterVariants);
            return _generatorHelper.CreatePasswordString(characterCount);
        }

        /// <summary>
        /// Generate a password string based on three default character types
        /// </summary>
        /// <param name="characterCount">A positive integer of how many characters the password should be</param>
        /// <returns>The password string</returns>
        public string GeneratePassword(int characterCount = 12)
        {
            _generatorHelper.EnsurePositiveCharacterCount(characterCount);
            _characters.Add(CharacterVariant.Digits, Characters.Digits);
            _characters.Add(CharacterVariant.Lowercase, Characters.Lowercase);
            _characters.Add(CharacterVariant.Uppercase, Characters.Uppercase);
            return _generatorHelper.CreatePasswordString(characterCount);
        }
    }
}