using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace O_O.Models
{
    public class post
    {
        public string _title;
        public string _content;
        public DateTime _pubdate;
        public string _tag;
        public int _comments;
        public post(string title, string content, DateTime pubdate, string tag, int comments)
        {
            _title = title;
            _content = content;
            _pubdate = pubdate;
            _tag = tag;
            _comments = comments;
        }
    }
}