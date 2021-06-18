﻿using MyWebServer.Server.Common;
using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;
using System;
using System.Collections.Generic;

namespace MyWebServer.Server.Routing
{
    public class RoutingTable : IRoutingTable
    {
        private readonly Dictionary<HttpMethod, Dictionary<string, Func<HttpRequest, HttpResponse>>> routes;

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
            Guard.AgainstNull(response, nameof(response));

            return this.Map(method, path, request => response);
        }


        public IRoutingTable Map(HttpMethod method, string path, Func<HttpRequest, HttpResponse> responseFunction)
        {
            Guard.AgainstNull(path, nameof(path));
            Guard.AgainstNull(responseFunction, nameof(responseFunction));

            this.routes[method][path] = responseFunction;

            return this;
        }


        public IRoutingTable MapGet(string path, HttpResponse response)
            => MapGet(path, request => response);


        public IRoutingTable MapGet(string path, Func<HttpRequest, HttpResponse> responseFunction)
            => this.Map(HttpMethod.GET, path, responseFunction);


        public IRoutingTable MapPost(string path, HttpResponse response)
            => MapPost(path, request => response);

        

        public IRoutingTable MapPost(string path, Func<HttpRequest, HttpResponse> responseFunction)
            => this.Map(HttpMethod.POST, path, responseFunction);


        public HttpResponse ExecuteRequest(HttpRequest request)
        {
            var method = request.Method;
            var path = request.Path;

            if (!this.routes.ContainsKey(method) || !this.routes[method].ContainsKey(path))
            {
                return new NotFoundResponse();
            }

            var responseFunction = this.routes[method][path];

            return responseFunction(request);
        }
    }
}
