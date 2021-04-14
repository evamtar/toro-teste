using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using toroinvestimentos.patromonio.domain.Entities.Model.Base;

namespace toroinvestimentos.patromonio.domain.Entities.Model
{
    public class Ativo : BaseEntity
    {
        public string CodigoBovespa { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }

        public decimal ValorUnitario { get; set; }

        public decimal ValorTotal 
        { 
            get 
            {
                return this.Quantidade * this.ValorUnitario;
            } 
        }

        [JsonIgnore]
        public string ClienteId { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Relacionamentos
        /// </summary>
        public virtual Cliente Cliente{ get; set; }
    }
}
