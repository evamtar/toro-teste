using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using toroinvestimentos.patromonio.domain.Configuration;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Interfaces.CrossCutting;

namespace toroinvestimentos.patromonio.infra.crosscutting.ExternalServices
{
    public class ConsultaBovespaService : IConsultaBovespaService
    {
        #region Variaveis

        private readonly IOptions<BovespaConfiguration> _settings;
        
        #endregion

        #region Construtor

        public ConsultaBovespaService(IOptions<BovespaConfiguration> settings) 
        {
            _settings = settings;
        }

        #endregion

        public Task<BovespaExternal> ConsultaValor(BovespaExternal entity)
        {
            var fullPath = Path.Combine(Environment.CurrentDirectory, "acoes_simulador.json");
            var content = new List<BovespaExternal> {
                new BovespaExternal
                {
                    CodigoPapel = "PETR4",
                    Valor = (decimal)24.33
                },
                new BovespaExternal
                {
                    CodigoPapel = "CMIG4",
                    Valor = (decimal)12.94
                },
                new BovespaExternal
                {
                    CodigoPapel = "VVAR3",
                    Valor = (decimal)12.73
                },
            };
            var returnValue = content.Find(atv => atv.CodigoPapel == entity.CodigoPapel);
            return Task.FromResult(this.RandomizarUltimoNumero(returnValue));
        }

        private BovespaExternal RandomizarUltimoNumero(BovespaExternal input) 
        {
            if (input == null)
                return new BovespaExternal { Valor = (decimal)new Random().NextDouble() };
            else
            {
                var randomNumber = new Random().Next(1, 10);
                input.Valor += randomNumber % 2 == 0 ? (decimal)0.01 : randomNumber % 3 == 0 ? (decimal)-0.02 : (decimal)0.03;
            }
            return input;
        }
    }
}
