using MyWebServer.Server;
using System.Threading.Tasks;
using MyWebServer.Server.Results;

namespace MyWebServer
{
    public class Program
    {
        public static async Task Main() 
            => await new HttpServer(routes => routes
                    .MapGet("/", new TextResponse("Hello from Ivo!"))
                    .MapGet("/Cats", new TextResponse("<h1>Hello from Molly the black cat!</hq>", "text/html"))
                    )
                .Start();
    }
}
