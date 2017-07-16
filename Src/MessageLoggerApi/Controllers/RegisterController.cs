using System.Threading.Tasks;
using MessageLoggerApi.Contracts;
using MessageLoggerApi.Models;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace MessageLoggerApi.Controllers
{
    [Route("[controller]")]
    public class RegisterController : Controller
    {
        private readonly IMongoDatabase _db;

        public RegisterController(IMongoDatabase db)
        {
            _db = db;
        }

        // POST /register
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterContractInput contract)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (string.IsNullOrEmpty(contract.DisplayName))
            {
                return BadRequest();
            }

            if (await _db.GetCollection<Application>("Application").Find(a => a.DisplayName == contract.DisplayName).FirstOrDefaultAsync() != null)
            {
                return BadRequest(new { DisplayName = new[] { "Display name already in use by another application" } });
            }

            var application = new Application
            {
                DisplayName = contract.DisplayName
            };

            await _db.GetCollection<Application>("Application").InsertOneAsync(application);

            return Ok(new RegisterContractOutput(application));
        }
    }
}