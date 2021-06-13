using System;
using System.Text;

namespace MyWebServer.Server.Http
{
    public abstract class HttpResponse
    {
        public HttpResponse(HttpStatusCode statusCode)
        {
            this.StatusCode = statusCode;

            this.Headers.Add("Server", "My Web Server");
            this.Headers.Add("Date", $"{DateTime.Now.Date:R}");
        }

        public HttpStatusCode StatusCode { get; init; }

        public HttpHeaderCollection Headers { get; } = new();

        public string Content { get; init; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"HTTP/1.1 {(int) this.StatusCode} {this.StatusCode}");

            foreach (var header in this.Headers)
            {
                result.AppendLine(header.ToString());
            }

            if (!string.IsNullOrEmpty(this.Content))
            {
                result.AppendLine();
                result.Append(this.Content);
            }

            return result.ToString();
        }
    }
}
