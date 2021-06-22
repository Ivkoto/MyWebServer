using System;
using MyWebServer.Server.Controllers;
using MyWebServer.Server.Http;
using MyWebServer.Server.Results;

namespace MyWebServer.Controllers
{
    public class AccountController : Controller
    {
        public AccountController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Login()
        {
            //var user = this.db.Users.Find(username, password);
            //if (user != null)
            //{
            //  this.Signin(userId);

            //  return Text("User is loged in");
            //}
            //return Text("Invalid credentials!");

            var someUserId = "MyUserId"; //Should come from the database.
            this.SignIn(someUserId);

            return Text("User authenticated!");

        }


        public HttpResponse Logout()
        {
            this.SignOut();

            return Text("User signed out!");
        }

        public HttpResponse AuthenticationCheck()
        {
            if (this.User.IsAuthenticated)
            {
                return Text($"Authenticated user: {this.User.Id}");
            }
            else
            {
                return Text("User is not authenticated!");
            }
        }
        

        public HttpResponse CookiesCheck()
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


        public HttpResponse SessionCheck()
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
