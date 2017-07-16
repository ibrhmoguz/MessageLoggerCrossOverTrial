using System.Threading.Tasks;
using MessageLoggerApi.Contracts;
using MessageLoggerApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Moq;
using Xunit;
using Microsoft.Extensions.Caching.Memory;

namespace MessageLoggerApiTests
{
    public class LogControllerTests
    {
        [Fact]
        public async Task MissingAuthorizationAsync()
        {
            Mock<IMongoDatabase> mongoDbMock = new Mock<IMongoDatabase>();
            Mock<IMemoryCache> cacheMock = new Mock<IMemoryCache>();
            var logController = new LogController(mongoDbMock.Object, cacheMock.Object);
            var result = await logController.Post(string.Empty, new LogContractInput() { });

            Assert.IsType<UnauthorizedResult>(result);
        }

        [Fact]
        public async Task WrongAuthorizationFormat()
        {
            Mock<IMongoDatabase> mongoDbMock = new Mock<IMongoDatabase>();
            Mock<IMemoryCache> cacheMock = new Mock<IMemoryCache>();
            var logController = new LogController(mongoDbMock.Object, cacheMock.Object);
            var result = await logController.Post("sadfasdf&&6546546", new LogContractInput() { });

            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}