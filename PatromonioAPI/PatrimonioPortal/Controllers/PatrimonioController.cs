using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PatrimonioPortal.CrossCutting.Interface;
using PatrimonioPortal.Models;

namespace PatrimonioPortal.Controllers
{
    public class PatrimonioController : Controller
    {
        #region Variaveis

        private readonly IContaCorrenteService _contaCorrenteService;

        #endregion

        #region Construtores

        public PatrimonioController(IContaCorrenteService contaCorrenteService) 
        {
            _contaCorrenteService = contaCorrenteService;
        }

        #endregion

        public async Task<IActionResult> Index(ClienteModel cliente)
        {
            PatrominioConsolidadoModel model = new PatrominioConsolidadoModel { Cliente = cliente, Token = cliente.Token };
            model.Conta = await _contaCorrenteService.GetContaCorrentAsync(cliente.Token, cliente.Id);
            return View(model);
        }
    }
}