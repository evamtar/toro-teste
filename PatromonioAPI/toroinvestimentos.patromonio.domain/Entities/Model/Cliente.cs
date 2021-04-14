using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using toroinvestimentos.patromonio.domain.Entities.Model.Base;

namespace toroinvestimentos.patromonio.domain.Entities.Model
{
    public class Cliente : BaseEntity
    {
        public string NomeCompleto { get; set; }
        public string Documento { get; set; }
        public bool Ativo { get; set; }
        [JsonIgnore]
        public string UsuarioId { get; set; }

        [JsonIgnore]
        public virtual ICollection<ContaCorrente> Contas { get; set; }

        [JsonIgnore]
        public virtual ICollection<Ativo> Ativos { get; set; }
        

        [JsonIgnore]
        /// <summary>
        /// Relacionamentos
        /// </summary>
        public virtual Usuario Usuario { get; set; }
    }
}
