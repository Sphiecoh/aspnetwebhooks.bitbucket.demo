using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AspNet.Webhooks.Demo.Data;
using AspNet.Webhooks.Demo.Models;
using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;

namespace AspNet.Webhooks.Demo.WebHookHandlers
{
    public class BitbucketWebHookHandler : WebHookHandler
    {
        private readonly IssuesRepository _repository;

        public BitbucketWebHookHandler()
        {
            _repository = new IssuesRepository();
        }
        public override  Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            var entry = context.GetDataOrDefault<JObject>();

            // Extract the action -- for Bitbucket we have only one.
            var action = context.Actions.First();
            switch (action)
            {
                case "repo:push":
                    // Extract information about the repository
                    var repository = entry["repository"].ToObject<BitbucketRepository>();

                    // Information about the user causing the event
                    var actor = entry["actor"].ToObject<BitbucketUser>();

                    // Information about the specific changes
                    foreach (var change in entry["push"]["changes"])
                    {
                        // The previous commit
                        var oldTarget = change["old"]["target"].ToObject<BitbucketTarget>();

                        // The new commit
                        var newTarget = change["new"]["target"].ToObject<BitbucketTarget>();
                    }
                    break;
                case "issue:created":
                    Trace.TraceInformation(entry.ToString());
                    var issue = entry.ToObject<BitbucketIssue>();
                    _repository.Create(issue).Wait();
                    break;
                default:
                    Trace.WriteLine(entry.ToString());
                    break;
            }

            return Task.FromResult(true);
        }
    }
}