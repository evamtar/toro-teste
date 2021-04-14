using PatrimonioPortal.Configuration;
using PatrimonioPortal.Models;
using System.Net.Http;
using Microsoft.Extensions.Options;
using PatrimonioPortal.CrossCutting.Interface;
using System;
using Newtonsoft.Json;
using System.Text;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;

namespace PatrimonioPortal.CrossCutting.Caller
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _cliente;
        private readonly IOptions<PatrimonioURL> _settings;
        public LoginService(IOptions<PatrimonioURL> settings) 
        {
            _settings = settings;
            _cliente = new HttpClient();
            _cliente.BaseAddress = new Uri(_settings.Value.BaseURL);
        }

        public async Task<LoginModel> AutenticarAsync(LoginModel entity) 
        {
            try
            {
                HttpResponseMessage httpResponse = await _cliente.PostAsJsonAsync<LoginModel>(_settings.Value.LoginUrl, entity);
                string message = await httpResponse.Content.ReadAsStringAsync();
                if (httpResponse.StatusCode != HttpStatusCode.OK) 
                {
                    throw new Exception(message);
                }
                else
                    return JsonConvert.DeserializeObject<LoginModel>(message);
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }
    }
}
