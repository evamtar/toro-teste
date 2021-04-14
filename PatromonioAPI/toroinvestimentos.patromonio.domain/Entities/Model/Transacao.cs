using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using toroinvestimentos.patromonio.domain.Entities.Model.Base;

namespace toroinvestimentos.patromonio.domain.Entities.Model
{
    public class Transacao : BaseEntity
    {
        public string TipoOperacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataOperacao {get;set;}

        [JsonIgnore]
        public TimeSpan Hora { get; set; }

        public string HoraOperacao 
        { 
            get 
            {
                return string.Concat(this.Hora.Hours.ToString("00"), ":", this.Hora.Minutes.ToString("00"), ":", this.Hora.Seconds.ToString("00"));
            } 
        }

        [JsonIgnore]
        public string ContaCorrenteId { get; set; }

        [JsonIgnore]
        /// <summary>
        /// Relacionamentos
        /// </summary>
        public ContaCorrente Conta { get; set; }
    }
}
