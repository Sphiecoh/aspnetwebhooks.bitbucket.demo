




using System.Web.Http;

namespace AspNet.Webhooks.Demo
{
    public static class WebHookConfig
    {
        public static void Register(HttpConfiguration config)
        {

			config.InitializeReceiveBitbucketWebHooks();

        }
    }
}
