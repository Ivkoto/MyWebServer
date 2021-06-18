﻿using MyWebServer.Server;
using MyWebServer.Server.Controllers;
using MyWebServer.Server.Http;

namespace MyWebServer.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(HttpRequest request) : base(request)
        {
        }


        public HttpResponse Index() => Text("Hello from Ivo!");

        public HttpResponse ToSoftuni() => Redirect("https://softuni.bg");

        public HttpResponse LocalRedirect() => Redirect("/cats");
    }
}
