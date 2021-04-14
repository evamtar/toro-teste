using PatrimonioPortal.Configuration;
using PatrimonioPortal.Models;
using System.Net.Http;
using Microsoft.Extensions.Options;
using PatrimonioPortal.CrossCutting.Interface;
using System;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http.Headers;

namespace PatrimonioPortal.CrossCutting.Caller
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _cliente;
        private readonly IOptions<PatrimonioURL> _settings;
        public ClienteService(IOptions<PatrimonioURL> settings) 
        {
            _settings = settings;
            _cliente = new HttpClient();
            _cliente.BaseAddress = new Uri(_settings.Value.BaseURL);
        }

        public async Task<ClienteModel> GetClientAsync(string token, string idUsuario)
        {
            try
            {
                _cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string url = _settings.Value.ClienteUrl + "?idUsuario=" + idUsuario;
                HttpResponseMessage httpResponse = await _cliente.GetAsync(url);
                string message = await httpResponse.Content.ReadAsStringAsync();
                if (httpResponse.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(message);
                }
                else 
                {
                    var returnModel = JsonConvert.DeserializeObject<ClienteModel>(message);
                    returnModel.Token = token;
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
