using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ProyectoApiNicolas
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de Web API

            // Rutas de Web API config.MapHttpAttributeRoutes();


            //config.Routes.MapHttpRoute(
            //    name: "TraerCategorias",
            //    routeTemplate: "api/Productos/ObtenerCategorias",
            //    defaults: new { }
            //);



            //config.Routes.MapHttpRoute(
            //    name: "GetProductos",
            //    routeTemplate: "api/Productos/GetProducto/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);


            config.Routes.MapHttpRoute(
                name: "DefaultApi2",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            config.Formatters.Remove(config.Formatters.XmlFormatter);
        }
    }
}
