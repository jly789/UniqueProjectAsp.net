
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Data.Entity;
using Unique.DataContext;
using Unique.Models;





namespace Unique.Controllers
{

    public class CartController : Controller
    {

        [HttpGet]
        public   ActionResult List()
        {


            var db = new UniqueDb();

           // int memberId = (int)HttpContext.Session.GetInt32("memberId");

            var cartList =  from cart in db.Carts
                               join product in db.Products
                               on cart.productId equals product.productId
                            
                            where cart.memberId == 2
                               orderby cart.cartId descending

                            select new
                               {
                             
                                cart.cartId,
                                   cart.productId,
                                   cart.memberId,
                                   cart.price,
                                   cart.totalPrice,
                                   cart.quantity,
                                   product.productName,
                                   product.productImage,
                                   product.productImagePath,
                                   product.productContent,


                               };


         int cartTotalPrice = cartList.Sum(s =>s.totalPrice);

          
          ViewBag.CartTotalPrice = cartTotalPrice;
            
            








            //  int memberId = (int)HttpContext.Session.GetInt32("memberId");



            // var cartList = db.Carts.Where(c=>c.memberId.Equals(memberId)).ToList();



            //var cartList = db.Carts.Include(c=>c.Product).ToList();

            //  var cartList = db.Carts.FromSqlRaw($"SELECT * FROM dbo.Carts").ToList();


            //LeftJoin: var query = from person in db.Carts
            //                      join order in db.Products
            //                      on person.productId equals order.productId into personOrders
            //                      from order in personOrders
            //                      select new
            //                      {
            //                          person.price,
            //                          order.productBrand
            //                      };

            //RightJoin: var query = from order in db.Carts 
            //                      join person in db.Products
            //                      on order.productId equals person.productId into orderPerson
            //                      from person in orderPerson.DefaultIfEmpty()
            //                       select new
            //                      {
            //                          person.productPrice,
            //                          order.quantity
            //                      };

            //    여기서 person은 프로덕트테이블 order은 카트테이블


            //sql Linq 조인
            //var cartList = from photo in db.Carts
            //               join person in db.Products
            //               on photo.productId equals person.productId

            //               select new
            //               {
            //                   photo.productId,
            //                   person.productContent
            //               };

            //sql Linq Where 조인
            //var cartList = from photo in db.Carts
            //               from person in db.Products.Where(p => p.productBrand =="조건문")
            //               select new
            //               {
            //                   photo.productId,
            //                   person.productContent
            //               };

            //sql Linq GroupBY조인 Person테이블기준으로 그룹
            //var cartList = from photo in db.Carts
            //               join person in db.Products
            //               on photo.productId equals person.productId into personOrders

            //               select new
            //               {


            //                   bb = personOrders.Count(),


            //               };



            //foreach (var item in cartList)
            //{

            //    Console.WriteLine(item.productId);
            //    Console.WriteLine(item.memberId);
            //    Console.WriteLine(item.price);
            //    Console.WriteLine(item.totalPrice);
            //    Console.WriteLine(item.quantity);
            //    Console.WriteLine(item.productImage);
            //    Console.WriteLine(item.productImagePath);
            //    Console.WriteLine(item.productContent);

            //}


            return View(cartList);
            




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
                cart.totalPrice = price * quantity;

                db.Carts.Add(cart);
                db.SaveChanges();

                var cartList =db.Carts.ToList();
                return RedirectToAction("List", "Cart");

            }

              


               
        }

        public ActionResult CartDelete(int cartId)
        {
            Cart cart = new Cart();
            cart.cartId = cartId;

            Console.WriteLine(cartId);
            using (var db = new UniqueDb())
            {
            
                db.Carts.Remove(cart);
                db.SaveChanges();
                return RedirectToAction("List","Cart");

            }
              
        }

        


     

        // POST: CartController/Delete/5
        [HttpPost]

        public ActionResult Delete()
        {


            return View();

        }

    }
    
}
