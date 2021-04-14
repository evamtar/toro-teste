using PatrimonioPortal.Models;
using System.Threading.Tasks;

namespace PatrimonioPortal.CrossCutting.Interface
{
    public interface IClienteService
    {
        Task<ClienteModel> GetClientAsync(string token, string idUsuario);
    }
}
