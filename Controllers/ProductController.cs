
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

        [HttpGet]
        public ActionResult Register() //상품 등록
        {


            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Register(Product model, IFormFile file) //상품 파일이미지 등록및 상품등록
        {


            var fileFullName = file.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}.{fileFullName[1]}";

            var path = Path.Combine(_environment.WebRootPath, @"images\upload");


            using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                path = Path.Combine(_environment.WebRootPath, @"images\upload" + fileName);

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
        public ActionResult CategoryCheck(String categoryName) //카테고리를 선택할시 해당 하위카테고리 리스트 체크
        {

            using (var db = new UniqueDb())
            {

                var CheckCategoryId = db.Categorys.FirstOrDefault(c => c.categoryName.Equals(categoryName));

                var SubCategoryList = db.SubCategorys.Where(s => s.categoryId.Equals(CheckCategoryId.categoryId)).ToList();



                return Json(SubCategoryList);
            }

        }

        [HttpGet]
        public ActionResult Detail(int productId) //상품 상세리스트
        {

            using (var db = new UniqueDb())
            {



                var list = db.Products.FirstOrDefault(p => p.productId.Equals(productId));

                var listImg = db.ProductImgs.Where(p => p.productId.Equals(productId)).ToList();

                ViewBag.ProductImgList = listImg;


                return View(list);
            }

        }

        [HttpGet]
        public ActionResult List(int pg = 1) //상품 총 리스트
        {

            using (var db = new UniqueDb())
            {

                var list = db.Products.OrderBy(p => p.productId).ToList();

                const int pageSize = 8;
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
        public ActionResult SortList(String price, String category, String subcategory, int pg = 1) //상품 가격별,카테고리별 정렬 리스트
        {

            if (price == "ALL" && category == "ALL") //가격및 카테고리가 모두 ALL일경우
            {
                using (var db = new UniqueDb())
                {

                    ViewBag.price = price;
                    ViewBag.category = category;
                    ViewBag.subcategory = subcategory;

                    var list = db.Products.OrderBy(p => p.productId).ToList();

                    const int pageSize = 8;
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

            if (price == "highPrice" && category == "ALL") // 가격이 높은순,카테고리 전부로 조회할시 
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
            if (price == "lowPrice" && category == "ALL") // 가격이 낮은순,카테고리 전부로 조회할시 
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


            if (price == "highPrice" && category != "ALL") // 가격이 높은순,카테고리 전부가 아닐시 조회
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
            if (price == "lowPrice" && category != "ALL") // 가격이 낮은순,카테고리 전부가 아닐시 조회할시 
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

            if (price == "ALL" && category != "ALL") // 가격상관없고,카테고리 전부가 아닐시 조회
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
        public ActionResult Update(int productId) //상품 수정리스트 출력
        {

            using (var db = new UniqueDb())
            {



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
        public ActionResult Update(Product Model) // 상품수정 출력
        {


            using (var db = new UniqueDb())
            {

                db.Update(Model);
                db.SaveChanges();
                return RedirectToAction("List", "Product");

            }


        }


        public ActionResult Delete(Product Model) //상품 삭제
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
