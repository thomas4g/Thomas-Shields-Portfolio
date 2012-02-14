using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Thomas_Shields_Portfolio.Models
{
	public class article
	{
		public int id { get; set; }
		[Required]
		public string title { get; set; }
		[AllowHtml]
		[Required]
		public string content { get; set; }
		[Required]
		public DateTime date { get; set; }
		[Required]
		public string author { get; set; }
		[Required]
		public int stars { get; set; }
		[Required]
		public string tags { get; set; } //comma delimited
		public article() { }
		public article(int _id, string _title, string _content, DateTime _date, string _author, int _stars, string _tags)
		{
			id = _id;
			title = _title;
			content = _content;
			date = _date;
			author = _author;
			stars = _stars;
			tags = _tags;
		}
	}
}