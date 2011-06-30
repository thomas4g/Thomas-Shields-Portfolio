using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O_O.Models
{
    public class StackOverflowItem
    {
        public string title { get; set; }
        public DateTime date { get; set; }
        public string type { get; set; }
        public string link { get; set; }
        public StackOverflowItem(string _title, DateTime _date, string _type, string _link)
        {
            title = _title;
            date = _date;
            type = _type;
            link = _link;
        }
    }
}