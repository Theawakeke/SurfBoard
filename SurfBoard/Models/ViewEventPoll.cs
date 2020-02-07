using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfBoard.Models
{
    public class ViewEventPoll
    {
        public int Event_ID { get; set; }
        public string Event_Code { get; set; }
        public string Event_Name { get; set; }
        public System.DateTime Start_Date { get; set; }
        public System.DateTime End_Date { get; set; }
        public string Event_Password { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}