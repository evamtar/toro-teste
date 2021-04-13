using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Interfaces.Repositories;
using toroinvestimentos.patromonio.domain.Interfaces.Services;
using toroinvestimentos.patromonio.service.Services.Base;

namespace toroinvestimentos.patromonio.service.Services
{
    public class ContaCorrenteService : BaseService<ContaCorrente>, IContaCorrenteService
    {
        #region Variaveis

        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        
        #endregion

        #region Construtor

        public ContaCorrenteService(IContaCorrenteRepository contaCorrenteRepository) : base(contaCorrenteRepository)
        {
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        #endregion
    }
}
