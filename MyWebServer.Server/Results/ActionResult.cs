using System.Collections.Generic;
using MyWebServer.Server.Http;

namespace MyWebServer.Server.Results
{
    public abstract class ActionResult : HttpResponse
    {
        protected ActionResult(HttpResponse response) 
            : base(response.StatusCode)
        {
            this.Content = response.Content;
            this.PrepareCookies(response.Cookies);
            this.PrepareHeaders(response.Headers);
        }

        protected HttpResponse Response { get; private init; }

        private void PrepareHeaders(IDictionary<string, HttpHeader> headers)
        {
            foreach (var header in headers.Values)
            {
                this.AddHeader(header.Name, header.Value);
            }
        }


        private void PrepareCookies(IDictionary<string, HttpCookie> cookies)
        {
            foreach (var cookie in cookies.Values)
            {
                this.AddCookie(cookie.Name, cookie.Value);
            }
        }
    }
}