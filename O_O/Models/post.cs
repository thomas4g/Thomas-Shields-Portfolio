using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace O_O.Models
{
    public class post
    {
        
        public int id {get; set;}
        [Required]
        public string title { get; set; }
        [AllowHtml]
        [Required]
        public string content { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public string tag { get; set; }
        public List<comment> comments { get; set; }
        public post()
        {

        }
        public post(int _id, string _title, string _content, DateTime _date, string _tag, List<comment> _comments)
        {
            id = _id;
            title = _title;
            content = _content;
            date = _date;
            tag = _tag;
            comments = _comments;
        }
    }
}