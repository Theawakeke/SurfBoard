using SurfBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SurfBoard.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashborad
        public ActionResult DashBoard()
        {

            var ID = Convert.ToInt32(Session["User_ID"]);

            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                List<Event> eventlist = new List<Event>();

                eventlist = db.Event.Where(x => x.Users_ID == ID).ToList();

                var eventlistCount = eventlist.Count();
                ViewBag.eventlistCount = eventlistCount;

                List<Eventpoll> countPoll = new List<Eventpoll>();

                var countPollview = from po in db.Polls
                            join ev in db.Event on po.Event_ID equals ev.Event_ID
                            where ev.Users_ID == ID
                            select new Eventpoll
                            {
                                Poll = po,
                                Event = ev


                            };
                countPoll = countPollview.ToList();
                ViewBag.PollCount = countPoll.Count();

                List<PollEvOuter> conutouterview = new List<PollEvOuter>();

                var conutouter = from po in db.Polls
                            join ev in db.Event on po.Event_ID equals ev.Event_ID
                            join ou in db.Outer on po.Polls_ID equals ou.Polls_ID
                            where ev.Users_ID == ID
                            select new PollEvOuter
                            {
                                Poll = po,
                                Event = ev,
                                Outer = ou


                            };

                conutouterview = conutouter.ToList();
                ViewBag.ConutOuter = conutouterview.Count();

                List<AnalysisData> AnalysisData = new List<AnalysisData>();

                var find = from po in db.Polls
                                 join ev in db.Event on po.Event_ID equals ev.Event_ID
                                 join ou in db.Outer on po.Polls_ID equals ou.Polls_ID
                                 join pt in db.Polls_Type on po.Polls_Type_ID equals pt.Polls_Type_ID
                                 
                                 
                                 where ev.Users_ID == ID
                                 select new AnalysisData
                                 {
                                     Polls = po,
                                     Event = ev,
                                     Outer = ou,
                                     Polls_Type = pt
                                  
                                    


                                 };

                AnalysisData = find.ToList();
                ViewBag.AnalysisData = AnalysisData;
                

                return View();
            }
        }
    }
}