using Xunit;

namespace CodeCoverageWorkshop.Logic.xUnit.Test
{
    public class PhoneValidatorTests
    {
        [Theory]
        [InlineData("", "Nie podano numeru telefonu.")]
        [InlineData("1", "Numer telefonu ma mieć 9 cyfr.")]
        [InlineData("12234478", "Numer telefonu ma mieć 9 cyfr.")]
        [InlineData("1234567890", "Numer telefonu ma mieć 9 cyfr.")]
        [InlineData("123123abc", "Numer telefonu ma mieć 9 cyfr.")]
        public void Validate_ShouldReturnProperValidationMessage_ForInvalidInput(string input, string expectedMessage)
        {
            // Arrange
            var sut = new PhoneValidator();

            // Act
            var result = sut.Validate(input);

            // Assert
            Assert.Contains(expectedMessage, result.ErrorMessages);
        }

        // If you comment out this test case you'll still get 100% line coverage
        [Fact]
        public void Validate_ShouldReturnNoErrorMessages_ForValidInput()
        {
            // Arrange
            var sut = new PhoneValidator();

            // Act
            var result = sut.Validate("123456999");

            // Assert
            Assert.Empty(result.ErrorMessages);
        }
    }
}
