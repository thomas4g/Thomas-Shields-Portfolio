using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace O_O.Models
{
    public class comment
    {
        public int ID { get; set; }
        [Required(ErrorMessage="What's your name?")]
        public string author { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        [Required(ErrorMessage="Whatcha got to say?")]
        public string content { get; set; }
        public DateTime date { get; set; }
        public int post { get; set; }
    }
}