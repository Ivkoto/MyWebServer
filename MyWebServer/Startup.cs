using MyWebServer.Server;
using MyWebServer.Server.Responses;
using MyWebServer.Server.Results;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class Startup
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                    .MapGet("/", new TextResponse("Hello from Ivo!"))
                    .MapGet("/Cats", request =>
                    {
                        const string nameKey = "Name";

                        var query = request.Query;

                        var catName = query.ContainsKey(nameKey) ? query[nameKey] : "the cats";

                        var result = $"<h1>Hello from the {catName}!</h1>";
                        //от къде и какво идва в този result по дяволите
                        return new HtmlResponse(result);
                    })
                    .MapGet("/Map", new HtmlResponse("<h2>Hello from the interactive map</h2>"))
                    )
                .Start();
    }
}
