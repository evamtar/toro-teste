using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Interfaces.Repositories;
using toroinvestimentos.patromonio.domain.Interfaces.Services;
using toroinvestimentos.patromonio.service.Services.Base;

namespace toroinvestimentos.patromonio.service.Services
{
    public class AtivoService : BaseService<Ativo>, IAtivoService
    {
        #region Variaveis

        private readonly IAtivoRepository _ativoRepository;
        
        #endregion

        #region Construtor

        public AtivoService(IAtivoRepository ativoRepository) : base(ativoRepository)
        {
            _ativoRepository = ativoRepository;
        }

        #endregion
    }
}
