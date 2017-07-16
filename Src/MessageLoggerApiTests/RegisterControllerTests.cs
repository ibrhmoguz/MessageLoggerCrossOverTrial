using System.Threading.Tasks;
using MessageLoggerApi.Contracts;
using MessageLoggerApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace MessageLoggerApiTests
{
    public class RegisterControllerTests
    {
        [Fact]
        public async Task MissingDisplayName()
        {
            Mock<IMongoDatabase> mongoDbMock = new Mock<IMongoDatabase>();
            var registerController = new RegisterController(mongoDbMock.Object);
            var result = await registerController.Post(new RegisterContractInput() { DisplayName = string.Empty });

            Assert.IsType<BadRequestResult>(result);
        }
    }
}