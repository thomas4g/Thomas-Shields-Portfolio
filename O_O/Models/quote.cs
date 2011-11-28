using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O_O.Models
{
    public class quote
    {
        public enum QuoteType
        {
            Theology, Design, Code, Other
        }
        public int id { get; set; }
        public string body { get; set; }
        public string author { get; set; }
        public QuoteType type { get; set; }
    }
}