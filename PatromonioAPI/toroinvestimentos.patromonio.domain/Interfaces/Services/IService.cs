using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using toroinvestimentos.patromonio.domain.Entities.Model.Base;

namespace toroinvestimentos.patromonio.domain.Interfaces.Services
{
    public interface IService<T> where T : BaseEntity
                                    
    {
        T Incluir<V>(T obj) where V : AbstractValidator<T>;

        T Alterar<V>(T obj) where V : AbstractValidator<T>;

        void Excluir(string id);

        T Selecionar(Expression<Func<T, bool>> filter);

        IList<T> Buscar(Expression<Func<T, bool>> filter);

        Task<IList<T>> BuscarAssincrono(Expression<Func<T, bool>> filter);

        IList<T> SelecionarTodos();

        Task<IList<T>> SelecionarTodosAssincrono();

    }
}
