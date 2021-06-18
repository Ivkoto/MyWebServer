using MyWebServer.Server;
using MyWebServer.Server.Controllers;
using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;

namespace MyWebServer.Controllers
{
    public class AnimalsController : Controller
    {

        public AnimalsController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Cats()
        {
            const string nameKey = "Name";

            var query = this.Request.Query;

            var catName = query.ContainsKey(nameKey) ? query[nameKey] : "the cats";

            var result = $"<h1>Hello from the {catName}!</h1>";

            //от къде и какво идва в този result по дяволите
            return new HtmlResponse(result);

        }


        public HttpResponse Dogs() => Html("<h2>Hello from the Dogs</h2>");
    }
}