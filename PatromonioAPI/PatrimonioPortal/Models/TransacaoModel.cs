using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatrimonioPortal.Models
{
    public class TransacaoModel : BaseModel
    {
        public string TipoOperacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataOperacao { get; set; }
        public string HoraOperacao { get; set; }
    }
}
