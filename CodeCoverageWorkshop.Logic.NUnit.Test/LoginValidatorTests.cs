using CodeCoverageWorkshop.Logic.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeCoverageWorkshop.Logic.NUnit.Test
{
    [TestFixture]
    public class LoginValidatorTests
    {
        [Test]
        public void Validate_WhenLoginIsUnique_ShouldNotReturnLoginNotUniqueValidationMessage()
        {
            // Arrange
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(x => x.UserExists(It.IsAny<string>())).Returns(false);
            var glossaryServiceMock = new Mock<IGlossaryService>();
            glossaryServiceMock.Setup(x => x.GetElements(GlossaryConsts.ForbiddenLogins)).Returns(new List<string>() { "zakazanyLogin1", "niecenzuralneSłowo" });

            var sut = new LoginValidator(userServiceMock.Object, glossaryServiceMock.Object);
            string login = "uniqueLogin";
            string password = "somePassword";


            // Act & Assert
            Assert.DoesNotThrow(() => sut.Validate(login, password));
        }
    }
}
