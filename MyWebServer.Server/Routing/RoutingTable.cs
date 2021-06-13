using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;
using System.Collections.Generic;

namespace MyWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, HttpResponse>> routes;

        public RoutingTable() 
            => this.routes = new()
            {
                [HttpMethod.GET] = new(),
                [HttpMethod.POST] = new(),
                [HttpMethod.PUT] = new(),
                [HttpMethod.DELETE] = new()
            };

        public IRoutingTable Map(HttpMethod method, string path, HttpResponse response)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(response, nameof(response));

            this.routes[method][path] = response;

            return this;
        }

        public IRoutingTable MapGet(string path, HttpResponse response)
            => Map(HttpMethod.GET, path, response);

        public IRoutingTable MapPost(string path, HttpResponse response)
            => Map(HttpMethod.POST, path, response);

        public HttpResponse MatchRequest(HttpRequest request)
        {
            var method = request.Method;
            var path = request.Path;

            if (!this.routes.ContainsKey(method) || !this.routes[method].ContainsKey(path))
            {
                return new NotFoundResponse();
            }

            return this.routes[method][path];
        }
    }
}
