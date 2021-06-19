﻿using MyWebServer.Models;
using MyWebServer.Models.Animals;
using MyWebServer.Server;
using MyWebServer.Server.Controllers;
using MyWebServer.Server.Http;
using MyWebServer.Server.Responses;

namespace MyWebServer.Controllers
{
    public class AnimalsController : Controller
    {

        public AnimalsController(HttpRequest request)
            : base(request)
        {
        }

        public HttpResponse Cats()
        {
            const string nameKey = "Name";
            const string ageKey = "Age";

            var query = this.Request.Query;

            var catName = query.ContainsKey(nameKey) ? query[nameKey] : "the cats";

            var catAge = query.ContainsKey(ageKey) ? int.Parse(query[ageKey]) : 0;

            var viewModel = new CatViewModel()
            {
                Name = catName,
                Age = catAge
            };

            return View(viewModel);

        }

        public HttpResponse Dogs() => View(new DogsViewModel
        {
            Name = "Pesho",
            Age = 125,
            Breed = "No such a dog"
        });

        public HttpResponse Bunnies() => View("Rabbits");

        public HttpResponse Turtles() => View("Animals/Wild/Turtles");
    }
}