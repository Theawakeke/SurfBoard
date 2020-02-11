using SurfBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SurfBoard.Business;

namespace SurfBoard.Controllers
{
    public class EventController : Controller
    {
        // GET: Event
        public ActionResult Home()
        {
            var ID = Convert.ToInt32(Session["User_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                List<Event> eventlist = new List<Event>();

                eventlist = db.Event.Where(x => x.Users_ID == ID).OrderByDescending(q => q.Event_ID).ToList();

                //viewbagdata
                ViewBag.MyEventlist = eventlist;

                ViewBag.CountList = eventlist.Count();
                return View();
            }
        }

        public ActionResult _CreateView()
        {
            return View();
        }

        public ActionResult RandomCode()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Event eventmodel)
        {
            if (eventmodel.Event_Name == null)
            {
                var result = new { Result = "Error in Your Information" + "\r\n" + " เกิดความผิดในการกรอกข้อมูลของคุณ", Event = "" };
                return Json(result);
            }
            if (eventmodel.Event_Code == null)
            {
                var result = new { Result = "Error in Your Information" + "\r\n" + " เกิดความผิดในการกรอกข้อมูลของคุณ", Event = "" };
                return Json(result);
            }
            DateTime date = Convert.ToDateTime(@"01/01/01");
            if (eventmodel.Start_Date == date)
            {
                var result = new { Result = "Error in Your Information" + "\r\n" + " เกิดความผิดในการกรอกข้อมูลของคุณ", Event = "" };
                return Json(result);
            }


            string today = DateTime.Now.AddYears(-543).AddDays(1).ToString("dd/MM/yy");
            DateTime today1 = Convert.ToDateTime(today);
            if (eventmodel.Start_Date == today1)
            {
                var result = new { Result = "Error in Your Information, Please dont set date less than today." + "\r\n" + " เกิดความผิดในการกรอกข้อมูลของคุณ กรุณาอย่าตั้งเวลาน้อยกว่าเวลาปัจจุบัน", Event = "" };
                return Json(result);
            }
            if (eventmodel.End_Date == date)
            {
                var result = new { Result = "Error in Your Information" + "\r\n" + " เกิดความผิดในการกรอกข้อมูลของคุณ", Event = "" };
                return Json(result);
            }

            string TestEventPass = eventmodel.Event_Password;
            if (TestEventPass != null)
            {
                if (TestEventPass.Equals("ErrorCaseWhiteSpace"))
                {
                    var result = new { Result = "Please enter the password or remove the check if you do not want to enter the password. " + "\r\n" + " กรุณาใส่รหัสผ่านหรือลบเครื่องหมายหากคุณไม่ต้องการใส่รหัสผ่าน", Event = "" };
                    return Json(result);
                }
            }

            var CodeUpperCase = eventmodel.Event_Code.ToUpper();
            CheckDupe bussiness = new CheckDupe();

            bool IsDupicate = bussiness.CheckDupicate(CodeUpperCase, eventmodel.Start_Date, eventmodel.End_Date);
            if (!IsDupicate)
            {

                using (ProjectJobEntities db = new ProjectJobEntities())

                {

                    Event model = new Event()
                    {

                        Event_Code = CodeUpperCase,
                        Event_Name = eventmodel.Event_Name,
                        Start_Date = eventmodel.Start_Date,
                        End_Date = eventmodel.End_Date,
                        Users_ID = Convert.ToInt32(Session["User_ID"]),
                        Event_Password = eventmodel.Event_Password


                    };
                    db.Event.Add(model);

                    db.SaveChanges();





                    var result = new { Result = "Add Event Succesfully." + "\r\n" + " บันทึกกิจกรรมสำเร็จ", Event = model };

                    return Json(result);
                }


            }
            else
            {

                // TempData["msg"] = "<script>alert('Your Timeline is already Exist.');</script>";
                var result = new
                {
                    Result = "Your Timeline is already exist. Plaese Change Your Timeline or Your Event Code" + "\r\n"
                    + " ช่วงเวลาของคุณซ้ำ กรุณาเปลี่ยนช่วงเวลา หรือ รหัสกิจกรรม",
                    Event = ""
                };
                return Json(result);


            }
        }


        [HttpPost]
        public ActionResult LinkPage(int ID)
        {
            var UID = Convert.ToInt32(Session["User_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())

            {
                var model = db.Event.Where(x => x.Users_ID == UID && x.Event_ID == ID).SingleOrDefault();

                Session["User_ID"] = UID;
                Session["Event_ID"] = ID;
                Session["Event_Code"] = model.Event_Code;
                Session["Event_Name"] = model.Event_Name;


            }
            return Json(new { Url = "PollPage" });

        }


        public ActionResult PollPage()
        {


            var eid = Convert.ToInt32(Session["Event_ID"]);

            using (ProjectJobEntities db = new ProjectJobEntities())
            {

                List<Polls_Type> pollType = new List<Polls_Type>();
                pollType = db.Polls_Type.ToList();

                //viewbagdata
                ViewBag.MyPolist = pollType;



                List<Polls> pol = new List<Polls>();
                pol = db.Polls.Where(x => x.Event_ID == eid).OrderByDescending(q => q.Polls_ID).ToList();

                //viewbagdata
                ViewBag.MyPol = pol;


                List<TypePollView> viewP = new List<TypePollView>();

                var varis = from po in db.Polls
                            join pot in db.Polls_Type on po.Polls_Type_ID equals pot.Polls_Type_ID

                            where po.Event_ID == eid
                            orderby po.Polls_ID descending
                            select new TypePollView
                            {
                                Poll = po,
                                Polls_Type = pot


                            };

                viewP = varis.ToList();
                ViewBag.ThisPo = viewP;
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

        [HttpPost]
        public ActionResult AddPoll(int PollTypes, string PollName, string OPts, int Ratng, int NumMulti, string Ismulti, int Limit)

        {

            if (PollName != "")
            {
                if (PollTypes == 1)
                {
                    string[] OPtsrCheck = OPts.Trim().Split('|');
                    var numOPcheck = OPtsrCheck.Length;

                    if (OPtsrCheck[0] == "")
                    {
                        var i = 0;
                        foreach (var poo in OPtsrCheck)
                        {
                            if (String.IsNullOrWhiteSpace(poo) || poo == "")
                            {
                                i = 1 + i;
                            }
                        }
                        if (numOPcheck == i)
                        {
                            var results = new { Result = "Please Add Your Choices." + "\r\n" + " กรุณาเพิ่มตัวเลือกของคุณ", Poll = "" };
                            return Json(results);
                        }
                    }
                    else
                    {
                        if (String.IsNullOrWhiteSpace(OPtsrCheck[0]))
                        {
                            var results = new { Result = "Please Add Your Choices." + "\r\n" + " กรุณาเพิ่มตัวเลือกของคุณ", Poll = "" };
                            return Json(results);
                        }
                    }

                    Dictionary<string, int> checkRepeatWord = new Dictionary<string, int>();
                    for (int i = 0; i < numOPcheck; i++) //loop the splited string  
                    {
                        if (OPtsrCheck[i] != "")
                        {
                            if (checkRepeatWord.ContainsKey(OPtsrCheck[i])) // Check if word already exist in dictionary update the count  
                            {
                                var results = new
                                {
                                    Result = "Please check your options, Some option is repeated to other options."
                                     + "\r\n" + " กรุณาตรวจสอบตัวเลือกของคุณ, บางตัวเลือกซ้ำกับตัวเลือกอื่น",
                                    Poll = ""
                                };
                                return Json(results);
                            }
                            else
                            {
                                checkRepeatWord.Add(OPtsrCheck[i], 1);  // if a string is repeated and not added in dictionary , here we are adding   
                            }
                        }
                    }
                }

                var IsAllowMulti = Convert.ToBoolean(Ismulti);

                using (ProjectJobEntities db = new ProjectJobEntities())

                {


                    Polls Pmodel = new Polls()
                    {

                        Polls_Name = PollName,
                        Polls_Type_ID = PollTypes,
                        Event_ID = Convert.ToInt32(Session["Event_ID"]),
                        IsActive = false,
                        Rating = Ratng,
                        IsMulti = IsAllowMulti,
                        MaxMulti = NumMulti,
                        LimitPerson = Limit

                    };
                    db.Polls.Add(Pmodel);

                    if (PollTypes == 1)
                    {


                        string[] OPtsr = OPts.Trim().Split('|');
                        foreach (var poo in OPtsr)
                        {
                            if (poo != "")
                            {
                                Options Omodel = new Options()
                                {
                                    Polls_ID = Pmodel.Polls_ID,
                                    Options_Name = poo
                                };
                                db.Options.Add(Omodel);
                            }
                        }




                    }
                    db.SaveChanges();


                    var ViewPT = from po in db.Polls
                                 join pot in db.Polls_Type on po.Polls_Type_ID equals pot.Polls_Type_ID
                                 where po.Polls_ID == Pmodel.Polls_ID
                                 select new SelectPolltype
                                 {
                                     Polls_ID = po.Polls_ID,
                                     Polls_Name = po.Polls_Name,
                                     Polls_Type_ID = pot.Polls_Type_ID,
                                     Polls_Type_Name = pot.Polls_Type_Name,
                                     Type_Color = pot.Type_Color,
                                     Type_icon = pot.Type_icon,
                                     IsActive = po.IsActive

                                 };

                    var view = ViewPT.ToList();
                    var result = new { Result = "Add Poll Succesfully." + "\r\n" + " บันทึกโพลคำถามสำเร็จ", Poll = 1, Create = view };

                    return Json(result);
                }

            }
            else
            {
                var result = new { Result = "Please Enter your Poll Name." + "\r\n" + " กรุณากรอกชื่อของคำถาม", Poll = "" };

                return Json(result);
            }

        }


        public ActionResult UpdateNtf(int id, string status)
        {
            var eid = Convert.ToInt32(Session["Event_ID"]);
            var ID = Convert.ToInt32(id);
            var Status = Convert.ToBoolean(status);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {

                var call = db.Polls.Where(x => x.Event_ID == eid).ToList();



                foreach (var poo in call)
                {


                    poo.IsActive = false;


                }


                var result = db.Polls.Where(a => a.Polls_ID == ID).SingleOrDefault();
                if (result != null)
                {
                    result.IsActive = Status;


                }
                db.SaveChanges();

                var results = new { ID = result.Polls_ID, TID = result.Polls_Type_ID };
                return Json(results);

            }


        }
        public ActionResult CallSignalR(int id, int type)
        {
            var checkid = Convert.ToInt32(Session["Event_ID"]);
            MyHub.Hello(id, type, checkid);

            return Json("Success", JsonRequestBehavior.AllowGet);
        }


        public ActionResult _Text(int ID)
        {
            var id = Convert.ToInt32(Session["User_ID"]);
            var eid = Convert.ToInt32(Session["Event_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {

                var Text = from po in db.Polls
                           join ev in db.Event on po.Event_ID equals ev.Event_ID
                           join st in db.Outer on po.Polls_ID equals st.Polls_ID
                           where po.Polls_ID == ID
                           select new PollEvOuter
                           {
                               Poll = po,
                               Event = ev,
                               Outer = st,

                           };
                var viewText = Text.OrderByDescending(q => q.Outer.Outer_ID).ToList();
                ViewBag.ThisTextnCloud = viewText;
                ViewBag.ThisTextCount = viewText.Count();
                var viewte = from po in db.Polls
                             join pot in db.Polls_Type on po.Polls_Type_ID equals pot.Polls_Type_ID
                             where po.Polls_ID == ID
                             select new SelectPolltype
                             {
                                 Polls_ID = po.Polls_ID,
                                 Polls_Name = po.Polls_Name,
                                 Polls_Type_ID = pot.Polls_Type_ID,
                                 Polls_Type_Name = pot.Polls_Type_Name,
                                 Type_Color = pot.Type_Color,
                                 Type_icon = pot.Type_icon,
                                 IsActive = po.IsActive

                             };
                var viewter = viewte.ToList();
                ViewBag.view = viewter;


                return PartialView();
            }

        }

        public ActionResult _Rate(int ID)
        {
            var id = Convert.ToInt32(Session["User_ID"]);
            var eid = Convert.ToInt32(Session["Event_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                var rate = db.Outer.Where(x => x.Polls_ID == ID).OrderBy(x => x.Outer_Rating).ToList();
                var ratetrack = rate.Select(x => x.Outer_Rating);
                var ratecon = ratetrack.ToArray();
                var highrate = db.Polls.Where(x => x.Polls_ID == ID).Select(x => x.Rating).Single();
                var rateName = db.Polls.Where(x => x.Polls_ID == ID).ToList();

                Dictionary<int?, int> RepeatedRate = new Dictionary<int?, int>();
                for (int i = 1; i < highrate + 1; i++)
                {
                    RepeatedRate.Add(i, 0);
                }
                for (int i = 0; i < ratecon.Length; i++) //loop the splited string  
                {
                    if (RepeatedRate.ContainsKey(ratecon[i])) // Check if word already exist in dictionary update the count  
                    {
                        int value = RepeatedRate[ratecon[i]];
                        RepeatedRate[ratecon[i]] = value + 1;
                    }
                    else
                    {
                        RepeatedRate.Add(ratecon[i], 1);  // if a string is repeated and not added in dictionary , here we are adding   
                    }
                }
                var all = rate.Count();
                if (all == 0)
                {
                    all = 1;
                }
                int?[] ReconKeys = RepeatedRate.Keys.ToArray();
                int[] ReconValues = RepeatedRate.Values.ToArray();
                Dictionary<int?, decimal> GetCal = new Dictionary<int?, decimal>();
                for (int i = 0; i < ReconKeys.Length; i++) //loop the splited string  
                {
                    decimal Value = ReconValues[i];
                    decimal Debitvalue = (decimal)(Value / all) * 100;
                    decimal DEBITAMT = Convert.ToDecimal(string.Format("{0:0.0}", Debitvalue));
                    GetCal.Add(ReconKeys[i], DEBITAMT);  // if a string is repeated and not added in dictionary , here we are adding   

                }
                int? Sumrate = 0;
                for (int i = 0; i < ReconKeys.Length; i++)
                {
                    var Sumbe = ReconKeys[i] * ReconValues[i];
                    Sumrate = Sumbe + Sumrate;
                }

                decimal d = Convert.ToDecimal(Sumrate);
                decimal PreCal = (decimal)d / all;
                decimal PostCal = Convert.ToDecimal(string.Format("{0:0.0}", PreCal));
                ViewBag.obj = GetCal;
                ViewBag.PostCal = PostCal;

                var viewte = from po in db.Polls
                             join pot in db.Polls_Type on po.Polls_Type_ID equals pot.Polls_Type_ID
                             where po.Polls_ID == ID
                             select new SelectPolltype
                             {
                                 Polls_ID = po.Polls_ID,
                                 Polls_Name = po.Polls_Name,
                                 Polls_Type_ID = pot.Polls_Type_ID,
                                 Polls_Type_Name = pot.Polls_Type_Name,
                                 Type_Color = pot.Type_Color,
                                 Type_icon = pot.Type_icon,
                                 IsActive = po.IsActive

                             };
                var viewter = viewte.ToList();
                ViewBag.Name = viewter;

            }
            return PartialView();
        }

        public ActionResult _Multi(int ID)
        {
            using (ProjectJobEntities db = new ProjectJobEntities())
            {

                var multi = from op in db.Options
                            join so in db.OuterOptions on op.Options_ID equals so.Options_ID
                            where op.Polls_ID == ID
                            select new PollOPtions
                            {
                                Option = op,
                                OuterOptions = so


                            };

                var viewmulti = multi.ToList();
                var optiontrack = viewmulti.Select(x => x.Option.Options_Name);
                var optioncon = optiontrack.ToArray();
                var all = viewmulti.Count();
                var OptionsName = db.Options.Where(x => x.Polls_ID == ID).Select(x => x.Options_Name).ToArray();
                var allnamecount = OptionsName.Count();
                Dictionary<string, int> Repeatedoptions = new Dictionary<string, int>();
                for (int i = 0; i < allnamecount; i++)
                {
                    Repeatedoptions.Add(OptionsName[i], 0);
                }
                for (int i = 0; i < optioncon.Length; i++) //loop the splited string  
                {

                    if (Repeatedoptions.ContainsKey(optioncon[i])) // Check if word already exist in dictionary update the count  
                    {
                        int value = Repeatedoptions[optioncon[i]];
                        Repeatedoptions[optioncon[i]] = value + 1;
                    }
                    else
                    {
                        Repeatedoptions.Add(optioncon[i], 1);  // if a string is repeated and not added in dictionary , here we are adding   
                    }
                }

                if (all == 0)
                {
                    all = 1;
                }
                var ReconKeys = Repeatedoptions.Keys.ToArray();
                int[] ReconValues = Repeatedoptions.Values.ToArray();
                Dictionary<string, decimal> KeepCal = new Dictionary<string, decimal>();
                for (int i = 0; i < ReconKeys.Length; i++) //loop the splited string  
                {
                    decimal Value = ReconValues[i];
                    decimal Debitvalue = (decimal)(Value / all) * 100;
                    decimal DEBITAMT = Convert.ToDecimal(string.Format("{0:0.0}", Debitvalue));
                    KeepCal.Add(ReconKeys[i], DEBITAMT);  // if a string is repeated and not added in dictionary , here we are adding   

                }
                ViewBag.obj = KeepCal;
                var viewte = from po in db.Polls
                             join pot in db.Polls_Type on po.Polls_Type_ID equals pot.Polls_Type_ID
                             where po.Polls_ID == ID
                             select new SelectPolltype
                             {
                                 Polls_ID = po.Polls_ID,
                                 Polls_Name = po.Polls_Name,
                                 Polls_Type_ID = pot.Polls_Type_ID,
                                 Polls_Type_Name = pot.Polls_Type_Name,
                                 Type_Color = pot.Type_Color,
                                 Type_icon = pot.Type_icon,
                                 IsActive = po.IsActive

                             };
                var viewter = viewte.ToList();
                ViewBag.view = viewter;
                return PartialView();
            }

        }
        public ActionResult _Cloud(int ID)
        {

            var eid = Convert.ToInt32(Session["Event_ID"]);
            using (ProjectJobEntities db = new ProjectJobEntities())
            {

                var all = db.Outer.Where(x => x.Polls_ID == ID).ToList();

                var MA = all.Select(x => x.Outer_Text);

                string[] word = MA.ToArray();
                string[] wait = { "ยังไม่มีการตอบคำถามในโพลคำถามนี้" };
                if (word.Length == 0)
                {
                    word = wait;
                }

                Dictionary<string, int> RepeatedWordCount = new Dictionary<string, int>();

                for (int i = 0; i < word.Length; i++) //loop the splited string  
                {
                    if (RepeatedWordCount.ContainsKey(word[i])) // Check if word already exist in dictionary update the count  
                    {
                        int value = RepeatedWordCount[word[i]];
                        RepeatedWordCount[word[i]] = value + 1;
                    }
                    else
                    {
                        RepeatedWordCount.Add(word[i], 1);  // if a string is repeated and not added in dictionary , here we are adding   
                    }
                }
                ViewBag.obj = RepeatedWordCount;
                var viewte = from po in db.Polls
                             join pot in db.Polls_Type on po.Polls_Type_ID equals pot.Polls_Type_ID
                             where po.Polls_ID == ID
                             select new SelectPolltype
                             {
                                 Polls_ID = po.Polls_ID,
                                 Polls_Name = po.Polls_Name,
                                 Polls_Type_ID = pot.Polls_Type_ID,
                                 Polls_Type_Name = pot.Polls_Type_Name,
                                 Type_Color = pot.Type_Color,
                                 Type_icon = pot.Type_icon,
                                 IsActive = po.IsActive

                             };
                var viewter = viewte.ToList();
                ViewBag.view = viewter;


                return View();
            }

        }

        public ActionResult DeletPoll(int PollID)
        {
            using (ProjectJobEntities db = new ProjectJobEntities())
            {

                Polls pollDetail = db.Polls.Find(PollID);
                db.Polls.Remove(pollDetail);
                db.SaveChanges();



                var alertt = "Delete Success";
                return Json(alertt);
            }

        }
        public ActionResult DeletEvent(int EventID)
        {
            using (ProjectJobEntities db = new ProjectJobEntities())
            {

                Event EventDetail = db.Event.Find(EventID);
                db.Event.Remove(EventDetail);
                db.SaveChanges();


                var alerte = new { Result = "Delete Success" };
                
                return Json(alerte);
            }

        }
        public ActionResult _LookupEditEvent(int EID)
        {
            using (ProjectJobEntities db = new ProjectJobEntities())
            {

                var EditView = db.Event.Where(x => x.Event_ID == EID).Select(x => new EventViewModel() { Event_ID = x.Event_ID, Event_Code = x.Event_Code, Event_Name = x.Event_Name, End_Date = x.End_Date, Start_Date = x.Start_Date, Event_Password = x.Event_Password }).ToList();
                var EventPassword = EditView.Select(x => x.Event_Password).ToArray();
                ViewBag.EditView = EditView;
                ViewBag.EventPassword = EventPassword;

                return View();
            }

        }
        public ActionResult EDITEvent(string Name, string Event_Code, DateTime Start_Date, DateTime End_Date, int ID, string Password)
        {
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                Eit bussiness = new Eit();

                bool IsDupicate = bussiness.CheckEdit(Event_Code, Start_Date, End_Date, ID);
                if (!IsDupicate)
                {
                    var EditView = db.Event.Where(x => x.Event_ID == ID).SingleOrDefault();


                    EditView.Event_Code = Event_Code;
                    EditView.Start_Date = Start_Date;
                    EditView.End_Date = End_Date;
                    EditView.Event_Name = Name;
                    EditView.Event_Password = Password;
                    db.SaveChanges();

                    var alerte = new { Result = "Event have been updated." };

                    return Json(alerte);
                }
                else
                {

                    // TempData["msg"] = "<script>alert('Your Timeline is already Exist.');</script>";
                    var alerte = new { Result = "Your Event Code and Timeline is already exist." };
                    return Json(alerte);

                }
            }
        }
        public ActionResult _LookupEditPoll(int PID)
        {
            using (ProjectJobEntities db = new ProjectJobEntities())
            {


                var EditViewPoll = db.Polls.Where(x => x.Polls_ID == PID).Select(x => new PollView() { Polls_ID = x.Polls_ID, Polls_Type_ID = x.Polls_Type_ID, Polls_Name = x.Polls_Name, Event_ID = x.Event_ID, Rating = x.Rating, IsMulti = x.IsMulti, MaxMulti = x.MaxMulti , LimitPerson = x.LimitPerson }).ToList();
                var typePoll = EditViewPoll.Select(x => x.Polls_Type_ID).ToArray();
                var LimitPoll = EditViewPoll.Select(x => x.LimitPerson).ToArray();

                var EditViewOption = db.Options.Where(x => x.Polls_ID == PID).Select(x => new OptionView() { Polls_ID = x.Polls_ID, Options_ID = x.Options_ID, Options_Name = x.Options_Name }).ToList();
                ViewBag.OptionsLength = EditViewOption.Count();
                ViewBag.EditViewOption = EditViewOption;
                ViewBag.EditViewRate = EditViewPoll;
                ViewBag.EditViewType = typePoll;
                ViewBag.EditLimitPoll = LimitPoll;
                return View();
            }

        }
        public ActionResult EDITEPoll(string Name, int rating, int ID, int Type, string ID_Options, string Options, int NumMulti, string Ismulti, int Limit)
        {
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                var EditPollView = db.Polls.Where(x => x.Polls_ID == ID).SingleOrDefault();

                EditPollView.Polls_Name = Name;
                EditPollView.LimitPerson = Limit;
                if (Type == 4)
                {
                    if (EditPollView.Rating != rating)
                    {
                        var SurveyRate = db.Outer.Where(x => x.Polls_ID == ID && x.Outer_Rating > rating).ToArray();
                        for (int i = 0; i < SurveyRate.Length; i++)
                        {
                            db.Outer.Remove(SurveyRate[i]);
                        }
                        EditPollView.Rating = rating;
                    }


                }
                if (Type == 1)
                {

                    string[] CheckID_Options = ID_Options.Trim().Split('|');
                    string[] CheckOptions = Options.Trim().Split('|');
                    var IDLength = CheckID_Options.Length;
                    Dictionary<string, string> Repeatedoptions = new Dictionary<string, string>();
                    for (int i = 0; i < IDLength; i++)
                    {
                        if (CheckOptions[i] != "")
                        {
                            if (Repeatedoptions.ContainsKey(CheckOptions[i])) // Check if word already exist in dictionary update the count  
                            {
                                var alertes = new { Result = "Please check your options, Some option is repeated to other options.", Get = 1 };
                                return Json(alertes);
                            }
                            else
                            {

                                Repeatedoptions.Add(CheckOptions[i], CheckID_Options[i]);
                            }
                        }
                    }

                    Dictionary<string, int> GetOldoptions = new Dictionary<string, int>();
                    for (int i = 0; i < IDLength; i++)
                    {
                        if (CheckOptions[i] != "")
                        {
                            var toint = Convert.ToInt32(CheckID_Options[i]);
                            if (toint != 0) // Check if word already exist in dictionary update the count  
                            {

                                GetOldoptions.Add(CheckOptions[i], toint);
                            }
                        }
                    }
                    Dictionary<string, int> Newoptions = new Dictionary<string, int>();
                    for (int i = 0; i < IDLength; i++)
                    {
                        if (CheckOptions[i] != "")
                        {
                            var toint = Convert.ToInt32(CheckID_Options[i]);
                            if (toint == 0) // Check if word already exist in dictionary update the count  
                            {

                                Newoptions.Add(CheckOptions[i], toint);
                            }
                        }
                    }
                    var OptionsLength = GetOldoptions.Count();
                    var OldOption = db.Options.Where(x => x.Polls_ID == ID).Select(x => x.Options_ID).ToArray();
                    var OldDataLength = OldOption.Length;

                    if (OptionsLength == OldDataLength)
                    {
                        var checkBack = db.Options.Where(x => x.Polls_ID == ID);

                        for (int index = 0; index < OptionsLength; index++)
                        {
                            var element = GetOldoptions.ElementAt(index);
                            var key = element.Key;
                            if (!checkBack.Any(x => x.Options_Name == key))
                            {
                                var OptionID = Convert.ToInt32(element.Value);
                                var UpdateBack = db.Options.Where(x => x.Polls_ID == ID && x.Options_ID == OptionID).SingleOrDefault();
                                {
                                    UpdateBack.Options_Name = key;
                                };

                            }
                        }
                    }
                    if (OptionsLength < OldDataLength)
                    {
                        int[] checkBack = db.Options.Where(x => x.Polls_ID == ID).Select(x => x.Options_ID).ToArray();
                        var OldStringID = "";
                        for (int iz = 0; iz < checkBack.Length; iz++)
                        {
                            var a = Convert.ToString(checkBack[iz]);
                            OldStringID = OldStringID + " " + a;
                        }

                        string[] OldStringID_Split = OldStringID.Trim().Split(' ');

                        var OldStringID_Length = OldStringID_Split.Length;
                        for (int index = 0; index < OldStringID_Length; index++)
                        {
                            var intOldID = Convert.ToInt32(OldStringID_Split[index]);
                            if (!GetOldoptions.Any(x => x.Value == intOldID))
                            {
                                Options OptionDelete = db.Options.Find(intOldID);
                                db.Options.Remove(OptionDelete);

                            }

                        }
                    }

                    if (Newoptions.Count != 0)
                    {

                        foreach (var kvp in Newoptions)
                        {
                            if (kvp.Key != "")
                            {
                                Options Omodel = new Options()
                                {
                                    Polls_ID = ID,
                                    Options_Name = kvp.Key
                                };
                                db.Options.Add(Omodel);
                            }
                        }
                    }
                    var IsAllowMulti = Convert.ToBoolean(Ismulti);
                    var UpdateBack2 = db.Polls.Where(x => x.Polls_ID == ID).SingleOrDefault();
                    {
                        UpdateBack2.IsMulti = IsAllowMulti;
                        UpdateBack2.MaxMulti = NumMulti;
                    };

                }

                db.SaveChanges();


                var signalID = db.Polls.Where(x => x.Polls_ID == ID).Select(x => x.Polls_ID).SingleOrDefault();
                var signalType = db.Polls.Where(x => x.Polls_ID == ID).Select(x => x.Polls_Type_ID).SingleOrDefault();
                var Signal = new { signalID, signalType };
                var alerte = new { Result = "Poll have been Updated.", Get = 0, s = Signal };

                return Json(alerte);

            }

        }



    }
}