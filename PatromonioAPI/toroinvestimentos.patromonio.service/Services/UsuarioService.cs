using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using toroinvestimentos.patromonio.domain.Configuration;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Entities.Validator;
using toroinvestimentos.patromonio.domain.Exceptions;
using toroinvestimentos.patromonio.domain.Interfaces.Repositories;
using toroinvestimentos.patromonio.domain.Interfaces.Services;
using toroinvestimentos.patromonio.service.Services.Base;

namespace toroinvestimentos.patromonio.service.Services
{
    public class UsuarioService : BaseService<Usuario>, IUsuarioService
    {
        #region Variaveis

        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IOptions<JWTConfiguration> _settings;

        #endregion

        #region Construtor

        public UsuarioService(IUsuarioRepository usuarioRepository,
                              IOptions<JWTConfiguration> settings) : base(usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _settings = settings;
        }

        #endregion

        #region Metodos Publicos

        public Usuario Autenticar(Usuario entity)
        {
            base.Validar<UsuarioValidator>(entity);
            List<Usuario> usuarios = _usuarioRepository.Buscar(us => us.Login == entity.Login).ToList();
            if (!usuarios.Any() || ((entity.SenhaCriptografada) != usuarios.FirstOrDefault().SenhaCriptografada))
                throw new InvalidLoginException("O login / senha inválidos.");
            else
            {
                entity.generatedData(usuarios.FirstOrDefault().Id, this.GerarToken(entity, usuarios.FirstOrDefault().Id), DateTime.UtcNow.AddHours(1));
            }
            return entity;
        }

        #endregion

        #region Metodos Privados

        private string GerarToken(Usuario entity, string userData)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_settings.Value.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.UserData, userData),
                    new Claim(ClaimTypes.Name, entity.Login)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        #endregion
    }
}
