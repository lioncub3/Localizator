using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BestSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace BestSite.Controllers
{
    public class PostsController : Controller
    {
        public PostsController(IStringLocalizer<HomeController> localizer)
        {
            Localizer = localizer;
        }

        public IStringLocalizer<HomeController> Localizer { get; }

        public IActionResult Index()
        {
            //Post post = new Post();
            //post.Name = "";
            //post.Description = "";



            return Content(Localizer["Product"]);
        }
    }
}