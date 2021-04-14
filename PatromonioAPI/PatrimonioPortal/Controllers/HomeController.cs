using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatrimonioPortal.CrossCutting.Interface;
using PatrimonioPortal.Models;

namespace PatrimonioPortal.Controllers
{
    public class HomeController : Controller
    {
        #region Variaveis

        private readonly IClienteService _clienteService;

        #endregion

        #region Construtor

        public HomeController(IClienteService clienteService) 
        {
            _clienteService = clienteService;
        }

        #endregion

        public async Task<IActionResult> Index(LoginModel model)
        {
            var cliente = await _clienteService.GetClientAsync(model.Token, model.Id);
            return View(cliente);
        }

        public IActionResult Back(ClienteModel model)
        {
            return View("Index", model);
        }
    }
}