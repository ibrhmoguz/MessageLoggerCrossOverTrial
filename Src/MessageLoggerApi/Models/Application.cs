using System;
using MongoDB.Bson;

namespace MessageLoggerApi.Models
{
    public class Application
    {
        public Application()
        {
            ApplicationSecret = Guid.NewGuid().ToString().Replace("-", string.Empty);
        }

        public ObjectId Id { get; set; }

        public string DisplayName { get; set; }

        public string ApplicationSecret { get; set; }
    }
}