
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using Unique.DataContext;
using Unique.Models;
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



                var list = db.Products.FirstOrDefault(p => p.productId.Equals(productId));

                var listImg = db.ProductImgs.Where(p => p.productId.Equals(productId)).ToList();

                ViewBag.ProductImgList = listImg;


                return View(list);
            }




            // var list = db.Products.Where(p => p.productCategoryName.Equals(subcategory)).OrderByDescending(p => p.productPrice).ToList();


        }

        [HttpGet]
        public ActionResult List(int pg = 1)
        {

            using (var db = new UniqueDb())
            {

                var list = db.Products.OrderByDescending(p => p.productId).ToList();

                const int pageSize = 4;
                if (pg < 1)
                    pg = 1;

                int recsCount = list.Count();

                var pager = new Pager(recsCount, pg, pageSize);

                int recSkip = (pg - 1) * pageSize;

                var data = list.Skip(recSkip).Take(pager.PageSize).ToList();

                this.ViewBag.Pager = pager;

                return View(data);
            }




        }

        [HttpPost]
        public ActionResult SortList(String price, String category, String subcategory,int pg=1)
        {

            if (price == "ALL" && category == "ALL")
            {
                using (var db = new UniqueDb())
                {

                    ViewBag.price = price;
                    ViewBag.category = category;
                    ViewBag.subcategory = subcategory;

                    var list = db.Products.OrderBy(p => p.productId).ToList();

                    const int pageSize = 4;
                    if (pg < 1)
                        pg = 1;

                    int recsCount = list.Count();

                    var pager = new Pager(recsCount, pg, pageSize);

                    int recSkip = (pg - 1) * pageSize;

                    var data = list.Skip(recSkip).Take(pager.PageSize).ToList();

                    this.ViewBag.Pager = pager;

                    return View(data);
                }

            }

            if (price == "highPrice" && category == "ALL")
            {



                using (var db = new UniqueDb())
                {

                    ViewBag.price = price;
                    ViewBag.category = category;
                    ViewBag.subcategory = subcategory;

                    var list = db.Products.OrderByDescending(p => p.productPrice).ToList();


                    return View(list);
                }


            }
            if (price == "lowPrice" && category == "ALL")
            {



                using (var db = new UniqueDb())
                {
                    ViewBag.price = price;
                    ViewBag.category = category;
                    ViewBag.subcategory = subcategory;
                    var list = db.Products.OrderBy(p => p.productPrice).ToList();

                    return View(list);
                }


            }


            if (price == "highPrice" && category != "ALL")
            {



                using (var db = new UniqueDb())
                {

                    ViewBag.price = price;
                    ViewBag.category = category;
                    ViewBag.subcategory = subcategory;

                    var list = db.Products.Where(p => p.productCategoryName.Equals(subcategory)).OrderByDescending(p => p.productPrice).ToList();

                    return View(list);
                }


            }
            if (price == "lowPrice" && category != "ALL")
            {



                using (var db = new UniqueDb())
                {
                    ViewBag.price = price;
                    ViewBag.category = category;
                    ViewBag.subcategory = subcategory;

                    var list = db.Products.Where(p => p.productCategoryName.Equals(subcategory)).OrderBy(p => p.productPrice).ToList();

                    return View(list);
                }


            }



            if (price == "ALL" && category != "ALL")
            {



                using (var db = new UniqueDb())
                {
                    ViewBag.price = price;
                    ViewBag.category = category;
                    ViewBag.subcategory = subcategory;

                    var list = db.Products.Where(p => p.productCategoryName.Equals(subcategory)).ToList();

                    return View(list);
                }


            }











            using (var db = new UniqueDb())
            {
                ViewBag.price = price;
                ViewBag.category = category;
                ViewBag.subcategory = subcategory;

                var list = db.Products.OrderByDescending(p => p.productId).ToList();

                return View(list);
            }




        }


        [HttpGet]
        public ActionResult Update(int productId)
        {

            using (var db = new UniqueDb())
            {

                //  var list = db.Products.FirstOrDefault(p => p.productId.Equals(productId));

                var list = db.Products.FirstOrDefault(p => p.productId.Equals(productId));

                var listImg = db.ProductImgs.Where(p => p.productId.Equals(productId)).ToList();

                ViewBag.ProductImgList = listImg;

                foreach (var item in listImg)
                {

                }
                return View(list);
            }




        }

        [HttpPost]
        public ActionResult Update(Product Model)
        {

            Console.WriteLine(Model.productName);
            Console.WriteLine(Model.productId);
            Console.WriteLine(Model.productPrice);
            Console.WriteLine(Model.productContent);

            using (var db = new UniqueDb())
            {



                db.Update(Model);
                db.SaveChanges();
                return RedirectToAction("List", "Product");

            }




        }



        public ActionResult Delete(Product Model)
        {

            using (var db = new UniqueDb())
            {
                var productImgId = db.ProductImgs.Where(p => p.productId.Equals(Model.productId)).ToList();


                db.RemoveRange(productImgId);
                db.SaveChanges();

                db.Products.Remove(Model);
                db.SaveChanges();
                return RedirectToAction("List", "Product");
            }



        }
    }





}
