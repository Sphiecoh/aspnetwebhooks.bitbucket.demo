using System;
using System.Collections.Generic;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json;

namespace AspNet.Webhooks.Demo.Models
{
    /// <summary>
    /// 
    /// </summary>
   
    public class BitbucketIssue
    {
        /// <summary>
        /// Gets the collection of <see cref="BitbucketLink"/> instances and their link relationships. The
        /// key is the link relationship and the value is the actual link.
        /// </summary>
        [JsonProperty("links")]
        public IDictionary<string, BitbucketLink> Links { get; } = new Dictionary<string, BitbucketLink>();
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        [JsonProperty("priority")]
        public string Priority { get; set; }
        [JsonProperty("state")]
        public string State { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("created_on")]
        public DateTime CreatedAt { get; set; }
        [JsonProperty("updated_on")]
        public DateTime UpdatedAt { get; set; }
        [JsonProperty("content")]
        public BitbucketIssueContent Content { get; set; }
    }
}