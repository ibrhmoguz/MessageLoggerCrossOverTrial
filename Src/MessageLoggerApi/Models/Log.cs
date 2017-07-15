using MongoDB.Bson;

namespace MessageLoggerApi.Models
{
    public class Log
    {
        public ObjectId ApplicationId { get; set; }

        public string Logger { get; set; }

        public string Level { get; set; }

        public string Message { get; set; }
    }
}
