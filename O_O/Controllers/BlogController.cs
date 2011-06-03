using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using O_O.Models;
namespace O_O.Controllers
{
    public class BlogController : Controller
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            List<post> p = new List<post>();
            p.Add(new post("My First Post","My Post's Content...", DateTime.Now, "Theology",0));
            return View(p);
        }

    }
}
