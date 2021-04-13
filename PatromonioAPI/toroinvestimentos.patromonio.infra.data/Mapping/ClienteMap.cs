using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using toroinvestimentos.patromonio.domain.Entities.Model;

namespace toroinvestimentos.patromonio.infra.data.Mapping
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("CLIENTE");

            builder.Property(e => e.Id)
                .HasColumnName("CLIENTE_ID")
                .HasMaxLength(50);

            builder.Property(e => e.NomeCompleto)
                .HasColumnName("NOME_COMPLETO")
                .HasMaxLength(150);

            builder.Property(e => e.Documento)
                .HasColumnName("DOCUMENTO")
                .HasMaxLength(20);

            builder.Property(e => e.Ativo)
                .HasColumnName("ATIVO");

            builder.Property(e => e.UsuarioId)
                .HasColumnName("USUARIO_ID")
                .HasMaxLength(50);

            builder.HasOne(d => d.Usuario)
                .WithMany(p => p.Clientes)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
