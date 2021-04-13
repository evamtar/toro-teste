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
        
        #endregion

        #region Overrided Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
        }

        #endregion
    }
}
