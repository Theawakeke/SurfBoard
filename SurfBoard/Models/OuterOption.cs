using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfBoard.Models
{
    public class OuterOption
    {
        public Outer Outer { get; set; }
        public OuterOptions OuterOptions { get; set; }
        public Options Options { get; set; }
    }
}