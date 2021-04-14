using PatrimonioPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatrimonioPortal.CrossCutting.Interface
{
    public interface ITransacaoService
    {
        Task<IList<TransacaoModel>> GetListAsync(string token, string idContaCorrente);
    }
}
