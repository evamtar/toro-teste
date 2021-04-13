using Microsoft.EntityFrameworkCore;
using toroinvestimentos.patromonio.domain.Entities.Model;
using toroinvestimentos.patromonio.infra.data.Mapping;

namespace toroinvestimentos.patromonio.infra.data.Context
{
    public class MySqlContext : DbContext
    {
        #region Construtor

        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options)
        {
        }

        #endregion

        #region DbSet 

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ContaCorrente> Contas { get; set; }
        public DbSet<Transacao> Movimentacoes { get; set; }

        #endregion

        #region Overrided Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<ContaCorrente>(new ContaCorrenteMap().Configure);
            modelBuilder.Entity<Transacao>(new TransacaoMap().Configure);
        }

        #endregion
    }
}
