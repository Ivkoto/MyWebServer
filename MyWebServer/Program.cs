using MyWebServer.Server;
using System.Threading.Tasks;
using MyWebServer.Server.Responses;
using MyWebServer.Server.Results;

namespace MyWebServer
{
    public class Program
    {
        public static async Task Main() 
            => await new HttpServer(routes => routes
                    .MapGet("/", new TextResponse("Hello from Ivo!"))
                    .MapGet("/Cats", new HtmlResponse("<h1>Hello from Molly the black cat!</h1>"))
                    .MapGet("/Map", new HtmlResponse("<h2>Hello from the interactive map</h2>"))
                    )
                .Start();
    }
}
