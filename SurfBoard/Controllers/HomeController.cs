using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurfBoard.Models;
using PasswordSecurity;

namespace SurfBoard.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
           

            return View();
        }

        public ActionResult _Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrateUser(string FirstName, string LastName, string password, string Email, string ConfirmPassword )
        {
            if (FirstName == "" )
            {
                var results = new { Result = "กรุณากรอกข้อมูลทั้งหมด", Poll = "" };
                return Json(results);
            }
            if (LastName == "")
            {
                var results = new { Result = "กรุณากรอกข้อมูลทั้งหมด", Poll = "" };
                return Json(results);
            }
            if (Email == "")
            {
                var results = new { Result = "กรุณากรอกข้อมูลทั้งหมด", Poll = "" };
                return Json(results);
            }
            if (password != ConfirmPassword)
            {

               
                var results = new { Result = "รหัสผ่านของคุณทั้งสองช่องไม่เหมือนกัน", Poll = "" };
                return Json(results);
            }
            using (ProjectJobEntities db = new ProjectJobEntities())

            {
                if (db.Users.Any(x => x.Email == Email))
                {
                   
                    var results = new { Result = "อีเมลของคุณถูกใช้แล้ว", Poll = "" };
                    return Json(results);
                }
                password = PasswordStorage.CreateHash(password);

                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                var random = new Random();
                var RandomID = new string(Enumerable.Repeat(chars, 13).Select(s => s[random.Next(s.Length)]).ToArray());
                
                db.Users.Add(new Users()
                {

                    FirstName = FirstName,
                    LastName = LastName,
                    Password = password,
                    Email = Email,
                    Ses_ID = RandomID

                });

                db.SaveChanges();

            }

            ModelState.Clear();
            var result = new { Result = "การสมัครสมาชิกสำเร็จ", Poll = 1 };
            return Json(result);
        }
        public ActionResult _Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(string password, string Email)
        {

            using (ProjectJobEntities db = new ProjectJobEntities())

            {
                if (Email != null && password != null)
                {
                    var model = db.Users.Where(x => x.Email == Email).SingleOrDefault();

                    if (model == null)
                    {
                        
                        var results = new { Result = "บัญชีนี้ไม่ได้ถูกลงทะเบียนในระบบ, กรุณาสมัครสมาชิก ", Poll = "" };
                        return Json(results);
                    }


                    bool result = PasswordStorage.VerifyPassword( password, model.Password);


                    if (result)
                    {


                        Session["User_ID"] = model.User_ID;
                        Session["FirstName"] = model.FirstName;
                        Session["LastName"] = model.LastName;
                        Session["Email"] = model.Email;
                        Session["Ses_ID"] = model.Ses_ID;
                        var results = new { Result = "เข้าสู่ระบบสำเร็จ", Poll = 1 };
                        return Json(results);
                    }
                    else
                    {

                        var results = new { Result = "อีเมลหรือรหัสผ่านของคุณผิด", Poll = "" };
                        return Json(results); ;


                    }
                }
                return View();
            }


        }

        public ActionResult Logout()
        {
            Session.Remove("User_ID");
            Session.Remove("FirstName");
            Session.Remove("LastName");
            Session.Remove("Email");
            Session.Remove("Ses_ID");
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Back()
        {
            return RedirectToAction("Index", "Home");

        }

    }
}