﻿using System;
using MyWebServer.Server.Controllers;
using MyWebServer.Server.Http;

namespace MyWebServer.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(HttpRequest request)
            : base(request)
        {
        }


        public HttpResponse ActionWithCookies()
        {
            const string cookieName = "My-Cookie";

            if (this.Request.Cookies.ContainsKey(cookieName))
            {
                var cookie = this.Request.Cookies[cookieName];

                return Text($"Cookie already exist - {cookie}");
            }

            this.Response.AddCookie(cookieName, "My-Value");
            this.Response.AddCookie("My-SecondCookie", "My-SecondValue");

            return Text("Cookies set!");
        }


        public HttpResponse ActionWithSession()
        {
            const string currentDateKey = "CurrentDate";

            if (this.Request.Session.ContainsKey(currentDateKey))
            {
                var curDate = this.Request.Session[currentDateKey];

                return Text($"Stored date: {curDate}");
            }

            this.Request.Session[currentDateKey] = DateTime.UtcNow.ToString();

            return Text("Current date stored!");
        }
    }
}