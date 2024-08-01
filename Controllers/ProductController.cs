
using Microsoft.AspNetCore.Mvc;
using Unique.DataContext;
using Unique.Models;
using Unique.Models.Member;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Unique.Controllers
{
    public class ProductController : Controller
    {

        private readonly IHostingEnvironment _environment;

        public ProductController(IHostingEnvironment environment)
        {
            _environment = environment;
        }


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
            public async Task<IActionResult> Register(Product model, IFormFile file)
            {
         

            var path = Path.Combine(_environment.WebRootPath, @"images\upload");


            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";

            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            model.memberId = 1;
            model.productImage = fileName;
            model.productImagePath = path;

            if (ModelState.IsValid)
            {

                using (var db = new UniqueDb())
                {


                    db.Products.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }

            }

                return View(model);
        }


       
        [HttpPost]
        public ActionResult CategoryCheck(String categoryName)
        {


            using (var db = new UniqueDb())
            {

                var CheckCategoryId = db.Categorys.FirstOrDefault(c => c.categoryName.Equals(categoryName));

                var SubCategoryList = db.SubCategorys.Where(s => s.categoryId.Equals(CheckCategoryId.categoryId)).ToList();

            

                return Json(SubCategoryList);
            }

        }





    }
}
