using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Unique.DataContext;
using Unique.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Unique.Controllers
{
    public class OrderController : Controller
    {
        [HttpGet]
        public ActionResult Order()
        {
            var db = new UniqueDb();

             int memberId = (int)HttpContext.Session.GetInt32("memberId");

            var cartList = from cart in db.Carts
                           join product in db.Products
                           on cart.productId equals product.productId

                           where cart.memberId == memberId
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


            int cartTotalPrice = cartList.Sum(s => s.totalPrice);


            ViewBag.CartTotalPrice = cartTotalPrice;
            return View(cartList);
        }


        [HttpPost]
        public ActionResult Payment([FromBody] PaymentData data)
        {
            var db = new UniqueDb();

            Cart cart = new Cart();

          

            if (data != null)
            {
                // Orders 테이블에 데이터 추가
                for (int i = 0; i < data.cartId?.Length; i++)
                {
                 

                    var order = new Order
                    {
                        memberId = data.memberId,
                        cartId = data.cartId[i],
                        productId = data.productId?[i],
                        price = data.price?[i],
                        totalPrice = data.totalPrice?[i],
                        impUid = data.impUid,
                        orderNum = data.orderNum,
                        orderPrice = data.orderPrice,
                        orderQuantity = data.orderQuantity?[i],
                        orderStatus = data.orderStatus,
                        

                    };

                 

                    db.Orders.Add(order);
                    db.SaveChanges();



               
                 
                }


                for (int i = 0; i < data.cartId?.Length; i++)
                {
                 
                    cart.cartId = data.cartId[i];
                    db.Carts.Remove(cart); //주문완료시 장바구니에 담아있던 리스트 삭제
                    db.SaveChanges();

                }


            }


            //1.여기서 cart 삭제해야함 

            return Json(data);
        }


        [HttpGet]
        public ActionResult List()
        {
             int memberId = (int)HttpContext.Session.GetInt32("memberId");


            var db = new UniqueDb();

            //   var myOrder = db.Orders.Where(o=>o.memberId.Equals(memberId)).ToList();
            var orderList = from order in db.Orders
                            join product in db.Products
                            on order.productId equals product.productId

                            where order.memberId == memberId
                            orderby order.orderId descending

                            select new
                            {

                                order.orderId,
                                order.productId,
                                order.memberId,
                                order.orderQuantity,
                                order.price,
                                order.totalPrice,
                                order.orderStatus,
                                product.productName,
                                product.productImage,
                                product.productImagePath,
                                product.productContent,


                            };



            return View(orderList);



        }

        //주문취소
        public IActionResult OrderDelete(int orderId)
        {
            using (var db = new UniqueDb())
            {
             

                var deleteOrder = db.Orders.FirstOrDefault(n => n.orderId.Equals(orderId));


                if (deleteOrder == null)
                {

                    return RedirectToAction("List", "Order");
                }

                // 기존 엔티티의 값을 업데이트
                deleteOrder.orderStatus = "주문취소";
             
                db.SaveChanges();
                return RedirectToAction("List", "Order");
            }

        

            

           
        }

    }
 



}
