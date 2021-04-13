using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using toroinvestimentos.patromonio.domain.Entities.Model.Base;
using toroinvestimentos.patromonio.domain.Interfaces.Repositories;
using toroinvestimentos.patromonio.domain.Interfaces.Services;

namespace toroinvestimentos.patromonio.service.Services.Base
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual T Incluir<V>(T entity) where V : AbstractValidator<T>
        {
            this.Validar<V>(entity);
            _repository.Incluir(entity);
            return entity;
        }


        public virtual T Alterar<V>(T entity) where V : AbstractValidator<T>
        {
            this.Validar<V>(entity);
            _repository.Atualizar(entity);
            return entity;
        }

        public virtual void Excluir(string id)
        {
            _repository.Excluir(id);
        }

        public IList<T> Buscar(Expression<Func<T, bool>> filter)
        {
            return _repository.Buscar(filter);
        }

        public async Task<IList<T>> BuscarAssincrono(Expression<Func<T, bool>> filter)
        {
            return await _repository.BuscarAssincrono(filter);
        }

        public virtual T Selecionar(Expression<Func<T, bool>> filter)
        {
            return _repository.Selecionar(filter);
        }

        public IList<T> SelecionarTodos()
        {
            return _repository.SelecionarTodos();
        }

        public async Task<IList<T>> SelecionarTodosAssincrono()
        {
            return await _repository.SelecionarTodosAssincrono();
        }

        protected void Validar<V>(T entity) where V : AbstractValidator<T>
        {
            AbstractValidator<T> validator = (AbstractValidator<T>)Activator.CreateInstance<V>();
            validator.ValidateAndThrow(entity);
        }

    }
}
