using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using toroinvestimentos.patromonio.domain.Entities.Model.Base;
using toroinvestimentos.patromonio.domain.Interfaces.Repositories;
using toroinvestimentos.patromonio.infra.data.Context;

namespace toroinvestimentos.patromonio.infra.data.Repository.Base
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        #region Variaveis 

        private readonly MySqlContext _context;

        #endregion

        #region Construtor

        /// <summary>
        /// Haverá injeção de dependecia do contexto
        /// </summary>
        /// <param name="context"></param>
        public BaseRepository(MySqlContext context)
        {
            _context = context;
        }

        #endregion

        #region Métodos Base

        public virtual void Incluir(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Atualizar(T entity)
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Excluir(string id)
        {
            _context.Set<T>().Remove(Selecionar(entity => entity.Id == id));
            _context.SaveChanges();
        }

        public virtual IList<T> Buscar(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }

        public virtual async Task<IList<T>> BuscarAssincrono(Expression<Func<T, bool>> filter)
        {
            return await _context.Set<T>().Where(filter).ToListAsync();
        }

        public virtual T Selecionar(Expression<Func<T, bool>> filter)
        {
            return _context.Set<T>().Where(filter).FirstOrDefault();
        }

        public virtual IList<T> SelecionarTodos()
        {
            return _context.Set<T>().ToList();
        }

        public virtual async Task<IList<T>> SelecionarTodosAssincrono()
        {
            return await _context.Set<T>().ToListAsync();
        }

        #endregion
    }
}
