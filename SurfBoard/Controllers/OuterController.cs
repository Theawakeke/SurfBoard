using SurfBoard.Business;
using SurfBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurfBoard.Controllers
{
    public class OuterController : Controller
    {
        // GET: Outer
        public ActionResult EnterEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LinkCode(string Code)
        {
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                var code = Code.ToUpper();
                var eventlist = from ev in db.Event
                                join us in db.Users on ev.Users_ID equals us.User_ID
                                where ev.Event_Code.Contains(code)
                                select new ViewNameEvent
                                {
                                    Event = ev,
                                    Users = us
                                };
                var eventlist2 = eventlist.ToList();
                var list = eventlist2.Select(x => new ViewEventPoll() { LastName = x.Users.LastName, FirstName = x.Users.FirstName, Event_ID = x.Event.Event_ID, Event_Code = x.Event.Event_Code, Event_Name = x.Event.Event_Name, End_Date = x.Event.End_Date, Start_Date = x.Event.Start_Date, Event_Password = x.Event.Event_Password }).OrderByDescending(q => q.Event_ID).ToList();



                return Json(list);
            }

        }
        [HttpPost]
        public ActionResult LinkQuestionPage(int ID)
        {
            using (ProjectJobEntities db = new ProjectJobEntities())

            {
                var model = db.Event.Where(x => x.Event_ID == ID).SingleOrDefault();

                Session["Event_ID"] = ID;

                Session["Event_Code"] = model.Event_Code;

            }
            return Json(new { Url = "QuestionsPage" });

        }

        public ActionResult FindSession()
        {
            var Ses_ID = Convert.ToString(Session["Ses_ID"]);

            if (Ses_ID != "")
            {
                var FindSes_ID = new { CheckSes_ID = "0" };
                return Json(FindSes_ID, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var FindSes_ID = new { CheckSes_ID = "1" };
                return Json(FindSes_ID, JsonRequestBehavior.AllowGet);
            }


        }

        public ActionResult SetSessionOuter(string OuterName)
        {
            var Name = OuterName;

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var NewOuterID = new string(Enumerable.Repeat(chars, 13).Select(s => s[random.Next(s.Length)]).ToArray());

            Session["FirstName"] = Name;
            Session["Ses_ID"] = NewOuterID;

            var React = new { clear = "0" };
            return Json(React, JsonRequestBehavior.AllowGet);

        }
        public ActionResult QuestionsPage()
        {
            var eid = Convert.ToInt32(Session["Event_ID"]);

            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                var findActive = from ev in db.Event
                                 join po in db.Polls on ev.Event_ID equals po.Event_ID
                                 where ev.Event_ID == eid
                                 select new Eventpoll
                                 {
                                     Event = ev,
                                     Poll = po
                                 };
                //var PollActive = findActive.SingleOrDefault(x => x.Poll.IsActive == true);

                //ViewBag.Active = PollActive;
                ViewBag.ThisActive = eid;
               
                return View();


            }
        }
        public JsonResult FindIsActive(int EventID)
        {

            var session = Convert.ToString(Session["Ses_ID"]);

            using (ProjectJobEntities db = new ProjectJobEntities())
            {

                var findActive = from ev in db.Event
                                 join po in db.Polls on ev.Event_ID equals po.Event_ID
                                 where ev.Event_ID == EventID
                                 select new Eventpoll
                                 {
                                     Event = ev,
                                     Poll = po
                                 };
                var numActive = findActive.Where(x => x.Poll.IsActive == true).ToList();
                var CountActive = numActive.Count();
                


                if (CountActive == 1)
                {
                    var PollActive = findActive.FirstOrDefault(x => x.Poll.IsActive == true);
                

                    if (PollActive != null)
                    {

                        var React = new { CheckAct = "1", ID = PollActive.Poll.Polls_ID, Type = PollActive.Poll.Polls_Type_ID };
                        return Json(React, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        var React = new { CheckAct = "0" };
                        return Json(React, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    var React = new { CheckAct = "0" };
                    return Json(React, JsonRequestBehavior.AllowGet);
                }
            }


        }
        public JsonResult FindHasSession()
        {

            var session = Convert.ToString(Session["Ses_ID"]);
            var SessionPollID = Convert.ToInt32(Session["Poll_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {

                var HasSession = db.Outer.Where(x => x.OuterSes_ID == session && x.Polls_ID == SessionPollID).Count();

                var PollActive = db.Polls.FirstOrDefault(x => x.Polls_ID == SessionPollID);

                if (HasSession != 0)
                {
                    var React = new { Checksession = "1", ID = PollActive.Polls_ID, Type = PollActive.Polls_Type_ID };
                    return Json(React, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var React = new { Checksession = "2" };
                    return Json(React, JsonRequestBehavior.AllowGet);
                }


            }


        }


        public ActionResult _QRate(int? pid)
        {
            var ID = Convert.ToInt32(Session["Event_ID"]);


            using (ProjectJobEntities db = new ProjectJobEntities())
            {



                var pol = db.Polls.Where(x => x.Polls_ID == pid).SingleOrDefault();
                ViewBag.whatRate = pol;

                var numLimit = pol.LimitPerson;
                var numusercount = db.Outer.Where(x => x.Polls_ID == pid).Count();
                if (numLimit == numusercount)
                {
                    ViewBag.Limitcheck = 1;
                }
                else
                {
                    ViewBag.Limitcheck = 0;
                }

                List<Polls> QRate = new List<Polls>();
                QRate = db.Polls.Where(x => x.Event_ID == ID && x.Polls_ID == pid).ToList();

                
                Session["Poll_ID"] = pid;

                //viewbagdata

                ViewBag.MyQRate = QRate;

                return View();
            }
        }
        public ActionResult _QMulti(int? pid)
        {
            var ID = Convert.ToInt32(Session["Event_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                List<Polls> QMulti = new List<Polls>();
                QMulti = db.Polls.Where(x => x.Event_ID == ID && x.Polls_ID == pid).ToList();

                //viewbagdata
                ViewBag.MyQMulti = QMulti;
                var Is = db.Polls.Where(x => x.Polls_ID == pid).Select(x => x.IsMulti).ToArray();
                ViewBag.IsMulti = Is;
                var Max = db.Polls.Where(x => x.Polls_ID == pid).Select(x => x.MaxMulti).ToArray();
                ViewBag.MaxLimit = Max;

                var Multi = db.Options.Where(x => x.Polls_ID == pid).ToList();
                ViewBag.MyChoose = Multi;

                var numLimit = QMulti.Select(x => x.LimitPerson).Single();
                var numusercount = db.Outer.Where(x => x.Polls_ID == pid).Count();
                if (numLimit == numusercount)
                {
                    ViewBag.Limitcheck = 1;
                }
                else
                {
                    ViewBag.Limitcheck = 0;
                }

                Session["Poll_ID"] = pid;

                return PartialView();
            }
        }
        public ActionResult _QText(int? pid)
        {
            var ID = Convert.ToInt32(Session["Event_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                List<Polls> QText = new List<Polls>();
                QText = db.Polls.Where(x => x.Event_ID == ID && x.Polls_ID == pid).ToList();

                var numLimit = QText.Select(x => x.LimitPerson).Single();
                var numusercount = db.Outer.Where(x => x.Polls_ID == pid).Count();
                if (numLimit == numusercount)
                {
                    ViewBag.Limitcheck = 1;
                }
                else
                {
                    ViewBag.Limitcheck = 0;
                }
                //viewbagdata
                ViewBag.MyQText = QText;

                Session["Poll_ID"] = pid;

                return PartialView();
            }
        }
        public ActionResult _QCloud(int? pid)
        {

            var ID = Convert.ToInt32(Session["Event_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                List<Polls> QCloud = new List<Polls>();
                QCloud = db.Polls.Where(x => x.Event_ID == ID && x.Polls_ID == pid).ToList();

                var numLimit = QCloud.Select(x => x.LimitPerson).Single();
                var numusercount = db.Outer.Where(x => x.Polls_ID == pid).Count();
                if (numLimit == numusercount)
                {
                    ViewBag.Limitcheck = 1;
                }
                else
                {
                    ViewBag.Limitcheck = 0;
                }
                //viewbagdata

                ViewBag.MyQCloud = QCloud;

                Session["Poll_ID"] = pid;

                return PartialView();
            }
        }
        [HttpPost]
        public ActionResult AddAnswer(int PollTypes, int PollID, string Options, int Rate, string Text, int MaxMulti)
        {

            if (Text == "")
            {
                Text = null;
            }

            if (PollTypes == 1 && Options == "0")
            {
                var result = new { Result = " การเพิ่มคำตอบไม่สำเร็จ", Check = 0 };

                return Json(result);
            }
            if (PollTypes == 4 && Rate == 0)
            {
                var result = new { Result = " การเพิ่มคำตอบไม่สำเร็จ", Check = 0 };

                return Json(result);
            }
            if (PollTypes == 2 && Text == null)
            {
                var result = new { Result = " การเพิ่มคำตอบไม่สำเร็จ", Check = 0 };

                return Json(result);
            }
            if (PollTypes == 3 && Text == null)
            {
                var result = new { Result = " การเพิ่มคำตอบไม่สำเร็จ", Check = 0 };

                return Json(result);
            }
            if (PollTypes == 1)
            {
                string[] OPtsr = Options.Trim().Split(' ');
                int CheckMax = OPtsr.Length;
                if (CheckMax > MaxMulti)
                {
                    var result = new { Result = "กรุณาเลือกตัวเลือกแค่ " + MaxMulti + " ตัวเลือก", Check = 0 };

                    return Json(result);
                }
            }

            if (PollTypes == 3 && Text != null)
            {
                Text = Text.ToLower();

            }


            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                CPC bussiness = new CPC();
                bool IsDupicate = bussiness.CheckPollClose(PollID);
                if (IsDupicate)
                {
                    Outer Pmodel = new Outer()
                    {

                        Polls_ID = PollID,
                        Outer_Text = Text,
                        Outer_Rating = Rate,
                        Outer_Name = Convert.ToString(Session["FirstName"]),
                        OuterSes_ID = Convert.ToString(Session["Ses_ID"])

                    };
                    db.Outer.Add(Pmodel);
                    if (PollTypes == 1)
                    {

                        string[] OPtsr = Options.Trim().Split(' ');
                        foreach (var poo in OPtsr)
                        {
                            int Op = Convert.ToInt32(poo);
                            OuterOptions Omodel = new OuterOptions()
                            {
                                Outer_ID = Pmodel.Outer_ID,
                                Options_ID = Op
                            };

                            db.OuterOptions.Add(Omodel);
                        }
                    }
                    db.SaveChanges();


                    var result = new { Result = " การเพิ่มคำตอบสำเร็จ", id = Pmodel.Polls_ID, type = PollTypes, Check = 1 };

                    return Json(result);
                }
                else
                {
                    var result = new { Result = " กิจกรรมนี้ปิดไปแล้ว, กรุณาหากิจกรรมอื่น", Check = 2 };

                    return Json(result);
                }
            }
        }
        public ActionResult CallSignalR(int id, int type)
        {
            var checkid = Convert.ToInt32(Session["Event_ID"]);
            MyHub.Hello(id, type, checkid);

            return Json("Success", JsonRequestBehavior.AllowGet);
        }
        public ActionResult _SetMulti(int? pid)
        {
            var ID = Convert.ToInt32(Session["Event_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                List<Polls> QText = new List<Polls>();
                QText = db.Polls.Where(x => x.Event_ID == ID && x.Polls_ID == pid).ToList();

                //viewbagdata
                ViewBag.MyQText = QText;

                return PartialView();
            }
        }
        public ActionResult Back()
        {

            return RedirectToAction("Index", "Home");
        }
        public ActionResult BackEvent()
        {
            return RedirectToAction("Home", "Event");

        }

        public ActionResult validatePassword(int EventID, string Password)
        {

            using (ProjectJobEntities db = new ProjectJobEntities())

            {

                var model = db.Event.Where(x => x.Event_ID == EventID).SingleOrDefault();
                var dbPassword = model.Event_Password.ToString();

                if (Password != dbPassword)
                {
                    var results = new { Result = "รหัสผ่านกิจกรรมผิด", Pascheck = "" };
                    return Json(results);
                }
                else
                {
                    var results = new { evnet_ID = EventID, Pascheck = "1" };

                    return Json(results);
                }
            }


        }
        public ActionResult _SetshowRate(int? checkid)
        {
            var ID = Convert.ToInt32(Session["Event_ID"]);


            using (ProjectJobEntities db = new ProjectJobEntities())
            {



                var pol = db.Polls.Where(x => x.Polls_ID == checkid).SingleOrDefault();
                ViewBag.whatRate = pol;



                List<Polls> QRate = new List<Polls>();
                QRate = db.Polls.Where(x => x.Event_ID == ID && x.Polls_ID == checkid).ToList();

                //viewbagdata
                ViewBag.MyQRate = QRate;

                return View();
            }
        }
        public ActionResult _SetshowMulti(int? checkid)
        {
            var ID = Convert.ToInt32(Session["Event_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                List<Polls> QMulti = new List<Polls>();
                QMulti = db.Polls.Where(x => x.Event_ID == ID && x.Polls_ID == checkid).ToList();

                //viewbagdata
                ViewBag.MyQMulti = QMulti;
                var Is = db.Polls.Where(x => x.Polls_ID == checkid).Select(x => x.IsMulti).ToArray();
                ViewBag.IsMulti = Is;
                var Max = db.Polls.Where(x => x.Polls_ID == checkid).Select(x => x.MaxMulti).ToArray();
                ViewBag.MaxLimit = Max;

                var Multi = db.Options.Where(x => x.Polls_ID == checkid).ToList();
                ViewBag.MyChoose = Multi;


                return PartialView();
            }
        }
        public ActionResult _SetshowText(int? checkid)
        {
            var ID = Convert.ToInt32(Session["Event_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                List<Polls> QText = new List<Polls>();
                QText = db.Polls.Where(x => x.Event_ID == ID && x.Polls_ID == checkid).ToList();


                //viewbagdata
                ViewBag.MyQText = QText;

                return PartialView();
            }
        }
        public ActionResult _SetshowCloud(int? checkid)
        {

            var ID = Convert.ToInt32(Session["Event_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                List<Polls> QCloud = new List<Polls>();
                QCloud = db.Polls.Where(x => x.Event_ID == ID && x.Polls_ID == checkid).ToList();


                //viewbagdata
                ViewBag.MyQCloud = QCloud;

                return PartialView();
            }
        }
    }
}
