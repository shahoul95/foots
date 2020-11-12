using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using foots.Models;

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
