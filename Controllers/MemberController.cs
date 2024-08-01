﻿
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;
using Unique.DataContext;
using Unique.Models;
using Unique.Models.Member;


namespace Unique.Controllers
{
    public class MemberController : Controller
    {
        // GET: MemberController
        public ActionResult Index()
        {
          
            Console.WriteLine("asdas");

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult LogOut()

        {
            HttpContext.Session.Remove("memberId");

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(MemberLogin model)
        {

           
            if (ModelState.IsValid)
            {

                using (var db = new UniqueDb())
                {
                    var member = db.Members.FirstOrDefault(m => m.userId.Equals(model.userId) && m.pwd.Equals(model.pwd));

                    if (member != null)
                    {

                        HttpContext.Session.SetInt32("memberId", member.memberId);
                        HttpContext.Session.SetString("userId", member.userId);

                        return RedirectToAction("Index", "Home");
                    }

                }

                ModelState.AddModelError(string.Empty, "사용자 ID 혹은 비밀번호가 올바르지 않습니다.");
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();

        }

        //아이디중복체크
        [HttpPost]
        public ActionResult IdCheck(String userId)
        {


            using (var db = new UniqueDb())
            {

                var CheckuserId = db.Members.FirstOrDefault(m => m.userId.Equals(userId));

                return Json(CheckuserId);
            }

        }

        [HttpPost]
        public ActionResult Register(Member model)
        {
            if (ModelState.IsValid)
            {

                String pattern = @"^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$";
                String Msg = "이메일 형식이 올바르지 않습니다";
                bool isValid = Regex.IsMatch(model.email, pattern);
                if (isValid) { 
                 
                }
                else {

                    ViewBag.ErrorMessage = Msg;
                    return View(model);
                }
                using (var db = new UniqueDb())
                {



                    var userId = db.Members.FirstOrDefault(m => m.userId.Equals(model.userId));
                    var nickName = db.Members.FirstOrDefault(m => m.nickName.Equals(model.nickName));
                    var tel = db.Members.FirstOrDefault(m => m.tel.Equals(model.tel));
                    var email = db.Members.FirstOrDefault(m => m.email.Equals(model.email));




                    if (userId != null || nickName != null || tel != null || email != null)
                    {

                        ViewBag.userId = userId;
                        ViewBag.nickName = nickName;
                        ViewBag.tel = tel;
                        ViewBag.email = email;
                        return View(model);
                    }



                    else
                    {



                        db.Members.Add(model);
                        db.SaveChanges();

                    }
                }
                return Redirect("Login");


            }


            return View(model);
        }


        public ActionResult SearchUserId()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SearchUserId(Member model)
        {
          
          

            using (var db = new UniqueDb())

            { 
                var id  = db.Members.FirstOrDefault(m => m.userName.Equals(model.userName) && m.pwd.Equals(model.pwd));

                if (id != null) {


                   



                   // Console.WriteLine(ViewBag.id);
                    ViewBag.userId = id.userId;
                   // model.userId = id.userId;
                    return View(model);
                }
                 
                }
                ModelState.AddModelError(string.Empty, "해당 사용자 아이디는 존재하지 않습니다.");
             
         

            return View(model);
        }
        [HttpGet]
        public ActionResult SearchPwd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SearchPwd(Member model)
        {



            using (var db = new UniqueDb())

            {
                var pwd = db.Members.FirstOrDefault(m => m.userId.Equals(model.userId) && m.email.Equals(model.email));

                if (pwd != null)
                {






                    // Console.WriteLine(ViewBag.id);
                    ViewBag.Pwd = pwd.pwd;
                    // model.userId = id.userId;
                    return View(model);
                }

            }
            ModelState.AddModelError(string.Empty, "해당 사용자의 비밀번호는 존재하지 않습니다.");



            return View(model);
        }



    }
}
