using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using toroinvestimentos.patromonio.domain.Entities.Model;


namespace toroinvestimentos.patromonio.infra.data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.Ignore(e => e.Token);
            builder.Ignore(e => e.Expiracao);

            builder.Property(e => e.Id)
                .HasColumnName("USUARIO_ID")
                .HasMaxLength(50);

            builder.Property(e => e.Login)
                .HasColumnName("LOGIN")
                .HasMaxLength(100);

            builder.Property(e => e.SenhaCriptografada)
                .HasColumnName("SENHA_CRIPTOGRAFADA")
                .HasMaxLength(50);
        }
    }
}
