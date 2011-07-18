using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace O_O.Controllers
{
    public class QuotesController : Controller
    {
        //
        // GET: /Quotes/
        public String Index()
        {
            //return "{\"author\": \"Thomas Shields\", \"quote\":\"My Epic Quote\"}";


            Uri qodUri = new Uri("http://quotesondesign.com/api/3.0/api-3.0.json", UriKind.Absolute);
            HttpWebRequest qodRequest = (HttpWebRequest)WebRequest.Create(qodUri);
            HttpWebResponse qodResponse = (HttpWebResponse)qodRequest.GetResponse();
            string qodJson = "";
            using (StreamReader sr = new StreamReader(qodResponse.GetResponseStream()))
            {
                qodJson = sr.ReadToEnd();
            }
            return qodJson;
          //  return Json(qodJson,JsonRequestBehavior.AllowGet);
            
        }

    }
}
