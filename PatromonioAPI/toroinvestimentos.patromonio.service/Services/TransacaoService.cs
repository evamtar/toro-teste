

using System;
using System.Linq;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Exceptions;
using toroinvestimentos.patromonio.domain.Interfaces.Repositories;
using toroinvestimentos.patromonio.domain.Interfaces.Services;
using toroinvestimentos.patromonio.service.Services.Base;

namespace toroinvestimentos.patromonio.service.Services
{
    public class TransacaoService : BaseService<Transacao>, ITransacaoService
    {
        #region Variaveis

        private readonly ITransacaoRepository _transacaoRepository;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        #endregion

        #region Construtor

        public TransacaoService(ITransacaoRepository transacaoRepository,
                                IContaCorrenteRepository contaCorrenteRepository
            ) : base(transacaoRepository)
        {
            _transacaoRepository = transacaoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        #endregion

        #region Métodos Públicos

        public override Transacao Incluir<V>(Transacao entity)
        {
            entity.DataOperacao = DateTime.Now;
            entity.Hora = DateTime.Now.TimeOfDay;
            this.Validar<V>(entity);
            var transacao = entity;
            var contasCorrente = _contaCorrenteRepository.Buscar(cc => cc.Id == entity.ContaCorrenteId);
            if (!contasCorrente.Any())
                throw new ContaCorrenteException("A operação não pode ser realizada. Tente mais tarde");
            else {
                var conta = contasCorrente.FirstOrDefault();
                if (conta.Saldo < entity.Valor)
                    throw new ContaCorrenteException("Saldo insuficiente.");
                else
                {
                    conta.Saldo -= entity.Valor;
                    _contaCorrenteRepository.Atualizar(conta);
                    transacao = base.Incluir<V>(entity);
                }
            }
            return transacao;
        }

        #endregion
    }
}
