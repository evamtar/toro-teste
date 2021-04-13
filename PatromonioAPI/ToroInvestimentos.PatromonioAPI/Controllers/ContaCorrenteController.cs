using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Interfaces.Services;

namespace ToroInvestimentos.PatromonioAPI.Controllers
{
    [Route("api/contacorrente")]
    [ApiController]
    public class ContaCorrenteController : ControllerBase
    {
        #region Variaveis injeção dependencia / Controle Acesso

        private readonly IContaCorrenteService _contaCorrenteService;

        #endregion

        #region Construtor
        public ContaCorrenteController(IContaCorrenteService contaCorrenteService)
        {
            _contaCorrenteService = contaCorrenteService;
        }

        #endregion

        #region Métodos Públicos

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ContaCorrente>> Get(string idCliente)
        {
            try
            {
                var contaCorrente = await _contaCorrenteService.SelecionarAssincrono(cli => cli.ClienteId == idCliente);
                return Ok(contaCorrente);
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }


        #endregion
    }
}