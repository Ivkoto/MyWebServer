﻿using MyWebServer.Server.Http;

namespace MyWebServer.Server.Responses
{
    public class NotFoundResponse : HttpResponse
    {
        public NotFoundResponse()
            : base(Http.HttpStatusCode.NotFound)
        {
        }
    }
}
