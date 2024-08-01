
using Microsoft.AspNetCore.Mvc;
using Unique.Models;
using Unique.Models.Member;


namespace Unique.Controllers
{
    public class ProductController : Controller
    {
        // GET: ProductController
        public ActionResult Index()
        {
         
          

            

            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();

        }

            [HttpPost]
            public ActionResult Register(int id)
            {
                return View();
            }



        }
}
