using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using toroinvestimentos.patromonio.domain.Entities.Model.Base;

namespace toroinvestimentos.patromonio.domain.Entities.Model
{
    public class ContaCorrente : BaseEntity
    {
        public string Agencia { get; set; }
        public string Numero { get; set; }
        public decimal Saldo { get; set; }

        [JsonIgnore]
        public string ClienteId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Transacao> Movimentacoes { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Relacionamentos
        /// </summary>
        public virtual Cliente Cliente { get; set; }
    }
}
