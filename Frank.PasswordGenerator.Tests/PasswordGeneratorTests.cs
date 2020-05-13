using FluentAssertions;
using System;
using Xunit;

namespace Frank.PasswordGenerator.Tests
{
    public class PasswordGeneratorTests
    {
        [Fact]
        public void GeneratePassword_NoVariantsSupplied_ThrowNullReferenceException()
        {
            // Arrange
            var passwordGenerator = new PasswordGenerator();
            int characterCount = 10;
            CharacterVariant[] characterVariants = null;

            // Act and Assert
            Assert.Throws<NullReferenceException>(() => passwordGenerator.GeneratePassword(characterCount, characterVariants));
        }

        [Fact]
        public void GeneratePassword_NonPositiveCountSupplied_ThrowArgumentException()
        {
            // Arrange
            var passwordGenerator = new PasswordGenerator();
            int characterCount = 0;
            CharacterVariant[] characterVariants = new[] { CharacterVariant.Lowercase, CharacterVariant.Special };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => passwordGenerator.GeneratePassword(characterCount, characterVariants));
        }

        [Fact]
        public void GeneratePassword_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var passwordGenerator = new PasswordGenerator();
            int characterCount = 10;
            CharacterVariant[] characterVariants = new[] { CharacterVariant.Lowercase, CharacterVariant.Special };

            // Act and Assert
            passwordGenerator.GeneratePassword(characterCount, characterVariants);
        }

        [Fact]
        public void GeneratePassword_DefaultSettings_ReturnNewPassword()
        {
            // Arrange
            var passwordGenerator = new PasswordGenerator();

            // Act
            var result = passwordGenerator.GeneratePassword();

            // Assert
            result.Should().HaveLength(12);
        }

        [Fact]
        public void GeneratePassword_TenCharactersLong_ShouldBeTenCharacters()
        {
            // Arrange
            var passwordGenerator = new PasswordGenerator();
            int characterCount = 10;

            // Act
            var result = passwordGenerator.GeneratePassword(characterCount);

            // Assert
            result.Should().HaveLength(characterCount);
        }
    }
}