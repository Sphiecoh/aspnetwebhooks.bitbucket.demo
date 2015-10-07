using System.Threading.Tasks;
using AspNet.Webhooks.Demo.Models;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace AspNet.Webhooks.Demo.Data
{
    public class IssuesRepository : DocumentDb
    {
        public IssuesRepository() : base("Bitbucket", "Issues")
        {
        }

        public Task<ResourceResponse<Document>> Create(BitbucketIssue issue)
        {
            return Client.CreateDocumentAsync(Collection.DocumentsLink, issue);
        }
    }
}