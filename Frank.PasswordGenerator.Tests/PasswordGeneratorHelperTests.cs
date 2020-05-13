using FluentAssertions;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Frank.PasswordGenerator.Tests
{
    public class PasswordGeneratorHelperTests
    {
        private readonly ITestOutputHelper _outputHelper;

        public PasswordGeneratorHelperTests(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Fact]
        public void CreatePasswordString_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var characters = new Dictionary<CharacterVariant, string>();
            characters.Add(CharacterVariant.Digits, Characters.Digits);
            characters.Add(CharacterVariant.Lowercase, Characters.Lowercase);
            characters.Add(CharacterVariant.Uppercase, Characters.Uppercase);

            var passwordGeneratorHelper = new PasswordGeneratorHelper(characters);
            int characterCount = 12;

            // Act
            var result = passwordGeneratorHelper.CreatePasswordString(characterCount);

            // Assert
            _outputHelper.WriteLine(result);
        }

        [Fact]
        public void AddCharacterVariantsToDictionary_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var characters = new Dictionary<CharacterVariant, string>();
            var passwordGeneratorHelper = new PasswordGeneratorHelper(characters);
            var characterVariants = new[] { CharacterVariant.Lowercase, CharacterVariant.Special };

            // Act
            passwordGeneratorHelper.AddCharacterVariantsToDictionary(characterVariants);

            // Assert
            characters.Should().HaveCount(characterVariants.Length);
        }

        [Fact]
        public void EnsurePositiveCharacterVariantCount_PositiveCount_DoesNotThrow()
        {
            // Arrange
            var characters = new Dictionary<CharacterVariant, string>();
            characters.Add(CharacterVariant.Digits, Characters.Digits);
            characters.Add(CharacterVariant.Lowercase, Characters.Lowercase);
            characters.Add(CharacterVariant.Uppercase, Characters.Uppercase);
            var passwordGeneratorHelper = new PasswordGeneratorHelper(characters);
            var characterVariants = new[] { CharacterVariant.Lowercase, CharacterVariant.Special };

            // Act and Assert
            passwordGeneratorHelper.EnsurePositiveCharacterVariantCount(characterVariants);
        }

        [Fact]
        public void EnsurePositiveCharacterVariantCount_NonPositiveCount_ThrowsArgumentException()
        {
            // Arrange
            var characters = new Dictionary<CharacterVariant, string>();
            var passwordGeneratorHelper = new PasswordGeneratorHelper(characters);
            var characterVariants = new CharacterVariant[] { };

            // Assert
            Assert.Throws<ArgumentException>(() => passwordGeneratorHelper.EnsurePositiveCharacterVariantCount(characterVariants));
        }

        [Fact]
        public void EnsurePositiveCharacterCount_PositiveCount_DoesNotThrow()
        {
            // Arrange
            var characters = new Dictionary<CharacterVariant, string>();
            var passwordGeneratorHelper = new PasswordGeneratorHelper(characters);
            int characterCount = 12;

            // Act and Assert
            passwordGeneratorHelper.EnsurePositiveCharacterCount(characterCount);
        }

        [Fact]
        public void EnsurePositiveCharacterCount_NonPositiveCount_ThrowsArgumentException()
        {
            // Arrange
            var characters = new Dictionary<CharacterVariant, string>();
            characters.Add(CharacterVariant.Digits, Characters.Digits);
            characters.Add(CharacterVariant.Lowercase, Characters.Lowercase);
            characters.Add(CharacterVariant.Uppercase, Characters.Uppercase);
            var passwordGeneratorHelper = new PasswordGeneratorHelper(characters);
            int characterCount = 0;

            // Act and Assert
            Assert.Throws<ArgumentException>(() => passwordGeneratorHelper.EnsurePositiveCharacterCount(characterCount));
        }

        [Fact]
        public void GetRandomCharacterVariant_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var characters = new Dictionary<CharacterVariant, string>();
            characters.Add(CharacterVariant.Digits, Characters.Digits);
            characters.Add(CharacterVariant.Lowercase, Characters.Lowercase);
            characters.Add(CharacterVariant.Uppercase, Characters.Uppercase);
            var passwordGeneratorHelper = new PasswordGeneratorHelper(characters);

            // Act
            var result = passwordGeneratorHelper.GetRandomCharacterVariant();

            // Assert
            characters.Should().ContainKey(result);
        }

        [Fact]
        public void GetRandom_RunTwice_ValuesShouldBeDifferent()
        {
            // Arrange
            var characters = new Dictionary<CharacterVariant, string>();
            var passwordGeneratorHelper = new PasswordGeneratorHelper(characters);
            int maxValue = 1000;

            // Act
            var result1 = passwordGeneratorHelper.GetRandom(maxValue);
            var result2 = passwordGeneratorHelper.GetRandom(maxValue);

            // Assert
            result1.Should().NotBe(result2);
        }
    }
}