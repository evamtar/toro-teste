using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatrimonioPortal.Models
{
    public class ContaModel : BaseModel
    {
        public string Id { get; set; }
        public string Agencia { get; set; }
        public string Numero { get; set; }

        public string NumeroFormatado { 
            get 
            {
                if (string.IsNullOrEmpty(this.Numero))
                    return string.Empty;
                else 
                {
                    return this.Numero.Substring(0, this.Numero.Length - 1) + "-" + this.Numero.Substring(this.Numero.Length - 1);
                }
            } 
        }
        public decimal Saldo { get; set; }
    }
}
