using PatrimonioPortal.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PatrimonioPortal.CrossCutting.Interface
{
    public interface IAtivosService
    {
        Task<IList<AtivoModel>> GetListAtivosAsync(string token, string idCliente);
    }
}
