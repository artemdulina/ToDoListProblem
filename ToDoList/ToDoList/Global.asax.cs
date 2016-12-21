using System.Web.Http;
using ToDoList.Handlers;

namespace ToDoList
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new DataLoader());
        }
    }
}
