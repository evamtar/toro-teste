using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatrimonioPortal.Models;

namespace PatrimonioPortal.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(LoginModel model)
        {
            return View();
        }
    }
}