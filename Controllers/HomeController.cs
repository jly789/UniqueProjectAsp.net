using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using Unique.DataContext;
using Unique.Models;

namespace Unique.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
     

            using (var db = new UniqueDb())

            {
            var List = db.Products.OrderBy(p => p.productId).Take(20).ToList();
                return View(List);
            }
                
        }

        public IActionResult Login()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
