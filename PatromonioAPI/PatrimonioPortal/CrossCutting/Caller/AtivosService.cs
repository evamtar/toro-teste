using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using PatrimonioPortal.Configuration;
using PatrimonioPortal.CrossCutting.Interface;
using PatrimonioPortal.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PatrimonioPortal.CrossCutting.Caller
{
    public class AtivosService : IAtivosService
    {
        private readonly HttpClient _cliente;
        private readonly IOptions<PatrimonioURL> _settings;
        private readonly IDistributedCache _cache;

        public AtivosService(IOptions<PatrimonioURL> settings,
                              IDistributedCache cache)
        {
            _settings = settings;
            _cache = cache;
            _cliente = new HttpClient();
            _cliente.BaseAddress = new Uri(_settings.Value.BaseURL);
        }

        public async Task<IList<AtivoModel>> GetListAtivosAsync(string token, string idCliente)
        {
            try
            {
                var ativosJson = await _cache.GetStringAsync("AtivoCliente_" + idCliente);
                if (ativosJson == null)
                {
                    _cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    _cliente.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                    string url = _settings.Value.AtivoURL + "?idCliente=" + idCliente;
                    HttpResponseMessage httpResponse = await _cliente.GetAsync(url);
                    string message = await httpResponse.Content.ReadAsStringAsync();
                    if (httpResponse.StatusCode != HttpStatusCode.OK && httpResponse.StatusCode != HttpStatusCode.NoContent)
                    {
                        throw new Exception(message);
                    }
                    else
                    {
                        if (httpResponse.StatusCode != HttpStatusCode.OK)
                            return new List<AtivoModel> { };

                        var returnModel = JsonConvert.DeserializeObject<IList<AtivoModel>>(message);
                        await _cache.SetStringAsync("AtivoCliente_" + idCliente, JsonConvert.SerializeObject(returnModel),
                                         new DistributedCacheEntryOptions
                                         {
                                             AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(15)
                                         });
                        return returnModel;
                    }
                }
                return JsonConvert.DeserializeObject<IList<AtivoModel>>(ativosJson);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
