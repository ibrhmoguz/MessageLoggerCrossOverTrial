using System.Threading.Tasks;
using MessageLoggerApi.Contracts;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Bson;
using MessageLoggerApi.Models;
using System;

namespace MessageLoggerApi.Controllers
{
    [Route("[controller]")]
    public class LogController : Controller
    {
        private readonly IMongoDatabase _db;

        public LogController(IMongoDatabase db)
        {
            _db = db;
        }

        // POST /log
        [HttpPost]
        public async Task<IActionResult> Post([FromHeader(Name = "Authorization")] string authorization, [FromBody] LogContractInput contract)
        {
            if (string.IsNullOrEmpty(authorization))
            {
                return Unauthorized();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!Guid.TryParse(authorization, out Guid accessToken))
            {
                return BadRequest("There is something wrong in Authorization header. Please check access token, It should be 32 character id for authorization.");
            }

            if (!ObjectId.TryParse(contract.ApplicationId, out ObjectId applicationId))
            {
                return BadRequest("There is something wrong in Request. Please check applicationId, It should be 32 character id.");
            }

            if (await _db.GetCollection<Token>("Token").Find(a => a.Value == accessToken.ToString().Replace("-", string.Empty) && a.ApplicationId == applicationId).FirstOrDefaultAsync() == null)
            {
                return Ok(new LogContractOutput() { Success = false });
            }

            var log = new Log
            {
                ApplicationId = applicationId,
                Level = contract.Level,
                Logger = contract.Logger,
                Message = contract.Message
            };

            await _db.GetCollection<Log>("Log").InsertOneAsync(log);

            return Ok(new LogContractOutput() { Success = true });
        }
    }
}