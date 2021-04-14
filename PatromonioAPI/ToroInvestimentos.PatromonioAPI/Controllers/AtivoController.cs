using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Interfaces.CrossCutting;
using toroinvestimentos.patromonio.domain.Interfaces.Services;

namespace ToroInvestimentos.PatromonioAPI.Controllers
{
    [Route("api/ativos")]
    [ApiController]
    public class AtivoController : ControllerBase
    {
        #region Variaveis injeção dependencia / Controle Acesso

        private readonly IAtivoService _ativoService;
        private readonly IConsultaBovespaService _consultaBovespaService;

        #endregion

        #region Construtor
        public AtivoController(IAtivoService ativoService,
                               IConsultaBovespaService consultaBovespaService)
        {
            _ativoService = ativoService;
            _consultaBovespaService = consultaBovespaService;
        }

        #endregion

        #region Métodos Públicos

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IList<Ativo>>> Get(string idCliente)
        {
            try
            {
                var ativos = await _ativoService.BuscarAssincrono(atv => atv.ClienteId == idCliente);
                foreach (var ativo in ativos)
                {
                    var valorAtivo = await _consultaBovespaService.ConsultaValor(new BovespaExternal { CodigoPapel = ativo.CodigoBovespa });
                    ativo.ValorUnitario = valorAtivo.Valor;
                }
                return Ok(ativos);
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }


        #endregion
    }
}