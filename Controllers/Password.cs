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
    public class Password : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View("Password");
        }

        [HttpPost("password")]
        public async Task<ActionResult> password([FromBody] Membre member)
        {

            var context = new DjibsonContext();
            try
            {
                if (member.Login != null)
                {


                    var a = Task.Run(()=>from profile in context.Membre where profile.Login == member.Login select new { profile.Login });
                    var c = await a;
                    var b = c.DefaultIfEmpty().Single().Login;

                    if (b == member.Login)
                    {
                        a.Wait();
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
            finally
            {
                if(context != null)
                {
                    await context.DisposeAsync();
                }
            }
            
        }
    }
}
