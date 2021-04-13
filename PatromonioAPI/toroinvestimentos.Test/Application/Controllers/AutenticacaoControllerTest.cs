using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Exceptions;
using toroinvestimentos.patromonio.domain.Interfaces.Services;
using ToroInvestimentos.PatromonioAPI.Controllers;
using Xunit;

namespace toroinvestimentos.Test.Application.Controllers
{
    public class AutenticacaoControllerTest
    {
        #region Variaveis

        private readonly Mock<IUsuarioService>  mockUsuarioService;

        #endregion

        #region Construtor

        public AutenticacaoControllerTest() 
        {
            mockUsuarioService = new Mock<IUsuarioService>();
        }

        #endregion

        #region Cenários de teste

        [Fact]
        public void AutenticacaoControllerTest_Autenticar_WithSucess() 
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
            mockUsuarioService.Setup(us => us.Autenticar(It.IsAny<Usuario>())).Returns(fakeUserReturn);

            #endregion

            #region Act

            var controller = this.GetController();
            var result = controller.Autenticar(fakeUserInput);
            var okResult = Assert.IsType<OkObjectResult>(result);
            
            
            #endregion

            #region Asserts

            Assert.Equal(200, okResult.StatusCode);
            Assert.Equal(fakeUserReturn, okResult.Value);

            #endregion

        }

        [Fact]
        public void AutenticacaoControllerTest_Autenticar_WithInvalidLoginOrPassword()
        {
            #region Prepare

            Usuario fakeUserInput = new Usuario
            {
                Login = "login",
                Senha = "senha",
                SenhaCriptografada = "senha_criptografada",
            };
            mockUsuarioService.Setup(us => us.Autenticar(It.IsAny<Usuario>())).Throws<InvalidLoginException>();

            #endregion

            #region Act

            var controller = this.GetController();
            var result = controller.Autenticar(fakeUserInput);
            var unauthorized = Assert.IsType<UnauthorizedObjectResult>(result);


            #endregion

            #region Asserts

            Assert.Equal(401, unauthorized.StatusCode);
            
            #endregion

        }

        [Fact]
        public void AutenticacaoControllerTest_Autenticar_WithAnyException()
        {
            #region Prepare

            Usuario fakeUserInput = new Usuario
            {
                Login = "login",
                Senha = "senha",
                SenhaCriptografada = "senha_criptografada",
            };
            mockUsuarioService.Setup(us => us.Autenticar(It.IsAny<Usuario>())).Throws<Exception>();

            #endregion

            #region Act

            var controller = this.GetController();
            var result = controller.Autenticar(fakeUserInput);
            var forbid = Assert.IsType<ForbidResult>(result);


            #endregion

            #region Asserts

            Assert.Contains("Exception", forbid.AuthenticationSchemes[0]);

            #endregion

        }

        #endregion

        #region Métodos Auxiliares Privados

        private AutenticacaoController GetController() 
        {
            return new AutenticacaoController(mockUsuarioService.Object);
        }

        #endregion
    }
}
