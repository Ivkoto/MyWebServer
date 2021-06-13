using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using System;
using System.Collections.Generic;
using MyWebServer.Server.Responses;

namespace MyWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, HttpResponse>> routes;

        public RoutingTable() =>
            this.routes = new()
            {
                [HttpMethod.GET] = new(),
                [HttpMethod.POST] = new(),
                [HttpMethod.PUT] = new(),
                [HttpMethod.DELETE] = new()
            };

        public IRoutingTable Map(string url, HttpMethod method, HttpResponse response) =>
            method switch
            {
                HttpMethod.GET => this.MapGet(url, response),
                _ => throw new InvalidOperationException($"Method {method} is not supported.")
            };

        public IRoutingTable MapGet(string url, HttpResponse response)
        {
            Guard.AgainstNull(url, nameof(url));
            Guard.AgainstNull(response, nameof(response));

            this.routes[HttpMethod.GET][url] = response;

            return this;
        }

        public HttpResponse MatchRequest(HttpRequest request)
        {
            var method = request.Method;
            var url = request.Url;

            if (!this.routes.ContainsKey(method) || !this.routes[method].ContainsKey(url))
            {
                return new NotFoundResponse();
            }

            return this.routes[method][url];
        }
    }
}
