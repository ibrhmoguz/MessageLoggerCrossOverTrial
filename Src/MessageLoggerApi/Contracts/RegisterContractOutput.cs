using MessageLoggerApi.Models;
using Newtonsoft.Json;

namespace MessageLoggerApi.Contracts
{
    public class RegisterContractOutput
    {
        public RegisterContractOutput(Application application)
        {
            ApplicationId = application.Id.ToString();
            DisplayName = application.DisplayName;
            ApplicationSecret = application.ApplicationSecret;
        }

        [JsonProperty("application_id")]
        public string ApplicationId { get; set; }

        [JsonProperty("display_name")]
        public string DisplayName { get; set; }

        [JsonProperty("application_secret")]
        public string ApplicationSecret { get; set; }
    }
}