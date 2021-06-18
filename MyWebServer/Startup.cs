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
                    .MapGet<AnimalsController>("/Cats", c => c.Cats())
                    .MapGet<AnimalsController>("/Dogs", c => c.Dogs()))
                .Start();
    }
}
