using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatrimonioPortal.CrossCutting.Interface;
using PatrimonioPortal.Models;

namespace PatrimonioPortal.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginService _loginService;
        public LoginController(ILoginService loginService) 
        {
            _loginService = loginService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AutenticarAsync(LoginModel entity)
        {
            try
            {
                var loggerUser = await _loginService.AutenticarAsync(entity);
                return RedirectToAction("Index", "Home", loggerUser);
            }
            catch (Exception ex) 
            {
                return View("Index", new LoginModel { HasErrors = true, ErrorTitle="Falha na autenticacao", ErrorMessage= ex.Message });
            }
        }
    }
}