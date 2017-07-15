using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MessageLoggerApi.Models
{
    public class RateInfo
    {
        public RateInfo()
        {
            Hits = 1;
        }

        public string ApplicationId { get; set; }

        public int Hits { get; set; }
    }
}
