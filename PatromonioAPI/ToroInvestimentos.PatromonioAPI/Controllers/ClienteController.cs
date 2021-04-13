using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Interfaces.Services;

namespace ToroInvestimentos.PatromonioAPI.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        #region Variaveis injeção dependencia / Controle Acesso

        private readonly IClienteService _clienteService;

        #endregion

        #region Construtor
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        #endregion

        #region Métodos Públicos

        [Authorize]
        [HttpGet]
        public async Task<ActionResult<Cliente>> Get(string idUsuario)
        {
            try
            {
                var cliente = await _clienteService.SelecionarAssincrono(cli => cli.UsuarioId == idUsuario);
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }


        #endregion
    }
}