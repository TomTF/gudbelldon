/// <copyright>
/// Copyright (c) 2014 All Rights Reserved
/// <author>Thomas Fischer</author>
/// </copyright>   

using Newtonsoft.Json.Serialization;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace Gudbelldon
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.UseDataContractJsonSerializer = false;

            //config.Formatters.XmlFormatter.UseXmlSerializer = true;
        }
    }
}
