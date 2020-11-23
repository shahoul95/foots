
using Microsoft.AspNetCore.Mvc;

namespace foots.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
      
            return View("Index");
        }

        

    }
}
