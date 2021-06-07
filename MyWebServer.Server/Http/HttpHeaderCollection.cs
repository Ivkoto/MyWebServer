using System.Collections.Generic;

namespace MyWebServer.Server.Http
{
    public class HttpHeaderCollection
    {
        private readonly Dictionary<string, HttpHeader> headers;

        public HttpHeaderCollection()
            => new Dictionary<string, HttpHeader>();
    }
}
