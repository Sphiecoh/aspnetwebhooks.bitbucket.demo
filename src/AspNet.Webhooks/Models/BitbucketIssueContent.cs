using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AspNet.Webhooks.Demo.Models
{
    public class BitbucketIssueContent
    {
        [JsonProperty("raw")]
        public string Description { get; set; }
        [JsonProperty("html")]
        public string DescriptionHtml { get; set; }
        [JsonProperty("markup")]
        public string MarkupLanguage { get; set; }
    }
}