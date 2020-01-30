

using SurfBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfBoard.Business
{
    public class CheckDupe
    {
        public bool CheckDupicate(string CodeUpperCase, DateTime startDate, DateTime endDate)
        {
            bool result = false;
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                var Lookstart = db.Event.Where(x => x.Event_Code == CodeUpperCase).Select(x => x.Start_Date).ToList();
                var Lookend = db.Event.Where(x => x.Event_Code == CodeUpperCase).Select(x => x.End_Date).ToList();
                var LookUp = new { start = Lookstart.ToArray(), end = Lookend.ToArray() };
                var LookCount = Lookstart.Count();

                if (db.Event.Any(x => x.Event_Code == CodeUpperCase))
                {
                    List<DateTime> allEvents = new List<DateTime>();
                    for (int i = 0; i < LookCount; i++)
                    {
                        allEvents.Add(LookUp.start[i]); //Make sure the start date is included in the list of dates!

                        var tempDate = LookUp.start[i];
                        var tempend = LookUp.end[i];
                        while (tempDate < tempend) //Less than or Equals means the end date will be added as well
                        {
                            tempDate = tempDate.AddDays(1);
                            allEvents.Add(tempDate);
                        }
                    }

                    List<DateTime> allEventsAdd = new List<DateTime>();

                    allEventsAdd.Add(startDate); //Make sure the start date is included in the list of dates!

                    var tempDateAdd = startDate;
                    var tempendAdd = endDate;
                    while (tempDateAdd < tempendAdd) //Less than or Equals means the end date will be added as well
                    {
                        tempDateAdd = tempDateAdd.AddDays(1);
                        allEventsAdd.Add(tempDateAdd);
                    }

                    for (int i = 0; i < allEventsAdd.Count(); i++)
                    {
                        var datacheck = allEventsAdd[i];
                        if (allEvents.Any(x => x.Date == datacheck))
                        {


                            result = true;


                        }
                    }
                }
                else
                {
                    result = false;
                }

            }
            return result;
        }

    }


}