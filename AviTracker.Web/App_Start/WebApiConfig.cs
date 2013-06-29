using System.Collections.Generic;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace AviTracker.Web.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "ProjectApi",
                routeTemplate: "api/client/{clientId}/project/{id}",
                defaults: new { controller = "Project", id = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "ProjectTaskApi",
                routeTemplate: "api/project/{projectId}/task/{taskId}",
                defaults: new { controller = "Task", taskId = RouteParameter.Optional });

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
                );

            // To disable tracing in your application, please comment out or remove the following line of code
            // For more information, refer to: http://www.asp.net/web-api
            config.EnableSystemDiagnosticsTracing();

            var timeConverter = new IsoDateTimeConverter();

            var settings = new JsonSerializerSettings
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    DateFormatHandling = DateFormatHandling.IsoDateFormat,
                    Converters = new List<JsonConverter> {timeConverter}
                };
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings = settings;
        }
    }
}