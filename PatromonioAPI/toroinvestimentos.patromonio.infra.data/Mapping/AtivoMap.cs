using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using toroinvestimentos.patromonio.domain.Entities.Model;

namespace toroinvestimentos.patromonio.infra.data.Mapping
{
    class AtivoMap : IEntityTypeConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.ToTable("ATIVOS");


            builder.Ignore(e => e.ValorUnitario);
            builder.Ignore(e => e.ValorTotal);

            builder.Property(e => e.Id)
                .HasColumnName("ATIVO_ID")
                .HasMaxLength(50);

            builder.Property(e => e.CodigoBovespa)
                .HasColumnName("CODIGO_BOVESPA")
                .HasMaxLength(150);

            builder.Property(e => e.Descricao)
                .HasColumnName("DESCRICAO")
                .HasMaxLength(20);

            builder.Property(e => e.Quantidade)
                .HasColumnName("QUANTIDADE");

            builder.Property(e => e.ClienteId)
                .HasColumnName("CLIENTE_ID")
                .HasMaxLength(50);

            builder.HasOne(d => d.Cliente)
                .WithMany(p => p.Ativos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
