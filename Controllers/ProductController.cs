
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
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
         

          


            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";

            var path = Path.Combine(_environment.WebRootPath, @"images\upload");
         

            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                path = Path.Combine(_environment.WebRootPath, @"images\upload" + fileName);

                await file.CopyToAsync(fileStream);
            }

            Console.WriteLine(path);

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

        [HttpGet]
        public ActionResult Detail(int productId)
        {

            using (var db = new UniqueDb())
            {

                var list = db.Products.FirstOrDefault(p=>p.productId.Equals(productId));
                return View(list);
            }
         
                
           


               

        }

        [HttpGet]
        public ActionResult List()
        {

            using (var db = new UniqueDb())
            {
             //   students = students.OrderByDescending(s => s.LastName);

                var list = db.Products.OrderByDescending(p => p.productId).ToList();
             
                return View(list);
            }




        }

        [HttpPost]
        public ActionResult SortList(String price)
        {

           

            Console.WriteLine(price);


            using (var db = new UniqueDb())
            {
               

                var list = db.Products.OrderByDescending(p => p.productId).ToList();

                return View(list);
            }




        }


        [HttpGet]
        public ActionResult Update()
        {



            return View();

        }




    }
}
