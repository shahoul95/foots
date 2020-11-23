using System;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace foots.Controllers
{
    public class Deconnection : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Deconnection");
        }
        public ActionResult deco()
        {
            HttpContext.Session.Remove("nom");
            HttpContext.Session.Remove("prenom");
            HttpContext.Session.Remove("equipe");
            HttpContext.Session.Remove("poste");
            HttpContext.Session.Remove("id");
            HttpContext.Session.Clear();
            var deco = 1;
            return Json(new {deco});
        }
    }
}
