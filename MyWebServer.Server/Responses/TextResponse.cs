using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;

namespace MyWebServer.Server.Responses
{
    public class TextResponse : ContentResponse
    {

        public TextResponse(string text)
            : base(text, HttpContentType.PlainText)
        {
        }
    }
}
