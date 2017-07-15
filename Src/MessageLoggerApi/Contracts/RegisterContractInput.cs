using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MessageLoggerApi.Contracts
{
    public class RegisterContractInput
    {
        [JsonProperty("display_name")]
        [Required]
        [StringLength(32)]
        public string DisplayName { get; set; }
    }
}
