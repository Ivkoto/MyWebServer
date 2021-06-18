using MyWebServer.Server.Http;
using MyWebServer.Server.Routing;
using System;

namespace MyWebServer.Server.Controllers
{
    public static class RoutingTableExtensions
    {
        public static IRoutingTable MapGet<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
            => routingTable.MapGet(path, request =>
                    controllerFunction(CreatController<TController>(request)));


        public static IRoutingTable MapPost<TController>(
            this IRoutingTable routingTable,
            string path,
            Func<TController, HttpResponse> controllerFunction)
            where TController : Controller
            => routingTable.MapPost(path, request =>
                controllerFunction(CreatController<TController>(request)));


        private static TController CreatController<TController>(HttpRequest request)
        => (TController)Activator.CreateInstance(typeof(TController), request);
                                                             //replaced code //new[] { request }
    }
}
