using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Exceptions;
using toroinvestimentos.patromonio.domain.Interfaces.Services;

namespace ToroInvestimentos.PatromonioAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {

        #region Variaveis injeção dependencia / Controle Acesso

        private readonly IUsuarioService _usuarioService;

        #endregion

        #region Construtor
        public AutenticacaoController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        #endregion

        #region Métodos Públicos

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Autenticar([FromBody] Usuario usuario)
        {
            try
            {
                usuario = _usuarioService.Autenticar(usuario);
                return Ok(usuario);
            }
            catch (InvalidLoginException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                return Forbid(ex.Message);
            }
        }

        #endregion


    }
}
