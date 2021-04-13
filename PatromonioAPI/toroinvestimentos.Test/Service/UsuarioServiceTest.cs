using FluentValidation;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using toroinvestimentos.patromonio.domain.Configuration;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Interfaces.Repositories;
using toroinvestimentos.patromonio.service.Services;
using Xunit;

namespace toroinvestimentos.Test.Service
{
    public class UsuarioServiceTest
    {
        #region Variaveis

        private readonly Mock<IUsuarioRepository> mockUsuarioRepository;
        private readonly IOptions<JWTConfiguration> settings;
        #endregion

        #region Construtor

        public UsuarioServiceTest()
        {
            mockUsuarioRepository = new Mock<IUsuarioRepository>();
            settings = Options.Create<JWTConfiguration>(new JWTConfiguration { Key= "afsdkjasjflxswafsdklk434orqiwup3457u-34oewir4irroqwiffv48mfs" });
        }

        #endregion

        #region Cenários de teste

        [Fact]
        public void UsuarioServiceTest_Autenticar_WithSucess_ReturnUserWithToken()
        {
            #region Prepare

            Usuario fakeUserInput = new Usuario
            {
                Login = "login",
                Senha = "senha",
                SenhaCriptografada = "senha_criptografada",
            };

            Usuario fakeUserReturn = new Usuario
            {
                Login = "login",
                Senha = "senha",
                SenhaCriptografada = "senha_criptografada",
            };
            fakeUserReturn.generatedData("id", "token", DateTime.Now.AddHours(1));
            mockUsuarioRepository.Setup(us => us.Buscar(It.IsAny<Expression<Func<Usuario, bool>>>())).Returns(new List<Usuario> { fakeUserReturn });

            #endregion

            #region Act

            var service = this.GetUsuarioService();
            var result = service.Autenticar(fakeUserInput);

            #endregion

            #region Asserts

            Assert.NotEqual(DateTime.MinValue, result.Expiracao);
            Assert.NotNull(result.Token);

            #endregion

        }

        [Fact]
        public void UsuarioServiceTest_Autenticar_WithFailLoginValidation()
        {
            #region Prepare

            Usuario fakeUserInput = new Usuario
            {
                Senha = "senha",
                SenhaCriptografada = "senha_criptografada",
            };

            #endregion

            #region Act

            var service = this.GetUsuarioService();
            var result = Assert.Throws<ValidationException>(() => service.Autenticar(fakeUserInput));

            #endregion

            #region Asserts

            Assert.Contains("login", result.Message);
            
            #endregion

        }

        [Fact]
        public void UsuarioServiceTest_Autenticar_WithFailSenhaValidation()
        {
            #region Prepare

            Usuario fakeUserInput = new Usuario
            {
                Login = "login"
            };

            #endregion

            #region Act

            var service = this.GetUsuarioService();
            var result = Assert.Throws<ValidationException>(() => service.Autenticar(fakeUserInput));

            #endregion

            #region Asserts

            Assert.Contains("senha", result.Message);

            #endregion

        }

        [Fact]
        public void UsuarioServiceTest_Autenticar_WithNullObjectValidation()
        {
            #region Prepare

            Usuario fakeUserInput = null;

            #endregion

            #region Act

            var service = this.GetUsuarioService();
            var result = Assert.Throws<ArgumentNullException>(() => service.Autenticar(fakeUserInput));

            #endregion

            #region Asserts

            Assert.Contains("null", result.Message);

            #endregion

        }

        #endregion

        #region Métodos Auxiliares Privados

        private UsuarioService GetUsuarioService()
        {
            return new UsuarioService(mockUsuarioRepository.Object, settings);
        }

        #endregion
    }
}
