using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using toroinvestimentos.patromonio.domain.Entities.Model;

namespace toroinvestimentos.patromonio.infra.data.Mapping
{
    public class ContaCorrenteMap : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.ToTable("CONTA_CORRENTE");

            builder.Property(e => e.Id)
                .HasColumnName("CONTA_CORRENTE_ID")
                .HasMaxLength(50);

            builder.Property(e => e.Agencia)
                .HasColumnName("AGENCIA")
                .HasMaxLength(10);

            builder.Property(e => e.Numero)
                .HasColumnName("NUMERO")
                .HasMaxLength(20);

            builder.Property(e => e.Saldo)
                .HasColumnName("SALDO");

            builder.Property(e => e.ClienteId)
                .HasColumnName("CLIENTE_ID")
                .HasMaxLength(50);

            builder.HasOne(d => d.Cliente)
                .WithMany(p => p.Contas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
