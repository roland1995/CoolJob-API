using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoolJobAPI.Models
{
    public class Job
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }
        public string Company { get; set; }
        [JsonPropertyName("company_url")]
        public string CompanyUrl { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [JsonPropertyName("how_to_apply")]
        public string HowToApply { get; set; }
        [JsonPropertyName("company_log")]
        public string CompanyLogo { get; set; }
    }
}
