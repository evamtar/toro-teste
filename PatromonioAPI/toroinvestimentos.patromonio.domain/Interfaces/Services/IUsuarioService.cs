using toroinvestimentos.patromonio.domain.Entities.Model;

namespace toroinvestimentos.patromonio.domain.Interfaces.Services
{
    public interface IUsuarioService : IService<Usuario>
    {
        Usuario Autenticar(Usuario entity);
    }
}
