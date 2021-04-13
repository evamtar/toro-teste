using System;
using System.Collections.Generic;
using System.Text;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.domain.Interfaces.Repositories;
using toroinvestimentos.patromonio.infra.data.Context;
using toroinvestimentos.patromonio.infra.data.Repository.Base;

namespace toroinvestimentos.patromonio.infra.data.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        #region Variaveis

        private readonly MySqlContext _context;

        #endregion

        #region Construtor

        public ClienteRepository(MySqlContext context) : base(context)
        {
            _context = context;
        }

        #endregion
    }
}
