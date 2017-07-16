using System.Threading.Tasks;
using MessageLoggerApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace MessageLoggerApiTests
{
    public class AuthControllerTests
    {
        [Fact]
        public async Task MissingAuthorizationAsync()
        {
            Mock<IMongoDatabase> mongoDbMock = new Mock<IMongoDatabase>();
            var authController = new AuthController(mongoDbMock.Object);
            var result = await authController.Post(string.Empty);

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task WrongAuthorizationFormat()
        {
            Mock<IMongoDatabase> mongoDbMock = new Mock<IMongoDatabase>();
            var authController = new AuthController(mongoDbMock.Object);
            var result = await authController.Post("sadfasdf&&6546546");

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task MissingApplicationId()
        {
            Mock<IMongoDatabase> mongoDbMock = new Mock<IMongoDatabase>();
            var authController = new AuthController(mongoDbMock.Object);
            var result = await authController.Post(":ff34221527d846d58b62622189bc7f85");

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}