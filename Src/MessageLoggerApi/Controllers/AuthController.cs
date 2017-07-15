using System.Threading.Tasks;
using MessageLoggerApi.Contracts;
using MessageLoggerApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MessageLoggerApi.Controllers
{
    [Route("[controller]")]
    public class AuthController : Controller
    {
        private readonly IMongoDatabase _db;

        public AuthController(IMongoDatabase db)
        {
            _db = db;
        }

        // POST /auth
        [HttpPost]
        public async Task<IActionResult> Post([FromHeader(Name = "Authorization")] string authorization)
        {
            if (string.IsNullOrEmpty(authorization))
            {
                return Unauthorized();
            }

            var authParameters = authorization.Split(':');

            if (authParameters.Length != 2)
            {
                return Unauthorized();
            }

            if (!ObjectId.TryParse(authParameters[0], out ObjectId applicationId))
            {
                return BadRequest("There is something wrong in Authorization header. Please check applicationId, It should be 32 character id for which to create the token");
            }

            var application = await _db.GetCollection<Application>("Application")
                                        .Find(a => a.Id == new ObjectId(authParameters[0]) && a.ApplicationSecret == authParameters[1])
                                        .FirstOrDefaultAsync();

            if (application == null)
            {
                return Unauthorized();
            }

            var token = new Token
            {
                ApplicationId = new ObjectId(authParameters[0])
            };

            await _db.GetCollection<Token>("Token").InsertOneAsync(token);

            return Ok(new AuthContractOutput(token.Value));
        }
    }
}