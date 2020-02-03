using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfBoard.Models
{
    public class PollView
    {
        public int Polls_ID { get; set; }
        public int Polls_Type_ID { get; set; }
        public string Polls_Name { get; set; }
        public int Event_ID { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> Rating { get; set; }
        public bool IsMulti { get; set; }
        public Nullable<int> MaxMulti { get; set; }
    }
}