using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatrimonioPortal.Models
{
    public class PatrominioConsolidadoModel : BaseModel
    {
        public ClienteModel Cliente { get; set; }
        public ContaModel Conta { get; set; }
        public IList<AtivoModel> Ativos { get; set; }
        public IList<TransacaoModel> Transacoes { get; set; }

        public decimal TotalAtivos { 
            get 
            {
                var valorAtivos = this.Ativos != null ? this.CalculaTotalAtivos() : (decimal)0.00;
                return valorAtivos;
            } 
        }

        public decimal PatrimonioTotal { 
            get 
            {
                var valorDisponivel = this.Conta != null ? this.Conta.Saldo : (decimal) 0.00;
                return valorDisponivel + this.TotalAtivos;
            } 
        }

        private decimal CalculaTotalAtivos() 
        {
            var valorTotal = (decimal)0.00;
            foreach (var ativo in this.Ativos)
                valorTotal += ativo.ValorTotal;
            return valorTotal;
        }
    }
}
