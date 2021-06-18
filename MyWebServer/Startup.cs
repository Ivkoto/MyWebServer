using MyWebServer.Controllers;
using MyWebServer.Server;
using System.Threading.Tasks;
using MyWebServer.Server.Controllers;

namespace MyWebServer
{
    public class Startup
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                    .MapGet<HomeController>("/", c => c.Index())
                    .MapGet<HomeController>("/softuni", c => c.ToSoftuni())
                    .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
                    .MapGet<AnimalsController>("/cats", c => c.Cats())
                    .MapGet<AnimalsController>("/dogs", c => c.Dogs()))
                .Start();
    }
}
