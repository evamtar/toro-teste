using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using toroinvestimentos.patromonio.domain.Entities.Model;

namespace toroinvestimentos.patromonio.infra.data.Mapping
{
    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("TRANSACAO");

            builder.Property(e => e.Id)
                .HasColumnName("TRANSACAO_ID")
                .HasMaxLength(50);

            builder.Property(e => e.TipoOperacao)
                .HasColumnName("TIPO_OPERACAO")
                .HasMaxLength(1);

            builder.Property(e => e.Valor)
                .HasColumnName("VALOR");

            builder.Property(e => e.DataOperacao)
                .HasColumnName("DATA_OPERACAO");

            builder.Property(e => e.HoraOperacao)
                .HasColumnName("HORA_OPERACAO");

            builder.Property(e => e.ContaCorrenteId)
                .HasColumnName("CONTA_CORRENTE_ID")
                .HasMaxLength(50);

            builder.HasOne(d => d.Conta)
                .WithMany(p => p.Movimentacoes)
                .HasForeignKey(d => d.ContaCorrenteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
