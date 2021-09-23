using CodeCoverageWorkshop.Logic;
using System;
using Xunit;

namespace CodeCoverageWorkshop.Logic.xUnit.Test
{
    public class EmailValidatorTests
    {
        [Theory]
        [InlineData("")]
        [InlineData("plainaddress")]
        [InlineData("#@%^%#$@#$@#.com")]
        [InlineData("@example.com")]
        [InlineData("Joe Smith <email@example.com>")]
        [InlineData("email@example@example.com")]
        [InlineData(".beginswithdot@example.com")]
        [InlineData("endswithdot@example.com.")]
        [InlineData("email.@example.com")]
        [InlineData("email..email@example.com")]
        [InlineData("あいうえお@example.com")]
        [InlineData("email@example.com (Joe Smith)")]
        [InlineData("email@example")]
        [InlineData("email@111.222.333.44444")]
        [InlineData("email@example..com")]
        [InlineData("Abc..123@example.com")]
        public void Validate_ShouldReturnValidationMessage_WhenEmailIsInvalid(string email)
        {
            // Arrange
            var emailValidator = new EmailValidator();

            // Act
            var result = emailValidator.Validate(email);

            // Assert
            Assert.False(result.IsValid);
            Assert.Contains("Adres e-mail jest niepoprawny.", result.ErrorMessages);
        }

        // Try comment out all InlineData attributes below leaving only one and you'll still get 100% code coverage for EmailValidator
        [Theory]
        [InlineData("email@example.com")]
        [InlineData("firstname.lastname@example.com")]
        [InlineData("email@subdomain.example.com")]
        [InlineData("firstname+lastname@example.com")]
        [InlineData("1234567890@example.com")]
        [InlineData("email@example-one.com")]
        [InlineData("_______@example.com")]
        [InlineData("email@example.name")]
        [InlineData("firstname-lastname@example.com")]
        [InlineData("ivan.sergeev@example.ru")]
        [InlineData("иван.сергеев@пример.рф")] // https://en.wikipedia.org/wiki/International_email
        public void Validate_ShouldPass_WhenEmailIsValid(string email)
        {
            // Arrange
            var emailValidator = new EmailValidator();

            // Act
            var result = emailValidator.Validate(email);

            // Assert
            Assert.True(result.IsValid);
            Assert.Empty(result.ErrorMessages);
        }


    }
}
