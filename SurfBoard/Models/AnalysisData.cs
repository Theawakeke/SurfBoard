using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfBoard.Models
{
    public class AnalysisData
    {
        
        public Event Event { get; set; }
        public Polls Polls { get; set; }
        public Polls_Type Polls_Type { get; set; }
        public Outer Outer { get; set; }
        public OuterOptions OuterOptions { get; set; }
        public Options Options { get; set; }

    }
}