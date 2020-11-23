using System;

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;

using foots.Models;



// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace foots.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Passchange : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Passchange");
        }

        [HttpGet("change")]
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

        [HttpPost("update")]
        public async Task<JsonResult> update([FromBody] Membre member)
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
            var context = new DjibsonContext();
            var nouveaus =  crypt.BCryptHash(member.MotPasses);
            if( member.Login != null && member.MotPasses != null)
            {
                var requete = Task.Run(() => from profilse in context.Membre where profilse.Login == member.Login select profilse);
                var requetes = await requete;
                foreach(var i in requetes)
                {
                    i.MotPasses = nouveaus;
                 
                }
                try
                {
                    requete.Wait();
                   await context.SaveChangesAsync();
                   
                    HttpContext.Session.Remove("email");
                   
                   
                }
                catch (Exception e)
                {
                    return Json(e);
                    // Provide for exceptions.
                }
                finally
                {
                    if(context != null)
                    {
                        await context.DisposeAsync();
                    }
                }
            }
            return Json(0);

        }
    }
}
