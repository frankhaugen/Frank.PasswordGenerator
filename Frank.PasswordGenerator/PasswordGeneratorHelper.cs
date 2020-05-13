﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Frank.PasswordGenerator
{
    /// <summary>
    /// This should be hidden
    /// </summary>
    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PasswordGeneratorHelper
    {
        private Dictionary<CharacterVariant, string> _characters;

        public PasswordGeneratorHelper(Dictionary<CharacterVariant, string> characters)
        {
            _characters = characters;
        }

        public string CreatePasswordString(int characterCount)
        {
            var output = "";

            for (int i = 0; i < characterCount; i++)
            {
                var characters = CombineCharactersToSingleString();
                output += characters[GetRandom(CombineCharactersToSingleString().Length - 1)];
            }

            return output;
        }

        public string CombineCharactersToSingleString() => _characters.SelectMany(x => x.Value).Select(x => x).ToString();

        public void AddCharacterVariantsToDictionary(CharacterVariant[] characterVariants)
        {
            EnsurePositiveCharacterVariantCount(characterVariants);

            foreach (var characterVariant in characterVariants)
            {
                switch (characterVariant)
                {
                    case CharacterVariant.Digits:
                        _characters.Add(CharacterVariant.Digits, Characters.Digits);
                        break;

                    case CharacterVariant.Uppercase:
                        _characters.Add(CharacterVariant.Uppercase, Characters.Uppercase);
                        break;

                    case CharacterVariant.Lowercase:
                        _characters.Add(CharacterVariant.Lowercase, Characters.Lowercase);
                        break;

                    case CharacterVariant.Special:
                        _characters.Add(CharacterVariant.Special, Characters.Special);
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public void EnsurePositiveCharacterVariantCount(CharacterVariant[] characterVariants)
        {
            if (characterVariants.Length < 1)
            {
                throw new ArgumentException("Value cannot be less than 1", nameof(characterVariants));
            }
        }

        public void EnsurePositiveCharacterCount(int characterCount)
        {
            if (characterCount < 1)
            {
                throw new ArgumentException("Value cannot be less than 1", nameof(characterCount));
            }
        }

        public CharacterVariant GetRandomCharacterVariant()
        {
            return _characters.ElementAt(GetRandom(_characters.Count)).Key;
        }

        public int GetRandom(int maxValue)
        {
            var random = new Random();
            return random.Next(maxValue);
        }
    }
}