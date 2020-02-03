using SurfBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfBoard.Business
{
    public class Eit
    {
        public bool CheckEdit(string EventCode, DateTime startDate, DateTime endDate, int ID)
        {
            bool result = false;
            using (ProjectJobEntities db = new ProjectJobEntities())
            {
                var checkBack = db.Event.Where(x => x.Event_ID != ID);
                if (checkBack.Any(x => x.Event_Code == EventCode && x.Start_Date == startDate && x.End_Date == endDate))
                {
                    if (checkBack.Any(x => x.Start_Date == startDate))
                    {
                        if (checkBack.Any(x => x.End_Date == endDate))
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