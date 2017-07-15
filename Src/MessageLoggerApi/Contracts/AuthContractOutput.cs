using Newtonsoft.Json;

namespace MessageLoggerApi.Contracts
{
    public class AuthContractOutput
    {
        public AuthContractOutput(string accessToken)
        {
            AccessToken = accessToken;
        }

        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}