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
    public class Passchange : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Passchange");
        }

        public ActionResult change()
        {
            var email = HttpContext.Session.GetString("email");
            if(email != null)
            {

                return Json(email);
            }
            else
            {
                return Json(false);
            }
       
        }
        public ActionResult update(string email,string nouveau)
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
            var context = new djibsonContext();
           var nouveaus =  crypt.BCryptHash(nouveau);
            if( email != null && nouveau != null)
            {
                var requete = from profilse in context.Membre where profilse.Login == email select profilse;
                foreach(var i in requete)
                {
                    i.MotPasses = nouveaus;
                 
                }
                try
                {
                    context.SaveChangesAsync();
                   
                    HttpContext.Session.Remove("email");
                   
                   
                }
                catch (Exception e)
                {
                    return Json(e);
                    // Provide for exceptions.
                }
           
            }
            return Json(0);

        }
    }
}
