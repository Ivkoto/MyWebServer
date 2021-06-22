using MyWebServer.Controllers;
using MyWebServer.Server;
using System.Threading.Tasks;
using MyWebServer.Server.Controllers;

namespace MyWebServer
{
    public class Startup
    {
        public static async Task Main()
            => await new HttpServer(routes => routes
                    .MapGet<HomeController>("/", c => c.Index())
                    .MapGet<HomeController>("/Softuni", c => c.ToSoftuni())
                    .MapGet<HomeController>("/ToCats", c => c.LocalRedirect())
                    .MapGet<HomeController>("/Error", c => c.Error())
                    .MapGet<AnimalsController>("/Cats", c => c.Cats())
                    .MapGet<AnimalsController>("/Dogs", c => c.Dogs())
                    .MapGet<AnimalsController>("/Bunnies", c => c.Bunnies())
                    .MapGet<AnimalsController>("/Turtles", c => c.Turtles())
                    .MapGet<AccountController>("/Cookies", c => c.CookiesCheck())
                    .MapGet<AccountController>("/Session", c => c.SessionCheck())
                    .MapGet<AccountController>("/Login", c => c.Login())
                    .MapGet<AccountController>("/Logout", c => c.Logout())
                    .MapGet<AccountController>("/Authentication", c => c.AuthenticationCheck())
                    .MapGet<CatsController>("/Cats/Create", c => c.Create())
                    .MapPost<CatsController>("/Cats/Save", c => c.Save()))
                .Start();
    }
}
