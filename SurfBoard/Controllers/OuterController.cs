﻿using SurfBoard.Business;
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
                var eventlist = db.Event.Where(x => x.Event_Code.Contains(code)).ToList();
                var list = eventlist.Select(x => new EventViewModel() { Event_ID = x.Event_ID, Event_Code = x.Event_Code, Event_Name = x.Event_Name, End_Date = x.End_Date, Start_Date = x.Start_Date }).OrderByDescending(q => q.Event_ID).ToList();



                return Json(list);
            }

        }
        [HttpPost]
        public ActionResult LinkQuestionPage(int ID)
        {
            var code = Convert.ToString(Session["Event_Code"]);
            using (ProjectJobEntities db = new ProjectJobEntities())

            {
                var model = db.Event.Where(x => x.Event_ID == ID).SingleOrDefault();

                Session["Event_ID"] = ID;

                Session["Event_Code"] = model.Event_Code;

            }
            return Json(new { Url = "QuestionsPage" });

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
                    var React = new { CheckAct = "3" };
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

                List<Polls> QRate = new List<Polls>();
                QRate = db.Polls.Where(x => x.Event_ID == ID && x.Polls_ID == pid).ToList();

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

                //viewbagdata
                ViewBag.MyQText = QText;

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

                //viewbagdata
                ViewBag.MyQCloud = QCloud;

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
                var result = new { Result = "Add Answer Failed." + "\r\n" + " การเพิ่มคำตอบไม่สำเร็จ", Check = 0 };

                return Json(result);
            }
            if (PollTypes == 4 && Rate == 0)
            {
                var result = new { Result = "Add Answer Failed." + "\r\n" + " การเพิ่มคำตอบไม่สำเร็จ", Check = 0 };

                return Json(result);
            }
            if (PollTypes == 2 && Text == null)
            {
                var result = new { Result = "Add Answer Failed." + "\r\n" + " การเพิ่มคำตอบไม่สำเร็จ", Check = 0 };

                return Json(result);
            }
            if (PollTypes == 3 && Text == null)
            {
                var result = new { Result = "Add Answer Failed." + "\r\n" + " การเพิ่มคำตอบไม่สำเร็จ", Check = 0 };

                return Json(result);
            }
            if (PollTypes == 1)
            {
                string[] OPtsr = Options.Trim().Split(' ');
                int CheckMax = OPtsr.Length;
                if (CheckMax > MaxMulti)
                {
                    var result = new { Result = "Please Choose only " + MaxMulti + " Answers", Check = 0 };

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
                        Outer_Rating = Rate

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


                    var result = new { Result = "Add Answer Succesfully." + "\r\n" + " การเพิ่มคำตอบสำเร็จ", id = Pmodel.Polls_ID, type = PollTypes, Check = 1 };

                    return Json(result);
                }
                else
                {
                    var result = new { Result = "This Event is no longer active. Please find another Event" + "\r\n" + " กิจกรรมนี้ปิดไปแล้ว, กรุณาหากิจกรรมอื่น", Check = 2 };

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

    }
}