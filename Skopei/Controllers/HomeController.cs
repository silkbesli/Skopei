using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Skopei.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            var values = new Dictionary<string, string>
                {
                { "Name", "Tom" },
                { "Email", "Tom@hotmail.com" }
                };

            var content = new FormUrlEncodedContent(values);

            var response = client.PostAsync("http://localhost:1651/api/Users", content);

            
            return View();
        }
    }
}
