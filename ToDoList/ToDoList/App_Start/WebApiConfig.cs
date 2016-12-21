using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using BLL.ServicesImplementations;
using ToDoList.Handlers;
using ToDoList.Services;

namespace ToDoList
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "GetAll",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { controller = "ToDos", action = "Get" },
                constraints: new { HttpMethod = new HttpMethodConstraint(HttpMethod.Get)},
                handler: new DataLoader(config, new UserService(), new ToDoService())
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
