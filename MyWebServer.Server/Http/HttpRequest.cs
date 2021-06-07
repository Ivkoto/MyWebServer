using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebServer.Server.Http
{
    public class HttpRequest
    {
        private const string newLine = "\r\n";


        public HttpMethod Method { get; private set; }

        public string Url { get; private set; }

        public HttpHeaderCollection Headers { get; private set; }

        public string Body { get; private set; }


        public static HttpRequest Parse(string request)
        {
            var lines = request.Split(newLine);

            var startLine = lines.First().Split(" ");


            var method = parseHttpMethod(startLine[0]);
            var url = startLine[1];

            var headerLines = lines.Skip(1);

            var headerCollection = ParseHttpHeaderCollection(lines.Skip(1));
        }

        private static HttpMethod parseHttpMethod(string method)
        {
            return method.ToUpper() switch
            {
                "GET" => HttpMethod.GET,
                "POST" => HttpMethod.POST,
                "PUT" => HttpMethod.PUT,
                "Delete" => HttpMethod.DELETE,
                _ => throw new InvalidOperationException($"Method {method} is not supported.")
            };
        }

        private static HttpHeaderCollection ParseHttpHeaderCollection(IEnumerable<string> headerLines)
        {
            var headerCollection = new HttpHeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == newLine)
                {
                    break;
                }

                var headerParts = headerLine.Split(":", 2);

                var header = new HttpHeader()
                {
                    Name = headerParts[0],
                    Value = headerParts[1].Trim()
                };
                
                headerCollection.Add(header);
            }

            return headerCollection;
        }

        //public static string[] GetStartLine(string request)
        //{

        //}
    }
}
