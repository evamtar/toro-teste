using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PatrimonioPortal.Configuration;
using PatrimonioPortal.CrossCutting.Interface;
using PatrimonioPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PatrimonioPortal.CrossCutting.Caller
{
    public class TransacaoService : ITransacaoService
    {
        private readonly HttpClient _cliente;
        private readonly IOptions<PatrimonioURL> _settings;
        public TransacaoService(IOptions<PatrimonioURL> settings)
        {
            _settings = settings;
            _cliente = new HttpClient();
            _cliente.BaseAddress = new Uri(_settings.Value.BaseURL);
        }

        public async Task<IList<TransacaoModel>> GetListAsync(string token, string idContaCorrente)
        {
            try
            {
                _cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string url = _settings.Value.TransacaoUrl + "?idContaCorrente=" + idContaCorrente;
                HttpResponseMessage httpResponse = await _cliente.GetAsync(url);
                string message = await httpResponse.Content.ReadAsStringAsync();
                if (httpResponse.StatusCode != HttpStatusCode.OK && httpResponse.StatusCode != HttpStatusCode.NoContent)
                {
                    throw new Exception(message);
                }
                else
                {
                    if (httpResponse.StatusCode != HttpStatusCode.OK)
                        return new List<TransacaoModel> { };

                    var returnModel = JsonConvert.DeserializeObject<IList<TransacaoModel>>(message);
                    return returnModel;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
