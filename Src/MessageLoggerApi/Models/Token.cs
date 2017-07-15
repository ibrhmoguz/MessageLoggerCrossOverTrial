using System;
using MongoDB.Bson;

namespace MessageLoggerApi.Models
{
    public class Token
    {
        public Token()
        {
            CreatedDate = DateTime.UtcNow;
            Value = Guid.NewGuid().ToString().Replace("-", string.Empty);
        }

        public ObjectId Id { get; set; }

        public ObjectId ApplicationId { get; set; }

        public string Value { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}