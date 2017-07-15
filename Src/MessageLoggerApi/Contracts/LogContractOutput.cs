using Newtonsoft.Json;

namespace MessageLoggerApi.Contracts
{
    public class LogContractOutput
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}
