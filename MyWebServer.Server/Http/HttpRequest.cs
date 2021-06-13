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


            var method = ParseHttpMethod(startLine[0]);
            var url = startLine[1];

            var headerLines = lines.Skip(1);

            var headerCollection = ParseHttpHeaders(headerLines);

            var bodyLines = lines.Skip(headerCollection.Count + 2).ToArray();

            var body = string.Join(newLine, bodyLines);

            return new HttpRequest
            {
                Method = method,
                Url = url,
                Headers = headerCollection,
                Body = body
            };
        }

        private static HttpMethod ParseHttpMethod(string method)
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

        private static HttpHeaderCollection ParseHttpHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HttpHeaderCollection();

            foreach (var headerLine in headerLines)
            {
                if (headerLine == string.Empty)
                {
                    break;
                }

                var headerParts = headerLine.Split(":", 2);

                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }
                
                var headerName = headerParts[0];
                var headerValue = headerParts[1].Trim();

                headerCollection.Add(headerName, headerValue);
            }

            return headerCollection;
        }
    }
}
