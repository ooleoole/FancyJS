using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FancyText.Repo;
using Microsoft.AspNetCore.Mvc;

namespace FancyText.Controllers
{
   
    public class FancyTextController : Controller
    {
        

        
        public IActionResult Index()
        {
            return View();
        }
    }
}
