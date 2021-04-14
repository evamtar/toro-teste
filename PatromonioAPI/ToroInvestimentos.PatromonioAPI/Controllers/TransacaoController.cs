using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Entities.Validator;
using toroinvestimentos.patromonio.domain.Interfaces.Services;

namespace ToroInvestimentos.PatromonioAPI.Controllers
{
    [Route("api/movimentacoes")]
    [ApiController]
    public class TransacaoController : Controller
    {
        #region Variaveis injeção dependencia / Controle Acesso

        private readonly ITransacaoService _transacaoService;

        #endregion

        #region Construtor
        public TransacaoController(ITransacaoService transacaoService)
        {
            _transacaoService = transacaoService;
        }

        #endregion

        #region Métodos Públicos

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IList<Transacao>>> Get(string idContaCorrente)
        {
            try
            {
                var movimentacoes = await _transacaoService.BuscarAssincrono(cli => cli.ContaCorrenteId == idContaCorrente);
                movimentacoes = movimentacoes.OrderBy(mov => mov.DataOperacao).ThenBy(mov => mov.Hora).ToList();
                return Ok(movimentacoes);
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async void Post([FromBody] Transacao entity) 
        {
            await Task.FromResult(_transacaoService.Incluir<TransacaoValidator>(entity));
        }

        #endregion
    }
}