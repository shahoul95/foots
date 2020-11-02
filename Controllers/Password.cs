using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using System.Text.Json.Serialization;

using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using foots.Models;
using MySqlX.XDevAPI.Relational;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace foots.Controllers
{
    public class Password : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Password");
        }
        public ActionResult password(string id)
        {

            var context = new djibsonContext();
            try
            {
                if (id != null)
                {


                    var a = from profile in context.Membre where profile.Login == id select new { profile.Login };
                    var b = a.DefaultIfEmpty().Single().Login;

                    if (b == id)
                    {
                        HttpContext.Session.SetString("email", b);
                        return Json(0);
                    }
                    else
                    {
                        return Json(false);
                    }
               

                }
                else
                {
                    return Json(false);
                }
              

            }catch(Exception e)
            {
                return Json(e);
            }
        }
    }
}
