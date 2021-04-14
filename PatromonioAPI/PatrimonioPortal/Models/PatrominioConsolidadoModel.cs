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
    }
}
