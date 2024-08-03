using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unique.DataContext;
using Unique.Models;
using Unique.Models.Member;



namespace Unique.Controllers
{

    public class CartController : Controller
    {

        [HttpGet]
        public ActionResult List()
        {
            

            using (var db = new UniqueDb())
            {
                int memberId = (int)HttpContext.Session.GetInt32("memberId");
           
                var cartList = db.Carts.Where(c=>c.memberId.Equals(memberId)).ToList();
                return View(cartList);

            }

          
        }



        [HttpPost]
        // GET: CartController
        public ActionResult List(int quantity, int price, int productId)
        {

            using (var db = new UniqueDb())
            {
                Cart cart = new Cart();

                cart.memberId = (int)HttpContext.Session.GetInt32("memberId");
                cart.quantity = quantity;
                cart.price = price; 
                cart.productId = productId;

                db.Carts.Add(cart);
                db.SaveChanges();

                var cartList =db.Carts.ToList();
                return View(cartList);

            }

              


               
        }


        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]

        public ActionResult Delete()
        {


            return View();

        }

    }
    
}
