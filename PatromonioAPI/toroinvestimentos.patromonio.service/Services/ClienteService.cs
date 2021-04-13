using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Interfaces.Repositories;
using toroinvestimentos.patromonio.domain.Interfaces.Services;
using toroinvestimentos.patromonio.service.Services.Base;

namespace toroinvestimentos.patromonio.service.Services
{
    public class ClienteService : BaseService<Cliente>, IClienteService
    {
        #region Variaveis

        private readonly IClienteRepository _clienteRepository;
        
        #endregion

        #region Construtor

        public ClienteService(IClienteRepository clienteRepository) : base(clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        #endregion
    }
}
