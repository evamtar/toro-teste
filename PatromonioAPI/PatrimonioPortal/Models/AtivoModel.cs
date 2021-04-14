﻿namespace PatrimonioPortal.Models
{
    public class AtivoModel : BaseModel
    {
        public string CodigoBovespa { get; set; }
        public string Descricao { get; set; }
        public int Quantidade { get; set; }
        public decimal ValorUnitario { get; set; }
        public decimal ValorTotal{ get;set;}
    }
}
