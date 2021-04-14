using PatrimonioPortal.Models;
using System.Threading.Tasks;

namespace PatrimonioPortal.CrossCutting.Interface
{
    public interface IContaCorrenteService
    {
        Task<ContaModel> GetContaCorrentAsync(string token, string idCliente);
    }
}
