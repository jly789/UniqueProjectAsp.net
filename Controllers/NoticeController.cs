
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Unique.DataContext;
using Unique.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Unique.Controllers
{
    public class NoticeController : Controller
    {
        // GET: NoticeController
        public ActionResult List()
        {
            using (var db = new UniqueDb())
            {
                var noticeList = db.Notices.OrderByDescending(n=>n.noticeDate).ToList();


                return View(noticeList);
            }

           
        }

        // GET: NoticeController/Details/5
        public ActionResult Detail(int noticeId)
        {

          


            using (var db = new UniqueDb()) { 

               
              var noticeDetail = db.Notices.FirstOrDefault(n=>n.noticeId.Equals(noticeId));



             

                return View(noticeDetail);
             

            }

         
        }

        [HttpGet]
        public ActionResult Register()
        {
          
            int? memberId = HttpContext.Session.GetInt32("memberId");

          
            if (memberId.HasValue)
            {
               
                ViewBag.MemberId = memberId.Value;

               
                return View();
            }

            return View();
        }


        [HttpPost]
        public ActionResult Register(Notice notice)
        {
            
            if (ModelState.IsValid)
            {

                using (var db = new UniqueDb())
                {
                    notice.noticeDate = DateTime.Now;
                    db.Notices.Add(notice);
                    db.SaveChanges();


                    return RedirectToAction("List", "Notice");
                }
            }
            return View(notice);
        }



        [HttpGet]
        public ActionResult Update(Notice notice)
        {


                return View(notice);
          

         
        }

        [HttpPost]
        public ActionResult Update(Notice notice,int id)
        {

            if (ModelState.IsValid)
            {
                Console.WriteLine(notice.noticeId);

                using (var db= new UniqueDb())
                {
                    var updateNotice = db.Notices.FirstOrDefault(n => n.noticeId.Equals(notice.noticeId));
                    

                    if (updateNotice == null)
                    {
                       
                        return View(notice);
                    }

                    // 기존 엔티티의 값을 업데이트
                    updateNotice.noticeTitle = notice.noticeTitle;
                    updateNotice.noticeContent = notice.noticeContent;
                    updateNotice.noticeDate = DateTime.Now;
                    db.SaveChanges();
                 
                }

                return Redirect("List");
            }

            return View(notice);



        }

        [HttpPost]
        public ActionResult Delete(Notice notice)
        {

            using (var db = new UniqueDb())
            {
                db.Notices.Remove(notice);  
                db.SaveChanges();
                return Redirect("List");
            }


        }
    }
}
