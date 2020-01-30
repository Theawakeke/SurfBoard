using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfBoard.Models
{
    public class PollEvOuter
    {
        public Polls Poll { get; set; }
        public Event Event { get; set; }
        public Outer Outer { get; set; }

    }
}