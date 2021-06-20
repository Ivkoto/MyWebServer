using MyWebServer.Server.Http;
using MyWebServer.Server.Results;

namespace MyWebServer.Server.Results
{
    public class HtmlResult : ContentResult
    {
        public HtmlResult(HttpResponse response, string html)
            : base(response, html, HttpContentType.Html)
        {
        }
    }
}
