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
using Microsoft.Extensions.Caching.Distributed;

namespace PatrimonioPortal.CrossCutting.Caller
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _cliente;
        private readonly IOptions<PatrimonioURL> _settings;
        private readonly IDistributedCache _cache;
        public ClienteService(IOptions<PatrimonioURL> settings,
                              IDistributedCache cache) 
        {
            _settings = settings;
            _cache = cache;
            _cliente = new HttpClient();
            _cliente.BaseAddress = new Uri(_settings.Value.BaseURL);
        }

        public async Task<ClienteModel> GetClientAsync(string token, string idUsuario)
        {
            try
            {
                var clienteJson = await _cache.GetStringAsync("Cliente_" + idUsuario);
                if (clienteJson == null) 
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
                        await _cache.SetStringAsync("Cliente_" + idUsuario, JsonConvert.SerializeObject(returnModel), 
                                         new DistributedCacheEntryOptions {
                                             AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(5)
                                         });
                        return returnModel;
                    }
                }
                return JsonConvert.DeserializeObject<ClienteModel>(clienteJson);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
