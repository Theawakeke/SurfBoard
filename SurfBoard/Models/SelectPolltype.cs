using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SurfBoard.Models
{
    public class SelectPolltype
    {
        public int Polls_ID { get; set; }
        public int Polls_Type_ID { get; set; }
        public string Polls_Name { get; set; }
        public string Polls_Type_Name { get; set; }
        public string Type_Color { get; set; }
        public string Type_icon { get; set; }
        public bool IsActive { get; set; }
    }
}