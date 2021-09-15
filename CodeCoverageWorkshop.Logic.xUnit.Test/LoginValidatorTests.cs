using CodeCoverageWorkshop.Logic.Services;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CodeCoverageWorkshop.Logic.xUnit.Test
{
    public class LoginValidatorTests
    {
        [Fact]
        public void Validate_WhenLoginIsUnique_ShouldNotReturnLoginNotUniqueValidationMessage()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.UserExists(It.IsAny<string>())).Returns(false);
            var glossaryServiceMock = new Mock<IGlossaryService>();
            glossaryServiceMock.Setup(x => x.GetElements(GlossaryConsts.ForbiddenLogins)).Returns(new List<string>() { "zakazanyLogin1", "brzydkieSłowo" });

            var sut = new LoginValidator(userServiceMock.Object, glossaryServiceMock.Object);
            string login = "uniqueLogin";
            string password = "somePassword";


            // Act & Assert
            var exception = Record.Exception(() => sut.Validate(login, password));
            Assert.Null(exception);
        }

        [Fact]
        public void Validate_WhenLoginIsNotUnique_ShouldReturnLoginNotUniqueValidationMessage()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.UserExists(It.IsAny<string>())).Returns(true);
            var glossaryServiceMock = new Mock<IGlossaryService>();
            glossaryServiceMock.Setup(x => x.GetElements(GlossaryConsts.ForbiddenLogins)).Returns(new List<string>() { "zakazanyLogin1", "brzydkieSłowo" });

            var sut = new LoginValidator(userServiceMock.Object, glossaryServiceMock.Object);
            string login = "someLogin";
            string password = "somePassword";


            // Act & Assert
            var exception = Record.Exception(() => sut.Validate(login, password));
            Assert.NotNull(exception);
            Assert.Contains("Podany login jest już zajęty", exception.Message);
        }
    }
}
