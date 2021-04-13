using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using toroinvestimentos.patromonio.domain.Entities.Model.Base;

namespace toroinvestimentos.patromonio.domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Incluir(T entity);

        void Atualizar(T entity);

        void Excluir(string id);

        T Selecionar(Expression<Func<T, bool>> filter);

        IList<T> Buscar(Expression<Func<T, bool>> filter);

        Task<IList<T>> BuscarAssincrono(Expression<Func<T, bool>> filter);

        IList<T> SelecionarTodos();

        Task<IList<T>> SelecionarTodosAssincrono();
    }
}
