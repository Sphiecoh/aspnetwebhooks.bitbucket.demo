using System.Web;
using System.Web.Http;

namespace AspNet.Webhooks.Demo
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}