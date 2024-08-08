
using Microsoft.AspNetCore.Mvc;
using Unique.DataContext;
using Unique.Models;

namespace Unique.Controllers
{
    public class NoticeController : Controller
    {
       
        public ActionResult List() //공지 리스트 
        {
            using (var db = new UniqueDb())
            {
                var noticeList = db.Notices.OrderByDescending(n=>n.noticeDate).ToList();

                

                return View(noticeList);
            }

           
        }

       
        public ActionResult Detail(int noticeId) //공지 상세정보
        {

            using (var db = new UniqueDb()) { 

               
              var noticeDetail = db.Notices.FirstOrDefault(n=>n.noticeId.Equals(noticeId));



             

                return View(noticeDetail);
             

            }

         
        }

        [HttpGet]
        public ActionResult Register() //공지 등록리스트 출력
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
        public ActionResult Register(Notice notice) //공지 등록
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
        public ActionResult Update(Notice notice) // 공지 수정리스트 출력
        {

                return View(notice);
          
        }

        [HttpPost]
        public ActionResult Update(Notice notice,int id) //공지 수정
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
        public ActionResult Delete(Notice notice) // 공지삭제
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
