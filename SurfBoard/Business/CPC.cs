using SurfBoard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfBoard.Business
{
    public class CPC
    {
        public bool CheckPollClose(int PollID)
        {
            bool result = false;
            using (ProjectJobEntities db = new ProjectJobEntities())
            {

                if (db.Polls.Any(x => x.Polls_ID == PollID))
                {

                    result = true;


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