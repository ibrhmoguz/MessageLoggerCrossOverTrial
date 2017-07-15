using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MessageLoggerApi.Contracts
{
    public class LogContractInput
    {
        [Required]
        [StringLength(32)]
        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }

        [Required]
        [StringLength(256)]
        [JsonProperty("logger")]
        public string Logger { get; set; }

        [Required]
        [StringLength(256)]
        [JsonProperty("level")]
        public string Level { get; set; }

        [Required]
        [StringLength(2048)]
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
